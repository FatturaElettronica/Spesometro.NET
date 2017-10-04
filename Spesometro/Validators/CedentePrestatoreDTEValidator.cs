using Spesometro.Common;
using FluentValidation;

namespace Spesometro.Validators
{
    public class CedentePrestatoreDTEValidator : AbstractValidator<CedenteCessionario<FattureEmesse.CedentePrestatore>>
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
