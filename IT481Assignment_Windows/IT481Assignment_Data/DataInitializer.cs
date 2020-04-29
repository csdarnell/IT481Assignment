using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IT481Assignment_Data
{
    public class DataInitializer
    {
        private readonly string connectionString;

        private CustomerManager customerManager;

        public DataInitializer(string connectionString)
        {
            this.connectionString = connectionString;
            customerManager = new CustomerManager(connectionString);
        }

        public CustomerManager GetCustomerManager()
        {
            return customerManager;
        }
    }
}
