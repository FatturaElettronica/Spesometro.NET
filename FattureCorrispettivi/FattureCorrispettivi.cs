using System.Xml.Serialization;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi
{
    public class FattureCorrispettivi : BaseClassSerializable
    {
        private readonly Header.Header _header;
        public FattureCorrispettivi()
        {
            _header = new Header.Header();
        }
        [DataProperty]
        [XmlElement(ElementName = "DatiFatturaHeader")]
        public Header.Header Header => _header;
    }
}
