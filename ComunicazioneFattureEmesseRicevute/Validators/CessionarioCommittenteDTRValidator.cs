using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation;

namespace ComunicazioneFattureEmesseRicevute.Validators
{
    public class CessionarioCommittenteDTRValidator : AbstractValidator<CedenteCessionario>
    {
        public CessionarioCommittenteDTRValidator()
        {
            RuleFor(x => x.IdentificativiFiscali)
                .SetValidator(new IdentificativiFiscaliCessionarioCommitenteDTRValidator());
            RuleFor(x => x.AltriDatiIdentificativi)
                .SetValidator(new AltriDatiIdentificativiItaliaValidator())
                .When(x=>!x.AltriDatiIdentificativi.IsEmpty());
        }
    }
}
