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
    public partial class ManagementMenu : Form
    {
        static Employee _loggedInEmployee;
        public ManagementMenu(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnEmployees.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnStock.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnCustomers.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnSuppliers.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnCategories.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnCustomerOrders.Text, _loggedInEmployee);
            f.ShowDialog();
        }
    }
}
