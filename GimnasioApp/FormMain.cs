using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GimnasioApp.FormLogin;
using FormsTimer = System.Windows.Forms.Timer;



namespace GimnasioApp
{
    public partial class FormMain : Form
    {

        private int idUsuario;
        private string nombreUsuario;
        private string rol;

        private UcInicio ucInicio; // guardamos referencia global
        public string HoraActual => lblFechaHoraActual.Text;

        public FormMain(int idUsuario, string nombreUsuario, string rol)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.rol = rol;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string fechaHora = DateTime.Now.ToString("dd/MM/yyyy      HH:mm");
            lblFechaHoraActual.Text = fechaHora;

            if (ucInicio != null && panelContenido.Controls.Contains(ucInicio))
            {
                ucInicio.ActualizarHora(fechaHora);
            }
        }

        private Button botonActual = null;

        private void ActivarBoton(Button boton)
        {
            // Restaurar color del botón anterior
            if (botonActual != null)
                botonActual.BackColor = Color.FromArgb(255, 255, 255);

            // Activar nuevo botón
            boton.BackColor = Color.FromArgb(205, 205, 205); // gris
            botonActual = boton;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load_1(object sender, EventArgs e)
        {
            ucInicio = new UcInicio(idUsuario);
            ucInicio.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(ucInicio);

            FormsTimer timer = new FormsTimer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();

            lblUsuario.Text = nombreUsuario;

            lblUsuario.Text = $"{FormLogin.SesionActual.NombreUsuario} ({FormLogin.SesionActual.Rol})";

            //Ocultamos por defecto
            btnReportes.Visible = false;
            btnConfiguracion.Visible = false;

            //Si el rol del usuario logueado es Administrador, mostrarlo
            if (FormLogin.SesionActual.Rol == "Administrador")
            {
                btnReportes.Visible = true;
                btnConfiguracion.Visible = true;
            }
        }

        private void LoadUserControl(UserControl uc, Button boton)
        {
            ActivarBoton(boton);
            uc.Dock = DockStyle.Fill;   // ocupa todo el panel
            panelContenido.Controls.Clear(); // limpia lo que había
            panelContenido.Controls.Add(uc);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcAgregar(), btnAgregar);
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcRegistro(), btnRegistro);
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcInventario(idUsuario, rol), btnInventario);
        }

        private void btnCorte_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcCorte(idUsuario, rol), btnAgregar);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UcConfiguracion(idUsuario, rol), btnAgregar);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ActivarBoton(btnInicio);
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(ucInicio); // volvemos a mostrar el mismo UC

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString))
            {
                conn.Open();

                // 🔹 Verificar si el usuario tiene ventas SIN incluir en su último corte
                string queryPendientes = @"
            SELECT COUNT(*) 
            FROM Ventas V
            WHERE 
                V.IdUsuario = @idUsuario
                AND V.Anulada = 0
                AND CONVERT(date, V.FechaCreacion) = CONVERT(date, GETDATE())
                AND V.FechaCreacion > ISNULL(
                    (SELECT TOP 1 FechaCorte 
                     FROM CortesCaja 
                     WHERE IdUsuario = @idUsuario 
                     ORDER BY FechaCorte DESC),
                    '1900-01-01')";

                SqlCommand cmd = new SqlCommand(queryPendientes, conn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                int pendientes = Convert.ToInt32(cmd.ExecuteScalar());

                if (pendientes > 0)
                {
                    MessageBox.Show("No puede cerrar sesión porque tiene ventas pendientes de corte.\nPor favor, realice el corte antes de cerrar sesión.",
                                    "Corte pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Bloquear cierre de sesión
                }
            }

            // ✅ Si no hay ventas pendientes, permitir cerrar sesión normalmente
            DialogResult result = MessageBox.Show(
                "¿Cerrar sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                FormLogin login = new FormLogin();
                login.Show();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            UcReportes reportes = new UcReportes();
            reportes.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(reportes);
        }

    }
}
