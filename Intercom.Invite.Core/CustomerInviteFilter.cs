using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intercom.Invite
{
    public class CustomerInviteFilter
    {
        private readonly ICustomerListReader customerListReader;
        private Func<GPSCoordinate, GPSCoordinate, double> distanceCalculator;

        public CustomerInviteFilter(ICustomerListReader customerListReader, 
                                    Func<GPSCoordinate, GPSCoordinate, double> distanceCalculator)
        {
            this.customerListReader = customerListReader;
            this.distanceCalculator = distanceCalculator;
        }

        public IEnumerable<Customer> Filter(GPSCoordinate source, double radius)
        {
            return this.customerListReader
                        .GetCustomers()
                        .Where(c => distanceCalculator(source, c.Coordinate) <= radius);
        }
    }
}
