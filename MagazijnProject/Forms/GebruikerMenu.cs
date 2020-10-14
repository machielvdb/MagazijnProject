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
    public partial class GebruikerMenu : Form
    {
        static Personeelslid ingelogdeGebruiker;
        public GebruikerMenu(Personeelslid gebruiker)
        {
            InitializeComponent();
            CenterToScreen();
            ingelogdeGebruiker = gebruiker;
        }

        private void btnDatabeheer_Click(object sender, EventArgs e)
        {
            if (ingelogdeGebruiker.ToegangID != 0) return;

            Databeheer f = new Databeheer();
            f.ShowDialog();
        }
    }
}
