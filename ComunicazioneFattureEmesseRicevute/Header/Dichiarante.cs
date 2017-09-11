using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Header
{
    public class Dichiarante : BaseClassSerializable
    {
        public Dichiarante() { }
        public Dichiarante(XmlReader r) : base(r) { }

        [DataProperty]
        public string CodiceFiscale { get; set; }
        [DataProperty]
        public int Carica { get; set; } 
    }
}
