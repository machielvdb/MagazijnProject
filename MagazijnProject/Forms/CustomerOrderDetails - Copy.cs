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
        static Employee _loggedInEmployee;
        static List<OrderProduct> _orderList = new List<OrderProduct>();

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
            var newOrderProduct = new OrderProduct();
            newOrderProduct.Product = (Product)cbProduct.SelectedItem;
            newOrderProduct.Order.EmployeeID = _loggedInEmployee.EmployeeID;
            newOrderProduct.Order.Customer = (Customer)cbCustomer.SelectedItem;
            newOrderProduct.Amount = Convert.ToInt32(numAmount.Value);
            _orderList.Add(newOrderProduct);
            lbAdded.DisplayMember = "ProductnameAndAmount";
            lbAdded.DisplayMember = "OrderProductID";
            lbAdded.DataSource = _orderList;
        }
    }
}
