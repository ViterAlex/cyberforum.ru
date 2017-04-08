using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FigureInFigure
{
    internal class CheckBoxRowHeaderCell : DataGridViewRowHeaderCell
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

        #endregion

        #region Overrides of DataGridViewHeaderCell

        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseUp(e);
            Value = Value == null || !(bool)Value;
        }

        #region Overrides of DataGridViewHeaderCell

        

        #region Overrides of DataGridViewCell

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //base.OnMouseClick(e);
        }

        #endregion

        #endregion

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
