using System.Xml;
using FatturaElettronica.Common;
using FatturaElettronica.Core;

namespace Spesometro.Common
{
    public class DenominazioneNomeCognome : BaseClassSerializable
    {
        public DenominazioneNomeCognome() { } 
        public DenominazioneNomeCognome(XmlReader r) : base(r) { } 
        [DataProperty]
        public string Denominazione { get; set; }
        [DataProperty]
        public string Nome { get; set; }
        [DataProperty]
        public string Cognome { get; set; }
        public string CognomeNome
        {
            get
            {
                var r = ((Cognome ?? string.Empty) + " " + (Nome ?? string.Empty)).Trim();
                return string.IsNullOrEmpty(r) ? null : r;
            }
        }
    }
}
