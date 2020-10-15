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
    public partial class EmployeeDetails : Form
    {
        static Employee _selectedEmployee;
        public EmployeeDetails(Employee selectedEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedEmployee = selectedEmployee;
        }

        public EmployeeDetails()
        {
            InitializeComponent();
            CenterToScreen();
            _selectedEmployee = null;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee == null)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to create this new employee?", "New employee", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseEntities1())
                    {
                        var employee = new Employee()
                        {
                            Firstname = tbFirstname.Text,
                            Lastname = tbLastname.Text,
                            StartingSalary = decimal.Parse(tbStartingSalary.Text),
                            EmploymentDate = dtpEmploymentDate.Value
                        };
                    }
                }
            }

            else
            {
                var dialogResult = MessageBox.Show("Are you sure you want to edit this employee?", "Edit employee", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseEntities1())
                    {
                        var editEmployeeQuery = ctx.Employees.Single(x => x.EmployeeID == _selectedEmployee.EmployeeID);
                        editEmployeeQuery.Firstname = tbFirstname.Text;
                        editEmployeeQuery.Lastname = tbLastname.Text;
                        editEmployeeQuery.AccessID = Convert.ToInt32(cbAccess.SelectedValue);
                        editEmployeeQuery.EmploymentDate = dtpEmploymentDate.Value;
                        ctx.SaveChanges();
                    }
                }
            }
        }

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities1())
            {
                var accesslist = ctx.Accesses.ToList();
                cbAccess.DisplayMember = "AccessName";
                cbAccess.ValueMember = "AccessID";
                cbAccess.DataSource = accesslist;

                if (_selectedEmployee != null)
                {
                    tbFirstname.Text = _selectedEmployee.Firstname;
                    tbLastname.Text = _selectedEmployee.Lastname;
                    tbStartingSalary.Text = _selectedEmployee.StartingSalary.ToString();
                    dtpEmploymentDate.Value = _selectedEmployee.EmploymentDate;
                    cbAccess.SelectedValue = _selectedEmployee.AccessID;
                }

                else
                    return;
            }

        }
    }
}
