using Spesometro.Header;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DichiaranteValidator  :
        BaseClass<Dichiarante, Spesometro.Validators.DichiaranteValidator>
    {
        [TestMethod]
        public void CodiceFiscaleIsRequired()
        {
            AssertRequired(x => x.CodiceFiscale);
        }
        [TestMethod]
        public void CodiceFiscaleMinMaxLength()
        {
            AssertMinMaxLength(x => x.CodiceFiscale, 11, 16);
        }
        [TestMethod]
        public void CaricaMinMaxValue()
        {
            var dichiarante = new Dichiarante { Carica = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.Carica, dichiarante);
            dichiarante.Carica = 16;
            validator.ShouldHaveValidationErrorFor(x => x.Carica, dichiarante);
            dichiarante.Carica = 1;
            validator.ShouldNotHaveValidationErrorFor(x => x.Carica, dichiarante);
        }
    }
}
