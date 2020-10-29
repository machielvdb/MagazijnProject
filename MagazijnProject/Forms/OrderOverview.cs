using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class OrderOverview : Form
    {
        private static Employee _loggedInEmployee;
        public OrderOverview(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (_loggedInEmployee.AccessID == 3)
            {
                var selectedcustomer = (Customer)cbObject.SelectedItem;
                var selectedorder = (Order)lbOrders.SelectedItem;

                var f = new CustomerOrderDetails(selectedcustomer, selectedorder);
                f.ShowDialog();
            }
        }

        private void OrderOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                if (_loggedInEmployee.AccessID == 3)
                {
                    lblObject.Text = "Customer:";
                    var customerlist = ctx.Customers.ToList();
                    cbObject.DataSource = null;
                    cbObject.DisplayMember = "FullName";
                    cbObject.ValueMember = "CustomerID";
                    cbObject.DataSource = customerlist;
                }

                else if (_loggedInEmployee.AccessID == 2)
                {
                    lblObject.Text = "Supplier:";
                    var supplierlist = ctx.Suppliers.ToList();
                    cbObject.DataSource = null;
                    cbObject.DisplayMember = "Name";
                    cbObject.ValueMember = "SupplierID";
                    cbObject.DataSource = supplierlist;
                }
            }
        }

        private void cbObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                if (_loggedInEmployee.AccessID == 3)
                {
                    var selectedcustomer = (Customer)cbObject.SelectedItem;
                    var customerorders = ctx.Orders.Where(x => x.CustomerID == selectedcustomer.CustomerID).ToList();
                    lbOrders.DataSource = null;
                    lbOrders.DisplayMember = "ShowOrder";
                    lbOrders.ValueMember = "OrderID";
                    lbOrders.DataSource = customerorders;
                }

                else if (_loggedInEmployee.AccessID == 2)
                {
                    var selectedsupplier = (Supplier)cbObject.SelectedItem;
                    var supplierorders = ctx.Orders.Where(x => x.SupplierID == selectedsupplier.SupplierID).ToList();
                    lbOrders.DataSource = null;
                    lbOrders.DisplayMember = "ShowOrder";
                    lbOrders.ValueMember = "OrderID";
                    lbOrders.DataSource = supplierorders;
                }
            }
        }
    }
}
