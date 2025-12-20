namespace GimnasioApp
{
    partial class UcConfiguracion
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
            lblConfiguracion = new Label();
            cmbxPreciosMembresias = new ComboBox();
            lblEditarPrecios = new Label();
            rbtnRegistrarPrecio = new RoundButton();
            txtbActualizarPrecioMembresias = new TextBox();
            lblPrecio = new Label();
            lblMembresias = new Label();
            lblEditarUsuarios = new Label();
            lblAgregarUsuario = new Label();
            lblNombre = new Label();
            txtbNombreUsuario = new TextBox();
            txtbContraseña = new TextBox();
            lblContraseña = new Label();
            txtbCorreo = new TextBox();
            lblCorreo = new Label();
            rbtnAgregarUsuario = new RoundButton();
            lblRol = new Label();
            cmbxRol = new ComboBox();
            lblFechaHoraActualUC = new Label();
            roundButton1 = new RoundButton();
            panel1 = new Panel();
            panel2 = new Panel();
            rbtnEliminarUsuario = new RoundButton();
            cmbxEliminarUsuario = new ComboBox();
            lblEliminarUsuario = new Label();
            lblEditarPreciosInventario = new Label();
            lblInventario = new Label();
            cmbProductos = new ComboBox();
            txtbPrecio = new TextBox();
            lblPrecioI = new Label();
            panel3 = new Panel();
            lblCantidad = new Label();
            txtbCantidadProductos = new TextBox();
            rbtnEliminarProducto = new RoundButton();
            btnActualizarPrecioInventario = new RoundButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblConfiguracion
            // 
            lblConfiguracion.AutoSize = true;
            lblConfiguracion.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfiguracion.Location = new Point(5, 10);
            lblConfiguracion.Margin = new Padding(5, 0, 5, 0);
            lblConfiguracion.Name = "lblConfiguracion";
            lblConfiguracion.Size = new Size(131, 19);
            lblConfiguracion.TabIndex = 28;
            lblConfiguracion.Text = "Administracion";
            // 
            // cmbxPreciosMembresias
            // 
            cmbxPreciosMembresias.FormattingEnabled = true;
            cmbxPreciosMembresias.Location = new Point(11, 114);
            cmbxPreciosMembresias.Name = "cmbxPreciosMembresias";
            cmbxPreciosMembresias.Size = new Size(263, 27);
            cmbxPreciosMembresias.TabIndex = 29;
            cmbxPreciosMembresias.SelectedIndexChanged += cmbxPreciosMembresias_SelectedIndexChanged;
            // 
            // lblEditarPrecios
            // 
            lblEditarPrecios.AutoSize = true;
            lblEditarPrecios.Location = new Point(11, 30);
            lblEditarPrecios.Name = "lblEditarPrecios";
            lblEditarPrecios.Size = new Size(158, 19);
            lblEditarPrecios.TabIndex = 30;
            lblEditarPrecios.Text = "Editar Membresias";
            // 
            // rbtnRegistrarPrecio
            // 
            rbtnRegistrarPrecio.BackColor = Color.LightGreen;
            rbtnRegistrarPrecio.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnRegistrarPrecio.ForeColor = Color.Black;
            rbtnRegistrarPrecio.Location = new Point(11, 158);
            rbtnRegistrarPrecio.Margin = new Padding(4, 3, 4, 3);
            rbtnRegistrarPrecio.Name = "rbtnRegistrarPrecio";
            rbtnRegistrarPrecio.Size = new Size(146, 43);
            rbtnRegistrarPrecio.TabIndex = 31;
            rbtnRegistrarPrecio.Text = "Actualizar";
            rbtnRegistrarPrecio.Click += rbtnRegistrarPrecio_Click;
            // 
            // txtbActualizarPrecioMembresias
            // 
            txtbActualizarPrecioMembresias.Location = new Point(298, 114);
            txtbActualizarPrecioMembresias.Name = "txtbActualizarPrecioMembresias";
            txtbActualizarPrecioMembresias.PlaceholderText = "$";
            txtbActualizarPrecioMembresias.Size = new Size(102, 28);
            txtbActualizarPrecioMembresias.TabIndex = 32;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(298, 92);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(61, 19);
            lblPrecio.TabIndex = 33;
            lblPrecio.Text = "Precio";
            // 
            // lblMembresias
            // 
            lblMembresias.AutoSize = true;
            lblMembresias.Location = new Point(11, 92);
            lblMembresias.Name = "lblMembresias";
            lblMembresias.Size = new Size(109, 19);
            lblMembresias.TabIndex = 34;
            lblMembresias.Text = "Membresias";
            // 
            // lblEditarUsuarios
            // 
            lblEditarUsuarios.AutoSize = true;
            lblEditarUsuarios.Location = new Point(11, 20);
            lblEditarUsuarios.Name = "lblEditarUsuarios";
            lblEditarUsuarios.Size = new Size(125, 19);
            lblEditarUsuarios.TabIndex = 35;
            lblEditarUsuarios.Text = "Editar Usuarios";
            // 
            // lblAgregarUsuario
            // 
            lblAgregarUsuario.AutoSize = true;
            lblAgregarUsuario.Location = new Point(11, 75);
            lblAgregarUsuario.Name = "lblAgregarUsuario";
            lblAgregarUsuario.Size = new Size(140, 19);
            lblAgregarUsuario.TabIndex = 36;
            lblAgregarUsuario.Text = "Agregar Usuario";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(11, 122);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(76, 19);
            lblNombre.TabIndex = 37;
            lblNombre.Text = "Nombre";
            // 
            // txtbNombreUsuario
            // 
            txtbNombreUsuario.Location = new Point(11, 144);
            txtbNombreUsuario.Name = "txtbNombreUsuario";
            txtbNombreUsuario.Size = new Size(225, 28);
            txtbNombreUsuario.TabIndex = 38;
            // 
            // txtbContraseña
            // 
            txtbContraseña.Location = new Point(496, 144);
            txtbContraseña.Name = "txtbContraseña";
            txtbContraseña.Size = new Size(225, 28);
            txtbContraseña.TabIndex = 40;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(496, 122);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(103, 19);
            lblContraseña.TabIndex = 39;
            lblContraseña.Text = "Contraseña";
            // 
            // txtbCorreo
            // 
            txtbCorreo.Location = new Point(252, 144);
            txtbCorreo.Name = "txtbCorreo";
            txtbCorreo.Size = new Size(225, 28);
            txtbCorreo.TabIndex = 42;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(252, 122);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(65, 19);
            lblCorreo.TabIndex = 41;
            lblCorreo.Text = "Correo";
            // 
            // rbtnAgregarUsuario
            // 
            rbtnAgregarUsuario.BackColor = Color.LightGreen;
            rbtnAgregarUsuario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnAgregarUsuario.ForeColor = Color.Black;
            rbtnAgregarUsuario.Location = new Point(11, 197);
            rbtnAgregarUsuario.Margin = new Padding(4, 3, 4, 3);
            rbtnAgregarUsuario.Name = "rbtnAgregarUsuario";
            rbtnAgregarUsuario.Size = new Size(146, 43);
            rbtnAgregarUsuario.TabIndex = 43;
            rbtnAgregarUsuario.Text = "Agregar";
            rbtnAgregarUsuario.Click += rbtnAgregarUsuario_Click;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(749, 122);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(34, 19);
            lblRol.TabIndex = 44;
            lblRol.Text = "Rol";
            // 
            // cmbxRol
            // 
            cmbxRol.FormattingEnabled = true;
            cmbxRol.Location = new Point(749, 144);
            cmbxRol.Name = "cmbxRol";
            cmbxRol.Size = new Size(199, 27);
            cmbxRol.TabIndex = 45;
            // 
            // lblFechaHoraActualUC
            // 
            lblFechaHoraActualUC.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaHoraActualUC.AutoSize = true;
            lblFechaHoraActualUC.BackColor = Color.Gainsboro;
            lblFechaHoraActualUC.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaHoraActualUC.Location = new Point(1393, -11);
            lblFechaHoraActualUC.Name = "lblFechaHoraActualUC";
            lblFechaHoraActualUC.Size = new Size(0, 23);
            lblFechaHoraActualUC.TabIndex = 46;
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1380, -21);
            roundButton1.Margin = new Padding(2, 3, 2, 3);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 47;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblMembresias);
            panel1.Controls.Add(lblPrecio);
            panel1.Controls.Add(txtbActualizarPrecioMembresias);
            panel1.Controls.Add(rbtnRegistrarPrecio);
            panel1.Controls.Add(lblEditarPrecios);
            panel1.Controls.Add(cmbxPreciosMembresias);
            panel1.Location = new Point(210, 44);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 222);
            panel1.TabIndex = 51;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(rbtnEliminarUsuario);
            panel2.Controls.Add(cmbxRol);
            panel2.Controls.Add(lblRol);
            panel2.Controls.Add(cmbxEliminarUsuario);
            panel2.Controls.Add(rbtnAgregarUsuario);
            panel2.Controls.Add(lblEliminarUsuario);
            panel2.Controls.Add(txtbCorreo);
            panel2.Controls.Add(lblCorreo);
            panel2.Controls.Add(txtbContraseña);
            panel2.Controls.Add(lblContraseña);
            panel2.Controls.Add(txtbNombreUsuario);
            panel2.Controls.Add(lblNombre);
            panel2.Controls.Add(lblAgregarUsuario);
            panel2.Controls.Add(lblEditarUsuarios);
            panel2.Location = new Point(210, 537);
            panel2.Name = "panel2";
            panel2.Size = new Size(1027, 419);
            panel2.TabIndex = 52;
            // 
            // rbtnEliminarUsuario
            // 
            rbtnEliminarUsuario.BackColor = Color.FromArgb(255, 128, 128);
            rbtnEliminarUsuario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnEliminarUsuario.ForeColor = Color.Black;
            rbtnEliminarUsuario.Location = new Point(11, 357);
            rbtnEliminarUsuario.Margin = new Padding(4, 3, 4, 3);
            rbtnEliminarUsuario.Name = "rbtnEliminarUsuario";
            rbtnEliminarUsuario.Size = new Size(146, 43);
            rbtnEliminarUsuario.TabIndex = 50;
            rbtnEliminarUsuario.Text = "Eliminar";
            rbtnEliminarUsuario.Click += rbtnEliminarUsuario_Click;
            // 
            // cmbxEliminarUsuario
            // 
            cmbxEliminarUsuario.FormattingEnabled = true;
            cmbxEliminarUsuario.Location = new Point(11, 308);
            cmbxEliminarUsuario.Name = "cmbxEliminarUsuario";
            cmbxEliminarUsuario.Size = new Size(263, 27);
            cmbxEliminarUsuario.TabIndex = 49;
            // 
            // lblEliminarUsuario
            // 
            lblEliminarUsuario.AutoSize = true;
            lblEliminarUsuario.Location = new Point(11, 286);
            lblEliminarUsuario.Name = "lblEliminarUsuario";
            lblEliminarUsuario.Size = new Size(136, 19);
            lblEliminarUsuario.TabIndex = 48;
            lblEliminarUsuario.Text = "Eliminar Usuario";
            // 
            // lblEditarPreciosInventario
            // 
            lblEditarPreciosInventario.AutoSize = true;
            lblEditarPreciosInventario.Location = new Point(11, 30);
            lblEditarPreciosInventario.Name = "lblEditarPreciosInventario";
            lblEditarPreciosInventario.Size = new Size(139, 19);
            lblEditarPreciosInventario.TabIndex = 35;
            lblEditarPreciosInventario.Text = "Editar Inventario";
            // 
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Location = new Point(11, 92);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(90, 19);
            lblInventario.TabIndex = 53;
            lblInventario.Text = "Inventario";
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(11, 114);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(263, 27);
            cmbProductos.TabIndex = 54;
            cmbProductos.SelectedIndexChanged += cmbProductos_SelectedIndexChanged;
            // 
            // txtbPrecio
            // 
            txtbPrecio.Location = new Point(296, 113);
            txtbPrecio.Name = "txtbPrecio";
            txtbPrecio.PlaceholderText = "$";
            txtbPrecio.Size = new Size(102, 28);
            txtbPrecio.TabIndex = 55;
            // 
            // lblPrecioI
            // 
            lblPrecioI.AutoSize = true;
            lblPrecioI.Location = new Point(296, 91);
            lblPrecioI.Name = "lblPrecioI";
            lblPrecioI.Size = new Size(61, 19);
            lblPrecioI.TabIndex = 35;
            lblPrecioI.Text = "Precio";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblCantidad);
            panel3.Controls.Add(txtbCantidadProductos);
            panel3.Controls.Add(rbtnEliminarProducto);
            panel3.Controls.Add(btnActualizarPrecioInventario);
            panel3.Controls.Add(lblPrecioI);
            panel3.Controls.Add(txtbPrecio);
            panel3.Controls.Add(cmbProductos);
            panel3.Controls.Add(lblInventario);
            panel3.Controls.Add(lblEditarPreciosInventario);
            panel3.Location = new Point(210, 283);
            panel3.Name = "panel3";
            panel3.Size = new Size(794, 235);
            panel3.TabIndex = 56;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(420, 91);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(84, 19);
            lblCantidad.TabIndex = 58;
            lblCantidad.Text = "Cantidad";
            // 
            // txtbCantidadProductos
            // 
            txtbCantidadProductos.Location = new Point(420, 114);
            txtbCantidadProductos.Name = "txtbCantidadProductos";
            txtbCantidadProductos.PlaceholderText = "#";
            txtbCantidadProductos.Size = new Size(102, 28);
            txtbCantidadProductos.TabIndex = 55;
            // 
            // rbtnEliminarProducto
            // 
            rbtnEliminarProducto.BackColor = Color.FromArgb(255, 128, 128);
            rbtnEliminarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnEliminarProducto.ForeColor = Color.Black;
            rbtnEliminarProducto.Location = new Point(213, 164);
            rbtnEliminarProducto.Margin = new Padding(4, 3, 4, 3);
            rbtnEliminarProducto.Name = "rbtnEliminarProducto";
            rbtnEliminarProducto.Size = new Size(146, 43);
            rbtnEliminarProducto.TabIndex = 57;
            rbtnEliminarProducto.Text = "Eliminar";
            rbtnEliminarProducto.Click += rbtnEliminarProducto_Click;
            // 
            // btnActualizarPrecioInventario
            // 
            btnActualizarPrecioInventario.BackColor = Color.LightGreen;
            btnActualizarPrecioInventario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizarPrecioInventario.ForeColor = Color.Black;
            btnActualizarPrecioInventario.Location = new Point(11, 164);
            btnActualizarPrecioInventario.Margin = new Padding(4, 3, 4, 3);
            btnActualizarPrecioInventario.Name = "btnActualizarPrecioInventario";
            btnActualizarPrecioInventario.Size = new Size(146, 43);
            btnActualizarPrecioInventario.TabIndex = 57;
            btnActualizarPrecioInventario.Text = "Actualizar";
            btnActualizarPrecioInventario.Click += btnActualizarPrecioInventario_Click;
            // 
            // UcConfiguracion
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel3);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(roundButton1);
            Controls.Add(lblConfiguracion);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "UcConfiguracion";
            Size = new Size(1636, 1165);
            Load += UcConfiguracion_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblConfiguracion;
        private ComboBox cmbxPreciosMembresias;
        private Label lblEditarPrecios;
        private RoundButton rbtnRegistrarPrecio;
        private TextBox txtbActualizarPrecioMembresias;
        private Label lblPrecio;
        private Label lblMembresias;
        private Label lblEditarUsuarios;
        private Label lblAgregarUsuario;
        private Label lblNombre;
        private TextBox txtbNombreUsuario;
        private TextBox txtbContraseña;
        private Label lblContraseña;
        private TextBox txtbCorreo;
        private Label lblCorreo;
        private RoundButton rbtnAgregarUsuario;
        private Label lblRol;
        private ComboBox cmbxRol;
        private Label lblFechaHoraActualUC;
        private RoundButton roundButton1;
        private Panel panel1;
        private Panel panel2;
        private Label lblEliminarUsuario;
        private ComboBox cmbxEliminarUsuario;
        private RoundButton rbtnEliminarUsuario;
        private Label lblEditarPreciosInventario;
        private Label lblInventario;
        private ComboBox cmbProductos;
        private TextBox txtbPrecio;
        private Label lblPrecioI;
        private Panel panel3;
        private RoundButton btnActualizarPrecioInventario;
        private Panel panel4;
        private RoundButton rbtnEliminarProducto;
        private Label label1;
        private TextBox txtbCantidadProductos;
        private Label label3;
        private Label lblCantidad;
    }
}
