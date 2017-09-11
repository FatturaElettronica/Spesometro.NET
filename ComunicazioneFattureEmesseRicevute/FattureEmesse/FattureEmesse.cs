using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using ComunicazioneFattureEmesseRicevute.Common;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.FattureEmesse
{
    public class FattureEmesse : BaseClassSerializable
    {
        private readonly CedentePrestatore _cedentePrestatore;
        private readonly List<CessionarioCommittente> _cessionarioCommittente;
        private readonly Rettifica _rettifica;

        public FattureEmesse()
        {
            _cedentePrestatore = new CedentePrestatore();
            _cessionarioCommittente = new List<CessionarioCommittente>();
            _rettifica = new Rettifica();
        }
        public FattureEmesse(XmlReader r) : base(r) { }

        [DataProperty]
        [XmlElement(ElementName = "CedentePrestatoreDTE")]
        public CedentePrestatore CedentePrestatore => _cedentePrestatore;
        [DataProperty]
        [XmlElement(ElementName = "CessionarioCommittenteDTE")]
        public List<CessionarioCommittente> CessionarioCommittente => _cessionarioCommittente;
        [DataProperty]
        public Rettifica Rettifica => _rettifica;
    }
}
