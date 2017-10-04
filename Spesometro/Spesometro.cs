using System.Xml.Serialization;
using Spesometro.Settings;
using FatturaElettronica.Common;

namespace Spesometro
{
    public class Spesometro : BaseClassSerializable
    {
        private readonly Header.Header _header;
        private readonly FattureEmesse.FattureEmesse _fattureEmesse;
        private readonly FattureRicevute.FattureRicevute _fattureRicevute;
        private readonly Annullamento.Annullamento _annullamento;
        public Spesometro()
        {
            _header = new Header.Header();
            _fattureEmesse = new FattureEmesse.FattureEmesse();
            _fattureRicevute = new FattureRicevute.FattureRicevute();
            _annullamento = new Annullamento.Annullamento();
        }

        public override void WriteXml(System.Xml.XmlWriter w)
        {
            w.WriteStartElement(RootElement.Prefix, RootElement.LocalName, RootElement.NameSpace);
            w.WriteAttributeString("versione", Settings.Version.Current);
            foreach (var a in RootElement.ExtraAttributes)
            {
                w.WriteAttributeString(a.Prefix, a.LocalName, a.ns, a.value);
            }
            base.WriteXml(w);
            w.WriteEndElement();
        }

        public override void ReadXml(System.Xml.XmlReader r)
        {
            r.MoveToContent();
            base.ReadXml(r);
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
