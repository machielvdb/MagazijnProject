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
            var f = new ObjectManagementOverview(btnEmployees.Text);
            f.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var f = new ObjectManagementOverview(btnProducts.Text);
            f.ShowDialog();
        }
    }
}
