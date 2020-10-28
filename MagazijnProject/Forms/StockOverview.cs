using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class StockOverview : Form
    {
        private static Employee _loggedInEmployee;
        public StockOverview(Employee loggedinemployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedinemployee;
        }

        private void StockOverview_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseDataEntity())
            {
                var categorylist = ctx.Categories.ToList();
                cbCategories.DataSource = null;
                cbCategories.DisplayMember = "CategoryName";
                cbCategories.ValueMember = "CategoryID";
                cbCategories.DataSource = categorylist;
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCategory = (Category)cbCategories.SelectedItem;

            using (var ctx = new WarehouseDataEntity())
            {
                var productlist = ctx.Products.Where(x => x.Category == selectedCategory).ToList();
                lbProducts.DataSource = null;
                lbProducts.DisplayMember = "Name";
                lbProducts.ValueMember = "ProductID";
                lbProducts.DataSource = productlist;
            }
        }
    }
}
