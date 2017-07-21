namespace System.Windows.Forms
{
    /// <summary>
    /// Контрол для редактирования значения в ячейке
    /// </summary>
    public class VotingEditCell : VoteSelector, IDataGridViewEditingControl
    {
        #region Реализация IDataGridViewEditingControl

        public DataGridView EditingControlDataGridView { get; set; }

        public object EditingControlFormattedValue
        {
            get
            {
                return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                if (value is VotingResultEnum)
                {
                    VoteResult = (VotingResultEnum)value;
                }
                else if (value is string)
                {
                    VoteResult = (VotingResultEnum)Enum.Parse(typeof(VotingResultEnum), value?.ToString());
                }
                else
                {
                    VoteResult = default(VotingResultEnum);
                }
            }
        }

        public int EditingControlRowIndex { get; set; }
        public bool EditingControlValueChanged { get; set; }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            return;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return !dataGridViewWantsInputKey;
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return VoteResult.ToString();
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            return;
        }
        #endregion

        protected override void OnVoteResultChanged()
        {
            EditingControlValueChanged = true;
            EditingControlDataGridView?.NotifyCurrentCellDirty(true);
            base.OnVoteResultChanged();
        }
    }
}
