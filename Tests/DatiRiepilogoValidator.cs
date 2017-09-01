using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.Tabelle;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiRiepilogoValidator  :
        BaseClass<DatiRiepilogo, ComunicazioneFattureCorrispettivi.Validators.DatiRiepilogoValidator>
    {
        [TestMethod]
        public void NaturaOnlyAcceptsTableValues()
        {
            challenge.DatiIVA.Aliquota = 1;
            AssertOnlyAcceptsTableValues<Natura>(x => x.Natura);
        }
        [TestMethod]
        public void NaturaIsRequiredWhenAliquotaIsZero()
        {
            challenge.DatiIVA.Aliquota = 0;
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00400");
            challenge.Natura = "N1";
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void NaturaCannotBeN6WhenEsibilitaIVAIsS()
        {
            challenge.EsigibilitaIVA = "S";
            challenge.DatiIVA.Aliquota = 1;
            challenge.Natura = "N6";
            validator.ShouldHaveValidationErrorFor(x => x.Natura, challenge).WithErrorCode("00420");
            challenge.EsigibilitaIVA = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Natura, challenge);
        }
        [TestMethod]
        public void DetraibileMustBeZeroWhenDeducibileIsSI()
        {
            challenge.Deducibile = "SI";
            challenge.Detraibile = 1;
            validator.ShouldHaveValidationErrorFor(x => x.Detraibile, challenge).WithErrorCode("00435");
            challenge.Detraibile = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.Detraibile, challenge);
        }
        [TestMethod]
        public void DeducibileOnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsSIValue(x => x.Deducibile);
        }
        [TestMethod]
        public void DeducibileMustBeEmptyWhenDetraibileGreaterThanZero()
        {
            challenge.Detraibile = 1;
            challenge.Deducibile = "SI";
            validator.ShouldHaveValidationErrorFor(x => x.Deducibile, challenge).WithErrorCode("00435");
            challenge.Detraibile = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.Deducibile, challenge);
        }
        [TestMethod]
        public void EsigibilitaIVAOnlyAcceptsTableValues()
        {
            AssertOnlyAcceptsTableValues<EsigibilitaIVA>(x => x.EsigibilitaIVA);
        }
        [TestMethod]
        public void ProductOfAliquotaAndImponibileMustBeZeroWhenImpostaIsZero()
        {
            challenge.DatiIVA.Imposta = 0;
            challenge.DatiIVA.Aliquota = 0.1m;
            challenge.ImponibileImporto = 100;
            validator.ShouldHaveValidationErrorFor(x => x.DatiIVA.Imposta, challenge).WithErrorCode("00434");
            challenge.DatiIVA.Imposta = 1;
            challenge.DatiIVA.Aliquota = 0;
            validator.ShouldHaveValidationErrorFor(x => x.DatiIVA.Aliquota, challenge).WithErrorCode("00434");
            challenge.DatiIVA.Imposta = 0;
            challenge.DatiIVA.Aliquota = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.DatiIVA.Imposta, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.DatiIVA.Aliquota, challenge);
        }
        [TestMethod]
        public void AliquotaMustBeZeroWhenImpostaIsZero()
        {
            challenge.DatiIVA.Aliquota = 0.1m;
            challenge.DatiIVA.Imposta = 0;
            validator.ShouldHaveValidationErrorFor(x => x.DatiIVA.Imposta, challenge).WithErrorCode("00434");
            challenge.DatiIVA.Aliquota = 0;
            challenge.DatiIVA.Imposta = 1;
            validator.ShouldHaveValidationErrorFor(x => x.DatiIVA.Aliquota, challenge).WithErrorCode("00434");
            challenge.DatiIVA.Imposta = 0;
            challenge.DatiIVA.Aliquota = 0;
            validator.ShouldNotHaveValidationErrorFor(x => x.DatiIVA.Imposta, challenge);
            validator.ShouldNotHaveValidationErrorFor(x => x.DatiIVA.Aliquota, challenge);
        }
    }
}
