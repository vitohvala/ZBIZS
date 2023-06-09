using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaBZ
{
    public partial class Profil : UserControl
    {
        public Profil()
        {
            InitializeComponent();
        }
        void ocisti() {
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
        }
        void val(TextBox box, string novi, string izbaze) {
            if (!string.IsNullOrEmpty(box.Text))
            {
                valProfil prfl = new valProfil();
                DialogResult result = prfl.ShowDialog();
                if (result == DialogResult.OK)
                {
                    novi = box.Text;
                    string upt = "UPDATE Korisnik SET '" + izbaze + "' = '" + novi + "' " +
                        "WHERE JMBG = '" + globalne.korisnik.jmbg + "';";
                    bazaKontrol kon = new bazaKontrol();
                    kon.izvrsiUpit(upt);
                    kon.zatvori();
                    MessageBox.Show("Uspesno ste zamenili " + izbaze);
                }
            }
            else
            {
                MessageBox.Show("Popunite Polje!");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length > 7)
                val(textBox7, globalne.korisnik.lozinka, "Lozinka");
            else MessageBox.Show("Mora najmanje 8 karaktera");
            ocisti();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) textBox7.UseSystemPasswordChar = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            val(textBox6, globalne.korisnik.ime, "Korisnicko_ime");
            ocisti();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                valProfil prfl = new valProfil();
                DialogResult result = prfl.ShowDialog();
                if (result == DialogResult.OK)
                {
                    globalne.korisnik.telefon = int.Parse(textBox5.Text);
                    string upt = "UPDATE Korisnik SET Telefon = '" + globalne.korisnik.telefon + "' " +
                        "WHERE JMBG = '" + globalne.korisnik.jmbg + "';";
                    bazaKontrol kon = new bazaKontrol();
                    kon.izvrsiUpit(upt);
                    kon.zatvori();
                    MessageBox.Show("Uspesno ste zamenili Telefon");
                }
            }
            else
            {
                MessageBox.Show("Popunite Polje!");
            }
            ocisti();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex mail = new Regex(@"^\w+@\w+(\.\w+)+$");
            if (!mail.IsMatch(textBox4.Text) && !string.IsNullOrEmpty(textBox4.Text))
                MessageBox.Show("Neispravan E-mail");
            else 
                val(textBox4, globalne.korisnik.email, "Email");
            ocisti();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            val(textBox3, globalne.korisnik.ime, "Ime");
            ocisti();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            val(textBox1, globalne.korisnik.jmbg, "JMBG");
            ocisti();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            Upozorenje upozorenje = new Upozorenje("Da li ste sigurni da želite izbrisati nalog?");
            dialog = upozorenje.ShowDialog();
            if (upozorenje.DialogResult == DialogResult.Yes)
            {
                string najbolji = "DELETE FROM Korisnik WHERE JMBG = '" + globalne.korisnik.jmbg + "';";
                bazaKontrol poslednji = new bazaKontrol();
                poslednji.izvrsiUpit(najbolji);
                poslednji.zatvori();
                Logovanje log = new Logovanje();
                PromeniUC.promeniUC(log, globalne.panel1);
            }
            else if (upozorenje.DialogResult == DialogResult.No)
            {
                upozorenje.Dispose();
            }
        }
    }
}
