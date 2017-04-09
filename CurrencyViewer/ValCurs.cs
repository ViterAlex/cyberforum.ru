using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyViewer
{

    /// <remarks/>
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class ValCurs
    {
        /// <remarks/>
        [XmlElement("Valute")]
        public List<Valute> Valutes { get; set; }

        /// <remarks/>
        [XmlAttribute]
        public string Date { get; set; }

        /// <remarks/>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
