using ComunicazioneFattureCorrispettivi.Common;
using FluentValidation;

namespace ComunicazioneFattureCorrispettivi.Validators
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
