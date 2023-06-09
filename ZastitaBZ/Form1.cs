using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ZastitaBZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            globalne.form1 = this;
            globalne.panel1 = panel1;
            globalne.newres = Width + 100;
            //this.Width += 100;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Logovanje logpanel = new Logovanje();
            PromeniUC.promeniUC(logpanel, globalne.panel1);
            Application.Idle += Application_Idle;
        }
        private void Application_Idle(object sender, EventArgs e)
        {

            if (globalne.res == true)
            {
                this.Width = globalne.newres;
                globalne.panel1.Width = this.Width;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
