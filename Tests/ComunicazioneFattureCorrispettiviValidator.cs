using System.Linq;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ComunicazioneFattureCorrispettiviValidator  :
        BaseClass<Spesometro.Spesometro, Spesometro.Validators.SpesometroValidator>
    {
        [TestMethod]
        public void HeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.Header, typeof(Spesometro.Validators.HeaderValidator));
        }
        [TestMethod]
        public void FattureEmesseHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.FattureEmesse, typeof(Spesometro.Validators.FattureEmesseValidator));
        }
        [TestMethod]
        public void FattureRicevuteHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.FattureRicevute, typeof(Spesometro.Validators.FattureRicevuteValidator));
        }
        [TestMethod]
        public void AnnullamentoHasChildValidator()
        {
            validator.ShouldHaveDelegateChildValidator(
                x => x.Annullamento, typeof(Spesometro.Validators.RettificaValidator));
        }
        [TestMethod]
        public void FattureEmesseEmptyWhenRicevuteOrAnnullamentoAreNotEmpty()
        {
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.Annullamento.Posizione = 1;
            var r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = null;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = null;
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.Annullamento.Posizione = 0;
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = null;
            challenge.Annullamento.Posizione = 0;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = null;
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = "cognome";
            challenge.Annullamento.Posizione = 0;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));

            challenge.FattureEmesse.CedentePrestatore.AltriDatiIdentificativi.Cognome = null;
            challenge.FattureRicevute.CessionarioCommittente.AltriDatiIdentificativi.Cognome = null;
            challenge.Annullamento.Posizione = 1;
            r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureRicevute" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "FattureEmesse" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "Annullamento" && x.ErrorMessage.Contains("dovrebbe essere vuoto")));
        }
    }
}
