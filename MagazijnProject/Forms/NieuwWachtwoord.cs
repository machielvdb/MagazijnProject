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
    public partial class NieuwWachtwoord : Form
    {
        static Personeelslid _geselecteerdPersoneelslid;
        public NieuwWachtwoord(Personeelslid geselecteerd)
        {
            InitializeComponent();
            CenterToScreen();
            _geselecteerdPersoneelslid = geselecteerd;
        }

        private void btnBevestig_Click(object sender, EventArgs e)
        {
            if (tbBevestigWachtwoord.Text == tbNieuwWachtwoord.Text)
            {
                using (MagazijnDatabase ctx = new MagazijnDatabase())
                {
                    ctx.Personeelslid.Where(x => x.PersoneelslidID == _geselecteerdPersoneelslid.PersoneelslidID).FirstOrDefault().Wachtwoord = tbNieuwWachtwoord.Text;
                    ctx.Personeelslid.Where(x => x.PersoneelslidID == _geselecteerdPersoneelslid.PersoneelslidID).FirstOrDefault().LaatsteLogin = DateTime.Now;
                    ctx.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
