using System.Collections.Generic;
using System.Linq;
using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.FattureRicevute;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureRicevuteValidator : BaseClass<FattureRicevute, ComunicazioneFattureCorrispettivi.Validators.FattureRicevuteValidator>
    {

        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.CedenteCessionarioValidator));
        }
        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.CedenteCessionarioDatiFatturaBodyValidator));
        }
        [TestMethod]
        public void CedentePrestatoreCollectionCannotBeEmpty()
        {
            AssertCollectionCannotBeEmpty(x => x.CedentePrestatore);
        }
        [TestMethod]
        public void CedentePrestatoreCollectionMinMaxItems()
        {
            const int max = 1000;
            var obj = new CedentePrestatore();
            challenge.CedentePrestatore.AddRange(Enumerable.Repeat(obj, max));

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CedentePrestatore"));

            challenge.CedentePrestatore.Add(new CedentePrestatore());
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CedentePrestatore"));
        }
        [TestMethod]
        public void RettificaAllowedWithSingleDocument00447()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            var cedentePrestatore = new CedentePrestatore();
            challenge.CedentePrestatore.AddRange(Enumerable.Repeat(cedentePrestatore, 2));
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            challenge.CedentePrestatore.Clear();
            challenge.CedentePrestatore.Add(cedentePrestatore);
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            var datiFatturaBody = new ComunicazioneFattureCorrispettivi.FattureRicevute.DatiFatturaBody();
            challenge.CedentePrestatore[0].DatiFatturaBody.AddRange(Enumerable.Repeat(datiFatturaBody,2));
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            challenge.CedentePrestatore[0].DatiFatturaBody.Clear();
            challenge.CedentePrestatore[0].DatiFatturaBody.Add(datiFatturaBody);
            validator.ShouldNotHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge);
        }
    }
}
