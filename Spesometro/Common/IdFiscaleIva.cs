using System.Xml;
using Spesometro.Validators;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.Common
{
    public class IdFiscaleIVA : BaseClassValidatable<IdFiscaleIVA>
    {

        public IdFiscaleIVA() : base()
        {
            Validator = new IdFiscaleIVAValidator();
        }

        public IdFiscaleIVA(XmlReader r) : base(r) { }

        [DataProperty]
        public string IdPaese { get; set; }

        [DataProperty]
        public string IdCodice { get; set; }
    }
}
