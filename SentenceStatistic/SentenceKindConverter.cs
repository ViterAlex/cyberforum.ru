using System;
using System.Globalization;
using System.Windows.Data;
using SentenceStatistic.Models;

namespace SentenceStatistic
{
    public class SentenceKindConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kind = (SentenceKind) value;
            string answer = "Предложение не заканчивается на какой-либо из знаков ?, !, .";
            switch (kind)
            {
                case SentenceKind.Narrative:
                    answer = "Предложение является повествовательным";
                    break;
                case SentenceKind.Interrogative:
                    answer = "Предложение является вопросительным";
                    break;
                case SentenceKind.Exclamation:
                    answer = "Предложение является восклицательным";
                    break;
            }
            return answer;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}