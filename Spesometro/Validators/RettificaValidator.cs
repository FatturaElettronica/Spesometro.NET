using FluentValidation;
using Spesometro.Common;

namespace Spesometro.Validators
{
    public class RettificaValidator : AbstractValidator<Rettifica>
    {
        public RettificaValidator()
        {
            RuleFor(x => x.IdFile)
                .NotEmpty()
                .Length(1, 18);
        }
    }
}
