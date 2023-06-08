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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            globalne.form1 = this;
            globalne.panel1 = panel1;

            Logovanje logpanel = new Logovanje();
            PromeniUC.promeniUC(logpanel, globalne.panel1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
