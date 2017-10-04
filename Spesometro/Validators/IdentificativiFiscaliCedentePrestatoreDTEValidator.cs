using Spesometro.Common;
using FluentValidation;

namespace Spesometro.Validators
{
    public class IdentificativiFiscaliCedentePrestatoreDTEValidator : IdentificativiFiscaliValidator
    {
        public IdentificativiFiscaliCedentePrestatoreDTEValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAItaliaValidator());
        }
    }
}
