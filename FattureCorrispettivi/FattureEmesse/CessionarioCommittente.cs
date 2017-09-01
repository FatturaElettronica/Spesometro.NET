using System.Collections.Generic;
using System.Xml.Serialization;
using ComunicazioneFattureCorrispettivi.Common;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.FattureEmesse
{
    public class CessionarioCommittente : CedenteCessionario
    {
        private readonly List<DatiFatturaBody> _datiFatturaBody;

        public CessionarioCommittente() : base()
        {
            _datiFatturaBody = new List<DatiFatturaBody>();
        }

        [DataProperty]
        [XmlElement(ElementName = "DatiFatturaBodyDTE")]
        public List<DatiFatturaBody> DatiFatturaBody => _datiFatturaBody;
    }
}
