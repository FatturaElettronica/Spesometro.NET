using FluentValidation;
using Spesometro;

namespace Spesometro.Validators
{
    public class IdentificativiFiscaliValidator : AbstractValidator<Common.IdentificativiFiscali>
    {
        public IdentificativiFiscaliValidator()
        {
            RuleFor(x => x.CodiceFiscale)
                .Length(11, 16);
        }
    }
}
