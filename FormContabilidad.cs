using System;
// using BibliotecaContabilidad;
using System.Windows.Forms;

namespace PROYECTO_PIZZA
{
    public partial class FormContabilidad : Form
    {

        #region Atributos
        //Contabilidad conta2 = new Contabilidad();
        private byte[] porcionesPepperoni = { 1, 1, 1, 1, 0, 0, 0 };
        private byte[] porcionesHawaiiana = { 1, 1, 1, 0, 0, 1, 1 };
        private byte[] porcionesTresCarnes = { 1, 1, 1, 1, 1, 1, 0 };
        private double[] costosIngredientes = { 7.5, 14.25, 34.17, 46.5, 40, 30, 8 };
        private double costoPizza;
        private byte[] stockTotal = new byte[7];
        private double[] precios = { 150, 180, 200 };
        private byte[] totalPedidos = { 0, 0, 0 };
        #endregion
        public FormContabilidad(byte[] pedidos, byte[] stock)
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                totalPedidos[i] = pedidos[i];
            }
            for (int i = 0; i < 7; i++)
            {
                stockTotal[i] = stock[i];
            }
        }

        private void pbClose2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            lbContaPepperoni.Text = totalPedidos[0].ToString();
            lbContaHawaiiana.Text = totalPedidos[1].ToString();
            lbContaTresCarnes.Text = totalPedidos[2].ToString();
            lbGananciaBruta.Text = "$" + GananciaTotal(totalPedidos).ToString();

            lbPorcionesMasa.Text = stockTotal[0].ToString();
            lbPorcionesSalsa.Text = stockTotal[1].ToString();
            lbPorcionesQueso.Text = stockTotal[2].ToString();
            lbPorcionesPepperoni.Text = stockTotal[3].ToString();
            lbPorcionesCarne.Text = stockTotal[4].ToString();
            lbPorcionesJamon.Text = stockTotal[5].ToString();
            lbPorcionesPiña.Text = stockTotal[6].ToString();
        }

        private double GananciaTotal(byte[] pedido)
        {
            byte[] misPizzas = new byte[7];
            for (int i = 0; i < 7; i++)
            {
                misPizzas[i] = (byte)(pedido[0] * porcionesPepperoni[i]
                    + pedido[1] * porcionesHawaiiana[i]
                    + pedido[2] * porcionesTresCarnes[i]);
                costoPizza += misPizzas[i] * costosIngredientes[i];
            }

            return (pedido[0] * precios[0] + pedido[1] * precios[1] + pedido[2] * precios[2]) - costoPizza;
        }


    }
}
