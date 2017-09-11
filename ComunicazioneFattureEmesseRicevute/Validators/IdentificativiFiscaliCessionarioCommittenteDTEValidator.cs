using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class IdentificativiFiscaliCessionarioCommittenteDTEValidator : IdentificativiFiscaliValidator
    {
        public IdentificativiFiscaliCessionarioCommittenteDTEValidator()
        {
            RuleFor(x => x.IdFiscaleIVA)
                .SetValidator(new IdFiscaleIVAValidator())
                .When(x=>!x.IdFiscaleIVA.IsEmpty());
        }
    }
}
