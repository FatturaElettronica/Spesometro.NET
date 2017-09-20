using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using ComunicazioneFattureEmesseRicevute.Common;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.FattureEmesse
{
    public class CessionarioCommittente : CedenteCessionario<CessionarioCommittente>
    {
        private readonly List<DatiFatturaBody> _datiFatturaBody;
        public CessionarioCommittente() : base()
        {
            _datiFatturaBody = new List<DatiFatturaBody>();
        }
        public CessionarioCommittente(XmlReader r) : base(r) { }

        [DataProperty(order: 2)]
        [XmlElement(ElementName = "DatiFatturaBodyDTE")]
        public List<DatiFatturaBody> DatiFatturaBody => _datiFatturaBody;
    }
}
