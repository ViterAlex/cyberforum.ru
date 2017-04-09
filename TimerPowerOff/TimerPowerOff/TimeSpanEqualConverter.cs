using System;
using System.Globalization;
using System.Windows.Data;

namespace TimerPowerOff
{
    public class TimeSpanEqualConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var seconds = (int)parameter;
            var ts = (TimeSpan) value;
            return ts.Seconds <= seconds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}