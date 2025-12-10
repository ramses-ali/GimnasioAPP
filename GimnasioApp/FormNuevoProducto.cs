using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GimnasioApp
{
    public partial class FormNuevoProducto : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

        public FormNuevoProducto()
        {
            InitializeComponent();
        }

        private void rbtnAgregarNuevoProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtbNuevoProducto.Text.Trim();
            string stockTexto = txtbStock.Text.Trim();
            string precioTexto = txtbPrecio.Text.Trim();

            // 🔸 Validaciones
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingrese el nombre del producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(stockTexto, out int stock) || stock < 0)
            {
                MessageBox.Show("Ingrese un valor válido para el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(precioTexto, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingrese un valor válido para el precio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Productos (Nombre, Stock, Precio, Categoria) VALUES (@Nombre, @Stock, @Precio, @Categoria)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Stock", stock);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@Categoria", "Producto");

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // 🔹 Esto indica éxito
                            this.Close(); // 🔹 Cierra el formulario
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message);
            }
        }
    }
}
