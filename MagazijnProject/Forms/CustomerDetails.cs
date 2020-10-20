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
    public partial class CustomerDetails : Form
    {
        Customer _selectedCustomer;
        public CustomerDetails(Customer selectedCustomer)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedCustomer = selectedCustomer;
        }

        public CustomerDetails()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            if (_selectedCustomer != null)
            {
                tbFirstname.Text = _selectedCustomer.Firstname;
                tbLastname.Text = _selectedCustomer.Lastname;
                tbAddress.Text = _selectedCustomer.Address;
                tbNumber.Text = _selectedCustomer.Housenumber;
                tbBus.Text = _selectedCustomer.Bus;
                tbZIP.Text = Convert.ToString(_selectedCustomer.ZIP_code);
                tbCity.Text = _selectedCustomer.City;
                tbPhone.Text = _selectedCustomer.Phonenumber;
                tbemail.Text = _selectedCustomer.e_mail;
                tbNote.Text = _selectedCustomer.Note;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to create this new customer?", "New customer", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseEntity())
                    {
                        var newCustomer = new Customer()
                        {
                            Firstname = tbFirstname.Text,
                            Lastname = tbLastname.Text,
                            Address = tbAddress.Text,
                            Housenumber = tbNumber.Text,
                            Bus = tbBus.Text,
                            ZIP_code = Convert.ToInt32(tbZIP.Text),
                            City = tbCity.Text,
                            Phonenumber = tbPhone.Text,
                            e_mail = tbemail.Text,
                            Note = tbNote.Text,
                            JoinDate = DateTime.Now
                        };

                        ctx.Customers.Add(newCustomer);
                        ctx.SaveChanges();
                        MessageBox.Show("Customer added.");
                        Close();
                    }
                }
            }

            else
            {
                var dialogResult = MessageBox.Show("Are you sure you want to edit this customer?", "Edit customer", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseEntity())
                    {
                        var getCustomer = ctx.Customers.Find(_selectedCustomer.CustomerID);
                        getCustomer.Firstname = tbFirstname.Text;
                        getCustomer.Lastname = tbLastname.Text;
                        getCustomer.Address = tbAddress.Text;
                        getCustomer.Housenumber = tbNumber.Text;
                        getCustomer.Bus = tbBus.Text;
                        getCustomer.ZIP_code = Convert.ToInt32(tbZIP.Text);
                        getCustomer.City = tbCity.Text;
                        getCustomer.Phonenumber = tbPhone.Text;
                        getCustomer.e_mail = tbemail.Text;
                        getCustomer.Note = tbNote.Text;
                        ctx.SaveChanges();
                        MessageBox.Show("Changes saved.");
                        Close();
                    }
                }
            }
        }
    }
}
