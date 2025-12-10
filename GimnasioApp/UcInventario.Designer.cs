namespace GimnasioApp
{
    partial class UcInventario
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
            lblInventario = new Label();
            roundButton1 = new RoundButton();
            panelInventario = new FlowLayoutPanel();
            cmbProductos = new ComboBox();
            xtxbCantidad = new TextBox();
            label1 = new Label();
            label2 = new Label();
            rbtnRegistrarProducto = new RoundButton();
            rbtnNuevoProducto = new RoundButton();
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
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventario.Location = new Point(3, 10);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(90, 19);
            lblInventario.TabIndex = 27;
            lblInventario.Text = "Inventario";
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
            // panelInventario
            // 
            panelInventario.AutoScroll = true;
            panelInventario.BackColor = Color.White;
            panelInventario.Dock = DockStyle.Bottom;
            panelInventario.FlowDirection = FlowDirection.TopDown;
            panelInventario.Location = new Point(0, 53);
            panelInventario.Name = "panelInventario";
            panelInventario.Padding = new Padding(30);
            panelInventario.Size = new Size(1309, 800);
            panelInventario.TabIndex = 30;
            // 
            // cmbProductos
            // 
            cmbProductos.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(75, 200);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(364, 29);
            cmbProductos.TabIndex = 0;
            // 
            // xtxbCantidad
            // 
            xtxbCantidad.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xtxbCantidad.Location = new Point(455, 200);
            xtxbCantidad.Multiline = true;
            xtxbCantidad.Name = "xtxbCantidad";
            xtxbCantidad.PlaceholderText = "#";
            xtxbCantidad.Size = new Size(84, 29);
            xtxbCantidad.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 172);
            label1.Name = "label1";
            label1.Size = new Size(156, 19);
            label1.TabIndex = 32;
            label1.Text = "Registrar Producto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(455, 172);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 33;
            label2.Text = "Cantidad";
            // 
            // rbtnRegistrarProducto
            // 
            rbtnRegistrarProducto.BackColor = Color.FromArgb(192, 255, 192);
            rbtnRegistrarProducto.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnRegistrarProducto.ForeColor = Color.Black;
            rbtnRegistrarProducto.Location = new Point(78, 253);
            rbtnRegistrarProducto.Margin = new Padding(5, 4, 5, 4);
            rbtnRegistrarProducto.Name = "rbtnRegistrarProducto";
            rbtnRegistrarProducto.Size = new Size(148, 45);
            rbtnRegistrarProducto.TabIndex = 0;
            rbtnRegistrarProducto.Text = "Ingresar";
            rbtnRegistrarProducto.Click += rbtnRegistrarProducto_Click;
            // 
            // rbtnNuevoProducto
            // 
            rbtnNuevoProducto.BackColor = Color.FromArgb(192, 192, 255);
            rbtnNuevoProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnNuevoProducto.ForeColor = Color.Black;
            rbtnNuevoProducto.Location = new Point(270, 259);
            rbtnNuevoProducto.Margin = new Padding(4, 3, 4, 3);
            rbtnNuevoProducto.Name = "rbtnNuevoProducto";
            rbtnNuevoProducto.Size = new Size(169, 39);
            rbtnNuevoProducto.TabIndex = 35;
            rbtnNuevoProducto.Text = "Nuevo Producto";
            rbtnNuevoProducto.Click += rbtnNuevoProducto_Click;
            // 
            // UcInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rbtnNuevoProducto);
            Controls.Add(rbtnRegistrarProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(xtxbCantidad);
            Controls.Add(cmbProductos);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(lblInventario);
            Controls.Add(roundButton1);
            Controls.Add(panelInventario);
            Name = "UcInventario";
            Size = new Size(1309, 853);
            Load += UcInventario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFechaHoraActualUC;
        private Label lblInventario;
        private RoundButton roundButton1;
        private FlowLayoutPanel panelInventario;
        private ComboBox cmbProductos;
        private TextBox xtxbCantidad;
        private Label label1;
        private Label label2;
        private RoundButton rbtnRegistrarProducto;
        private RoundButton rbtnNuevoProducto;
    }
}
