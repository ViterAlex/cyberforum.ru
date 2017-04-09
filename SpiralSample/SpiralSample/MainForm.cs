using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Spiral
{
    internal delegate PointF SpiralDelegate(float angle);

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private SpiralDelegate _spiral;
        private float _alpha;
        private float _n = 3;//количество оборотов
        private List<PointF> _points;
        private float _r = 3.2f;
        private float _scale;

        private void Form1_Load(object sender, EventArgs e)
        {
            _points = new List<PointF>();
            pictureBox1.Paint += pictureBox_Paint;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_points == null || _points.Count < 3)
            {
                return;
            }
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TranslateTransform(pictureBox1.ClientSize.Width / 2f, pictureBox1.ClientSize.Height / 2f);
            e.Graphics.ScaleTransform(_scale, _scale);
            using (var pen = new Pen(Color.Red, 1 / _scale))
            {
                e.Graphics.DrawCurve(pen, _points.ToArray());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _points.Add(_spiral(_alpha));
            _alpha += 0.2f;
            timer1.Enabled = _alpha - Math.PI * 2 * _n <= double.Epsilon;
            if (!timer1.Enabled)
            {
                _alpha = 0;
            }
            pictureBox1.Invalidate();
        }

        private PointF ArchimedeanSpiral(float angle)
        {
            return new PointF((float)(_r * angle * Math.Cos(angle)), (float)(_r * angle * Math.Sin(angle)));
        }

        //Гиперболическая спираль
        private PointF HyperbolicSpiral(float angle)
        {
            if (angle == 0)
            {
                angle += 0.2f;
            }
            return new PointF((float)(10 * _r * Math.Cos(angle) / angle), (float)(10 * _r * Math.Sin(angle) / angle));
        }

        //Спираль Ферма
        private PointF FermatSpiral(float angle)
        {
            return new PointF((float)(Math.Sqrt(angle) * Math.Cos(angle)), (float)(Math.Sqrt(angle) * Math.Sin(angle)));
        }

        //Логарифмическая спираль
        private PointF LogarithmicSpiral(float angle)
        {
            return new PointF((float)(0.1 * Math.Exp(angle * .5) * Math.Cos(angle)), (float)(0.1 * Math.Exp(angle * .5) * Math.Sin(angle)));
        }

        private void archRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!archRadioButton.Checked) return;
            _spiral = ArchimedeanSpiral;
            _n = 3;
            Reset();
        }

        private void Reset()
        {
            _points.Clear();
            _scale = 1;
            Invalidate();
            _alpha = 0;
            timer1.Enabled = true;
        }

        private void hyperbRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!hyperbRadioButton.Checked) return;
            _spiral = HyperbolicSpiral;
            _n = 50;
            Reset();
            _scale = 10;
        }

        private void fermatRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!fermatRadioButton.Checked) return;
            _spiral = FermatSpiral;
            _n = 3;
            Reset();
            _scale = 25f;
        }

        private void logariphRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!logariphRadioButton.Checked) return;
            _spiral = LogarithmicSpiral;
            _n = 2;
            Reset();
            _scale = 10f;
        }
    }
}
