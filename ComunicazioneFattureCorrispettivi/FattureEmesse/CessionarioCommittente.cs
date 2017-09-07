using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using ComunicazioneFattureCorrispettivi.Common;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.FattureEmesse
{
    public class CessionarioCommittente : CedenteCessionarioDatiFatturaBody
    {
        public CessionarioCommittente() : base() { }
        public CessionarioCommittente(XmlReader r) : base(r) { }

        [DataProperty(order:2)]
        [XmlElement(ElementName = "DatiFatturaBodyDTE")]
        public new List<DatiFatturaBody> DatiFatturaBody => base.DatiFatturaBody;
    }
}
