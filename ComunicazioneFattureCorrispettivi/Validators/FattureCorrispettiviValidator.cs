using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class FattureCorrispettiviValidator : AbstractValidator<FattureCorrispettivi>
    {
        public FattureCorrispettiviValidator()
        {
            RuleFor(x => x.Header)
                .SetValidator(new HeaderValidator());
            RuleFor(x => x.FattureEmesse)
                .SetValidator(new FattureEmesseValidator());
        }
    }
}
