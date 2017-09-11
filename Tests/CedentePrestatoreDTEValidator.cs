using ComunicazioneFattureEmesseRicevute.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CedentePrestatoreDTEValidator : BaseClass<CedentePrestatore, 
        ComunicazioneFattureEmesseRicevute.Validators.CedentePrestatoreDTEValidator>
    {

        [TestMethod]
        public void IdentificativiFiscaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IdentificativiFiscali, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.IdentificativiFiscaliCedentePrestatoreDTEValidator));
        }
        [TestMethod]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.AltriDatiIdentificativi, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.AltriDatiIdentificativiItaliaValidator));
        }
    }
}
