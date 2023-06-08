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
    public partial class Vrsta : UserControl
    {
        public Vrsta()
        {
            InitializeComponent();
        }

        private void Vrsta_Load(object sender, EventArgs e)
        {
            bazaKontrol konekcija = new bazaKontrol();
            string upit = "SELECT * FROM Vrsta;";
            konekcija.popuni(dataGridView1, upit);
            konekcija.zatvori();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
