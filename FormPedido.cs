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
        private Boolean m = false;
        #endregion

        #region Constructor
        public FormPedido()
        {
            InitializeComponent();
            miPedido = new byte[3];
        }

        public FormPedido(byte[] totalPedidos)
        {
            InitializeComponent();
            miPedido = new byte[3];
            conta.ActualizarStock(totalPedidos);
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
                if(pbPaso1.Visible == false)
                    pbPaso1.Visible = true;
            }
            else
            {
                MessageBox.Show("Se ha alcanzado el límite del inventario");
                pbPaso1.Visible = false;
            }
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
            {
                MessageBox.Show("Se ha alcanzado el límite del inventario");
                pbPaso1.Visible = false;
            }
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
            {
                MessageBox.Show("Se ha alcanzado el límite del inventario");
                pbPaso1.Visible = false;
            }
        }

        //Método que realiza la orden de un pedido e imprime el precio a pagar
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (miPedido[0] + miPedido[1] + miPedido[2] != 0)
            {
                if (conta.VerificarStock(miPedido))
                {
                    conta.ActualizarStock(miPedido);
                    lbPrecioTotal.Text = "$" + conta.Precios(miPedido).ToString() + ".00";
                    pbPaso2.Visible = true;
                    MessageBox.Show("El pedido se realizó de forma exitosa");
                }
                else
                {
                    MessageBox.Show(" Ya no hay suficientes ingredientes");
                }
                conta.Total = 0;
            }
            else
                MessageBox.Show("Debes agregar al menos un producto");
            
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
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            m = true;
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (m)
                this.Location = Cursor.Position;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            m = false;
        }
        #endregion
    }
}
