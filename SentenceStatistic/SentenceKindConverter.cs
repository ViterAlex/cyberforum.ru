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
            string answer = "����������� �� ������������� �� �����-���� �� ������ ?, !, .";
            switch (kind)
            {
                case SentenceKind.Narrative:
                    answer = "����������� �������� �����������������";
                    break;
                case SentenceKind.Interrogative:
                    answer = "����������� �������� ��������������";
                    break;
                case SentenceKind.Exclamation:
                    answer = "����������� �������� ���������������";
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