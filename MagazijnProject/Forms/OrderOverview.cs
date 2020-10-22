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
        static OrderProduct _selectedOrderProduct;
        static Customer _selectedCustomer;
        static Supplier _selectedSupplier;
        public OrderOverview(Employee loggedInEmployee, Customer selectedCustomer)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedCustomer = selectedCustomer;
        }

        public OrderOverview(Employee loggedInEmployee, OrderProduct selectedOrderProduct)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedOrderProduct = selectedOrderProduct;
        }

        public OrderOverview(Employee loggedInEmployee, Supplier selectedSupplier)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedInEmployee;
            _selectedSupplier = selectedSupplier;
        }


        private void OrderOverview_Load(object sender, EventArgs e)
        {
            if (_selectedSupplier != null)
                lblObject.Text = _selectedSupplier.Name;

            else if (_selectedCustomer != null)
                lblObject.Text = _selectedCustomer.FullName;

            else if (_selectedOrderProduct != null)
                if (_selectedOrderProduct.Order.CustomerID != null)
                    lblObject.Text = _selectedOrderProduct.Order.Customer.FullName;
                else
                    lblObject.Text = _selectedOrderProduct.Order.Supplier.Name;

            using (var ctx = new WarehouseDataEntity())
            {
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
            using (var ctx = new WarehouseDataEntity())
            {

            }
        }
    }
}
