using ComunicazioneFattureCorrispettivi.Common;
using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class CedentePrestatoreDTEValidator : AbstractValidator<CedenteCessionario>
    {
        public CedentePrestatoreDTEValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliCedentePrestatoreDTEValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiItaliaValidator());
        }
    }
}
