using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pantone
{
    public static class Helper
    {
        public static SolidBrush Brush(this Color color)
        {
            return new SolidBrush(color);
        }

        public static void InvokeEx(this Control control, Action method)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method);
            }
            else
            {
                method();
            }
        }
    }
}
