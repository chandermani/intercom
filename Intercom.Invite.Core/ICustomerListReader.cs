using System.Collections.Generic;

namespace Intercom.Invite
{
    public interface ICustomerListReader
    {
        IEnumerable<Customer> GetCustomers();
    }
}