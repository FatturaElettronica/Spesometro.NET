using System.Xml.Serialization;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi
{
    public class FattureCorrispettivi : BaseClassSerializable
    {
        private readonly Header.Header _header;
        private readonly FattureEmesse.FattureEmesse _fattureEmesse;
        public FattureCorrispettivi()
        {
            _header = new Header.Header();
            _fattureEmesse = new FattureEmesse.FattureEmesse();
        }
        [DataProperty]
        [XmlElement(ElementName = "DatiFatturaHeader")]
        public Header.Header Header => _header;
        
        [DataProperty]
        [XmlElement(ElementName = "DTE")]
        public FattureEmesse.FattureEmesse FattureEmesse => _fattureEmesse;
    }
}
