using System;
using BibliotecaContabilidad;
using System.Windows.Forms;

namespace PROYECTO_PIZZA
{
    public partial class FormPedido : Form
    {
        #region Atributos
        private byte[] miPedido;
        Contabilidad conta = new Contabilidad();
        #endregion

        #region Constructor
        public FormPedido()
        {
            InitializeComponent();
            miPedido = new byte[3];
        }
        #endregion

        #region Métodos
        private void pbClose2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPepperoni_Click(object sender, EventArgs e)
        {
            miPedido[0] += 1;
            MostrarPedido();
        }
        private void btnHawaiiana_Click(object sender, EventArgs e)
        {
            miPedido[1] += 1;
            MostrarPedido();
        }

        private void btnTresCarnes_Click(object sender, EventArgs e)
        {
            miPedido[2] += 1;
            MostrarPedido();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (conta.VerificarStock(miPedido))
            {
                conta.ActualizarStock(miPedido);
                lbPrecioTotal.Text ="$" + conta.Precios(miPedido).ToString() + ".00";
            }
            else
            {
                MessageBox.Show(" Ya no hay suficientes ingredientes");
            }
            conta.Total = 0;
        }

        private void btnNuevaOrden_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                miPedido[i] = 0;
            }
            lbPrecioTotal.Text = "$0";
            lbOrdenPepperoni.Text = "-";
            lbOrdenHawaiiana.Text = "-";
            lbOrdenTresCarnes.Text = "-";
        }
        private void MostrarPedido()
        {
            lbOrdenPepperoni.Text = miPedido[0].ToString();
            lbOrdenHawaiiana.Text = miPedido[1].ToString();
            lbOrdenTresCarnes.Text = miPedido[2].ToString();
        }
        #endregion

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            FormContabilidad pantallaConta = new FormContabilidad(conta.TotalPedidos, conta.ConsultarStock());
            pantallaConta.Show();
        }
    }
}
