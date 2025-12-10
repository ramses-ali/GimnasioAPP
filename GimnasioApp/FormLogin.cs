using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Security.Cryptography;


namespace GimnasioApp
{
    public partial class FormLogin : Form
    {

        private Database db;

        public static class SesionActual
        {
            public static int IdUsuario { get; set; }
            public static string NombreUsuario { get; set; }
            public static string Rol { get; set; }
        }

        public FormLogin()
        {
            InitializeComponent();
            db = new Database(); // Inicializamos la conexión
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            txtContraseña.PasswordChar = '*';
        }

        private void CircularPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtCorreo.Text.Trim();
            string clave = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.");
                return;
            }

            string claveHash = CalcularSHA256(clave);

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                // 🔹 Incluimos el nombre del rol
                string query = @"
                    SELECT U.IdUsuario, U.NombreUsuario, R.NombreRol 
                    FROM UsuariosSistema U
                    INNER JOIN Roles R ON U.IdRol = R.IdRol
                    WHERE U.NombreUsuario = @usuario 
                      AND U.ClaveHash = @clave 
                      AND U.Estado = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave", claveHash);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int idUsuario = reader.GetInt32(0);
                        string nombreUsuario = reader.GetString(1);
                        string rol = reader.GetString(2);

                        // 🔹 Guardamos la sesión actual
                        SesionActual.IdUsuario = idUsuario;
                        SesionActual.NombreUsuario = nombreUsuario;
                        SesionActual.Rol = rol;

                        // 🔹 Abrimos el form principal
                        FormMain formMain = new FormMain(idUsuario, nombreUsuario, rol);
                        this.Hide();
                        formMain.FormClosed += (s, args) => this.Close();
                        formMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
            }
        }

        // 🔹 Función para generar hash SHA256
        private string CalcularSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToUpper();
            }
        }

    }
}
