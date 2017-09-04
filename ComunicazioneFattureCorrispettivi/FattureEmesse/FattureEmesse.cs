using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.FattureEmesse
{
    public class FattureEmesse : BaseClassSerializable
    {
        private readonly CedentePrestatore _cedentePrestatore;
        private readonly List<CessionarioCommittente> _cessionarioCommittente;

        public FattureEmesse()
        {
            _cedentePrestatore = new CedentePrestatore();
            _cessionarioCommittente = new List<CessionarioCommittente>();
        }
        public FattureEmesse(XmlReader r) : base(r) { }

        [DataProperty]
        [XmlElement(ElementName = "CedentePrestatoreDTE")]
        public CedentePrestatore CedentePrestatore => _cedentePrestatore;
        [DataProperty]
        [XmlElement(ElementName = "CessionarioCommittenteDTE")]
        public List<CessionarioCommittente> CessionarioCommittente => _cessionarioCommittente;
    }
}
