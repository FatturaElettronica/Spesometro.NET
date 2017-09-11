using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class CessionarioCommittenteDTEValidator : AbstractValidator<CedenteCessionarioDatiFatturaBody>
    {
        public CessionarioCommittenteDTEValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliCessionarioCommittenteDTEValidator())
                .When(x=>!x.IdentificativiFiscali.IsEmpty());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiValidator())
                .When(x=>!x.AltriDatiIdentificativi.IsEmpty());
            RuleFor(x => x.DatiFatturaBody)
                .SetCollectionValidator(new DatiFatturaBodyValidator())
                .NotEmpty();
            RuleFor(x => x.DatiFatturaBody)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
        }
    }
}
