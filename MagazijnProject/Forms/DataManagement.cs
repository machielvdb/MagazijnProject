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
    public partial class DataManagement : Form
    {
        public DataManagement()
        {
            InitializeComponent();
            CenterToScreen();
        }

        // Aan de hand van welke knop werd aangeklikt wordt de parameter voor de volgende form meegegeven, om daar de 
        // listbox met de juiste objecten uit de database te gaan vullen.
        private void btnPersoneel_Click(object sender, EventArgs e)
        {
            string keuze = "Personeel";
            DataManagementOverview f = new DataManagementOverview(keuze);
            f.ShowDialog();
        }

        private void btnProducten_Click(object sender, EventArgs e)
        {
            string keuze = "Producten";
            DataManagementOverview f = new DataManagementOverview(keuze);
            f.ShowDialog();
        }

        private void btnLeveranciers_Click(object sender, EventArgs e)
        {
            string keuze = "Leveranciers";
            DataManagementOverview f = new DataManagementOverview(keuze);
            f.ShowDialog();
        }

        private void btnKlanten_Click(object sender, EventArgs e)
        {
            string keuze = "Klanten";
            DataManagementOverview f = new DataManagementOverview(keuze);
            f.ShowDialog();
        }
    }
}
