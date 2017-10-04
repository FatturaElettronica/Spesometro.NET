
using System;
using System.Xml;
using FatturaElettronica.Common;

namespace Spesometro.FattureRicevute

{
    public class DatiGenerali : Common.DatiGenerali {

        public DatiGenerali() : base() { }
        public DatiGenerali(XmlReader r) : base(r) { }

        [DataProperty(order:3)]
        public DateTime? DataRegistrazione { get; set; }
    }
}
