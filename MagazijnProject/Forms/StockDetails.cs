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
                using (var ctx = new WarehouseDBEntity())
                {
                    tbName.Text = _selectedProduct.Name;
                    tbCost.Text = _selectedProduct.Cost.ToString();
                    tbMargin.Text = _selectedProduct.Margin.ToString();

                    FillTaxBox();
                    FillCategoryBox();
                    FillSupplierBox();

                    if (_selectedProduct.InStock)
                    {
                        rbYes.Checked = true;
                        tbAmount.Text = _selectedProduct.AmountInStock.ToString();
                        tbAmountAvailable.Text = _selectedProduct.AmountAvailable.ToString();
                        tbOrder.Text = _selectedProduct.AmountInOrder.ToString();

                        var isNull = string.IsNullOrEmpty(_selectedProduct.AmountInBackorder.ToString());
                        if (isNull)
                        {
                            tbBackorder.Text = "0";
                        }

                        else
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

            else
            {
                FillTaxBox();
                FillCategoryBox();
                FillSupplierBox();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                var newProduct = new Product()
                {
                    Name = tbName.Text,
                    Cost = decimal.Parse(tbCost.Text),
                    Margin = decimal.Parse(tbMargin.Text),
                    Tax = Convert.ToInt32(cbTax.SelectedValue),
                    CategoryID = Convert.ToInt32(cbCategory.SelectedValue),
                    SupplierID = Convert.ToInt32(cbSupplier.SelectedValue),
                    InStock = rbYes.Checked ? true : false,
                    AmountInStock = int.Parse(tbAmount.Text),
                    AmountInOrder = int.Parse(tbOrder.Text),
                    AmountAvailable = int.Parse(tbAmountAvailable.Text),
                    AmountInBackorder = int.Parse(tbBackorder.Text)
                };

                using (var ctx = new WarehouseDBEntity())
                {
                    var dialogResult = MessageBox.Show("Are you sure you want to create this new product?", "New product", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        ctx.Products.Add(newProduct);
                        ctx.SaveChanges();
                        Close();
                    }
                }
            }

            else
            {
                using (var ctx = new WarehouseDBEntity())
                {
                    var dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Edit product", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes)
                    {
                        var productToEdit = ctx.Products.Find(_selectedProduct.ProductID);

                        if (productToEdit == null)
                            MessageBox.Show("Something went wrong.");
                        else
                        {
                            productToEdit.Name = tbName.Text;
                            productToEdit.Cost = decimal.Parse(tbCost.Text);
                            productToEdit.Margin = decimal.Parse(tbMargin.Text);
                            productToEdit.Tax = Convert.ToInt32(cbTax.SelectedValue);
                            productToEdit.CategoryID = Convert.ToInt32(cbCategory.SelectedValue);
                            productToEdit.SupplierID = Convert.ToInt32(cbSupplier.SelectedValue);
                            productToEdit.InStock = rbYes.Checked ? true : false;
                            productToEdit.AmountInStock = int.Parse(tbAmount.Text);
                            productToEdit.AmountInOrder = int.Parse(tbOrder.Text);
                            productToEdit.AmountAvailable = int.Parse(tbAmountAvailable.Text);
                            productToEdit.AmountInBackorder = int.Parse(tbBackorder.Text);
                            ctx.SaveChanges();
                            Close();
                        }
                    }
                }
            }
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYes.Checked)
            {
                tbAmount.Enabled = true;
                tbAmountAvailable.Enabled = true;
                tbOrder.Enabled = true;
                tbBackorder.Enabled = true;
            }

            else
            {
                tbAmount.Enabled = false;
                tbAmountAvailable.Enabled = false;
                tbOrder.Enabled = false;
                tbBackorder.Enabled = false;
            }
        }

        private void FillTaxBox()
        {
            var taxlist = new List<int>() { 6, 12, 21 };
            cbTax.DataSource = taxlist;
            if (_selectedProduct != null)
                cbTax.SelectedText = $"{_selectedProduct.Tax.ToString()}";
        }

        public void FillCategoryBox()
        {
            using (var ctx = new WarehouseDBEntity())
            {
                var categorylist = ctx.Categories.ToList();
                cbCategory.DisplayMember = "CategoryName";
                cbCategory.ValueMember = "CategoryID";
                cbCategory.DataSource = categorylist;
                if (_selectedProduct != null)
                    cbCategory.SelectedValue = _selectedProduct.CategoryID;
            }
        }

        public void FillSupplierBox()
        {
            using (var ctx = new WarehouseDBEntity())
            {
                var supplierlist = ctx.Suppliers.ToList();
                cbSupplier.DisplayMember = "Name";
                cbSupplier.ValueMember = "SupplierID";
                cbSupplier.DataSource = supplierlist;

                if (_selectedProduct != null)
                    cbSupplier.SelectedValue = _selectedProduct.SupplierID;
            }
        }
    }
}
