using System;
using ComunicazioneFattureCorrispettivi;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureCorrispettiviValidator  :
        BaseClass<FattureCorrispettivi, ComunicazioneFattureCorrispettivi.Validators.FattureCorrispettiviValidator>
    {
        [TestMethod]
        public void HeaderHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Header, typeof(ComunicazioneFattureCorrispettivi.Validators.HeaderValidator));
        }
    }
}
