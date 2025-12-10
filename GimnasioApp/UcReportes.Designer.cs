using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GimnasioApp
{
    partial class UcReportes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblFechaHoraActualUC = new Label();
            roundButton1 = new RoundButton();
            lblTotalProductos = new Label();
            lblTotalMembresias = new Label();
            lblEfectivoEnCaja = new Label();
            lblCortes = new Label();
            cmbDias = new ComboBox();
            dgvProductos = new DataGridView();
            dgvMembresias = new DataGridView();
            dgvGeneralDia = new DataGridView();
            lblSeccionProductos = new Label();
            lblSeccionMembresias = new Label();
            lblSeccionGeneral = new Label();
            cmbCortes = new ComboBox();
            label1 = new Label();
            txtTotalProductos = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTotalMembresias = new Label();
            label4 = new Label();
            txtTotalEfectivo = new Label();
            label5 = new Label();
            txtTotalTransferencia = new Label();
            label7 = new Label();
            txtTotalGeneral = new Label();
            btnGenerarPDF = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGeneralDia).BeginInit();
            SuspendLayout();
            // 
            // lblFechaHoraActualUC
            // 
            lblFechaHoraActualUC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaHoraActualUC.AutoSize = true;
            lblFechaHoraActualUC.BackColor = Color.Gainsboro;
            lblFechaHoraActualUC.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaHoraActualUC.Location = new Point(1366, 37);
            lblFechaHoraActualUC.Margin = new Padding(4, 0, 4, 0);
            lblFechaHoraActualUC.Name = "lblFechaHoraActualUC";
            lblFechaHoraActualUC.Size = new Size(0, 23);
            lblFechaHoraActualUC.TabIndex = 0;
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1349, 27);
            roundButton1.Margin = new Padding(4, 3, 4, 3);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 1;
            // 
            // lblTotalProductos
            // 
            lblTotalProductos.Location = new Point(0, 0);
            lblTotalProductos.Name = "lblTotalProductos";
            lblTotalProductos.Size = new Size(100, 23);
            lblTotalProductos.TabIndex = 23;
            // 
            // lblTotalMembresias
            // 
            lblTotalMembresias.Location = new Point(0, 0);
            lblTotalMembresias.Name = "lblTotalMembresias";
            lblTotalMembresias.Size = new Size(100, 23);
            lblTotalMembresias.TabIndex = 22;
            // 
            // lblEfectivoEnCaja
            // 
            lblEfectivoEnCaja.Location = new Point(0, 0);
            lblEfectivoEnCaja.Name = "lblEfectivoEnCaja";
            lblEfectivoEnCaja.Size = new Size(100, 23);
            lblEfectivoEnCaja.TabIndex = 21;
            // 
            // lblCortes
            // 
            lblCortes.AutoSize = true;
            lblCortes.Location = new Point(39, 90);
            lblCortes.Name = "lblCortes";
            lblCortes.Size = new Size(44, 19);
            lblCortes.TabIndex = 12;
            lblCortes.Text = "Dias";
            // 
            // cmbDias
            // 
            cmbDias.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDias.Location = new Point(39, 112);
            cmbDias.Name = "cmbDias";
            cmbDias.Size = new Size(320, 27);
            cmbDias.TabIndex = 13;
            cmbDias.SelectedIndexChanged += cmbCortes_SelectedIndexChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(39, 297);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(980, 180);
            dgvProductos.TabIndex = 15;
            // 
            // dgvMembresias
            // 
            dgvMembresias.AllowUserToAddRows = false;
            dgvMembresias.AllowUserToDeleteRows = false;
            dgvMembresias.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvMembresias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembresias.BackgroundColor = Color.White;
            dgvMembresias.ColumnHeadersHeight = 29;
            dgvMembresias.Location = new Point(39, 497);
            dgvMembresias.Name = "dgvMembresias";
            dgvMembresias.ReadOnly = true;
            dgvMembresias.RowHeadersWidth = 51;
            dgvMembresias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembresias.Size = new Size(980, 140);
            dgvMembresias.TabIndex = 16;
            // 
            // dgvGeneralDia
            // 
            dgvGeneralDia.AllowUserToAddRows = false;
            dgvGeneralDia.AllowUserToDeleteRows = false;
            dgvGeneralDia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvGeneralDia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGeneralDia.BackgroundColor = Color.White;
            dgvGeneralDia.ColumnHeadersHeight = 29;
            dgvGeneralDia.Location = new Point(39, 667);
            dgvGeneralDia.Name = "dgvGeneralDia";
            dgvGeneralDia.ReadOnly = true;
            dgvGeneralDia.RowHeadersWidth = 51;
            dgvGeneralDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGeneralDia.Size = new Size(1440, 412);
            dgvGeneralDia.TabIndex = 17;
            // 
            // lblSeccionProductos
            // 
            lblSeccionProductos.AutoSize = true;
            lblSeccionProductos.Location = new Point(39, 277);
            lblSeccionProductos.Name = "lblSeccionProductos";
            lblSeccionProductos.Size = new Size(181, 19);
            lblSeccionProductos.TabIndex = 18;
            lblSeccionProductos.Text = "Productos (por corte)";
            // 
            // lblSeccionMembresias
            // 
            lblSeccionMembresias.AutoSize = true;
            lblSeccionMembresias.Location = new Point(39, 477);
            lblSeccionMembresias.Name = "lblSeccionMembresias";
            lblSeccionMembresias.Size = new Size(200, 19);
            lblSeccionMembresias.TabIndex = 19;
            lblSeccionMembresias.Text = "Membresías (por corte)";
            // 
            // lblSeccionGeneral
            // 
            lblSeccionGeneral.AutoSize = true;
            lblSeccionGeneral.Location = new Point(39, 647);
            lblSeccionGeneral.Name = "lblSeccionGeneral";
            lblSeccionGeneral.Size = new Size(183, 19);
            lblSeccionGeneral.TabIndex = 20;
            lblSeccionGeneral.Text = "Tabla general del día";
            // 
            // cmbCortes
            // 
            cmbCortes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCortes.Location = new Point(39, 213);
            cmbCortes.Name = "cmbCortes";
            cmbCortes.Size = new Size(320, 27);
            cmbCortes.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 191);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 24;
            label1.Text = "Cortes";
            // 
            // txtTotalProductos
            // 
            txtTotalProductos.AutoSize = true;
            txtTotalProductos.Location = new Point(439, 192);
            txtTotalProductos.Name = "txtTotalProductos";
            txtTotalProductos.Size = new Size(19, 19);
            txtTotalProductos.TabIndex = 26;
            txtTotalProductos.Text = "$";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(439, 167);
            label2.Name = "label2";
            label2.Size = new Size(132, 19);
            label2.TabIndex = 27;
            label2.Text = "Total Productos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(617, 167);
            label3.Name = "label3";
            label3.Size = new Size(151, 19);
            label3.TabIndex = 29;
            label3.Text = "Total Membresias";
            // 
            // txtTotalMembresias
            // 
            txtTotalMembresias.AutoSize = true;
            txtTotalMembresias.Location = new Point(617, 192);
            txtTotalMembresias.Name = "txtTotalMembresias";
            txtTotalMembresias.Size = new Size(19, 19);
            txtTotalMembresias.TabIndex = 28;
            txtTotalMembresias.Text = "$";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1024, 167);
            label4.Name = "label4";
            label4.Size = new Size(116, 19);
            label4.TabIndex = 31;
            label4.Text = "Total Efectivo";
            // 
            // txtTotalEfectivo
            // 
            txtTotalEfectivo.AutoSize = true;
            txtTotalEfectivo.Location = new Point(1024, 192);
            txtTotalEfectivo.Name = "txtTotalEfectivo";
            txtTotalEfectivo.Size = new Size(19, 19);
            txtTotalEfectivo.TabIndex = 30;
            txtTotalEfectivo.Text = "$";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(814, 167);
            label5.Name = "label5";
            label5.Size = new Size(168, 19);
            label5.TabIndex = 32;
            label5.Text = "Total Transferencias";
            // 
            // txtTotalTransferencia
            // 
            txtTotalTransferencia.AutoSize = true;
            txtTotalTransferencia.Location = new Point(814, 192);
            txtTotalTransferencia.Name = "txtTotalTransferencia";
            txtTotalTransferencia.Size = new Size(19, 19);
            txtTotalTransferencia.TabIndex = 33;
            txtTotalTransferencia.Text = "$";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1190, 167);
            label7.Name = "label7";
            label7.Size = new Size(117, 19);
            label7.TabIndex = 34;
            label7.Text = "Total General";
            // 
            // txtTotalGeneral
            // 
            txtTotalGeneral.AutoSize = true;
            txtTotalGeneral.Location = new Point(1190, 192);
            txtTotalGeneral.Name = "txtTotalGeneral";
            txtTotalGeneral.Size = new Size(19, 19);
            txtTotalGeneral.TabIndex = 35;
            txtTotalGeneral.Text = "$";
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.BackColor = Color.SkyBlue;
            btnGenerarPDF.ForeColor = Color.Black;
            btnGenerarPDF.Location = new Point(39, 1104);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(188, 45);
            btnGenerarPDF.TabIndex = 36;
            btnGenerarPDF.Text = "Generar PDF";
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // UcReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnGenerarPDF);
            Controls.Add(txtTotalGeneral);
            Controls.Add(label7);
            Controls.Add(txtTotalTransferencia);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtTotalEfectivo);
            Controls.Add(label3);
            Controls.Add(txtTotalMembresias);
            Controls.Add(label2);
            Controls.Add(txtTotalProductos);
            Controls.Add(cmbCortes);
            Controls.Add(label1);
            Controls.Add(lblSeccionGeneral);
            Controls.Add(lblSeccionMembresias);
            Controls.Add(lblSeccionProductos);
            Controls.Add(dgvGeneralDia);
            Controls.Add(dgvMembresias);
            Controls.Add(dgvProductos);
            Controls.Add(cmbDias);
            Controls.Add(lblCortes);
            Controls.Add(lblEfectivoEnCaja);
            Controls.Add(lblTotalMembresias);
            Controls.Add(lblTotalProductos);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(roundButton1);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UcReportes";
            Size = new Size(1600, 1192);
            Load += UcReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMembresias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGeneralDia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFechaHoraActualUC;
        private RoundButton roundButton1;

        // Totales (visuales)
        private Label lblTotalProductos;
        private Label lblTotalMembresias;
        private Label lblEfectivoEnCaja;

        // Cortes
        private Label lblCortes;
        private ComboBox cmbDias;

        // DataGrids
        private DataGridView dgvProductos;
        private DataGridView dgvMembresias;
        private DataGridView dgvGeneralDia;

        // Section labels
        private Label lblSeccionProductos;
        private Label lblSeccionMembresias;
        private Label lblSeccionGeneral;
        private ComboBox cmbCortes;
        private Label label1;
        private Label txtTotalProductos;
        private Label label2;
        private Label label3;
        private Label txtTotalMembresias;
        private Label label4;
        private Label txtTotalEfectivo;
        private Label label5;
        private Label txtTotalTransferencia;
        private Label label7;
        private Label txtTotalGeneral;
        private RoundButton btnGenerarPDF;
    }
}
