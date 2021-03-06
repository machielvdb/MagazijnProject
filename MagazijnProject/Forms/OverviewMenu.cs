﻿using System;
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
    public partial class OverviewMenu : Form
    {
        private static Employee _loggedInEmployee;
        public OverviewMenu(Employee loggedinemployee)
        {
            InitializeComponent();
            CenterToScreen();
            _loggedInEmployee = loggedinemployee;
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            var f = new StockOverview(_loggedInEmployee);
            f.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var f = new OrderOverview(_loggedInEmployee);
            f.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var f = new CustomerOverview(_loggedInEmployee);
            f.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            var f = new SupplierOverview(_loggedInEmployee);
            f.ShowDialog();
        }
    }
}
