using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FigureInFigure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
dataGridView1.RowsAdded += (sender, args) =>
{
    dataGridView1.Rows[args.RowIndex].HeaderCell = new CheckBoxRowHeaderCell();
};
dataGridView1.TopLeftHeaderCell = new TopLeftCheckboxHeaderCell();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = Controls;
        }
    }
}
