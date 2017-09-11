using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class CedentePrestatoreDTRValidator : AbstractValidator<CedenteCessionarioDatiFatturaBody>
    {
        public CedentePrestatoreDTRValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliCedentePrestatoreDTRValidator());
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
