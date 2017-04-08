using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {

	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
			this.Paint += Form1_Paint;
			BarCode.SaveBarCodeToFile(@"C:\Users\Viter\Desktop\BarCode.jpg", "036000291452");
			this.Text = BarCode.CheckControlNumber("036000291452").ToString();
			
		}

		void Form1_Paint(object sender, PaintEventArgs e) {

			e.Graphics.DrawImage(BarCode.DrawEAN13("991234123458"), 0, 0);
			//Pen pen = new Pen(Color.Black, 0){ Alignment = System.Drawing.Drawing2D.PenAlignment.Left };
			//Pen pen1 = new Pen(Color.Red, 4) { Alignment = System.Drawing.Drawing2D.PenAlignment.Left };
			//e.Graphics.DrawLine(pen, this.Width / 2, 0, this.Width / 2, this.Height / 3);
			//e.Graphics.DrawLine(pen1, this.Width / 2, this.Height / 3, this.Width / 2, this.Height);
		}
	}
}
