using Spesometro.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiFatturaBodyDTEValidator : BaseClass<DatiFatturaBody, Spesometro.Validators.DatiFatturaBodyDTEValidator>
    {

        [TestMethod]
        public void DatiGeneraliHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.DatiGenerali, 
                typeof(Spesometro.Validators.DatiGeneraliValidator));
        }
    }
}
