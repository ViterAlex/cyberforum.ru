namespace System.Windows.Forms
{
    /// <summary>
    /// Столбец с ячейкой результата голосования
    /// </summary>
    public class VotingColumn : DataGridViewTextBoxColumn
    {
        private VotingCell _cellTemplate;

        public override DataGridViewCell CellTemplate
        {
            get
            {
                if (_cellTemplate == null)
                    _cellTemplate = new VotingCell();
                return _cellTemplate;
            }
            set
            {
                _cellTemplate = (VotingCell)value;
            }
        }
    }
}
