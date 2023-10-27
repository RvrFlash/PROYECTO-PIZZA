namespace BibliotecaUsuario
{
    public class Usuarios
    {
        #region Atributos
        private string nomUsuario;
        private string password;
        #endregion

        #region Constructor
        public Usuarios(string nomUsuario, string password)
        {
            NomUsuario = nomUsuario;
            Password = password;
        }
        #endregion

        #region Propiedades
        public string NomUsuario { get => nomUsuario; set => nomUsuario = value; }
        public string Password { get => password; set => password = value; }
        #endregion
    }
}
