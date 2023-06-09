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
    public partial class Upozorenje : Form
    {
        string poruka;
        public Upozorenje()
        {
            InitializeComponent();
        }
        public Upozorenje(String poruka)
        {
            InitializeComponent();
            this.poruka = poruka;
            this.btnDa.DialogResult = DialogResult.Yes;
            this.btnNe.DialogResult = DialogResult.No;

            lblPoruka.Text = poruka.ToString();
        }

        private void Upozorenje_Load(object sender, EventArgs e)
        {

        }
    }
}
