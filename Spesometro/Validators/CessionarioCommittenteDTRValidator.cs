using Spesometro.Common;
using FluentValidation;

namespace Spesometro.Validators
{
    public class CessionarioCommittenteDTRValidator : AbstractValidator<CedenteCessionario<FattureRicevute.CessionarioCommittente>>
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
