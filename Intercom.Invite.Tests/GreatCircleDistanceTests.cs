using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Intercom.Invite.Tests
{
    public class GreatCircleDistanceTests
    {
        [Theory]
        [MemberData(nameof(DistancesToCheck))]
        public void When_valid_coordinates_are_provided_calculates_valid_Great_Cirlce_Distance(GPSCoordinate coordinate1, GPSCoordinate coordinate2, double distance)
        {
            DistanceCalculator.GreatCircleDistance(coordinate1, coordinate2).ShouldBe(distance, 0.2d);
        }

        public static IEnumerable<object[]> DistancesToCheck =>
           new List<object[]>
           {
                new object[] { new GPSCoordinate(53.339428d, -6.257664d), new GPSCoordinate(52.986375d, -6.043701d), 41.77d },
                new object[] { new GPSCoordinate(53.339428d, -6.257664d), new GPSCoordinate(53.1229599d, -6.2705202d), 24.09d },
                new object[] { new GPSCoordinate(53.339428d, -6.257664d), new GPSCoordinate(54.1225d, -8.143333d), 151.5d },
                new object[] { new GPSCoordinate(53.339428d, -6.257664d), new GPSCoordinate(53.521111d, -9.831111d), 237.6d },
                new object[] { new GPSCoordinate(53.339428d, -6.257664d), new GPSCoordinate(52.986375d, 10.27699d), 1100.48d },
                new object[] { new GPSCoordinate(53.339428d, -6.257664d), new GPSCoordinate(51.6307555d, 0.0353609d), 466.33d },
           };
    }
}
