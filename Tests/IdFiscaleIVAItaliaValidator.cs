using Spesometro.Common;
using Spesometro.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class IdFiscaleIVAItaliaValidator : BaseClass<IdFiscaleIVA, Spesometro.Validators.IdFiscaleIVAItaliaValidator>
    {

        [TestMethod]
        public void TestIDataError()
        {
            //challenge.AttachValidator(new Spesometro.Validators.IdFiscaleIVAItaliaValidator());
            var a = challenge["IdPaese"];
        }
        [TestMethod]
        public void IdPaeseIsRequired()
        {
            AssertRequired(x => x.IdPaese);
        }
        [TestMethod]
        public void IdPaeseOnlyAcceptsSIValue()
        {
            AssertOnlyAcceptsITValue(x => x.IdPaese);
        }
        [TestMethod]
        public void IdCodiceIsRequired()
        {
            AssertRequired(x => x.IdCodice);
        }
        [TestMethod]
        public void IdCodiceMinMaxLength()
        {
            AssertMinMaxLength(x => x.IdCodice, 1, 28);
        }
    }
}
