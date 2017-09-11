using ComunicazioneFattureEmesseRicevute.Common;
using ComunicazioneFattureEmesseRicevute.Tabelle;
using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class LocalitàValidator : AbstractValidator<Località>
    {
        public LocalitàValidator()
        {
            RuleFor(x => x.Indirizzo)
                .NotEmpty()
                .Length(1, 60)
                .Latin1SupplementValidator();
            RuleFor(x => x.NumeroCivico)
                .Length(1, 8)
                .When(x => !string.IsNullOrEmpty(x.NumeroCivico));
            RuleFor(x => x.CAP)
                .NotEmpty()
                .Length(5);
            RuleFor(x => x.Comune)
                .NotEmpty()
                .Length(1, 60)
                .Latin1SupplementValidator();
            RuleFor(x => x.Provincia)
                .SetValidator(new IsValidValidator<Provincia>())
                .When(x => !string.IsNullOrEmpty(x.Provincia));
            RuleFor(id => id.Nazione)
                .NotEmpty()
                .SetValidator(new IsValidValidator<IdPaese>());
        }
    }
}
