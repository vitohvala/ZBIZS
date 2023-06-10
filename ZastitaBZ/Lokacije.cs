using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZastitaBZ
{
    public partial class Lokacije : UserControl
    {
        public string sqlupit;
        void refresh_dg()
        {
            sqlupit = "SELECT naziv, Latinski_naziv, Lokalni_naziv from Lokacija" +
               " INNER JOIN Vrst_lok on Lokacija.ID = Vrst_lok.idlok" +
               " INNER JOIN Vrsta on Vrsta.Latinski_naziv = Vrst_lok.lat_naziv" +
               " WHERE Lokacija.naziv = '" + globalne.korisnik.okrug + "';";
            bazaKontrol kon = new bazaKontrol();
            kon.popuni(dataGridView1, sqlupit);
            kon.zatvori();
            dataGridView1.Refresh();
        }
        public Lokacije()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;

        }
        private void Application_Idle(object sender, EventArgs e)
        {
            label2.Text = globalne.korisnik.okrug;
        }
        private void Lokacije_Load(object sender, EventArgs e)
        {
            label2.Text = globalne.korisnik.okrug;

            bazaKontrol kon = new bazaKontrol();
            string query = "SELECT naziv FROM Lokacija";
            kon.puniCombo(comboBox1, query, "naziv");
            query = "SELECT Latinski_naziv FROM Vrsta";
            kon.puniCombo(comboBox2, query, "Latinski_naziv");
            kon.zatvori();
            refresh_dg();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)comboBox1.SelectedItem;
            globalne.korisnik.okrug = selectedRow["naziv"].ToString();
            refresh_dg();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = (DataRowView)comboBox2.SelectedItem;
            string lat = selectedRow["Latinski_naziv"].ToString();
            int Id = 0;
            string que = "SELECT ID FROM Lokacija WHERE naziv = '" + globalne.korisnik.okrug + "';";
            bazaKontrol kon = new bazaKontrol();
            kon.izvrsiUpit(que);
            if (kon.reader.Read())
            {
                Id = kon.reader.GetInt32(0);
            }
            kon.zatvori();
            if (lat != null && Id != 0)
            {
                kon = new bazaKontrol();
                sqlupit = "SELECT * FROM Vrst_lok WHERE idlok = " + Id + " AND lat_naziv = '" + lat + "';";
                kon.izvrsiUpit(sqlupit);
                if (kon.reader.HasRows)
                {
                    MessageBox.Show("Vec Postoji");
                }
                else
                {
                    sqlupit = "INSERT INTO Vrst_lok (idlok, lat_naziv)" +
                        " VALUES(" + Id + ", '" + lat + "');";
                    kon.izvrsiUpit(sqlupit);
                    kon.zatvori();
                }
            }
            else {
                MessageBox.Show("Izaberite Sve Vrednosti");
            }
           
            refresh_dg();

        }
        string naziv_t, ime_lat;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                naziv_t = row.Cells[0].Value.ToString();
                ime_lat = row.Cells[1].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlcmd;
            int Id = 0;

            if (naziv_t != null && ime_lat != null)
            {
                DialogResult dialog = new DialogResult();
                Upozorenje upozorenje = new Upozorenje("Da li ste sigurni da želite izbrisati " + ime_lat + "?");
                dialog = upozorenje.ShowDialog();
                if (upozorenje.DialogResult == DialogResult.Yes)
                {
                    sqlcmd = "SELECT ID FROM Lokacija WHERE naziv = '" + globalne.korisnik.okrug + "';";
                    bazaKontrol kon = new bazaKontrol();
                    kon.izvrsiUpit(sqlcmd);
                    if (kon.reader.Read())
                    {
                        Id = kon.reader.GetInt32(0);
                    }
                    sqlcmd = "DELETE FROM Vrst_lok WHERE lat_naziv = '" + ime_lat + "' AND idlok = " + Id + ";";
                    kon.izvrsiUpit(sqlcmd);
                    kon.zatvori();
                    refresh_dg();
                }
                else if (upozorenje.DialogResult == DialogResult.No)
                {
                    upozorenje.Dispose();
                }
            }
            else {
                MessageBox.Show("Izaberite Nesto Iz Rekorda");
            }
        }
    }
}
