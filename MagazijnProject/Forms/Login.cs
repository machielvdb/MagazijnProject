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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (MagazijnDatabase ctx = new MagazijnDatabase())
            {
                // Kijken of de gebruiker voor de eerste keer inlogt, prompten om wachtwoord te kiezen indien dit het geval is.
                var gebruiker = (Personeelslid)cbGebruikers.SelectedItem;
                var firstLogin = string.IsNullOrEmpty(gebruiker.LaatsteLogin.ToString());
                var passwordsMatch = (tbWachtwoord.Text == gebruiker.Wachtwoord);

                if (firstLogin)
                {
                    NieuwWachtwoord f = new NieuwWachtwoord(gebruiker);
                    f.ShowDialog();
                }

                // Indien wachtwoorden overeenkomen, controleren welk menu de gebruiker te zien krijgt.
                else if (passwordsMatch)
                {
                    Hide();
                    Form f = new GebruikerMenu(gebruiker);
                    f.ShowDialog();
                    var personeelsquery = ctx.Personeelslid.Single(
                        x => x.PersoneelslidID == gebruiker.PersoneelslidID);
                    personeelsquery.LaatsteLogin = DateTime.Now;
                    Close();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            using (MagazijnDatabase ctx = new MagazijnDatabase())
            {
                var personeelslijst = ctx.Personeelslid.ToList();
                cbGebruikers.DataSource = personeelslijst;
            }
        }
    }
}
