using GPX_File_Viewer.GPX_Representations;
using System.Collections.Generic;

namespace GPX_File_Viewer
{
    public static class TrackHelper
    {
        public static Track TrackOne = new Track("Track One", "Track One");
        public static Track TrackTwo = new Track("Track Two", "Track Two");

        /// <summary>
        /// Clears the track requested.
        /// </summary>
        /// <returns></returns>
        public static bool Clear(Track track)
        {
            bool result = true;
            try
            {
                foreach (TrackSegment segment in track.TrackSegments)
                {
                    segment.TrackPoints.Clear();
                }
                track.TrackSegments.Clear();
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static List<WayPoint> TrackOnePoints ()
        {
            List<WayPoint> wayPoints = new List<WayPoint>();
            try
            {
                foreach (TrackSegment segment in TrackOne.TrackSegments)
                {
                    foreach (WayPoint wayPoint in segment.TrackPoints)
                    {
                        wayPoints.Add(wayPoint);
                    }
                }
            }
            catch
            {

            }
            return wayPoints;
        }
        public static List<WayPoint> TrackTwoPoints()
        {
            List<WayPoint> wayPoints = new List<WayPoint>();
            try
            {
                foreach (TrackSegment segment in TrackTwo.TrackSegments)
                {
                    foreach (WayPoint wayPoint in segment.TrackPoints)
                    {
                        wayPoints.Add(wayPoint);
                    }
                }
            }
            catch
            {

            }
            return wayPoints;
        }
    }
}
