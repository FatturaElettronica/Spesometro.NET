using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spesometro.Header;

namespace Tests
{
    [TestClass]
    public class HeaderValidator :
        BaseClass<Header, Spesometro.Validators.HeaderValidator>
    {
        [TestMethod]
        public void ProgressivoInvioIsOptional()
        {
            AssertOptional(x => x.ProgressivoInvio);
        }
        [TestMethod]
        public void ProgressivoInvioMinMaxLength()
        {
            AssertMinMaxLength(x => x.ProgressivoInvio, 1, 10);
        }
        //[TestMethod]
        //public void DichiaranteHasChildValidator()
        //{
        //    validator.ShouldHaveDelegateChildValidator(x => x.Dichiarante, typeof(Spesometro.Validators.DichiaranteValidator));
        //}
    }
}
