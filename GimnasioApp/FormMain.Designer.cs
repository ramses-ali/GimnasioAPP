namespace GimnasioApp
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            panelContenido = new Panel();
            lblFechaHoraActual = new Label();
            roundButton1 = new RoundButton();
            lblUsuario = new Label();
            lblDourietGYM = new Label();
            panel2 = new Panel();
            btnConfiguracion = new Button();
            btnReportes = new Button();
            btnCorte = new Button();
            btnCerrarSesion = new Button();
            lblVentasInvenario = new Label();
            btnInventario = new Button();
            btnRegistro = new Button();
            lblGestion = new Label();
            btnAgregar = new Button();
            lblPrincipal = new Label();
            btnInicio = new Button();
            timer = new System.Windows.Forms.Timer(components);
            panelContenido.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenido
            // 
            panelContenido.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContenido.BackColor = Color.White;
            panelContenido.Controls.Add(lblFechaHoraActual);
            panelContenido.Controls.Add(roundButton1);
            panelContenido.Location = new Point(273, 0);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(1309, 853);
            panelContenido.TabIndex = 0;
            // 
            // lblFechaHoraActual
            // 
            lblFechaHoraActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaHoraActual.AutoSize = true;
            lblFechaHoraActual.BackColor = Color.Gainsboro;
            lblFechaHoraActual.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFechaHoraActual.Location = new Point(1070, 37);
            lblFechaHoraActual.Name = "lblFechaHoraActual";
            lblFechaHoraActual.Size = new Size(0, 23);
            lblFechaHoraActual.TabIndex = 21;
            // 
            // roundButton1
            // 
            roundButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            roundButton1.BackColor = Color.Gainsboro;
            roundButton1.ForeColor = Color.Black;
            roundButton1.Location = new Point(1057, 27);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(231, 43);
            roundButton1.TabIndex = 22;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.White;
            lblUsuario.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(1050, 40);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 18);
            lblUsuario.TabIndex = 23;
            // 
            // lblDourietGYM
            // 
            lblDourietGYM.AutoSize = true;
            lblDourietGYM.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDourietGYM.Location = new Point(70, 9);
            lblDourietGYM.Name = "lblDourietGYM";
            lblDourietGYM.Size = new Size(132, 23);
            lblDourietGYM.TabIndex = 1;
            lblDourietGYM.Text = "Douriet GYM";
            lblDourietGYM.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnConfiguracion);
            panel2.Controls.Add(btnReportes);
            panel2.Controls.Add(btnCorte);
            panel2.Controls.Add(btnCerrarSesion);
            panel2.Controls.Add(lblVentasInvenario);
            panel2.Controls.Add(btnInventario);
            panel2.Controls.Add(btnRegistro);
            panel2.Controls.Add(lblGestion);
            panel2.Controls.Add(btnAgregar);
            panel2.Controls.Add(lblPrincipal);
            panel2.Controls.Add(btnInicio);
            panel2.Controls.Add(lblDourietGYM);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(267, 853);
            panel2.TabIndex = 2;
            // 
            // btnConfiguracion
            // 
            btnConfiguracion.Anchor = AnchorStyles.Bottom;
            btnConfiguracion.BackColor = Color.DarkGray;
            btnConfiguracion.FlatAppearance.BorderColor = Color.White;
            btnConfiguracion.FlatAppearance.BorderSize = 0;
            btnConfiguracion.FlatStyle = FlatStyle.Flat;
            btnConfiguracion.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfiguracion.Location = new Point(12, 632);
            btnConfiguracion.Name = "btnConfiguracion";
            btnConfiguracion.Size = new Size(243, 46);
            btnConfiguracion.TabIndex = 12;
            btnConfiguracion.Text = "        Administración";
            btnConfiguracion.TextAlign = ContentAlignment.MiddleLeft;
            btnConfiguracion.UseVisualStyleBackColor = false;
            btnConfiguracion.Click += btnConfiguracion_Click;
            // 
            // btnReportes
            // 
            btnReportes.Anchor = AnchorStyles.Bottom;
            btnReportes.BackColor = Color.SkyBlue;
            btnReportes.FlatAppearance.BorderColor = Color.White;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.Location = new Point(12, 687);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(243, 46);
            btnReportes.TabIndex = 11;
            btnReportes.Text = "        Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnCorte
            // 
            btnCorte.Anchor = AnchorStyles.Bottom;
            btnCorte.BackColor = Color.FromArgb(255, 224, 192);
            btnCorte.FlatAppearance.BorderColor = Color.White;
            btnCorte.FlatAppearance.BorderSize = 0;
            btnCorte.FlatStyle = FlatStyle.Flat;
            btnCorte.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCorte.Location = new Point(13, 741);
            btnCorte.Name = "btnCorte";
            btnCorte.Size = new Size(243, 46);
            btnCorte.TabIndex = 10;
            btnCorte.Text = "        Corte";
            btnCorte.TextAlign = ContentAlignment.MiddleLeft;
            btnCorte.UseVisualStyleBackColor = false;
            btnCorte.Click += btnCorte_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Bottom;
            btnCerrarSesion.BackColor = Color.FromArgb(255, 128, 128);
            btnCerrarSesion.FlatAppearance.BorderColor = Color.White;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.Location = new Point(13, 795);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(243, 46);
            btnCerrarSesion.TabIndex = 9;
            btnCerrarSesion.Text = "        Cerrar Sesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblVentasInvenario
            // 
            lblVentasInvenario.AutoSize = true;
            lblVentasInvenario.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentasInvenario.Location = new Point(13, 409);
            lblVentasInvenario.Name = "lblVentasInvenario";
            lblVentasInvenario.Size = new Size(167, 19);
            lblVentasInvenario.TabIndex = 8;
            lblVentasInvenario.Text = "Ventas e Inventario";
            // 
            // btnInventario
            // 
            btnInventario.BackColor = Color.White;
            btnInventario.FlatAppearance.BorderColor = Color.White;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Nirmala UI", 10.2F);
            btnInventario.Location = new Point(13, 442);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(243, 46);
            btnInventario.TabIndex = 7;
            btnInventario.Text = "        Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.UseVisualStyleBackColor = false;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnRegistro
            // 
            btnRegistro.BackColor = Color.White;
            btnRegistro.FlatAppearance.BorderColor = Color.White;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Nirmala UI", 10.2F);
            btnRegistro.Location = new Point(13, 331);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(243, 46);
            btnRegistro.TabIndex = 6;
            btnRegistro.Text = "        Registro";
            btnRegistro.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistro.UseVisualStyleBackColor = false;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // lblGestion
            // 
            lblGestion.AutoSize = true;
            lblGestion.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGestion.Location = new Point(13, 245);
            lblGestion.Name = "lblGestion";
            lblGestion.Size = new Size(141, 19);
            lblGestion.TabIndex = 5;
            lblGestion.Text = "Gestion Clientes";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.White;
            btnAgregar.FlatAppearance.BorderColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Nirmala UI", 10.2F);
            btnAgregar.Location = new Point(13, 278);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(243, 46);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "        Agregar";
            btnAgregar.TextAlign = ContentAlignment.MiddleLeft;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblPrincipal
            // 
            lblPrincipal.AutoSize = true;
            lblPrincipal.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrincipal.Location = new Point(12, 135);
            lblPrincipal.Name = "lblPrincipal";
            lblPrincipal.Size = new Size(79, 19);
            lblPrincipal.TabIndex = 3;
            lblPrincipal.Text = "Principal";
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.White;
            btnInicio.FlatAppearance.BorderColor = Color.White;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Nirmala UI", 10.2F);
            btnInicio.Location = new Point(12, 168);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(243, 46);
            btnInicio.TabIndex = 2;
            btnInicio.Text = "        Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 853);
            Controls.Add(lblUsuario);
            Controls.Add(panel2);
            Controls.Add(panelContenido);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMain";
            WindowState = FormWindowState.Maximized;
            Load += FormMain_Load_1;
            panelContenido.ResumeLayout(false);
            panelContenido.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelContenido;
        private Label lblDourietGYM;
        private Panel panel2;
        private Button btnInicio;
        private Label lblGestion;
        private Button btnAgregar;
        private Label lblPrincipal;
        private Button btnRegistro;
        private Label lblVentasInvenario;
        private Button btnInventario;
        private Button btnCerrarSesion;
        private Button btnCorte;
        private RoundButton roundButton1;
        private System.Windows.Forms.Timer timer;
        public Label lblFechaHoraActual;
        private Label lblUsuario;
        private Button btnReportes;
        private Button btnConfiguracion;
    }
}