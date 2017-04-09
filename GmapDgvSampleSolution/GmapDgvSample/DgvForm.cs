using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GmapDgvSample
{
    public partial class DgvForm : Form
    {
        public DgvForm()
        {
            InitializeComponent();
            //bindingSource1.DataSource = typeof(MapData);
            //dataGridView1.AutoGenerateColumns = true;
        }

        public event EventHandler ShowMapRequest;
        private void openDbButton_Click(object sender, EventArgs e)
        {
            this.mapDataTableAdapter.Fill(this.mapDbDataSet.MapData);
        }

        private void updateDbButton_Click(object sender, EventArgs e)
        {
            mapDataTableAdapter.Update(mapDbDataSet.MapData);
        }

        private void showMapButton_Click(object sender, EventArgs e)
        {
            var list = new List<MapData>();
            foreach (MapDbDataSet.MapDataRow row in mapDataTableAdapter.GetData().Rows)
            {
                list.Add(new MapData
                         {
                             Id = row.Id,
                             Lat = row.Lat,
                             Lon = row.Lon,
                             Name = row.Name
                         });
            }
            OnShowMapRequest(list);
        }

        protected virtual void OnShowMapRequest(List<MapData> list )
        {
            ShowMapRequest?.Invoke(list, EventArgs.Empty);
        }
    }
}
