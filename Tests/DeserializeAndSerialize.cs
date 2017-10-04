using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using Spesometro.Settings;
using System;
using FatturaElettronica.Common;

namespace Tests
{
    [TestClass]
    public class DeserializeAndSerialize
    {
        [TestMethod]
        public void SerializeHeader()
        {
            var doc = new Spesometro.Spesometro();

            using (var w = XmlWriter.Create("test", new XmlWriterSettings { Indent = true }))
            {
                doc.WriteXml(w);
            }

            using (var r = XmlReader.Create("test"))
            {
               while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        if (r.Prefix == RootElement.Prefix && r.LocalName == RootElement.LocalName)
                        {
                            Assert.AreEqual(RootElement.NameSpace, r.NamespaceURI);
                            foreach (var a in RootElement.ExtraAttributes)
                            {
                                Assert.AreEqual(a.value, r.GetAttribute(string.Format("{0}:{1}", a.Prefix, a.LocalName)));
                            }
                            break;
                        }
                    }
                }
            }
            File.Delete("test");
        }

        [TestMethod]
        public void DeserializeAndThenSerializeDTESample()
        {
            DeserializeAndThenSerialize("Samples/ITAAABBB99T99X999W_DF_00004.xml", "DTE");
        }

        [TestMethod]
        public void DeserializeAndThenSerializeDTRSample()
        {
            DeserializeAndThenSerialize("Samples/ITAAABBB99T99X999W_DF_00002.xml", "DTR");
        }

        private void DeserializeAndThenSerialize(string filename, string sample)
        {
            var comunicazione = Deserialize(filename);
            var validator = new Spesometro.Validators.SpesometroValidator();

            var r = validator.Validate(comunicazione);
            Assert.IsTrue(validator.Validate(comunicazione).IsValid);
            ValidateComunicazione(comunicazione, sample);

            using (var w = XmlWriter.Create("challenge.xml", new XmlWriterSettings { Indent = true }))
            {
                comunicazione.WriteXml(w);
            }

            comunicazione = Deserialize("challenge.xml");

            Assert.IsTrue(validator.Validate(comunicazione).IsValid);
            ValidateComunicazione(comunicazione, sample);

            File.Delete("challenge.xml");
        }
        private Spesometro.Spesometro Deserialize(string fileName)
        {
            var doc = new Spesometro.Spesometro();
            var s = new XmlReaderSettings {IgnoreWhitespace = true};
            using (var r = XmlReader.Create(fileName, new XmlReaderSettings { IgnoreWhitespace = true }))
            {
                doc.ReadXml(r);
            }
            return doc;
        }
        private void ValidateComunicazione(Spesometro.Spesometro c, string sample)
        {
            switch (sample)
            {
                case "DTE":
                    ValidateComunicazioneDTE(c);
                    break;
                case "DTR":
                    ValidateComunicazioneDTR(c);
                    break;
            }
        }
        private void ValidateComunicazioneDTE(Spesometro.Spesometro c)
        {
            Assert.AreEqual("0112001", c.Header.ProgressivoInvio);

            var cp = c.FattureEmesse.CedentePrestatore;
            Assert.AreEqual("IT", cp.IdentificativiFiscali.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("xxxxxxxxxxxxxxxxx", cp.IdentificativiFiscali.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("GATEWAY INFORMATICA SRL", cp.AltriDatiIdentificativi.Denominazione);
            Assert.AreEqual("VIA DEGLI STADI,32", cp.AltriDatiIdentificativi.Sede.Indirizzo);
            Assert.AreEqual("87100", cp.AltriDatiIdentificativi.Sede.CAP);
            Assert.AreEqual("COSENZA", cp.AltriDatiIdentificativi.Sede.Comune);
            Assert.AreEqual("CS", cp.AltriDatiIdentificativi.Sede.Provincia);
            Assert.AreEqual("IT", cp.AltriDatiIdentificativi.Sede.Nazione);

            var cc = c.FattureEmesse.CessionarioCommittente[0];
            Assert.AreEqual("GRDSFN66D17H199K", cc.IdentificativiFiscali.CodiceFiscale);
            Assert.AreEqual("XXXXXXXXXXXXX", cc.AltriDatiIdentificativi.Denominazione);
            Assert.AreEqual("Via Giuseppe Mercalli, 2", cc.AltriDatiIdentificativi.Sede.Indirizzo);
            Assert.AreEqual("80056", cc.AltriDatiIdentificativi.Sede.CAP);
            Assert.AreEqual("Ercolano", cc.AltriDatiIdentificativi.Sede.Comune);
            Assert.AreEqual("NA", cc.AltriDatiIdentificativi.Sede.Provincia);
            Assert.AreEqual("IT", cc.AltriDatiIdentificativi.Sede.Nazione);
            var b = cc.DatiFatturaBody[0];
            Assert.AreEqual("TD01", b.DatiGenerali.TipoDocumento);
            Assert.AreEqual(2017, b.DatiGenerali.Data.Year);
            Assert.AreEqual(2, b.DatiGenerali.Data.Day);
            Assert.AreEqual(1, b.DatiGenerali.Data.Month);
            Assert.AreEqual("1", b.DatiGenerali.Numero);
            Assert.AreEqual(561.10m, b.DatiRiepilogo[0].ImponibileImporto);
            Assert.AreEqual(100m, b.DatiRiepilogo[0].Detraibile);
            Assert.AreEqual("I", b.DatiRiepilogo[0].EsigibilitaIVA);
            Assert.AreEqual(123.44m, b.DatiRiepilogo[0].DatiIVA.Imposta);
            Assert.AreEqual(22m, b.DatiRiepilogo[0].DatiIVA.Aliquota);

            cc = c.FattureEmesse.CessionarioCommittente[1];
            Assert.AreEqual("IT", cc.IdentificativiFiscali.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("xxxxxxxxxxxxxxxx", cc.IdentificativiFiscali.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("ZZZZZZZZZZZZZZZZ", cc.AltriDatiIdentificativi.Denominazione);
            Assert.AreEqual("Via Ripuaria, 119", cc.AltriDatiIdentificativi.Sede.Indirizzo);
            Assert.AreEqual("80014", cc.AltriDatiIdentificativi.Sede.CAP);
            Assert.AreEqual("Giugliano in Campania", cc.AltriDatiIdentificativi.Sede.Comune);
            Assert.AreEqual("NA", cc.AltriDatiIdentificativi.Sede.Provincia);
            Assert.AreEqual("IT", cc.AltriDatiIdentificativi.Sede.Nazione);
            b = cc.DatiFatturaBody[0];
            Assert.AreEqual("TD01", b.DatiGenerali.TipoDocumento);
            Assert.AreEqual(2017, b.DatiGenerali.Data.Year);
            Assert.AreEqual(2, b.DatiGenerali.Data.Day);
            Assert.AreEqual(1, b.DatiGenerali.Data.Month);
            Assert.AreEqual("2", b.DatiGenerali.Numero);
            Assert.AreEqual(183.10m, b.DatiRiepilogo[0].ImponibileImporto);
            Assert.AreEqual(100m, b.DatiRiepilogo[0].Detraibile);
            Assert.AreEqual("I", b.DatiRiepilogo[0].EsigibilitaIVA);
            Assert.AreEqual(40.28m, b.DatiRiepilogo[0].DatiIVA.Imposta);
            Assert.AreEqual(22m, b.DatiRiepilogo[0].DatiIVA.Aliquota);
        }
        private void ValidateComunicazioneDTR(Spesometro.Spesometro c)
        {
            Assert.AreEqual("19", c.Header.ProgressivoInvio);

            var cc = c.FattureRicevute.CessionarioCommittente;
            Assert.AreEqual("IT", cc.IdentificativiFiscali.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("03954060632", cc.IdentificativiFiscali.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("GRDSFN66D17H199K", cc.IdentificativiFiscali.CodiceFiscale);
            Assert.AreEqual("PIPPO", cc.AltriDatiIdentificativi.Nome);
            Assert.AreEqual("FRANCO", cc.AltriDatiIdentificativi.Cognome);
            Assert.AreEqual("Via Posillipo", cc.AltriDatiIdentificativi.Sede.Indirizzo);
            Assert.AreEqual("1", cc.AltriDatiIdentificativi.Sede.NumeroCivico);
            Assert.AreEqual("80100", cc.AltriDatiIdentificativi.Sede.CAP);
            Assert.AreEqual("Napoli", cc.AltriDatiIdentificativi.Sede.Comune);
            Assert.AreEqual("NA", cc.AltriDatiIdentificativi.Sede.Provincia);
            Assert.AreEqual("IT", cc.AltriDatiIdentificativi.Sede.Nazione);

            var cp = c.FattureRicevute.CedentePrestatore[0];
            Assert.AreEqual("IT", cp.IdentificativiFiscali.IdFiscaleIVA.IdPaese);
            Assert.AreEqual("03954060632", cp.IdentificativiFiscali.IdFiscaleIVA.IdCodice);
            Assert.AreEqual("93006500610", cp.IdentificativiFiscali.CodiceFiscale);
            Assert.AreEqual("PIPPO S.R.L.", cp.AltriDatiIdentificativi.Denominazione);
            Assert.AreEqual("VIA ROMA", cp.AltriDatiIdentificativi.Sede.Indirizzo);
            Assert.AreEqual("80100", cp.AltriDatiIdentificativi.Sede.CAP);
            Assert.AreEqual("napoli", cp.AltriDatiIdentificativi.Sede.Comune);
            Assert.AreEqual("NA", cp.AltriDatiIdentificativi.Sede.Provincia);
            Assert.AreEqual("IT", cp.AltriDatiIdentificativi.Sede.Nazione);
            var b = cp.DatiFatturaBody[0];
            Assert.AreEqual("TD01", b.DatiGenerali.TipoDocumento);
            Assert.AreEqual(2017, b.DatiGenerali.Data.Year);
            Assert.AreEqual(1, b.DatiGenerali.Data.Day);
            Assert.AreEqual(5, b.DatiGenerali.Data.Month);
            Assert.AreEqual("2", b.DatiGenerali.Numero);
            Assert.AreEqual(1000m, b.DatiRiepilogo[0].ImponibileImporto);
            Assert.AreEqual(100m, b.DatiRiepilogo[0].DatiIVA.Imposta);
            Assert.AreEqual(10m, b.DatiRiepilogo[0].DatiIVA.Aliquota);
    }
        private void SerializeAndAssertRootElementAttributes(Spesometro.Spesometro doc)
        {
        }
    }
}
