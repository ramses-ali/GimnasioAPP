namespace GimnasioApp
{
    partial class UcInicio
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
            btnAsistencia = new RoundButton();
            btnVenta = new RoundButton();
            lblInicio = new Label();
            lblFechaHoraActualUC = new Label();
            roundButton1 = new RoundButton();
            dgvAsistencias = new DataGridView();
            dgvVentas = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // btnAsistencia
            // 
            btnAsistencia.BackColor = Color.FromArgb(192, 255, 192);
            btnAsistencia.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnAsistencia.ForeColor = Color.Black;
            btnAsistencia.Location = new Point(78, 175);
            btnAsistencia.Margin = new Padding(4, 3, 4, 3);
            btnAsistencia.Name = "btnAsistencia";
            btnAsistencia.Size = new Size(211, 54);
            btnAsistencia.TabIndex = 18;
            btnAsistencia.Text = "Registrar Asistencia";
            btnAsistencia.Click += btnAsistencia_Click;
            // 
            // btnVenta
            // 
            btnVenta.BackColor = Color.FromArgb(192, 255, 192);
            btnVenta.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnVenta.ForeColor = Color.Black;
            btnVenta.Location = new Point(78, 109);
            btnVenta.Margin = new Padding(4, 3, 4, 3);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(172, 54);
            btnVenta.TabIndex = 17;
            btnVenta.Text = "Registrar Venta";
            btnVenta.Click += btnVenta_Click;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInicio.Location = new Point(3, 10);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(54, 19);
            lblInicio.TabIndex = 16;
            lblInicio.Text = "Inicio";
            // 
            // lblFechaHoraActualUC
            // 
            lblFechaHoraActualUC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaHoraActualUC.AutoSize = true;
            lblFechaHoraActualUC.BackColor = Color.Gainsboro;
            lblFechaHoraActualUC.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaHoraActualUC.Location = new Point(1070, 37);
            lblFechaHoraActualUC.Name = "lblFechaHoraActualUC";
            lblFechaHoraActualUC.Size = new Size(0, 23);
            lblFechaHoraActualUC.TabIndex = 25;
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1057, 27);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 26;
            // 
            // dgvAsistencias
            // 
            dgvAsistencias.BackgroundColor = Color.White;
            dgvAsistencias.BorderStyle = BorderStyle.None;
            dgvAsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencias.Location = new Point(78, 295);
            dgvAsistencias.Name = "dgvAsistencias";
            dgvAsistencias.RowHeadersWidth = 51;
            dgvAsistencias.Size = new Size(786, 487);
            dgvAsistencias.TabIndex = 27;
            // 
            // dgvVentas
            // 
            dgvVentas.BackgroundColor = Color.White;
            dgvVentas.BorderStyle = BorderStyle.None;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(736, 295);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(480, 487);
            dgvVentas.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 273);
            label1.Name = "label1";
            label1.Size = new Size(101, 19);
            label1.TabIndex = 29;
            label1.Text = "Asistencias";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(736, 273);
            label2.Name = "label2";
            label2.Size = new Size(65, 19);
            label2.TabIndex = 30;
            label2.Text = "Ventas";
            // 
            // UcInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvVentas);
            Controls.Add(dgvAsistencias);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(btnAsistencia);
            Controls.Add(btnVenta);
            Controls.Add(lblInicio);
            Controls.Add(roundButton1);
            Name = "UcInicio";
            Size = new Size(1309, 853);
            Load += UcInicio_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RoundButton btnAsistencia;
        private RoundButton btnVenta;
        private Label lblInicio;
        private Label lblFechaHoraActualUC;
        private RoundButton roundButton1;
        private DataGridView dgvAsistencias;
        private DataGridView dgvVentas;
        private Label label1;
        private Label label2;
    }
}
