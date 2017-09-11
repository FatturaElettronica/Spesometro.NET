using System.Xml;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Common
{
    public class CedenteCessionario : BaseClassSerializable
    {
        private readonly IdentificativiFiscali _identificativiFiscali;
        private readonly AltriDatiIdentificativi _altriDatiIdentificativi;

        public CedenteCessionario()
        {
            _identificativiFiscali = new IdentificativiFiscali();
            _altriDatiIdentificativi = new AltriDatiIdentificativi();
        }
        public CedenteCessionario(XmlReader r) : base(r) { }

        [DataProperty(order:0)]
        public IdentificativiFiscali IdentificativiFiscali => _identificativiFiscali;
        [DataProperty(order:1)]
        public AltriDatiIdentificativi AltriDatiIdentificativi => _altriDatiIdentificativi;
    }
}
