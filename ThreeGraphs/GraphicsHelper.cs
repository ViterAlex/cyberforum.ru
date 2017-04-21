using System.Drawing;

namespace ThreeGraphs
{
    static class GraphicsHelper
    {
        private static Pen _colorPen = new Pen(Color.Black);
        
        public static Pen Pen(this Color color, float width = 1f)
        {
            _colorPen.Color = color;
            _colorPen.Width = width;
            return _colorPen;
        }
    }
}
