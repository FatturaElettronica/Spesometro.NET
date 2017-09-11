using System.Linq;
using ComunicazioneFattureEmesseRicevute.Common;
using ComunicazioneFattureEmesseRicevute.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CessionarioCommittenteDTEValidator : BaseClass<CessionarioCommittente, ComunicazioneFattureEmesseRicevute.Validators.CessionarioCommittenteDTEValidator>
    {

        [TestMethod]
        public void IdentificativiFiscaliHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.IdentificativiFiscali,
                typeof(ComunicazioneFattureEmesseRicevute.Validators.IdentificativiFiscaliCessionarioCommittenteDTEValidator));
        }
        [TestMethod]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.AltriDatiIdentificativi,
                typeof(ComunicazioneFattureEmesseRicevute.Validators.AltriDatiIdentificativiValidator));
        }
        [TestMethod]
        public void DatiFatturaBodyCollectionMinMaxItems()
        {
            const int max = 1000;
            var obj = new DatiFatturaBody();
            challenge.DatiFatturaBody.AddRange(Enumerable.Repeat(obj, max));

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiFatturaBody"));

            challenge.DatiFatturaBody.Add(new DatiFatturaBody());
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "DatiFatturaBody"));
        }
    }
}
