using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CedentePrestatoreDTEValidator : BaseClass<CedentePrestatore, ComunicazioneFattureCorrispettivi.Validators.CedentePrestatoreDTEValidator>
    {

        [TestMethod]
        public void IdentificativiFiscaliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IdentificativiFiscali, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.IdentificativiFiscaliItaliaValidator));
        }
        [TestMethod]
        public void AltriDatiIdentificativiHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.AltriDatiIdentificativi, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.AltriDatiIdentificativiValidator));
        }
    }
}
