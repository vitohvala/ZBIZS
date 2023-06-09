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
    public partial class Logovanje : UserControl
    {
        
        public Logovanje()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registracija reg = new Registracija();
            PromeniUC.promeniUC(reg, globalne.panel1);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = textBox1.Text;
            pass = textBox2.Text;
            bazaKontrol kon = new bazaKontrol();
            string upit = "SELECT * from Korisnik where Korisnicko_ime = '" + user + "' AND Lozinka = '" + pass  + "';";
            kon.izvrsiUpit(upit);
            if (kon.reader.Read())
            {
                textBox1.Text = textBox2.Text = "";

                globalne.korisnik = new Korisnik();
                globalne.korisnik.jmbg = kon.reader["JMBG"].ToString();
                globalne.korisnik.username = kon.reader["Korisnicko_ime"].ToString(); ;
                globalne.korisnik.lozinka = kon.reader["Lozinka"].ToString();
                globalne.korisnik.email = kon.reader["Email"].ToString();
                globalne.korisnik.ime = kon.reader["Ime"].ToString();
                globalne.korisnik.prezime = kon.reader["Prezime"].ToString();
                globalne.korisnik.telefon = int.Parse(kon.reader["Telefon"].ToString());

                BiranjeOkruga okrug = new BiranjeOkruga();
                PromeniUC.promeniUC(okrug, globalne.panel1);
              
            }
            else
            {
                textBox1.Text = textBox2.Text = "";

                MessageBox.Show("Pogresno Uneto Korisnicko Ime ili Lozinka");
            }
            kon.zatvori();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }
    }
}
