using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GimnasioApp
{
    public partial class UcInicio : UserControl
    {

        private int idUsuario;

        public UcInicio(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario; // Guardamos el ID
            dgvAsistencias.CellFormatting += dgvAsistencias_CellFormatting; // ✅ pintar dinámico
            CargarAsistencias();
            CargarVentasDelDia();
        }

        private void dgvAsistencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAsistencias.Columns[e.ColumnIndex].Name == "Membresia" && e.Value != null)
            {
                if (e.Value.ToString() == "VENCIDA")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                }
            }
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            FormAsistencias form = new FormAsistencias(idUsuario);
            form.StartPosition = FormStartPosition.Manual;
            form.OnAsistenciaRegistrada += CargarAsistencias; // 🔹 Refrescar cuando se registre
            form.ShowDialog();
        }

        public void ActualizarHora(string hora)
        {
            lblFechaHoraActualUC.Text = hora;
        }

        private void CargarAsistencias()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ROW_NUMBER() OVER (ORDER BY a.FechaEntrada ASC) AS N,   -- ✅ numeración del día
                            a.IdCliente,                                            -- ✅ mostrar id cliente
                            c.Nombres + ' ' + c.Apellidos AS Cliente, 
                            CASE 
                                WHEN m.FechaFin < CAST(GETDATE() AS DATE) OR m.Activa = 0 
                                    THEN 'VENCIDA' 
                                ELSE p.Nombre 
                            END AS Membresia,
                            a.FechaEntrada
                        FROM Asistencias a
                        INNER JOIN Clientes c ON a.IdCliente = c.IdCliente
                        LEFT JOIN MembresiasCliente m ON a.IdCliente = m.IdCliente 
                            AND m.IdMembresia = (
                                SELECT TOP 1 IdMembresia 
                                FROM MembresiasCliente 
                                WHERE IdCliente = c.IdCliente 
                                ORDER BY FechaFin DESC
                            )
                        LEFT JOIN PlanesMembresia p ON m.IdPlan = p.IdPlan
                        WHERE CAST(a.FechaEntrada AS DATE) = CAST(GETDATE() AS DATE)
                        ORDER BY a.FechaEntrada ASC";


                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAsistencias.DataSource = dt;

                    if (dgvAsistencias.Columns.Contains("N"))
                        dgvAsistencias.Columns["N"].Width = 50;

                    if (dgvAsistencias.Columns.Contains("IdCliente"))
                        dgvAsistencias.Columns["IdCliente"].Width = 80;

                    if (dgvAsistencias.Columns.Contains("Cliente"))
                        dgvAsistencias.Columns["Cliente"].Width = 250;

                    if (dgvAsistencias.Columns.Contains("FechaEntrada"))
                        dgvAsistencias.Columns["FechaEntrada"].Width = 200;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asistencias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentasDelDia()
        {
            try
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            p.Nombre AS Producto,
                            d.Cantidad,
                            v.FechaCreacion
                        FROM Ventas v
                        INNER JOIN DetalleVenta d ON v.IdVenta = d.IdVenta
                        INNER JOIN Productos p ON d.IdProducto = p.IdProducto
                        WHERE 
                            v.Anulada = 0
                            AND CAST(v.FechaCreacion AS DATE) = CAST(GETDATE() AS DATE)
                        ORDER BY v.FechaCreacion DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVentas.DataSource = dt;

                    // Ajustes visuales

                    if (dgvVentas.Columns.Contains("Producto"))
                        dgvVentas.Columns["Producto"].Width = 150;

                    if (dgvVentas.Columns.Contains("Cantidad"))
                        dgvVentas.Columns["Cantidad"].Width = 80;

                    if (dgvVentas.Columns.Contains("FechaCreacion"))
                        dgvVentas.Columns["FechaCreacion"].Width = 180;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar ventas del día: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void UcInicio_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            using (FormVentas form = new FormVentas(idUsuario))
            {
                form.StartPosition = FormStartPosition.Manual;
                form.OnAsistenciaRegistrada += CargarAsistencias; // refresca asistencias
                form.OnVentaRegistrada += CargarVentasDelDia;
                form.ShowDialog(); // se abre como modal y bloquea la ventana principal
            }
        }
    }
}
