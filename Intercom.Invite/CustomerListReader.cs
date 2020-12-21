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
        private readonly ICustomerModelBuilder customerModelBuilder;

        public CustomerListReader(string customerListFilePath, ICustomerModelBuilder customerModelBuilder)
        {
            this.customerListFilePath = customerListFilePath;
            this.customerModelBuilder = customerModelBuilder;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            using (var sr = new StreamReader(File.OpenRead(customerListFilePath)))
            {
                string customerLine = null;
                while ((customerLine = sr.ReadLine()) != null)
                {
                    yield return this.customerModelBuilder.Build(customerLine);
                }
            }
        }
    }
}
