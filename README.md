# Spesometro, o Comunicazione delle Fatture Emesse e Ricvute

## Caratteristiche
- Lettura e scrittura nel [formato standard][pa] supportato dalla PA Italiana (XML).
- Convalida in osservanza delle specifiche  tecniche ufficiali
- .NET Standard v2.0 offre supporto per un [ampio numero di piattaforme][netstandard].

## Installazione
ComunicazioneFattureEmesseRicevute è un package [NuGet][nuget] quindi tutto quel che serve è eseguire:

```
	PM> Install-Package ComunicazioneFattureEmesseRicevute
```
dalla Package Console, oppure usare il comando equivalente in Visual Studio.

## Licenza
ComunicazioneFattureEmesseRicevute è un progetto open source di [Nicola Iarocci][ni] e [Gestionale Amica][ga] rilasciato sotto licenza [BSD][bsd].

## Utilizzo
```cs
using System;
using System.Xml;
using ComunicazioneFattureEmesseRicevute.Common;
using ComunicazioneFattureEmesseRicevute.FattureEmesse;
using ComunicazioneFattureEmesseRicevute.Validators;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var comunicazione = new ComunicazioneFattureEmesseRicevute.ComunicazioneFattureEmesseRicevute();

            // Lettura da file XML
            using (var file = XmlReader.Create("IT01180680397_DF_00001.xml", new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
            {
                comunicazione.ReadXml(file);
            }

            // La classe ComunicazioneFattureEmesseRicevute segue lo schema del tracciato ufficiale, vedi:
            // http://www.agenziaentrate.gov.it/wps/file/Nsilib/Nsi/Strumenti/Specifiche+tecniche/Specifiche+tecniche+comunicazioni/Fatture+e+corrispettivi+ST/Allegato+XML+Dati+Fattura/Formato+XMLdati_fattura.xls
            Console.WriteLine($"Progressivo invio: {comunicazione.Header.ProgressivoInvio}");
            Console.WriteLine($"Numero di destinatari fatture emesse: {comunicazione.FattureEmesse.CessionarioCommittente.Count}");

            // Aggiunta di una fattura per nuovo committente
            var committente = new CessionarioCommittente();
            committente.IdentificativiFiscali.CodiceFiscale = "01180680397";
            committente.AltriDatiIdentificativi.Denominazione = "CIR 2000";
            committente.AltriDatiIdentificativi.Sede.Indirizzo = "Via Sansovino 45";
            committente.AltriDatiIdentificativi.Sede.CAP = "48124";
            committente.AltriDatiIdentificativi.Sede.Comune = "Ravenna";

            var fattura = new DatiFatturaBody();
            fattura.DatiGenerali.Data = DateTime.Now;
            fattura.DatiGenerali.TipoDocumento = "TD01";
            fattura.DatiGenerali.Numero = "345";

            var riepilogo = new DatiRiepilogo { ImponibileImporto = 100, EsigibilitaIVA = "I" };
            riepilogo.DatiIVA.Aliquota = 22;
            riepilogo.DatiIVA.Imposta = 0.22m;

            fattura.DatiRiepilogo.Add(riepilogo);
            committente.DatiFatturaBody.Add(fattura);

            // Sono disponibili validatori per tutte le classi esposte dalla libreria.
            var v = new CessionarioCommittenteDTEValidator();
            var result = v.Validate(committente);

            if (result.IsValid)
            {
                comunicazione.FattureEmesse.CessionarioCommittente.Add(committente);

                // Serializzazione XML 
                using (var w = XmlWriter.Create("IT01180680397_DF_00001.xml", new XmlWriterSettings { Indent = true }))
                {
                    comunicazione.WriteXml(w);
                }
            }
            else
            {
                // Introspezione errori.
                foreach (var error in result.Errors)
                {
                    Console.WriteLine(error.PropertyName);
                    Console.WriteLine(error.ErrorMessage);
                    Console.WriteLine(error.ErrorCode);
                }
            }
            Console.ReadKey();
        }
    }
}
```

[bsd]: https://raw.githubusercontent.com/FatturaElettronica/ComunicazioneFattureEmesseRicevute/master/LICENSE
[ga]: http://gestionaleamica.com
[ni]: https://nicolaiarocci.com
[nuget]: https://www.nuget.org/packages/ComunicazioneFattureEmesseRicevute/
[pa]: http://www.agenziaentrate.gov.it/wps/file/Nsilib/Nsi/Strumenti/Specifiche+tecniche/Specifiche+tecniche+comunicazioni/Fatture+e+corrispettivi+ST/Allegato+XML+Dati+Fattura/Formato+XMLdati_fattura.xls
[netstandard]: https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md
