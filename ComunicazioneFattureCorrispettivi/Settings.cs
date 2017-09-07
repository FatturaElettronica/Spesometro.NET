using System.Runtime.CompilerServices;

namespace ComunicazioneFattureCorrispettivi.Settings
{
    public class Version
    {
        public static string Current => "DAT20";
    }
    public class RootElement
    {
        public static string Prefix { get { return "ns2"; } }
        public static string LocalName { get { return "DatiFattura"; } }
        public static string NameSpace { get { return "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v2.0"; } }
        public static XmlAttributeString[] ExtraAttributes
        {
            get
            {
                return new XmlAttributeString[] { };
                //return new XmlAttributeString[] {
                //    new XmlAttributeString { Prefix="xmlns", LocalName="ds", ns=null, value="http://www.w3.org/2000/09/xmldsig#"},
                //    new XmlAttributeString { Prefix="xmlns", LocalName="xsi", ns=null, value="http://www.w3.org/2001/XMLSchema-instance"},
                //    new XmlAttributeString { Prefix="xsi", LocalName="schemaLocation", ns=null, value="http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2 fatturaordinaria_v1.2.xsd"}
                //};
            }
        }
        public class XmlAttributeString
        {
            public string Prefix;
            public string LocalName;
            public string ns;
            public string value;
        }
    }
}
