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
    public partial class SupplierOrdersOverview : Form
    {
        static Employee _loggedInEmployee;
        public SupplierOrdersOverview(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void SupplierOrdersOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var supplierlist = ctx.Suppliers.ToList();
                cbSuppliers.DataSource = null;
                cbSuppliers.DisplayMember = "Name";
                cbSuppliers.ValueMember = "SupplierID";
                cbSuppliers.DataSource = supplierlist;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var selectedSupplier = (Supplier)cbSuppliers.SelectedItem;

            if (selectedSupplier != null)
            {
                var oo = new OrderCreation(_loggedInEmployee, selectedSupplier);
                oo.ShowDialog();
            }

            else
                MessageBox.Show("Please select a supplier.");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbOrders.SelectedItem != null)
            {
                var selectedOrder = (Order)lbOrders.SelectedItem;
                var selectedSupplier = (Supplier)cbSuppliers.SelectedItem;

                if (selectedSupplier != null && selectedOrder != null)
                {
                    var oo = new OrderCreation(_loggedInEmployee, selectedSupplier, selectedOrder);
                    oo.Show();
                }
            }
        }

        private void cbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var selectedSupplier = (Supplier)cbSuppliers.SelectedItem;
                var orderlist = ctx.Orders.Where(x => x.SupplierID == selectedSupplier.SupplierID).ToList();
                lbOrders.DataSource = null;
                lbOrders.DisplayMember = "ShowOrder";
                lbOrders.ValueMember = "OrderID";
                lbOrders.DataSource = orderlist;
            }
        }
    }
}
