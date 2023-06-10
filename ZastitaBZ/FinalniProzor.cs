using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaBZ
{
    public partial class FinalniProzor : UserControl
    {
        public FinalniProzor()
        {
            InitializeComponent();
            boje(pocetnaToolStripMenuItem);
            PocetnaUC pocetna = new PocetnaUC();
            PromeniUC.promeniUC(pocetna, panel1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //Vrsta vrsta = new Vrsta();
            //PromeniUC.promeniUC(vrsta, panel1);
            UsernameItem.Text = globalne.korisnik.username.ToString();
        }
        void boje(ToolStripMenuItem menu) {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = SystemColors.Control;
            }
            menu.BackColor = Color.IndianRed;
        }
        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boje(UsernameItem);
            DialogResult dialog = new DialogResult();
            Upozorenje upozorenje = new Upozorenje("Da li ste sigurni da želite da se odjavite?");
            dialog = upozorenje.ShowDialog();
            if (upozorenje.DialogResult == DialogResult.Yes)
            {
                Logovanje logovanjeUC = new Logovanje();
                PromeniUC.promeniUC(logovanjeUC, globalne.panel1);
            }
            else if (upozorenje.DialogResult == DialogResult.No)
            {
                upozorenje.Dispose();
            }
           
        }

        private void BijkaItem_Click(object sender, EventArgs e)
        {
            boje(Biljkaitem);
            Vrsta vrsta = new Vrsta();
            PromeniUC.promeniUC(vrsta, panel1);
        }

        private void zivotinjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boje(zivotinjaToolStripMenuItem);
            Vrsta vrsta = new Vrsta("Animal");
            PromeniUC.promeniUC(vrsta, panel1);
        }

        private void pocetnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boje(pocetnaToolStripMenuItem);
            PocetnaUC pocetna = new PocetnaUC();
            PromeniUC.promeniUC(pocetna, panel1);
        }

        private void lokacijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boje(lokacijeToolStripMenuItem);
            Lokacije lok = new Lokacije();
            PromeniUC.promeniUC(lok, panel1);
        }

        private void mojProfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boje(UsernameItem);
            Profil nalog = new Profil();
            PromeniUC.promeniUC(nalog, panel1);
        }
    }
}
