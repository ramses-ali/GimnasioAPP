namespace GimnasioApp
{
    partial class FormReporteAsistencias
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
            cbxFecha = new ComboBox();
            dgvAsistencias = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            lblTotalAsistencias = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).BeginInit();
            SuspendLayout();
            // 
            // cbxFecha
            // 
            cbxFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFecha.FormattingEnabled = true;
            cbxFecha.Location = new Point(160, 77);
            cbxFecha.Name = "cbxFecha";
            cbxFecha.Size = new Size(277, 27);
            cbxFecha.TabIndex = 0;
            // 
            // dgvAsistencias
            // 
            dgvAsistencias.BackgroundColor = Color.White;
            dgvAsistencias.BorderStyle = BorderStyle.None;
            dgvAsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencias.Location = new Point(160, 139);
            dgvAsistencias.Name = "dgvAsistencias";
            dgvAsistencias.RowHeadersWidth = 51;
            dgvAsistencias.Size = new Size(1093, 566);
            dgvAsistencias.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 55);
            label1.Name = "label1";
            label1.Size = new Size(139, 19);
            label1.TabIndex = 2;
            label1.Text = "Seleccionar Dia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 736);
            label2.Name = "label2";
            label2.Size = new Size(148, 19);
            label2.TabIndex = 3;
            label2.Text = "Total Asistencias:";
            // 
            // lblTotalAsistencias
            // 
            lblTotalAsistencias.AutoSize = true;
            lblTotalAsistencias.Location = new Point(307, 736);
            lblTotalAsistencias.Name = "lblTotalAsistencias";
            lblTotalAsistencias.Size = new Size(19, 19);
            lblTotalAsistencias.TabIndex = 4;
            lblTotalAsistencias.Text = "#";
            // 
            // FormReporteAsistencias
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1510, 822);
            Controls.Add(lblTotalAsistencias);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvAsistencias);
            Controls.Add(cbxFecha);
            Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormReporteAsistencias";
            ShowIcon = false;
            StartPosition = FormStartPosition.Manual;
            Load += FormReporteAsistencias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxFecha;
        private DataGridView dgvAsistencias;
        private Label label1;
        private Label label2;
        private Label lblTotalAsistencias;
    }
}