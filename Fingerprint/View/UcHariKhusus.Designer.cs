namespace Fingerprint.View
{
    partial class UcHariKhusus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgHariKhusus = new System.Windows.Forms.DataGridView();
            this.tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.grForm = new System.Windows.Forms.GroupBox();
            this.dtTanggal2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTanggal1 = new System.Windows.Forms.DateTimePicker();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.dtTahun = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgHariKhusus)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgHariKhusus
            // 
            this.dgHariKhusus.AllowUserToAddRows = false;
            this.dgHariKhusus.AllowUserToDeleteRows = false;
            this.dgHariKhusus.AllowUserToResizeRows = false;
            this.dgHariKhusus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgHariKhusus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgHariKhusus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHariKhusus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tanggal,
            this.keterangan});
            this.dgHariKhusus.Location = new System.Drawing.Point(258, 29);
            this.dgHariKhusus.MultiSelect = false;
            this.dgHariKhusus.Name = "dgHariKhusus";
            this.dgHariKhusus.RowHeadersVisible = false;
            this.dgHariKhusus.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgHariKhusus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHariKhusus.ShowEditingIcon = false;
            this.dgHariKhusus.Size = new System.Drawing.Size(592, 536);
            this.dgHariKhusus.TabIndex = 62;
            this.dgHariKhusus.SelectionChanged += new System.EventHandler(this.dgPegawai_SelectionChanged);
            // 
            // tanggal
            // 
            this.tanggal.DataPropertyName = "tanggal";
            dataGridViewCellStyle1.Format = "dd MMMM yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.tanggal.HeaderText = "Tanggal";
            this.tanggal.Name = "tanggal";
            this.tanggal.ReadOnly = true;
            this.tanggal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tanggal.Width = 150;
            // 
            // keterangan
            // 
            this.keterangan.DataPropertyName = "keterangan";
            this.keterangan.HeaderText = "Keterangan";
            this.keterangan.Name = "keterangan";
            this.keterangan.ReadOnly = true;
            this.keterangan.Width = 250;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHapus);
            this.groupBox1.Controls.Add(this.btnTambah);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 55);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(87, 19);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(6, 19);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 10;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dari Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(9, 122);
            this.txtKeterangan.MaxLength = 250;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(234, 20);
            this.txtKeterangan.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(698, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(61, 148);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(60, 23);
            this.btnSimpan.TabIndex = 14;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(127, 148);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(60, 23);
            this.btnBatal.TabIndex = 15;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // grForm
            // 
            this.grForm.Controls.Add(this.dtTanggal2);
            this.grForm.Controls.Add(this.label3);
            this.grForm.Controls.Add(this.dtTanggal1);
            this.grForm.Controls.Add(this.label1);
            this.grForm.Controls.Add(this.btnBatal);
            this.grForm.Controls.Add(this.btnSimpan);
            this.grForm.Controls.Add(this.label2);
            this.grForm.Controls.Add(this.txtKeterangan);
            this.grForm.Enabled = false;
            this.grForm.Location = new System.Drawing.Point(3, 64);
            this.grForm.Name = "grForm";
            this.grForm.Size = new System.Drawing.Size(249, 180);
            this.grForm.TabIndex = 64;
            this.grForm.TabStop = false;
            this.grForm.Text = "Form";
            // 
            // dtTanggal2
            // 
            this.dtTanggal2.Location = new System.Drawing.Point(9, 83);
            this.dtTanggal2.Name = "dtTanggal2";
            this.dtTanggal2.Size = new System.Drawing.Size(234, 20);
            this.dtTanggal2.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sampai Tanggal";
            // 
            // dtTanggal1
            // 
            this.dtTanggal1.Location = new System.Drawing.Point(9, 44);
            this.dtTanggal1.Name = "dtTanggal1";
            this.dtTanggal1.Size = new System.Drawing.Size(234, 20);
            this.dtTanggal1.TabIndex = 16;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(289, 3);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(198, 20);
            this.txtCari.TabIndex = 65;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // dtTahun
            // 
            this.dtTahun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTahun.CustomFormat = "yyyy";
            this.dtTahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTahun.Location = new System.Drawing.Point(779, 3);
            this.dtTahun.Name = "dtTahun";
            this.dtTahun.ShowUpDown = true;
            this.dtTahun.Size = new System.Drawing.Size(71, 20);
            this.dtTahun.TabIndex = 68;
            this.dtTahun.Value = new System.DateTime(2018, 1, 4, 10, 53, 58, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Cari";
            // 
            // UcHariKhusus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtTahun);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.grForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgHariKhusus);
            this.Enabled = false;
            this.Name = "UcHariKhusus";
            this.Size = new System.Drawing.Size(853, 568);
            this.Load += new System.EventHandler(this.UcPegawai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgHariKhusus)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grForm.ResumeLayout(false);
            this.grForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgHariKhusus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grForm;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.DateTimePicker dtTanggal1;
        private System.Windows.Forms.DateTimePicker dtTahun;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn keterangan;
        private System.Windows.Forms.DateTimePicker dtTanggal2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
