using System;
using System.Text;
using System.Windows.Forms;

namespace RichTextBoxSyncSelection {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			ASCIIRtb.TextChanged += ASCIIRtb_TextChanged;
			ASCIIRtb.SelectionChanged += ASCIIRtb_SelectionChanged;
			HexRtb.SelectionChanged += HexRtb_SelectionChanged;
			HexRtb.Text = StringToHex(ASCIIRtb.Text);
		}

		//Выбор текста в поле с hex-текстом
		void HexRtb_SelectionChanged(object sender, EventArgs e) {
			ASCIIRtb.SelectionChanged -= ASCIIRtb_SelectionChanged;
			int start = HexRtb.SelectionStart;//Начало выделения
			int len = HexRtb.SelectionLength;//Длина выделения
			if (len == 0) {
				string text=(sender as RichTextBox).Text;
				//Курсор  не в начале hex-текста или не слева от hex-числа
				if (!(start == 0 || text[start - 1] == ' '))
					//Курсор справа от от hex-числа
					if ((sender as RichTextBox).Text[start] == ' ')
						start -= 2;
					else//курсор посередине hex-числа
						start--;
					len = 3;
				}
			ASCIIRtb.Select(start / 3, len / 3);
			ASCIIRtb.SelectionChanged += ASCIIRtb_SelectionChanged;
		}

		//Выделение текста в поле с обычным текстом
		void ASCIIRtb_SelectionChanged(object sender, EventArgs e) {
			HexRtb.SelectionChanged -= HexRtb_SelectionChanged;
			int start = ASCIIRtb.SelectionStart;//Начало выделения
			int len = ASCIIRtb.SelectionLength;//Длина выделения
			//Если выделения нет, то в hex выделим байт, соответствующий символу справа от курсора.
			if (len == 0) len = 1;
			//Выделения текста в hex
			HexRtb.Select(start * 3, len * 3 - 1);
			HexRtb.SelectionChanged += HexRtb_SelectionChanged;
		}

		private void ASCIIRtb_TextChanged(object sender, EventArgs e) {
			HexRtb.Text = StringToHex((sender as RichTextBox).Text);
		}

		//Перевод текстовой строки в шестнадцатиричную. Каждый символ — один байт. Байты разделены пробелами
		private string StringToHex(string text) {
			byte[] ar = Encoding.ASCII.GetBytes(text.ToCharArray());
			return BitConverter.ToString(ar).Replace("-", " ");
		}

		private void compareToolStripMenuItem_Click(object sender, EventArgs e) {
			CompareTexts f2 = new CompareTexts();
			f2.SetText(ASCIIRtb.Text);
			f2.Show();
		}
	}
}
