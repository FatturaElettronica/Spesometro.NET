using ComunicazioneFattureEmesseRicevute.FattureRicevute;
using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class CedentePrestatoreDTRValidator : AbstractValidator<CedentePrestatore>
    {
        public CedentePrestatoreDTRValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliCedentePrestatoreDTRValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiValidator());
            RuleFor(x => x.DatiFatturaBody)
                .SetCollectionValidator(new DatiFatturaBodyDTRValidator())
                .NotEmpty();
            RuleFor(x => x.DatiFatturaBody)
                .Must(items => items.Count >= 1 && items.Count <= 1000);
        }
    }
}
