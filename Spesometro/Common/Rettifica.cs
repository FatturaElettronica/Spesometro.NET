using System.Xml;
using FatturaElettronica.Common;

namespace Spesometro.Common
{
    public class Rettifica : BaseClassSerializable
    {
        public Rettifica() { }
        public Rettifica(XmlReader r) : base(r) { }

        [DataProperty]
        public string IdFile { get; set; }
        [DataProperty]
        public int Posizione { get; set; }
    }
}
