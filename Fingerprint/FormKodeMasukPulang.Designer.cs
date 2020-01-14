namespace Fingerprint
{
    partial class FormKodeMasukPulang
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
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtMasuk = new System.Windows.Forms.TextBox();
            this.txtPulang = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Masuk";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Pulang";
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(49, 84);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 57;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtMasuk
            // 
            this.txtMasuk.Location = new System.Drawing.Point(107, 31);
            this.txtMasuk.MaxLength = 1;
            this.txtMasuk.Name = "txtMasuk";
            this.txtMasuk.Size = new System.Drawing.Size(53, 20);
            this.txtMasuk.TabIndex = 58;
            this.txtMasuk.Text = "0";
            // 
            // txtPulang
            // 
            this.txtPulang.Location = new System.Drawing.Point(107, 58);
            this.txtPulang.MaxLength = 1;
            this.txtPulang.Name = "txtPulang";
            this.txtPulang.Size = new System.Drawing.Size(53, 20);
            this.txtPulang.TabIndex = 59;
            this.txtPulang.Text = "1";
            // 
            // FormKodeMasukPulang
            // 
            this.AcceptButton = this.btnSimpan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 121);
            this.Controls.Add(this.txtPulang);
            this.Controls.Add(this.txtMasuk);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormKodeMasukPulang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kode Masuk/Pulang";
            this.Load += new System.EventHandler(this.FormAturan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtMasuk;
        private System.Windows.Forms.TextBox txtPulang;
    }
}