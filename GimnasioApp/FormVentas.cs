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
    public partial class FormVentas : Form
    {

        private int idUsuario;

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

        public event Action OnAsistenciaRegistrada;

        private List<ArticuloAgregado> articulosAgregados = new List<ArticuloAgregado>();

        // 🔹 Clase interna que representa un artículo agregado a la venta
        public class ArticuloAgregado
        {
            public int IdProducto { get; set; }
            public string Nombre { get; set; }
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal => PrecioUnitario * Cantidad;
        }

        public FormVentas(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
        }

        private void FormVentas_Load_1(object sender, EventArgs e)
        {
            CargarMembresias();
            CargarProductos();

            cbxMembresia.SelectedIndexChanged += cbxMembresia_SelectedIndexChanged;

            lblTotalVenta.Text = "$0.00";
        }

        private void cbxMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotalVenta();
        }

        private void CargarMembresias()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IdPlan, Nombre, Precio FROM PlanesMembresia WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                // 🔹 Agregar opción inicial "Seleccionar membresía"
                DataRow filaInicial = dt.NewRow();
                filaInicial["IdPlan"] = 0;
                filaInicial["Nombre"] = "Seleccionar membresía";
                filaInicial["Precio"] = 0;
                dt.Rows.InsertAt(filaInicial, 0);

                cbxMembresia.DataSource = dt;
                cbxMembresia.DisplayMember = "Nombre";
                cbxMembresia.ValueMember = "IdPlan";
                cbxMembresia.SelectedIndex = 0;

                // Opcional: mostrar nombre + precio
                cbxMembresia.Format += (s, e) =>
                {
                    if (e.ListItem is DataRowView row)
                    {
                        e.Value = $"{row["Nombre"]} - ${row["Precio"]}";
                    }
                };
            }
        }

        private void CargarProductos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT IdProducto, Nombre, Precio, Stock FROM Productos WHERE Activo = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                // 🔹 Agregar opción inicial "Seleccionar producto"
                DataRow filaInicial = dt.NewRow();
                filaInicial["IdProducto"] = 0;
                filaInicial["Nombre"] = "Seleccionar producto";
                filaInicial["Precio"] = 0;
                filaInicial["Stock"] = 0;
                dt.Rows.InsertAt(filaInicial, 0);

                cbxArticulo.DataSource = dt;
                cbxArticulo.DisplayMember = "Nombre";
                cbxArticulo.ValueMember = "IdProducto";
                cbxArticulo.SelectedIndex = 0;

                cbxArticulo.Format += (s, e) =>
                {
                    if (e.ListItem is DataRowView row)
                    {
                        e.Value = $"{row["Nombre"]} - ${row["Precio"]}";
                    }
                };
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (cbxArticulo.SelectedValue == null || (int)cbxArticulo.SelectedValue == 0)
            {
                MessageBox.Show("Seleccione un artículo válido.");
                return;
            }

            if (!int.TryParse(txtbCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            int idProducto = (int)cbxArticulo.SelectedValue;
            string nombreArticulo = cbxArticulo.Text;
            decimal precioUnitario = ObtenerPrecioProducto(idProducto);

            // Validar stock
            if (!ValidarStockDisponible(idProducto, cantidad))
            {
                MessageBox.Show("No hay suficiente stock disponible para este producto.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existente = articulosAgregados.FirstOrDefault(a => a.IdProducto == idProducto);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
            }
            else
            {
                articulosAgregados.Add(new ArticuloAgregado
                {
                    IdProducto = idProducto,
                    Nombre = nombreArticulo,
                    Cantidad = cantidad,
                    PrecioUnitario = precioUnitario
                });
            }

            ActualizarListaArticulos();
            ActualizarTotalVenta();
        }

        private bool ValidarStockDisponible(int idProducto, int cantidad)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Stock FROM Productos WHERE IdProducto = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idProducto);
                object o = cmd.ExecuteScalar();
                int stock = o != null && o != DBNull.Value ? Convert.ToInt32(o) : 0;
                return stock >= cantidad;
            }
        }

        private void ActualizarListaArticulos()
        {
            var controlesEliminar = this.Controls.OfType<Control>()
                .Where(c => c.Tag != null && c.Tag.ToString().StartsWith("articulo_"))
                .ToList();

            foreach (var ctrl in controlesEliminar)
                this.Controls.Remove(ctrl);

            int startY = 370;
            int index = 1;

            foreach (var articulo in articulosAgregados)
            {
                Label lbl = new Label
                {
                    Text = $"{index}. {articulo.Nombre} - Cantidad: {articulo.Cantidad} - Subtotal: ${articulo.Subtotal:0.00}",
                    AutoSize = true,
                    Location = new Point(40, startY),
                    Font = new Font("Century Gothic", 9F),
                    Tag = "articulo_lbl_" + articulo.IdProducto
                };

                Button btnEliminar = new Button
                {
                    Text = "X",
                    BackColor = Color.LightCoral,
                    ForeColor = Color.White,
                    Font = new Font("Century Gothic", 8F, FontStyle.Bold),
                    Size = new Size(25, 25),
                    Location = new Point(500, startY - 2),
                    Tag = "articulo_btn_" + articulo.IdProducto
                };

                btnEliminar.Click += (s, e) =>
                {
                    articulosAgregados.RemoveAll(a => a.IdProducto == articulo.IdProducto);
                    ActualizarListaArticulos();
                    ActualizarTotalVenta();
                };

                this.Controls.Add(lbl);
                this.Controls.Add(btnEliminar);

                startY += 30;
                index++;
            }
        }

        private void ActualizarTotalVenta()
        {
            decimal total = articulosAgregados.Sum(a => a.Subtotal);

            int idPlan = 0;
            if (cbxMembresia.SelectedValue != null)
                idPlan = (int)cbxMembresia.SelectedValue;

            if (idPlan != 0)
                total += ObtenerPrecioMembresia(idPlan);

            lblTotalVenta.Text = $" $ {total:0.00}";
        }

        private decimal ObtenerPrecioProducto(int idProducto)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Precio FROM Productos WHERE IdProducto = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idProducto);
                object res = cmd.ExecuteScalar();
                return res == null || res == DBNull.Value ? 0m : Convert.ToDecimal(res);
            }
        }

        private void txtbRecibi_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtbRecibi.Text, out decimal recibido))
            {
                decimal total = articulosAgregados.Sum(a => a.Subtotal);
                int idPlan = 0;
                if (cbxMembresia.SelectedValue != null)
                    idPlan = (int)cbxMembresia.SelectedValue;

                if (idPlan != 0)
                    total += ObtenerPrecioMembresia(idPlan);

                decimal cambio = recibido - total;
                txtbCambio.Text = cambio >= 0 ? cambio.ToString("0.00") : "0.00";
            }
        }

        private decimal ObtenerPrecioMembresia(int idPlan)
        {
            if (idPlan == 0)
                return 0; // 🔹 Si el id es 0 (Seleccionar membresía), no hay precio

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Precio FROM PlanesMembresia WHERE IdPlan = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPlan);

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToDecimal(result);
            }
        }

        private int ObtenerDuracionMembresia(int idPlan)
        {
            if (idPlan == 0) return 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DuracionDias FROM PlanesMembresia WHERE IdPlan = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPlan);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private (int IdMembresia, int IdPlan, DateTime FechaFin) ObtenerMembresiaActivaInfo(int idCliente)
        {
            if (idCliente <= 0) return (0, 0, DateTime.MinValue);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT TOP 1 IdMembresia, IdPlan, FechaFin
                                 FROM MembresiasCliente
                                 WHERE IdCliente = @idCliente
                                 AND Activa = 1
                                 ORDER BY FechaFin DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetDateTime(2)
                        );
                    }
                }
            }
            return (0, 0, DateTime.MinValue);
        }

        private void rbtnRegistrarVenta_Click(object sender, EventArgs e)
        {
            // Permitir vender sin membresía y sin cliente (si hay productos)
            int idCliente = 0;
            if (!string.IsNullOrWhiteSpace(txtbIdVenta.Text) && int.TryParse(txtbIdVenta.Text, out int parsedId))
            {
                idCliente = parsedId;
            }
            else if (!string.IsNullOrWhiteSpace(txtbNombreVenta.Text))
            {
                idCliente = BuscarClientePorNombre(txtbNombreVenta.Text);
            }

            int idPlan = 0;
            if (cbxMembresia.SelectedValue != null)
                idPlan = (int)cbxMembresia.SelectedValue;

            // Validaciones mínimas:
            // - Si no hay cliente y tampoco hay artículos ni membresía -> no permitir
            if (idCliente == 0 && articulosAgregados.Count == 0 && idPlan == 0)
            {
                MessageBox.Show("No hay cliente, ni productos, ni membresía para registrar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si user seleccionó una membresía (idPlan != 0) pero no hay cliente -> requerir cliente
            if (idPlan != 0 && idCliente == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente para vender una membresía.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idMetodoPago = 0;

            if (rbtnEfectivo.Checked)
                idMetodoPago = 1;
            else if (rbtnTransferencia.Checked)
                idMetodoPago = 2;
            /*else if (rbtnTarjeta.Checked)
                idMetodoPago = 3;
            */

            if (idMetodoPago == 0)
            {
                MessageBox.Show("Seleccione un metodo de pago.", "Metodo pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int duracionDias = ObtenerDuracionMembresia(idPlan);
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = (duracionDias == 1 &&
               (cbxMembresia.Text.ToLower().Contains("dia") || cbxMembresia.Text.ToLower().Contains("estudiante")))
                ? fechaInicio.Date
                : fechaInicio.AddDays(duracionDias);

            decimal precioMembresia = idPlan != 0 ? ObtenerPrecioMembresia(idPlan) : 0m;
            decimal totalVenta = precioMembresia + articulosAgregados.Sum(a => a.Subtotal);

            // Validacion para no permitir ventas en $0
            if (totalVenta <= 0)
            {
                MessageBox.Show(
                    "No se puede registrar una venta con total $0.00.\nAgregue al menos un producto o una membresía.",
                    "Venta inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1️⃣ Registrar venta (IdCliente puede ser NULL)
                    string numVenta = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                    string queryVenta = @"INSERT INTO Ventas (NumeroVenta, IdCliente, IdUsuario, MontoTotal, IdMetodoPago) 
                      OUTPUT INSERTED.IdVenta
                      VALUES (@numVenta, @idCliente, @idUsuario, @monto, @metodo)";
                    SqlCommand cmdVenta = new SqlCommand(queryVenta, conn, tran);
                    cmdVenta.Parameters.AddWithValue("@numVenta", numVenta);
                    cmdVenta.Parameters.AddWithValue("@idUsuario", idUsuario);
                    // IdCliente puede ser NULL en la venta:
                    if (idCliente > 0) cmdVenta.Parameters.AddWithValue("@idCliente", idCliente);
                    else cmdVenta.Parameters.AddWithValue("@idCliente", DBNull.Value);
                    cmdVenta.Parameters.AddWithValue("@monto", totalVenta);
                    cmdVenta.Parameters.AddWithValue("@metodo", idMetodoPago);
                    int idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                    // 2️⃣ Membresía: únicamente si se escogió una membresía (idPlan != 0)
                    int? idMembresia = null;
                    if (idPlan != 0)
                    {
                        var membresiaInfo = ObtenerMembresiaActivaInfo(idCliente);

                        // 🔹 Registrar detalle de la membresía vendida
                        string insertDetalleM = @"INSERT INTO DetalleMembresiaVenta
                                (IdVenta, IdPlan, Precio, FechaInicio, FechaFin)
                                VALUES (@v, @p, @precio, @ini, @fin)";

                        SqlCommand cmdDetM = new SqlCommand(insertDetalleM, conn, tran);
                        cmdDetM.Parameters.AddWithValue("@v", idVenta);
                        cmdDetM.Parameters.AddWithValue("@p", idPlan);
                        cmdDetM.Parameters.AddWithValue("@precio", precioMembresia);
                        cmdDetM.Parameters.AddWithValue("@ini", fechaInicio);
                        cmdDetM.Parameters.AddWithValue("@fin", fechaFin);
                        cmdDetM.ExecuteNonQuery();

                        // Si existe membresía y está vigente EN LA FECHA (hoy) -> bloquear renovación
                        if (membresiaInfo.IdMembresia > 0 && membresiaInfo.FechaFin.Date >= DateTime.Today)
                        {
                            MessageBox.Show("El cliente ya tiene una membresía activa vigente.");
                            tran.Rollback();
                            return;
                        }

                        if (membresiaInfo.IdMembresia > 0)
                        {
                            // Renovar (actualizar)
                            string update = @"UPDATE MembresiasCliente SET IdPlan=@plan, IdMetodoPago=@met, FechaInicio=@ini, FechaFin=@fin WHERE IdMembresia=@id";
                            SqlCommand cmdUpd = new SqlCommand(update, conn, tran);
                            cmdUpd.Parameters.AddWithValue("@plan", idPlan);
                            cmdUpd.Parameters.AddWithValue("@met", idMetodoPago);
                            cmdUpd.Parameters.AddWithValue("@ini", fechaInicio);
                            cmdUpd.Parameters.AddWithValue("@fin", fechaFin);
                            cmdUpd.Parameters.AddWithValue("@id", membresiaInfo.IdMembresia);
                            cmdUpd.ExecuteNonQuery();
                            idMembresia = membresiaInfo.IdMembresia;
                        }
                        else
                        {
                            // Insertar nueva membresía
                            string insert = @"INSERT INTO MembresiasCliente (IdCliente, IdPlan, IdMetodoPago, FechaInicio, FechaFin, Activa)
                                              OUTPUT INSERTED.IdMembresia
                                              VALUES (@idC, @idP, @met, @ini, @fin, 1)";
                            SqlCommand cmdIns = new SqlCommand(insert, conn, tran);
                            cmdIns.Parameters.AddWithValue("@idC", idCliente);
                            cmdIns.Parameters.AddWithValue("@idP", idPlan);
                            cmdIns.Parameters.AddWithValue("@met", idMetodoPago);
                            cmdIns.Parameters.AddWithValue("@ini", fechaInicio);
                            cmdIns.Parameters.AddWithValue("@fin", fechaFin);
                            idMembresia = Convert.ToInt32(cmdIns.ExecuteScalar());
                        }
                    }

                    // 3️⃣ Detalle y movimientos (si hay artículos)
                    foreach (var art in articulosAgregados)
                    {
                        string det = @"INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario)
                                       VALUES (@v, @p, @c, @pu)";
                        SqlCommand cmdD = new SqlCommand(det, conn, tran);
                        cmdD.Parameters.AddWithValue("@v", idVenta);
                        cmdD.Parameters.AddWithValue("@p", art.IdProducto);
                        cmdD.Parameters.AddWithValue("@c", art.Cantidad);
                        cmdD.Parameters.AddWithValue("@pu", art.PrecioUnitario);
                        cmdD.ExecuteNonQuery();

                        string stock = "UPDATE Productos SET Stock = Stock - @c WHERE IdProducto=@p";
                        SqlCommand cmdS = new SqlCommand(stock, conn, tran);
                        cmdS.Parameters.AddWithValue("@c", art.Cantidad);
                        cmdS.Parameters.AddWithValue("@p", art.IdProducto);
                        cmdS.ExecuteNonQuery();

                        string mov = @"INSERT INTO MovimientosInventario (IdProducto, TipoMovimiento, Cantidad, CostoUnitario, Referencia, IdUsuario)
                            VALUES (@p, 'Salida', @c, @cu, @ref, @idUsuario)";
                        SqlCommand cmdM = new SqlCommand(mov, conn, tran);
                        cmdM.Parameters.AddWithValue("@p", art.IdProducto);
                        cmdM.Parameters.AddWithValue("@c", art.Cantidad);
                        cmdM.Parameters.AddWithValue("@cu", art.PrecioUnitario);
                        cmdM.Parameters.AddWithValue("@ref", "Venta #" + numVenta);
                        cmdM.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmdM.ExecuteNonQuery();
                    }

                    // 4️⃣ Pagos: pasar IdMembresiaCliente NULL si no hay membresía
                    string pago = @"INSERT INTO Pagos (IdVenta, IdMembresiaCliente, Monto, IdMetodoPago, IdUsuario)
                        VALUES (@v, @m, @mo, @met, @idUsuario)";
                    SqlCommand cmdP = new SqlCommand(pago, conn, tran);
                    cmdP.Parameters.AddWithValue("@v", idVenta);
                    cmdP.Parameters.AddWithValue("@idUsuario", idUsuario);
                    if (idMembresia.HasValue)
                        cmdP.Parameters.AddWithValue("@m", idMembresia.Value);
                    else
                        cmdP.Parameters.AddWithValue("@m", DBNull.Value);
                    cmdP.Parameters.AddWithValue("@mo", totalVenta);
                    cmdP.Parameters.AddWithValue("@met", idMetodoPago);
                    cmdP.ExecuteNonQuery();

                    tran.Commit();
                    OnAsistenciaRegistrada?.Invoke();
                    MessageBox.Show("✅ Venta registrada correctamente. Se actualizó inventario y pago.", "Éxito");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    try { tran.Rollback(); } catch { }
                    MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int BuscarClientePorNombre(string nombre)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 IdCliente FROM Clientes WHERE Nombres + ' ' + ISNULL(Apellidos,'') LIKE @nombre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                var result = cmd.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
        }

        private void txtbNombreVenta_TextChanged_1(object sender, EventArgs e)
        {
            if (!txtbNombreVenta.Focused) return;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 1 IdCliente FROM Clientes WHERE Nombres + ' ' + ISNULL(Apellidos,'') LIKE @nombre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", "%" + txtbNombreVenta.Text + "%");
                var result = cmd.ExecuteScalar();
                txtbIdVenta.Text = result != null ? result.ToString() : "";
            }
        }

        private void txtbIdVenta_TextChanged_1(object sender, EventArgs e)
        {
            if (!txtbIdVenta.Focused) return;
            if (int.TryParse(txtbIdVenta.Text, out int idCliente))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Nombres + ' ' + ISNULL(Apellidos,'') FROM Clientes WHERE IdCliente = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idCliente);
                    var result = cmd.ExecuteScalar();
                    txtbNombreVenta.Text = result != null ? result.ToString() : "";
                }
            }
            else
            {
                txtbNombreVenta.Text = "";
            }
        }
    }
}