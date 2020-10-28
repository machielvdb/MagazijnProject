using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace MagazijnProject.Forms
{
    public partial class OrderOverview : Form
    {
        static Employee _loggedInEmployee;
        static Order _selectedOrder;
        static Customer _selectedCustomer;
        static Supplier _selectedSupplier;
        static List<SelectedProduct> _selectedProducts = new List<SelectedProduct>();
        List<int> _productsToRemove = new List<int>();
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

        public OrderOverview(Employee loggedInEmployee, Supplier selectedSupplier, Order selectedOrder)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedSupplier = selectedSupplier;
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

                if (_selectedOrder != null)
                {
                    btnCreate.Text = "Edit order";

                    if (_selectedOrder.CustomerID != null)
                    {
                        _selectedProducts = ctx.OrderProducts.Where(x => x.OrderID == _selectedOrder.OrderID).Select(x => new SelectedProduct{ ProductID = x.ProductID, Name = x.Product.Name, Amount = x.Amount}).ToList();
                        RefreshProductlist();
                    }

                    else
                    {
                        _selectedProducts = ctx.OrderProducts.Where(x => x.OrderID == _selectedOrder.OrderID).Select(x => new SelectedProduct { ProductID = x.ProductID, Name = x.Product.Name, Amount = x.Amount }).ToList();
                        RefreshProductlist();
                    }
                }

                else
                {
                    btnCreate.Text = "Create order";
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

                    lbProducts.DataSource = null;
                    lbProducts.DisplayMember = "NameAndAmount";
                    lbProducts.ValueMember = "ProductID";
                    lbProducts.DataSource = _selectedProducts;
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
                var selectedProduct = (SelectedProduct)lbProducts.SelectedItem;
                _productsToRemove.Add(selectedProduct.ProductID);

                _selectedProducts.Remove((SelectedProduct)lbProducts.SelectedItem);

                lbProducts.DataSource = null;
                lbProducts.DisplayMember = "Name";
                lbProducts.ValueMember = "ProductID";
                lbProducts.DataSource = _selectedProducts;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                if (_selectedOrder == null)
                {
                    if (_selectedSupplier == null)
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

                    else
                    {
                        var newOrder = new Order
                        {
                            DateCreated = DateTime.Now,
                            EmployeeID = _loggedInEmployee.EmployeeID,
                            SupplierID = _selectedSupplier.SupplierID
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

                else
                {
                    var editOrder = ctx.Orders.Single(x => x.OrderID == _selectedOrder.OrderID);
                    editOrder.EmployeeID = _loggedInEmployee.EmployeeID;

                    var orderProductList = ctx.OrderProducts.Where(x => x.OrderID == _selectedOrder.OrderID).ToList();

                    var orderproducttodelete = ctx.OrderProducts.Where(x => x.OrderID == _selectedOrder.OrderID && _productsToRemove.Contains(x.ProductID));
                    ctx.OrderProducts.RemoveRange(orderproducttodelete);
                    ctx.SaveChanges();

                    foreach (var item in _selectedProducts)
                    {
                        var newOrderProduct = new OrderProduct
                        {
                            OrderID = editOrder.OrderID,
                            ProductID = item.ProductID,
                            Amount = item.Amount
                        };

                        if (orderProductList.Contains(newOrderProduct))
                        {
                            continue;
                        }

                        else
                        {
                            ctx.OrderProducts.Add(newOrderProduct);
                            ctx.SaveChanges();
                        }
                    }

                    MessageBox.Show("Order edited.");
                    Close();
                }
            }
        }

        private void RefreshProductlist()
        {
            lbProducts.DataSource = null;
            lbProducts.DisplayMember = "NameAndAmount";
            lbProducts.ValueMember = "ProductID";
            lbProducts.DataSource = _selectedProducts;
        }

        private void OrderOverview_FormClosed(object sender, FormClosedEventArgs e)
        {
            _selectedProducts = new List<SelectedProduct>();
        }
    }
}