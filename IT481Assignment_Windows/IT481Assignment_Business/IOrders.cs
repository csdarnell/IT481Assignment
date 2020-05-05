using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Business
{
    public interface IOrders
    {
        /// <summary>
        /// Order Count
        /// </summary>
        int OrderCount { get; }
        /// <summary>
        /// A read-only list of orders
        /// </summary>
        IReadOnlyCollection<Order> OrderList { get; }
        /// <summary>
        /// Refresh the Order Data
        /// </summary>
        void Refresh();
    }
}
