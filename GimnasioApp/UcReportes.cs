using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GimnasioApp
{
    public partial class UcReportes : UserControl
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;

        public UcReportes()
        {
            InitializeComponent();

            cmbDias.SelectedIndexChanged += cmbDias_SelectedIndexChanged;
            cmbCortes.SelectedIndexChanged += cmbCortes_SelectedIndexChanged;

            // Inicializar vistas
            CargarDiasConCorteFinal();
            // Si quieres que al abrir muestre hoy (si hay corte final hoy), descomenta:
            // if (cmbDias.Items.Count > 0) cmbDias.SelectedIndex = 0;
        }

        private void UcReportes_Load(object sender, EventArgs e)
        {
            lblFechaHoraActualUC.Text = ((FormMain)this.ParentForm).lblFechaHoraActual.Text;
        }

        // ---------------------------------------
        // UTIL: convierte objeto a decimal seguro
        // ---------------------------------------
        private decimal ToDecimalSafe(object o)
        {
            if (o == null || o == DBNull.Value) return 0m;
            return Convert.ToDecimal(o);
        }

        // ---------------------------------------
        // 1) CARGAR DÍAS (con CorteFinal) en cmbDias
        // ---------------------------------------
        private void CargarDiasConCorteFinal()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"
                    SELECT DISTINCT CONVERT(date, FechaCorteFinal) AS Dia
                    FROM CorteFinal
                    ORDER BY Dia DESC";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDias.DataSource = dt;
                cmbDias.DisplayMember = "Dia";
                cmbDias.ValueMember = "Dia";
                if (dt.Rows.Count > 0)
                {
                    cmbDias.SelectedIndex = 0;
                    // Se disparará cmbDias_SelectedIndexChanged
                }
            }
        }

        private void CargarDias()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT DISTINCT CONVERT(date, FechaCorteFinal) AS Dia
            FROM CorteFinal
            ORDER BY Dia DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDias.DisplayMember = "Dia";
                cmbDias.ValueMember = "Dia";
                cmbDias.DataSource = dt;
            }
        }

        // ---------------------------------------
        // 2) CUANDO SELECCIONAS UN DÍA: cargar CorteCaja del día y resumen general del día
        // ---------------------------------------
        private void cmbDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDias.SelectedValue == null) return;

            if (cmbDias.SelectedValue is DataRowView drv)
            {
                // Obtiene el valor real desde la fila
                DateTime dia = Convert.ToDateTime(drv["Dia"]);
                CargarCortesDelDia(dia);
                CargarResumenGeneral(dia);
                CargarTablaGeneralDia(dia);
                return;
            }

            // Si ya es un DateTime normal
            DateTime selectedDia = Convert.ToDateTime(cmbDias.SelectedValue);
            CargarCortesDelDia(selectedDia);
            CargarResumenGeneral(selectedDia);
            CargarTablaGeneralDia(selectedDia);
        }

        // ---------------------------------------
        // 3) CARGAR CORTES (CortesCaja) de un día en cmbCortes
        // ---------------------------------------
        private void CargarCortesDelDia(DateTime dia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"
            SELECT 
                c.IdCorte,
                c.FechaCorte,
                u.NombreUsuario AS Usuario
            FROM CortesCaja c
            INNER JOIN UsuariosSistema u ON c.IdUsuario = u.IdUsuario
            WHERE CONVERT(date, c.FechaCorte) = @Dia
            ORDER BY c.FechaCorte ASC";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Dia", dia.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔹 Columna combinada (para que muestre fecha + usuario)
                dt.Columns.Add("Mostrar", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    DateTime fecha = Convert.ToDateTime(row["FechaCorte"]);
                    string usuario = row["Usuario"].ToString();

                    row["Mostrar"] = $"{fecha:dd/MM/yyyy HH:mm} - {usuario}";
                }

                cmbCortes.DisplayMember = "Mostrar";
                cmbCortes.ValueMember = "IdCorte";
                cmbCortes.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    cmbCortes.SelectedIndex = 0;
                }
                else
                {
                    dgvProductos.DataSource = null;
                    dgvMembresias.DataSource = null;
                }
            }
        }


        // ---------------------------------------
        // 4) AL CAMBIAR DE CORTE: determino rango y cargo reportes por corte
        // ---------------------------------------
        private void cmbCortes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCortes.SelectedValue == null) return;

            int idCorteActual = Convert.ToInt32(cmbCortes.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Obtener fecha del corte actual
                DateTime fechaActual;
                string q1 = "SELECT FechaCorte FROM CortesCaja WHERE IdCorte = @Id";
                using (SqlCommand c1 = new SqlCommand(q1, con))
                {
                    c1.Parameters.AddWithValue("@Id", idCorteActual);
                    object o = c1.ExecuteScalar();
                    if (o == null || o == DBNull.Value) return;
                    fechaActual = Convert.ToDateTime(o);
                }

                // Obtener fecha del corte anterior del mismo día (si existe)
                DateTime fechaInicio;
                string q2 = @"
                    SELECT TOP 1 FechaCorte 
                    FROM CortesCaja 
                    WHERE FechaCorte < @FechaActual
                      AND CONVERT(date, FechaCorte) = CONVERT(date, @FechaActual)
                    ORDER BY FechaCorte DESC";
                using (SqlCommand c2 = new SqlCommand(q2, con))
                {
                    c2.Parameters.AddWithValue("@FechaActual", fechaActual);
                    object o2 = c2.ExecuteScalar();
                    if (o2 == null || o2 == DBNull.Value)
                    {
                        // si no hay corte anterior, inicio = inicio del día (00:00:00)
                        fechaInicio = fechaActual.Date; // midnight del mismo día
                    }
                    else
                    {
                        // empezamos justo después del corte anterior
                        DateTime prev = Convert.ToDateTime(o2);
                        fechaInicio = prev; // inclusive prev? consider sales > prev; usaremos >= inicio (prev) and < fechaActual
                    }
                }

                // Para nuestras consultas usaremos:
                // Inicio = fechaInicio (inclusive)
                // Fin = fechaActual (inclusive/exclusive según consultas)
                // Para capturar las ventas entre (prevCut, thisCut] podemos usar FechaCreacion > prev AND FechaCreacion <= actual
                DateTime inicio = fechaInicio;
                DateTime fin = fechaActual;

                // Cargar productos / membresias / totales para este corte
                CargarProductosPorCorte(inicio, fin);
                CargarMembresiasPorCorte(inicio, fin);
                CargarTotalesPorCorte(inicio, fin);
            }
        }

        // ---------------------------------------
        // 5) CARGAR PRODUCTOS VENDIDOS ENTRE inicio (excl) y fin (incl)
        // ---------------------------------------
        private void CargarProductosPorCorte(DateTime inicio, DateTime fin)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"
                    SELECT 
                        P.Nombre AS Producto,
                        SUM(DV.Cantidad) AS Cantidad,
                        SUM(DV.Cantidad * DV.PrecioUnitario) AS Total
                    FROM Ventas V
                    INNER JOIN DetalleVenta DV ON DV.IdVenta = V.IdVenta
                    INNER JOIN Productos P ON P.IdProducto = DV.IdProducto
                    WHERE V.Anulada = 0
                      AND V.FechaCreacion > @Inicio
                      AND V.FechaCreacion <= @Fin
                    GROUP BY P.Nombre
                    ORDER BY Total DESC";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Inicio", inicio);
                cmd.Parameters.AddWithValue("@Fin", fin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProductos.DataSource = dt;
            }
        }

        // ---------------------------------------
        // 6) CARGAR MEMBRESIAS VENDIDAS ENTRE inicio (excl) y fin (incl)
        // ---------------------------------------
        private void CargarMembresiasPorCorte(DateTime inicio, DateTime fin)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"
            SELECT 
                PM.Nombre AS Membresia,
                COUNT(*) AS Cantidad,
                SUM(DMV.Precio) AS Total
            FROM DetalleMembresiaVenta DMV
            INNER JOIN PlanesMembresia PM ON PM.IdPlan = DMV.IdPlan
            INNER JOIN Ventas V ON V.IdVenta = DMV.IdVenta
            WHERE V.FechaCreacion > @Inicio
              AND V.FechaCreacion <= @Fin
              AND V.Anulada = 0
            GROUP BY PM.Nombre
            ORDER BY Total DESC";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Inicio", inicio);
                cmd.Parameters.AddWithValue("@Fin", fin);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMembresias.DataSource = dt;
            }
        }

        // ---------------------------------------
        // 7) Totales por método de pago y resumen del corte
        // ---------------------------------------
        private void CargarTotalesPorCorte(DateTime inicio, DateTime fin)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = @"
                    SELECT M.Nombre AS MetodoPago, ISNULL(SUM(V.MontoTotal),0) AS Total
                    FROM Ventas V
                    INNER JOIN MetodosPago M ON M.IdMetodoPago = V.IdMetodoPago
                    WHERE V.Anulada = 0
                      AND V.FechaCreacion > @Inicio
                      AND V.FechaCreacion <= @Fin
                    GROUP BY M.Nombre
                    ORDER BY Total DESC";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@Inicio", inicio);
                    cmd.Parameters.AddWithValue("@Fin", fin);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);

                    // Puedes mostrar este dt en un grid o consolidarlo en labels.
                    // Aquí por simplicidad, se muestra en la consola de depuración y en un MessageBox resumido.
                    decimal total = 0m;
                    foreach (DataRow r in dt.Rows)
                    {
                        total += ToDecimalSafe(r["Total"]);
                    }

                    // Si quieres mostrar un resumen emergente:
                    // (Descomenta si deseas)
                    // string msg = $"Totales por método en este corte:\n";
                    // foreach (DataRow r in dt.Rows) msg += $"{r["MetodoPago"]}: ${ToDecimalSafe(r["Total"]):0.00}\n";
                    // MessageBox.Show(msg, "Resumen Corte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ---------------------------------------
        // 8) CARGAR RESUMEN GENERAL DEL DÍA (totales)
        // ---------------------------------------
        private void CargarResumenGeneral(DateTime dia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // ------------------ TOTAL PRODUCTOS --------------------
                string qProd = @"
            SELECT ISNULL(SUM(DV.Cantidad * DV.PrecioUnitario),0)
            FROM Ventas V
            INNER JOIN DetalleVenta DV ON DV.IdVenta = V.IdVenta
            WHERE V.Anulada = 0
              AND CONVERT(date, V.FechaCreacion) = @Dia";
                using (SqlCommand c = new SqlCommand(qProd, con))
                {
                    c.Parameters.AddWithValue("@Dia", dia.Date);
                    txtTotalProductos.Text = ToDecimalSafe(c.ExecuteScalar()).ToString("0.00");
                }

                // ------------------ TOTAL MEMBRESÍAS --------------------
                string qMem = @"
            SELECT ISNULL(SUM(DMV.Precio),0)
            FROM DetalleMembresiaVenta DMV
            INNER JOIN Ventas V ON V.IdVenta = DMV.IdVenta
            WHERE CONVERT(date, V.FechaCreacion) = @Dia
              AND V.Anulada = 0";
                using (SqlCommand c = new SqlCommand(qMem, con))
                {
                    c.Parameters.AddWithValue("@Dia", dia.Date);
                    txtTotalMembresias.Text = ToDecimalSafe(c.ExecuteScalar()).ToString("0.00");
                }

                // ------------------ TOTAL EFECTIVO EN CORTES --------------------
                string qEfectivoCortes = @"
            SELECT ISNULL(SUM(MontoTotal),0)
            FROM CortesCaja
            WHERE CONVERT(date, FechaCorte) = @Dia";
                using (SqlCommand c = new SqlCommand(qEfectivoCortes, con))
                {
                    c.Parameters.AddWithValue("@Dia", dia.Date);
                    txtTotalEfectivo.Text = ToDecimalSafe(c.ExecuteScalar()).ToString("0.00");
                }

                // ------------------ TOTAL TRANSFERENCIA --------------------
                string qTransfer = @"
            SELECT ISNULL(SUM(V.MontoTotal),0)
            FROM Ventas V
            INNER JOIN MetodosPago M ON M.IdMetodoPago = V.IdMetodoPago
            WHERE CONVERT(date, V.FechaCreacion) = @Dia
              AND V.Anulada = 0
              AND M.Nombre = 'Transferencia'";

                using (SqlCommand c = new SqlCommand(qTransfer, con))
                {
                    c.Parameters.AddWithValue("@Dia", dia.Date);
                    txtTotalTransferencia.Text = ToDecimalSafe(c.ExecuteScalar()).ToString("0.00");
                }

                // ------------------ TOTAL GENERAL DEL DÍA --------------------
                string qGeneral = @"
            SELECT ISNULL(SUM(V.MontoTotal),0)
            FROM Ventas V
            WHERE CONVERT(date, V.FechaCreacion) = @Dia
              AND V.Anulada = 0";

                using (SqlCommand c = new SqlCommand(qGeneral, con))
                {
                    c.Parameters.AddWithValue("@Dia", dia.Date);
                    txtTotalGeneral.Text = ToDecimalSafe(c.ExecuteScalar()).ToString("0.00");
                }

            }
        }

        // ---------------------------------------
        // 9) TABLA GENERAL DEL DÍA (ventas y membresias combinadas, con corte que corresponde si existe)
        // ---------------------------------------
        private void CargarTablaGeneralDia(DateTime dia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string q = @"
                    -- PRODUCTOS
                    SELECT 
                        'Producto' AS Tipo,
                        P.Nombre AS Nombre,
                        DV.Cantidad AS Cantidad,
                        (DV.Cantidad * DV.PrecioUnitario) AS Total,
                        (
                            SELECT TOP 1 C.IdCorte 
                            FROM CortesCaja C 
                            WHERE C.FechaCorte >= V.FechaCreacion
                            ORDER BY C.FechaCorte ASC
                        ) AS Corte,
                        V.FechaCreacion AS Hora
                    FROM Ventas V
                    INNER JOIN DetalleVenta DV ON DV.IdVenta = V.IdVenta
                    INNER JOIN Productos P ON P.IdProducto = DV.IdProducto
                    WHERE CONVERT(date, V.FechaCreacion) = @Dia
                      AND V.Anulada = 0

                    UNION ALL

                    -- MEMBRESÍAS
                    SELECT
                        'Membresía' AS Tipo,
                        PM.Nombre AS Nombre,
                        1 AS Cantidad,
                        DMV.Precio AS Total,
                        (
                            SELECT TOP 1 C.IdCorte 
                            FROM CortesCaja C 
                            WHERE C.FechaCorte >= V.FechaCreacion
                            ORDER BY C.FechaCorte ASC
                        ) AS Corte,
                        V.FechaCreacion AS Hora
                    FROM DetalleMembresiaVenta DMV
                    INNER JOIN PlanesMembresia PM ON PM.IdPlan = DMV.IdPlan
                    INNER JOIN Ventas V ON V.IdVenta = DMV.IdVenta
                    WHERE CONVERT(date, V.FechaCreacion) = @Dia
                      AND V.Anulada = 0

                    ORDER BY Hora ASC, Tipo, Nombre;
                ";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Dia", dia.Date);

                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);

                dgvGeneralDia.DataSource = dt;
            }
        }

        private void GenerarReportePDF()
        {
            if (cmbDias.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un día para generar el reporte.");
                return;
            }

            DateTime dia = Convert.ToDateTime(cmbDias.SelectedValue);

            try
            {
                string carpetaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
                string ruta = Path.Combine(carpetaDescargas, $"Reporte_{dia:yyyy_MM_dd}.pdf");

                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(ruta, System.IO.FileMode.Create));

                doc.Open();

                // ENCABEZADO
                var titulo = new iTextSharp.text.Paragraph($"REPORTE DEL DÍA {dia:dd/MM/yyyy}")
                {
                    Alignment = iTextSharp.text.Element.ALIGN_CENTER
                };
                titulo.Font.Size = 16;
                titulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                doc.Add(titulo);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                // CONSULTAS
                DataTable dtProductos = ObtenerProductosDia(dia);
                DataTable dtMembresias = ObtenerMembresiasDia(dia);

                decimal totalProductos = Convert.ToDecimal(txtTotalProductos.Text);
                decimal totalMembresias = Convert.ToDecimal(txtTotalMembresias.Text);
                decimal totalEfectivo = Convert.ToDecimal(txtTotalEfectivo.Text);
                decimal totalTransfer = Convert.ToDecimal(txtTotalTransferencia.Text);
                decimal totalGeneral = Convert.ToDecimal(txtTotalGeneral.Text);

                // =============================================================
                // 🟦 TABLA DE PRODUCTOS
                // =============================================================
                iTextSharp.text.Paragraph tituloProductos = new iTextSharp.text.Paragraph("PRODUCTOS VENDIDOS");
                tituloProductos.Font.SetStyle(iTextSharp.text.Font.BOLD);
                tituloProductos.Alignment = iTextSharp.text.Element.ALIGN_LEFT;
                doc.Add(tituloProductos);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                iTextSharp.text.pdf.PdfPTable tablaProductos = new iTextSharp.text.pdf.PdfPTable(3);
                tablaProductos.WidthPercentage = 100;

                tablaProductos.AddCell("Producto");
                tablaProductos.AddCell("Cantidad");
                tablaProductos.AddCell("Total");

                if (dtProductos.Rows.Count == 0)
                {
                    tablaProductos.AddCell("No se vendieron productos.");
                    tablaProductos.AddCell("-");
                    tablaProductos.AddCell("-");
                }
                else
                {
                    foreach (DataRow r in dtProductos.Rows)
                    {
                        tablaProductos.AddCell(r["Producto"].ToString());
                        tablaProductos.AddCell(r["Cantidad"].ToString());
                        tablaProductos.AddCell($"${r["Total"]}");
                    }
                }

                doc.Add(tablaProductos);
                doc.Add(new iTextSharp.text.Paragraph($"Total Productos: ${totalProductos:0.00}\n\n"));

                // =============================================================
                // 🟩 TABLA DE MEMBRESÍAS
                // =============================================================
                iTextSharp.text.Paragraph tituloMembresias = new iTextSharp.text.Paragraph("MEMBRESÍAS VENDIDAS");
                tituloMembresias.Font.SetStyle(iTextSharp.text.Font.BOLD);
                tituloMembresias.Alignment = iTextSharp.text.Element.ALIGN_LEFT;
                doc.Add(tituloMembresias);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                iTextSharp.text.pdf.PdfPTable tablaMemb = new iTextSharp.text.pdf.PdfPTable(3);
                tablaMemb.WidthPercentage = 100;

                tablaMemb.AddCell("Membresía");
                tablaMemb.AddCell("Cantidad");
                tablaMemb.AddCell("Total");

                if (dtMembresias.Rows.Count == 0)
                {
                    tablaMemb.AddCell("No se vendieron membresías.");
                    tablaMemb.AddCell("-");
                    tablaMemb.AddCell("-");
                }
                else
                {
                    foreach (DataRow r in dtMembresias.Rows)
                    {
                        tablaMemb.AddCell(r["Membresia"].ToString());
                        tablaMemb.AddCell(r["Cantidad"].ToString());
                        tablaMemb.AddCell($"${r["Total"]}");
                    }
                }

                doc.Add(tablaMemb);
                doc.Add(new iTextSharp.text.Paragraph($"Total Membresías: ${totalMembresias:0.00}\n\n"));

                // =============================================================
                // 🟥 TABLA DE TOTALES GENERALES
                // =============================================================

                iTextSharp.text.Paragraph tituloTotales = new iTextSharp.text.Paragraph("TOTALES DEL DÍA");
                tituloTotales.Font.SetStyle(iTextSharp.text.Font.BOLD);
                tituloTotales.Alignment = iTextSharp.text.Element.ALIGN_LEFT;
                doc.Add(tituloTotales);
                doc.Add(new iTextSharp.text.Paragraph("\n"));

                iTextSharp.text.pdf.PdfPTable tablaTotales = new iTextSharp.text.pdf.PdfPTable(2);
                tablaTotales.WidthPercentage = 60;

                tablaTotales.AddCell("Concepto");
                tablaTotales.AddCell("Total");

                tablaTotales.AddCell("Efectivo en Cortes");
                tablaTotales.AddCell($"${totalEfectivo:0.00}");

                tablaTotales.AddCell("Transferencias");
                tablaTotales.AddCell($"${totalTransfer:0.00}");

                tablaTotales.AddCell("Productos");
                tablaTotales.AddCell($"${totalProductos:0.00}");

                tablaTotales.AddCell("Membresías");
                tablaTotales.AddCell($"${totalMembresias:0.00}");

                tablaTotales.AddCell("TOTAL GENERAL");
                tablaTotales.AddCell($"${totalGeneral:0.00}");

                doc.Add(tablaTotales);

                doc.Close();

                MessageBox.Show("Reporte generado correctamente:\n" + ruta);

                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = ruta,
                    UseShellExecute = true
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message);
            }
        }

        private DataTable ObtenerProductosDia(DateTime dia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"
        SELECT 
            P.Nombre AS Producto,
            SUM(DV.Cantidad) AS Cantidad,
            SUM(DV.Cantidad * DV.PrecioUnitario) AS Total
        FROM Ventas V
        INNER JOIN DetalleVenta DV ON DV.IdVenta = V.IdVenta
        INNER JOIN Productos P ON P.IdProducto = DV.IdProducto
        WHERE V.Anulada = 0
          AND CONVERT(date, V.FechaCreacion) = @Dia
        GROUP BY P.Nombre
        ORDER BY Total DESC";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Dia", dia.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private DataTable ObtenerMembresiasDia(DateTime dia)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string q = @"
        SELECT 
            PM.Nombre AS Membresia,
            COUNT(*) AS Cantidad,
            SUM(DMV.Precio) AS Total
        FROM DetalleMembresiaVenta DMV
        INNER JOIN PlanesMembresia PM ON PM.IdPlan = DMV.IdPlan
        INNER JOIN Ventas V ON V.IdVenta = DMV.IdVenta
        WHERE V.Anulada = 0
          AND CONVERT(date, V.FechaCreacion) = @Dia
        GROUP BY PM.Nombre
        ORDER BY Total DESC";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Dia", dia.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            GenerarReportePDF();
        }

    }
}