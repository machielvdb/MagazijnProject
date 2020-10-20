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

        public CustomerOrderDetails(Employee loggedInEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
        }

        private void OrderDetails_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities1())
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
            var newOrderProduct = CreateNewOrderProduct();
            _orderList.Add(newOrderProduct);
            lbAdded.DisplayMember = "ProductnameAndAmount";
            lbAdded.ValueMember = "OrderProductID";
            lbAdded.DataSource = _orderList;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to create this order?", "Create new order", MessageBoxButtons.YesNo);

            if (DialogResult == DialogResult.Yes)
            {
                using (var ctx = new WarehouseEntities1())
                {
                    foreach (var item in _orderList)
                    {
                        ctx.OrderProducts.Add(item);
                    }
                    ctx.SaveChanges();
                    MessageBox.Show("Orders saved.");
                    Close();
                }
            }
        }

        private Order CreateNewOrder()
        {
            var newOrder = new Order
            {
                EmployeeID = _loggedInEmployee.EmployeeID,
                CustomerID = Convert.ToInt32(cbCustomer.SelectedValue),
                DateCreated = DateTime.Now
            };
            return newOrder;
        }

        private OrderProduct CreateNewOrderProduct()
        {
            var newOrder = CreateNewOrder();
            var newOrderProduct = new OrderProduct
            {
                Product = (Product)cbProduct.SelectedItem,
                Amount = Convert.ToInt32(numAmount.Value),
                OrderID = newOrder.OrderID
            };
            return newOrderProduct;
        }
    }
}
