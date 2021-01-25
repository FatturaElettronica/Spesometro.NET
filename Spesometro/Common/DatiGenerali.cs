using System;
using System.Xml;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.Common
{
    public class DatiGenerali : BaseClassSerializable
    {
        public DatiGenerali() { }
        public DatiGenerali(XmlReader r) : base(r) { }
        
        [DataProperty(order:0)]
        public string TipoDocumento { get; set; }
        [DataProperty(order:1)]
        public DateTime Data { get; set; }
        [DataProperty(order:2)]
        public string Numero { get; set; }
    }
}
