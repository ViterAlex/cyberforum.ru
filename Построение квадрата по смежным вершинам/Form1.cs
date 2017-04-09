using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1 {
	public partial class Form1 : Form {
		bool OnDrawMode = false;
		Point pt;
		RectangleF rect;
		PointF[] points;
		public Form1() {
			InitializeComponent();
			this.Paint += Form1_Paint;
			this.MouseMove += Form1_MouseMove;
			this.MouseDown += Form1_MouseDown;
			this.MouseUp += Form1_MouseUp;
		}

		void Form1_MouseUp(object sender, MouseEventArgs e) {
			OnDrawMode = false;
			this.Invalidate();
			this.Paint -= Form1_Paint_Object;
			this.Paint += Form1_Paint;
		}

		void Form1_MouseDown(object sender, MouseEventArgs e) {
			OnDrawMode = true;
			pt = e.Location;
			this.Paint -= Form1_Paint;
			this.Paint += Form1_Paint_Object;
		}

		void Form1_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button != System.Windows.Forms.MouseButtons.Left) return;
			points = GetSquareVertices(pt, e.Location);
			this.Invalidate();
		}

		void Form1_Paint(object sender, PaintEventArgs e) {
			if (points == null) return;
			using (Pen pen = new Pen(Color.Black, 2) { Alignment = PenAlignment.Inset }) {
				e.Graphics.DrawPolygon(pen, points);
			}
		}
		void Form1_Paint_Object(object sender, PaintEventArgs e) {
			if (points == null) return;
			using (Pen pen = new Pen(Color.Blue, 1) { Alignment = PenAlignment.Inset, DashStyle=DashStyle.Dash }) {
				//e.Graphics.TranslateTransform(pt.X, pt.Y);
				e.Graphics.DrawPolygon(pen, points);
			}
		}
		/// <summary>
		/// Функция вычисления вершин квадрата по двум смежным вершинам
		/// </summary>
		/// <param name="pt1">Первая вершина</param>
		/// <param name="pt2">Вторая вершина</param>
		/// <returns>Функция возвращает массив точек, являющихся вершинами квадрата</returns>
		PointF[] GetSquareVertices(PointF pt1, PointF pt2) {
			using (System.Drawing.Drawing2D.GraphicsPath square = new System.Drawing.Drawing2D.GraphicsPath()) {
				//Разность координат (с учётом знака)
				float deltaX = pt1.X - pt2.X, deltaY = pt1.Y - pt2.Y;
				//Расстояние между точками
				float dist = (float)Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
				//Угол наклона стороны
				double angle;
				//Прямоугольник с вычисленной длиной стороны
				square.AddRectangle(RectangleF.FromLTRB(0, 0, dist, dist));
				//Вычисление угла поворота
				angle = Math.Atan(deltaY / deltaX);
				//Посколько функция Math.Atan возвращает угол в пределах [-π/2;π/2],
				//то нужно пересчитать его в пределы [0;2π]. Для этого смотрим знак разности координат.
				//Квадранты считаются с правого нижнего против часовой стрелки.
				//Первый квадрант [0;π/2) получается сам собой при вычислении арктангенса
				if ((deltaX > 0 && deltaY <= 0) || (deltaX >= 0 && deltaY > 0)) {//Второй квадрант [π/2;π) или третий квадрант [π;3π/2)
					angle = Math.PI + angle;
				}
				else if (deltaX <= 0 && deltaY > 0) {//Четвёртый квадрант [3π/2;2π)
					angle = 2 * Math.PI + angle;
				}
				//Перевод угла из радиан в градусы
				angle *= 180 / Math.PI;
				//Перенос начала координат в первую точку и
				//поворот прямоугольника на вычисленный угол относительно этого нового начала координат
				using (System.Drawing.Drawing2D.Matrix m = new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, pt.X, pt.Y)) {
					m.RotateAt((float)angle, new PointF());
					square.Transform(m);
				}
				return square.PathPoints;
			}
		}
	}
}
