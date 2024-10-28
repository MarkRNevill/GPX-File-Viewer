using System.Collections.Generic;
using System.Xml.Serialization;

namespace GPX_File_Viewer.GPX_Representations
{
    public class TrackSegment
    {
        [XmlElement("trkpt")]
        public List<WayPoint> TrackPoints = new List<WayPoint>();

        public int SegmentOrder = 0;

        public TrackSegment(int segmentOrder)
        {
            SegmentOrder = segmentOrder;
        }
    }
}
