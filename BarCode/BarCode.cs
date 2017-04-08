using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1 {
	internal static class BarCode {
		const float TOTAL_WIDTH = 1.2343f;//31,35 мм
		const float TOTAL_HEIGHT = 1.0209F;//25,93 мм
		const float LINE_LEN = 0.8996f;//22,85 мм
		const float SPACE_UP_DOWN = 0.013f;//0,33 мм
		const float SPACE_LEFT = 0.1429f;//3,63 мм
		const float SPACE_RIGHT = 0.0909f;//2,31 мм
		const float SEPARATOR_LINE_LEN = 0.9646f;//24,5 мм
		const float TEXT_HEIGHT = 0.1083f;//25,91 - 23,16 = 2,75 мм
		const float TEXT_POS = 0.9118f;//23,16 мм

		//Коды для левой шестёрки
		static uint[,] Lcode = new uint[10, 7]{
			{0,0,0,1,1,0,1},
			{0,0,1,1,0,0,1},
			{0,0,1,0,0,1,1},
			{0,1,1,1,1,0,1},
			{0,1,0,0,0,1,1},
			{0,1,1,0,0,0,1},
			{0,1,0,1,1,1,1},
			{0,1,1,1,0,1,1},
			{0,1,1,0,1,1,1},
			{0,0,0,1,0,1,1}
		};
		//Коды для правой шестёрки
		static uint[,] Rcode = new uint[10, 7]{
			{1,1,1,0,0,1,0},
			{1,1,0,0,1,1,0},
			{1,1,0,1,1,0,0},
			{1,0,0,0,0,1,0},
			{1,0,1,1,1,0,0},
			{1,0,0,1,1,1,0},
			{1,0,1,0,0,0,0},
			{1,0,0,0,1,0,0},
			{1,0,0,1,0,0,0},
			{1,1,1,0,1,0,0}
		};
		//Коды разделителей
		static uint[,] Divcode = new uint[3, 5] {
			{1,0,1,2,2},
			{0,1,0,1,0},
			{1,0,1,2,2}
		};

		static internal Bitmap DrawEAN13(string barCodeNum, float DPI = 300) {

			Bitmap barCodeBmp = new Bitmap((int)(TOTAL_WIDTH * DPI) + 1, (int)(TOTAL_HEIGHT * DPI) + 1);
			barCodeBmp.SetResolution(DPI, DPI);

			int w = (int)(barCodeBmp.Width + DPI * (SPACE_LEFT + SPACE_RIGHT)), h = (int)(barCodeBmp.Height + 2 * DPI * SPACE_UP_DOWN);
			Bitmap fullImage = new Bitmap(w, h);
			fullImage.SetResolution(DPI, DPI);

			Pen pen = new Pen(Color.White, TOTAL_WIDTH * DPI / 95f);
			float textSpace = 7f * pen.Width / 6f;
			PointF textPt = new PointF(0, TEXT_POS * DPI);//координаты текста
			Font f = new Font("Tahoma", TEXT_HEIGHT * 72f, FontStyle.Regular);

			using (Graphics g = Graphics.FromImage(barCodeBmp),
							g1 = Graphics.FromImage(fullImage)) {

				g.FillRectangle(Brushes.White, new Rectangle(0, 0, barCodeBmp.Width, barCodeBmp.Height));

				//Разделитель слева
				float x = pen.Width / 2, y = SEPARATOR_LINE_LEN * DPI;
				for (int i = 0; i < 3; i++, x += pen.Width) {
					pen.Color = Divcode[0, i] == 0 ? Color.White : Color.Black;
					g.DrawLine(pen, x, 0, x, y);
				}

				//Левая половина кода
				int n;
				y = LINE_LEN * DPI;
				for (int i = 0; i < 6; i++, textPt.X += textSpace) {
					textPt.X = x;
					g.DrawString(barCodeNum[i].ToString(), f, Brushes.Black, textPt);
					n = int.Parse(barCodeNum[i].ToString());
					for (int j = 0; j < Lcode.GetLength(1); j++, x += pen.Width) {
						pen.Color = Lcode[n, j] == 0 ? Color.White : Color.Black;
						g.DrawLine(pen, x, 0, x, y);
					}
				}

				//Разделитель по центру
				y = SEPARATOR_LINE_LEN * DPI;
				for (int i = 0; i < Divcode.GetLength(1); i++, x += pen.Width) {
					pen.Color = Divcode[1, i] == 0 ? Color.White : Color.Black;
					g.DrawLine(pen, x, 0, x, y);
				}

				//Правая половина кода
				y = LINE_LEN * DPI;
				for (int i = 6; i < barCodeNum.Length; i++, textPt.X += textSpace) {
					n = int.Parse(barCodeNum[i].ToString());
					textPt.X = x;
					g.DrawString(barCodeNum[i].ToString(), f, Brushes.Black, textPt);
					for (int j = 0; j < Rcode.GetLength(1); j++, x += pen.Width) {
						pen.Color = Rcode[n, j] == 0 ? Color.White : Color.Black;
						g.DrawLine(pen, x, 0, x, y);
					}
				}
				//Разделитель справа
				y = SEPARATOR_LINE_LEN * DPI;
				for (int i = 0; i < 3; i++, x += pen.Width) {
					pen.Color = Divcode[2, i] == 0 ? Color.White : Color.Black;
					g.DrawLine(pen, x, 0, x, y);
				}
				g1.FillRectangle(Brushes.White, 0, 0, fullImage.Width, fullImage.Height);
				g1.DrawImage(barCodeBmp, DPI * SPACE_LEFT, DPI * SPACE_UP_DOWN);
			}

			return fullImage;
			//return barCodeBmp;
		}

		static internal void SaveBarCodeToFile(string path, string barCodeNum) {
			Bitmap bmp = DrawEAN13(barCodeNum);
			bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
			bmp.Dispose();
		}

		static internal bool CheckControlNumber(string barCodeNum) {
			int oddSum = 0;

			for (int i = 0; i < barCodeNum.Length - 1; i += 2) {
				oddSum += int.Parse(barCodeNum[i].ToString());
			}

			oddSum *= 3;

			for (int i = 1; i < barCodeNum.Length - 1; i += 2) {
				oddSum += int.Parse(barCodeNum[i].ToString());
			}

			int last = 10 - (oddSum % 10);

			return (last % 10) == int.Parse(barCodeNum[barCodeNum.Length - 1].ToString());
		}

	}
}
