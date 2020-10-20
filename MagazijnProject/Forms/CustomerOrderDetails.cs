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
        static Employee _loggedInEmployee;
        static List<CustomerOrderProduct> _orderList = new List<CustomerOrderProduct>();

        public CustomerOrderDetails(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntity())
            {
                var customerList = ctx.Customers.ToList();
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerID";
                cbCustomer.DataSource = customerList;

                var productList = ctx.Products.ToList();
                cbProduct.DisplayMember = "Name";
                cbProduct.ValueMember = "ProductID";
                cbProduct.DataSource = productList;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newCustomerOrderProduct = CreateNewCustomerOrderProduct();
            _orderList.Add(newCustomerOrderProduct);
            lbAdded.DisplayMember = "ProductnameAndAmount";
            lbAdded.ValueMember = "OrderProductID";
            lbAdded.DataSource = _orderList;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to create this order?", "Create new order", MessageBoxButtons.YesNo);

            if (DialogResult == DialogResult.Yes)
            {
                using (var ctx = new WarehouseEntity())
                {
                    foreach (var item in _orderList)
                    {
                        ctx.CustomerOrderProducts.Add(item);
                        ctx.SaveChanges();
                    }
                    MessageBox.Show("Orders saved.");
                    Close();
                }
            }
        }

        private CustomerOrder CreateNewCustomerOrder()
        {
            using (var ctx = new WarehouseEntity())
            {
                var newCustomerOrder = new CustomerOrder
                {
                    EmployeeID = _loggedInEmployee.EmployeeID,
                    CustomerID = Convert.ToInt32(cbCustomer.SelectedValue),
                    DateCreated = DateTime.Now
                };

                ctx.CustomerOrders.Add(newCustomerOrder);
                ctx.SaveChanges();
                return newCustomerOrder;
            }
        }

        private CustomerOrderProduct CreateNewCustomerOrderProduct()
        {
            var newCustomerOrder = CreateNewCustomerOrder();

            var newCustomerOrderProduct = new CustomerOrderProduct
            {
                Product = (Product)cbProduct.SelectedItem,
                CustomerOrderID = newCustomerOrder.CustomerOrderID
            };
            return newCustomerOrderProduct;
        }
    }
}
