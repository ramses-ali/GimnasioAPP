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
    public partial class UcAgregar : UserControl
    {
        public UcAgregar()
        {
            InitializeComponent();
        }

        private void UcAgregar_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;
        }

        private void txtbApellidosCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnRegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrWhiteSpace(txtbNombreCliente.Text) || string.IsNullOrWhiteSpace(txtbApellidosCliente.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre y los apellidos del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar número de teléfono de 10 dígitos
                // 🔹 Teléfono opcional
                string telefono = txtbCelular.Text.Trim();

                if (!string.IsNullOrEmpty(telefono))
                {
                    if (telefono.Length != 10 || !telefono.All(char.IsDigit))
                    {
                        MessageBox.Show("El teléfono debe contener exactamente 10 dígitos.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 🔹 Verificar si ya existe un cliente con mismos Nombres y Apellidos
                    string checkQuery = "SELECT COUNT(*) FROM Clientes WHERE Nombres = @Nombres AND Apellidos = @Apellidos";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Nombres", txtbNombreCliente.Text);
                        checkCmd.Parameters.AddWithValue("@Apellidos", txtbApellidosCliente.Text);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Ya existe un cliente con el mismo nombre y apellidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 🔹 Insertar cliente nuevo
                    string query = "INSERT INTO Clientes (Nombres, Apellidos, Telefono) VALUES (@Nombres, @Apellidos, @Telefono)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", txtbNombreCliente.Text);
                        cmd.Parameters.AddWithValue("@Apellidos", txtbApellidosCliente.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtbCelular.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente registrado correctamente ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el cliente ❌", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
