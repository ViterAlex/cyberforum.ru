using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FlowersBouquet
{
    public partial class MainForm : Form
    {
        //Точки спиралей, которые будут образовывать цветок
        private List<PointF> _points = new List<PointF>();

        //Количество спиралей вокруг центра
        private const int COUNT = 10;

        public MainForm()
        {
            InitializeComponent();
            panel1.Paint += Panel1_Paint;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_points == null || _points.Count < 3)
            {
                return;
            }
            var ar = _points.ToArray();
            //Переносим начало координат в центр
            e.Graphics.TranslateTransform(panel1.ClientSize.Width / 2f, panel1.ClientSize.Height / 2f);
            //Увеличиваем в два раза, чтобы центральная спираль была побольше
            e.Graphics.ScaleTransform(2, 2);
            //Рисуем центральную спираль
            e.Graphics.DrawCurve(Pens.Blue, ar);
            //Сбрасываем масшаб
            e.Graphics.ScaleTransform(0.5f, 0.5f);
            //Рисуем спирали вокруг
            for (var i = 0; i < COUNT; i++)
            {
                //Смещаемся на 45 пикселей вправо
                e.Graphics.TranslateTransform(45, 0);
                //рисуем спираль
                e.Graphics.DrawCurve(Pens.Green, ar);
                //возвращаемся в центр формы
                e.Graphics.TranslateTransform(-45, 0);
                //поворачиваем для рисования следующей спирали
                e.Graphics.RotateTransform(360f / COUNT);
            }
        }

        float _a;
        float _b;
        float _lambda;

        private void DrawFlower()
        {
            _a = (float)aNumericUpDown.Value;
            _b = (float)bNumericUpDown.Value;
            _lambda = (float)lambdaNumericUpDown.Value;
            _points = GetCurve();
            panel1.Invalidate();
        }

        //Функция для получения точек спирали.
        private List<PointF> GetCurve()
        {
            var list = new List<PointF>();
            //1080=360×3 три оборота спирали
            for (int j = 0; j < 1080; j += 6)
            {
                list.Add(SpiralPoint((float)((j - 1) * Math.PI / 180)));
            }
            return list;
        }

        //Точка на спирали при определённом угле
        private PointF SpiralPoint(float angle)
        {
            float x = (float)((_a + _b) * Math.Cos(angle) - _lambda * _a * Math.Cos((_a + _b) * angle / _a));
            float y = (float)((_a + _b) * Math.Sin(angle) - _lambda * _a * Math.Sin((_a + _b) * angle / _a));
            return new PointF(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawFlower();
        }

        private int prevLen;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (prevLen < richTextBox1.TextLength)
            {
                Debug.WriteLine("Добавление");
            }
            else if (prevLen > richTextBox1.TextLength)
            {
                Debug.WriteLine("Удаление");
            }
            else
            {
                Debug.WriteLine("Вставка");
            }
            prevLen = richTextBox1.TextLength;
        }
    }
}
