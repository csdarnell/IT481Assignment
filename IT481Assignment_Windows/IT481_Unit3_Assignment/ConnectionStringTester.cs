using IT481Assignment_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT481_Unit3_Assignment
{
    public partial class ConnectionStringTester : Form
    {
        public ConnectionStringTester()
        {
            InitializeComponent();
        }

        private void btnRetrieveData_Click(object sender, EventArgs e)
        {
            txtStatus.Text = string.Empty;

            string connectionString = string.Format(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString, txtUserName.Text, txtPassword.Text);

            string statusMessage = string.Empty;

            lstCustomerList.Items.Clear();

            lblCustomerCount.Text = "0";
            try
            {
                Customers customers = new Customers(connectionString);
                customers.Refresh();

                lblCustomerCount.Text = customers.Count.ToString();

                foreach (Customer cust in customers.List)
                {
                    lstCustomerList.Items.Add($"{cust.CustomerId.ToString()} - {cust.LastName}");
                }

                statusMessage = "Customers retrieved successfully";
            }
            catch (Exception ex)
            {
                statusMessage = ex.Message;
            }
            txtStatus.Text = String.Concat(txtStatus.Text, Environment.NewLine, statusMessage);


            statusMessage = string.Empty;

            lstEmployees.Items.Clear();

            lblEmployeeCount.Text = "0";
            try
            {
                Employees employees = new Employees(connectionString);
                employees.Refresh();

                lblEmployeeCount.Text = employees.Count.ToString();

                foreach (Employee emp in employees.List)
                {
                    lstEmployees.Items.Add($"{emp.EmployeeId.ToString()} - {emp.LastName}");
                }

                statusMessage = "Employees retrieved successfully";
            }
            catch (Exception ex)
            {
                statusMessage = ex.Message;
            }
            txtStatus.Text = String.Concat(txtStatus.Text, Environment.NewLine, statusMessage);

            statusMessage = string.Empty;

            lstOrders.Items.Clear();

            lblOrderCount.Text = "0";
            try
            {
                Orders orders = new Orders(connectionString);
                orders.Refresh();

                lblOrderCount.Text = orders.Count.ToString();

                foreach (Order order in orders.List)
                {
                    lstOrders.Items.Add($"{order.OrderId.ToString()} - {order.ShipName}");

                }

                statusMessage = "Orders retrieved successfully";
            }
            catch (Exception ex)
            {
                statusMessage = ex.Message;
            }
            txtStatus.Text = String.Concat(txtStatus.Text, Environment.NewLine, statusMessage);
        }
    }
}
