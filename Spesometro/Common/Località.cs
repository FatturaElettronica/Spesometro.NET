using System.Xml;
using FatturaElettronica.Common;

namespace Spesometro.Common
{
    public class Località : BaseClassSerializable
    {
        public Località() { }
        public Località(XmlReader r) : base(r) { } 

        [DataProperty]
        public string Indirizzo { get; set; }
        [DataProperty]
        public string NumeroCivico { get; set; }
        [DataProperty]
        public string CAP { get; set; }
        [DataProperty]
        public string Comune { get; set; }
        [DataProperty]
        public string Provincia { get; set; }
        [DataProperty]
        public string Nazione { get; set; }
    }
}
