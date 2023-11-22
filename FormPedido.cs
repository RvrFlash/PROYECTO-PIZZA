using System;
using BibliotecaContabilidad;
using System.Windows.Forms;

namespace PROYECTO_PIZZA
{
    public partial class FormPedido : Form
    {
        #region Atributos
        //Variable que almacena la cantidad y tipo de pizzas en un mismo pedido
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
            if ((miPedido[0] + miPedido[1] + miPedido[2]) < 20)
            {
                miPedido[0] += 1;
                MostrarPedido();
                if(pbPaso1.Visible==false)
                    pbPaso1.Visible = true;
            }
            else
                MessageBox.Show("Se ha alcanzado el límite del inventario");

        }
        private void btnHawaiiana_Click(object sender, EventArgs e)
        {
            if ((miPedido[0] + miPedido[1] + miPedido[2]) < 20)
            {
                miPedido[1] += 1;
                MostrarPedido();
                if (pbPaso1.Visible == false)
                    pbPaso1.Visible = true;
            }
            else
                MessageBox.Show("Se ha alcanzado el límite del inventario");
        }

        private void btnTresCarnes_Click(object sender, EventArgs e)
        {
            if ((miPedido[0] + miPedido[1] + miPedido[2]) < 20)
            {
                miPedido[2] += 1;
                MostrarPedido();
                if (pbPaso1.Visible == false)
                    pbPaso1.Visible = true;
            }
            else
                MessageBox.Show("Se ha alcanzado el límite del inventario");
        }

        //Método que realiza la orden de un pedido e imprime el precio a pagar
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (conta.VerificarStock(miPedido))
            {
                conta.ActualizarStock(miPedido);
                lbPrecioTotal.Text ="$" + conta.Precios(miPedido).ToString() + ".00";
                pbPaso2.Visible = true;
            }
            else
            {
                MessageBox.Show(" Ya no hay suficientes ingredientes");
            }
            conta.Total = 0;
        }

        private void MostrarPedido()
        {
            if (conta.VerificarStock(miPedido))
            {
                lbOrdenPepperoni.Text = miPedido[0].ToString();
                lbOrdenHawaiiana.Text = miPedido[1].ToString();
                lbOrdenTresCarnes.Text = miPedido[2].ToString();
                lbPrecioTotal.Text = "$" + conta.Precios(miPedido).ToString() + ".00";
                conta.Total = 0;
            }
            else
            {
                MessageBox.Show(" Ya no hay suficientes ingredientes");
            }
        }

        //Método que restablece los valores a cero y permite realizar una nueva orden
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
            pbPaso1.Visible = false;
            pbPaso2.Visible = false;
        }

        //Método que despliega la pantalla de contabilidad.
        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            FormContabilidad pantallaConta = new FormContabilidad(conta.TotalPedidos, conta.ConsultarStock());
            pantallaConta.Show();
            this.Hide();
        }
        #endregion
    }
}
