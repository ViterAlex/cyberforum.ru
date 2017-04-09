using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using ColorUITypeEditor;
namespace RadialDigitsExample
{
    [DefaultEvent("BitClicked"), Designer(typeof(BitClickerDesigner))]
    public partial class BitClicker : UserControl
    {
        private List<byte> _values;
        /// <summary>Минимальный радиус радиус</summary>
        private float Rmin { get { return Math.Min(Width, Height) * 0.1f; } }
        /// <summary>Максимальный радиус</summary>
        private float Rmax { get { return Math.Min(Width, Height) * 0.9f / 2; } }
        /// <summary>Ширина кольцевого сегмента</summary>
        private float SegmentWidth { get { return (Rmax - Rmin) / 8; } }
        /// <summary>Угловая величина сегмента</summary>
        private float _anglePerNumber;
        /// <summary>Индекс выбранного номера</summary>
        private int _index;
        /// <summary>Контур сегмента под курсором</summary>
        private GraphicsPath _path;

        private Color _zero;

        /// <summary>Цвет бита 0</summary>
        [Category("Appearance"), Description("Цвет бита 0"), Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
        public Color Zero
        {
            get { return _zero; }
            set
            {
                _zero = value;
                Invalidate();
            }
        }

        private Color _one;

        /// <summary>Цвет бита 1</summary>
        [Category("Appearance"), Description("Цвет бита 1"), Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
        public Color One
        {
            get { return _one; }
            set
            {
                _one = value;
                Invalidate();
            }
        }

        private Color _grid;

        /// <summary>Цвет сетки</summary>
        [Category("Appearance"), Description("Цвет сетки"), Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
        public Color Grid
        {
            get { return _grid; }
            set
            {
                _grid = value;
                Invalidate();
            }
        }

        private Color _highlight;

        /// <summary>Цвет выделения</summary>
        [Category("Appearance"), Description("Цвет выделения"), Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
        public Color Highlight
        {
            get { return _highlight; }
            set
            {
                _highlight = value;
                Invalidate();
            }
        }

        /// <summary>Число под курсором</summary>
        [Browsable(false)]
        public byte CurrentNumber
        {
            get { return _index > -1 && _index < _values.Count ? _values[_index] : default(byte); }
        }

        private int _currentBitValue;

        /// <summary>Номер бита под курсором</summary>
        [Browsable(false)]
        public int CurrentBit { get; private set; }

        /// <summary>Значение бита под курсором</summary>
        [Browsable(false)]
        public int CurrentBitValue
        {
            get { return _currentBitValue; }
            set
            {
                if (_currentBitValue == value || _index == -1 || _index > _values.Count) return;
                _currentBitValue = value;
                _values[_index] ^= (byte)(1 << CurrentBit);
                Invalidate();
            }
        }

        /// <summary>Событие клика по биту</summary>
        public event EventHandler<BitClickedEventArgs> BitClicked;

        public BitClicker()
            : this(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 })
        {
        }

        public BitClicker(IEnumerable<byte> values)
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.SupportsTransparentBackColor, true);
            Load += (s, e) =>
            {
                SetDefaultColors();
                SetValues(values);
            };
        }

        private void SetDefaultColors()
        {
            Zero = Color.FromArgb(120, 170, 120, 57);
            One = Color.FromArgb(200, 200, 11, 59);
            Highlight = Color.DarkOrange;
            Grid = Color.FromArgb(200, 200, 200, 100);
        }

        public void SetValues(IEnumerable<byte> values)
        {
            _values = values.ToList();
            _anglePerNumber = 360f / _values.Count;
            Invalidate();
        }

        /// <summary>
        /// Функция для получения значения конкретного бита числа.
        /// </summary>
        /// <param name="b">Число</param>
        /// <param name="bitNumber">Номер бита</param>
        /// <returns>Возвращает true, если бит равен 1 и false, если равен 0.</returns>
        private static bool GetBit(byte b, int bitNumber)
        {
            return (b & (1 << bitNumber)) != 0;
        }

        /// <summary>
        /// Функция для проверки положения курсора над полем
        /// </summary>
        /// <param name="position">Положение курсора</param>
        /// <returns>Возвращает true, если курсор находится над сегментами и false, если в другом месте.</returns>
        private bool IsMouseOverField(System.Drawing.Point position)
        {
            position.Offset(-Width / 2, -Height / 2);
            Vector v = new Vector(position.X, position.Y);
            return v.Length < Rmax && v.Length > Rmin;
        }

        /// <summary>
        /// Функция получения контура сегмента для заданного бита
        /// </summary>
        /// <param name="bitNumber">Номер бита</param>
        /// <returns>Возвращает контур сегмента для заданного бита. Контур не развёрнут.</returns>
        private GraphicsPath GetPath(int bitNumber)
        {
            var gp = new GraphicsPath();
            using (Matrix translate = new Matrix(1, 0, 0, 1, Width / 2f, Height / 2f))
            {
                gp.Transform(translate);
                var x = Rmin + bitNumber * SegmentWidth;
                var x1 = x + SegmentWidth;
                gp.AddLine(x, 0, x1, 0);
                gp.AddArc(-x1, -x1, 2 * x1, 2 * x1, 0, _anglePerNumber);
                gp.AddArc(-x, -x, 2 * x, 2 * x, _anglePerNumber, -_anglePerNumber);
                gp.CloseAllFigures();
            }
            return gp;
        }

        #region Overrides of Control

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (IsMouseOverField(e.Location))
                OnBitClicked(new BitClickedEventArgs(CurrentNumber, CurrentBit, CurrentBitValue, e));
            base.OnMouseClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var matrix = new Matrix(1, 0, 0, 1, Width / 2f, Height / 2f);
            e.Graphics.Transform = matrix;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //Рисование битов числа
            using (var brush = new SolidBrush(Zero))
                foreach (var val in _values)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        var bit = GetBit(val, i);
                        brush.Color = bit ? One : Zero;
                        e.Graphics.FillPath(brush, GetPath(i));
                    }
                    e.Graphics.RotateTransform(_anglePerNumber);
                }
            matrix.Dispose();
            //Рисование сетки
            using (var pen = new Pen(Grid) { DashStyle = DashStyle.Dash })
            {
                //Радиальные линии
                for (int i = 0; i < _values.Count; i++)
                {
                    e.Graphics.DrawLine(pen, Rmin, 0, Rmax, 0);
                    e.Graphics.RotateTransform(_anglePerNumber);
                }
                //Концентрические линии
                for (int i = 0; i <= 8; i++)
                {
                    var x = Rmin + i * SegmentWidth;
                    e.Graphics.DrawEllipse(pen, -x, -x, 2 * x, 2 * x);
                }
            }
            if (_path == null || _index == -1) return;
            //Сегмент выделения
            e.Graphics.RotateTransform(_index * _anglePerNumber);
            e.Graphics.DrawPath(new Pen(Highlight, 2), _path);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var pt = e.Location;
            //Отсчёт от начала координат
            pt.Offset(-Width / 2, -Height / 2);
            //Если курсор вне поля
            if (!IsMouseOverField(e.Location))
            {
                Cursor = Cursors.Default;
                if (_path != null) _path.Dispose();
                _path = null;
                _index = -1;
                Invalidate();
                return;
            }
            Cursor = Cursors.Hand;
            //Вектор курсора
            Vector v1 = new Vector(pt.X, pt.Y);
            //вектор X
            Vector v2 = new Vector(1, 0);
            //Угол между векторами
            var angle = Vector.AngleBetween(v2, v1);
            //Приводим к [0°;360°]
            if (angle < 0) angle = 360 + angle;
            _index = (int)(angle / _anglePerNumber);

            //Вычисляем бит по удалению от центра
            var len = v1.Length - Rmin;
            CurrentBit = (int)(len / SegmentWidth);
            _currentBitValue = GetBit(CurrentNumber, CurrentBit) ? 1 : 0;
            _path = GetPath(CurrentBit);
            Invalidate();
            base.OnMouseMove(e);
        }
        #endregion


        protected virtual void OnBitClicked(BitClickedEventArgs e)
        {
            EventHandler<BitClickedEventArgs> handler = BitClicked;
            if (handler != null) handler(this, e);
        }
    }
}
