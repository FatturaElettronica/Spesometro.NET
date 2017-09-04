using System.Xml;
using ComunicazioneFattureCorrispettivi.Common;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.Common
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
