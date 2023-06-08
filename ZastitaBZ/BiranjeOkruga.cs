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
        private void load_file(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                comboBox1.Items.AddRange(lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška prilikom čitanja podataka: " + ex.Message);
            }
        }
        private void BiranjeOkruga_Load(object sender, EventArgs e)
        {
            load_file("listaokruga.txt");
            label1.Text = globalne.korisnik.username.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logovanje logpanel = new Logovanje();
            PromeniUC.promeniUC(logpanel, globalne.panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // globalne.korisnik.okrug = "ww";
            FinalniProzor fin = new FinalniProzor();
            PromeniUC.promeniUC(fin, globalne.panel1);

        }
    }
}
