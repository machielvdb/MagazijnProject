using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class CategorieDetails : Form
    {
        Category _selectedCategory;
        public CategorieDetails(Category selectedCategory)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedCategory = selectedCategory;
        }

        public CategorieDetails()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void CategorieDetails_Load(object sender, EventArgs e)
        {
            if (_selectedCategory != null)
            {
                tbName.Text = _selectedCategory.CategoryName;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedCategory == null)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to create this new category?", "New category", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseEntities1())
                    {
                        var newCategory = new Category()
                        {
                            CategoryName = tbName.Text
                        };

                        ctx.Categories.Add(newCategory);
                        ctx.SaveChanges();
                        MessageBox.Show("Category added.");
                        Close();
                    }
                }
            }

            else
            {
                var dialogResult = MessageBox.Show("Are you sure you want to edit this category?", "Edit category", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseEntities1())
                    {
                        var getCategory = ctx.Categories.Find(_selectedCategory.CategoryID);
                        getCategory.CategoryName = tbName.Text;
                        ctx.SaveChanges();
                        MessageBox.Show("Changes saved.");
                        Close();
                    }
                }
            }
        }
    }
}
