using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace GmapDgvSample
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void openDgvButton_Click(object sender, EventArgs e)
        {
            var f = new DgvForm();
            f.ShowMapRequest -= F_ShowMapRequest;
            f.ShowMapRequest += F_ShowMapRequest;
            f.Show();
        }

        private void F_ShowMapRequest(object sender, EventArgs e)
        {
            var list = sender as List<MapData>;
            _markers.Markers.Clear();
            foreach (var mapData in list)
            {
                var marker = new GMarkerGoogle(new PointLatLng(mapData.Lat, mapData.Lon), GMarkerGoogleType.green_pushpin);
                marker.ToolTip = new GMapBaloonToolTip(marker);
                marker.ToolTipText = mapData.Name;
                _markers.Markers.Add(marker);
            }
            gMapControl1.Zoom = 13;
            gMapControl1.Position = new PointLatLng(list[list.Count / 2].Lat, list[list.Count / 2].Lon);
        }

        #region Overrides of Form

        private GMapOverlay _markers;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gMapControl1.ShowCenter = false;
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gMapControl1.Overlays.Add(_markers = new GMapOverlay("markers"));
        }

        #endregion
    }
}
