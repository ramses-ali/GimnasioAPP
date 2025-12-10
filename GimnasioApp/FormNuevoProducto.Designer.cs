namespace GimnasioApp
{
    partial class FormNuevoProducto
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
            txtbNuevoProducto = new TextBox();
            label1 = new Label();
            txtbStock = new TextBox();
            txtbPrecio = new TextBox();
            label2 = new Label();
            label3 = new Label();
            rbtnAgregarNuevoProducto = new RoundButton();
            SuspendLayout();
            // 
            // txtbNuevoProducto
            // 
            txtbNuevoProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbNuevoProducto.Location = new Point(64, 108);
            txtbNuevoProducto.Multiline = true;
            txtbNuevoProducto.Name = "txtbNuevoProducto";
            txtbNuevoProducto.Size = new Size(264, 36);
            txtbNuevoProducto.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 79);
            label1.Name = "label1";
            label1.Size = new Size(142, 19);
            label1.TabIndex = 1;
            label1.Text = "Nuevo Producto";
            // 
            // txtbStock
            // 
            txtbStock.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbStock.Location = new Point(334, 108);
            txtbStock.Multiline = true;
            txtbStock.Name = "txtbStock";
            txtbStock.PlaceholderText = "#";
            txtbStock.Size = new Size(89, 36);
            txtbStock.TabIndex = 2;
            // 
            // txtbPrecio
            // 
            txtbPrecio.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbPrecio.Location = new Point(430, 108);
            txtbPrecio.Multiline = true;
            txtbPrecio.Name = "txtbPrecio";
            txtbPrecio.PlaceholderText = "$";
            txtbPrecio.Size = new Size(88, 36);
            txtbPrecio.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(336, 79);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 4;
            label2.Text = "Stock";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(428, 79);
            label3.Name = "label3";
            label3.Size = new Size(61, 19);
            label3.TabIndex = 5;
            label3.Text = "Precio";
            // 
            // rbtnAgregarNuevoProducto
            // 
            rbtnAgregarNuevoProducto.BackColor = Color.FromArgb(192, 255, 192);
            rbtnAgregarNuevoProducto.ForeColor = Color.Black;
            rbtnAgregarNuevoProducto.Location = new Point(542, 103);
            rbtnAgregarNuevoProducto.Name = "rbtnAgregarNuevoProducto";
            rbtnAgregarNuevoProducto.Size = new Size(141, 44);
            rbtnAgregarNuevoProducto.TabIndex = 6;
            rbtnAgregarNuevoProducto.Text = "Agregar";
            rbtnAgregarNuevoProducto.Click += rbtnAgregarNuevoProducto_Click;
            // 
            // FormNuevoProducto
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(757, 231);
            Controls.Add(rbtnAgregarNuevoProducto);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtbPrecio);
            Controls.Add(txtbStock);
            Controls.Add(label1);
            Controls.Add(txtbNuevoProducto);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(740, 240);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormNuevoProducto";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbNuevoProducto;
        private Label label1;
        private TextBox txtbStock;
        private TextBox txtbPrecio;
        private Label label2;
        private Label label3;
        private RoundButton rbtnAgregarNuevoProducto;
    }
}