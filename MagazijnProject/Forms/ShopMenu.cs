using MagazijnProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject
{
    public partial class ShopMenu : Form
    {
        static Employee _loggedInEmployee;
        public ShopMenu()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public ShopMenu(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnCustomers.Text, _loggedInEmployee);
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new CustomerOrdersOverview(_loggedInEmployee);
            f.ShowDialog();
        }
    }
}
