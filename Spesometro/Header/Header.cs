using System.Xml;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.Header
{
    public class Header : BaseClassSerializable
    {
        private readonly Dichiarante _dichiarante;
        public Header()
        {
            _dichiarante = new Dichiarante();
        }
        public Header(XmlReader r) : base(r) { }

        [DataProperty]
        public string ProgressivoInvio { get; set; }
        [DataProperty]
        public Dichiarante Dichiarante => _dichiarante;
        public string IdSistema {get;}
    }
}
