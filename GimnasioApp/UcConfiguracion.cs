using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GimnasioApp
{
    public partial class UcConfiguracion : UserControl
    {
        private int idUsuario;
        private string rol;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

        public UcConfiguracion(int idUsuario, string rol)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.rol = rol;
        }

        private void UcConfiguracion_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;

            CargarMembresias();
            CargarRoles();
            CargarUsuarios();
            CargarProductosEnComboBox();
        }

        // ======================
        // 🔹 SECCIÓN MEMBRESÍAS
        // ======================
        private void CargarMembresias()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdPlan, Nombre FROM PlanesMembresia WHERE Activo = 1 ORDER BY Nombre ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbxPreciosMembresias.DisplayMember = "Nombre";
                    cmbxPreciosMembresias.ValueMember = "IdPlan";
                    cmbxPreciosMembresias.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar membresías: " + ex.Message);
            }
        }

        private void rbtnRegistrarPrecio_Click(object sender, EventArgs e)
        {
            if (cmbxPreciosMembresias.SelectedValue == null || string.IsNullOrWhiteSpace(txtbActualizarPrecioMembresias.Text))
            {
                MessageBox.Show("Selecciona una membresía y escribe un nuevo precio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtbActualizarPrecioMembresias.Text, out decimal nuevoPrecio))
            {
                MessageBox.Show("El precio debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE PlanesMembresia SET Precio = @Precio WHERE IdPlan = @IdPlan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Precio", nuevoPrecio);
                    cmd.Parameters.AddWithValue("@IdPlan", cmbxPreciosMembresias.SelectedValue);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Precio de membresía actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbActualizarPrecioMembresias.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar precio: " + ex.Message);
            }
        }

        // ===================
        // 🔹 SECCIÓN USUARIOS
        // ===================
        private void CargarRoles()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdRol, NombreRol FROM Roles WHERE Estado = 1 ORDER BY NombreRol ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbxRol.DisplayMember = "NombreRol";
                    cmbxRol.ValueMember = "IdRol";
                    cmbxRol.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdUsuario, NombreUsuario FROM UsuariosSistema WHERE Estado = 1 ORDER BY NombreUsuario ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbxEliminarUsuario.DisplayMember = "NombreUsuario";
                    cmbxEliminarUsuario.ValueMember = "IdUsuario";
                    cmbxEliminarUsuario.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void rbtnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtbContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtbCorreo.Text) ||
                cmbxRol.SelectedValue == null)
            {
                MessageBox.Show("Completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreUsuario = txtbNombreUsuario.Text.Trim();
            string correo = txtbCorreo.Text.Trim();
            string claveHash = GenerarHash(txtbContraseña.Text.Trim());
            int idRol = Convert.ToInt32(cmbxRol.SelectedValue);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO UsuariosSistema (NombreUsuario, ClaveHash, Correo, IdRol, FechaCreacion, Estado)
                                     VALUES (@NombreUsuario, @ClaveHash, @Correo, @IdRol, GETDATE(), 1)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    cmd.Parameters.AddWithValue("@ClaveHash", claveHash);
                    cmd.Parameters.AddWithValue("@Correo", correo);
                    cmd.Parameters.AddWithValue("@IdRol", idRol);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtbNombreUsuario.Clear();
                    txtbCorreo.Clear();
                    txtbContraseña.Clear();
                    CargarUsuarios();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show("El nombre de usuario ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
        }

        private void rbtnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (cmbxEliminarUsuario.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEliminar = Convert.ToInt32(cmbxEliminarUsuario.SelectedValue);

            DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar este usuario?", "Confirmar eliminación",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE UsuariosSistema SET Estado = 0 WHERE IdUsuario = @IdUsuario";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdUsuario", idEliminar);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message);
            }
        }

        // ================================
        // 🔹 SECCIÓN ACTUALIZAR PRODUCTOS
        // ================================
        private void CargarProductosEnComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT IdProducto, Nombre FROM Productos WHERE Activo = 1 ORDER BY Nombre ASC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    cmbProductos.DisplayMember = "Nombre";
                    cmbProductos.ValueMember = "IdProducto";
                    cmbProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void btnActualizarPrecioInventario_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtbPrecio.Text, out decimal nuevoPrecio) || nuevoPrecio < 0)
            {
                MessageBox.Show("El precio debe ser válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtbCantidadProductos.Text, out int nuevaCantidad) || nuevaCantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        string query = @"UPDATE Productos 
                                 SET Precio = @Precio, Stock = @Stock 
                                 WHERE IdProducto = @IdProducto";

                        SqlCommand cmd = new SqlCommand(query, conn, tran);
                        cmd.Parameters.AddWithValue("@Precio", nuevoPrecio);
                        cmd.Parameters.AddWithValue("@Stock", nuevaCantidad);
                        cmd.Parameters.AddWithValue("@IdProducto", cmbProductos.SelectedValue);
                        cmd.ExecuteNonQuery();

                        // Registrar movimiento
                        string queryMov = @"INSERT INTO MovimientosInventario 
                                    (IdProducto, TipoMovimiento, Cantidad, CostoUnitario, Referencia, IdUsuario)
                                    VALUES (@IdProducto, 'Ajuste', @Cantidad, @Costo, 'Actualización Inventario', @IdUsuario)";

                        SqlCommand cmdMov = new SqlCommand(queryMov, conn, tran);
                        cmdMov.Parameters.AddWithValue("@IdProducto", cmbProductos.SelectedValue);
                        cmdMov.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                        cmdMov.Parameters.AddWithValue("@Costo", nuevoPrecio);
                        cmdMov.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmdMov.ExecuteNonQuery();

                        tran.Commit();
                        MessageBox.Show("Inventario actualizado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exTran)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error en transacción: " + exTran.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        // ========================
        // 🔹 UTILIDAD: HASH CLAVES
        // ========================
        private string GenerarHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private void rbtnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un producto para eliminar.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Seguro que deseas eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Productos SET Activo = 0 WHERE IdProducto = @IdProducto";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdProducto", cmbProductos.SelectedValue);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Producto eliminado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarProductosEnComboBox();
                txtbPrecio.Clear();
                txtbCantidadProductos.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto: " + ex.Message);
            }
        }

        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedValue == null)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Stock, Precio FROM Productos WHERE IdProducto = @IdProducto";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdProducto", cmbProductos.SelectedValue);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtbCantidadProductos.Text = reader["Stock"].ToString();
                        txtbPrecio.Text = reader["Precio"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del producto: " + ex.Message);
            }
        }

        private void cmbxPreciosMembresias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxPreciosMembresias.SelectedValue == null)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Precio FROM PlanesMembresia WHERE IdPlan = @IdPlan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdPlan", cmbxPreciosMembresias.SelectedValue);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        txtbActualizarPrecioMembresias.Text = Convert.ToDecimal(result).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el precio de la membresía: " + ex.Message);
            }
        }
    }
}
