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
            using (var ctx = new WarehouseDataEntity())
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
                    case "Categories":
                        var categorylist = ctx.Categories.ToList();
                        lbObjects.DisplayMember = "CategoryName";
                        lbObjects.ValueMember = "CategoryID";
                        lbObjects.DataSource = categorylist;
                        break;
                    case "Customer Orders":
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
                    var ed = new EmployeeDetails(selectedEmployee);
                    ed.ShowDialog();
                    break;
                case "Stock":
                    var selectedProduct = (Product)lbObjects.SelectedItem;
                    var sd = new StockDetails(selectedProduct);
                    sd.ShowDialog();
                    break;
                case "Customers":
                    var selectedCustomer = (Customer)lbObjects.SelectedItem;
                    var cd = new CustomerDetails(selectedCustomer);
                    cd.ShowDialog();
                    break;
                case "Suppliers":
                    var selectedSupplier = (Supplier)lbObjects.SelectedItem;
                    var supd = new SupplierDetails(selectedSupplier);
                    supd.ShowDialog();
                    break;
                case "Categories":
                    var selectedCategory = (Category)lbObjects.SelectedItem;
                    var catd = new CategorieDetails(selectedCategory);
                    catd.ShowDialog();
                    break;
                case "Customer Orders":
                    break;
                case "Supplier Orders":
                    break;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            switch (_userchoice)
            {
                case "Employees":
                    var ed = new EmployeeDetails();
                    ed.ShowDialog();
                    break;
                case "Stock":
                    var sd = new StockDetails();
                    sd.ShowDialog();
                    break;
                case "Customers":
                    var cd = new CustomerDetails();
                    cd.ShowDialog();
                    break;
                case "Suppliers":
                    var supd = new SupplierDetails();
                    supd.ShowDialog();
                    break;
                case "Categories":
                    var catd = new CategorieDetails();
                    catd.ShowDialog();
                    break;
                case "Customer Orders":
                    var cod = new CustomerOrdersOverview(_loggedInEmployee);
                    cod.ShowDialog();
                    break;
                case "Supplier Orders":
                    break;
            }
        }
    }
}