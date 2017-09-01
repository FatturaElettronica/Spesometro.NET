using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiFatturaBodyValidator : BaseClass<ComunicazioneFattureCorrispettivi.FattureEmesse.DatiFatturaBody, ComunicazioneFattureCorrispettivi.Validators.DatiFatturaBodyValidator>
    {

        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.DatiGeneraliValidator));
        }
    }
}
