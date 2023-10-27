using System;

namespace BibliotecaContabilidad
{
    public class Contabilidad
    {
        #region Atributos
        private byte[] porcionesPepperoni = { 1, 1, 1, 1, 0, 0, 0 };
        private byte[] porcionesHawaiiana = { 1, 1, 1, 0, 0, 1, 1 };
        private byte[] porcionesTresCarnes = { 1, 1, 1, 1, 1, 1, 0 };
        private double total;
        private double[] precios = { 150, 180, 200 };
        private byte[] productosVendidos;
        private byte[] totalPedidos = { 0, 0, 0 };


        //Arreglo unidimensional que contiene el inventario de la tienda en porciones
        //Se suponen porciones suficientes para 10 pizzas
        private int[] stockIngredientes = { 20, 20, 20, 20, 20, 20, 20 };
        private string[] ingredientes = {"Masa", "Salsa de tomate", "Queso", "Pepperoni",
                                          "Carne molida", "Jamón", "Piña"};
        #endregion

        #region Propiedades
        public byte[] ProductosVendidos { get => productosVendidos; set => productosVendidos = value; }
        public int[] StockIngredientes { get => stockIngredientes; set => stockIngredientes = value; }
        public double Total { get => total; set => total = value; }
        public byte[] TotalPedidos { get => totalPedidos; set => totalPedidos = value; }
        #endregion

        #region Métodos

        //Método para calcular el precio a pagar para el cliente
        public double Precios(byte[] pedido)
        {
            for (int i = 0; i < 3; i++)
            {
                Total += pedido[i] * precios[i];
            }

            return Total;
        }

        //Método para vefificar si hay suficientes ingredientes para preparar la Pizza
        public Boolean VerificarStock(byte[] pedido)
        {
            byte[] misPizzas = new byte[7];
            for (int i = 0; i < 7; i++)
            {
                misPizzas[i] = (byte)(pedido[0] * porcionesPepperoni[i]
                    + pedido[1] * porcionesHawaiiana[i]
                    + pedido[1] * porcionesTresCarnes[i]);
            }

            for (int i = 0; i < StockIngredientes.Length; i++)
            {
                if (StockIngredientes[i] - misPizzas[i] <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Método para actualizar el Stock total
        public void ActualizarStock(byte[] pedido)
        {
            TotalPedidos[0] += pedido[0];
            TotalPedidos[1] += pedido[1];
            TotalPedidos[2] += pedido[2];
            byte[] misPizzas = new byte[7];
            for (int i = 0; i < 7; i++)
            {
                misPizzas[i] = (byte)(pedido[0] * porcionesPepperoni[i]
                    + pedido[1] * porcionesHawaiiana[i]
                    + pedido[2] * porcionesTresCarnes[i]);

            }
            for (int i = 0; i < 7; i++)
            {
                StockIngredientes[i] = StockIngredientes[i] - misPizzas[i];
            }
        }

        //Método para consultar el Stock total
        public string[] ConsultarStock()
        {
            string[] mostrarStock = new string[7];
            for (int i = 0; i < StockIngredientes.Length; i++)
            {
                mostrarStock[i] = ingredientes[i] + ": " + stockIngredientes[i].ToString() + "\n";
            }
            return mostrarStock;
        }

        //Método para rellenar el Stock
        /*public void RellenarStock(byte[] nuevoStock)
        {
            for (int i = 0; i < StockIngredientes.Length; i++)
            {
                StockIngredientes[i] = StockIngredientes[i] + nuevoStock[i];
            }
        }*/
        #endregion
    }
}
