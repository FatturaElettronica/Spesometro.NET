using ComunicazioneFattureEmesseRicevute.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiFatturaBodyValidator : BaseClass<DatiFatturaBody, ComunicazioneFattureEmesseRicevute.Validators.DatiFatturaBodyValidator>
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
