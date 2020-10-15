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
        public ObjectManagementOverview(string userchoice)
        {
            InitializeComponent();
            CenterToScreen();
            _userchoice = userchoice;
        }

        public class _Employee
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public int Id { get; set; }
            public override string ToString() => $"{Firstname} {Lastname}";
        }

        public class _Customer
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public int Id { get; set; }
            public override string ToString() => $"{Firstname} {Lastname}";
        }
        private void ObjectManagementOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities1())
            {
                switch (_userchoice)
                {
                    case "Employees":
                        var employeelist = ctx.Employees.Select(x => new _Employee()
                        {
                            Firstname = x.Firstname,
                            Lastname = x.Lastname,
                            Id = x.EmployeeID
                        }).ToList();
                        lbObjects.DataSource = employeelist;
                        break;

                    case "Stock":
                        var productlist = ctx.Products.ToList();
                        lbObjects.DisplayMember = "Name";
                        lbObjects.ValueMember = "ProductID";
                        lbObjects.DataSource = productlist;
                        break;

                    case "Customers":
                        var customerlist = ctx.Customers.Select(x => new _Customer()
                        {
                            Firstname = x.Firstname,
                            Lastname = x.Lastname,
                            Id = x.CustomerID
                        }).ToList();
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
    }
}