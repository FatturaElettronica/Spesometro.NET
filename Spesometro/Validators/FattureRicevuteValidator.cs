using FluentValidation;

namespace Spesometro.Validators
{
    public class FattureRicevuteValidator : AbstractValidator<FattureRicevute.FattureRicevute>
    {
        public FattureRicevuteValidator()
        {
            RuleFor(x => x.CessionarioCommittente)
                .SetValidator(new CessionarioCommittenteDTRValidator())
                .NotEmpty();
            RuleFor(x => x.CedentePrestatore)
                .SetCollectionValidator(new CedentePrestatoreDTRValidator())
                .NotEmpty();
            RuleFor(x => x.CedentePrestatore)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
            RuleFor(x => x.Rettifica)
                .Must((fattureRicevute, _) => fattureRicevute.CedentePrestatore.Count == 1 && fattureRicevute.CedentePrestatore[0].DatiFatturaBody.Count == 1)
                .WithErrorCode("00447")
                .WithMessage("Non ammesso piu di un documento in caso di rettifica")
                .When(x => !x.Rettifica.IsEmpty());
        }
    }
}