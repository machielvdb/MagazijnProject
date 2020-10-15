using MagazijnProject.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Konscious.Security.Cryptography;
using System.Diagnostics;

namespace MagazijnProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities())
            {
                var employeeId = Convert.ToInt32(cbUsers.SelectedValue);
                var employee = ctx.Employees.Single(x => x.EmployeeID == employeeId);
                var loginQuery = ctx.Logins.Where(x => x.EmployeeID == employeeId).ToList();

                if (loginQuery.Count == 0)
                {
                    ChoosePassword f = new ChoosePassword(employee);
                    f.ShowDialog();
                }

                else if (!string.IsNullOrEmpty(tbPassword.Text))
                {
                    var hasher = new Hashing();
                    byte[] hashbytes = hasher.GetHashBytes(employee.Password);
                    byte[] saltbytes = hasher.GetHashBytes(employee.Salt);
                    bool passwordsmatch = hasher.VerifyHash(tbPassword.Text, saltbytes, hashbytes);

                    if (passwordsmatch)
                    {
                        var login = new Login()
                        {
                            EmployeeID = employeeId,
                            Login1 = DateTime.Now
                        };

                        ctx.Logins.Add(login);
                        ctx.SaveChanges();
                        var f = new UserMenu();
                        f.Show();
                        Close();
                    }
                    else MessageBox.Show("Passwords do not match.");
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities())
            {
                var accesslist = ctx.Accesses.ToList();
                cbDepartment.DisplayMember = "AccessName";
                cbDepartment.ValueMember = "AccessID";
                cbDepartment.DataSource = accesslist;
            }
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var ctx = new WarehouseEntities())
            {
                var selectedAccess = Convert.ToInt32(cbDepartment.SelectedValue);
                var employeelist = ctx.Employees.Where(x => x.AccessID == selectedAccess).Select(x => new { Name = x.Firstname + " " + x.Lastname, Id = x.EmployeeID}).ToList();
                if (employeelist != null)
                {
                    cbUsers.DisplayMember = "Name";
                    cbUsers.ValueMember = "Id";
                    cbUsers.DataSource = employeelist;
                }
            }
        }

        public void TestHashing()
        {
            var hasher = new Hashing();
            var password = "Hello World!";
            var stopwatch = Stopwatch.StartNew();
            
            MessageBox.Show($"Creating hash for password '{ password }'.");
            
            var salt = hasher.CreateSalt();
            MessageBox.Show($"Using salt '{ Convert.ToBase64String(salt) }'.");
            
            var hash = hasher.HashPassword(password, salt);
            MessageBox.Show($"Hash is '{ Convert.ToBase64String(hash) }'.");
            
            stopwatch.Stop();
            MessageBox.Show($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");
            
            stopwatch = Stopwatch.StartNew();
            MessageBox.Show($"Verifying hash...");
            
            var success = hasher.VerifyHash(password, salt, hash);
            MessageBox.Show(success ? "Success!" : "Failure!");
            
            stopwatch.Stop();
            MessageBox.Show($"Process took { stopwatch.ElapsedMilliseconds / 1024.0 } s");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var f = new NewUser();
            f.ShowDialog();
        }
    }
}
