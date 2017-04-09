using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using ColorUITypeEditor;

namespace RadialDigitsExample
{
    internal class BitClickerActionList : DesignerActionList
    {
        private readonly BitClicker _bitClicker;

        public BitClickerActionList(IComponent component)
            : base(component)
        {
            _bitClicker = component as BitClicker;
        }

        public DockStyle Dock
        {
            get { return _bitClicker.Dock; }
            set { SetValue("Dock", value); }
        }
        [Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
        public Color Zero
        {
            get { return _bitClicker.Zero; }
            set { SetValue("Zero", value); }
        }

        [Editor(typeof(ColorUIEditor), typeof(UITypeEditor))]
        public Color One
        {
            get { return _bitClicker.One; }
            set { SetValue("One", value); }
        }

        [Editor(typeof(ColorUIEditor),typeof(UITypeEditor))]
        public Color Highlight
        {
            get { return _bitClicker.Highlight; }
            set { SetValue("Highlight", value); }
        }

        [Editor(typeof(ColorUIEditor),typeof(UITypeEditor))]
        public Color Grid
        {
            get { return _bitClicker.Grid; }
            set { SetValue("Grid", value); }
        }

        private void SetValue(string propName, object value)
        {
            var prop = TypeDescriptor.GetProperties(_bitClicker)[propName];
            prop.SetValue(_bitClicker, value);

        }

        private string GetDescription(string propName)
        {
            var prop = TypeDescriptor.GetProperties(_bitClicker)[propName];
            return prop.Description + ':';
        }

        #region Overrides of DesignerActionList

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection
            {
                new DesignerActionHeaderItem("Цвета", "Colors"),
                new DesignerActionHeaderItem("Расположение", "Layout"),
                new DesignerActionPropertyItem("Zero", GetDescription("Zero"), "Colors"),
                new DesignerActionPropertyItem("One", GetDescription("One"), "Colors"),
                new DesignerActionPropertyItem("Highlight", GetDescription("Highlight"), "Colors"),
                new DesignerActionPropertyItem("Grid", GetDescription("Grid"), "Colors"),
                new DesignerActionPropertyItem("Dock", "Пристыковка:", "Layout")
            };
            return items;
        }

        #endregion
    }
}
