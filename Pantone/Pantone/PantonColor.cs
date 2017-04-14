using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace Pantone
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class PantonColor
    {

        [XmlElement("pantone")]
        public string PantoneId { get; set; }

        [XmlElement("hex")]
        public string Hex { get; set; }

        [XmlIgnore]
        public Color Color
        {
            get
            {
                return ColorTranslator.FromHtml(Hex);
            }
        }
        #region Overrides of Object

        public override string ToString()
        {
            return string.Format("{0}:{1}", PantoneId, Hex);
        }

        #endregion
    }


}
