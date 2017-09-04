namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class AltriDatiIdentificativiValidator : DenominazioneNomeCognomeValidator<Common.AltriDatiIdentificativi>
    {
        public AltriDatiIdentificativiValidator()
        {
            RuleFor(x => x.Sede)
                .SetValidator(new LocalitàValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new LocalitàValidator());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleValidator());
        }
    }
}
