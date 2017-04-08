using System;
using System.Windows.Forms;
namespace DGVMaskedEdit {
	class MaskedEditCell : DataGridViewTextBoxCell {
		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle) {
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
			MaskedEditColumn mec = OwningColumn as MaskedEditColumn;
			MaskedEditControl mectrl = (MaskedEditControl)DataGridView.EditingControl;
			try {
				mectrl.Text = this.Value.ToString();
			}
			catch (Exception) {
				mectrl.Text = string.Empty;
			}
			mectrl.Mask = mec.Mask;
			mectrl.PromptChar = mec.PromtChar;
			mectrl.ValidatingType = mec.ValidatingType;
		}
		public override Type EditType {
			get {
				return typeof(MaskedEditControl);
			}
		}
		public override Type ValueType {
			get {
				return typeof(string);
			}
		}
		public override object DefaultNewRowValue {
			get {
				return string.Empty;
			}
		}


		protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts) {
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
		}
	}
}
