using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HighlightAndRemove
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetEnabled();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Add(new TextBox { Text = $"{flowLayoutPanel1.Controls.Count + 1}" });
        }

private void HighlightAndRemove(Control.ControlCollection controls, int index)
{
    this.InvokeEx(new Action(() =>
    {
        controls[index].BackColor = Color.Red;
        Refresh();
    }));
    Thread.Sleep(200);
    this.InvokeEx(new Action(() =>
    {
        controls.RemoveAt(index);
    }));
}

        private void removeButton_Click(object sender, EventArgs e)
        {
            HighlightAndRemove(flowLayoutPanel1.Controls, 0);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear(flowLayoutPanel1.Controls);
        }

private async void Clear(Control.ControlCollection controls)
{
    while (controls.Count > 0)
    {
        await Task<bool>.Factory.StartNew(() =>
        {
            HighlightAndRemove(controls, 0);
            return true;
        });
    }
}

        private void SetEnabled()
        {
            removeButton.Enabled = flowLayoutPanel1.Controls.Count > 0;
            clearButton.Enabled = flowLayoutPanel1.Controls.Count > 0;
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            SetEnabled();
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            SetEnabled();
        }
    }
}
