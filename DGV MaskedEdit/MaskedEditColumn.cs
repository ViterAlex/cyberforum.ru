using System;
using System.Windows.Forms;
namespace DGVMaskedEdit {
	class MaskedEditColumn : DataGridViewColumn {
		public MaskedEditColumn()
			: base(new MaskedEditCell()) {
		}
		public MaskedEditColumn(string format)
			: base(new MaskedEditCell()) {
			DefaultCellStyle.Format = format;
			if (format == "lon")
				mask = @"00\'00\'00\,000";
			else if (format == "lat")
				mask = @"000\'00\'00\,000";
			DefaultCellStyle.FormatProvider = new CoordinatesFormatProvider();
			DefaultCellStyle.DataSourceNullValue = string.Empty;
			DefaultCellStyle.NullValue = string.Empty;
		}
		public override DataGridViewCell CellTemplate {
			get {
				return base.CellTemplate;
			}
			set {
				if ((value != null) && !value.GetType().IsAssignableFrom(typeof(MaskedEditCell))) {
					throw new InvalidCastException("Must be a MaskedEditCell");
				}
				base.CellTemplate = value;
			}
		}
		private string mask;

		public string Mask {
			get { return mask; }
			set { mask = value; }
		}
		private Type validatingType;

		public Type ValidatingType {
			get { return validatingType; }
			set { validatingType = value; }
		}

		private char promtChar = '_';

		public char PromtChar {
			get { return promtChar; }
			set { promtChar = value; }
		}
		private MaskedEditCell MaskedEditCellTemplate {
			get { return this.CellTemplate as MaskedEditCell; }
		}


	}
}
