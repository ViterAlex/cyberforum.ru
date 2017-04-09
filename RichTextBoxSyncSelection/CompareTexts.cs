using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RichTextBoxSyncSelection {
	public partial class CompareTexts : Form {
		public CompareTexts() {
			InitializeComponent();
		}
		public void SetText(string text) {
			richTextBox1.Text = text;
			richTextBox2.Text = text;
		}

		private void CompareButton_Click(object sender, EventArgs e) {
			//CompareTexts(richTextBox1.Text, richTextBox2.Text);
			Dictionary<int, string> dic = C1ompareTexts(richTextBox1.Text, richTextBox2.Text);
			foreach (KeyValuePair<int,string> item in dic) {
				richTextBox2.Select(item.Key, item.Value.Length);
				richTextBox2.SelectionColor = Color.Red;
			}
		}
		private Dictionary<int, string> C1ompareTexts(string text1, string text2) {
			Dictionary<int, string> dic = new Dictionary<int, string>();
			char[] arText1 = text1.ToCharArray();
			char[] arText2 = text2.ToCharArray();
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < arText1.Length; i++) {
				if (arText1[i] != arText2[i]) {
					dic.Add(i, "");
					sb.Clear();
					while (arText1[i] != arText2[i]) {
						sb.Append(arText2[i]);
						i++;
					}
					dic[dic.Count - 1] = sb.ToString();
				}
			}
			return dic;
		}
	}
}
