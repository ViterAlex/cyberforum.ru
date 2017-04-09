using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PaintedObjectsMoving {
	class PaintedObject : ICloneable {
		private GraphicsPath path;

		public GraphicsPath Path {
			get { return path; }
			set { path = value; }
		}
		private Pen pen;

		public Pen @Pen {
			get { return pen; }
			set { pen = value; }
		}
		public PaintedObject() {
			this.path = new GraphicsPath();
			this.pen = Pens.Black;
		}

		public PaintedObject(Pen pen, GraphicsPath path) {
			this.path = path.Clone() as GraphicsPath;
			this.pen = pen.Clone() as Pen;
		}

		public void AddRectangle(Rectangle rect) {
			if (path == null)
				path = new GraphicsPath();
			path.AddRectangle(rect);
		}

		#region ICloneable Members

		public object Clone() {
			return new PaintedObject(this.Pen.Clone() as Pen, this.Path.Clone() as GraphicsPath);
		}

		#endregion
	}
}
