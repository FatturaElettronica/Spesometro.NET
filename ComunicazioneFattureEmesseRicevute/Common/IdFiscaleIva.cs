using System.Xml;
using ComunicazioneFattureEmesseRicevute.Validators;
using FatturaElettronica.Common;

namespace ComunicazioneFattureEmesseRicevute.Common
{
    public class IdFiscaleIVA : BaseClassValidatable<IdFiscaleIVA>
    {

        public IdFiscaleIVA() : base()
        {
            Validator = new IdFiscaleIVAValidator();
        }

        public IdFiscaleIVA(XmlReader r) : base(r) { }

        [DataProperty]
        public string IdPaese { get; set; }

        [DataProperty]
        public string IdCodice { get; set; }
    }
}
