using IT481Assignment_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT481Assignment_Windows
{
    public partial class CustomerData : Form
    {
        private Customers customers = new Customers();

        public CustomerData()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            customers.Refresh();

            lblCustomerCount.Text = customers.CustomerCount.ToString();

            foreach (Customer cust in customers.CustomerList)
            {
                lstCustomerList.Items.Add(cust.LastName);
            }
        }
    }
}
