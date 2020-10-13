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
                using (MagazijnModelEntities ctx = new MagazijnModelEntities())
                {
                    ctx.Personeelslid.Where(x => x == _geselecteerdPersoneelslid).Select(p => p.Wachtwoord == tbNieuwWachtwoord.Text);
                    ctx.SaveChanges();

                    /*
                    ctx.Personeelslid.RemoveRange(ctx.Personeelslid.Where(p => p.PersoneelslidID == _geselecteerdPersoneelslid.PersoneelslidID));
                    _geselecteerdPersoneelslid.Wachtwoord = tbBevestigWachtwoord.Text;
                    ctx.Personeelslid.Add(_geselecteerdPersoneelslid);
                    ctx.SaveChanges();
                    */
                }
            }
        }
    }
}
