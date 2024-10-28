using System;
using System.Globalization;
using System.IO;

namespace GPX_File_Viewer.GPX_Representations
{
    public class GPXFormatWriteHomespun
    {
        private Track _track;
        private string _fileName;
        public GPXFormatWriteHomespun(string Filename, Track Track)
        {
            _track = Track;
            _fileName = Filename;
        }
        public bool Write(bool RetainElevation, bool RetainCustom)
        {
            bool returnValue = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(_fileName))
                {
                    writer.Write(GenerateXML(_track, RetainElevation, RetainCustom));
                    writer.Flush();
                }
                returnValue = true;
            }
            catch
            {

            }
            return returnValue;
        }
        public string GenerateXML(Track track, bool RetainElevation,bool RetainCustom)
        {
            /* Format for extensions "<trkpt>"
                + "<time>" + timeList[c].ToString("s") + "Z</time>"
                + "<extensions>"
                + "<gpxtpx:TrackPointExtension>"
                + "<gpxtpx:hr>" + heartRateList[c] + "</gpxtpx:hr>"
                + "</gpxtpx:TrackPointExtension>"
                + "</extensions>"
                + "</trkpt>";
            */

            string trkpt = "";
            foreach (TrackSegment trackSegment in track.TrackSegments)
            {
                trkpt += "    <trkseg>" + Environment.NewLine;
                foreach (WayPoint p in trackSegment.TrackPoints)
                {
                    string elevationString = p.Elevation == 0 || !RetainElevation ? "" : "        <ele>" + p.Elevation.ToString() + "</ele>" + Environment.NewLine;
                    string timeString = string.IsNullOrEmpty(p.DateTimeOfReading.ToString()) ? "" : "        <time>" + string.Format(p.DateTimeOfReading.ToString(), "s", CultureInfo.GetCultureInfo("en-US")) + "Z</time>" + Environment.NewLine;
                    string extensionsString = string.Empty;

                    if (p.CustomProperties.Count > 0)
                    {
                        extensionsString = "        <extensions> " + Environment.NewLine + "          <gpxtpx:TrackPointExtension>" + Environment.NewLine;
                        foreach (GPXExtensionProperty property in p.CustomProperties)
                        {
                            extensionsString += "            <gpxtpx:" + property.Name + ">" + property.Value + "/gpxtpx:" + property.Name + ">";
                        }
                        extensionsString += "          </gpxtpx:TrackPointExtension>" + Environment.NewLine + "        </extensions>" + Environment.NewLine;
                    }



                    trkpt += "      <trkpt lat=\"" + p.Latitude.ToString() + "\" lon=\"" + p.Longitude.ToString() + "\">" + Environment.NewLine
                          + elevationString
                          + timeString
                          + extensionsString
                         + "      </trkpt>" + Environment.NewLine;
                }
                trkpt += "    </trkseg>" + Environment.NewLine;
            }
            string gpx = "<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                + "<gpx xmlns=\"http://www.topografix.com/GPX/1/1\" xmlns:gpxtpx=\"http://www.garmin.com/xmlschemas/TrackPointExtension/v1\" xmlns:gpxx=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\" xmlns:ns1=\"http://www.cluetrust.com/XML/GPXDATA/1/0\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" creator=\"Zamfit\" version=\"1.3\" xsi:schemaLocation=\"http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd http://www.garmin.com/xmlschemas/GpxExtensions/v3 http://www.garmin.com/xmlschemas/GpxExtensionsv3.xsd http://www.garmin.com/xmlschemas/TrackPointExtension/v1 http://www.garmin.com/xmlschemas/TrackPointExtensionv1.xsd\">" + Environment.NewLine
                + "  <metadata>" + Environment.NewLine
                + "    <time>" + string.Format(track.Time.ToString(), "s", CultureInfo.GetCultureInfo("en-US")) + "</time>" + Environment.NewLine
                + "  </metadata>" + Environment.NewLine
                + "  <trk>" + Environment.NewLine
                + $"    <name>{track.Name}</name>" + Environment.NewLine
                + trkpt
                + "  </trk>" + Environment.NewLine
                + "</gpx>";
            return gpx;        
        }
    }
}

