namespace GimnasioApp
{
    partial class FormVentas
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
            lblMembresia = new Label();
            label1 = new Label();
            lblEfectivo = new Label();
            lblTransferencia = new Label();
            cbxMembresia = new ComboBox();
            rbtnEfectivo = new RadioButton();
            rbtnTransferencia = new RadioButton();
            lblId = new Label();
            lblNombre = new Label();
            txtbIdVenta = new TextBox();
            txtbNombreVenta = new TextBox();
            lblArticulo = new Label();
            cbxArticulo = new ComboBox();
            lblCantidad = new Label();
            lblRecibi = new Label();
            lblCambio = new Label();
            txtbRecibi = new TextBox();
            txtbCambio = new TextBox();
            rbtnRegistrarVenta = new RoundButton();
            btnAgregarArticulo = new Button();
            lblTotalVenta = new Label();
            label2 = new Label();
            txtbCantidad = new TextBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // lblMembresia
            // 
            lblMembresia.AutoSize = true;
            lblMembresia.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblMembresia.Location = new Point(31, 36);
            lblMembresia.Name = "lblMembresia";
            lblMembresia.Size = new Size(101, 19);
            lblMembresia.TabIndex = 0;
            lblMembresia.Text = "Membresia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(191, 36);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 1;
            // 
            // lblEfectivo
            // 
            lblEfectivo.AutoSize = true;
            lblEfectivo.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblEfectivo.Location = new Point(307, 521);
            lblEfectivo.Name = "lblEfectivo";
            lblEfectivo.Size = new Size(74, 19);
            lblEfectivo.TabIndex = 2;
            lblEfectivo.Text = "Efectivo";
            // 
            // lblTransferencia
            // 
            lblTransferencia.AutoSize = true;
            lblTransferencia.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblTransferencia.Location = new Point(405, 521);
            lblTransferencia.Name = "lblTransferencia";
            lblTransferencia.Size = new Size(118, 19);
            lblTransferencia.TabIndex = 3;
            lblTransferencia.Text = "Transferencia";
            // 
            // cbxMembresia
            // 
            cbxMembresia.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbxMembresia.FormattingEnabled = true;
            cbxMembresia.Location = new Point(31, 60);
            cbxMembresia.Name = "cbxMembresia";
            cbxMembresia.Size = new Size(258, 29);
            cbxMembresia.TabIndex = 4;
            // 
            // rbtnEfectivo
            // 
            rbtnEfectivo.AutoSize = true;
            rbtnEfectivo.Location = new Point(333, 551);
            rbtnEfectivo.Name = "rbtnEfectivo";
            rbtnEfectivo.Size = new Size(17, 16);
            rbtnEfectivo.TabIndex = 5;
            rbtnEfectivo.TabStop = true;
            rbtnEfectivo.UseVisualStyleBackColor = true;
            // 
            // rbtnTransferencia
            // 
            rbtnTransferencia.AutoSize = true;
            rbtnTransferencia.Location = new Point(454, 551);
            rbtnTransferencia.Name = "rbtnTransferencia";
            rbtnTransferencia.Size = new Size(17, 16);
            rbtnTransferencia.TabIndex = 6;
            rbtnTransferencia.TabStop = true;
            rbtnTransferencia.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblId.Location = new Point(31, 119);
            lblId.Name = "lblId";
            lblId.Size = new Size(25, 19);
            lblId.TabIndex = 7;
            lblId.Text = "Id";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblNombre.Location = new Point(114, 119);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(76, 19);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "Nombre";
            // 
            // txtbIdVenta
            // 
            txtbIdVenta.BackColor = Color.White;
            txtbIdVenta.BorderStyle = BorderStyle.None;
            txtbIdVenta.Font = new Font("Century Gothic", 10.2F);
            txtbIdVenta.Location = new Point(31, 143);
            txtbIdVenta.Multiline = true;
            txtbIdVenta.Name = "txtbIdVenta";
            txtbIdVenta.Size = new Size(70, 28);
            txtbIdVenta.TabIndex = 9;
            txtbIdVenta.TextChanged += txtbIdVenta_TextChanged_1;
            // 
            // txtbNombreVenta
            // 
            txtbNombreVenta.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbNombreVenta.BackColor = Color.White;
            txtbNombreVenta.BorderStyle = BorderStyle.None;
            txtbNombreVenta.Font = new Font("Century Gothic", 10.2F);
            txtbNombreVenta.Location = new Point(114, 147);
            txtbNombreVenta.Name = "txtbNombreVenta";
            txtbNombreVenta.Size = new Size(331, 21);
            txtbNombreVenta.TabIndex = 10;
            txtbNombreVenta.TextChanged += txtbNombreVenta_TextChanged_1;
            txtbNombreVenta.Leave += txtbNombreVenta_Leave;
            // 
            // lblArticulo
            // 
            lblArticulo.AutoSize = true;
            lblArticulo.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblArticulo.Location = new Point(31, 223);
            lblArticulo.Name = "lblArticulo";
            lblArticulo.Size = new Size(71, 19);
            lblArticulo.TabIndex = 11;
            lblArticulo.Text = "Articulo";
            // 
            // cbxArticulo
            // 
            cbxArticulo.Font = new Font("Century Gothic", 10.2F);
            cbxArticulo.FormattingEnabled = true;
            cbxArticulo.Location = new Point(31, 255);
            cbxArticulo.Name = "cbxArticulo";
            cbxArticulo.Size = new Size(290, 29);
            cbxArticulo.TabIndex = 12;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblCantidad.Location = new Point(336, 223);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(84, 19);
            lblCantidad.TabIndex = 14;
            lblCantidad.Text = "Cantidad";
            // 
            // lblRecibi
            // 
            lblRecibi.AutoSize = true;
            lblRecibi.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblRecibi.Location = new Point(36, 520);
            lblRecibi.Name = "lblRecibi";
            lblRecibi.Size = new Size(60, 19);
            lblRecibi.TabIndex = 18;
            lblRecibi.Text = "Recibí";
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            lblCambio.Location = new Point(167, 520);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(75, 19);
            lblCambio.TabIndex = 19;
            lblCambio.Text = "Cambio";
            // 
            // txtbRecibi
            // 
            txtbRecibi.BackColor = Color.White;
            txtbRecibi.BorderStyle = BorderStyle.None;
            txtbRecibi.Font = new Font("Century Gothic", 10.2F);
            txtbRecibi.Location = new Point(37, 542);
            txtbRecibi.Multiline = true;
            txtbRecibi.Name = "txtbRecibi";
            txtbRecibi.Size = new Size(90, 30);
            txtbRecibi.TabIndex = 20;
            txtbRecibi.TextChanged += txtbRecibi_TextChanged;
            // 
            // txtbCambio
            // 
            txtbCambio.BackColor = Color.White;
            txtbCambio.BorderStyle = BorderStyle.None;
            txtbCambio.Font = new Font("Century Gothic", 10.2F);
            txtbCambio.Location = new Point(167, 542);
            txtbCambio.Multiline = true;
            txtbCambio.Name = "txtbCambio";
            txtbCambio.Size = new Size(90, 30);
            txtbCambio.TabIndex = 21;
            // 
            // rbtnRegistrarVenta
            // 
            rbtnRegistrarVenta.BackColor = Color.FromArgb(192, 255, 192);
            rbtnRegistrarVenta.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbtnRegistrarVenta.ForeColor = Color.Black;
            rbtnRegistrarVenta.Location = new Point(678, 530);
            rbtnRegistrarVenta.Margin = new Padding(4, 3, 4, 3);
            rbtnRegistrarVenta.Name = "rbtnRegistrarVenta";
            rbtnRegistrarVenta.Size = new Size(148, 43);
            rbtnRegistrarVenta.TabIndex = 22;
            rbtnRegistrarVenta.Text = "Registrar";
            rbtnRegistrarVenta.Click += rbtnRegistrarVenta_Click;
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(441, 255);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(54, 28);
            btnAgregarArticulo.TabIndex = 23;
            btnAgregarArticulo.Text = "+";
            btnAgregarArticulo.UseVisualStyleBackColor = true;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVenta.Location = new Point(568, 543);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(0, 19);
            lblTotalVenta.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(573, 520);
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 25;
            label2.Text = "Total";
            // 
            // txtbCantidad
            // 
            txtbCantidad.BackColor = Color.White;
            txtbCantidad.BorderStyle = BorderStyle.None;
            txtbCantidad.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbCantidad.Location = new Point(340, 255);
            txtbCantidad.Multiline = true;
            txtbCantidad.Name = "txtbCantidad";
            txtbCantidad.Size = new Size(84, 29);
            txtbCantidad.TabIndex = 27;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(114, 143);
            panel1.Name = "panel1";
            panel1.Size = new Size(334, 28);
            panel1.TabIndex = 28;
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(857, 606);
            Controls.Add(txtbCantidad);
            Controls.Add(label2);
            Controls.Add(lblTotalVenta);
            Controls.Add(btnAgregarArticulo);
            Controls.Add(rbtnRegistrarVenta);
            Controls.Add(txtbCambio);
            Controls.Add(txtbRecibi);
            Controls.Add(lblCambio);
            Controls.Add(lblRecibi);
            Controls.Add(lblCantidad);
            Controls.Add(cbxArticulo);
            Controls.Add(lblArticulo);
            Controls.Add(txtbNombreVenta);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Controls.Add(rbtnTransferencia);
            Controls.Add(rbtnEfectivo);
            Controls.Add(cbxMembresia);
            Controls.Add(lblTransferencia);
            Controls.Add(lblEfectivo);
            Controls.Add(label1);
            Controls.Add(lblMembresia);
            Controls.Add(txtbIdVenta);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(350, 250);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVentas";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Ventas";
            Load += FormVentas_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMembresia;
        private Label label1;
        private Label lblEfectivo;
        private Label lblTransferencia;
        private ComboBox cbxMembresia;
        private RadioButton rbtnEfectivo;
        private RadioButton rbtnTransferencia;
        private Label lblId;
        private Label lblNombre;
        private TextBox txtbIdVenta;
        private TextBox txtbNombreVenta;
        private Label lblArticulo;
        private ComboBox cbxArticulo;
        private Label lblCantidad;
        private Label lblRecibi;
        private Label lblCambio;
        private TextBox txtbRecibi;
        private TextBox txtbCambio;
        private RoundButton rbtnRegistrarVenta;
        private Button btnAgregarArticulo;
        private Label lblTotalVenta;
        private Label label2;
        private TextBox txtbCantidad;
        private Panel panel1;
    }
}