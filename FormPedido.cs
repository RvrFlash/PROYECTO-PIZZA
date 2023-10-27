using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_PIZZA
{
    public partial class FormPedido : Form
    {
        public FormPedido()
        {
            InitializeComponent();
        }

        private void pbClose2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
