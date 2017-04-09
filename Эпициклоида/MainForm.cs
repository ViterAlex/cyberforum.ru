using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Epicycloid {
	public partial class MainForm : Form {

		GraphicsPath wheel;
		float R, r;
		Timer tmr = new Timer() { Interval = 100 };
		float phi = 10;//Угол поворота в градусах
		PointF[] points;
		const float PI = (float)Math.PI;

		System.Collections.Hashtable ht = new System.Collections.Hashtable();
		public MainForm() {
			InitializeComponent();
			r = 40f;
			R = Math.Min(pictureBox1.ClientSize.Height, pictureBox1.ClientSize.Width) / 2 - 2 * r;
			pictureBox1.Paint += pictureBox1_Paint;
			tmr.Tick += tmr_Tick;
			Init();
			//tmr.Start();
			FillPropertyGrid();
		}
		float t = 0.01f;
		void NextPoint() {
			//Условие прекращения работы таймера. Если разность координат последней и первой точки массива меньше 0,01
			if (points.Length>2 && (Math.Abs(points[0].X - points[points.Length - 1].X) <= 1e-2 && Math.Abs(points[0].Y - points[points.Length - 1].Y) < 1e-2))
				tmr.Enabled = false;
			float x = (float)((R + r) * Math.Cos(t) - r * Math.Cos((R + r) * t / r));
			float y = (float)((R + r) * Math.Sin(t) - r * Math.Sin((R + r) * t / r));
			Array.Resize<PointF>(ref points, points.Length + 1);
			points[points.Length - 1] = new PointF(x, y);
			t += 1e-1f;
		}
		void tmr_Tick(object sender, EventArgs e) {
			//RotateAndMove();
			//Array.Resize<PointF>(ref points, points.Length + 1);
			//points[points.Length - 1] = wheel.GetLastPoint();
			//if (Math.Abs(points[0].X - points[points.Length - 1].X) <= 1e-2 && Math.Abs(points[0].Y - points[points.Length - 1].Y) < 1e-2)
			//	tmr.Enabled = false;
			//this.Text = points.Length.ToString();
			NextPoint();
			if (tmr.Enabled)
				pictureBox1.Invalidate();
			//ht["Таймер"] = tmr.Enabled;
		}


		void pictureBox1_Paint(object sender, PaintEventArgs e) {
			using (Pen pen = new Pen(Color.Blue, 2) { Alignment = PenAlignment.Inset, LineJoin = LineJoin.Bevel }) {
				e.Graphics.TranslateTransform(pictureBox1.ClientSize.Width / 2f, pictureBox1.ClientSize.Height / 2f);
				//e.Graphics.DrawEllipse(pen, RectangleF.FromLTRB(-R, -R, R, R));
				//pen.Color = Color.Black;
				//e.Graphics.DrawPath(pen, wheel);
				if (tmr.Enabled && points.Length > 2) {
					pen.Color = Color.Red;
					//e.Graphics.DrawLines(pen, points);
					e.Graphics.DrawCurve(pen, points, 0.2f);
				}
			}
		}

		private void Init(bool startTimer = false) {
			tmr.Stop();
			if (wheel != null) {
				wheel.Dispose();
				wheel = null;
			}
			CreateWheel(r);
			using (Matrix m = new Matrix(1, 0, 0, 1, R, -r)) {
				RectangleF b = wheel.GetBounds();
				//Поворот колеса в исходное положение, чтобы точка на ободе совпадала с точкой касания к окружности качения
				//m.RotateAt((float)(Math.Asin(radius / (R + radius)) * 180 / PI), new PointF(b.Left + b.Width / 2, b.Top + b.Height / 2));
				wheel.Transform(m);
			}
			points = new PointF[1] { wheel.GetLastPoint() };
			tmr.Enabled = startTimer;
		}

		private void CreateWheel(float radius) {
			wheel = new GraphicsPath();
			//обод колеса
			wheel.AddEllipse(RectangleF.FromLTRB(0, 0, 2 * radius, 2 * radius));
			//Точка на колесе
			wheel.AddEllipse(RectangleF.FromLTRB(-1.5f, radius - 1.5f, 1.5f, radius + 1.5f));
			//спица колеса
			wheel.AddLine(radius, radius, 0, radius);
		}


		private void RotateAndMove() {
			using (Matrix m = new Matrix(1, 0, 0, 1, 0, 0)) {
				//Вращение относительно центра окружности качения
				m.RotateAt(phi * r / R, new PointF());
				RectangleF b = wheel.GetBounds();
				//Вращение относительно центра колеса
				m.RotateAt(phi, new PointF(b.Left + b.Width / 2, b.Top + b.Height / 2));
				wheel.Transform(m);
			}
		}

		private void FillPropertyGrid() {
			ht.Add("Интервал таймера", tmr.Interval);
			ht.Add("Радиус окружности качения", R);
			ht.Add("Радиус колеса", r);
			ht.Add("Угол поворота", phi);
			ht.Add("Таймер", tmr.Enabled);
			propertyGrid1.SelectedObject = new DictionaryPropertyGridAdapter(ht);
		}


		private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
			switch (e.ChangedItem.Label) {
				case "Интервал таймера":
					tmr.Interval = Convert.ToInt32(e.ChangedItem.Value);
					break;
				case "Радиус окружности качения":
					R = (float)e.ChangedItem.Value;
					Init(tmr.Enabled);
					break;
				case "Радиус колеса":
					r = (float)e.ChangedItem.Value;
					Init(tmr.Enabled);
					break;
				case "Угол поворота":
					phi = (float)e.ChangedItem.Value;
					Init(tmr.Enabled);
					break;
				case "Таймер":
					tmr.Enabled = (bool)e.ChangedItem.Value;
					break;
				default:
					break;
			}
		}
	}
}
