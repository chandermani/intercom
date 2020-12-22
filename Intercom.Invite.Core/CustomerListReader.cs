using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Intercom.Invite
{
    public class CustomerListReader : ICustomerListReader
    {
        private readonly string customerListFilePath;
        private readonly Func<string, Customer> mapper;

        public CustomerListReader(string customerListFilePath, Func<string,Customer> mapper)
        {
            this.customerListFilePath = customerListFilePath;
            this.mapper = mapper;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var sr = new StreamReader(File.OpenRead(customerListFilePath)))
            {
                string customerLine = null;
                while ((customerLine = sr.ReadLine()) != null)
                {
                    yield return mapper(customerLine);
                }
            }
        }
    }
}
