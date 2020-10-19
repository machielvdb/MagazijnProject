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
    public partial class OrderDetails : Form
    {
        Employee _loggedInEmployee;
        List<OrderProduct> _orderList = new List<OrderProduct>();

        public OrderDetails(Employee loggedInEmployee)
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
            var newOrder = new OrderProduct();
            newOrder.Product = (Product)cbProduct.SelectedItem;
            newOrder.Order.Employee = _loggedInEmployee;
            newOrder.Order.Customer = (Customer)cbCustomer.SelectedItem;
            newOrder.Amount = Convert.ToInt32(numAmount.Value);
            _orderList.Add(newOrder);
            lbAdded.DisplayMember = "ProductnameAndAmount";
            lbAdded.DisplayMember = "OrderProductID";
            lbAdded.DataSource = _orderList;
        }
    }
}
