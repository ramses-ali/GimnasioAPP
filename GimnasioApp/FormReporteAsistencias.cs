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

namespace GimnasioApp
{
    public partial class FormReporteAsistencias : Form
    {
        public FormReporteAsistencias()
        {
            InitializeComponent();
        }

        private void FormReporteAsistencias_Load(object sender, EventArgs e)
        {
            CargarDias();

            dgvAsistencias.AutoGenerateColumns = false;
            dgvAsistencias.AllowUserToAddRows = false;
            dgvAsistencias.ReadOnly = true;

            ConfigurarGrid();

            cbxFecha.SelectedIndexChanged += cbxFecha_SelectedIndexChanged;

            this.StartPosition = FormStartPosition.Manual;

            // Ajusta estos valores a tu gusto
            this.Left = 250;
            this.Top = 120;
        }

            string connectionString = ConfigurationManager
        .ConnectionStrings["ConnectionGymDB"].ConnectionString;


        private void CargarDias()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT DISTINCT CAST(FechaEntrada AS DATE) AS Dia
                         FROM Asistencias
                         ORDER BY Dia DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cbxFecha.DataSource = dt;
                cbxFecha.DisplayMember = "Dia";
                cbxFecha.ValueMember = "Dia";
            }
        }

        private void cbxFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFecha.SelectedValue != null)
            {
                DateTime dia = Convert.ToDateTime(cbxFecha.SelectedValue);
                CargarAsistenciasPorDia(dia);
            }
        }

        private void CargarAsistenciasPorDia(DateTime dia)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT 
                        a.IdCliente,
                        c.Nombres + ' ' + ISNULL(c.Apellidos,'') AS Cliente,
                        a.FechaEntrada
                    FROM Asistencias a
                    INNER JOIN Clientes c ON a.IdCliente = c.IdCliente
                    WHERE a.FechaEntrada >= @inicio
                      AND a.FechaEntrada < @fin
                    ORDER BY a.FechaEntrada";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@inicio", dia.Date);
                cmd.Parameters.AddWithValue("@fin", dia.Date.AddDays(1));

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                dgvAsistencias.DataSource = dt;

                // 🔹 Numerar filas (columna N)
                for (int i = 0; i < dgvAsistencias.Rows.Count; i++)
                {
                    dgvAsistencias.Rows[i].Cells["colN"].Value = i + 1;
                }

                // 🔹 Mostrar total del día
                lblTotalAsistencias.Text = $"{dt.Rows.Count}";
            }
        }

        private void ConfigurarGrid()
        {
            dgvAsistencias.Columns.Clear();

            // 🔹 Columna N (contador)
            DataGridViewTextBoxColumn colN = new DataGridViewTextBoxColumn();
            colN.HeaderText = "N";
            colN.Name = "colN";
            colN.Width = 50;
            colN.ReadOnly = true;
            dgvAsistencias.Columns.Add(colN);

            // 🔹 Id Cliente
            DataGridViewTextBoxColumn colIdCliente = new DataGridViewTextBoxColumn();
            colIdCliente.HeaderText = "ID Cliente";
            colIdCliente.DataPropertyName = "IdCliente";
            colIdCliente.Width = 120;
            dgvAsistencias.Columns.Add(colIdCliente);

            // 🔹 Cliente
            DataGridViewTextBoxColumn colCliente = new DataGridViewTextBoxColumn();
            colCliente.HeaderText = "Cliente";
            colCliente.DataPropertyName = "Cliente";
            colCliente.Width = 400;
            dgvAsistencias.Columns.Add(colCliente);

            // 🔹 Fecha entrada
            DataGridViewTextBoxColumn colFecha = new DataGridViewTextBoxColumn();
            colFecha.HeaderText = "Fecha de entrada";
            colFecha.DataPropertyName = "FechaEntrada";
            colFecha.Width = 250;
            dgvAsistencias.Columns.Add(colFecha);
        }

    }
}
