using ComunicazioneFattureCorrispettivi.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AltriDatiIdentificativiValidator : 
        DenominazioneNomeCognomeValidator<AltriDatiIdentificativi, ComunicazioneFattureCorrispettivi.Validators.AltriDatiIdentificativiItaliaValidator>
    {

        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Sede, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.LocalitàValidator));
        }
        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.StabileOrganizzazione, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.LocalitàValidator));
        }
        [TestMethod]
        public void RappresentanteFiscaleHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.RappresentanteFiscale, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.RappresentanteFiscaleItaliaValidator));
        }
    }
}
