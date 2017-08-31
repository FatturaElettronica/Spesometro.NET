using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.Common
{
    public class IdFiscaleIVA : BaseClassSerializable
    {

        public IdFiscaleIVA() { }
        public IdFiscaleIVA(XmlReader r) : base(r) { }

        [DataProperty]
        public string IdPaese { get; set; }

        [DataProperty]
        public string IdCodice { get; set; }
    }
}
