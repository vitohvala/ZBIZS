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
    public partial class valProfil : Form
    {
        public valProfil()
        {
            InitializeComponent();
            textBox1.UseSystemPasswordChar = true;
        }

        private void valProfil_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) {
                if (textBox1.Text == globalne.korisnik.lozinka)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Uneta šifra nije ispravna.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Unesite šifru.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
