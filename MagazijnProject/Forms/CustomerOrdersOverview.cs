using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class CustomerOrdersOverview : Form
    {
        static Employee _loggedInEmployee;
        public CustomerOrdersOverview(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void CustomerOrdersOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var customerList = ctx.Customers.ToList();
                cbCustomers.DisplayMember = "FullName";
                cbCustomers.ValueMember = "CustomerID";
                cbCustomers.DataSource = customerList;
            }
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var selectedCustomer = (Customer)cbCustomers.SelectedItem;
                var orderproductlist = ctx.OrderProducts.Where(x => x.Order.CustomerID == selectedCustomer.CustomerID).ToList();
                lbOrders.DisplayMember = "ProductNameAndAmount";
                lbOrders.ValueMember = "OrderProductID";
                lbOrders.DataSource = orderproductlist;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var selectedCustomer = (Customer)cbCustomers.SelectedItem;

            if (selectedCustomer != null)
            {
                var oo = new OrderOverview(_loggedInEmployee, selectedCustomer);
                oo.ShowDialog();
            }

            else
                MessageBox.Show("Please select a customer.");
        }
    }
}
