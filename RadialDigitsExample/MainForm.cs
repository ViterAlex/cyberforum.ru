using System;
using System.Windows.Forms;

namespace RadialDigitsExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var ar = new byte[(int)numericUpDown1.Value];
            Random rnd = new Random(DateTime.Now.Millisecond);
            rnd.NextBytes(ar);
            bitClicker1.SetValues(ar);
        }

        private byte _prevNum = default(byte);
        private int _prevBit = default(byte), _prevVal = default(byte);

        private void bitClicker1_MouseMove(object sender, MouseEventArgs e)
        {
            bool handled = _prevNum != bitClicker1.CurrentNumber;
            if (!handled)
                handled = _prevBit != bitClicker1.CurrentBit;
            if (!handled)
                handled = _prevVal != bitClicker1.CurrentBitValue;
            if (handled)
                toolTip1.SetToolTip(bitClicker1, string.Format("Число {0}.{3}Бит {1}.{3}Значение бита {2}{3}",
                    bitClicker1.CurrentNumber,
                    bitClicker1.CurrentBit,
                    bitClicker1.CurrentBitValue,
                    Environment.NewLine));
            _prevNum = bitClicker1.CurrentNumber;
            _prevBit = bitClicker1.CurrentBit;
            _prevVal = bitClicker1.CurrentBitValue;
        }

        private void bitClicker1_BitClicked(object sender, BitClickedEventArgs e)
        {
            var message = string.Format("Число:{0,5}\nБит:{1,5}\nЗначение бита:{2,5}", e.Number, e.Bit, e.BitValue);
            switch (e.MouseEventArgs.Button)
            {
                case MouseButtons.Left:
                    bitClicker1.CurrentBitValue = 1;
                    break;
                case MouseButtons.Right:
                    bitClicker1.CurrentBitValue = 0;
                    break;
            }
        }
    }
}
