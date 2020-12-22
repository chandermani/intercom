using System;
using System.Collections.Generic;
using System.Text;

namespace Intercom.Invite
{
    public class DistanceCalculator
    {
        // TODO: This can be part of some configurations
        public const double MEAN_EARTH_RADIUS_KM = 6371.009d;

        public static Func<GPSCoordinate, GPSCoordinate, double> GreatCircleDistance = (location1, location2) =>
        {
            var longitudeDelta = Math.Abs(location1.LongitudeInRadian - location2.LongitudeInRadian);
            var centralAngle = Math.Acos(
                                         (Math.Sin(location1.LatitudeInRadian) * Math.Sin(location2.LatitudeInRadian))
                                         + (Math.Cos(location1.LatitudeInRadian) * Math.Cos(location2.LatitudeInRadian) 
                                            * Math.Cos(longitudeDelta)));

            return centralAngle * MEAN_EARTH_RADIUS_KM;
        };
    }
}
