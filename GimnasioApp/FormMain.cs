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

        private DateTime ultimoDiaEjecutado = DateTime.MinValue;

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

            // Actualizar hora en UCInicio si se muestra
            if (ucInicio != null && panelContenido.Controls.Contains(ucInicio))
            {
                ucInicio.ActualizarHora(fechaHora);
            }

            // NUEVO: detectar cambio de fecha
            DateTime hoy = DateTime.Now.Date;

            if (ultimoDiaEjecutado != hoy)
            {
                ultimoDiaEjecutado = hoy;

                // Llamar corte automático del día anterior
                EjecutarCorteFinalAutomatico();
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

        private void LimpiarBotonActivo()
        {
            if (botonActual != null)
            {
                botonActual.BackColor = Color.FromArgb(255, 255, 255); // color original
                botonActual = null;
            }
        }

        private void EjecutarCorteNormalAutomatico(DateTime fecha)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                // 1️⃣ Obtener IdUsuario del último corte registrado
                int idUsuarioUltimo = ObtenerUltimoUsuarioCorte(conn);

                if (idUsuarioUltimo <= 0)
                    return; // No hay cortes previos, no hacer nada

                // 2️⃣ Ventas en efectivo del día
                string query = @"
            SELECT ISNULL(SUM(V.MontoTotal),0)
            FROM Ventas V
            INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
            WHERE 
                V.Anulada = 0
                AND M.Nombre = 'Efectivo'
                AND CONVERT(date, V.FechaCreacion) = @fecha";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                decimal totalEfectivo = Convert.ToDecimal(cmd.ExecuteScalar());

                if (totalEfectivo <= 0)
                    return;

                // 3️⃣ Registrar corte normal automático
                string insert = @"
            INSERT INTO CortesCaja (IdUsuario, MontoTotal, FechaCorte, EfectivoAcumulado)
            VALUES (@idUsuario, @monto, DATEADD(SECOND, -1, DATEADD(DAY, 1, @fecha)), @monto)";

                SqlCommand cmdInsert = new SqlCommand(insert, conn);
                cmdInsert.Parameters.AddWithValue("@idUsuario", idUsuarioUltimo);
                cmdInsert.Parameters.AddWithValue("@monto", totalEfectivo);
                cmdInsert.Parameters.AddWithValue("@fecha", fecha);
                cmdInsert.ExecuteNonQuery();
            }
        }

        private int ObtenerUltimoUsuarioCorte(SqlConnection conn)
        {
            string query = @"
        SELECT TOP 1 IdUsuario
        FROM CortesCaja
        ORDER BY FechaCorte DESC, IdCorte DESC";

            object res = new SqlCommand(query, conn).ExecuteScalar();

            return (res != null && res != DBNull.Value)
                ? Convert.ToInt32(res)
                : -1;
        }


        private void EjecutarCorteFinalAutomatico()
        {
            DateTime ayer = DateTime.Now.AddDays(-1).Date;

            string cs = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                // 1. Verificar si ya hubo corte final ayer
                string check = @"
            SELECT COUNT(*) 
            FROM EstadoCorte 
            WHERE Fecha = @fecha 
              AND CorteFinalHecho = 1";

                SqlCommand cmdCheck = new SqlCommand(check, conn);
                cmdCheck.Parameters.AddWithValue("@fecha", ayer);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (existe > 0)
                {
                    return; // ya había corte final
                }

                // 🔹 Ejecutar corte normal automático del día anterior
                EjecutarCorteNormalAutomatico(ayer);

                // 2. Calcular totales del día anterior

                string qEf = @"
            SELECT ISNULL(SUM(V.MontoTotal), 0)
            FROM Ventas V
            INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
            WHERE 
                V.Anulada = 0 
                AND CONVERT(date, V.FechaCreacion) = @fecha
                AND M.Nombre = 'Efectivo'
                AND (V.IncluidaEnCorteFinal = 0 OR V.IncluidaEnCorteFinal IS NULL)";
                SqlCommand cmdEf = new SqlCommand(qEf, conn);
                cmdEf.Parameters.AddWithValue("@fecha", ayer);
                decimal totalEfectivo = Convert.ToDecimal(cmdEf.ExecuteScalar());

                string qTr = @"
            SELECT ISNULL(SUM(V.MontoTotal), 0)
            FROM Ventas V
            INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
            WHERE 
                V.Anulada = 0 
                AND CONVERT(date, V.FechaCreacion) = @fecha
                AND M.Nombre <> 'Efectivo'
                AND (V.IncluidaEnCorteFinal = 0 OR V.IncluidaEnCorteFinal IS NULL)";
                SqlCommand cmdTr = new SqlCommand(qTr, conn);
                cmdTr.Parameters.AddWithValue("@fecha", ayer);
                decimal totalTransferencia = Convert.ToDecimal(cmdTr.ExecuteScalar());

                decimal totalGeneral = totalEfectivo + totalTransferencia;

                // 3. Insertar corte final
                string insertCorteFinal = @"
            INSERT INTO CorteFinal (FechaCorteFinal, TotalEfectivo, TotalTransferencia)
            VALUES (@F, @Ef, @Tr)";
                SqlCommand cmdInsert = new SqlCommand(insertCorteFinal, conn);
                cmdInsert.Parameters.AddWithValue("@F", ayer);
                cmdInsert.Parameters.AddWithValue("@Ef", totalEfectivo);
                cmdInsert.Parameters.AddWithValue("@Tr", totalTransferencia);
                cmdInsert.ExecuteNonQuery();

                // 4. Marcar ventas del día anterior como incluidas en corte final
                string updateVentas = @"
            UPDATE Ventas
            SET IncluidaEnCorteFinal = 1
            WHERE CONVERT(date, FechaCreacion) = @fecha
                  AND (IncluidaEnCorteFinal = 0 OR IncluidaEnCorteFinal IS NULL)";
                SqlCommand cmdUpd = new SqlCommand(updateVentas, conn);
                cmdUpd.Parameters.AddWithValue("@fecha", ayer);
                cmdUpd.ExecuteNonQuery();

                // 5. Registrar EstadoCorte
                string insertEstado = @"
            INSERT INTO EstadoCorte (Fecha, CorteFinalHecho)
            VALUES (@fecha, 1)";
                SqlCommand cmdEstado = new SqlCommand(insertEstado, conn);
                cmdEstado.Parameters.AddWithValue("@fecha", ayer);
                cmdEstado.ExecuteNonQuery();

                // 6. Reiniciar acumulados en CortesCaja
                string reset = @"
            UPDATE CortesCaja 
            SET EfectivoAcumulado = 0
            WHERE CONVERT(date, FechaCorte) = @fecha";
                SqlCommand cmdReset = new SqlCommand(reset, conn);
                cmdReset.Parameters.AddWithValue("@fecha", ayer);
                cmdReset.ExecuteNonQuery();
            }
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
            // Activar botón Inicio por defecto
            ActivarBoton(btnInicio);

        }

        private void LoadUserControl(UserControl uc, Button boton)
        {
            //NO activar color para botones especiales
            if (boton != btnCorte && boton != btnConfiguracion && boton != btnReportes)
            {
                ActivarBoton(boton);
            }

            uc.Dock = DockStyle.Fill;
            panelContenido.Controls.Clear();
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
            LimpiarBotonActivo();
            LoadUserControl(new UcCorte(idUsuario, rol), btnCorte);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            LimpiarBotonActivo();
            LoadUserControl(new UcConfiguracion(idUsuario, rol), btnConfiguracion);
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
            LimpiarBotonActivo();

            panelContenido.Controls.Clear();
            UcReportes reportes = new UcReportes();
            reportes.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(reportes);
        }

    }
}
