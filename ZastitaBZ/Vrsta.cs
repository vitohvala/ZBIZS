using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZastitaBZ
{
    public partial class Vrsta : UserControl
    {
        string which = "Biljka";
        string upit;
        string lat_naziv;
        public Vrsta()
        {
            InitializeComponent();
        }
        public Vrsta(string _which) {
            InitializeComponent();
            which = _which;
        }
        void popuni() {
            bazaKontrol konekcija = new bazaKontrol();
            if (which == "Animal")
                upit = "SELECT Latinski_naziv, Lokalni_naziv, S_Broj_prstena, Staniste FROM Vrsta WHERE Staniste IS NOT NULL OR S_Broj_Prstena IS NOT NULL";
            else if (which == "Biljka")
                upit = "SELECT Latinski_naziv, Lokalni_naziv, Broj_odluke, Datum_stupanja_odluke FROM Vrsta WHERE Broj_odluke IS NOT NULL OR Datum_stupanja_odluke IS NOT NULL;";
            konekcija.popuni(dataGridView1, upit);
            konekcija.zatvori();
        }
        void unesi() {
            bazaKontrol konekcija = new bazaKontrol();
            konekcija.popuni(dataGridView1, upit);
            konekcija.zatvori();
        }
        private void Vrsta_Load(object sender, EventArgs e)
        {
            if (which == "Animal")
            {
                label5.Text = "S.Broj Prstena";
                label6.Text = "Staniste";

                upit = "SELECT Latinski_naziv, Lokalni_naziv, S_Broj_prstena, Staniste " +
                    "FROM Vrsta WHERE Staniste IS NOT NULL OR S_Broj_Prstena IS NOT NULL";
            }
            else if (which == "Biljka")
            {
                label5.Text = "Broj Odluke";
                label6.Text = "Datum stupanja odluke";
                upit = "SELECT Latinski_naziv, Lokalni_naziv, Broj_odluke, Datum_stupanja_odluke" +
                    " FROM Vrsta WHERE Broj_odluke IS NOT NULL OR Datum_stupanja_odluke IS NOT NULL;";
            }
            unesi();
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                lat_imetxt.Text = row.Cells[0].Value.ToString();
                lok_imetxt.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
            }
        }

        void pretraga(string naziv, string pretragaVrednost) {
            if (which == "Animal")
                upit = "SELECT Latinski_naziv, Lokalni_naziv, S_Broj_prstena, Staniste " +
                    "FROM Vrsta WHERE (Staniste IS NOT NULL OR S_Broj_prstena IS NOT NULL) AND " +
                    naziv +" LIKE '%" + pretragaVrednost + "%';";
            else if (which == "Biljka")
                upit = "SELECT Latinski_naziv, Lokalni_naziv, Broj_odluke, Datum_stupanja_odluke " +
                    "FROM Vrsta WHERE (Broj_odluke IS NOT NULL OR Datum_stupanja_odluke IS NOT NULL) AND " +
                    naziv + " LIKE '%" + pretragaVrednost + "%';";
            unesi();

            dataGridView1.Refresh();

        }
        private void Lattxt_TextChanged(object sender, EventArgs e)
        {
            string pretragaVrednost = Lattxt.Text;

            pretraga("Latinski_naziv", pretragaVrednost);
        }

        private void loktxt_TextChanged(object sender, EventArgs e)
        {
            string pretragaVrednost = loktxt.Text;

            pretraga("Lokalni_naziv", pretragaVrednost); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lat_imetxt.Text.ToString()))
            {
                DialogResult dialog = new DialogResult();
                Upozorenje upozorenje = new Upozorenje("Da li ste sigurni da želite izbrisati Vrstu?");
                dialog = upozorenje.ShowDialog();
                if (upozorenje.DialogResult == DialogResult.Yes)
                {
                    lat_naziv = lat_imetxt.Text;
                    string query = "DELETE FROM Vrsta WHERE Latinski_naziv = '" + lat_naziv + "';";

                    bazaKontrol koneksn = new bazaKontrol();
                    koneksn.izvrsiUpit(query);
                    koneksn.zatvori();

                    popuni();
                    dataGridView1.Refresh();
                }
                else if (upozorenje.DialogResult == DialogResult.No)
                {
                    upozorenje.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Morate prvo selektovati rekord koji zelite izbrisati", "Upozorenje!");
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lat_imetxt.Text.ToString()))
            {
                DialogResult dialog = new DialogResult();
                Upozorenje upozorenje = new Upozorenje("Da li ste sigurni da želite da izmenite?");
                dialog = upozorenje.ShowDialog();
                if (upozorenje.DialogResult == DialogResult.Yes)
                {
                    lat_naziv = lat_imetxt.Text;
                    string lok_n = lok_imetxt.Text;

                    int tri = int.Parse(textBox3.Text);
                    string cet = textBox4.Text;
                    Regex date = new Regex(@"^[0-9]{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$");
                    if (which == "Animal")
                    {
                        upit = "UPDATE Vrsta SET Latinski_naziv = '" + lat_naziv + "', Lokalni_naziv = '" + lok_n +
                               "', S_Broj_prstena = '" + tri + "', Staniste = '" + cet + "' " +
                               "WHERE Latinski_naziv = '" + lat_naziv + "';";
                        bazaKontrol koneksn = new bazaKontrol();
                        koneksn.izvrsiUpit(upit);
                        koneksn.zatvori();

                        popuni();
                        dataGridView1.Refresh();
                    }
                    else if(which == "Biljka") {
                        if (date.IsMatch(cet))
                        {
                            upit = "UPDATE Vrsta SET Lokalni_naziv = '" + lok_n + "', ";
                            upit += " Broj_odluke = '" + tri + "', Datum_stupanja_odluke = date('" + cet + "') ";
                            upit += "WHERE Latinski_naziv = '" + lat_naziv + "';";

                            bazaKontrol koneksn = new bazaKontrol();
                            koneksn.izvrsiUpit(upit);
                            koneksn.zatvori();

                            popuni();
                            dataGridView1.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Unesite U formatu yyyy-mm-dd!");
                        }
                    }
                    else {
                        MessageBox.Show("Greska u unosu");
                    }
                }
                else if (upozorenje.DialogResult == DialogResult.No)
                {
                    upozorenje.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Morate prvo selektovati rekord koji zelite izbrisati", "Upozorenje!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lat_imetxt.Text.ToString()))
            {
                DialogResult dialog = new DialogResult();
                Upozorenje upozorenje = new Upozorenje("Da li ste sigurni da želite da unesete rekord?");
                dialog = upozorenje.ShowDialog();
                if (upozorenje.DialogResult == DialogResult.Yes)
                {
                    lat_naziv = lat_imetxt.Text;
                    upit = "SELECT * from Vrsta WHERE Latinski_naziv = '" + lat_naziv + "'; ";

                    bazaKontrol koneksn = new bazaKontrol();
                    koneksn.izvrsiUpit(upit);
                    if (koneksn.reader.HasRows)
                    {
                        MessageBox.Show("Vec Postoji!");
                        koneksn.zatvori();
                    }
                    else
                    {
                        koneksn.zatvori();
                        string lok_n = lok_imetxt.Text;

                        int tri = int.Parse(textBox3.Text);
                        string cet = textBox4.Text;
                        if (which == "Animal")
                        {
                            upit = "INSERT INTO VRSTA (Latinski_naziv, Lokalni_naziv, S_broj_Prstena, Staniste)" +
                                "VALUES ('" + lat_naziv + "', '" + lok_n + "', " + tri + ", '" + cet + "');";
                            bazaKontrol kon = new bazaKontrol();
                            kon.izvrsiUpit(upit);
                            kon.zatvori();

                            popuni();
                            dataGridView1.Refresh();
                        }
                        else
                        {

                            Regex date = new Regex(@"^[0-9]{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$");
                            if (date.IsMatch(cet))
                            {
                                upit = "INSERT INTO VRSTA (Latinski_naziv, Lokalni_naziv, Broj_odluke, Datum_stupanja_odluke)" +
                                "VALUES ('" + lat_naziv + "', '" + lok_n + "', " + tri + ", date('" + cet + "'));";
                                //MessageBox.Show(upit);
                                bazaKontrol kon = new bazaKontrol();
                                kon.izvrsiUpit(upit);
                                kon.zatvori();

                                popuni();
                                dataGridView1.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("Unesite U formatu yyyy-mm-dd!");
                            }
                        }
                    }
                }
                else if (upozorenje.DialogResult == DialogResult.No)
                {
                    upozorenje.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Morate prvo selektovati rekord koji zelite izbrisati", "Upozorenje!");
            }
        }
    }
}
