using System.ComponentModel;
using System.Globalization;
using System.Xml.Serialization;

namespace CurrencyViewer
{
    /// <remarks/>
    [XmlType(AnonymousType = true)]
    public class Valute
    {
        /// <remarks/>
        [DisplayName("Цифровой код")]
        public ushort NumCode { get; set; }

        /// <remarks/>
        [DisplayName("Код валюты")]
        public string CharCode { get; set; }

        /// <remarks/>
        [DisplayName("Номинал")]
        public ushort Nominal { get; set; }

        /// <remarks/>
        [DisplayName("Название")]
        public string Name { get; set; }

        /// <remarks/>
        [DisplayName("Курс")]
        public string Value { get; set; }

        /// <remarks/>
        [XmlAttribute("ID")]
        public string Id { get; set; }

        /// <summary>
        /// Значение курса в цифровом виде.
        /// </summary>
        [XmlIgnore]
        [DisplayName("Курс")]
        public decimal Rate
        {
            get { return decimal.Parse(Value, CultureInfo.CreateSpecificCulture("ru-Ru")); }
            set { Value = value.ToString(CultureInfo.CreateSpecificCulture("ru-Ru")); }
        }
    }
}