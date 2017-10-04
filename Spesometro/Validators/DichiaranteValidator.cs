using FluentValidation;
using Spesometro;

namespace Spesometro.Validators
{
    public class DichiaranteValidator : AbstractValidator<Header.Dichiarante>
    {
        public DichiaranteValidator()
        {
            RuleFor(x => x.CodiceFiscale)
                .NotEmpty()
                .Length(11, 16);
            RuleFor(x => x.Carica)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(15);
        }
    }
}
