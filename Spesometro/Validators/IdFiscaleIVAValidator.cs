using Spesometro.Common;
using Spesometro.Tabelle;
using FluentValidation;

namespace Spesometro.Validators
{
    public class IdFiscaleIVAValidator : AbstractValidator<IdFiscaleIVA>
    {
        public IdFiscaleIVAValidator()
        {
            RuleFor(id => id.IdPaese)
                .NotEmpty()
                .SetValidator(new IsValidValidator<IdPaese>());
            RuleFor(id => id.IdCodice)
                .NotEmpty()
                .Length(1, 28);
        }
    }
}
