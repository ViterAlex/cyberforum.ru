using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GmapDgvSample
{
    public partial class DgvForm : Form
    {
        public DgvForm()
        {
            InitializeComponent();
        }

        public event EventHandler ShowMapRequest;
        private void openDbButton_Click(object sender, EventArgs e)
        {
            this.mapDataTableAdapter.Fill(this.mapDbDataSet.MapData);
        }

        private void updateDbButton_Click(object sender, EventArgs e)
        {
            mapDataTableAdapter.Update(mapDbDataSet.MapData);
        }

        private void showMapButton_Click(object sender, EventArgs e)
        {

        }

        protected virtual void OnShowMapRequest(List<MapData> list)
        {
            ShowMapRequest?.Invoke(list, EventArgs.Empty);
        }
        //Кнопка экспорта
        private void exportToWord_Click(object sender, EventArgs e)
        {
            //Переключение активности кнопки
            var setButtonEnabled = new Action<bool>(enabled => exportToWord.Enabled = enabled);
            //Дективация кнопки
            setButtonEnabled(false);
            //По завершении экспорта вызываем переключение активности кнопки
            WordExporter.ExportCompleted += () =>
            {
        //Поскольку это действие выполняется в другом потоке, то используем InvokeRequired
        if (InvokeRequired)
                    BeginInvoke(setButtonEnabled, true);
                else
                    setButtonEnabled(true);
            };
            //Начинаем экспорт
            WordExporter.Export(dataGridView1, Path.GetFullPath("exported.doc"));
        }
    }
}
