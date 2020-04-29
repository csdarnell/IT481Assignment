using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Data
{
    public class CustomerManager
    {
        private readonly string connectionString;

        public CustomerManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IReadOnlyCollection<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * from Customers";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                customers.Clear();
                                while (reader.Read())
                                {
                                    Customer customer = new Customer();

                                    customer.CustomerId = reader.IsDBNull(reader.GetOrdinal("CustomerId")) == true ? string.Empty : reader.GetFieldValue<string>(reader.GetOrdinal("CustomerId"));
                                    customer.CompanyName = reader.IsDBNull(reader.GetOrdinal("CompanyName")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("CompanyName"));
                                    customer.ContactName = reader.IsDBNull(reader.GetOrdinal("ContactName")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ContactName"));
                                    customer.ContactTitle = reader.IsDBNull(reader.GetOrdinal("ContactTitle")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ContactTitle"));
                                    customer.Address = reader.IsDBNull(reader.GetOrdinal("Address")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Address"));
                                    customer.City = reader.IsDBNull(reader.GetOrdinal("City")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("City"));

                                    customer.Region = reader.IsDBNull(reader.GetOrdinal("Region")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Region"));
                                    customer.PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("PostalCode"));
                                    customer.Country = reader.IsDBNull(reader.GetOrdinal("Country")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Country"));
                                    customer.Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Phone"));
                                    customer.Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Fax"));

                                    customers.Add(customer);
                                }
                            }
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // An SQL exception has occurred.  Clear the internal data.
                customers.Clear();
            }

            return customers;
        }


    }
}
