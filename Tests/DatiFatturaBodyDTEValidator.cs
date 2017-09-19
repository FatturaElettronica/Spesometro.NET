using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiFatturaBodyDTEValidator : BaseClass<DatiFatturaBody, ComunicazioneFattureEmesseRicevute.Validators.DatiFatturaBodyDTEValidator>
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
