using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class ObjectManagementOverview : Form
    {
        static string _userchoice;
        static Employee _loggedInEmployee;
        public ObjectManagementOverview(string userchoice, Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _userchoice = userchoice;
            _loggedInEmployee = loggedInEmployee;
        }
        private void ObjectManagementOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities1())
            {
                switch (_userchoice)
                {
                    case "Employees":
                        var employeelist = ctx.Employees.ToList();
                        lbObjects.DisplayMember = "FullName";
                        lbObjects.ValueMember = "EmployeeID";
                        lbObjects.DataSource = employeelist;
                        break;

                    case "Stock":
                        var productlist = ctx.Products.ToList();
                        lbObjects.DisplayMember = "Name";
                        lbObjects.ValueMember = "ProductID";
                        lbObjects.DataSource = productlist;
                        break;

                    case "Customers":
                        var customerlist = ctx.Customers.ToList();
                        lbObjects.DisplayMember = "FullName";
                        lbObjects.ValueMember = "CustomerID";
                        lbObjects.DataSource = customerlist;
                        break;

                    case "Suppliers":
                        var supplierlist = ctx.Suppliers.ToList();
                        lbObjects.DisplayMember = "Name";
                        lbObjects.ValueMember = "SupplierID";
                        lbObjects.DataSource = supplierlist;
                        break;
                }
            }
        }

        private void Details_Click(object sender, EventArgs e)
        {
            switch (_userchoice)
            {
                case "Employees":
                    var selectedEmployee = (Employee)lbObjects.SelectedItem;
                    var f = new EmployeeDetails(selectedEmployee);
                    f.ShowDialog();
                    break;
                case "Stock":
                    break;
                case "Customers":
                    break;
                case "Suppliers":
                    break;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            switch (_userchoice)
            {
                case "Employees":
                    var f = new EmployeeDetails();
                    f.ShowDialog();
                    break;
                case "Stock":
                    break;
                case "Customers":
                    break;
                case "Suppliers":
                    break;
            }
        }
    }
}