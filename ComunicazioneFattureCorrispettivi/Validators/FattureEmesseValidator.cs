using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class FattureEmesseValidator : AbstractValidator<FattureEmesse.FattureEmesse>
    {
        public FattureEmesseValidator()
        {
            RuleFor(x => x.CedentePrestatore)
                .SetValidator(new CedentePrestatoreDTEValidator());
            RuleFor(x => x.CessionarioCommittente)
                .SetCollectionValidator(new CessionarioCommittenteDTEValidator())
                .NotEmpty();
            RuleFor(x => x.CessionarioCommittente)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
        }
    }
}
