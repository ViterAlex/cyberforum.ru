using System;
using System.Globalization;
using System.Windows.Data;
using Dates;
namespace ExperienceCounter.Converters
{
    /// <summary>
    /// Конвертер разницы дат в строку
    /// </summary>
    internal class DateDiffConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var start = values[0] as DateTime? ?? new DateTime();
            var end = values[1] as DateTime? ?? new DateTime();
            var datespan = new DateSpan(start, end);
            var dayDiff = datespan.Days;
            if (end.Day < start.Day)
            {
                dayDiff = DateTime.DaysInMonth(end.Year, end.Month) - start.Day + end.Day;
            }
            return string.Format(new DateDiffFormat(), "{0:y} {1:m} {2:d}", datespan.Years, datespan.Months == 12 ? 0 : datespan.Months, dayDiff);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
