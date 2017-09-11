using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AltriDatiIdentificativiValidator : 
        DenominazioneNomeCognomeValidator<AltriDatiIdentificativi, 
            ComunicazioneFattureEmesseRicevute.Validators.AltriDatiIdentificativiItaliaValidator>
    {

        [TestMethod]
        public void SedeHasChildValidator()
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.Sede.Indirizzo, challenge);

            challenge.Sede.CAP = "cap";
            validator.ShouldHaveValidationErrorFor(x => x.Sede.Indirizzo, challenge);
        }
        [TestMethod]
        public void StabileOrganizzazioneHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.StabileOrganizzazione, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.LocalitàValidator));
        }
        [TestMethod]
        public void RappresentanteFiscaleHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.RappresentanteFiscale, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.RappresentanteFiscaleItaliaValidator));
        }
    }
}
