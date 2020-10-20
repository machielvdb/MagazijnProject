using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbSurname.Text))
            {
                Employee newEmployee = new Employee
                {
                    Firstname = tbName.Text,
                    Lastname = tbSurname.Text,
                    Password = string.Empty,
                    AccessID = (int)cbDepartment.SelectedValue,
                    StartingSalary = int.Parse(tbStartingSalary.Text),
                    EmploymentDate = dtpEmployment.Value
                };

                using (var ctx = new WarehouseEntity())
                {
                    ctx.Employees.Add(newEmployee);
                    ctx.SaveChanges();
                    Close();
                }
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntity())
            {
                var accesslist = ctx.Accesses.ToList();
                cbDepartment.DisplayMember = "AccessName";
                cbDepartment.ValueMember = "AccessID";
                cbDepartment.DataSource = accesslist;
            }
        }
    }
}