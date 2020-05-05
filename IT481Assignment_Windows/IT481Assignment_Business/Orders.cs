using IT481Assignment_Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Business
{
    public class Orders : IOrders
    {
        private DataManager dataManager;
        private List<Employee> orders = new List<Employee>();

        public int OrderCount => orders.Count;

        public IReadOnlyCollection<Employee> OrderList => new ReadOnlyCollection<Employee>(orders);


        public Orders(string connectionString)
        {
            DataInitializer initializer = new DataInitializer(connectionString);
            dataManager = initializer.GetCustomerManager();

            Refresh();
        }

        public void Refresh()
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            if (dataManager == null)
                return;

            orders.Clear();

            var rawOrders = dataManager.GetEmployees();

            foreach (var rawOrder in rawOrders)
            {
                var order = new Employee();
                order.EmployeeId = rawOrder.EmployeeID;
                order.LastName = rawOrder.LastName;
                order.FirstName = rawOrder.FirstName;
                order.Title = rawOrder.Title;
                order.TitleOfCourtesy = rawOrder.TitleOfCourtesy;
                order.HireDate = rawOrder.HireDate;
                order.Notes = rawOrder.Notes;

                orders.Add(order);
            }


        }
    }
