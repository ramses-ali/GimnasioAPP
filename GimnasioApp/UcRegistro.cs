using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GimnasioApp
{
    public partial class UcRegistro : UserControl
    {
        public UcRegistro()
        {
            InitializeComponent();
            // Conecta el evento (puedes hacerlo también en el Load o en el diseñador)
            dgvRegistros.CellFormatting += dgvRegistros_CellFormatting;

            // Asegúrate que el TextChanged del txtbBuscar esté conectado
            txtbBuscar.TextChanged += txtbBuscar_TextChanged;
        }

        private void UcRegistro_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;

            CargarRegistros();

        }

        private void CargarRegistros(string filtro = "")
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    c.IdCliente,
                    c.Nombres,
                    c.Apellidos,
                    c.Telefono,
                    p.Nombre AS Membresia,
                    m.FechaInicio,
                    m.FechaFin
                FROM Clientes c
                LEFT JOIN MembresiasCliente m ON c.IdCliente = m.IdCliente AND m.Activa = 1
                LEFT JOIN PlanesMembresia p ON m.IdPlan = p.IdPlan";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += @" WHERE 
                           c.IdCliente LIKE @filtro
                           OR c.Nombres LIKE @filtro
                           OR c.Apellidos LIKE @filtro
                           OR c.Telefono LIKE @filtro";

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }
                    else
                    {
                        cmd.CommandText = query;
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRegistros.DataSource = dt;

                    // ajustar ancho/formatos de columnas
                    if (dgvRegistros.Columns.Contains("FechaFin"))
                    {
                        dgvRegistros.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvRegistros.Columns["FechaFin"].Width = 120;
                    }
                    if (dgvRegistros.Columns.Contains("Nombres"))
                    {
                        dgvRegistros.Columns["Nombres"].Width = 180;
                    }

                    // agregar columna Acciones si no existe (igual que antes)
                    if (!dgvRegistros.Columns.Contains("Acciones"))
                    {
                        DataGridViewButtonColumn btnAcciones = new DataGridViewButtonColumn();
                        btnAcciones.HeaderText = "Acciones";
                        btnAcciones.Name = "Acciones";
                        btnAcciones.Text = "Editar";
                        btnAcciones.UseColumnTextForButtonValue = true;
                        dgvRegistros.Columns.Add(btnAcciones);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Asegurarnos que la columna existe y estamos en la columna FechaFin
            if (dgvRegistros.Columns.Count == 0) return;
            if (dgvRegistros.Columns[e.ColumnIndex].Name != "FechaFin") return;

            // Si no hay valor lo dejamos en blanco
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
                return;
            }

            DateTime fechaFin;

            // leer el valor (puede venir como DateTime o como string)
            if (e.Value is DateTime dt)
            {
                fechaFin = dt;
            }
            else if (!DateTime.TryParse(e.Value.ToString(), out fechaFin))
            {
                // no es fecha válida: no hacemos nada
                return;
            }

            // Si la fecha ya pasó (strictly < hoy) pintamos en rojo.
            if (fechaFin.Date < DateTime.Today)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font(dgvRegistros.Font, FontStyle.Bold);
            }
            else
            {
                // restaurar estilo por defecto (importante por el reuso de celdas)
                e.CellStyle.ForeColor = dgvRegistros.DefaultCellStyle.ForeColor;
                e.CellStyle.Font = dgvRegistros.DefaultCellStyle.Font;
            }

            // formateo visual de la fecha
            e.Value = fechaFin.ToString("dd/MM/yyyy");
            e.FormattingApplied = true;
        }

        private void dgvRegistros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRegistros.Columns[e.ColumnIndex].Name == "Acciones")
            {
                int idCliente = Convert.ToInt32(dgvRegistros.Rows[e.RowIndex].Cells["IdCliente"].Value);
                string nombre = dgvRegistros.Rows[e.RowIndex].Cells["Nombres"].Value.ToString();
                string apellidos = dgvRegistros.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
                string telefono = dgvRegistros.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();

                using (FormEditarCliente frm = new FormEditarCliente(idCliente, nombre, apellidos, telefono))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // Recargar registros después de editar
                        CargarRegistros(txtbBuscar.Text);
                    }
                }
            }
        }

        private void txtbBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarRegistros(txtbBuscar.Text);
        }

    }
}
