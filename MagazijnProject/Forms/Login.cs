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
            bool passwordsMatch = false;

            using (MagazijnEntities ctx = new MagazijnEntities())
            {
                var gebruiker = cbGebruikers.SelectedItem as Personeelslid;
                var hashedWachtwoord = HashWachtwoord(tbWachtwoord.Text);

                passwordsMatch = (hashedWachtwoord == gebruiker.Wachtwoord);

                // Indien wachtwoorden overeenkomen, controleren welk menu de gebruiker te zien krijgt.
                if (passwordsMatch)
                {
                    Form f = new GebruikerMenu(gebruiker);
                    f.Show();
                    this.Close();
                }
            }
        }

        // https://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256 antwoord van Bjarki Heioar, 2e codeblock.
        public static string HashWachtwoord(string stringToEncrypt)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToEncrypt));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
