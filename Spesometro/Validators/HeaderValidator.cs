using FluentValidation;
using Spesometro;

namespace Spesometro.Validators
{
    public class HeaderValidator : AbstractValidator<Header.Header>
    {
        public HeaderValidator()
        {
            RuleFor(x => x.ProgressivoInvio)
                .Length(1, 10)
                .When(x=>!string.IsNullOrEmpty(x.ProgressivoInvio));
            RuleFor(x => x.Dichiarante)
                .SetValidator(new DichiaranteValidator())
                .When(x=>!x.Dichiarante.IsEmpty());
        }
    }
}
