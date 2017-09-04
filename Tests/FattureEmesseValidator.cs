using System.Collections.Generic;
using System.Linq;
using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureEmesseValidator : BaseClass<FattureEmesse, ComunicazioneFattureCorrispettivi.Validators.FattureEmesseValidator>
    {

        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.CedenteCessionarioValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.CedenteCessionarioDatiFatturaBodyValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteCollectionCannotBeEmpty()
        {
            AssertCollectionCannotBeEmpty(x => x.CessionarioCommittente);
        }
        [TestMethod]
        public void CessionarioCommittenteCollectionMinMaxItems()
        {
            const int max = 1000;
            var obj = new CessionarioCommittente();
            challenge.CessionarioCommittente.AddRange(Enumerable.Repeat(obj, max));

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CessionarioCommittente"));

            challenge.CessionarioCommittente.Add(new CessionarioCommittente());
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CessionarioCommittente"));
        }
        [TestMethod]
        public void RettificaAllowedWithSingleDocument00447()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            challenge.CessionarioCommittente.AddRange(new List<CessionarioCommittente>() { new CessionarioCommittente(), new CessionarioCommittente() });
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            challenge.CessionarioCommittente.Clear();
            challenge.CessionarioCommittente.Add(new CessionarioCommittente());
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");
            challenge.CessionarioCommittente[0].DatiFatturaBody.AddRange(new List<DatiFatturaBody>() { new DatiFatturaBody(), new DatiFatturaBody() });
            validator.ShouldHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge).WithErrorCode("00447");

            challenge.CessionarioCommittente[0].DatiFatturaBody.Clear();
            challenge.CessionarioCommittente[0].DatiFatturaBody.Add(new DatiFatturaBody());
            validator.ShouldNotHaveValidationErrorFor(x => x.Rettifica.IdFile, challenge);
        }
    }
}
