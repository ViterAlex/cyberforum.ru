using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace RunConsole.Converters
{
    /// <summary>
    ///     Конвертер для получения индекса элемента списка
    /// </summary>
    public class IndexConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (ListBoxItem) value;
            var listBox = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;
            if (listBox == null) return string.Empty;
            int index = listBox.ItemContainerGenerator.IndexFromContainer(item) + 1;
            return string.Format("Аргумент № {0}", index);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}