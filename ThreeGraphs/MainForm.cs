using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ThreeGraphs
{
    public partial class MainForm : Form
    {
        #region Свойства

        private readonly List<List<PointF>> _points = new List<List<PointF>>
                                                    {
                                                        new List<PointF>(),
                                                        new List<PointF>(),
                                                        new List<PointF>()
                                                    };

        private Bitmap _bmp;

        private int _days;

        private float ScaleX => pictureBox1.Width / 60f;

        private int Days
        {
            set
            {
                _days = value;
                hScrollBar1.Visible = _days > 60;
                hScrollBar1.Maximum = value - (hScrollBar1.Visible ? 60 : 0);
            }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            DoubleBuffered = true;
            birthDateDtp.Value = DateTime.Now.AddMonths(-4);
            SizeChanged += (sender, args) => BuildGraph();
            Load += (sender, args) => BuildGraph();
        }

        private void birthDateDtp_ValueChanged(object sender, EventArgs e)
        {
            Days = (DateTime.Now - birthDateDtp.Value).Days;
            _bmp = null;
            GetPoints();
        }

        private void BuildGraph()
        {
            GetPoints();
            DrawImage();
            pictureBox1.Invalidate();
        }

        private void buildGraphButton_Click(object sender, EventArgs e)
        {
            BuildGraph();
        }

        /// <summary>
        ///     Рисование координатной оси
        /// </summary>
        private void DrawAxis(Graphics g)
        {
            g.TranslateTransform(0, g.ClipBounds.Height / 2);
            //ось
            var end = new PointF(g.ClipBounds.Right, 0);
            g.DrawLine(Color.Gray.Pen(1.5f), new PointF(), end);
            //Стрелка
            g.FillPath(Brushes.DarkGray, GetArrow(new Point(), end));
            //Подписи к оси
            for (var i = 5; i < 60; i += 5)
            {
                var text = string.Format("{0} дн.", i + hScrollBar1.Value);
                var size = g.MeasureString(text, Font);
                var pt = new PointF(i * ScaleX, 2);
                g.DrawLine(Color.DarkGray.Pen(), pt.X, pt.Y, pt.X, pt.Y - 5);
                pt.X -= size.Width / 2;
                g.DrawString(text, Font, SystemBrushes.ActiveCaptionText, pt);
            }
        }

        /// <summary>
        ///     Рисование графиков на битмап
        /// </summary>
        private void DrawImage()
        {
            if (_bmp != null)
            {
                _bmp.Dispose();
            }
            if (_days <= 0) return;
            _bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Максимальное значение в трёх графиках по Y
            var maxY = _points.Select(l => l.Max(p => p.Y)).Max();
            var minY = _points.Select(l => l.Min(p => p.Y)).Min();
            var scaleY = _bmp.Height * 0.95f / (maxY - minY);

            using (var g = Graphics.FromImage(_bmp))
            {
                g.TranslateTransform(-_points[0].Skip(hScrollBar1.Value).ToList()[0].X, _bmp.Height / 2f);
                g.ScaleTransform(1, scaleY);

                g.DrawCurve(Color.Red.Pen(1 / scaleY), _points[0].Skip(hScrollBar1.Value).ToArray());
                g.DrawCurve(Color.Green.Pen(1 / scaleY), _points[1].Skip(hScrollBar1.Value).ToArray());
                g.DrawCurve(Color.Blue.Pen(1 / scaleY), _points[2].Skip(hScrollBar1.Value).ToArray());
            }
        }

        /// <summary>
        ///     Функция
        /// </summary>
        private static float func(int i, int P)
        {
            return (float)Math.Sin(2 * Math.PI * i / P) * 100;
        }

        /// <summary>
        ///     Рисование отрезка со стрелкой
        /// </summary>
        /// <param name="start">Начало отрезка</param>
        /// <param name="end">Конец отрезка</param>
        /// <param name="h">Раствор стрелки</param>
        /// <param name="l">Длина стрелки</param>
        private static GraphicsPath GetArrow(PointF start, PointF end, float h = 7, float l = 30)
        {
            var gp = new GraphicsPath();
            //Вектора
            var v = new PointF(end.X - start.X, end.Y - start.Y);
            //Длина
            var len = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            //Нормированный вектор
            var norm = new PointF(v.X / len, v.Y / len);
            //Отступаем на длину стрелки
            var pt = new PointF(end.X - l * norm.X, end.Y - l * norm.Y);
            //Нормали для раствора стрелки
            var n1 = new PointF(-norm.Y * h / 2 + pt.X, norm.X * h / 2 + pt.Y);
            var n2 = new PointF(norm.Y * h / 2 + pt.X, -norm.X * h / 2 + pt.Y);
            gp.StartFigure();
            gp.AddLine(n1, end);
            gp.AddLine(end, n2);
            return gp;
        }

        /// <summary>
        ///     Точки графика
        /// </summary>
        private void GetPoints()
        {
            _points[0].Clear();
            _points[1].Clear();
            _points[2].Clear();
            for (var i = 0; i < _days; i++)
            {
                _points[0].Add(new PointF(i * ScaleX, func(i, 23)));
                _points[1].Add(new PointF(i * ScaleX, func(i, 28)));
                _points[2].Add(new PointF(i * ScaleX, func(i, 33)));
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_bmp == null)
                return;
            DrawImage();
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawImage(_bmp, 0, 0);
            DrawAxis(e.Graphics);
        }
    }
}