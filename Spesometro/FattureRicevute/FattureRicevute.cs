using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Spesometro.Common;
using FatturaElettronica.Core;

namespace Spesometro.FattureRicevute
{
    public class FattureRicevute : BaseClassSerializable
    {
        private readonly CessionarioCommittente _cessionarioCommittente;
        private readonly List<CedentePrestatore> _cedentePrestatore;
        private readonly Rettifica _rettifica;

        public FattureRicevute()
        {
            _cedentePrestatore = new List<CedentePrestatore>();
            _cessionarioCommittente = new CessionarioCommittente();
            _rettifica = new Rettifica();
        }
        public FattureRicevute(XmlReader r) : base(r) { }

        [DataProperty]
        [XmlElement(ElementName = "CessionarioCommittenteDTR")]
        public CessionarioCommittente CessionarioCommittente => _cessionarioCommittente;
        [DataProperty]
        [XmlElement(ElementName = "CedentePrestatoreDTR")]
        public List<CedentePrestatore> CedentePrestatore => _cedentePrestatore;
        [DataProperty]
        public Rettifica Rettifica => _rettifica;
    }
}