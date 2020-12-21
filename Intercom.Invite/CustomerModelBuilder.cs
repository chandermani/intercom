using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intercom.Invite
{
    public interface ICustomerModelBuilder
    {
        public Customer Build(string customerLine);
    }

    public class CustomerModelBuilder : ICustomerModelBuilder
    {
        public Customer Build(string customerLine)
        {
            var c = JsonConvert.DeserializeObject<dynamic>(customerLine);
            return new Customer((int)c.user_id.Value,
                                        c.name.Value,
                                        new GPSCoordinate(double.Parse(c.latitude.Value), double.Parse(c.longitude.Value)));
        }
    }
}
