using System;

namespace GPX_File_Viewer.GPX_Representations
{
    public static class GPXCalculationsHelper
    {
        public static double GetMetresBetweenPoints( WayPoint PointA, WayPoint PointB)
        {
            double differenceLatitude = Radian(PointA.Latitude - PointB.Latitude);
            double differenceLongitude = Radian(PointA.Longitude - PointB.Longitude);
            double answer = Math.Sin(differenceLatitude / 2) * Math.Sin(differenceLatitude / 2) + Math.Cos(Radian(PointA.Latitude)) * Math.Cos(Radian(PointB.Latitude))
                * Math.Sin(differenceLongitude / 2) * Math.Sin(differenceLongitude / 2);
            double nextAnswer = 2 * Math.Atan2(Math.Sqrt(answer), Math.Sqrt(1 - answer));
            double finalAnswer = 6371 * nextAnswer * 1000;
            return finalAnswer;
        }

        public static double Radian(double angleInDegrees)
        {
            return Math.PI * angleInDegrees / 180.00;
        }


        public static TimeSpan GetTimeSpanBetweenPoints(WayPoint PointA, WayPoint PointB)
        {
            TimeSpan t = new TimeSpan();
            if (!(PointA.DateTimeOfReading== null ) && !(PointB.DateTimeOfReading== null))
            {
                
                t = (TimeSpan)(PointB.DateTimeOfReading - PointA.DateTimeOfReading);
            }
            return t;
        }

        public static double GetSpeedBetweenPoints(WayPoint PointA, WayPoint PointB, UnitsVelocity units)
        {
            
            if (units== UnitsVelocity.Kmph)
            {
                return ((GetMetresBetweenPoints(PointA, PointB) / 1000) / (GetTimeSpanBetweenPoints(PointA, PointB).TotalSeconds / 3600));
            }
            else
            {
                return ((GetMetresBetweenPoints(PointA, PointB) / 1609.344) / (GetTimeSpanBetweenPoints(PointA, PointB).TotalSeconds / 3600));
            }
        }


        public static Track GetShortenedTrack (Track InputTrack, int Metres)
        {
            Track OutputTrack = new Track($"{InputTrack.Name}_Shortened_{Metres}", $"Shorted version of {InputTrack.Description}");
            int Counter = 0;
            WayPoint LastPointCounted = default;
            foreach (TrackSegment trackSegment in InputTrack.TrackSegments)
            {
                TrackSegment newSegment = new TrackSegment(trackSegment.SegmentOrder);
                foreach (WayPoint InputPoint in trackSegment.TrackPoints)
                {

                    if (Counter == 0)
                    {
                        LastPointCounted = InputPoint;
                    }
                    else
                    {
                        if (GetMetresBetweenPoints(LastPointCounted, InputPoint) >= Metres)
                        {
                            newSegment.TrackPoints.Add(new WayPoint(InputPoint.TrackSegmentOrder, InputPoint.Latitude, InputPoint.Longitude, InputPoint.DateTimeOfReading));
                            LastPointCounted = InputPoint;
                        }
                    }
                    Counter++;
                }
                OutputTrack.TrackSegments.Add(newSegment);
            }
            return OutputTrack;

        }
    }
    public enum UnitsVelocity
    {
        Kmph,
        Mph

    }
}
