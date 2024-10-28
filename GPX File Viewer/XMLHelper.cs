using GPX_File_Viewer.GPX_Representations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GPX_File_Viewer
{
    public static class XMLHelper
    {
        public static bool GetAttributeOrElementValue(XElement xElement, string nameToFind, out string value)
        {
            try
            {
                if (xElement.HasAttributes)
                {
                    foreach (XAttribute a in xElement.Attributes())
                    {
                        if (a.Name == nameToFind)
                        {
                            value = a.Value.ToString();
                            return true;
                        }
                    }
                }
                if (xElement.HasElements)
                {
                    foreach (XElement subele in xElement.Elements())
                    {
                        if (subele.Name.LocalName == nameToFind)
                        {
                            value = subele.Value.ToString();
                            return true;
                        }
                    }
                }
            }
            catch
            {

            }
            value = null;
            return false;
        }

        public static List<Tuple<string, string>> GetOtherAttributesOrElementValues(XElement xElement, List<string> Exclusions)
        {
            List<Tuple<string, string>> Results = new List<Tuple<string, string>>();

            if (xElement.HasAttributes)
            {
                foreach (XAttribute a in xElement.Attributes())
                {
                    if (!Exclusions.Contains(a.Name.LocalName.ToString()))
                    {
                        Results.Add(new Tuple<string, string>(a.Name.LocalName, a.Value.ToString()));
                    }
 
                }
            }
            if (xElement.HasElements)
            {
                foreach (XElement subele in xElement.Elements())
                {
                    if (!Exclusions.Contains(subele.Name.LocalName.ToString()))
                    {
                        Results.Add(new Tuple<string, string>(subele.Name.LocalName, subele.Value.ToString()));
                    }
                }
            }

            return Results;

        }

        public static Track LoadTrackFromFile(string FileName)
        {
            // To Add - Deal with Link in metadata to allow showing of RideWithGPS page.
            //          Refactor this to a function which returns the result - i.e. Track, Trackpoints etc.

            XDocument XMLDoc = XDocument.Load(FileName);

            XElement metaElement = (from xml2 in XMLDoc.Descendants()
                                    where xml2.Name.LocalName.ToString() == "metadata"
                                    select xml2).FirstOrDefault();

            bool nameOk = XMLHelper.GetAttributeOrElementValue(metaElement, "name", out string trackName);

            bool trackTimeOk = XMLHelper.GetAttributeOrElementValue(metaElement, "time", out string trackTime);
            trackTimeOk = DateTime.TryParse(trackTime, out DateTime trackDateTime);

            bool linkOk = XMLHelper.GetAttributeOrElementValue(metaElement, "link", out string link);

            Track track = new Track(trackName, trackName, trackTimeOk ? (DateTime?)trackDateTime : null, linkOk ? link : string.Empty);

            XElement trkElement = (from xml2 in XMLDoc.Descendants()
                                   where xml2.Name.LocalName.ToString() == "trk"
                                   select xml2).FirstOrDefault();
            XElement trkNameElement = trkElement.Element("name");


            List<XElement> trackSegmentElements = (from xml3 in trkElement.Descendants()
                                                   where xml3.Name.LocalName.ToString() == "trkseg"
                                                   select xml3).ToList<XElement>();

            int Order = 0;
            int segmentNumber = 0;
            foreach (XElement trackSegmentElement in trackSegmentElements)
            {
                segmentNumber++;
                int segmentOrder = 0;
                TrackSegment thisSegment = new TrackSegment(segmentNumber);
                
                List<XElement> trackPointElements = (from xml3 in trackSegmentElement.Descendants()
                                                     where xml3.Name.LocalName.ToString() == "trkpt"
                                                     select xml3).ToList<XElement>();

                foreach (XElement trackPointElement in trackPointElements)
                {
                    Order++;
                    segmentOrder++;

                    bool latitudeOk = XMLHelper.GetAttributeOrElementValue(trackPointElement, "lat", out string myString);
                    latitudeOk = double.TryParse(myString, out double latitude);
                    bool longitudeOk = XMLHelper.GetAttributeOrElementValue(trackPointElement, "lon", out myString);
                    longitudeOk = double.TryParse(myString, out double longitude);
                    bool elevationOk = XMLHelper.GetAttributeOrElementValue(trackPointElement, "ele", out myString);
                    elevationOk = double.TryParse(myString, out double elevation);
                    if (!elevationOk)
                    {
                        elevation = 0;
                    }

                    bool timeOk = XMLHelper.GetAttributeOrElementValue(trackPointElement, "time", out myString);
                    timeOk = DateTime.TryParse(myString, out DateTime time);
                    DateTime? time2 = time;
                    if (!timeOk)
                    {
                        time2 = null;
                    }
                    List<string> excluded = new List<string>
                    {
                        "lat",
                        "lon",
                        "ele",
                        "time"
                    };
                    List<Tuple<string, string>> otherValues = XMLHelper.GetOtherAttributesOrElementValues(trackPointElement, excluded);
                    List<GPXExtensionProperty> extensionProperties = new List<GPXExtensionProperty>();
                    foreach (Tuple<string, string> result in otherValues)
                    {
                        GPXExtensionProperty gPXExtensionProperty = new GPXExtensionProperty(result.Item1, PropertyTypeEnumeration.String, result.Item2);
                        extensionProperties.Add(gPXExtensionProperty);
                    }
                    WayPoint point = new WayPoint(Order, segmentNumber, segmentOrder, latitude, longitude, elevation, time2, extensionProperties);
                    thisSegment.TrackPoints.Add(point);
                }
                track.TrackSegments.Add(thisSegment);
            }
            return track;
        }
    }
}
