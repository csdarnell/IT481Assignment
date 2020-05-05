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
        private List<Order> orders = new List<Order>();

        public int Count => orders.Count;

        public IReadOnlyCollection<Order> List => new ReadOnlyCollection<Order>(orders);


        public Orders(string connectionString)
        {
            DataInitializer initializer = new DataInitializer(connectionString);
            dataManager = initializer.GetDataManager();

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

            var rawOrders = dataManager.GetOrders();

            foreach (var rawOrder in rawOrders)
            {
                var order = new Order();
                order.OrderId = rawOrder.OrderID;
                order.CustomerId = rawOrder.CustomerID;
                order.EmployeeId = rawOrder.EmployeeID;
                order.OrderDate = rawOrder.OrderDate;
                order.RequiredDate = rawOrder.RequiredDate;
                order.ShippedDate = rawOrder.ShippedDate;
                order.ShipName = rawOrder.ShipName;

                orders.Add(order);
            }


        }
    }
}
