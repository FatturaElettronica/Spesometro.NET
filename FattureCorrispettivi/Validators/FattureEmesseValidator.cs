using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class FattureEmesseValidator : AbstractValidator<FattureEmesse.FattureEmesse>
    {
        public FattureEmesseValidator()
        {
            RuleFor(x => x.CedentePrestatore)
                .SetValidator(new CedentePrestatoreDTEValidator());
        }
    }
}
