using Spesometro.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RappresentanteFiscaleValidator : 
        DenominazioneNomeCognomeValidator<RappresentanteFiscale, Spesometro.Validators.RappresentanteFiscaleItaliaValidator>
    {

        [TestMethod]
        public void IdFiscaleIVAHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.IdFiscaleIVA, 
                typeof(Spesometro.Validators.IdFiscaleIVAItaliaValidator));
        }
    }
}
