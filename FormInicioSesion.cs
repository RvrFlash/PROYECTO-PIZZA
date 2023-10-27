using System;
using System.Collections;
using biblioUsuario;
using System.Windows.Forms;

namespace PROYECTO_PIZZA
{
    public partial class PizzaFix : Form
    {
        #region Atributos
        private ArrayList usuarios;
        private Boolean terminar = true;
        private byte index;
        #endregion

        #region Constructor
        public PizzaFix()
        {
            InitializeComponent();
            usuarios = new ArrayList();
            CargarUsuarios();
        }
        #endregion

        #region Métodos
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CargarUsuarios()
        {
            usuarios.Add(new Usuarios("Tony", "eljefe69"));
            usuarios.Add(new Usuarios("Carlotta", "pizzalover4"));
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            foreach (object usuario in usuarios)
            {
                terminar = true;
                Usuarios miUsuario = (Usuarios)usuario;
                if (txtbUsuario.Text == miUsuario.NomUsuario && txtbContraseña.Text == miUsuario.Password)
                {
                    FormPedido miPedido = new FormPedido();
                    miPedido.Show();
                    terminar = false;
                    break;
                }
            }

            if (terminar)
            {
                MessageBox.Show("usuario o contraseña incorrectos");
            }
        }
        #endregion
    }
}
