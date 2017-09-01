using ComunicazioneFattureCorrispettivi.Common;
using ComunicazioneFattureCorrispettivi.Header;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiGeneraliValidator  :
        BaseClass<DatiGenerali, ComunicazioneFattureCorrispettivi.Validators.DatiGeneraliValidator>
    {
        [TestMethod]
        public void NumeroIsRequired()
        {
            AssertRequired(x => x.Numero);
        }
        [TestMethod]
        public void NumeroMinMaxLength()
        {
            AssertMinMaxLength(x => x.Numero, 1, 20);
        }
    }
}
