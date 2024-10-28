using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GPX_File_Viewer.GPX_Representations
{
    [Serializable]
    public class WayPoint 
    {
        private readonly int _order;
        private readonly int _trackSegment;
        private readonly int _trackSegmentOrder;
        private PointLatLng _latLng;
        private readonly double _elevation;
        private readonly DateTime? _dateTimeofReading;
        private readonly List<GPXExtensionProperty> _additionalProperties;
        private double _distanceFromStart;
        private double _currentSpeed;
        private double _averageSpeedToHere;
        
        private WayPoint()
        {

        }

        public WayPoint(double X, double Y, int order)
        {
            this._latLng = new PointLatLng(X, Y);
            this._order = order;
        }

        public WayPoint(int order, int trackSegment, int trackSegmentOrder, double latitude, double longitude, double elevation, DateTime? dateTimeOfReading, List<GPXExtensionProperty> additionalProperties)
        {
            _order = order;
            _trackSegmentOrder = trackSegmentOrder;
            _trackSegment = trackSegment;
            this._latLng = new PointLatLng(latitude, longitude);
            _elevation = elevation;
            _dateTimeofReading = dateTimeOfReading;
            _additionalProperties = additionalProperties;
        }

        public WayPoint(int Order, double Latitude, double Longitude, DateTime? DateTimeOfReading = null)
        {
              _order = Order;
            _trackSegmentOrder = Order;
            _trackSegment = 1;
            this._latLng = new PointLatLng(Latitude, Longitude);
            _elevation = 0;
            _dateTimeofReading = DateTimeOfReading;
            _additionalProperties = new List<GPXExtensionProperty>();
        }

        public WayPoint(int order, double latitude, double longitude, double elevation, DateTime? dateTimeOfReading = null)
        {
            _order = order;
            _trackSegmentOrder = order;
            _trackSegment = 1;
            this._latLng = new PointLatLng(latitude, longitude);
            _elevation = elevation;
            _dateTimeofReading = dateTimeOfReading;
            _additionalProperties = new List<GPXExtensionProperty>();
        }


        [XmlAttribute("lat")]
        public double Latitude
        {
            get { return _latLng.Lat; }
  
        }
        [XmlAttribute("lon")]
        public double Longitude
        {
            get { return _latLng.Lng; }

        }

        [XmlIgnore]
        public int TrackSegment
        {
            get { return _trackSegment; }
        }
        /// <summary>
        /// Distance from start of route in KM
        /// </summary>
        [XmlIgnore]
        public double DistanceFromStart
        {
            get { return _distanceFromStart; }
            set { _distanceFromStart = value; }
        }

        /// <summary>
        /// Speed from previous point to here (Kph)
        /// </summary>
        [XmlIgnore]
        public double CurrentSpeed
        {
            get { return _currentSpeed; }
            set { _currentSpeed = value; }
        }

        /// <summary>
        /// Average speed point to here (Kph)
        /// </summary>
        [XmlIgnore]
        public double AverageSpeed
        {
            get { return _averageSpeedToHere; }
            set { _averageSpeedToHere = value; }
        }

        [XmlIgnore]
        public int TrackSegmentOrder
        {
            get { return _trackSegmentOrder; }
        }
        [XmlElement("time")]
        public DateTime? DateTimeOfReading
        {
            get { return _dateTimeofReading; }
        }
        [XmlIgnore]
        public int Order
        {
            get { return _order; }
        }

        public double X
        {
            get { return Latitude; }
        }
        public double Y
        {
            get { return Longitude; }
        }

        public double Elevation
        {
            get { return _elevation; }
        }

        public List<GPXExtensionProperty> CustomProperties
        {
            get { return _additionalProperties; }
        }
    }
}
