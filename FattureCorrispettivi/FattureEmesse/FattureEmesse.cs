using System.Xml;
using System.Xml.Serialization;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.FattureEmesse
{
    public class FattureEmesse : BaseClassSerializable
    {
        private readonly CedentePrestatore _cedentePrestatore;
        public FattureEmesse()
        {
            _cedentePrestatore = new CedentePrestatore();
        }
        public FattureEmesse(XmlReader r) : base(r) { }

        [DataProperty]
        [XmlElement(ElementName = "CedentePrestatoreDTE")]
        public CedentePrestatore CedentePrestatore => _cedentePrestatore;
    }
}
