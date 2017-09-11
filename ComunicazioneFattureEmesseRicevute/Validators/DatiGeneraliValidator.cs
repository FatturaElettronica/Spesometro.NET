using FluentValidation;
using ComunicazioneFattureEmesseRicevute.Common;
using ComunicazioneFattureEmesseRicevute.Tabelle;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class DatiGeneraliValidator : AbstractValidator<DatiGenerali>
    {
        public DatiGeneraliValidator()
        {
            RuleFor(x => x.TipoDocumento)
                .NotEmpty()
                .SetValidator(new IsValidValidator<TipoDocumento>());
            RuleFor(x => x.Numero)
                .NotEmpty()
                .Length(1, 20);
        }
    }
}
