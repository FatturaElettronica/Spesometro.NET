using System.Xml;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.Common
{
    public class CedenteCessionario<T> : BaseClassValidatable<T> where T: CedenteCessionario<T>
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
