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
            using (MagazijnModelEntities ctx = new MagazijnModelEntities())
            {
                // Lijst met alle personeelsleden ophalen om de combobox mee te vullen.
                var personeellijst = ctx.Personeelslid.Select(x => x).ToList();

                cbGebruikers.DataSource = personeellijst;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool passwordsMatch;

            using (MagazijnModelEntities ctx = new MagazijnModelEntities())
            {
                // Kijken of de gebruiker voor de eerste keer inlogt, prompten om wachtwoord te kiezen indien dit het geval is.
                var gebruiker = cbGebruikers.SelectedItem as Personeelslid;
                bool firstLogin = string.IsNullOrEmpty(gebruiker.Wachtwoord);
                passwordsMatch = (tbWachtwoord.Text == gebruiker.Wachtwoord);

                if (firstLogin)
                {
                    NieuwWachtwoord f = new NieuwWachtwoord(gebruiker);
                    f.ShowDialog();
                }

                // Indien wachtwoorden overeenkomen, controleren welk menu de gebruiker te zien krijgt.
                else if (passwordsMatch)
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
