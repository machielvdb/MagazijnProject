﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace MagazijnProject.Forms
{
    public partial class SupplierDetails : Form
    {
        private static Supplier _selectedSupplier;
        private static bool _overview = false;
        public SupplierDetails(Supplier selectedSupplier)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedSupplier = selectedSupplier;
        }

        public SupplierDetails(Supplier selectedSupplier, bool overview)
        {
            InitializeComponent();
            CenterToScreen();
            _selectedSupplier = selectedSupplier;
            _overview = overview;
        }

        public SupplierDetails()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            if (_selectedSupplier != null)
            {
                tbName.Text = _selectedSupplier.Name;
                tbPhone.Text = _selectedSupplier.Phonenumber;
                tbEmail.Text = _selectedSupplier.e_mail;
                tbAddress.Text = _selectedSupplier.Address;
                tbNumber.Text = Convert.ToString(_selectedSupplier.HouseNumber);
                tbBus.Text = _selectedSupplier.Bus;
                tbZIP.Text = Convert.ToString(_selectedSupplier.ZIP_Code);
                tbCity.Text = _selectedSupplier.City;
            }

            if (_overview)
            {
                btnConfirm.Visible = false;
                tbName.Enabled = false;
                tbPhone.Enabled = false;
                tbEmail.Enabled = false;
                tbAddress.Enabled = false;
                tbName.Enabled = false;
                tbNumber.Enabled = false;
                tbBus.Enabled = false;
                tbZIP.Enabled = false;
                tbCity.Enabled = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_selectedSupplier == null)
            {
                var dialogResult = MessageBox.Show("Are you sure you want to create this new supplier?", "New supplier", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseDataEntity())
                    {
                        var newSupplier = new Supplier()
                        {
                            Name = tbName.Text,
                            Phonenumber = tbPhone.Text,
                            e_mail = tbEmail.Text,
                            Address = tbAddress.Text,
                            HouseNumber = int.Parse(tbNumber.Text),
                            Bus = tbBus.Text,
                            ZIP_Code = int.Parse(tbZIP.Text),
                            City = tbCity.Text
                        };

                        ctx.Suppliers.Add(newSupplier);
                        ctx.SaveChanges();
                        MessageBox.Show("Supplier added.");
                        Close();
                    }
                }
            }

            else
            {
                var dialogResult = MessageBox.Show("Are you sure you want to edit this supplier?", "Edit supplier", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var ctx = new WarehouseDataEntity())
                    {
                        var getSupplier = ctx.Suppliers.Find(_selectedSupplier.SupplierID);

                        getSupplier.Name = tbName.Text;
                        getSupplier.Phonenumber = tbPhone.Text;
                        getSupplier.e_mail = tbEmail.Text;
                        getSupplier.Address = tbAddress.Text;
                        getSupplier.HouseNumber = int.Parse(tbNumber.Text);
                        getSupplier.Bus = tbBus.Text;
                        getSupplier.ZIP_Code = int.Parse(tbZIP.Text);
                        getSupplier.City = tbCity.Text;
                        ctx.SaveChanges();
                        MessageBox.Show("Changes saved.");
                        Close();
                    }
                }
            }
        }
    }
}
