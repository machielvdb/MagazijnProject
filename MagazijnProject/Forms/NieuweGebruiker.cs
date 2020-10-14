using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagazijnProject
{
    public partial class NieuweGebruiker : Form
    {
        public NieuweGebruiker()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnAanmaken_Click(object sender, EventArgs e)
        {
            if (tbVoornaam.Text != string.Empty || tbAchternaam.Text != string.Empty)
            {
                using (MagazijnDatabase ctx = new MagazijnDatabase())
                {
                    ctx.Personeelslid.Add(new Personeelslid() 
                    { 
                        Voornaam = tbVoornaam.Text, 
                        Achternaam = tbAchternaam.Text, 
                        ToegangID = (int)cbToegang.SelectedValue, 
                        DatumInDienst = dtpIndienst.Value
                    });
                    ctx.SaveChanges();
                    Close();
                }
            }
        }

        private void NieuweGebruiker_Load(object sender, EventArgs e)
        {
            // De toegang niveau's in de combobox laden met dezelfde keys als in DB.
            Dictionary<int, string> toegang = new Dictionary<int, string>
            {
                {0, "Admin"},
                {1, "Magazijn"},
                {2, "Verkoper"}
            };

            cbToegang.DataSource = new BindingSource(toegang, null);
            cbToegang.DisplayMember = "Value";
            cbToegang.ValueMember = "Key";
            cbToegang.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
