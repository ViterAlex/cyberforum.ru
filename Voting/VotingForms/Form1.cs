using System;
using System.Windows.Forms;

namespace Voting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dataGridView1.Rows.Add(VotingResultEnum.No, VotingResultEnum.Yes, VotingResultEnum.No, VotingResultEnum.Yes,VotingResultEnum.No);
            dataGridView1.Rows.Add(VotingResultEnum.No, VotingResultEnum.Yes, VotingResultEnum.No, VotingResultEnum.Yes,VotingResultEnum.No);
            dataGridView1.Rows.Add(VotingResultEnum.No, VotingResultEnum.Yes, VotingResultEnum.No, VotingResultEnum.Yes,VotingResultEnum.No);
            dataGridView1.Rows.Add(VotingResultEnum.No, VotingResultEnum.Yes, VotingResultEnum.No, VotingResultEnum.Yes,VotingResultEnum.No);
            dataGridView1.Rows.Add(VotingResultEnum.No, VotingResultEnum.Yes, VotingResultEnum.No, VotingResultEnum.Yes,VotingResultEnum.No);
        }
    }
}
