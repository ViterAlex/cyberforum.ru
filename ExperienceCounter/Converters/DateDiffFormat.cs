using System;
using System.Collections.Generic;

namespace ExperienceCounter.Converters
{
    /// <summary>
    /// Класс для форматирования количества лет, месяцев и дней в соответствии с правилами русского языка
    /// </summary>
    internal class DateDiffFormat : IFormatProvider, ICustomFormatter
    {
        private readonly List<string> _years = new List<string>(new[]
                                                     {
                                                        "год", "года", "лет"
                                                     });
        private readonly List<string> _months = new List<string>(new[]
                                                     {
                                                        "месяц", "месяца", "месяцев"
                                                     });
        private readonly List<string> _days = new List<string>(new[]
                                                     {
                                                        "день", "дня", "дней"
                                                     });

        #region Implementation of IFormatProvider

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        #endregion

        #region Implementation of ICustomFormatter

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is int)) return arg.ToString();
            var val = (int)arg;
            if (val == 0) return string.Empty;
            //Форматирование года
            if (format.Equals("y"))
                return $"{FormatYears(val)}";
            //Форматирование месяца
            if (format.Equals("m"))
                return $"{FormatMonths(val)}";
            //Форматирование дня
            if (format.Equals("d"))
                return $"{FormatDays(val)}";
            return arg.ToString();
        }

        #endregion
        /// <summary>
        /// Форматирование числа лет
        /// </summary>
        /// <param name="value">Число лет</param>
        private string FormatYears(int value)
        {
            return $"{value} {GetRightCase(_years, value)}";
        }

        /// <summary>
        /// Форматирование числа месяцев
        /// </summary>
        /// <param name="value">Число месяцев</param>
        private string FormatMonths(int value)
        {
            return $"{value} {GetRightCase(_months, value)}";
        }

        /// <summary>
        /// Форматирование числа дней
        /// </summary>
        /// <param name="value">Число дней</param>
        private string FormatDays(int value)
        {
            return $"{value} {GetRightCase(_days, value)}";
        }

        /// <summary>
        /// Определение правильной формы существительного для числительного
        /// </summary>
        /// <param name="cases">Список форм существительных</param>
        /// <param name="value">Число</param>
        private static string GetRightCase(IList<string> cases, int value)
        {
            if (value == 0) return string.Empty;
            if (value > 100) value %= 100;
            if (value < 20)
            {
                switch (value)
                {
                    case 1:
                        return cases[0];
                    case 2:
                    case 3:
                    case 4:
                        return cases[1];
                    default:
                        return cases[2];
                }
            }
            var single = value % 10;
            switch (single)
            {
                case 1:
                    return cases[0];
                case 2:
                case 3:
                case 4:
                    return cases[1];
                default:
                    return cases[2];
            }
        }
    }
}
