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
    public partial class FormEditarCliente : Form
    {
        private int idCliente;

        public FormEditarCliente(int id, string nombre, string apellidos, string telefono)
        {
            InitializeComponent();
            idCliente = id;
            txtNombre.Text = nombre;
            txtApellidos.Text = apellidos;
            txtTelefono.Text = telefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Validar campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
                {
                    MessageBox.Show("Debe ingresar el nombre y los apellidos del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string telefono = txtTelefono.Text.Trim();

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

                    // 🔹 Verificar si ya existe otro cliente con mismos Nombres y Apellidos
                    string checkQuery = @"SELECT COUNT(*) 
                                  FROM Clientes 
                                  WHERE Nombres = @nombres 
                                  AND Apellidos = @apellidos 
                                  AND IdCliente <> @idCliente"; // Excluir el cliente que se está editando

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                        checkCmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                        checkCmd.Parameters.AddWithValue("@idCliente", idCliente);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Ya existe otro cliente con el mismo nombre y apellidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 🔹 Actualizar cliente
                    string query = @"UPDATE Clientes 
                             SET Nombres = @nombres, Apellidos = @apellidos, Telefono = @telefono 
                             WHERE IdCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente actualizado correctamente ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // CONFIRMACIÓN
                DialogResult dr = MessageBox.Show(
                    "¿Seguro que deseas eliminar a este cliente?\n" +
                    "Esta acción no se puede deshacer.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dr != DialogResult.Yes)
                    return;

                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 🔹 Validar membresías del cliente
                    string queryFechaFin = @"
                        SELECT MAX(FechaFin)
                        FROM MembresiasCliente
                        WHERE IdCliente = @idCliente";

                    DateTime hoy = DateTime.Today;
                    DateTime ayer = hoy.AddDays(-1);

                    using (SqlCommand cmdFecha = new SqlCommand(queryFechaFin, conn))
                    {
                        cmdFecha.Parameters.AddWithValue("@idCliente", idCliente);

                        object result = cmdFecha.ExecuteScalar();

                        // CASO 1: Cliente sin ninguna membresía → SE PUEDE ELIMINAR
                        if (result == DBNull.Value)
                        {
                            // No tiene membresías, continuar eliminación
                        }
                        else
                        {
                            DateTime fechaFin = Convert.ToDateTime(result);

                            // CASO 2: Tiene membresía vigente
                            if (fechaFin > ayer)
                            {
                                MessageBox.Show(
                                    $"❌ No se puede eliminar el cliente.\n\n" +
                                    $"Tiene una membresía vigente hasta el {fechaFin:dd/MM/yyyy}.\n" +
                                    $"Solo se permite eliminar clientes sin membresía o con membresía vencida hasta el {ayer:dd/MM/yyyy}.",
                                    "Eliminación bloqueada",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }

                            // CASO 3: Membresía vencida (ayer o antes) → SE PUEDE ELIMINAR
                        }
                    }

                    // Eliminar asistencias
                    string deleteAsistencias = @"
                        DELETE FROM Asistencias
                        WHERE IdCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(deleteAsistencias, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);
                        cmd.ExecuteNonQuery();
                    }

                    // Eliminar membresías del cliente (ya están vencidas o no existen)
                    string deleteMembresias = @"
                        DELETE FROM MembresiasCliente
                        WHERE IdCliente = @idCliente";

                    using (SqlCommand cmdDelMem = new SqlCommand(deleteMembresias, conn))
                    {
                        cmdDelMem.Parameters.AddWithValue("@idCliente", idCliente);
                        cmdDelMem.ExecuteNonQuery();
                    }

                    // ELIMINAR CLIENTE
                    string eliminarQuery = @"DELETE FROM Clientes WHERE IdCliente = @idCliente";

                    using (SqlCommand cmdDel = new SqlCommand(eliminarQuery, conn))
                    {
                        cmdDel.Parameters.AddWithValue("@idCliente", idCliente);
                        cmdDel.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente eliminado correctamente ✅", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
