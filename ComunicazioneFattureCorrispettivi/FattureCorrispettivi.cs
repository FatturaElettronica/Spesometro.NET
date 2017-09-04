using System.Xml.Serialization;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi
{
    public class FattureCorrispettivi : BaseClassSerializable
    {
        private readonly Header.Header _header;
        private readonly FattureEmesse.FattureEmesse _fattureEmesse;
        private readonly FattureRicevute.FattureRicevute _fattureRicevute;
        private readonly Annullamento.Annullamento _annullamento;
        public FattureCorrispettivi()
        {
            _header = new Header.Header();
            _fattureEmesse = new FattureEmesse.FattureEmesse();
            _fattureRicevute = new FattureRicevute.FattureRicevute();
            _annullamento = new Annullamento.Annullamento();
        }
        [DataProperty]
        [XmlElement(ElementName = "DatiFatturaHeader")]
        public Header.Header Header => _header;
        
        [DataProperty]
        [XmlElement(ElementName = "DTE")]
        public FattureEmesse.FattureEmesse FattureEmesse => _fattureEmesse;

        [DataProperty]
        [XmlElement(ElementName = "DTR")]
        public FattureRicevute.FattureRicevute FattureRicevute => _fattureRicevute;

        [DataProperty]
        [XmlElement(ElementName = "ANN")]
        public Annullamento.Annullamento Annullamento => _annullamento;
    }
}
