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
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Vrsta vrsta = new Vrsta();
            PromeniUC.promeniUC(vrsta, panel1);
            UsernameItem.Text = globalne.korisnik.username.ToString();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logovanje log = new Logovanje();
            PromeniUC.promeniUC(log, globalne.panel1);
        }
    }
}
