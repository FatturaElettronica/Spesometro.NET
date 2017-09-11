using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Common
{
    public class CedenteCessionarioDatiFatturaBody : CedenteCessionario
    {
        private readonly List<DatiFatturaBody> _datiFatturaBody;
        public CedenteCessionarioDatiFatturaBody() : base ()
        {
            _datiFatturaBody = new List<DatiFatturaBody>();
        }
        public CedenteCessionarioDatiFatturaBody(XmlReader r) : base(r) { }

        [DataProperty]
        public List<DatiFatturaBody> DatiFatturaBody => _datiFatturaBody;
    }
}
