using System;
using BibliotecaContabilidad;
using System.Windows.Forms;

namespace PROYECTO_PIZZA
{
    public partial class FormContabilidad : Form
    {

        #region Atributos
        Contabilidad conta2 = new Contabilidad();
        private double[] costosIngredientes = { 7.5, 14.25, 34.17, 46.5, 40, 30, 8 };
        private byte[] stockTotal = new byte[7];
        private double[] precios = { 150, 180, 200 };
        private byte[] totalPedidos = { 0, 0, 0 };

        private Boolean bandera = false;
        #endregion

        #region Constructor
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
        #endregion

        #region Métodos
        private void pbClose2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double[] gastosYGanancias = new double[5];
            if (bandera == false)
            {
                lbContaPepperoni.Text = totalPedidos[0].ToString();
                lbContaHawaiiana.Text = totalPedidos[1].ToString();
                lbContaTresCarnes.Text = totalPedidos[2].ToString();
                gastosYGanancias = Estado(totalPedidos);
                lbVentas.Text = gastosYGanancias[0].ToString();
                lbGastos.Text = gastosYGanancias[1].ToString();
                lbGananciaBruta.Text = gastosYGanancias[2].ToString();
                lbImpuestos.Text = gastosYGanancias[3].ToString();
                lbTotal.Text = gastosYGanancias[4].ToString();

                //lbGananciaBruta.Text = "$" + Estado(totalPedidos).ToString();

                lbPorcionesMasa.Text = stockTotal[0].ToString();
                lbPorcionesSalsa.Text = stockTotal[1].ToString();
                lbPorcionesQueso.Text = stockTotal[2].ToString();
                lbPorcionesPepperoni.Text = stockTotal[3].ToString();
                lbPorcionesCarne.Text = stockTotal[4].ToString();
                lbPorcionesJamon.Text = stockTotal[5].ToString();
                lbPorcionesPiña.Text = stockTotal[6].ToString();
                bandera = true;
            }
            else
                MessageBox.Show("Ya se realizó la contabilidad");
            
        }

        private double[] Estado(byte[] pedido)
        {
            double[] cuentas = new double[5];
            byte[] misPizzas = new byte[7];
            for (int i = 0; i < 7; i++)
            {
                misPizzas[i] = (byte)(pedido[0] * conta2.PorcionesPepperoni[i]
                    + pedido[1] * conta2.PorcionesHawaiiana[i]
                    + pedido[2] * conta2.PorcionesTresCarnes[i]);
                cuentas[1] += misPizzas[i] * costosIngredientes[i];
            }
            cuentas[0] = (pedido[0] * precios[0] + pedido[1] * precios[1] + pedido[2] * precios[2]);
            cuentas[2] = cuentas[0] - cuentas[1];
            cuentas[3] = cuentas[2] * 0.3;
            cuentas[4] = cuentas[2]-cuentas[3];
            return cuentas;
        }
        #endregion

    }
}
