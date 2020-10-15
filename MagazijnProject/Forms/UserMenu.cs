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
    public partial class UserMenu : Form
    {
        static Employee _loggedInEmployee;
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
    }
}
