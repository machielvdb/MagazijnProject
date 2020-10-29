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
    public partial class CustomerOrderDetails : Form
    {
        private static Customer _selectedCustomer;
        private static Order _selectedOrder;
        private static List<SelectedProduct> _productsinorder = new List<SelectedProduct>();
        public CustomerOrderDetails(Customer selectedcustomer, Order selectedorder)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedCustomer = selectedcustomer;
            _selectedOrder = selectedorder;
        }
        private class SelectedProduct
        {
            public string Name { get; set; }
            public int ProductID { get; set; }
            public int Amount { get; set; }

            public string NameAndAmount => Amount + " x " + Name;
        }

        private void CustomerOrderDetails_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                tbCustomer.Text = _selectedCustomer.FullName;
                tbOrderID.Text = _selectedOrder.OrderID.ToString();
                //tbEmployee.Text = _selectedOrder.Employee.FullName;
                tbDateCreated.Text = _selectedOrder.DateCreated.ToShortDateString();

                var productlist = ctx.OrderProducts.Where(x => x.OrderID == _selectedOrder.OrderID).Select(x => x).ToList();

                foreach (var item in productlist)
                {
                    var listproduct = new SelectedProduct
                    {
                        Name = item.Product.Name,
                        ProductID = item.ProductID,
                        Amount = item.Amount
                    };

                    _productsinorder.Add(listproduct);
                }

                lbProducts.DataSource = null;
                lbProducts.DisplayMember = "NameAndAmount";
                lbProducts.ValueMember = "ProductID";
                lbProducts.DataSource = _productsinorder;
            }
        }
    }
}
