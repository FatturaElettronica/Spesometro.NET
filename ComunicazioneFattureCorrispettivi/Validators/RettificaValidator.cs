using FluentValidation;
using ComunicazioneFattureCorrispettivi.Common;

namespace ComunicazioneFattureCorrispettivi.Validators
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
