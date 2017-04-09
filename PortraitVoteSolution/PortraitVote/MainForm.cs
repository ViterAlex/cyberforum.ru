using System;
using System.Linq;
using System.Windows.Forms;
namespace PortraitVote
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                var portrait = new PortraitVote(i+1);
                portrait.ChoiseChanged += Portrait_ChoiseChanged;
                flowLayoutPanel1.Controls.Add(portrait);
            }
        }

        private void Portrait_ChoiseChanged(object sender, EventArgs e)
        {
            var portraits = flowLayoutPanel1.Controls.OfType<PortraitVote>().ToList();
            var dislikeCount = portraits.Count(p => p.Choise == PortraitVote.ChoiseEnum.Dislike);
            var likeCount = portraits.Count(p => p.Choise == PortraitVote.ChoiseEnum.Like);

            foreach (var portraitVote in portraits)
            {
                if (portraitVote.Choise != PortraitVote.ChoiseEnum.Unset) continue;
                portraitVote.SecondEnabled = dislikeCount != 2;
                portraitVote.FirstEnabled = likeCount != 2;
            }

        }
    }
}
