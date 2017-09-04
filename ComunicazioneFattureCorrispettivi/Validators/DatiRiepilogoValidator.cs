using FluentValidation;
using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.Tabelle;

namespace ComunicazioneFattureCorrispettivi.Validators
{
    public class DatiRiepilogoValidator : AbstractValidator<DatiRiepilogo>
    {
        public DatiRiepilogoValidator()
        {
            RuleFor(x => x.Natura)
                .SetValidator(new IsValidValidator<Natura>());
            RuleFor(x => x.Natura)
                .NotNull()
                .When(x => x.DatiIVA.Aliquota == 0)
                .WithErrorCode("00400")
                .WithMessage("<Natura> non presente a fronte di <Aliquota>  pari a zero");
            RuleFor(x => x.Natura)
                .Must(x=>x != "N6")
                .When(x => x.DatiIVA.Aliquota == 0)
                .WithErrorCode("00400")
                .WithMessage("<Natura> uguale a N6 a fronte di <Aliquota>  pari a zero");
            RuleFor(x => x.Natura)
                .Must(x=>x != "N6")
                .When(x => x.EsigibilitaIVA == "S")
                .WithErrorCode("00420")
                .WithMessage("<Natura> con valore N6 (inversione contabile) a fronte di <EsigibilitaIVA> uguale a S (scissione pagamenti)");

            RuleFor(x => x.Detraibile)
                .Equal(0)
                .When(x => x.Deducibile == "SI")
                .WithErrorCode("00435")
                .WithMessage("<Detraibile> e <Deducibile> non possono essere presenti contemporaneamente con riferimento allo stesso importo");

            RuleFor(x => x.Deducibile)
                .Equal("SI");
            RuleFor(x => x.Deducibile)
                .Empty()
                .When(x => x.Detraibile > 0)
                .WithErrorCode("00435")
                .WithMessage("<Detraibile> e <Deducibile> non possono essere presenti contemporaneamente con riferimento allo stesso importo");

            RuleFor(x => x.EsigibilitaIVA)
                .SetValidator(new IsValidValidator<EsigibilitaIVA>());

            RuleFor(x => x.DatiIVA.Imposta)
                .Must((riepilogo, _) => riepilogo.DatiIVA.Aliquota * riepilogo.ImponibileImporto == 0)
                .When(riepilogo => riepilogo.DatiIVA.Imposta == 0)
                .WithErrorCode("00434")
                .WithMessage("<Imposta> e <Aliquota> non coerenti");
            RuleFor(x => x.DatiIVA.Aliquota)
                .Must((riepilogo, _) => riepilogo.DatiIVA.Imposta * riepilogo.ImponibileImporto == 0)
                .When(riepilogo => riepilogo.DatiIVA.Aliquota == 0)
                .WithErrorCode("00434")
                .WithMessage("<Imposta> e <Aliquota> non coerenti");

            RuleFor(x => x.DatiIVA.Imposta)
                .Must((riepilogo, _) => riepilogo.DatiIVA.Aliquota == 0)
                .When(x => x.DatiIVA.Imposta == 0)
                .WithErrorCode("00434")
                .WithMessage("<Imposta> e <Aliquota> non coerenti");
            RuleFor(x => x.DatiIVA.Aliquota)
                .Must((riepilogo, _) => riepilogo.DatiIVA.Imposta == 0)
                .When(x => x.DatiIVA.Aliquota == 0)
                .WithErrorCode("00434")
                .WithMessage("<Imposta> e <Aliquota> non coerenti");
        }
    }
}
