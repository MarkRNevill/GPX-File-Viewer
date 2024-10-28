using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace GPX_File_Viewer.GPX_Representations
{
    [Serializable]
    public class Track
    {
        [XmlIgnore]
        public Guid TrackID = Guid.NewGuid();
        [XmlElement("name")]
        public string Name;
        public string Link;
        [XmlElement("description")]
        public string Description;
        [XmlElement("time")]
        public DateTime? Time;
        [XmlElement("trkseg")]
        public List<TrackSegment> TrackSegments = new List<TrackSegment>();

        private Track ()
        {
        }
        public Track (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public Track(string name, string description, DateTime? trackTime, string link = "")
        {
            this.Name = name;
            this.Description = description;
            Time = trackTime;
            this.Link = link;            
        }
    }
}
