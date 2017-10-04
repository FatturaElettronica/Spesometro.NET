using System.Collections.Generic;
using System.Linq;
using Spesometro.Common;
using Spesometro.FattureRicevute;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureRicevuteValidator : BaseClass<FattureRicevute, Spesometro.Validators.FattureRicevuteValidator>
    {

        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, 
                typeof(Spesometro.Validators.CessionarioCommittenteDTRValidator));
        }
        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, 
                typeof(Spesometro.Validators.CedentePrestatoreDTRValidator));
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
            challenge.Rettifica.Posizione = 1;
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            var cedentePrestatore = new CedentePrestatore();
            challenge.CedentePrestatore.AddRange(Enumerable.Repeat(cedentePrestatore, 2));
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            challenge.CedentePrestatore.Clear();
            challenge.CedentePrestatore.Add(cedentePrestatore);
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            var datiFatturaBody = new Spesometro.FattureRicevute.DatiFatturaBody();
            challenge.CedentePrestatore[0].DatiFatturaBody.AddRange(Enumerable.Repeat(datiFatturaBody,2));
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));

            challenge.Rettifica.Posizione = 0;
            challenge.CedentePrestatore[0].DatiFatturaBody.Clear();
            challenge.CedentePrestatore[0].DatiFatturaBody.Add(datiFatturaBody);
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Rettifica" && x.ErrorCode == "00447"));
        }
    }
}
