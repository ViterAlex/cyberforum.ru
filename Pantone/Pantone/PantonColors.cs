using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Pantone
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false,ElementName = "colors")]
    public class PantonColors
    {
        /// <remarks/>
        [XmlElement("color")]
        public List<PantonColor> Set { get; set; }

        /// <remarks/>
        [XmlAttribute("name")]
        public string SetName { get; set; }
    }
}