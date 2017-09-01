namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class AltriDatiIdentificativiItaliaValidator : DenominazioneNomeCognomeValidator<Common.AltriDatiIdentificativi>
    {
        public AltriDatiIdentificativiItaliaValidator()
        {
            RuleFor(x => x.Sede)
                .SetValidator(new LocalitàValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new LocalitàValidator());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleItaliaValidator());
        }
    }
}
