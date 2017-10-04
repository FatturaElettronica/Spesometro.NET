namespace Spesometro.Tabelle
{
    public class TipoDocumento : Tabella
    {
        public override Tabella[] List
        {
            get
            {
                return new Tabella[]
                {
                    new TipoDocumento { Codice = "TD01", Nome = "fattura" },
                    new TipoDocumento { Codice = "TD04", Nome = "nota di credito" },
                    new TipoDocumento { Codice = "TD05", Nome = "nota di debito" },
                    new TipoDocumento { Codice = "TD07", Nome = "fattura semplificata" },
                    new TipoDocumento { Codice = "TD08", Nome = "nota di credito semplificata" }
                };

            }
        }
    }
}