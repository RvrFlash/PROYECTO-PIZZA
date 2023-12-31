﻿using System;
using System.Collections;
using BibliotecaUsuario;
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
                    this.Hide();
                    terminar = false;
                    break;
                }
                if (string.IsNullOrEmpty(txtbUsuario.Text) || string.IsNullOrEmpty(txtbContraseña.Text))
                {
                    MessageBox.Show("Favor de llenar todos los campos");
                    terminar = false;
                    break;
                }
            }

            if (terminar)
            {
                MessageBox.Show("Usuario y/o contraseña incorrecta");
            }
        }
        #endregion
    }
}
