using ComunicazioneFattureCorrispettivi.Common;
using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class CedenteCessionarioDatiFatturaBodyValidator : AbstractValidator<CedenteCessionarioDatiFatturaBody>
    {
        public CedenteCessionarioDatiFatturaBodyValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiValidator());
            RuleFor(x => x.DatiFatturaBody)
                .SetCollectionValidator(new DatiFatturaBodyValidator())
                .NotEmpty();
            RuleFor(x => x.DatiFatturaBody)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
        }
    }
}
