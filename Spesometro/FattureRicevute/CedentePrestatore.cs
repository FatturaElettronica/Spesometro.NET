using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Spesometro.Common;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.FattureRicevute
{
    public class CedentePrestatore : CedenteCessionario<CedentePrestatore>
    {
        private readonly List<DatiFatturaBody> _datiFatturaBody;
        public CedentePrestatore() : base()
        {
            _datiFatturaBody = new List<DatiFatturaBody>();
        }
        public CedentePrestatore(XmlReader r) : base(r) { }

        [DataProperty]
        [XmlElement(ElementName = "DatiFatturaBodyDTR")]
        public List<DatiFatturaBody> DatiFatturaBody => _datiFatturaBody;
    }
}
