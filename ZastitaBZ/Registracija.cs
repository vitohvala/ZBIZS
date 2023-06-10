using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Text.RegularExpressions;

namespace ZastitaBZ
{
    public partial class Registracija : UserControl
    {
        
        bool[] check = new bool[7];

        private void button2_Click(object sender, EventArgs e)
        {
            Logovanje logpanel = new Logovanje();
            PromeniUC.promeniUC(logpanel, globalne.panel1);
        }

        public Registracija()
        {
            InitializeComponent();
            button1.Enabled = false;
            Application.Idle += Application_Idle;

        }
        private void Application_Idle(object sender, EventArgs e)
        {
            validacija();
            if (check.All(x => x))
                button1.Enabled = true;
        }
        private void proverabr(TextBox txtbox, Label lab, int ind) {
            if (!txtbox.Text.All(char.IsDigit))
            {
                lab.Text = "Mogu da se unose samo brojevi!";
            }
            else
            {
                lab.Text = "*";
                check[ind] = true;
            }
        }
        void proveriBazu(TextBox txt, Label lab,int ind, string upit) {
            bazaKontrol kon = new bazaKontrol();
            
            kon.izvrsiUpit(upit);
            if (kon.reader.HasRows)
            {
                lab.Text = "Vec postoji!";
                check[ind] = false;
            }
            else
            {
                if (string.IsNullOrEmpty(txt.Text) && txt.TextLength < 2)
                    lab.Text = "*";
                else
                {
                    lab.Text = "Dostupno!";
                    check[ind] = true;
                }
            }
            kon.zatvori();
        }
        private void validacija() {
            string upit;
            if (jmbgtxt.TextLength != 13 && !string.IsNullOrEmpty(jmbgtxt.Text) || !jmbgtxt.Text.All(char.IsDigit))
            {
                jmbg_help.Text = "Mora da sadrzi 13 brojeva!";
            }
            else
            {
                upit = "SELECT Korisnicko_ime from Korisnik where JMBG = '" + jmbgtxt.Text + "';";
                proveriBazu(jmbgtxt, jmbg_help, 0, upit);
            }

            Regex mail = new Regex(@"^\w+@\w+(\.\w+)+$");
            if (!mail.IsMatch(emailtxt.Text) && !string.IsNullOrEmpty(emailtxt.Text)) {
                email_help.Text = "Neispravan E-mail!";    
            }
            else {
                email_help.Text = "*";
                check[3] = true;
            }

            proverabr(telefontxt, telefon_help, 4);

            upit = "SELECT Korisnicko_ime from Korisnik where Korisnicko_ime = '" + usernametxt.Text + "';";
            proveriBazu(usernametxt, korisnicko_help, 5, upit);
     

            if (lozinkatxt.TextLength < 8 && lozinkatxt.TextLength > 2)
            {
                lozinka_help.Text = "Lozinka mora imati najmanje 8 karaktera!";
            }
            else {
                lozinka_help.Text = "*";
                check[6] = true;    
            }

            check[1] = check[2] = (imetxt.TextLength > 1 && prezimetxt.TextLength > 1) ? true : false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {   
            globalne.korisnik = new Korisnik(jmbgtxt.Text, imetxt.Text, prezimetxt.Text, 
                                            emailtxt.Text,usernametxt.Text, lozinkatxt.Text, int.Parse(telefontxt.Text));
            bazaKontrol kon = new bazaKontrol();
            string upit = "INSERT INTO Korisnik(JMBG, Ime, Prezime, Telefon, Email, Korisnicko_ime, Lozinka) Values('" + 
                globalne.korisnik.jmbg + "','" + globalne.korisnik.ime + "','" + globalne.korisnik.prezime + 
                "','" + globalne.korisnik.telefon  +"','" + globalne.korisnik.email + "','" + globalne.korisnik.username +
                "','" + globalne.korisnik.lozinka + "');";
            kon.izvrsiUpit(upit);
            //kon.reader.Close();
            kon.zatvori();
            MessageBox.Show("Uspesno Ste Se Registrivali!");
            BiranjeOkruga okrug = new BiranjeOkruga();
            PromeniUC.promeniUC(okrug, globalne.panel1);

        }
    }
}
