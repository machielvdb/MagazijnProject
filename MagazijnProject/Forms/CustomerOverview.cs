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
    public partial class CustomerOverview : Form
    {
        private static Employee _loggedInEmployee;
        public CustomerOverview(Employee loggedinemployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedinemployee;
        }

        private void CustomerOverview_Load(object sender, EventArgs e)
        {
            if (_loggedInEmployee.AccessID == 3 || _loggedInEmployee.AccessID == 1)
            {
                using (var ctx = new WarehouseDataEntity())
                {
                    var customerlist = ctx.Customers.ToList();
                    cbCustomers.DataSource = null;
                    cbCustomers.DisplayMember = "FullName";
                    cbCustomers.ValueMember = "CustomerID";
                    cbCustomers.DataSource = customerlist;
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            var selectedcustomer = (Customer)cbCustomers.SelectedItem;
            var f = new CustomerDetails(selectedcustomer, true);
            f.ShowDialog();
        }
    }
}
