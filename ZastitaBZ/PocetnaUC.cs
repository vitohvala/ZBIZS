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
    public partial class PocetnaUC : UserControl
    {
        public PocetnaUC()
        {
            InitializeComponent();
        }

        private void PocetnaUC_Load(object sender, EventArgs e)
        {
            label2.Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.\n" +
                " Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown\n " +
                "printer took a galley of type and scrambled it to make a type specimen book.\n" +
                " It has survived not only five centuries, but also the leap into electronic typesetting,\n" +
                " remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset \n" +
                "sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like\n" +
                " Aldus PageMaker including versions of Lorem Ipsum.";
        }
    }
}
