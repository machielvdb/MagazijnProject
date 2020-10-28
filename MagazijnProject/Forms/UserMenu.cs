using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPdf;

namespace MagazijnProject.Forms
{
    public partial class UserMenu : Form
    {
        private static Employee _loggedInEmployee;
        public UserMenu(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void btnManagement_Click(object sender, EventArgs e)
        {
            if (_loggedInEmployee.AccessID != 1)
            {
                MessageBox.Show("You are not authorized.");
            }

            else
            {
                var f = new ManagementMenu(_loggedInEmployee);
                f.ShowDialog();
            }
        }

        private void btnShop_Click(object sender, EventArgs e)
        {
            if (_loggedInEmployee.AccessID != 3)
                MessageBox.Show("You are not authorized.");

            else
            {
                var f = new ShopMenu(_loggedInEmployee);
                f.ShowDialog();
            }
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            if (_loggedInEmployee.AccessID != 2)
                MessageBox.Show("You are not authorized.");

            else
            {
                var f = new WarehouseMenu(_loggedInEmployee);
                f.ShowDialog();
            }
        }

        private void btnOverview_Click(object sender, EventArgs e)
        {
            var f = new OverviewMenu(_loggedInEmployee);
            f.ShowDialog();
        }
    }
}
