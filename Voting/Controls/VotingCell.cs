using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// Ячейка для отображения результат голосования
    /// </summary>
    public class VotingCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// Редактор значения в ячейке
        /// </summary>
        public override Type EditType
        {
            get { return typeof(VotingEditCell); }
        }
        /// <summary>
        /// Тип значения в ячейке
        /// </summary>
        public override Type ValueType
        {
            get { return typeof(VotingResultEnum); }
        }
        /// <summary>
        /// Значение для новой строки по умолчанию
        /// </summary>
        public override object DefaultNewRowValue
        {
            get { return default(VotingResultEnum); }
        }
        /// <summary>
        /// Преобразование введённого значения
        /// </summary>
        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
        {
            if (formattedValue is VotingResultEnum)
            {
                return formattedValue;
            }
            else if (formattedValue is string)
            {
                return (VotingResultEnum)Enum.Parse(typeof(VotingResultEnum), formattedValue.ToString());
            }
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }
        /// <summary>
        /// Инициализация контрола редактирования ячейки
        /// </summary>
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            var ectl = DataGridView.EditingControl as VotingEditCell;
            if (ectl == null) return;
            ectl.VoteResult = Value != null
                ? (VotingResultEnum)Value
                : default(VotingResultEnum);
            ectl.VoteResultChanged += Ectl_VoteResultChanged;
        }

        private void Ectl_VoteResultChanged(object sender, EventArgs e)
        {
            var vc = (sender as VotingEditCell);
            vc.VoteResultChanged -= Ectl_VoteResultChanged;
            DataGridView.EndEdit();
        }

        /// <summary>
        /// Положение и размер контрола для редактирования
        /// </summary>
        public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            var size = DataGridView.EditingControl.Size;
            var rect = new Rectangle(cellBounds.Location, size);
            base.PositionEditingControl(setLocation, setSize, rect, rect, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
        }
    }
}
