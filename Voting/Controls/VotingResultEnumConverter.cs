using System.ComponentModel;
using System.Globalization;

namespace System.Windows.Forms
{
    internal class VotingResultEnumConverter : EnumConverter
    {
        public VotingResultEnumConverter(Type type) : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                var vr = (VotingResultEnum)value;
                return GetAttribute<DescriptionAttribute>(vr).Description;
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        internal static T GetAttribute<T>(Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
    }
}
