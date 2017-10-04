using Spesometro.Common;
using FluentValidation;

namespace Spesometro.Validators
{
    public class IdFiscaleIVAItaliaValidator : AbstractValidator<IdFiscaleIVA>
    {
        public IdFiscaleIVAItaliaValidator() : base()
        {
            RuleFor(id => id.IdPaese)
                .NotEmpty()
                .Equal("IT");
            RuleFor(id => id.IdCodice)
                .NotEmpty()
                .Length(1, 28);
        }
    }
}
