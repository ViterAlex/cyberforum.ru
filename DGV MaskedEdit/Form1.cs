using System;
using System.Data;
using System.Windows.Forms;

namespace DGVMaskedEdit {
	public partial class Form1 : Form {
		DataTable dt = new DataTable();
		public Form1() {
			InitializeComponent();
			Random rnd = new Random(DateTime.Now.Millisecond);

			dt.Columns.Add("Latitude");
			dt.Columns.Add("Longitude");
			dataGridView1.AutoGenerateColumns = false;
			for (int i = 0; i < 5; i++) {
				dt.Rows.Add(rnd.Next(1000000000, 1800000000), rnd.Next(100000000, 1000000000));
			}
			dataGridView1.DataSource = dt;

			MaskedEditColumn col = new MaskedEditColumn("lon");
			col.DataPropertyName = "Longitude";
			col.HeaderText = "Широта";
			col.Name = col.DataPropertyName;
			dataGridView1.Columns.Add(col);

			col = new MaskedEditColumn("lat");
			col.DataPropertyName = "Latitude";
			col.HeaderText = "Долгота";
			col.Name = col.DataPropertyName;
			dataGridView1.Columns.Add(col);
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
			if (e.CellStyle.FormatProvider is ICustomFormatter && e.CellStyle.FormatProvider is CoordinatesFormatProvider) {
				//e.Value = (e.CellStyle.FormatProvider.GetFormat(typeof(ICustomFormatter)) as ICustomFormatter).Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
				CoordinatesFormatProvider cf = new CoordinatesFormatProvider();
				e.Value = cf.Format(e.CellStyle.Format, e.Value, cf);
				e.FormattingApplied = e.Value.ToString() != string.Empty;
			}
		}

		private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e) {
			e.Value = e.Value.ToString().Replace("'", "").Replace(",", "");
			e.ParsingApplied = true;
		}
	}
}
