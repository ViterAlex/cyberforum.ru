using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace ColorUITypeEditor
{
    public class ColorUIEditor : System.Drawing.Design.ColorEditor
    {

        #region Overrides of UITypeEditor

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context == null || provider == null || value == null) return base.EditValue(context, provider, value);
            var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc == null) return base.EditValue(context, provider, value);
            var editor = new ColorEditor((Color)value);
            edSvc.DropDownControl(editor);
            value = editor.NewColor;
            return value;
        }

        #endregion
    }
}
