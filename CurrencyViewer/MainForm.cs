using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CurrencyViewer
{
    public partial class MainForm : Form
    {
        private ValCurs _valCurs;
        public MainForm()
        {
            InitializeComponent();
            //Автогенерация столбцов
            dataGridView1.AutoGenerateColumns = true;
            //Выбор всей строки
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToOrderColumns = true;
            //Событие добавления столбца
            dataGridView1.ColumnAdded += (sender, args) =>
            {
                //Скрываем столбец Value, Id как неинформативные
                args.Column.Visible = args.Column.Name != "Value" && args.Column.Name != "Id";
            };
            fromNumericUpDown.Minimum = decimal.MinValue;
            fromNumericUpDown.Maximum = decimal.MaxValue;
            toNumericUpDown.Minimum = decimal.MinValue;
            toNumericUpDown.Maximum = decimal.MaxValue;
        }

        private void downloadRatesFileButton_Click(object sender, EventArgs e)
        {
            UpdateRates();

        }

        private void SetDataSources()
        {
            //Отображаем данные в dataGridView1 через bindingSource1
            bindingSource1.DataSource = _valCurs.Valutes;
            toBindingSource.DataSource = _valCurs.Valutes;
            fromBindingSource.DataSource = _valCurs.Valutes;
            toComboBox.DisplayMember = "CharCode";
            fromComboBox.DisplayMember = "CharCode";
            //Отображаем дату
            currentDateLabel.Text = _valCurs.Date;
        }

        private async void UpdateRates()
        {
            using (var client = new WebClient())
            {
                //Индикация процесса работы
                downloadRatesFileButton.Text = "Обновление данных...";
                //Скачиваем данные с сайта
                var xml = await client.DownloadStringTaskAsync(new Uri("http://www.cbr.ru/scripts/XML_daily.asp"));
                downloadRatesFileButton.Text = "Обновить курсы";
                if (string.IsNullOrEmpty(xml)) return;
                //Сериализация полученной строки в нужный тип данных
                var serializer = new XmlSerializer(typeof(ValCurs));
                using (TextReader reader = new StringReader(xml))
                {
                    _valCurs = serializer.Deserialize(reader) as ValCurs;
                }
                SetDataSources();
            }
        }

        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate(fromNumericUpDown.Value, (Valute)fromComboBox.SelectedValue, (Valute)toComboBox.SelectedValue);
        }

        private void Calculate(decimal from, Valute rateFrom, Valute rateTo)
        {
            if (fromComboBox.SelectedItem == null || toComboBox.SelectedItem == null) return;
            var rubles = from * rateFrom.Rate / rateFrom.Nominal;
            //var y = rubles* rateTo.Nominal / rateTo.Rate;

            try
            {
                toNumericUpDown.Value = rubles * rateTo.Nominal / rateTo.Rate;
            }
            catch (Exception)
            {
            }
        }

        private void fromNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Calculate(fromNumericUpDown.Value, (Valute)fromComboBox.SelectedValue, (Valute)toComboBox.SelectedValue);
        }

        
    }
}
