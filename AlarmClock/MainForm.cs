using System;
using System.Windows.Forms;

namespace AlarmClockNamespace {
	public partial class MainForm : Form {
		AlarmClock ac = new AlarmClock();
		public MainForm() {
			InitializeComponent();
			ShowTime();
		}

		private void HSetButton_Click(object sender, EventArgs e) {
			ac.SetHours();
			ShowTime();
		}

		private void MSetButton_Click(object sender, EventArgs e) {
			ac.SetMinutes();
			ShowTime();
		}

		private void AlarmButton_CheckedChanged(object sender, EventArgs e) {
			ac.AlarmMode = AlarmButton.Checked;
			ShowTime();
		}
		void ShowTime() { label1.Text = ac.ToString(); }
	}
}
