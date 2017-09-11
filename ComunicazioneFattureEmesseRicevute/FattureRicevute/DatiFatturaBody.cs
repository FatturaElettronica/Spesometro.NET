using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.FattureRicevute
{
    public class DatiFatturaBody : Common.DatiFatturaBody
    {
        private readonly DatiGenerali _datiGenerali;
        public DatiFatturaBody()
        {
            _datiGenerali = new DatiGenerali();
        }
        public DatiFatturaBody(XmlReader r) : base(r) { }

        [DataProperty]
        public new DatiGenerali DatiGenerali => _datiGenerali;
    }
}
