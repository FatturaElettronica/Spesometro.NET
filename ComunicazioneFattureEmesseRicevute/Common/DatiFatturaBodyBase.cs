using System.Collections.Generic;
using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Common
{
    public abstract class DatiFatturaBodyBase : BaseClassSerializable
    {
        private readonly List<DatiRiepilogo> _datiRiepilogo;

        public DatiFatturaBodyBase()
        {
            _datiRiepilogo = new List<DatiRiepilogo>();
        }
        public DatiFatturaBodyBase(XmlReader r) : base(r) { }

        [DataProperty]
        public List<DatiRiepilogo> DatiRiepilogo => _datiRiepilogo;
    }
}
