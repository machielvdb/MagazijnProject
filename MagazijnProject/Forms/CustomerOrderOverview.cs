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
    public partial class CustomerOrderOverview : Form
    {
        static Employee _loggedInEmployee;
        public CustomerOrderOverview(Employee loggedinemployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedinemployee;
        }

        private void CustomerOrderOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var customerlist = ctx.Customers.ToList();
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerID";
                cbCustomer.DataSource = customerlist;
            }
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var selectedCustomer = (Customer)cbCustomer.SelectedItem;
                var customerOrderlist = ctx.OrderProducts.Where(x => x.Order.CustomerID == selectedCustomer.CustomerID);
                lbOrders.DisplayMember = "GetProductName";
                lbOrders.ValueMember = "OrderProductID";
                lbOrders.DataSource = customerOrderlist;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var selectedCustomer = (Customer)cbCustomer.SelectedItem;
            var cod = new CustomerOrderDetails(_loggedInEmployee, selectedCustomer);
            cod.ShowDialog();
        }
    }
}
