using System.Collections.Generic;
using System.Linq;
using ComunicazioneFattureCorrispettivi.FattureEmesse;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FattureEmesseValidator : BaseClass<FattureEmesse, ComunicazioneFattureCorrispettivi.Validators.FattureEmesseValidator>
    {

        [TestMethod]
        public void CedentePrestatoreHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CedentePrestatore, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.CedentePrestatoreDTEValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteHasChildValidator()
        {
            validator.ShouldHaveChildValidator(
                x => x.CessionarioCommittente, 
                typeof(ComunicazioneFattureCorrispettivi.Validators.CessionarioCommittenteDTEValidator));
        }
        [TestMethod]
        public void CessionarioCommittenteCollectionCannotBeEmpty()
        {
            AssertCollectionCannotBeEmpty(x => x.CessionarioCommittente);
        }
        [TestMethod]
        public void CessionarioCommittenteCollectionMinMaxItems()
        {
            const int max = 1000;
            var obj = new CessionarioCommittente();
            challenge.CessionarioCommittente.AddRange(Enumerable.Repeat(obj, max));

            var r = validator.Validate(challenge);
            Assert.IsNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CessionarioCommittente"));

            challenge.CessionarioCommittente.Add(new CessionarioCommittente());
            r = validator.Validate(challenge);
            Assert.IsNotNull(r.Errors.FirstOrDefault(x => x.PropertyName == "CessionarioCommittente"));
        }
    }
}
