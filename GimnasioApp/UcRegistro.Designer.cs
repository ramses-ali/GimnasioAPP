namespace GimnasioApp
{
    partial class UcRegistro
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
            lblRegistro = new Label();
            roundButton1 = new RoundButton();
            txtbBuscar = new TextBox();
            pictureBox2 = new PictureBox();
            lblClientes = new Label();
            dgvRegistros = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).BeginInit();
            SuspendLayout();
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
            lblFechaHoraActualUC.TabIndex = 28;
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegistro.Location = new Point(3, 10);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(143, 19);
            lblRegistro.TabIndex = 27;
            lblRegistro.Text = "Registro Clientes";
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1057, 27);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 29;
            // 
            // txtbBuscar
            // 
            txtbBuscar.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbBuscar.Location = new Point(99, 93);
            txtbBuscar.Multiline = true;
            txtbBuscar.Name = "txtbBuscar";
            txtbBuscar.PlaceholderText = "Buscar";
            txtbBuscar.Size = new Size(352, 37);
            txtbBuscar.TabIndex = 30;
            txtbBuscar.TextChanged += txtbBuscar_TextChanged;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.buscar;
            pictureBox2.Location = new Point(69, 98);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 33;
            pictureBox2.TabStop = false;
            // 
            // lblClientes
            // 
            lblClientes.AutoSize = true;
            lblClientes.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblClientes.Location = new Point(69, 169);
            lblClientes.Name = "lblClientes";
            lblClientes.Size = new Size(74, 19);
            lblClientes.TabIndex = 34;
            lblClientes.Text = "Clientes";
            // 
            // dgvRegistros
            // 
            dgvRegistros.BackgroundColor = Color.White;
            dgvRegistros.BorderStyle = BorderStyle.None;
            dgvRegistros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistros.Location = new Point(69, 205);
            dgvRegistros.Name = "dgvRegistros";
            dgvRegistros.RowHeadersWidth = 51;
            dgvRegistros.Size = new Size(1219, 628);
            dgvRegistros.TabIndex = 35;
            dgvRegistros.CellContentClick += dgvRegistros_CellContentClick;
            // 
            // UcRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvRegistros);
            Controls.Add(lblClientes);
            Controls.Add(pictureBox2);
            Controls.Add(txtbBuscar);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(lblRegistro);
            Controls.Add(roundButton1);
            Name = "UcRegistro";
            Size = new Size(1309, 853);
            Load += UcRegistro_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRegistros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFechaHoraActualUC;
        private Label lblRegistro;
        private RoundButton roundButton1;
        private TextBox txtbBuscar;
        private PictureBox pictureBox2;
        private Label lblClientes;
        private DataGridView dgvRegistros;
    }
}
