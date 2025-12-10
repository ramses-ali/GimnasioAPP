namespace GimnasioApp
{
    partial class FormEditarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellidos = new TextBox();
            txtTelefono = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnGuardar = new RoundButton();
            btnEliminar = new RoundButton();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.WhiteSmoke;
            txtNombre.Location = new Point(81, 90);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(285, 28);
            txtNombre.TabIndex = 0;
            // 
            // txtApellidos
            // 
            txtApellidos.BackColor = Color.WhiteSmoke;
            txtApellidos.Location = new Point(372, 90);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(285, 28);
            txtApellidos.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.WhiteSmoke;
            txtTelefono.Location = new Point(680, 87);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(196, 28);
            txtTelefono.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            label1.Location = new Point(81, 54);
            label1.Name = "label1";
            label1.Size = new Size(84, 19);
            label1.TabIndex = 4;
            label1.Text = "Nombres";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            label2.Location = new Point(372, 54);
            label2.Name = "label2";
            label2.Size = new Size(86, 19);
            label2.TabIndex = 5;
            label2.Text = "Apellidos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            label3.Location = new Point(680, 54);
            label3.Name = "label3";
            label3.Size = new Size(79, 19);
            label3.TabIndex = 6;
            label3.Text = "Telefono";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(192, 255, 192);
            btnGuardar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Location = new Point(81, 163);
            btnGuardar.Margin = new Padding(4, 3, 4, 3);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(161, 44);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 192, 192);
            btnEliminar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.Location = new Point(292, 163);
            btnEliminar.Margin = new Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(161, 44);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormEditarCliente
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1120, 308);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombre);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(300, 200);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormEditarCliente";
            ShowIcon = false;
            StartPosition = FormStartPosition.Manual;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellidos;
        private TextBox txtTelefono;
        private Label label1;
        private Label label2;
        private Label label3;
        private RoundButton btnGuardar;
        private RoundButton btnEliminar;
    }
}