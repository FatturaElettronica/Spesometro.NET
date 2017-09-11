using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Common
{
    public class DatiIVA : BaseClassSerializable
    {

        public DatiIVA()
        {
        }
        public DatiIVA(XmlReader r) : base(r) { }

        [DataProperty]
        public decimal Imposta { get; set; }
        [DataProperty]
        public decimal Aliquota { get; set; }

    }
}
