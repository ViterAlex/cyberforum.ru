using System.Drawing;
using System.Windows.Forms;

namespace Pantone
{
    public partial class PantonColorChooser : UserControl
    {
        public PantonColorChooser()
        {
            InitializeComponent();
        }

        public PantonColorChooser(string name)
            : this()
        {
            nameLabel.Text = name;
        }

        public void SetColors(PantonColors colors)
        {
            colorCombo.DataSource = colors.Set;
        }

        public Color SelectedColor
        {
            get
            {
                return ((PantonColor)colorCombo.SelectedItem).Color;
            }
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }
            var pc = (PantonColor)colorCombo.Items[e.Index];
            var rect = e.Bounds;
            rect.Inflate(-1, -1);
            e.DrawBackground();
            e.Graphics.FillRectangle(pc.Color.Brush(), rect);
            e.Graphics.DrawString(pc.PantoneId, Font, SystemBrushes.ActiveCaptionText, rect);
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.DrawFocusRectangle();
        }
    }
}
