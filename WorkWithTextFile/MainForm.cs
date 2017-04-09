using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WorkWithTextFile
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            UpdateView();
        }

        private void UpdateView()
        {
            exportExcelButton.Enabled = dataGridView1.RowCount > 0;
            cutToolStripButton.Enabled = dataGridView1.CurrentCell != null;
            copyToolStripButton.Enabled = dataGridView1.CurrentCell != null;
            pasteToolStripButton.Enabled = dataGridView1.CurrentCell != null;
            deleteRowButton.Enabled = dataGridView1.CurrentRow != null;
            insertRowButton.Enabled = dataGridView1.CurrentRow != null;
            saveToolStripButton.Enabled = !string.IsNullOrEmpty(_filename) && dataGridView1.RowCount > 0;

        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openTxtFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openTxtFileDialog.ShowDialog(this) != DialogResult.OK) return;
            _filename = openTxtFileDialog.FileName;
            ReadFile(openTxtFileDialog.FileName);
        }

        private List<List<string>> _dataList;
        private string _filename;

        private void ReadFile(string fileName)
        {
            _dataList = new List<List<string>>();
            using (var reader = new StreamReader(fileName, Encoding.Default))
            {
                while (reader.Peek() != -1)
                {
                    _dataList.Add(new List<string>(reader.ReadLine().Split(' ')));
                }
            }
            UpdateDgv();
        }

        private void UpdateDgv()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.ColumnCount = _dataList[0].Count;
            foreach (List<string> list in _dataList)
            {
                dataGridView1.Rows.Add(list.ToArray());
            }
            UpdateView();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }
            if (dataGridView1.CurrentCell.FormattedValue != null)
                Clipboard.SetText(dataGridView1.CurrentCell.FormattedValue.ToString());
            dataGridView1.CurrentCell.Value = null;
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }
            if (dataGridView1.CurrentCell.FormattedValue != null)
                Clipboard.SetText(dataGridView1.CurrentCell.FormattedValue.ToString());
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                return;
            }
            dataGridView1.CurrentCell.Value = Clipboard.GetText();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            using (var stream = new StreamWriter(_filename, false, Encoding.Default))
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    var list = new List<string>();
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        list.Add(dataGridView1[i, j].Value.ToString());
                    }
                    stream.WriteLine(string.Join(" ", list));
                }
            }
        }

        private void exportExcelButton_Click(object sender, EventArgs e)
        {
            dynamic xlApp = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            xlApp.Visible = true;
            xlApp.Workbooks.Add();
            var cell = dataGridView1.CurrentCell;
            dataGridView1.SelectAll();
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
            xlApp.ActiveSheet.Paste();
            if (cell != null)
            {
                dataGridView1.CurrentCell = cell;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void insertRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            var col = dataGridView1.CurrentCell.ColumnIndex;
            var index = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.Insert(index, 1);
            dataGridView1.CurrentCell = dataGridView1[col, index];
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.HeaderText = String.Format("Столбец {0}", e.Column.Index + 1);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _filename = string.Empty;
            if (_dataList != null) _dataList.Clear();
            dataGridView1.Columns.Clear();
            UpdateView();
        }
    }
}
