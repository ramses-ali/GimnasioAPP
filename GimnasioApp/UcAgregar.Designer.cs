namespace GimnasioApp
{
    partial class UcAgregar
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
            lblAgregar = new Label();
            lblFechaHoraActualUC = new Label();
            roundButton1 = new RoundButton();
            rbtnRegistrarCliente = new RoundButton();
            txtbNombreCliente = new TextBox();
            lblNombre = new Label();
            txtbApellidosCliente = new TextBox();
            lblApellidos = new Label();
            txtbCelular = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblAgregar
            // 
            lblAgregar.AutoSize = true;
            lblAgregar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAgregar.Location = new Point(3, 10);
            lblAgregar.Name = "lblAgregar";
            lblAgregar.Size = new Size(138, 19);
            lblAgregar.TabIndex = 21;
            lblAgregar.Text = "Agregar Cliente";
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
            lblFechaHoraActualUC.TabIndex = 23;
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1057, 27);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 24;
            // 
            // rbtnRegistrarCliente
            // 
            rbtnRegistrarCliente.BackColor = Color.LightGreen;
            rbtnRegistrarCliente.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnRegistrarCliente.ForeColor = Color.Black;
            rbtnRegistrarCliente.Location = new Point(65, 251);
            rbtnRegistrarCliente.Margin = new Padding(4, 3, 4, 3);
            rbtnRegistrarCliente.Name = "rbtnRegistrarCliente";
            rbtnRegistrarCliente.Size = new Size(146, 43);
            rbtnRegistrarCliente.TabIndex = 27;
            rbtnRegistrarCliente.Text = "Registrar";
            rbtnRegistrarCliente.Click += rbtnRegistrarCliente_Click;
            // 
            // txtbNombreCliente
            // 
            txtbNombreCliente.BackColor = Color.WhiteSmoke;
            txtbNombreCliente.BorderStyle = BorderStyle.None;
            txtbNombreCliente.Font = new Font("Century Gothic", 10.2F);
            txtbNombreCliente.Location = new Point(65, 173);
            txtbNombreCliente.Multiline = true;
            txtbNombreCliente.Name = "txtbNombreCliente";
            txtbNombreCliente.Size = new Size(269, 30);
            txtbNombreCliente.TabIndex = 26;
            txtbNombreCliente.TextChanged += txtbNombreCliente_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblNombre.Location = new Point(65, 149);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(76, 19);
            lblNombre.TabIndex = 25;
            lblNombre.Text = "Nombre";
            // 
            // txtbApellidosCliente
            // 
            txtbApellidosCliente.BackColor = Color.WhiteSmoke;
            txtbApellidosCliente.BorderStyle = BorderStyle.None;
            txtbApellidosCliente.Font = new Font("Century Gothic", 10.2F);
            txtbApellidosCliente.Location = new Point(340, 173);
            txtbApellidosCliente.Multiline = true;
            txtbApellidosCliente.Name = "txtbApellidosCliente";
            txtbApellidosCliente.Size = new Size(269, 30);
            txtbApellidosCliente.TabIndex = 29;
            txtbApellidosCliente.TextChanged += txtbApellidosCliente_TextChanged;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblApellidos.Location = new Point(340, 149);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(86, 19);
            lblApellidos.TabIndex = 28;
            lblApellidos.Text = "Apellidos";
            // 
            // txtbCelular
            // 
            txtbCelular.BackColor = Color.WhiteSmoke;
            txtbCelular.BorderStyle = BorderStyle.None;
            txtbCelular.Font = new Font("Century Gothic", 10.2F);
            txtbCelular.Location = new Point(635, 173);
            txtbCelular.Multiline = true;
            txtbCelular.Name = "txtbCelular";
            txtbCelular.Size = new Size(269, 30);
            txtbCelular.TabIndex = 31;
            txtbCelular.TextChanged += txtbCelular_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            label1.Location = new Point(635, 149);
            label1.Name = "label1";
            label1.Size = new Size(67, 19);
            label1.TabIndex = 30;
            label1.Text = "Celular";
            // 
            // UcAgregar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(txtbCelular);
            Controls.Add(label1);
            Controls.Add(txtbApellidosCliente);
            Controls.Add(lblApellidos);
            Controls.Add(rbtnRegistrarCliente);
            Controls.Add(txtbNombreCliente);
            Controls.Add(lblNombre);
            Controls.Add(lblFechaHoraActualUC);
            Controls.Add(roundButton1);
            Controls.Add(lblAgregar);
            Name = "UcAgregar";
            Size = new Size(1309, 853);
            Load += UcAgregar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblAgregar;
        private Label lblFechaHoraActualUC;
        private RoundButton roundButton1;
        private RoundButton rbtnRegistrarCliente;
        private TextBox txtbNombreCliente;
        private Label lblNombre;
        private TextBox txtbApellidosCliente;
        private Label lblApellidos;
        private TextBox txtbCelular;
        private Label label1;
    }
}
