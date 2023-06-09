using System;
using System.IO;
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
    public partial class BiranjeOkruga : UserControl
    {
        public BiranjeOkruga()
        {
            InitializeComponent();
        }
        private void povezi()
        {
            try
            {
                string upit = "SELECT naziv FROM Lokacija";
                bazaKontrol kon = new bazaKontrol();
                kon.puniCombo(comboBox1, upit, "naziv");
                kon.zatvori();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom čitanja podataka: " + ex.Message);
            }
        }
        private void BiranjeOkruga_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            povezi();
            label1.Text = globalne.korisnik.username.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;
            globalne.korisnik.okrug = selectedRow["naziv"].ToString();
            globalne.res = true;
            FinalniProzor fin = new FinalniProzor();
            PromeniUC.promeniUC(fin, globalne.panel1);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString())) ? false : true;
        }
    }
}
