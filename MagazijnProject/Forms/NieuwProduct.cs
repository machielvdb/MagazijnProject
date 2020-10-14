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
    public partial class NieuwProduct : Form
    {
        public NieuwProduct()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void NieuwProduct_Load(object sender, EventArgs e)
        {
            List<int> btwTarieven = new List<int>() { 6, 12, 21 };
            cbBTW.DataSource = btwTarieven;
        }
    }
}