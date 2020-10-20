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
    public partial class ChoosePassword : Form
    {
        static Employee _selectedEmployee;
        public ChoosePassword(Employee selectedEmployee)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedEmployee = selectedEmployee;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tbNew.Text != tbConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
            }

            else
            {
                var hasher = new Hashing();
                var salt = hasher.GetHashString(hasher.CreateSalt());
                var hash = hasher.sha256encrypt(tbConfirm.Text, salt);
                var success = hasher.VerifyHash(tbConfirm.Text, salt, hash);

                if (success)
                {
                    using (var ctx = new WarehouseEntity())
                    {
                        var login = new Login()
                        {
                            EmployeeID = _selectedEmployee.EmployeeID,
                            Login1 = DateTime.Now
                        };

                        var employee = ctx.Employees.Single(x => x.EmployeeID == _selectedEmployee.EmployeeID);
                        employee.Password = hash;
                        employee.Salt = salt;
                        ctx.Logins.Add(login);
                        ctx.SaveChanges();
                        Close();
                    }
                }
            }
        }
    }
}
