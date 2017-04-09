using System;
using System.Windows.Forms;

namespace RadialDigitsExample
{
    public class BitClickedEventArgs : EventArgs
    {
        public byte Number { get; set; }
        public int Bit { get; set; }
        public int BitValue { get; set; }
        public MouseEventArgs MouseEventArgs { get; set; }

        public BitClickedEventArgs(byte number, int bit, int bitValue, MouseEventArgs e)
        {
            Number = number;
            Bit = bit;
            BitValue = bitValue;
            MouseEventArgs = e;
        }
    }
}