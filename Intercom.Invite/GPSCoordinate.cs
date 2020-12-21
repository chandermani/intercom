using System;
using System.Collections.Generic;
using System.Text;

namespace Intercom.Invite
{
    public class GPSCoordinate
    {
        public GPSCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }

        public double LatitudeInRadian => Latitude * Math.PI / 180;
        public double LongitudeInRadian => Longitude * Math.PI / 180;
    }
}
