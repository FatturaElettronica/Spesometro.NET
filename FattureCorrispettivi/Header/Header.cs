using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.Header
{
    public class Header : BaseClassSerializable
    {
        private readonly Dichiarante _dichiarante;
        public Header()
        {
            _dichiarante = new Dichiarante();
        }
        [DataProperty]
        public string ProgressivoInvio { get; set; }
        [DataProperty]
        public Dichiarante Dichiarante => _dichiarante;
        public string IdSistema {get;}
    }
}
