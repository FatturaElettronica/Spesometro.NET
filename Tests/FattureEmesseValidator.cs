using System.Collections.Generic;
using System.Linq;
using ComunicazioneFattureEmesseRicevute.Common;
using ComunicazioneFattureEmesseRicevute.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureEmesseValidator : BaseClass<FattureEmesse, ComunicazioneFattureEmesseRicevute.Validators.FattureEmesseValidator>
    {

        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.CedentePrestatoreDTEValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.CessionarioCommittenteDTEValidator));
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
            challenge.Rettifica.Posizione = 1;
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            challenge.CessionarioCommittente.AddRange(new List<CessionarioCommittente>() { new CessionarioCommittente(), new CessionarioCommittente() });
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            challenge.CessionarioCommittente.Clear();
            challenge.CessionarioCommittente.Add(new CessionarioCommittente());
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            challenge.CessionarioCommittente[0].DatiFatturaBody.AddRange(new List<DatiFatturaBody>() { new DatiFatturaBody(), new DatiFatturaBody() });
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            challenge.Rettifica.Posizione = 0;
            challenge.CessionarioCommittente[0].DatiFatturaBody.Clear();
            challenge.CessionarioCommittente[0].DatiFatturaBody.Add(new DatiFatturaBody());
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));
        }
    }
}
