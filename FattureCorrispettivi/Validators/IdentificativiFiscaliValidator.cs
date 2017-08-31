using FluentValidation;
using ComunicazioneFattureCorrispettivi;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class IdentificativiFiscaliValidator : AbstractValidator<Common.IdentificativiFiscali>
    {
        public IdentificativiFiscaliValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator());
            RuleFor(x => x.CodiceFiscale)
                .Length(11, 16);
        }
    }
}
