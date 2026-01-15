namespace GimnasioApp
{
    partial class FormAsistencias
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
            txtbNombreAsistencia = new TextBox();
            lblNombre = new Label();
            lblId = new Label();
            txtbIdAsistencia = new TextBox();
            rbtnRegistrarAsistencia = new RoundButton();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // txtbNombreAsistencia
            // 
            txtbNombreAsistencia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbNombreAsistencia.BackColor = Color.White;
            txtbNombreAsistencia.BorderStyle = BorderStyle.None;
            txtbNombreAsistencia.Font = new Font("Century Gothic", 10.2F);
            txtbNombreAsistencia.Location = new Point(122, 85);
            txtbNombreAsistencia.Name = "txtbNombreAsistencia";
            txtbNombreAsistencia.PlaceholderText = " Aa";
            txtbNombreAsistencia.Size = new Size(398, 21);
            txtbNombreAsistencia.TabIndex = 14;
            txtbNombreAsistencia.TextChanged += txtbNombreAsistencia_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblNombre.Location = new Point(120, 57);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(76, 19);
            lblNombre.TabIndex = 12;
            lblNombre.Text = "Nombre";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblId.Location = new Point(37, 57);
            lblId.Name = "lblId";
            lblId.Size = new Size(25, 19);
            lblId.TabIndex = 11;
            lblId.Text = "Id";
            // 
            // txtbIdAsistencia
            // 
            txtbIdAsistencia.BackColor = Color.White;
            txtbIdAsistencia.BorderStyle = BorderStyle.None;
            txtbIdAsistencia.Font = new Font("Century Gothic", 10.2F);
            txtbIdAsistencia.Location = new Point(37, 81);
            txtbIdAsistencia.Multiline = true;
            txtbIdAsistencia.Name = "txtbIdAsistencia";
            txtbIdAsistencia.PlaceholderText = " #";
            txtbIdAsistencia.Size = new Size(70, 30);
            txtbIdAsistencia.TabIndex = 13;
            txtbIdAsistencia.TextChanged += txtbIdAsistencia_TextChanged;
            // 
            // rbtnRegistrarAsistencia
            // 
            rbtnRegistrarAsistencia.BackColor = Color.FromArgb(192, 255, 192);
            rbtnRegistrarAsistencia.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnRegistrarAsistencia.ForeColor = Color.Black;
            rbtnRegistrarAsistencia.Location = new Point(37, 163);
            rbtnRegistrarAsistencia.Margin = new Padding(4, 3, 4, 3);
            rbtnRegistrarAsistencia.Name = "rbtnRegistrarAsistencia";
            rbtnRegistrarAsistencia.Size = new Size(146, 43);
            rbtnRegistrarAsistencia.TabIndex = 23;
            rbtnRegistrarAsistencia.Text = "Registrar";
            rbtnRegistrarAsistencia.Click += rbtnRegistrarAsistencia_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(120, 81);
            panel1.Name = "panel1";
            panel1.Size = new Size(402, 30);
            panel1.TabIndex = 24;
            // 
            // FormAsistencias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(700, 550);
            Controls.Add(rbtnRegistrarAsistencia);
            Controls.Add(txtbNombreAsistencia);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Controls.Add(txtbIdAsistencia);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(350, 250);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormAsistencias";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Asistencias";
            Load += FormAsistencias_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbNombreAsistencia;
        private Label lblNombre;
        private Label lblId;
        private TextBox txtbIdAsistencia;
        private RoundButton rbtnRegistrarAsistencia;
        private Panel panel1;
    }
}