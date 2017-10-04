using Spesometro.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CedentePrestatoreDTEValidator : BaseClass<CedentePrestatore, 
        Spesometro.Validators.CedentePrestatoreDTEValidator>
    {

        [TestMethod]
        public void IdentificativiFiscaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IdentificativiFiscali, 
                typeof(Spesometro.Validators.IdentificativiFiscaliCedentePrestatoreDTEValidator));
        }
        [TestMethod]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.AltriDatiIdentificativi, 
                typeof(Spesometro.Validators.AltriDatiIdentificativiItaliaValidator));
        }
    }
}
