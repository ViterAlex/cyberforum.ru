using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using ColorUITypeEditor.Annotations;
using Cyotek.Windows.Forms;

namespace ColorUITypeEditor
{
    public partial class ColorEditor : UserControl, INotifyPropertyChanged
    {
        public ColorEditor()
        {
            InitializeComponent();
            prevColorPanel.DataBindings.Add("BackColor", this, "PrevColor");
            currColorPanel.DataBindings.Add("BackColor", this, "NewColor");
        }

        public ColorEditor(Color prevColor)
            : this()
        {
            _prevColor = prevColor;
            _newColor = prevColor;
            colorEditorManager1.Color = prevColor;
            colorEditor1.Color = prevColor;
            colorWheel1.Color = prevColor;
        }

        private Color _prevColor;

        [Editor(typeof(ColorUIEditor),typeof(UITypeEditor))]
        public Color PrevColor
        {
            get { return _prevColor; }
            set
            {
                if (value.Equals(_prevColor)) return;
                _prevColor = value;
                OnPropertyChanged();
            }
        }

        private Color _newColor;

        [Editor(typeof(ColorUIEditor),typeof(UITypeEditor))]
        public Color NewColor
        {
            get { return _newColor; }
            set
            {
                if (value.Equals(_newColor)) return;
                _newColor = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void colorEditorManager1_ColorChanged(object sender, EventArgs e)
        {
            NewColor = colorEditorManager1.Color;
        }
    }
}
