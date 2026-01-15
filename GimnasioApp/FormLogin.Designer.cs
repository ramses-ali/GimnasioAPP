namespace GimnasioApp
{
    partial class FormLogin
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
            txtContraseña = new TextBox();
            txtCorreo = new TextBox();
            CircularPictureBox = new CircularPictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            lblIniciarSesion = new Label();
            btnLogin = new RoundButton();
            ((System.ComponentModel.ISupportInitialize)CircularPictureBox).BeginInit();
            SuspendLayout();
            // 
            // txtContraseña
            // 
            txtContraseña.Anchor = AnchorStyles.None;
            txtContraseña.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(633, 477);
            txtContraseña.Multiline = true;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PlaceholderText = "Contraseña";
            txtContraseña.Size = new Size(317, 50);
            txtContraseña.TabIndex = 1;
            txtContraseña.TextChanged += textBox1_TextChanged;
            txtContraseña.KeyDown += txtContraseña_KeyDown;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.None;
            txtCorreo.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCorreo.Location = new Point(633, 413);
            txtCorreo.Multiline = true;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Usuario";
            txtCorreo.Size = new Size(317, 50);
            txtCorreo.TabIndex = 2;
            // 
            // CircularPictureBox
            // 
            CircularPictureBox.Anchor = AnchorStyles.None;
            CircularPictureBox.Image = Properties.Resources.logo;
            CircularPictureBox.Location = new Point(706, 48);
            CircularPictureBox.Name = "CircularPictureBox";
            CircularPictureBox.Size = new Size(170, 170);
            CircularPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            CircularPictureBox.TabIndex = 3;
            CircularPictureBox.TabStop = false;
            CircularPictureBox.Click += CircularPictureBox_Click;
            // 
            // lblIniciarSesion
            // 
            lblIniciarSesion.Anchor = AnchorStyles.None;
            lblIniciarSesion.AutoSize = true;
            lblIniciarSesion.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIniciarSesion.Location = new Point(712, 358);
            lblIniciarSesion.Name = "lblIniciarSesion";
            lblIniciarSesion.Size = new Size(159, 27);
            lblIniciarSesion.TabIndex = 4;
            lblIniciarSesion.Text = "Iniciar Sesion";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.Black;
            btnLogin.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(633, 546);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(317, 58);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Continuar";
            btnLogin.Click += btnLogin_Click;
            // 
            // FormLogin
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(1582, 853);
            Controls.Add(btnLogin);
            Controls.Add(lblIniciarSesion);
            Controls.Add(CircularPictureBox);
            Controls.Add(txtCorreo);
            Controls.Add(txtContraseña);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += FormLogin_Load;
            ((System.ComponentModel.ISupportInitialize)CircularPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private TextBox txtContraseña;
        private TextBox txtCorreo;
        private GimnasioApp.CircularPictureBox CircularPictureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblIniciarSesion;
        private RoundButton btnLogin;
    }
}