namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class RappresentanteFiscaleItaliaValidator : DenominazioneNomeCognomeValidator<Common.RappresentanteFiscale>
    {
        public RappresentanteFiscaleItaliaValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAItaliaValidator());
        }
    }
}
