using System.Xml;
using Spesometro.Common;
using FatturaElettronica.Common;

namespace Spesometro.Common
{
    public class AltriDatiIdentificativi : DenominazioneNomeCognome
    {
        private readonly Località _sede;
        private readonly Località _stabileOrganizzazione;
        private readonly RappresentanteFiscale _rappresentanteFiscale;

        public AltriDatiIdentificativi()
        {
            _sede = new Località();
            _stabileOrganizzazione = new Località();
            _rappresentanteFiscale = new RappresentanteFiscale();
        }
        public AltriDatiIdentificativi(XmlReader r) : base(r) { }

        [DataProperty]
        public Località Sede => _sede;
        [DataProperty]
        public Località StabileOrganizzazione => _stabileOrganizzazione;
        [DataProperty]
        public RappresentanteFiscale RappresentanteFiscale => _rappresentanteFiscale;
    }
}
