using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
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
                if (konekcija.State == ConnectionState.Closed)
                {
                    konekcija.Open();
                }
                //konekcija.Open();
                cmd = new SQLiteCommand(upit, konekcija);
                reader = cmd.ExecuteReader();
               
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void popuni(DataGridView grid, string upit){
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(upit, konekcija);
            DataTable table = new DataTable();
            adapter.FillSchema(table, SchemaType.Source);
            adapter.Fill(table);
            grid.DataSource = table;
        }
        public void puniCombo(ComboBox Box, string upit, string tab) {
            SQLiteCommand komanda = new SQLiteCommand(upit, konekcija);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(komanda);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);

            Box.DataSource = tabela;
            Box.DisplayMember = tab;
        }
        public void zatvori() {
            if (reader != null && !reader.IsClosed)
            {
                reader.Close();
            }

            if (cmd != null)
            {
                cmd.Dispose();
            }

            if (konekcija != null && konekcija.State != ConnectionState.Closed)
            {
                konekcija.Close();
            }
        }

    }
}
