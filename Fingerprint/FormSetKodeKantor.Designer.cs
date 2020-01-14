namespace Fingerprint
{
    partial class FormSetKodeKantor
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
            this.dgKantor = new System.Windows.Forms.DataGridView();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kantor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kantor_lokasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kantor_nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kantor_mesin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgKantor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(462, 280);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 57;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // dgKantor
            // 
            this.dgKantor.AllowUserToAddRows = false;
            this.dgKantor.AllowUserToDeleteRows = false;
            this.dgKantor.AllowUserToResizeRows = false;
            this.dgKantor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgKantor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgKantor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgKantor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kantor_id,
            this.kantor_lokasi,
            this.kantor_nama,
            this.kantor_mesin});
            this.dgKantor.Location = new System.Drawing.Point(12, 38);
            this.dgKantor.MultiSelect = false;
            this.dgKantor.Name = "dgKantor";
            this.dgKantor.RowHeadersVisible = false;
            this.dgKantor.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgKantor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgKantor.ShowEditingIcon = false;
            this.dgKantor.Size = new System.Drawing.Size(525, 236);
            this.dgKantor.TabIndex = 63;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(43, 12);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(370, 20);
            this.txtCari.TabIndex = 64;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 65;
            this.label1.Text = "Cari";
            // 
            // kantor_id
            // 
            this.kantor_id.DataPropertyName = "kantor_id";
            this.kantor_id.HeaderText = "ID";
            this.kantor_id.Name = "kantor_id";
            this.kantor_id.ReadOnly = true;
            this.kantor_id.Visible = false;
            // 
            // kantor_lokasi
            // 
            this.kantor_lokasi.DataPropertyName = "kantor_lokasi";
            this.kantor_lokasi.HeaderText = "Lokasi";
            this.kantor_lokasi.Name = "kantor_lokasi";
            this.kantor_lokasi.ReadOnly = true;
            this.kantor_lokasi.Width = 200;
            // 
            // kantor_nama
            // 
            this.kantor_nama.DataPropertyName = "kantor_nama";
            this.kantor_nama.HeaderText = "Nama";
            this.kantor_nama.Name = "kantor_nama";
            this.kantor_nama.ReadOnly = true;
            this.kantor_nama.Width = 300;
            // 
            // kantor_mesin
            // 
            this.kantor_mesin.DataPropertyName = "kantor_mesin";
            this.kantor_mesin.HeaderText = "Mesin";
            this.kantor_mesin.Name = "kantor_mesin";
            this.kantor_mesin.Visible = false;
            // 
            // FormSetKodeKantor
            // 
            this.AcceptButton = this.btnSimpan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 315);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.dgKantor);
            this.Controls.Add(this.btnSimpan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetKodeKantor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Kode Sekolah/KCD/Kantor";
            this.Load += new System.EventHandler(this.FormAturan_Load);
            this.Shown += new System.EventHandler(this.FormSetKodeKantor_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgKantor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.DataGridView dgKantor;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kantor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn kantor_lokasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kantor_nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn kantor_mesin;
    }
}