using ComunicazioneFattureCorrispettivi.Common;
using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class CedenteCessionarioValidator : AbstractValidator<CedenteCessionario>
    {
        public CedenteCessionarioValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliItaliaValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiItaliaValidator());
        }
    }
}
