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
    public partial class DataManagementOverview : Form
    {
        static string _dataCategorie;
        public DataManagementOverview(string keuze)
        {
            InitializeComponent();
            CenterToScreen();
            _dataCategorie = keuze;
        }

        private void DatabeheerOverzicht_Load(object sender, EventArgs e)
        {
            // Naar gelang keuze in DatabeheerOverzicht correcte objecten binden aan de listbox.
            using (var ctx = new WarehouseEntities())
            {
                switch (_dataCategorie)
                {
                    case "Personeel":
                        var personeellijst = ctx.Employees.ToList();
                        lbObjecten.DataSource = personeellijst;
                        break;
                    case "Producten":
                        var productlijst = ctx.Products.ToList();
                        lbObjecten.DataSource = productlijst;
                        lbObjecten.DisplayMember = "Naam";
                        lbObjecten.ValueMember = "ProductID";
                        break;
                    case "Leveranciers":
                        var leverancierlijst = ctx.Suppliers.ToList();
                        lbObjecten.DataSource = leverancierlijst;
                        lbObjecten.DisplayMember = "Leveranciernaam";
                        lbObjecten.ValueMember = "LeverancierID";
                        break;
                    case "Klanten":
                        var klantenlijst = ctx.Customers.Select(x => x).ToList();
                        lbObjecten.DataSource = klantenlijst;
                        break;
                }
            }
        }

        private void btnNieuw_Click(object sender, EventArgs e)
        {
            // Naar gelang keuze in DatabeheerOverzicht correcte form oproepen.
            switch (_dataCategorie)
            {
                case "Personeel":
                    NieuweGebruiker ng = new NieuweGebruiker();
                    ng.ShowDialog();
                    break;
                case "Producten":
                    NewProduct np = new NewProduct();
                    np.ShowDialog();
                    break;
                case "Leveranciers":
                    break;
                case "Klanten":
                    break;
            }
        }

        private void btnWijzig_Click(object sender, EventArgs e)
        {

        }
    }
}
