using FluentValidation;
using ComunicazioneFattureEmesseRicevute.Common;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class RettificaValidator : AbstractValidator<Rettifica>
    {
        public RettificaValidator()
        {
            RuleFor(x => x.IdFile)
                .NotEmpty()
                .Length(1, 18);
        }
    }
}
