using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.Common
{
    public class DatiFatturaBody : BaseClassSerializable
    {
        private readonly DatiGenerali _datiGenerali;
        private readonly List<DatiRiepilogo> _datiRiepilogo;

        public DatiFatturaBody()
        {
            _datiGenerali = new DatiGenerali();
            _datiRiepilogo = new List<DatiRiepilogo>();
        }
        public DatiFatturaBody(XmlReader r) : base(r) { }

        [DataProperty]
        public DatiGenerali DatiGenerali => _datiGenerali;
        [DataProperty]
        public List<DatiRiepilogo> DatiRiepilogo => _datiRiepilogo;
    }
}
