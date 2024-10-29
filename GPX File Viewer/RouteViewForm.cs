using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;
using GPX_File_Viewer.GPX_Representations;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using GMap.NET.WindowsForms.Markers;
using static GMap.NET.Entity.OpenStreetMapGraphHopperGeocodeEntity;
//using GPX_File_Viewer.GMapCustomisations;

namespace GPX_File_Viewer
{

    public partial class RouteViewForm : Form
    {
        public List<GPX_File_Viewer.GPX_Representations.WayPoint> points1;
        public List<GPX_File_Viewer.GPX_Representations.WayPoint> points2;
        readonly GMapOverlay mapOverlay = new GMapOverlay("MyRoutes");
        readonly GMapOverlay mapOverlayMarkers = new GMapOverlay("MyMarkers");
        public RouteViewForm(List<GPX_File_Viewer.GPX_Representations.WayPoint> points, List<GPX_File_Viewer.GPX_Representations.WayPoint> secondPoints)
        {
            InitializeComponent();
            this.CenterToParent();
            comboBoxProvider.SelectedIndex = 0;
            comboBoxProvider.SelectedText = "Google Maps";
            SetTypes("Google");
            comboBoxMapType.SelectedIndex = 0;
            comboBoxMapType.SelectedText = "Standard";
            comboBoxMapType.Visible = true;
            labelMapType.Visible = true;
            points1 = points;
            points2 = secondPoints;
            try
            {
                System.Net.IPHostEntry e =
                     System.Net.Dns.GetHostEntry("www.google.com");
            }
            catch
            {
                gMapControl1.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection avaible, going to CacheOnly mode.",
                      "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }

            // config map
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.MaxZoom = 20;
            gMapControl1.MinZoom = 1;
            gMapControl1.Zoom = 5;
            gMapControl1.Position = new PointLatLng(51.79824, 0.31038);
            // get rid of the red cross in the centre of the map
            gMapControl1.ShowCenter = false;
            ClearRoutes();


            //AddRoute("First Route", points1, Color.Blue);
            //AddRoute("Second Route", points2, Color.Crimson);

            NewAddRoute("First Route", points1, Color.Blue);
            NewAddRoute("Second Route", points2, Color.Crimson);

            PlotElevation(points1);
            gMapControl1.MouseClick += GMapControl1_MouseClick;
            GMapOverlay pointOverlay = new GMapOverlay("PointToHightlight");
            gMapControl1.Overlays.Add(pointOverlay);


            gMapControl1.OnMarkerClick += new MarkerClick(GMapControl1_OnMarkerClick);


            


            //AddMarkerForDeb();
            /*
            gMapControl1.OnPositionChanged += new CurrentPositionChanged(gMapControl1_OnCurrentPositionChanged);
            gMapControl1.OnTileLoadStart += new TileLoadStart(gMapControl1_OnTileLoadStart);
            gMapControl1.OnTileLoadComplete += new
            TileLoadComplete(gMapControl1_OnTileLoadComplete);
            gMapControl1.OnMarkerClick += new MarkerClick(gMapControl1_OnMarkerClick);
            gMapControl1.OnMapZoomChanged += new MapZoomChanged(gMapControl1_OnMapZoomChanged);
            gMapControl1.OnMapTypeChanged += new MapTypeChanged(gMapControl1_OnMapTypeChanged);
            gMapControl1.MouseMove += new MouseEventHandler(gMapControl1_MouseMove);
            gMapControl1.MouseDown += new MouseEventHandler(gMapControl1_MouseDown);
            gMapControl1.MouseUp += new MouseEventHandler(gMapControl1_MouseUp);
            gMapControl1.OnMarkerEnter += new MarkerEnter(gMapControl1_OnMarkerEnter);
            gMapControl1.OnMarkerLeave += new MarkerLeave(gMapControl1_OnMarkerLeave);
            */
        }

        private void GMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            MessageBox.Show("Marker Click - " + item.Position.Lat + ", " + item.Position.Lng);
            MessageBox.Show($"Size {item.Size}");


        }

        private void GMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            return;
            string res = "";
            if (((GMapControl)sender).IsMouseOverMarker)
            {
                res = "Marker ";
            }

            if (((GMapControl)sender).IsMouseOverPolygon)
            {
                res += " Polygon ";
            }

            if (((GMapControl)sender).IsMouseOverRoute)
            {
                res += "Route ";
            }
            if (res == "")
            {
                res = "Nothing ";
            }
            MessageBox.Show( res + "was hit.");
        }

        private void GMapControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var result = gMapControl1.IsMouseOverRoute;
            // If the mouse if over a data point
            if (result)
            {
                SetPointMarked(new PointLatLng(e.X, e.Y));
            }
        }

        private void NewAddRoute(string routeName, List<GPX_File_Viewer.GPX_Representations.WayPoint> points, System.Drawing.Color color)
        {

            List<PointLatLng> routePoints = new List<PointLatLng>();
            foreach (GPX_File_Viewer.GPX_Representations.WayPoint point in points)
            {
                routePoints.Add(new PointLatLng(point.Latitude, point.Longitude));
                GMapMarker routeMarker = new GMarkerGoogle(new PointLatLng(point.Latitude, point.Longitude), GMarkerGoogleType.gray_small)
                {
                    Size = new Size(Width = 2, Height = 2),
                    //GMapMarker routeMarker = new CustomisedGMapMarker(new PointLatLng(point.Latitude, point.Longitude));
                    IsHitTestVisible = true
                };
                mapOverlayMarkers.Markers.Add(routeMarker);

                   // mapOverlay.Markers.Add(point);
            }
            GMapRoute route = new GMapRoute(routePoints, routeName)
            {
                Stroke = new Pen(color, 2),
                IsHitTestVisible = true
            };
            //mapOverlay.Routes.Add(route);
            //gMapControl1.Overlays.Add(mapOverlay);
            gMapControl1.Overlays.Add(mapOverlayMarkers);
            //gMapControl1.Overlays[1].IsVisibile = false;
            //gMapControl1.UpdateRouteLocalPosition(route);



            MessageBox.Show("Google says this route is " + route.Distance);


        }

        private void ChartElevation_MouseHover(object sender, System.EventArgs e)
        {
            MessageBox.Show("ChartElevationMouseHover");
        }

        private void SetPointMarked(PointLatLng pointLatLng)
        {
            GMapOverlay gMapOverlay = gMapControl1.Overlays.Where(x => x.Id == "PointToHightlight").Single();
            gMapOverlay.Clear();
            GMarkerGoogle marker = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.lightblue_dot);
            gMapOverlay.Markers.Add(marker);
            //gMapControl1.Overlays.Add(markers);
        }

        private void ClearRoutes()
        {
            mapOverlay.Routes.Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (gMapControl1.Zoom < gMapControl1.MaxZoom)
            {
                gMapControl1.Zoom++;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (gMapControl1.Zoom > gMapControl1.MinZoom)
            {
                gMapControl1.Zoom--;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxMapType.Items.Clear();
            if (comboBoxProvider.SelectedIndex == 0)
            {
                gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                SetTypes("Google");
                comboBoxMapType.SelectedText = "Standard";
                comboBoxMapType.Visible = true;
                labelMapType.Visible = true;
            }
            else if (comboBoxProvider.SelectedIndex == 1)
            {
                SetTypes("Open Cycle");
                comboBoxMapType.SelectedText = "Standard";
                comboBoxMapType.Visible = true;
                labelMapType.Visible = true;
                gMapControl1.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
            }
            else if (comboBoxProvider.SelectedIndex == 2)
            {
                comboBoxMapType.Visible = false;
                labelMapType.Visible = false;
                gMapControl1.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            }
            else
            {
                comboBoxMapType.Visible = false;
                labelMapType.Visible = false;
                gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            }
            gMapControl1.Refresh();
        }

        private void SetTypes(string provider)
        {
            comboBoxMapType.Items.Clear();
            comboBoxMapType.Text = "";
            if (provider == "Google")
            {
                comboBoxMapType.Items.Add("Standard");
                comboBoxMapType.Items.Add("Satellite");
                comboBoxMapType.Items.Add("Terrain");
            }
            else if (provider == "Open Cycle")
            {

                comboBoxMapType.Items.Add("Standard");
                comboBoxMapType.Items.Add("Landscape");
                comboBoxMapType.Items.Add("Transport");
            }
            else
            {

            }
        }

        private void ComboBoxMapType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxProvider.SelectedIndex == 0) // Google
            {
                if (comboBoxMapType.SelectedIndex == 1)
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                }
                else if (comboBoxMapType.SelectedIndex == 2)
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
                }
                else
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                }
            }
            else if (comboBoxProvider.SelectedIndex == 1)
            {
                if (comboBoxMapType.SelectedIndex == 1)
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.OpenCycleLandscapeMapProvider.Instance;
                }
                else if (comboBoxMapType.SelectedIndex == 2)
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.OpenCycleTransportMapProvider.Instance;
                }
                else
                {
                    gMapControl1.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
                }
            }
        }

        private void PlotElevation(List<WayPoint> wayPoints)
        {
            double maxDistance = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("Distance", typeof(double));
            dt.Columns.Add("Elevation", typeof(double));
            foreach (WayPoint wayPoint in wayPoints)
            {
                dt.Rows.Add(wayPoint.DistanceFromStart / 1000, wayPoint.Elevation);
                maxDistance = wayPoint.DistanceFromStart / 1000;
            }
            
            ChartElevation.DataSource = dt;
            ChartElevation.Series.Add("Route1");
            Series series = ChartElevation.Series["Series1"];
            ChartElevation.Series.Remove(series);
            ChartElevation.Series.SuspendUpdates();
            ChartElevation.Series["Route1"].XValueMember = "Distance";
            ChartElevation.Series["Route1"].YValueMembers = "Elevation";
            ChartElevation.Series["Route1"].ChartType = SeriesChartType.Line;
            ChartElevation.Series["Route1"].LegendText = "Route 1";
            ChartElevation.ChartAreas[0].AxisY.LabelStyle.Format = "";
            ChartElevation.BackColor = Color.LightGray;
            ChartElevation.ChartAreas[0].AxisY.LabelStyle.Interval = 100;
            ChartElevation.ChartAreas[0].AxisX.LabelStyle.Interval = 100;
            ChartElevation.ChartAreas[0].AxisX.Title = "KM";
            ChartElevation.ChartAreas[0].AxisY.Title = "Elevation";
            ChartElevation.ChartAreas[0].AxisX.RoundAxisValues();
            ChartElevation.ChartAreas[0].AxisX.Minimum = 0;
            ChartElevation.ChartAreas[0].AxisX.Maximum = maxDistance;
            ChartElevation.Series["Route1"].Color = Color.DarkBlue;
            ChartElevation.Series.ResumeUpdates();
            //ChartElevation.Series["Series1"].Label = "Label";
            ChartElevation.Enabled = true;
            
        }


        private void ChartElevation_Click(object sender, MouseEventArgs e)
        {
            _ = GetPointAtMouse(this.ChartElevation, e);
        }

        public static DataPoint GetPointAtMouse(Chart c, MouseEventArgs e)
        {
            var result = c.HitTest(e.X, e.Y);
            // If the mouse if over a data point
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                // Find selected data point
                var point = c.Series[0].Points[result.PointIndex];
                return point;
            }
            return null;
        }

        private void ChartElevation_Click(object sender, EventArgs e)
        {

        }
    }
}
