using FluentValidation;

namespace Spesometro.Validators
{
    public class AltriDatiIdentificativiValidator : DenominazioneNomeCognomeValidator<Common.AltriDatiIdentificativi>
    {
        public AltriDatiIdentificativiValidator()
        {
            RuleFor(x => x.Sede)
                .SetValidator(new LocalitàValidator());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new LocalitàValidator())
                .When(x=>!x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleValidator())
                .When(x=>!x.RappresentanteFiscale.IsEmpty());
        }
    }
}
