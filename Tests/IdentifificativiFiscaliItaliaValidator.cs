using ComunicazioneFattureCorrispettivi.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class IdentificativiFiscaliItaliaValidator : BaseClass<IdentificativiFiscali, ComunicazioneFattureCorrispettivi.Validators.IdentificativiFiscaliItaliaValidator>
    {

        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IdFiscaleIVA, typeof(ComunicazioneFattureCorrispettivi.Validators.IdFiscaleIVAItaliaValidator));
        }
        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16);
        }

    }
}
