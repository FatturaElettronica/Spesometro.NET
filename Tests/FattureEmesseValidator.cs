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
                typeof(ComunicazioneFattureCorrispettivi.Validators.CedentePrestatoreDTEValidator));
        }
    }
}
