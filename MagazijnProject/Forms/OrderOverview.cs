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
    public partial class OrderOverview : Form
    {
        static Employee _loggedInEmployee;
        static Order _selectedOrder;
        static Customer _selectedCustomer;
        static Supplier _selectedSupplier;
        static List<SelectedProduct> _selectedProducts = new List<SelectedProduct>();
        public OrderOverview(Employee loggedInEmployee, Customer selectedCustomer)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedCustomer = selectedCustomer;
        }

        public OrderOverview(Employee loggedInEmployee, Order selectedOrder)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedOrder = selectedOrder;
        }

        public OrderOverview(Employee loggedInEmployee, Supplier selectedSupplier)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedSupplier = selectedSupplier;
        }

        public OrderOverview(Employee loggedInEmployee, Customer selectedCustomer, Order selectedOrder)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedCustomer = selectedCustomer;
            _selectedOrder = selectedOrder;
        }


        private void OrderOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                if (_selectedSupplier != null)
                    lblObject.Text = _selectedSupplier.Name;

                else if (_selectedCustomer != null)
                    lblObject.Text = _selectedCustomer.FullName;

                else if (_selectedOrder != null)
                {
                    if (_selectedOrder.CustomerID != null)
                    {
                        lblObject.Text = _selectedOrder.Customer.FullName;

                        var productlist = ctx.OrderProducts.Where(x => x.OrderID == _selectedOrder.OrderID).Select(x => x);
                        foreach (var item in productlist)
                        {
                            var newP = new SelectedProduct
                            {
                                Name = item.Product.Name,
                                ProductID = item.ProductID,
                                Amount = item.Amount
                            };
                            _selectedProducts.Add(newP);
                        }
                        RefreshProductlist();
                    }

                    else
                    {
                        lblObject.Text = _selectedOrder.Supplier.Name;
                    }
                }

                var categoryList = ctx.Categories.ToList();
                cbCategories.DisplayMember = "CategoryName";
                cbCategories.ValueMember = "CategoryID";
                cbCategories.DataSource = categoryList;
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var selectedCategory = (Category)cbCategories.SelectedItem;
                var productList = ctx.Products.Where(x => x.CategoryID == selectedCategory.CategoryID).ToList();
                cbProducts.DisplayMember = "Name";
                cbProducts.ValueMember = "ProductID";
                cbProducts.DataSource = productList;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (numAmount.Value != 0)
            {
                var selectedProduct = (Product)cbProducts.SelectedItem;
                var listProduct = new SelectedProduct
                {
                    Name = cbProducts.Text,
                    ProductID = selectedProduct.ProductID,
                    Amount = Convert.ToInt32(numAmount.Value)
                };

                if (!_selectedProducts.Contains(listProduct))
                {
                    _selectedProducts.Add(listProduct);
                    RefreshProductlist();
                }
                else
                    MessageBox.Show("Product already in list.");
            }
        }

        private class SelectedProduct
        {
            public string Name { get; set; }
            public int ProductID { get; set; }
            public int Amount { get; set; }

            public string NameAndAmount => Amount + " x " + Name;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_selectedProducts != null && lbProducts.SelectedItem != null)
            {
                _selectedProducts.RemoveAt(lbProducts.SelectedIndex);
                RefreshProductlist();
            }
        }

        private void RefreshProductlist()
        {
            lbProducts.DataSource = null;
            lbProducts.DisplayMember = "NameAndAmount";
            lbProducts.ValueMember = "ProductID";
            lbProducts.DataSource = _selectedProducts;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var newOrder = new Order
                {
                    DateCreated = DateTime.Now,
                    EmployeeID = _loggedInEmployee.EmployeeID,
                    CustomerID = _selectedCustomer.CustomerID
                };

                ctx.Orders.Add(newOrder);
                ctx.SaveChanges();

                foreach (var item in _selectedProducts)
                {
                    var newOrderProduct = new OrderProduct
                    {
                        OrderID = newOrder.OrderID,
                        ProductID = item.ProductID,
                        Amount = item.Amount
                    };

                    ctx.OrderProducts.Add(newOrderProduct);
                    ctx.SaveChanges();
                    MessageBox.Show("Orders created.");
                    Close();
                }
            }
        }
    }
}
