using ComunicazioneFattureEmesseRicevute.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RettificaValidator  :
        BaseClass<Rettifica, ComunicazioneFattureEmesseRicevute.Validators.RettificaValidator>
    {
        [TestMethod]
        public void IdFileIsRequired()
        {
            AssertRequired(x => x.IdFile);
        }
        [TestMethod]
        public void IdFileMinMaxLength()
        {
            AssertMinMaxLength(x => x.IdFile, 1, 18);
        }
    }
}
