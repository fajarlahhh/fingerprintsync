namespace Fingerprint.View
{
    partial class UcIzin
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
            this.label3 = new System.Windows.Forms.Label();
            this.dtTanggal2 = new System.Windows.Forms.DateTimePicker();
            this.cbJenis = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPegawai = new System.Windows.Forms.ComboBox();
            this.dtTanggal1 = new System.Windows.Forms.DateTimePicker();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.dtTahun = new System.Windows.Forms.DateTimePicker();
            this.dgIzin = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.pegawai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jenis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keterangan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.grForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIzin)).BeginInit();
            this.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pegawai";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(9, 202);
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
            this.btnSimpan.Location = new System.Drawing.Point(61, 228);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(60, 23);
            this.btnSimpan.TabIndex = 14;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(127, 228);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(60, 23);
            this.btnBatal.TabIndex = 15;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // grForm
            // 
            this.grForm.Controls.Add(this.label3);
            this.grForm.Controls.Add(this.dtTanggal2);
            this.grForm.Controls.Add(this.cbJenis);
            this.grForm.Controls.Add(this.label5);
            this.grForm.Controls.Add(this.label4);
            this.grForm.Controls.Add(this.cbPegawai);
            this.grForm.Controls.Add(this.dtTanggal1);
            this.grForm.Controls.Add(this.label1);
            this.grForm.Controls.Add(this.btnBatal);
            this.grForm.Controls.Add(this.btnSimpan);
            this.grForm.Controls.Add(this.label2);
            this.grForm.Controls.Add(this.txtKeterangan);
            this.grForm.Enabled = false;
            this.grForm.Location = new System.Drawing.Point(3, 64);
            this.grForm.Name = "grForm";
            this.grForm.Size = new System.Drawing.Size(249, 289);
            this.grForm.TabIndex = 64;
            this.grForm.TabStop = false;
            this.grForm.Text = "Form";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Sampai Tanggal";
            // 
            // dtTanggal2
            // 
            this.dtTanggal2.Location = new System.Drawing.Point(9, 123);
            this.dtTanggal2.Name = "dtTanggal2";
            this.dtTanggal2.Size = new System.Drawing.Size(234, 20);
            this.dtTanggal2.TabIndex = 23;
            // 
            // cbJenis
            // 
            this.cbJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJenis.FormattingEnabled = true;
            this.cbJenis.Items.AddRange(new object[] {
            "Sakit",
            "Izin/Keperluan Lain",
            "Dispensasi",
            "Tugas Dinas",
            "Cuti"});
            this.cbJenis.Location = new System.Drawing.Point(9, 162);
            this.cbJenis.Name = "cbJenis";
            this.cbJenis.Size = new System.Drawing.Size(234, 21);
            this.cbJenis.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Jenis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Dari Tanggal";
            // 
            // cbPegawai
            // 
            this.cbPegawai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPegawai.FormattingEnabled = true;
            this.cbPegawai.Location = new System.Drawing.Point(9, 44);
            this.cbPegawai.Name = "cbPegawai";
            this.cbPegawai.Size = new System.Drawing.Size(234, 21);
            this.cbPegawai.TabIndex = 19;
            // 
            // dtTanggal1
            // 
            this.dtTanggal1.Location = new System.Drawing.Point(9, 84);
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
            // dgIzin
            // 
            this.dgIzin.AllowUserToAddRows = false;
            this.dgIzin.AllowUserToDeleteRows = false;
            this.dgIzin.AllowUserToResizeRows = false;
            this.dgIzin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgIzin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgIzin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIzin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pegawai,
            this.nip,
            this.nama,
            this.tanggal,
            this.jenis,
            this.keterangan});
            this.dgIzin.Location = new System.Drawing.Point(258, 29);
            this.dgIzin.MultiSelect = false;
            this.dgIzin.Name = "dgIzin";
            this.dgIzin.RowHeadersVisible = false;
            this.dgIzin.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgIzin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgIzin.ShowEditingIcon = false;
            this.dgIzin.Size = new System.Drawing.Size(592, 536);
            this.dgIzin.TabIndex = 69;
            this.dgIzin.SelectionChanged += new System.EventHandler(this.dgPegawai_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Cari";
            // 
            // pegawai
            // 
            this.pegawai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pegawai.DataPropertyName = "pegawai";
            this.pegawai.HeaderText = "pegawai";
            this.pegawai.Name = "pegawai";
            this.pegawai.ReadOnly = true;
            this.pegawai.Visible = false;
            this.pegawai.Width = 53;
            // 
            // nip
            // 
            this.nip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nip.DataPropertyName = "nip";
            this.nip.HeaderText = "NIP";
            this.nip.Name = "nip";
            this.nip.ReadOnly = true;
            this.nip.Width = 50;
            // 
            // nama
            // 
            this.nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nama.DataPropertyName = "nama";
            this.nama.HeaderText = "Nama";
            this.nama.Name = "nama";
            this.nama.ReadOnly = true;
            this.nama.Width = 60;
            // 
            // tanggal
            // 
            this.tanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tanggal.DataPropertyName = "tanggal";
            dataGridViewCellStyle1.Format = "dd MMMM yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.tanggal.HeaderText = "Tanggal";
            this.tanggal.Name = "tanggal";
            this.tanggal.ReadOnly = true;
            this.tanggal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tanggal.Width = 71;
            // 
            // jenis
            // 
            this.jenis.DataPropertyName = "jenis";
            this.jenis.HeaderText = "Jenis";
            this.jenis.Name = "jenis";
            this.jenis.ReadOnly = true;
            // 
            // keterangan
            // 
            this.keterangan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.keterangan.DataPropertyName = "keterangan";
            this.keterangan.HeaderText = "Keterangan";
            this.keterangan.Name = "keterangan";
            this.keterangan.ReadOnly = true;
            this.keterangan.Width = 87;
            // 
            // UcIzin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgIzin);
            this.Controls.Add(this.dtTahun);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.grForm);
            this.Controls.Add(this.groupBox1);
            this.Enabled = false;
            this.Name = "UcIzin";
            this.Size = new System.Drawing.Size(853, 568);
            this.Load += new System.EventHandler(this.UcPegawai_Load);
            this.groupBox1.ResumeLayout(false);
            this.grForm.ResumeLayout(false);
            this.grForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIzin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.ComboBox cbPegawai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbJenis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgIzin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtTanggal2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn pegawai;
        private System.Windows.Forms.DataGridViewTextBoxColumn nip;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn jenis;
        private System.Windows.Forms.DataGridViewTextBoxColumn keterangan;
    }
}
