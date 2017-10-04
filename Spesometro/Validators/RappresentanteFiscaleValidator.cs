namespace Spesometro.Validators
{
    public class RappresentanteFiscaleValidator : DenominazioneNomeCognomeValidator<Common.RappresentanteFiscale>
    {
        public RappresentanteFiscaleValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
        }
    }
}
