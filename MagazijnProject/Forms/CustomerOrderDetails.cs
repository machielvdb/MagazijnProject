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
        static List<OrderProduct> _orderList = new List<OrderProduct>();
        static OrderProduct _selectedOrderProduct;

        public CustomerOrderDetails(Employee loggedInEmployee, OrderProduct selectedOrder)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedOrderProduct = selectedOrder;
        }

        public CustomerOrderDetails(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDBEntity())
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
            lbAdded.DisplayMember = "ProductNameAndAmount";
            lbAdded.ValueMember = "OrderProductID";
            lbAdded.DataSource = _orderList;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to create this order?", "Create new order", MessageBoxButtons.YesNo);

            if (DialogResult == DialogResult.Yes)
            {
                using (var ctx = new WarehouseDBEntity())
                {
                    foreach (var item in _orderList)
                    {
                        ctx.OrderProducts.Add(item);
                        ctx.SaveChanges();
                    }
                    MessageBox.Show("Orders saved.");
                    Close();
                }
            }
        }

        private Order CreateNewCustomerOrder()
        {
            using (var ctx = new WarehouseDBEntity())
            {
                var newCustomerOrder = new Order
                {
                    EmployeeID = _loggedInEmployee.EmployeeID,
                    CustomerID = Convert.ToInt32(cbCustomer.SelectedValue),
                    DateCreated = DateTime.Now
                };

                ctx.Orders.Add(newCustomerOrder);
                ctx.SaveChanges();
                return newCustomerOrder;
            }
        }

        private OrderProduct CreateNewCustomerOrderProduct()
        {
            var newCustomerOrder = CreateNewCustomerOrder();

            var newCustomerOrderProduct = new OrderProduct
            {
                Product = (Product)cbProduct.SelectedItem,
                OrderID = newCustomerOrder.OrderID
            };
            return newCustomerOrderProduct;
        }
    }
}
