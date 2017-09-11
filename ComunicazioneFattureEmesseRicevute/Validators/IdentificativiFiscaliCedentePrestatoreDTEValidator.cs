using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
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
