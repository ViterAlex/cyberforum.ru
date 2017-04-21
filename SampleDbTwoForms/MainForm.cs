using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static WindowsFormsApplication1.Program;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            mapDataBindingNavigator.BindingSource = SharedMapBindingSource;
            mapDataDataGridView.DataSource = SharedMapBindingSource;
            //mapDataBindingNavigator.
        }

        private void mapDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            SharedAdapterManager.UpdateAll(SharedMapDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SharedMapDataTableAdapter.Fill(SharedMapDataSet.MapData);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new SecondForm().Show();
        }
    }
}
