using System;
using System.Collections.Generic;
using System.Text;
using FatturaElettronica.Common;

namespace ComunicazioneFattureCorrispettivi.Header
{
    public class Dichiarante : BaseClassSerializable
    {
        [DataProperty]
        public string CodiceFiscale { get; set; }
        [DataProperty]
        public int Carica { get; set; } 
    }
}
