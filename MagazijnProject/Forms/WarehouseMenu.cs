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
    public partial class WarehouseMenu : Form
    {
        static Employee _loggedInEmployee;
        public WarehouseMenu(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnStock.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnSuppliers.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnSupplierOrders_Click(object sender, EventArgs e)
        {
            var f = new SupplierOrdersOverview(_loggedInEmployee);
            f.ShowDialog();
        }
    }
}
