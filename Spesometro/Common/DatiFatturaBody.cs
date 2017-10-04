using System.Xml;
using Spesometro.Common;
using FatturaElettronica.Common;

namespace Spesometro.Common
{
    public class DatiFatturaBody : DatiFatturaBodyBase
    {
        private readonly DatiGenerali _datiGenerali;

        public DatiFatturaBody() : base()
        {
            _datiGenerali = new DatiGenerali();
        }
        public DatiFatturaBody(XmlReader r) : base(r) { }

        [DataProperty]
        public virtual DatiGenerali DatiGenerali => _datiGenerali;
    }
}
