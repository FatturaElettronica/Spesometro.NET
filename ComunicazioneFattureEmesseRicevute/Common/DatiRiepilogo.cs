using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Common
{
    public class DatiRiepilogo : BaseClassSerializable
    {

        private readonly DatiIVA _datiIVA;
        public DatiRiepilogo()
        {
            _datiIVA = new DatiIVA();
        }
        public DatiRiepilogo(XmlReader r) : base(r) { }

        [DataProperty]
        public decimal ImponibileImporto { get; set; }
        [DataProperty]
        public DatiIVA DatiIVA => _datiIVA;
        [DataProperty]
        public string Natura { get; set; }
        [DataProperty]
        public decimal? Detraibile { get; set; }
        [DataProperty]
        public string Deducibile { get; set; }
        [DataProperty]
        public string EsigibilitaIVA { get; set; }

    }
}
