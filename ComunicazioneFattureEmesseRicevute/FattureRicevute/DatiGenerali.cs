
using System;
using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.FattureRicevute

{
    public class DatiGenerali : Common.DatiGenerali {

        public DatiGenerali() { }
        public DatiGenerali(XmlReader r) : base(r) { }

        [DataProperty]
        public DateTime? DataRegistrazione { get; set; }
    }
}
