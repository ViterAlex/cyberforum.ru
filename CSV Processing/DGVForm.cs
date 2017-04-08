using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSVtoPARNamespace {
	public partial class DGVForm : Form {
		public DGVForm() {
			InitializeComponent();
		}
		public DGVForm(DataTable dt) {
			InitializeComponent();
			dataGridView1.DataSource = dt;
		}
	}
}
