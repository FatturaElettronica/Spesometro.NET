using Spesometro.Common;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DatiFatturaBodyDTRValidator : 
        BaseClass<Spesometro.FattureRicevute.DatiFatturaBody, Spesometro.Validators.DatiFatturaBodyDTRValidator>
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
