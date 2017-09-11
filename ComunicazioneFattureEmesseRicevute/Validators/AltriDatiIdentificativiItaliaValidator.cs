using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class AltriDatiIdentificativiItaliaValidator : DenominazioneNomeCognomeValidator<Common.AltriDatiIdentificativi>
    {
        public AltriDatiIdentificativiItaliaValidator()
        {
            RuleFor(x => x.Sede)
                .SetValidator(new LocalitàValidator())
                .When(x=>!x.Sede.IsEmpty());
            RuleFor(x => x.StabileOrganizzazione)
                .SetValidator(new LocalitàValidator())
                .When(x=>!x.StabileOrganizzazione.IsEmpty());
            RuleFor(x => x.RappresentanteFiscale)
                .SetValidator(new RappresentanteFiscaleItaliaValidator())
                .When(x=>!x.RappresentanteFiscale.IsEmpty());
        }
    }
}
