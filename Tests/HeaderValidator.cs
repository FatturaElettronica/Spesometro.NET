using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComunicazioneFattureCorrispettivi.Header;

namespace Tests
{
    [TestClass]
    public class HeaderValidator :
        BaseClass<Header, ComunicazioneFattureCorrispettivi.Validators.HeaderValidator>
    {
        [TestMethod]
        public void ProgressivoInvioIsOptional()
        {
            AssertOptional(x => x.ProgressivoInvio);
        }
        [TestMethod]
        public void ProgressivoInvioMinMaxLength()
        {
            AssertMinMaxLength(x => x.ProgressivoInvio, 1, 10);
        }
        [TestMethod]
        public void DichiaranteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Dichiarante, typeof(ComunicazioneFattureCorrispettivi.Validators.DichiaranteValidator));
        }
    }
}
