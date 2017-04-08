using System;
using System.Windows.Forms;
namespace DGVMaskedEdit {
	class MaskedEditControl : MaskedTextBox, IDataGridViewEditingControl {
		private DataGridView dataGridViewControl;
		private bool valueIsChanged = false;
		private int rowIndexNum;
		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle) {
			this.Font = dataGridViewCellStyle.Font;
			this.BackColor = dataGridViewCellStyle.BackColor;
			this.ForeColor = dataGridViewCellStyle.ForeColor;
		}

		public DataGridView EditingControlDataGridView {
			get {
				return dataGridViewControl;
			}
			set {
				dataGridViewControl = value;
			}
		}

		public object EditingControlFormattedValue {
			get {
				return this.Text;
			}
			set {
				this.Text = value.ToString();
			}
		}

		public int EditingControlRowIndex {
			get {
				return rowIndexNum;
			}
			set {
				rowIndexNum = value;
			}
		}

		public bool EditingControlValueChanged {
			get {
				return valueIsChanged;
			}
			set {
				valueIsChanged = value;
			}
		}

		public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey) {
			return true;
		}

		public Cursor EditingPanelCursor {
			get { return base.Cursor; }
		}

		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) {
			return this.Text;
		}

		public void PrepareEditingControlForEdit(bool selectAll) {
			//throw new NotImplementedException();
		}

		public bool RepositionEditingControlOnValueChange {
			get { return false; }
		}
		protected override void OnTextChanged(EventArgs e) {
			valueIsChanged = true;
			this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
			base.OnTextChanged(e);
		}
	}
}
