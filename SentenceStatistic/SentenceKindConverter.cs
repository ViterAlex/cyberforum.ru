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
            string answer = "ѕредложение не заканчиваетс€ на какой-либо из знаков ?, !, .";
            switch (kind)
            {
                case SentenceKind.Narrative:
                    answer = "ѕредложение €вл€етс€ повествовательным";
                    break;
                case SentenceKind.Interrogative:
                    answer = "ѕредложение €вл€етс€ вопросительным";
                    break;
                case SentenceKind.Exclamation:
                    answer = "ѕредложение €вл€етс€ восклицательным";
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