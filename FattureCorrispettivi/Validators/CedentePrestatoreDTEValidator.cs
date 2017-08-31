using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class CedentePrestatoreDTEValidator : AbstractValidator<FattureEmesse.CedentePrestatore>
    {
        public CedentePrestatoreDTEValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliItaliaValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiItaliaValidator());
        }
    }
}
