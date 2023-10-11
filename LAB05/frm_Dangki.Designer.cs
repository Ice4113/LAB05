namespace LAB05
{
    partial class frm_Dangki
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.CboChuyenNgnah = new System.Windows.Forms.ComboBox();
            this.dgvDangKi = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng Ký Chuyên Ngành";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chuyên Ngành";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khoa";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cboKhoa
            // 
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(276, 63);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(334, 21);
            this.cboKhoa.TabIndex = 3;
            // 
            // CboChuyenNgnah
            // 
            this.CboChuyenNgnah.FormattingEnabled = true;
            this.CboChuyenNgnah.Location = new System.Drawing.Point(276, 92);
            this.CboChuyenNgnah.Name = "CboChuyenNgnah";
            this.CboChuyenNgnah.Size = new System.Drawing.Size(334, 21);
            this.CboChuyenNgnah.TabIndex = 4;
            // 
            // dgvDangKi
            // 
            this.dgvDangKi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKi.Location = new System.Drawing.Point(57, 119);
            this.dgvDangKi.Name = "dgvDangKi";
            this.dgvDangKi.Size = new System.Drawing.Size(776, 268);
            this.dgvDangKi.TabIndex = 5;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(665, 408);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 6;
            this.Add.Text = "Đăng Ký";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // frm_Dangki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.dgvDangKi);
            this.Controls.Add(this.CboChuyenNgnah);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_Dangki";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frm_Dangki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.ComboBox CboChuyenNgnah;
        private System.Windows.Forms.DataGridView dgvDangKi;
        private System.Windows.Forms.Button Add;
    }
}