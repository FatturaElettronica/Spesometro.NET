using Spesometro.FattureRicevute;
using FluentValidation;

namespace Spesometro.Validators
{
    public class CedentePrestatoreDTRValidator : AbstractValidator<CedentePrestatore>
    {
        public CedentePrestatoreDTRValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliCedentePrestatoreDTRValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiValidator());
            RuleForEach(x => x.DatiFatturaBody)
                .SetValidator(new DatiFatturaBodyDTRValidator())
                .NotEmpty();
            RuleFor(x => x.DatiFatturaBody)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
        }
    }
}
