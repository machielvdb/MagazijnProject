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

namespace MagazijnProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (MagazijnEntities ctx = new MagazijnEntities())
            {
                // Lijst met alle personeelsleden ophalen om de combobox mee te vullen.
                var personeellijst = ctx.Personeelslid.Select(x => x).ToList();

                cbGebruikers.DataSource = personeellijst;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool passwordsMatch;

            using (MagazijnEntities ctx = new MagazijnEntities())
            {
                var gebruiker = cbGebruikers.SelectedItem as Personeelslid;
                passwordsMatch = (tbWachtwoord.Text == gebruiker.Wachtwoord);

                // Indien wachtwoorden overeenkomen, controleren welk menu de gebruiker te zien krijgt.
                if (passwordsMatch)
                {
                    this.Hide();
                    Form f = new GebruikerMenu(gebruiker);
                    f.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
