using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
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
            RuleFor(x => x.Rettifica)
                .Must((fattureEmesse, _) => fattureEmesse.CessionarioCommittente.Count == 1 && fattureEmesse.CessionarioCommittente[0].DatiFatturaBody.Count == 1)
                .WithErrorCode("00447")
                .WithMessage("Non ammesso piu di un documento in caso di rettifica")
                .When(x => !x.Rettifica.IsEmpty());
        }
    }
}
