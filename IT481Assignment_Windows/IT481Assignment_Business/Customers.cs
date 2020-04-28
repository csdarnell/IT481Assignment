using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Business
{
    public class Customers : ICustomers
    {
        List<Customer> customers = new List<Customer>();

        public Customers()
        {
            LoadCustomers();
        }

        public int CustomerCount => customers.Count;

        public IReadOnlyCollection<Customer> CustomerList => new ReadOnlyCollection<Customer>(customers);

        public void Refresh()
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {

        }
    }
}
