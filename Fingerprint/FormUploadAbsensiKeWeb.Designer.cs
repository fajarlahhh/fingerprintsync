namespace Fingerprint
{
    partial class FormUploadAbsensiKeWeb
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
            this.btnSimpan = new System.Windows.Forms.Button();
            this.dtTanggal1 = new System.Windows.Forms.DateTimePicker();
            this.dtTanggal2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(318, 38);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 57;
            this.btnSimpan.Text = "Upload";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dtTanggal1
            // 
            this.dtTanggal1.CustomFormat = "dd MMMM yyyy";
            this.dtTanggal1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTanggal1.Location = new System.Drawing.Point(12, 12);
            this.dtTanggal1.Name = "dtTanggal1";
            this.dtTanggal1.Size = new System.Drawing.Size(173, 20);
            this.dtTanggal1.TabIndex = 58;
            // 
            // dtTanggal2
            // 
            this.dtTanggal2.CustomFormat = "dd MMMM yyyy";
            this.dtTanggal2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTanggal2.Location = new System.Drawing.Point(220, 12);
            this.dtTanggal2.Name = "dtTanggal2";
            this.dtTanggal2.Size = new System.Drawing.Size(173, 20);
            this.dtTanggal2.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "s/d";
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(9, 38);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(300, 54);
            this.lblLog.TabIndex = 63;
            // 
            // FormUploadAbsensiKeWeb
            // 
            this.AcceptButton = this.btnSimpan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 103);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTanggal2);
            this.Controls.Add(this.dtTanggal1);
            this.Controls.Add(this.btnSimpan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUploadAbsensiKeWeb";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Posting Absensi";
            this.Load += new System.EventHandler(this.FormAturan_Load);
            this.Shown += new System.EventHandler(this.FormSetKodeKantor_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DateTimePicker dtTanggal1;
        private System.Windows.Forms.DateTimePicker dtTanggal2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLog;
    }
}