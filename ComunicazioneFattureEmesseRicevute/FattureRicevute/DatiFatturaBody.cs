using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.FattureRicevute
{
    public class DatiFatturaBody : Common.DatiFatturaBodyBase
    {
        private readonly DatiGenerali _datiGenerali;
        public DatiFatturaBody() : base()
        {
            _datiGenerali = new DatiGenerali();
        }
        public DatiFatturaBody(XmlReader r) : base(r) { }

        [DataProperty]
        public DatiGenerali DatiGenerali => _datiGenerali;
    }
}
