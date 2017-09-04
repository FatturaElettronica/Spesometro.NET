using System;
using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.Common
{
    public class DatiGenerali : BaseClassSerializable
    {

        public DatiGenerali() { }
        public DatiGenerali(XmlReader r) : base(r) { }
        
        [DataProperty]
        public string TipoDocumento { get; set; }
        [DataProperty]
        public DateTime Data { get; set; }
        [DataProperty]
        public string Numero { get; set; }
    }
}
