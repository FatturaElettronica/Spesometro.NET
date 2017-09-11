using FluentValidation;
using ComunicazioneFattureEmesseRicevute;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class IdentificativiFiscaliValidator : AbstractValidator<Common.IdentificativiFiscali>
    {
        public IdentificativiFiscaliValidator()
        {
            RuleFor(x => x.CodiceFiscale)
                .Length(11, 16);
        }
    }
}
