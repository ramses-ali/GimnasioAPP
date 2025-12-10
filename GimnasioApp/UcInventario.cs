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
    public partial class UcInventario : UserControl
    {

        private int idUsuario;
        private string rol;
        public UcInventario(int idUsuario, string rol)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.rol = rol;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;


        private void UcInventario_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;

            // 🔹 Solo los administradores pueden ver el precio y modificarlo
            if (rol != "Administrador")
            {
                rbtnNuevoProducto.Visible = false;
            }

            CargarInventario();

            CargarProductosEnComboBox();

        }

        // Cargar productos al ComboBox
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

        // Evento para registrar cambios (stock y precio)
        private void rbtnRegistrarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un producto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(cmbProductos.SelectedValue);
            bool actualizarStock = false;
            bool actualizarPrecio = false;

            int cantidad = 0;
            decimal precio = 0;

            // 🔹 Verificar si el usuario ingresó cantidad
            if (!string.IsNullOrWhiteSpace(xtxbCantidad.Text))
            {
                if (!int.TryParse(xtxbCantidad.Text, out cantidad))
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                actualizarStock = true;
            }

            if (!actualizarStock && !actualizarPrecio)
            {
                MessageBox.Show("Debes ingresar una cantidad o un precio para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        // 🔹 Actualizar producto
                        string query = "UPDATE Productos SET ";
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.Transaction = tran;

                        if (actualizarStock)
                        {
                            query += "Stock = Stock + @Cantidad";
                            cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        }

                        if (actualizarPrecio)
                        {
                            if (actualizarStock) query += ", ";
                            query += "Precio = @Precio";
                            cmd.Parameters.AddWithValue("@Precio", precio);
                        }

                        query += " WHERE IdProducto = @IdProducto";
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.CommandText = query;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // 🔹 Registrar movimiento de inventario
                            string tipoMovimiento = cantidad >= 0 ? "Entrada" : "Salida";
                            string referencia = actualizarPrecio
                                ? "Actualización de precio"
                                : "Actualización de stock";

                            string queryMov = @"INSERT INTO MovimientosInventario 
                                        (IdProducto, TipoMovimiento, Cantidad, CostoUnitario, Referencia, IdUsuario) 
                                        VALUES (@IdProducto, @TipoMovimiento, @Cantidad, @CostoUnitario, @Referencia, @IdUsuario)";

                            SqlCommand cmdMov = new SqlCommand(queryMov, conn, tran);
                            cmdMov.Parameters.AddWithValue("@IdProducto", idProducto);
                            cmdMov.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento);
                            cmdMov.Parameters.AddWithValue("@Cantidad", actualizarStock ? cantidad : 0);
                            cmdMov.Parameters.AddWithValue("@CostoUnitario", actualizarPrecio ? precio : 0);
                            cmdMov.Parameters.AddWithValue("@Referencia", referencia);
                            cmdMov.Parameters.AddWithValue("@IdUsuario", idUsuario);

                            cmdMov.ExecuteNonQuery();

                            tran.Commit();

                            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarInventario();
                            xtxbCantidad.Clear();
                        }
                        else
                        {
                            tran.Rollback();
                            MessageBox.Show("No se pudo actualizar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exTran)
                    {
                        tran.Rollback();
                        MessageBox.Show("Error al registrar movimiento: " + exTran.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar producto: " + ex.Message);
            }
        }

        private void rbtnNuevoProducto_Click(object sender, EventArgs e)
        {
            using (FormNuevoProducto formNuevo = new FormNuevoProducto())
            {
                if (formNuevo.ShowDialog() == DialogResult.OK)
                {
                    // 🔄 Refresca la lista o combo de productos
                    CargarInventario();
                }
            }
        }

        private Panel CrearTituloSeccion(string texto)
        {
            Panel contenedor = new Panel
            {
                Height = 35, // 🔹 Altura fija para evitar que se solape
                Dock = DockStyle.Top,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 20, 0, 0) // 🔹 Espaciado superior/inferior
            };

            Label lblTitulo = new Label
            {
                Text = texto.ToUpperInvariant(),
                Font = new Font("Century Gothic", 9, FontStyle.Bold),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(20, 8) // 🔹 Posición manual
            };

            // 🔹 Línea divisoria visible justo debajo del texto
            Panel linea = new Panel
            {
                Height = 1,
                Width = contenedor.Width - 40,
                BackColor = Color.LightGray,
                Location = new Point(20, contenedor.Height - 5),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            contenedor.Controls.Add(lblTitulo);
            contenedor.Controls.Add(linea);

            return contenedor;
        }

        private FlowLayoutPanel CrearSubPanel()
        {
            return new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoSize = true,
                Margin = new Padding(10),
                Padding = new Padding(10),
                BackColor = Color.Transparent
            };
        }

        private Panel CrearCardProducto(int id, string nombre, int stock, decimal precio)
        {
            Panel card = new Panel
            {
                Width = 200,
                Height = 130,
                BackColor = Color.White,
                Margin = new Padding(15),  // 🔹 Espaciado entre tarjetas
                Padding = new Padding(10), // 🔹 Espaciado interno
                BorderStyle = BorderStyle.FixedSingle
            };

            // 🔹 Sombra ligera para diseño minimalista
            card.Paint += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                    new Rectangle(3, 3, card.Width - 3, card.Height - 3));
                e.Graphics.FillRectangle(new SolidBrush(Color.White),
                    new Rectangle(0, 0, card.Width - 3, card.Height - 3));
            };

            Label lblNombre = new Label
            {
                Text = nombre,
                Font = new Font("Century Gothic", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblStock = new Label
            {
                Text = "Stock: " + stock,
                Location = new Point(10, 50),
                AutoSize = true
            };

            Label lblPrecio = new Label
            {
                Text = "Precio: $" + precio.ToString("0.00"),
                Location = new Point(10, 80),
                AutoSize = true
            };

            card.Controls.Add(lblNombre);
            card.Controls.Add(lblStock);
            card.Controls.Add(lblPrecio);

            return card;
        }

        private void CargarInventario()
        {
            panelInventario.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IdProducto, Nombre, Stock, Precio FROM Productos WHERE Activo = 1 ORDER BY IdProducto ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                List<(int id, string nombre, int stock, decimal precio)> productos = new();

                while (reader.Read())
                {
                    productos.Add((
                        (int)reader["IdProducto"],
                        reader["Nombre"].ToString(),
                        Convert.ToInt32(reader["Stock"]),
                        Convert.ToDecimal(reader["Precio"])
                    ));
                }

                reader.Close();

                // 🔹 Crear paneles para los dos grupos
                FlowLayoutPanel panelSuperior = CrearSubPanel();
                FlowLayoutPanel panelInferior = CrearSubPanel();

                // 🔹 Separar los productos
                var productosArriba = productos.Take(11);
                var productosAbajo = productos.Skip(11);

                // 🔹 Crear títulos con línea divisora
                Panel tituloSuperior = CrearTituloSeccion("General");
                Panel tituloInferior = CrearTituloSeccion("Otros");

                // 🔹 Agregar tarjetas al panel superior
                foreach (var p in productosArriba)
                    panelSuperior.Controls.Add(CrearCardProducto(p.id, p.nombre, p.stock, p.precio));

                // 🔹 Agregar tarjetas al panel inferior
                foreach (var p in productosAbajo)
                    panelInferior.Controls.Add(CrearCardProducto(p.id, p.nombre, p.stock, p.precio));

                // 🔹 Agregar secciones al panel principal
                panelInventario.Controls.Add(tituloSuperior);
                panelInventario.Controls.Add(panelSuperior);
                panelInventario.Controls.Add(tituloInferior);
                panelInventario.Controls.Add(panelInferior);
            }
        }
    }
}
