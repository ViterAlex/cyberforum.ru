namespace System.Windows.Forms
{
    /// <summary>
    /// Контрол для выбора результат голосования
    /// </summary>
    public partial class VoteSelector : UserControl
    {
        private VotingResultEnum _voteResult;
        public event EventHandler VoteResultChanged;
        /// <summary>
        /// Результат голосования
        /// </summary>
        public VotingResultEnum VoteResult
        {
            get { return _voteResult; }
            set
            {
                if (_voteResult == value) return;
                _voteResult = value;
                OnVoteResultChanged();
                UpdateView();
            }
        }

        private void UpdateView()
        {
            switch (_voteResult)
            {
                case VotingResultEnum.Yes:
                    yesRadioButton.Checked = true;
                    break;
                case VotingResultEnum.No:
                    noRadioButton.Checked = true;
                    break;
                case VotingResultEnum.Abstain:
                    abstainRadioButton.Checked = true;
                    break;
            }
        }

        protected virtual void OnVoteResultChanged()
        {
            VoteResultChanged?.Invoke(this, EventArgs.Empty);
        }

        public VoteSelector()
        {
            InitializeComponent();
            yesRadioButton.Tag = VotingResultEnum.Yes;
            noRadioButton.Tag = VotingResultEnum.No;
            abstainRadioButton.Tag = VotingResultEnum.Abstain;
            UpdateView();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (!rb.Checked) return;
            VoteResult = (VotingResultEnum)rb.Tag;
        }
    }
}
