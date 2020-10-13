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
    public partial class DatabeheerOverzicht : Form
    {
        static string _dataCategorie;
        public DatabeheerOverzicht(string keuze)
        {
            InitializeComponent();
            CenterToScreen();
            _dataCategorie = keuze;
        }

        private void DatabeheerOverzicht_Load(object sender, EventArgs e)
        {
            using (MagazijnModelEntities ctx = new MagazijnModelEntities())
            {
                switch (_dataCategorie)
                {
                    case "Personeel":
                        var personeellijst = ctx.Personeelslid.Select(x => x).ToList();
                        lbObjecten.DataSource = personeellijst;
                        break;
                    case "Producten":
                        var productlijst = ctx.Product.Select(x => x).ToList();
                        lbObjecten.DataSource = productlijst;
                        lbObjecten.DisplayMember = "Naam";
                        lbObjecten.ValueMember = "ProductID";
                        break;
                    case "Leveranciers":
                        var leverancierlijst = ctx.Leverancier.Select(x => x).ToList();
                        lbObjecten.DataSource = leverancierlijst;
                        lbObjecten.DisplayMember = "Leveranciernaam";
                        lbObjecten.ValueMember = "LeverancierID";
                        break;
                    case "Klanten":
                        var klantenlijst = ctx.Klant.Select(x => x).ToList();
                        lbObjecten.DataSource = klantenlijst;
                        break;
                }
            }
        }

        private void btnNieuw_Click(object sender, EventArgs e)
        {
            switch (_dataCategorie)
            {
                case "Personeel":
                    NieuweGebruiker f = new NieuweGebruiker();
                    f.ShowDialog();
                    break;
                case "Producten":
                    break;
                case "Leveranciers":
                    break;
                case "Klanten":
                    break;
            }
        }
    }
}
