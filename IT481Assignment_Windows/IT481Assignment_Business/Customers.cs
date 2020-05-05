using IT481Assignment_Data;
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
        private DataManager dataManager;
        private List<Customer> customers = new List<Customer>();

        public int Count => customers.Count;

        public IReadOnlyCollection<Customer> List => new ReadOnlyCollection<Customer>(customers);


        public Customers(string connectionString)
        {
            DataInitializer initializer = new DataInitializer(connectionString);
            dataManager = initializer.GetDataManager();

            LoadCustomers();
        }

        public void Refresh()
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            if (dataManager == null)
                return;

            customers.Clear();

            var rawCustomers = dataManager.GetCustomers();

            foreach(var rawCustomer in rawCustomers)
            {
                var customer = new Customer();
                customer.CustomerId = rawCustomer.CustomerId;

                // Handle varying length names, considering that the ContactName field is the full name of the person
                var namePieces = rawCustomer.ContactName.Split(' ');
                switch(namePieces.Length)
                {
                    case 2:
                        customer.FirstName = namePieces[0];
                        customer.LastName = namePieces[namePieces.Length - 1];
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        customer.FirstName = namePieces[0];
                        customer.MiddleName = namePieces[1];
                        customer.LastName = namePieces[namePieces.Length - 1];
                        break;
                    default:
                        customer.LastName = rawCustomer.ContactName;
                        break;
                }
                customers.Add(customer);
            }

        }
    }
}
