using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GimnasioApp
{
    public partial class UcCorte : UserControl
    {
        private int idUsuario;
        private string rol;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

        public UcCorte(int idUsuario, string rol)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.rol = rol;
        }

        private void UcCorte_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;

            // Mostrar u ocultar el botón Corte Final según el rol
            if (rol != "Administrador")
            {
                btnCorteFinal.Visible = false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string check = "SELECT COUNT(*) FROM EstadoCorte WHERE Fecha = CONVERT(date, GETDATE()) AND CorteFinalHecho = 1";
                SqlCommand cmd = new SqlCommand(check, conn);
                int cerrado = Convert.ToInt32(cmd.ExecuteScalar());

                if (cerrado > 0)
                {
                    lblTotalCaja.Text = "Efectivo en caja: $0.00";
                    lblTotalVentasGlobal.Text = "Ventas totales del día: $0.00";
                    dgvVentas.DataSource = null;
                    dgvUltimoCorte.DataSource = null;
                    return;
                }
            }

            // Si no está cerrado, carga normalmente
            CargarVentasDelDia();
            CargarUltimoCorte();
            CargarTotalVentasUsuario();
        }

        // Ventas del día actual del usuario logueado
        // Ventas del día actual del usuario logueado + mantener efectivo previo

        private void CargarVentasDelDia()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1) Cargar el grid con TODAS las ventas del día (útil para mostrar)
                string queryVentasGrid = @"
                    SELECT 
                        V.NumeroVenta AS [Folio],
                        M.Nombre AS [Metodo de Pago],
                        V.MontoTotal AS [Monto Total],
                        V.FechaCreacion AS [Fecha],
                        U.NombreUsuario AS [Usuario]
                    FROM Ventas V
                    INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
                    LEFT JOIN UsuariosSistema U ON V.IdUsuario = U.IdUsuario
                    WHERE 
                        V.Anulada = 0
                        AND CONVERT(date, V.FechaCreacion) = CONVERT(date, GETDATE())
                    ORDER BY V.FechaCreacion DESC";
                SqlCommand cmdGrid = new SqlCommand(queryVentasGrid, conn);
                DataTable dt = new DataTable();
                dt.Load(cmdGrid.ExecuteReader());
                dgvVentas.DataSource = dt;

                // 2) Obtener la fecha del último corte (global) — si no hay, usar '1900-01-01'
                string queryUltimoCorteFecha = @"
                    SELECT TOP 1 FechaCorte 
                    FROM CortesCaja
                    ORDER BY FechaCorte DESC, IdCorte DESC";
                SqlCommand cmdUltFecha = new SqlCommand(queryUltimoCorteFecha, conn);
                object oUlt = cmdUltFecha.ExecuteScalar();
                DateTime ultimaFechaCorte = oUlt != null && oUlt != DBNull.Value
                    ? Convert.ToDateTime(oUlt)
                    : DateTime.Parse("1900-01-01");

                // 3) Obtener el acumulado previo (último EfectivoAcumulado registrado)
                string queryAcumulado = @"
                    SELECT TOP 1 EfectivoAcumulado
                    FROM CortesCaja
                    ORDER BY FechaCorte DESC, IdCorte DESC";
                SqlCommand cmdAcum = new SqlCommand(queryAcumulado, conn);
                object resAcum = cmdAcum.ExecuteScalar();
                decimal acumuladoPrevio = resAcum != null && resAcum != DBNull.Value
                    ? Convert.ToDecimal(resAcum)
                    : 0m;

                // 4) Sumar las ventas NUEVAS en EFECTIVO desde la ultimaFechaCorte (coincide con la lógica del corte)
                string queryVentasEfectivo = @"
                    SELECT ISNULL(SUM(V.MontoTotal), 0)
                    FROM Ventas V
                    INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
                    WHERE 
                        V.Anulada = 0
                        AND M.Nombre = 'Efectivo'
                        AND V.FechaCreacion > @ultimaFechaCorte
                        AND (V.IncluidaEnCorteFinal = 0 OR V.IncluidaEnCorteFinal IS NULL)";
                SqlCommand cmdVentasEfectivo = new SqlCommand(queryVentasEfectivo, conn);
                cmdVentasEfectivo.Parameters.AddWithValue("@ultimaFechaCorte", ultimaFechaCorte);
                decimal ventasNuevasEfectivo = Convert.ToDecimal(cmdVentasEfectivo.ExecuteScalar());

                // 5) Mostrar: acumulado previo + ventas nuevas
                decimal efectivoEnCaja = acumuladoPrevio + ventasNuevasEfectivo;
                lblTotalCaja.Text = $"Efectivo en caja: ${efectivoEnCaja:0.00}";
            }
        }

        // Mostrar el último corte realizado (de cualquier usuario)
        private void CargarUltimoCorte()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT TOP 1 
                        C.IdCorte AS [Folio Corte],
                        U.NombreUsuario AS [Usuario],
                        C.MontoTotal AS [Efectivo],
                        C.FechaCorte AS [Fecha]
                    FROM CortesCaja C
                    INNER JOIN UsuariosSistema U ON C.IdUsuario = U.IdUsuario
                    ORDER BY C.FechaCorte DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvUltimoCorte.DataSource = dt;

                if (dgvUltimoCorte.Columns.Contains("Fecha"))
                {
                    dgvUltimoCorte.Columns["Fecha"].Width = 220;
                }
                if (dgvUltimoCorte.Columns.Contains("Usuario"))
                {
                    dgvUltimoCorte.Columns["Usuario"].Width = 180;
                }
            }
        }

        // Mostrar total de ventas del usuario
        // Ventas totales del día (de todos los usuarios)
        private void CargarTotalVentasUsuario()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT ISNULL(SUM(V.MontoTotal), 0)
                    FROM Ventas V
                    WHERE 
                        V.Anulada = 0
                        AND CONVERT(date, V.FechaCreacion) = CONVERT(date, GETDATE())";

                SqlCommand cmd = new SqlCommand(query, conn);
                decimal totalDia = Convert.ToDecimal(cmd.ExecuteScalar());
                lblTotalVentasGlobal.Text = $"Ventas totales del día: ${totalDia:0.00}";
            }
        }

        // Registrar corte (solo usuario actual)
        // Registrar corte (manteniendo efectivo acumulado)
        private void btnHacerCorte_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 🔸 Evitar cortes si ya hay corte final
                string queryCheck = "SELECT COUNT(*) FROM EstadoCorte WHERE Fecha = CONVERT(date, GETDATE()) AND CorteFinalHecho = 1";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                int cerrado = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (cerrado > 0)
                {
                    MessageBox.Show("Ya se realizó el corte final del día.\nNo se pueden hacer más cortes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔸 Obtener acumulado anterior
                decimal acumuladoPrevio = 0;
                string queryPrev = "SELECT TOP 1 EfectivoAcumulado FROM CortesCaja ORDER BY FechaCorte DESC, IdCorte DESC";
                SqlCommand cmdPrev = new SqlCommand(queryPrev, conn);
                object resPrev = cmdPrev.ExecuteScalar();
                if (resPrev != null && resPrev != DBNull.Value)
                    acumuladoPrevio = Convert.ToDecimal(resPrev);

                // 🔸 Obtener fecha del último corte
                DateTime ultimaFechaCorte = new DateTime(1753, 1, 1);

                string queryFecha = "SELECT TOP 1 FechaCorte FROM CortesCaja ORDER BY FechaCorte DESC, IdCorte DESC";
                object resFecha = new SqlCommand(queryFecha, conn).ExecuteScalar();

                if (resFecha != null && resFecha != DBNull.Value)
                {
                    ultimaFechaCorte = Convert.ToDateTime(resFecha);
                }

                // 🔸 Ventas NUEVAS en EFECTIVO
                string queryVentasEfectivo = @"
                    SELECT ISNULL(SUM(V.MontoTotal),0)
                    FROM Ventas V
                    INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
                    WHERE 
                        V.Anulada = 0
                        AND M.Nombre = 'Efectivo'
                        AND V.FechaCreacion > @UltimoCorte";

                SqlCommand cmdVentas = new SqlCommand(queryVentasEfectivo, conn);
                cmdVentas.Parameters.AddWithValue("@UltimoCorte", ultimaFechaCorte);
                decimal nuevasVentasEfectivo = Convert.ToDecimal(cmdVentas.ExecuteScalar());

                // 🔸 Membresías pagadas en EFECTIVO
                string queryMembresiasEfectivo = @"
                    SELECT ISNULL(SUM(PM.Precio),0)
                    FROM MembresiasCliente MC
                    INNER JOIN PlanesMembresia PM ON MC.IdPlan = PM.IdPlan
                    INNER JOIN MetodosPago M ON MC.IdMetodoPago = M.IdMetodoPago
                    WHERE 
                        M.Nombre = 'Efectivo'
                        AND MC.FechaCreacion > @UltimoCorte";

                SqlCommand cmdMembresias = new SqlCommand(queryMembresiasEfectivo, conn);
                cmdMembresias.Parameters.AddWithValue("@UltimoCorte", ultimaFechaCorte);
                decimal nuevasMembresiasEfectivo = Convert.ToDecimal(cmdMembresias.ExecuteScalar());

                // 🔸 Total efectivo nuevo = ventas + membresías
                decimal nuevasEntradasEfectivo = nuevasVentasEfectivo + nuevasMembresiasEfectivo;

                if (nuevasEntradasEfectivo == 0)
                {
                    MessageBox.Show("No hay ventas nuevas en efectivo desde el último corte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 🔸 Nuevo acumulado = acumulado previo + nuevas ventas en efectivo
                decimal nuevoAcumulado = acumuladoPrevio + nuevasEntradasEfectivo;

                // 🔸 Registrar el nuevo corte
                string insert = @"
                    INSERT INTO CortesCaja (IdUsuario, MontoTotal, FechaCorte, EfectivoAcumulado)
                    VALUES (@idUsuario, @monto, GETDATE(), @acumulado)";
                SqlCommand cmdInsert = new SqlCommand(insert, conn);
                cmdInsert.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmdInsert.Parameters.AddWithValue("@monto", nuevasEntradasEfectivo);
                cmdInsert.Parameters.AddWithValue("@acumulado", nuevoAcumulado);
                cmdInsert.ExecuteNonQuery();

                MessageBox.Show($"✅ Corte realizado correctamente.\n\n" +
                                $"Monto nuevo en efectivo: ${nuevasEntradasEfectivo:0.00}\n" +
                                $"Efectivo acumulado: ${nuevoAcumulado:0.00}",
                                "Corte Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarUltimoCorte();
                CargarVentasDelDia();
            }
        }

        private void btnCorteFinal_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                // 🟡 Verificar si ya se hizo el corte final hoy
                string queryCheck = "SELECT COUNT(*) FROM EstadoCorte WHERE Fecha = CONVERT(date, GETDATE()) AND CorteFinalHecho = 1";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, conn);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                if (existe > 0)
                {
                    MessageBox.Show("El corte final del día ya fue realizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 💵 Totales del día
                string queryEfectivo = @"
                    SELECT ISNULL(SUM(V.MontoTotal), 0)
                    FROM Ventas V
                    INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
                    WHERE 
                        V.Anulada = 0 
                        AND CONVERT(date, V.FechaCreacion) = CONVERT(date, GETDATE())
                        AND M.Nombre = 'Efectivo'
                        AND V.IncluidaEnCorteFinal = 0";
                decimal totalEfectivo = Convert.ToDecimal(new SqlCommand(queryEfectivo, conn).ExecuteScalar());

                string queryTransfer = @"
                    SELECT ISNULL(SUM(V.MontoTotal), 0)
                    FROM Ventas V
                    INNER JOIN MetodosPago M ON V.IdMetodoPago = M.IdMetodoPago
                    WHERE 
                        V.Anulada = 0 
                        AND CONVERT(date, V.FechaCreacion) = CONVERT(date, GETDATE())
                        AND M.Nombre <> 'Efectivo'
                        AND V.IncluidaEnCorteFinal = 0";
                decimal totalTransferencia = Convert.ToDecimal(new SqlCommand(queryTransfer, conn).ExecuteScalar());

                decimal totalGeneral = totalEfectivo + totalTransferencia;

                // 🧾 Registrar corte final
                string insertCorteFinal = @"
                    INSERT INTO CorteFinal (TotalEfectivo, TotalTransferencia)
                    VALUES (@TEfectivo, @TTransfer)";
                using (SqlCommand cmdInsert = new SqlCommand(insertCorteFinal, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@TEfectivo", totalEfectivo);
                    cmdInsert.Parameters.AddWithValue("@TTransfer", totalTransferencia);
                    cmdInsert.ExecuteNonQuery();
                }

                // 🔄 Marcar ventas del día como incluidas en el corte final
                string queryUpdate = @"
                    UPDATE Ventas
                    SET IncluidaEnCorteFinal = 1
                    WHERE CONVERT(date, FechaCreacion) = CONVERT(date, GETDATE())
                          AND IncluidaEnCorteFinal = 0";
                new SqlCommand(queryUpdate, conn).ExecuteNonQuery();

                // 🗓 Registrar el estado del corte final
                string insertEstado = "INSERT INTO EstadoCorte (Fecha, CorteFinalHecho) VALUES (CONVERT(date, GETDATE()), 1)";
                new SqlCommand(insertEstado, conn).ExecuteNonQuery();

                // 🔄 Reiniciar efectivo acumulado del día actual a 0
                string resetEfectivo = @"
                    UPDATE CortesCaja 
                    SET EfectivoAcumulado = 0
                    WHERE CONVERT(date, FechaCorte) = CONVERT(date, GETDATE())";
                new SqlCommand(resetEfectivo, conn).ExecuteNonQuery();

                // 📊 Guardar detalle de tipos de venta en memoria antes de insertar
                List<(string categoria, int cantidad, decimal total)> productos = new();
                List<(string categoria, int cantidad, decimal total)> membresias = new();

                // === 🛍 PRODUCTOS ===
                string queryProductos = @"
                    SELECT 
                        ISNULL(P.Categoria, 'Sin categoría') AS Categoria, 
                        COUNT(DISTINCT V.IdVenta) AS CantidadVentas,
                        SUM(DV.Cantidad * DV.PrecioUnitario) AS Total
                    FROM Ventas V
                    INNER JOIN DetalleVenta DV ON V.IdVenta = DV.IdVenta
                    INNER JOIN Productos P ON DV.IdProducto = P.IdProducto
                    WHERE 
                        V.Anulada = 0
                        AND CONVERT(date, V.FechaCreacion) = CONVERT(date, GETDATE())
                    GROUP BY P.Categoria";

                using (SqlCommand cmdProd = new SqlCommand(queryProductos, conn))
                using (SqlDataReader dr = cmdProd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        productos.Add((
                            dr["Categoria"].ToString(),
                            Convert.ToInt32(dr["CantidadVentas"]),
                            Convert.ToDecimal(dr["Total"])
                        ));
                    }
                }

                // === 💪 MEMBRESÍAS ===
                string queryMembresias = @"
                    SELECT 
                        ISNULL(PM.Categoria, 'Sin categoría') AS Categoria,
                        COUNT(MC.IdMembresia) AS CantidadVentas,
                        SUM(PM.Precio) AS Total
                    FROM MembresiasCliente MC
                    INNER JOIN PlanesMembresia PM ON MC.IdPlan = PM.IdPlan
                    WHERE 
                        CONVERT(date, MC.FechaCreacion) = CONVERT(date, GETDATE())
                    GROUP BY PM.Categoria";

                using (SqlCommand cmdMem = new SqlCommand(queryMembresias, conn))
                using (SqlDataReader dr = cmdMem.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        membresias.Add((
                            dr["Categoria"].ToString(),
                            Convert.ToInt32(dr["CantidadVentas"]),
                            Convert.ToDecimal(dr["Total"])
                        ));
                    }
                }

                // 🚀 Insertar después de cerrar los readers
                foreach (var p in productos)
                {
                    string insertTipo = @"
                        INSERT INTO TipoVenta (Fecha, Tipo, Categoria, CantidadVentas, MontoTotal)
                        VALUES (CONVERT(date, GETDATE()), 'Producto', @Categoria, @Cantidad, @Total)";
                    using (SqlCommand cmdInsertProd = new SqlCommand(insertTipo, conn))
                    {
                        cmdInsertProd.Parameters.AddWithValue("@Categoria", p.categoria);
                        cmdInsertProd.Parameters.AddWithValue("@Cantidad", p.cantidad);
                        cmdInsertProd.Parameters.AddWithValue("@Total", p.total);
                        cmdInsertProd.ExecuteNonQuery();
                    }
                }

                foreach (var m in membresias)
                {
                    string insertTipo = @"
                    INSERT INTO TipoVenta (Fecha, Tipo, Categoria, CantidadVentas, MontoTotal)
                    VALUES (CONVERT(date, GETDATE()), 'Membresía', @Categoria, @Cantidad, @Total)";
                    using (SqlCommand cmdInsertMem = new SqlCommand(insertTipo, conn))
                    {
                        cmdInsertMem.Parameters.AddWithValue("@Categoria", m.categoria);
                        cmdInsertMem.Parameters.AddWithValue("@Cantidad", m.cantidad);
                        cmdInsertMem.Parameters.AddWithValue("@Total", m.total);
                        cmdInsertMem.ExecuteNonQuery();
                    }
                }

                // 🧹 Limpiar interfaz
                dgvVentas.DataSource = null;
                dgvUltimoCorte.DataSource = null;
                lblTotalCaja.Text = "Efectivo en caja: $0.00";
                lblTotalVentasGlobal.Text = "Ventas totales del día: $0.00";

                MessageBox.Show($"✅ CORTE FINAL REALIZADO\n\n" +
                                $"Total Efectivo: ${totalEfectivo:0.00}\n" +
                                $"Transferencias: ${totalTransferencia:0.00}\n" +
                                $"Total General: ${totalGeneral:0.00}\n\n" +
                                $"El sistema se reinició para un nuevo día.",
                                "Corte Final", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
