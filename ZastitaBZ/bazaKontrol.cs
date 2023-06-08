using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite ;
using System.Windows.Forms;

namespace ZastitaBZ
{
    class bazaKontrol
    {
        public SQLiteConnection konekcija = new SQLiteConnection("Data Source=db.db");
        public SQLiteDataReader reader;
        public SQLiteCommand cmd;
        public void izvrsiUpit(string upit) {
            try
            {
                konekcija.Open();
                cmd = new SQLiteCommand(upit, konekcija);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }
        public void zatvori() {
            if (konekcija != null) { 
                konekcija.Close();
            }
        }

    }
}
