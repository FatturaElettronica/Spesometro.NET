using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiFatturaBodyDTRValidator : 
        BaseClass<ComunicazioneFattureEmesseRicevute.FattureRicevute.DatiFatturaBody, ComunicazioneFattureEmesseRicevute.Validators.DatiFatturaBodyDTRValidator>
    {

        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, 
                typeof(ComunicazioneFattureEmesseRicevute.Validators.DatiGeneraliValidator));
        }
    }
}
