using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PortraitVote
{
    public partial class PortraitVote : UserControl
    {
        public enum ChoiseEnum
        {
            Unset,
            Like,
            Dislike
        }

        [Category("Портрет")]
        public Color ChoiseColor { get; set; }

        private ChoiseEnum _choise;

        [Category("Портрет")]
        public ChoiseEnum Choise
        {
            get { return _choise; }
            set
            {
                if (_choise == value) return;
                _choise = value;
                ChangeChoise();
            }
        }


        [Category("Портрет")]
        public bool FirstEnabled
        {
            get { return firstButton.Enabled; }
            set { firstButton.Enabled = value; }
        }


        [Category("Портрет")]
        public bool SecondEnabled
        {
            get { return secondButton.Enabled; }
            set { secondButton.Enabled = value; }
        }


        [Category("Портрет")]
        public Image Image
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public int Number { get; set; }
        private Action _secondAction;

        public event EventHandler ChoiseChanged;

        private void ChangeChoise()
        {
            switch (Choise)
            {
                case ChoiseEnum.Unset:
                    _secondAction = Dislike;
                    firstButton.Text = "Нравится";
                    secondButton.Text = "Не нравится";
                    firstButton.ForeColor = SystemColors.WindowText;
                    firstButton.Enabled = true;
                    secondButton.Enabled = true;
                    ChoiseColor = SystemColors.Control;
                    break;
                case ChoiseEnum.Like:
                    _secondAction = CancelChoise;
                    firstButton.Text = "Нравится";
                    secondButton.Text = "Отменить выбор";
                    firstButton.ForeColor = Color.Beige;
                    firstButton.Enabled = false;
                    secondButton.Enabled = true;
                    ChoiseColor = Color.Green;
                    break;
                case ChoiseEnum.Dislike:
                    _secondAction = CancelChoise;
                    firstButton.Text = "Не нравится";
                    secondButton.Text = "Отменить выбор";
                    firstButton.ForeColor = Color.Beige;
                    firstButton.Enabled = false;
                    secondButton.Enabled = true;
                    ChoiseColor = Color.Red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            firstButton.BackColor = ChoiseColor;
            Invalidate();
            OnChoiseChanged();
        }


        public PortraitVote()
        {
            InitializeComponent();
            tableLayoutPanel1.BackColor = Color.Transparent;
            FirstEnabled = true;
            SecondEnabled = true;
            firstButton.Text = "Нравится";
            secondButton.Text = "Не нравится";
            _secondAction = Dislike;
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            Like();
        }

        private void secondButton_Click(object sender, EventArgs e)
        {
            _secondAction?.Invoke();
        }

        private void Like()
        {
            Choise = ChoiseEnum.Like;
        }

        private void Dislike()
        {
            Choise = ChoiseEnum.Dislike;
        }

        private void CancelChoise()
        {
            Choise = ChoiseEnum.Unset;
        }

        #region Overrides of Control

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                var heights = tableLayoutPanel1.GetRowHeights();
                var h = heights[0] + heights[1];
                using (Pen pen = new Pen(ChoiseColor) { Alignment = PenAlignment.Inset })
                {
                    e.Graphics.DrawRectangle(pen,
                        new Rectangle(tableLayoutPanel1.Location, new Size(ClientSize.Width - 1, h - 1)));
                }
                Debug.WriteLine("Drawn");
            }
            catch (Exception)
            {
            }
        }

        public PortraitVote(Image image)
            : this()
        {
            Image = image;
        }

        public PortraitVote(int number)
            : this()
        {
            Number = number;
            using (var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
            {
                var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (var g = Graphics.FromImage(bmp))
                {
                    TextRenderer.DrawText(g, number.ToString(), new Font(Font.FontFamily, bmp.Height * 0.6f), rect, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                Image = (Image)bmp.Clone();
            }
        }
        #endregion

        protected virtual void OnChoiseChanged()
        {
            ChoiseChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}