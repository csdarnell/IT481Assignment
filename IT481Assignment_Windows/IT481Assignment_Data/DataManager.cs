using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Data
{
    public class DataManager
    {
        private readonly string connectionString;

        public DataManager(string connectionString)
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
                throw new Exception($"Unable to retrieve Employees: {ex.Message}");
            }

            return customers;
        }

        public IReadOnlyCollection<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * from Employees";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                employees.Clear();
                                while (reader.Read())
                                {
                                    Employee employee = new Employee();

                                    employee.EmployeeID = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) == true ? int.MinValue : reader.GetFieldValue<int>(reader.GetOrdinal("EmployeeID"));

                                    employee.LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("LastName"));
                                    employee.FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("FirstName"));
                                    employee.Title = reader.IsDBNull(reader.GetOrdinal("Title")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Title"));
                                    employee.TitleOfCourtesy = reader.IsDBNull(reader.GetOrdinal("TitleOfCourtesy")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("TitleOfCourtesy"));

                                    employee.BirthDate = reader.IsDBNull(reader.GetOrdinal("BirthDate")) == true ? DateTime.MinValue : reader.GetFieldValue<DateTime>(reader.GetOrdinal("BirthDate"));
                                    employee.HireDate = reader.IsDBNull(reader.GetOrdinal("HireDate")) == true ? DateTime.MinValue : reader.GetFieldValue<DateTime>(reader.GetOrdinal("HireDate"));

                                    employee.Address = reader.IsDBNull(reader.GetOrdinal("Address")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Address"));
                                    employee.City = reader.IsDBNull(reader.GetOrdinal("City")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("City"));
                                    employee.Region = reader.IsDBNull(reader.GetOrdinal("Region")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Region"));
                                    employee.PostalCode = reader.IsDBNull(reader.GetOrdinal("PostalCode")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("PostalCode"));
                                    employee.Country = reader.IsDBNull(reader.GetOrdinal("Country")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Country"));
                                    employee.HomePhone = reader.IsDBNull(reader.GetOrdinal("HomePhone")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("HomePhone"));
                                    employee.Extension = reader.IsDBNull(reader.GetOrdinal("Extension")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Extension"));
                                    employee.Notes = reader.IsDBNull(reader.GetOrdinal("Notes")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("Notes"));

                                    employee.ReportsToFK = reader.IsDBNull(reader.GetOrdinal("ReportsTo")) == true ? int.MinValue : reader.GetFieldValue<int>(reader.GetOrdinal("ReportsTo"));

                                    //TODO:  Handle Photos

                                    employees.Add(employee);
                                }
                            }
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // An SQL exception has occurred.  Clear the internal data.
                employees.Clear();
                throw new Exception($"Unable to retrieve Employees: {ex.Message}");
            }

            return employees;
        }

        public IReadOnlyCollection<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * from Orders";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                orders.Clear();
                                while (reader.Read())
                                {
                                    Order order = new Order();

                                    order.OrderID = reader.IsDBNull(reader.GetOrdinal("OrderID")) == true ? int.MinValue : reader.GetFieldValue<int>(reader.GetOrdinal("OrderID"));
                                    order.CustomerID = reader.IsDBNull(reader.GetOrdinal("CustomerID")) == true ? string.Empty : reader.GetFieldValue<string>(reader.GetOrdinal("CustomerID"));
                                    order.EmployeeID = reader.IsDBNull(reader.GetOrdinal("EmployeeID")) == true ? int.MinValue : reader.GetFieldValue<int>(reader.GetOrdinal("EmployeeID"));
                                    order.OrderDate = reader.IsDBNull(reader.GetOrdinal("OrderDate")) == true ? DateTime.MinValue : reader.GetFieldValue<DateTime>(reader.GetOrdinal("OrderDate"));
                                    order.RequiredDate = reader.IsDBNull(reader.GetOrdinal("RequiredDate")) == true ? DateTime.MinValue : reader.GetFieldValue<DateTime>(reader.GetOrdinal("RequiredDate"));
                                    order.ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) == true ? DateTime.MinValue : reader.GetFieldValue<DateTime>(reader.GetOrdinal("ShippedDate"));
                                    order.ShipVia = reader.IsDBNull(reader.GetOrdinal("ShipVia")) == true ? int.MinValue : reader.GetFieldValue<int>(reader.GetOrdinal("ShipVia"));
                                    order.Freight = reader.IsDBNull(reader.GetOrdinal("Freight")) == true ? decimal.MinValue : reader.GetFieldValue<decimal>(reader.GetOrdinal("Freight"));

                                    order.ShipName = reader.IsDBNull(reader.GetOrdinal("ShipName")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ShipName"));
                                    order.ShipAddress = reader.IsDBNull(reader.GetOrdinal("ShipAddress")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ShipAddress"));
                                    order.ShipCity = reader.IsDBNull(reader.GetOrdinal("ShipCity")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ShipCity"));
                                    order.ShipRegion = reader.IsDBNull(reader.GetOrdinal("ShipRegion")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ShipRegion"));
                                    order.ShipPostalCode = reader.IsDBNull(reader.GetOrdinal("ShipPostalCode")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ShipPostalCode"));
                                    order.ShipCountry = reader.IsDBNull(reader.GetOrdinal("ShipCountry")) == true ? string.Empty : reader.GetString(reader.GetOrdinal("ShipCountry"));

                                    orders.Add(order);
                                }
                            }
                        }
                    }

                }
            }
            catch (SqlException ex)
            {
                // An SQL exception has occurred.  Clear the internal data.
                orders.Clear();
                throw new Exception($"Unable to retrieve Orders: {ex.Message}");
            }

            return orders;
        }

    }
}
