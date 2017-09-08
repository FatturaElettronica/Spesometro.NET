using FluentValidation;
using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.Tabelle;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class DatiIVAValidator : AbstractValidator<DatiIVA>
    {
        public DatiIVAValidator()
        {
            RuleFor(x => x.Imposta)
                .Must((datiIVA, _) => datiIVA.Aliquota == 0)
                .When(x => x.Imposta == 0)
                .WithErrorCode("00434")
                .WithMessage("<Imposta> o <Aliquota> non coerenti");
        }
    }
}
