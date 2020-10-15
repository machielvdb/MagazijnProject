using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class StockDetails : Form
    {
        static Product _selectedProduct;
        public StockDetails(Product selectedProduct)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedProduct = selectedProduct;
        }

        public StockDetails()
        {
            InitializeComponent();
            CenterToScreen();
            _selectedProduct = null;
        }

        private void StockDetails_Load(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                using (var ctx = new WarehouseEntities1())
                {
                    tbName.Text = _selectedProduct.Name;
                    tbCost.Text = _selectedProduct.Cost.ToString();
                    tbMargin.Text = _selectedProduct.Margin.ToString();
                    tbUnit.Text = _selectedProduct.Unit.ToString();

                    var taxlist = new List<int>() { 6, 12, 21 };
                    cbTax.DataSource = taxlist;
                    cbTax.SelectedText = $"{_selectedProduct.Tax.ToString()}";

                    var categorylist = ctx.Categories.ToList();
                    cbCategory.DisplayMember = "CategoryName";
                    cbCategory.ValueMember = "CategoryID";
                    cbCategory.DataSource = categorylist;
                    cbCategory.SelectedValue = _selectedProduct.CategoryID;

                    var supplierlist = ctx.Suppliers.ToList();
                    cbSupplier.DisplayMember = "Name";
                    cbSupplier.ValueMember = "SupplierID";
                    cbSupplier.DataSource = supplierlist;
                    cbSupplier.SelectedValue = _selectedProduct.SupplierID;

                    if (_selectedProduct.InStock)
                    {
                        rbYes.Checked = true;
                        tbAmount.Text = _selectedProduct.AmountInStock.ToString();
                        tbAmountAvailable.Text = _selectedProduct.AmountAvailable.ToString();
                        tbOrder.Text = _selectedProduct.AmountInOrder.ToString();
                        tbBackorder.Text = _selectedProduct.AmountInBackorder.ToString();
                    }

                    else
                    {
                        rbNo.Checked = true;
                        tbAmount.Enabled = false;
                        tbAmountAvailable.Enabled = false;
                        tbOrder.Enabled = false;
                        tbBackorder.Enabled = false;
                    }
                }
            }
        }
    }
}
