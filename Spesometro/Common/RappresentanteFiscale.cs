using System.Xml;
using Spesometro.Common;
using FatturaElettronica.Common;

namespace Spesometro.Common
{
    public class RappresentanteFiscale : DenominazioneNomeCognome
    {
        private readonly IdFiscaleIVA _idFiscaleIVA;

        public RappresentanteFiscale()
        {
            _idFiscaleIVA = new IdFiscaleIVA();
        }
        public RappresentanteFiscale(XmlReader r) : base(r) { }

        [DataProperty]
        public IdFiscaleIVA IdFiscaleIVA => _idFiscaleIVA;
    }
}
