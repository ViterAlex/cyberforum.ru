using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication4 {
    public partial class MainForm : Form {
        Point origin;
        public MainForm() {
            InitializeComponent();
            panel1.MouseClick += (s, e) => {
                origin = e.Location;
                panel1.Refresh();
            };
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            DrawFractal(e.Graphics,
                (float)rNumericUpDown.Value,
                (float)sNumericUpDown.Value,
                (float)tNumericUpDown.Value,
                (int)stepNumericUpDown.Value,
                origin);
        }

private void DrawFractal(Graphics g, float r, float s, float t, int step, Point origin) {
    g.TranslateTransform(origin.X, origin.Y);
    float angle;
    int red, green, blue;
    using (Pen pen = new Pen(Color.Black, 1.5f)) {
        for (int v = -10000; v < 10000; v += step) {
            angle = (float)(s * Math.Pow(v, t));
            red = Math.Abs(v / 4 + 1024) % 255;
            green = Math.Abs(255 - v / 3) % 255;
            blue = Math.Abs(128 - v) % 255;
            pen.Color = Color.FromArgb(red, green, blue);
            g.DrawLine(pen, 0, 0, r, r);
            g.TranslateTransform(r, r);
            g.RotateTransform(angle);
            Application.DoEvents();
        }
    }
}

        private void button1_Click(object sender, EventArgs e) {
            panel1.Refresh();
        }

        private void rNumericUpDown_ValueChanged(object sender, EventArgs e) {
            panel1.Refresh();
        }
    }
}
