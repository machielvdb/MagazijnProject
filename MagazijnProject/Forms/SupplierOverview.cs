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
    public partial class SupplierOverview : Form
    {
        private static Employee _loggedInEmployee;
        public SupplierOverview(Employee loggedinemployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedinemployee;
        }

        private void SupplierOverview_Load(object sender, EventArgs e)
        {
            if (_loggedInEmployee.AccessID == 2 || _loggedInEmployee.AccessID == 1)
            {
                using (var ctx = new WarehouseDataEntity())
                {
                    var supplierlist = ctx.Suppliers.ToList();
                    cbSuppliers.DataSource = null;
                    cbSuppliers.DisplayMember = "Name";
                    cbSuppliers.ValueMember = "SupplierID";
                    cbSuppliers.DataSource = supplierlist;
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            var selectedsupplier = (Supplier)cbSuppliers.SelectedItem;
            var f = new SupplierDetails(selectedsupplier, true);
            f.ShowDialog();
        }
    }
}
