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
    public partial class FormAsistencias : Form
    {

        private int idUsuario;

        public event Action OnAsistenciaRegistrada; // 🔹 Evento para notificar al UcInicio
        private bool isUpdating = false; // 🔹 Para evitar loops infinitos

        public FormAsistencias(int idUsuario)
        {
            InitializeComponent();
            CargarNombresAutoComplete();
            this.idUsuario = idUsuario;
        }

        private void CargarNombresAutoComplete()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Nombres + ' ' + Apellidos AS NombreCompleto FROM Clientes";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    AutoCompleteStringCollection nombres = new AutoCompleteStringCollection();

                    while (reader.Read())
                    {
                        nombres.Add(reader["NombreCompleto"].ToString());
                    }

                    txtbNombreAsistencia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtbNombreAsistencia.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtbNombreAsistencia.AutoCompleteCustomSource = nombres;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar nombres: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;
                int idCliente = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 🔹 Si el usuario puso ID
                    if (!string.IsNullOrWhiteSpace(txtbIdAsistencia.Text) && int.TryParse(txtbIdAsistencia.Text, out int id))
                    {
                        idCliente = id;
                    }
                    else if (!string.IsNullOrWhiteSpace(txtbNombreAsistencia.Text))
                    {
                        // 🔹 Buscar cliente por nombre
                        string queryNombre = "SELECT TOP 1 IdCliente FROM Clientes WHERE Nombres + ' ' + Apellidos LIKE @nombre";
                        SqlCommand cmdNombre = new SqlCommand(queryNombre, conn);
                        cmdNombre.Parameters.AddWithValue("@nombre", "%" + txtbNombreAsistencia.Text.Trim() + "%");

                        object result = cmdNombre.ExecuteScalar();
                        if (result != null)
                        {
                            idCliente = Convert.ToInt32(result);
                        }
                    }

                    if (idCliente == 0)
                    {
                        MessageBox.Show("Cliente no encontrado ❌", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 🔹 Insertar asistencia (solo si no existe hoy)
                    string queryCheck = @"SELECT COUNT(*) 
                      FROM Asistencias 
                      WHERE IdCliente = @idCliente 
                      AND CAST(FechaEntrada AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@idCliente", idCliente);

                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Este cliente ya registró asistencia hoy ❌", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 🔹 Insertar asistencia
                    string queryInsert = "INSERT INTO Asistencias (IdCliente) VALUES (@idCliente)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@idCliente", idCliente);
                    cmdInsert.ExecuteNonQuery();
                }

                // 🔹 Disparar evento para refrescar el DataGridView
                OnAsistenciaRegistrada?.Invoke();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar asistencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbNombreAsistencia_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            if (string.IsNullOrWhiteSpace(txtbNombreAsistencia.Text))
            {
                isUpdating = true;
                txtbIdAsistencia.Text = "";
                isUpdating = false;
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT TOP 1 IdCliente 
                                 FROM Clientes 
                                 WHERE Nombres + ' ' + Apellidos LIKE @nombre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", "%" + txtbNombreAsistencia.Text.Trim() + "%");

                    object result = cmd.ExecuteScalar();
                    isUpdating = true;
                    txtbIdAsistencia.Text = result != null ? result.ToString() : "";
                    isUpdating = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtbIdAsistencia_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            if (string.IsNullOrWhiteSpace(txtbIdAsistencia.Text))
            {
                isUpdating = true;
                txtbNombreAsistencia.Text = "";
                isUpdating = false;
                return;
            }

            if (int.TryParse(txtbIdAsistencia.Text.Trim(), out int idCliente))
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "SELECT Nombres + ' ' + Apellidos AS NombreCompleto FROM Clientes WHERE IdCliente = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idCliente);

                        object result = cmd.ExecuteScalar();
                        isUpdating = true;
                        txtbNombreAsistencia.Text = result != null ? result.ToString() : "";
                        isUpdating = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
