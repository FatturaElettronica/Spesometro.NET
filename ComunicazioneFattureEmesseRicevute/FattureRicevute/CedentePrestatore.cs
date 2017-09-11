using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using ComunicazioneFattureEmesseRicevute.Common;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.FattureRicevute
{
    public class CedentePrestatore : CedenteCessionarioDatiFatturaBody
    {
        public CedentePrestatore() : base() { }
        public CedentePrestatore(XmlReader r) : base(r) { }

        [DataProperty]
        [XmlElement(ElementName = "DatiFatturaBodyDTR")]
        public new List<Common.DatiFatturaBody> DatiFatturaBody => base.DatiFatturaBody;
    }
}
