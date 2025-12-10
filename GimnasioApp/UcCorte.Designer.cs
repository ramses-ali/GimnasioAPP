namespace GimnasioApp
{
    partial class UcCorte
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
            lblCorte = new Label();
            roundButton1 = new RoundButton();
            btnHacerCorte = new RoundButton();
            lblTotalCaja = new Label();
            dgvVentas = new DataGridView();
            lblTotalVentasGlobal = new Label();
            dgvUltimoCorte = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            btnCorteFinal = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUltimoCorte).BeginInit();
            SuspendLayout();
            // 
            // lblFechaHoraActualUC
            // 
            lblFechaHoraActualUC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaHoraActualUC.AutoSize = true;
            lblFechaHoraActualUC.BackColor = Color.Gainsboro;
            lblFechaHoraActualUC.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaHoraActualUC.Location = new Point(1398, 38);
            lblFechaHoraActualUC.Margin = new Padding(4, 0, 4, 0);
            lblFechaHoraActualUC.Name = "lblFechaHoraActualUC";
            lblFechaHoraActualUC.Size = new Size(0, 23);
            lblFechaHoraActualUC.TabIndex = 28;
            // 
            // lblCorte
            // 
            lblCorte.AutoSize = true;
            lblCorte.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCorte.Location = new Point(4, 10);
            lblCorte.Margin = new Padding(4, 0, 4, 0);
            lblCorte.Name = "lblCorte";
            lblCorte.Size = new Size(53, 19);
            lblCorte.TabIndex = 27;
            lblCorte.Text = "Corte";
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1381, 29);
            roundButton1.Margin = new Padding(4, 3, 4, 3);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 29;
            // 
            // btnHacerCorte
            // 
            btnHacerCorte.BackColor = Color.Tomato;
            btnHacerCorte.ForeColor = Color.White;
            btnHacerCorte.Location = new Point(111, 497);
            btnHacerCorte.Margin = new Padding(4, 3, 4, 3);
            btnHacerCorte.Name = "btnHacerCorte";
            btnHacerCorte.Size = new Size(151, 46);
            btnHacerCorte.TabIndex = 30;
            btnHacerCorte.Text = "Hacer Corte";
            btnHacerCorte.Click += btnHacerCorte_Click;
            // 
            // lblTotalCaja
            // 
            lblTotalCaja.AutoSize = true;
            lblTotalCaja.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalCaja.Location = new Point(111, 452);
            lblTotalCaja.Name = "lblTotalCaja";
            lblTotalCaja.Size = new Size(25, 27);
            lblTotalCaja.TabIndex = 31;
            lblTotalCaja.Text = "$";
            // 
            // dgvVentas
            // 
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(498, 452);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(883, 340);
            dgvVentas.TabIndex = 32;
            // 
            // lblTotalVentasGlobal
            // 
            lblTotalVentasGlobal.AutoSize = true;
            lblTotalVentasGlobal.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVentasGlobal.Location = new Point(111, 201);
            lblTotalVentasGlobal.Name = "lblTotalVentasGlobal";
            lblTotalVentasGlobal.Size = new Size(21, 23);
            lblTotalVentasGlobal.TabIndex = 33;
            lblTotalVentasGlobal.Text = "$";
            // 
            // dgvUltimoCorte
            // 
            dgvUltimoCorte.BackgroundColor = Color.White;
            dgvUltimoCorte.BorderStyle = BorderStyle.None;
            dgvUltimoCorte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimoCorte.Location = new Point(498, 201);
            dgvUltimoCorte.Name = "dgvUltimoCorte";
            dgvUltimoCorte.RowHeadersWidth = 51;
            dgvUltimoCorte.Size = new Size(723, 107);
            dgvUltimoCorte.TabIndex = 34;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(498, 162);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 35;
            label1.Text = "Ultimo Corte";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(498, 414);
            label2.Name = "label2";
            label2.Size = new Size(122, 23);
            label2.TabIndex = 36;
            label2.Text = "Ventas Hoy";
            // 
            // btnCorteFinal
            // 
            btnCorteFinal.BackColor = Color.DarkRed;
            btnCorteFinal.ForeColor = Color.White;
            btnCorteFinal.Location = new Point(111, 575);
            btnCorteFinal.Margin = new Padding(4, 3, 4, 3);
            btnCorteFinal.Name = "btnCorteFinal";
            btnCorteFinal.Size = new Size(180, 46);
            btnCorteFinal.TabIndex = 37;
            btnCorteFinal.Text = "Hacer Corte Final";
            btnCorteFinal.Click += btnCorteFinal_Click;
            // 
            // UcCorte
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnCorteFinal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvUltimoCorte);
            Controls.Add(lblTotalVentasGlobal);
            Controls.Add(dgvVentas);
            Controls.Add(lblTotalCaja);
            Controls.Add(btnHacerCorte);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(lblCorte);
            Controls.Add(roundButton1);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Margin = new Padding(4, 3, 4, 3);
            Name = "UcCorte";
            Size = new Size(1636, 810);
            Load += UcCorte_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUltimoCorte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnCorteFinal_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnHacerCorte_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblFechaHoraActualUC;
        private Label lblCorte;
        private RoundButton roundButton1;
        private RoundButton btnHacerCorte;
        private Label lblTotalCaja;
        private DataGridView dgvVentas;
        private Label lblTotalVentasGlobal;
        private DataGridView dgvUltimoCorte;
        private Label label1;
        private Label label2;
        private RoundButton btnCorteFinal;
    }
}
