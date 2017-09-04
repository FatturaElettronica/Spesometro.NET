using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class FattureRicevuteValidator : AbstractValidator<FattureRicevute.FattureRicevute>
    {
        public FattureRicevuteValidator()
        {
            RuleFor(x => x.CessionarioCommittente)
                .SetValidator(new CedenteCessionarioValidator())
                .NotEmpty();
            RuleFor(x => x.CedentePrestatore)
                .SetCollectionValidator(new CedenteCessionarioDatiFatturaBodyValidator())
                .NotEmpty();
            RuleFor(x => x.CedentePrestatore)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
            RuleFor(x => x.Rettifica.IdFile)
                .Must((fattureEmesse, _) => fattureEmesse.CedentePrestatore.Count == 1 && fattureEmesse.CedentePrestatore[0].DatiFatturaBody.Count == 1)
                .When(x => !x.IsEmpty())
                .WithErrorCode("00447")
                .WithMessage("Non ammesso piu di un documento in caso di rettifica");
        }
    }
}
