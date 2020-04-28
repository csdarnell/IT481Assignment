using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Business
{
    public interface ICustomers
    {
        /// <summary>
        /// Customer Count
        /// </summary>
        int CustomerCount { get; }
        /// <summary>
        /// A read-only list of customers
        /// </summary>
        IReadOnlyCollection<Customer> CustomerList { get; }
        /// <summary>
        /// Refresh the Customer Data
        /// </summary>
        void Refresh();
    }
}
