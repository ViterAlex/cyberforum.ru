using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVtoPARNamespace {
	public partial class RowsColumnsSelectForm : Form {

		private CSVProcess cp;//Класс, обрабатывающий CSV-файл 
		private DGVForm dgvForm;//третья форма для показа результатов выбора

		public RowsColumnsSelectForm() {
			InitializeComponent();

		}
		//Конструктор формы со ссылкой на класс-обработчик csv-файлов
		public RowsColumnsSelectForm(CSVProcess cp) {
			InitializeComponent();
			this.cp = cp;
		}

		//Клик по переключателю для выбора диапазона строк
		private void SelectRangeRadioButton_CheckedChanged(object sender, EventArgs e) {
			EnableUpDowns((sender as RadioButton).Checked);
			EndRowIndexUpDown.Value = EndRowIndexUpDown.Maximum;
		}

		//Метод изменения состояния доступности контролов
		private void EnableUpDowns(bool value) {
			StartRowIndexUpDown.Enabled = value;
			EndRowIndexUpDown.Enabled = value;
			label1.Enabled = value;
		}

		//Процедура загрузки формы
		private void Form2_Load(object sender, EventArgs e) {
			ConvertButton.Enabled = checkedListBox1.CheckedIndices.Count != 0;

			checkedListBox1.Items.AddRange(cp.ColumnsNames);
			StartRowIndexUpDown.Maximum = cp.RowsCount;
			EndRowIndexUpDown.Maximum = cp.RowsCount;
			EnableUpDowns(SelectRangeRadioButton.Checked);
		}

		//Клик по кнопке "Конвертировать"
		private void ConvertButton_Click(object sender, EventArgs e) {
			if (dgvForm != null) { dgvForm.Close(); dgvForm = null; }
			int startRowIndex, endRowIndex;
			if (SelectAllRadioButton.Checked) {
				startRowIndex = 1;
				endRowIndex = (int)EndRowIndexUpDown.Maximum;
			}
			else {
				startRowIndex = (int)StartRowIndexUpDown.Value;
				endRowIndex = (int)EndRowIndexUpDown.Value;
			}
			int[] columnIndices = checkedListBox1.CheckedIndices.Cast<int>().Select(i => i).ToArray<int>();
			dgvForm = new DGVForm(cp.GetDataTablePart(startRowIndex, endRowIndex, columnIndices));
			dgvForm.Show();
		}

		//Клик по списку
		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) {
			ConvertButton.Enabled = (sender as CheckedListBox).CheckedIndices.Count != 0;
		}

		//Измененение значения индекса начальной строки
		private void StartRowIndexUpDown_ValueChanged(object sender, EventArgs e) {
			EndRowIndexUpDown.Minimum = StartRowIndexUpDown.Value;
		}

		private void CheckAllLabel_Click(object sender, EventArgs e) {

			for (int i = 0; i < checkedListBox1.Items.Count; i++)
				checkedListBox1.SetItemChecked(i, true);
			ConvertButton.Enabled = checkedListBox1.CheckedIndices.Count != 0;
		}

		private void UncheckAllLabel_Click(object sender, EventArgs e) {

			for (int i = 0; i < checkedListBox1.Items.Count; i++)
				checkedListBox1.SetItemChecked(i, false);
			ConvertButton.Enabled = checkedListBox1.CheckedIndices.Count != 0;
		}
	}
}
