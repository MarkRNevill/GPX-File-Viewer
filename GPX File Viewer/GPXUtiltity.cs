using GPX_File_Viewer.GPX_Representations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GPX_File_Viewer
{
    public partial class GPXUtiltity : Form
    {
        Track track;
        WayPoint lastPoint;
        readonly List<WayPoint> NewTrackPoints = new List<WayPoint>();
        readonly List<WayPoint> OriginalTrackPoints = new List<WayPoint>();
        readonly DataTable resultsTable = new DataTable();
        bool retainElevation = true;
        bool retainCustom = false;
        public GPXUtiltity()
        {
            InitializeComponent();
            this.CenterToScreen();
            SetVisibility(false);
            ShowCompressionOptions(false);
        }
        private void ResetTrack(TrackFile track)
        {
            if (track == TrackFile.File1)
            {
                OriginalTrackPoints.Clear();
            }
            if (track == TrackFile.File2)
            {
                NewTrackPoints.Clear();
            }
        }
        private void ButtonSelectFile_Click(object sender, EventArgs e)
        {
            // As we are selecting a new file, reset all the track variables.
            ResetTrack(TrackFile.File1);
            // Set the necessary visibility.
            SetVisibility(false);
            string fileName;
            // Ask for the file to be processed.
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select the GPX file to be processed.",
                Filter = "GPX files (*.gpx)|*.gpx"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            else
                return;
            double totalDistance = 0;
            double totalPoints = 0;
            TrackHelper.TrackOne = XMLHelper.LoadTrackFromFile(fileName);
            track = TrackHelper.TrackOne;
            int counter = 0;
            foreach (TrackSegment segment in track.TrackSegments)
            {
                foreach (WayPoint point in segment.TrackPoints)
                {
                    totalPoints++;
                    OriginalTrackPoints.Add(point);
                    if (counter > 0)
                    {
                        double distance = GPXCalculationsHelper.GetMetresBetweenPoints(point, lastPoint);
                        lastPoint = point;
                        totalDistance += distance;
                        point.DistanceFromStart = totalDistance;
                        point.CurrentSpeed = GPXCalculationsHelper.GetSpeedBetweenPoints(point, lastPoint, UnitsVelocity.Kmph);
                    }
                    else
                    {
                        lastPoint = point;
                    }
                    counter++;
                }
            }
            resultsTable.Rows.Clear();
            if (!resultsTable.Columns.Contains("Property"))
            {
                resultsTable.Columns.Add("Property");
                
                resultsTable.Columns.Add("Value");
                resultsTable.Columns["Value"].Caption = "File 1";
                resultsTable.PrimaryKey = new DataColumn[] { resultsTable.Columns["Property"] };
            }
            DataRow dataRow;
            dataRow = resultsTable.NewRow();
            dataRow["Property"] = $"Source file";
            dataRow["Value"] = fileName;
            resultsTable.Rows.Add(dataRow);
            dataRow = resultsTable.NewRow();
            dataRow["Property"] = $"Track distance";
            dataRow["Value"] = $"{totalDistance / 1000:n3}km";
            resultsTable.Rows.Add(dataRow);
            dataRow = resultsTable.NewRow();
            dataRow["Property"] = $"Track points";
            dataRow["Value"] = $"{totalPoints} points";
            resultsTable.Rows.Add(dataRow);
            dataGridViewStats.DataSource = resultsTable;
            SetVisibility(true);
        }


        private void SetVisibility(bool IsVisible)
        {
            buttonOpenMap.Visible = (IsVisible && track.TrackSegments.Count > 0);
            buttonCompress.Visible = (IsVisible && track.TrackSegments.Count > 0);
            buttonSelectFile2.Visible = (IsVisible && track.TrackSegments.Count > 0);
            buttonClear.Visible = (IsVisible && track.TrackSegments.Count > 0);
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "gpx files (*.gpx)|*.gpx",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    Track newTrack = new Track("Revised Track", "Revised Track");
                    newTrack.TrackSegments.Add(new TrackSegment(1));
                    newTrack.TrackSegments[0].TrackPoints = NewTrackPoints;
                    GPXFormatWriteHomespun homespunGPXWriter = new GPXFormatWriteHomespun(saveFileDialog1.FileName, newTrack);
                    bool result = homespunGPXWriter.Write(retainElevation, retainCustom);
                    if (result == true)
                    {
                        MessageBox.Show("File saved correctly.");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong with writing the file.");
                    }
                    UpdateStatsFileName(saveFileDialog1.FileName);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Saving encountered an unexpected error: {ex.Message} : {ex.StackTrace}");
            }              
        }

        private void ButtonMap_Click(object sender, EventArgs e)
        {
            if (NetConnectivityHelper.CheckForInternetConnection() == true)
            {
                RouteViewForm rvf = new RouteViewForm(TrackHelper.TrackOnePoints(), TrackHelper.TrackTwoPoints())
                {
                    Owner = this
                };
                rvf.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Unable to detect an internet connection. Please check your internet connectivity.  This feature requires a working connection to the internet in order to use server based mapping features.");
            }
        }

        private void ButtonCompress_Click(object sender, EventArgs e)
        {
            CompressionOptions c = new CompressionOptions
            {
                compressionDelegate = SetCompressionOptions,
                Owner = this
            };
            DialogResult result = c.ShowDialog();
        }

        private void ShowCompressionOptions(bool makeVisible)
        {
            buttonSaveCompressedFile.Visible = makeVisible;           
        }
        private void SetCompressionOptions(CompressionArguments args)
        {
            bool ok = CompressTrack(args);
            ShowCompressionOptions(true);
        }

        public bool CompressTrack(CompressionArguments args)
        {
            retainCustom = args.RetainCustomData;
            retainElevation = args.RetainElevation;
            ResetTrack(TrackFile.File2);
            NewTrackPoints.Clear();
            bool result = false;
            try
            {
                if (track.TrackSegments.Count == 0 )
                {
                    return false;
                }                           
                double totalDistance = 0;
                int counter = 0;
                Guid newTrackGuid = Guid.NewGuid();
                int x = 0;
                List<WayPoint> PointsToRDP = new List<WayPoint>();
                foreach (TrackSegment segment in track.TrackSegments)
                {
                    foreach (WayPoint point in segment.TrackPoints)
                    {
                        x++;
                        PointsToRDP.Add(new WayPoint(x, point.Latitude, point.Longitude, point.Elevation, point.DateTimeOfReading));
                    }
                }
                double tolerance = Convert.ToDouble(args.Accuracy);
                // Needs to be converted to degrees.
                double degreesTolerance = tolerance * 360.0 / (2.0 * Math.PI * 6378137.0);
                var SimplifiedPointsList = DouglasPeuckerInterpolation.Interpolate(PointsToRDP, 4000, degreesTolerance);
                foreach (WayPoint point in SimplifiedPointsList.ToList())
                {
                    NewTrackPoints.Add(new WayPoint(point.Order, point.X, point.Y, point.Elevation, point.DateTimeOfReading));
                }
                totalDistance = 0;
                counter = 0;
                foreach (WayPoint thispoint in NewTrackPoints)
                {
                    if (counter > 0)
                    {
                        double distance = GPXCalculationsHelper.GetMetresBetweenPoints(thispoint, lastPoint);
                        lastPoint = thispoint;
                        totalDistance += distance;

                    }
                    else
                    {
                        lastPoint = thispoint;
                    }
                    counter++;
                }
                AddStats(totalDistance / 1000, args.Accuracy);
                TrackHelper.Clear(TrackHelper.TrackTwo);
                TrackHelper.TrackTwo.TrackSegments.Add(new TrackSegment(0));
                TrackHelper.TrackTwo.TrackSegments[0].TrackPoints = NewTrackPoints;
                
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CompressTrack returned the following error : {ex.Message}");
            }
            return result;
        }

        private void AddStats(double distance, int accuracy)
        {
            if (!resultsTable.Columns.Contains("Value2"))
            {
                resultsTable.Columns.Add("Value2");
                resultsTable.Columns["Value2"].Caption = "File Two";
            }
            if (resultsTable.Rows.Contains("Source File"))
            {
                DataRow row = resultsTable.Rows.Find("Source File");
                row["Value2"] = "Compressed file - not saved";
                row = resultsTable.Rows.Find("Track distance");
                row["Value2"] = $"{distance:n3} km";
                row = resultsTable.Rows.Find("Track points");
                row["Value2"] = NewTrackPoints.Count.ToString();
            }
            if (resultsTable.Rows.Contains("Compression Accuracy"))
            {
                DataRow row = resultsTable.Rows.Find("Compression Accuracy");
                row["Value2"] = $"{accuracy} metres";
            }
            else
            {
                DataRow dataRow;
                dataRow = resultsTable.NewRow();
                dataRow["Property"] = $"Compression Accuracy";
                dataRow["Value2"] = $"{accuracy} metres";
                dataRow["Value"] = $"Not compressed";
                resultsTable.Rows.Add(dataRow);
            }
            dataGridViewStats.DataSource = resultsTable;
            dataGridViewStats.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void UpdateStatsFileName(string fileName)
        {
            if (resultsTable.Rows.Contains("Source File"))
            {
                DataRow row = resultsTable.Rows.Find("Source File");
                row["Value2"] = fileName;
                dataGridViewStats.DataSource = resultsTable;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSelectFile2_Click(object sender, EventArgs e)
        {
            // As we are selecting a new file, reset all the track variables.
            ResetTrack(TrackFile.File2);
            // Set the necessary visibility.
            SetVisibility(false);
            string fileName;
            // Ask for the file to be processed.
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select a second GPX file to be processed.",
                Filter = "GPX files (*.gpx)|*.gpx"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            else
                return;
            double totalDistance = 0;
            double totalPoints = 0;
            TrackHelper.TrackTwo = XMLHelper.LoadTrackFromFile(fileName);
            track = TrackHelper.TrackTwo;
            int counter = 0;
            foreach (TrackSegment segment in track.TrackSegments)
            {
                foreach (WayPoint point in segment.TrackPoints)
                {
                    totalPoints++;
                    OriginalTrackPoints.Add(point);
                    if (counter > 0)
                    {
                        double distance = GPXCalculationsHelper.GetMetresBetweenPoints(point, lastPoint);
                        lastPoint = point;
                        totalDistance += distance;
                    }
                    else
                    {
                        lastPoint = point;
                    }
                    counter++;
                }
            }
            if (!resultsTable.Columns.Contains("Value2"))
            {
                resultsTable.Columns.Add("Value2");
                resultsTable.Columns["Value2"].Caption = "File Two";
            }
            if (resultsTable.Rows.Contains("Source File"))
            {
                DataRow row = resultsTable.Rows.Find("Source File");
                row["Value2"] = fileName;
                row = resultsTable.Rows.Find("Track distance");
                row["Value2"] = $"{totalDistance:n3} km";
                row = resultsTable.Rows.Find("Track points");
                row["Value2"] = TrackHelper.TrackTwoPoints().Count.ToString();
            }
            dataGridViewStats.DataSource = resultsTable;
            dataGridViewStats.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            SetVisibility(true);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ResetTrack(TrackFile.File1);
            ResetTrack(TrackFile.File2);
            dataGridViewStats.DataSource = null;
            resultsTable.Clear();
            SetVisibility(false);
        }
    }
}
