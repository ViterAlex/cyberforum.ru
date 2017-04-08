using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FigureInFigure
{
    internal class TopLeftCheckboxHeaderCell : DataGridViewTopLeftHeaderCell
    {

        #region Overrides of DataGridViewRowHeaderCell

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                                        DataGridViewElementStates cellState, object value, object formattedValue, string errorText,
                                        DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                        DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            var state = Value != null && (bool)Value ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
            var size = CheckBoxRenderer.GetGlyphSize(graphics, state);
            var pt = cellBounds.Location;
            pt.Offset(cellBounds.Width / 2, cellBounds.Height / 2);
            pt.Offset(-size.Width / 2, -size.Height / 2);
            CheckBoxRenderer.DrawCheckBox(graphics, pt, state);
        }

        protected override bool SetValue(int rowIndex, object value)
        {
            SetValues();
            return base.SetValue(rowIndex, value);
        }

        private void SetValues()
        {
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                bool headerCellValue = Value == null || !(bool)Value;
                row.HeaderCell.Value = headerCellValue;
                Debug.WriteLine(row.Index);
            }
        }
        #endregion

        #region Overrides of DataGridViewHeaderCell

        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseUp(e);
            Value = Value == null || !(bool)Value;
            DataGridView.HitTestInfo hitInfo = DataGridView.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                DataGridView.ClearSelection();
            }
        }
        
        public override Type ValueType
        {
            get
            {
                return typeof(bool);
            }
            set
            {

            }
        }

        #endregion

    }
}
