using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZastitaBZ
{
    public class Korisnik
    {
        public string jmbg, ime, prezime, email, username, lozinka;
        public int telefon;
        public string okrug;

        public Korisnik(string JMBG, string name, string Lname, string e_mail, string kor_ime, string pass, int tel) {
            jmbg = JMBG;
            ime = name;
            prezime = Lname;
            email = e_mail;
            username = kor_ime;
            lozinka = pass;
            telefon = tel;
        }
        public Korisnik() { }
    }
}
