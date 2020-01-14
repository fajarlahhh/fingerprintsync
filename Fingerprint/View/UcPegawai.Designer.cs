namespace Fingerprint.View
{
    partial class UcPegawai
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
            this.dgPegawai = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtNIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPanggilan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGolongan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.grForm = new System.Windows.Forms.GroupBox();
            this.chkSync = new System.Windows.Forms.CheckBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbJenisKelamin = new System.Windows.Forms.ComboBox();
            this.txtSandi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbHakAkses = new System.Windows.Forms.ComboBox();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnUploadKeMesin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblJumlah = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panggilan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.golongan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kelamin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sandi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPegawai)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgPegawai
            // 
            this.dgPegawai.AllowUserToAddRows = false;
            this.dgPegawai.AllowUserToDeleteRows = false;
            this.dgPegawai.AllowUserToResizeRows = false;
            this.dgPegawai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPegawai.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPegawai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPegawai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nip,
            this.nama,
            this.panggilan,
            this.golongan,
            this.kelamin,
            this.izin,
            this.sandi,
            this.upload});
            this.dgPegawai.Location = new System.Drawing.Point(258, 29);
            this.dgPegawai.MultiSelect = false;
            this.dgPegawai.Name = "dgPegawai";
            this.dgPegawai.RowHeadersVisible = false;
            this.dgPegawai.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPegawai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPegawai.ShowEditingIcon = false;
            this.dgPegawai.Size = new System.Drawing.Size(906, 716);
            this.dgPegawai.TabIndex = 62;
            this.dgPegawai.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgPegawai_DataBindingComplete);
            this.dgPegawai.SelectionChanged += new System.EventHandler(this.dgPegawai_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHapus);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnTambah);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 55);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(168, 19);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 12;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(87, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // txtNIP
            // 
            this.txtNIP.Location = new System.Drawing.Point(6, 83);
            this.txtNIP.MaxLength = 50;
            this.txtNIP.Name = "txtNIP";
            this.txtNIP.Size = new System.Drawing.Size(234, 20);
            this.txtNIP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NIP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nama Lengkap";
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(6, 122);
            this.txtNama.MaxLength = 500;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(234, 20);
            this.txtNama.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Panggilan";
            // 
            // txtPanggilan
            // 
            this.txtPanggilan.Location = new System.Drawing.Point(6, 161);
            this.txtPanggilan.MaxLength = 20;
            this.txtPanggilan.Name = "txtPanggilan";
            this.txtPanggilan.Size = new System.Drawing.Size(234, 20);
            this.txtPanggilan.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Golongan";
            // 
            // txtGolongan
            // 
            this.txtGolongan.Location = new System.Drawing.Point(6, 200);
            this.txtGolongan.MaxLength = 10;
            this.txtGolongan.Name = "txtGolongan";
            this.txtGolongan.Size = new System.Drawing.Size(234, 20);
            this.txtGolongan.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Jenis Kelamin";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1089, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 20);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(61, 368);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(60, 23);
            this.btnSimpan.TabIndex = 7;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(127, 368);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(60, 23);
            this.btnBatal.TabIndex = 15;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // grForm
            // 
            this.grForm.Controls.Add(this.chkSync);
            this.grForm.Controls.Add(this.txtID);
            this.grForm.Controls.Add(this.label7);
            this.grForm.Controls.Add(this.label8);
            this.grForm.Controls.Add(this.cbJenisKelamin);
            this.grForm.Controls.Add(this.txtSandi);
            this.grForm.Controls.Add(this.label1);
            this.grForm.Controls.Add(this.btnBatal);
            this.grForm.Controls.Add(this.label6);
            this.grForm.Controls.Add(this.cbHakAkses);
            this.grForm.Controls.Add(this.label4);
            this.grForm.Controls.Add(this.txtGolongan);
            this.grForm.Controls.Add(this.btnSimpan);
            this.grForm.Controls.Add(this.txtPanggilan);
            this.grForm.Controls.Add(this.label5);
            this.grForm.Controls.Add(this.label3);
            this.grForm.Controls.Add(this.txtNIP);
            this.grForm.Controls.Add(this.label2);
            this.grForm.Controls.Add(this.txtNama);
            this.grForm.Enabled = false;
            this.grForm.Location = new System.Drawing.Point(3, 64);
            this.grForm.Name = "grForm";
            this.grForm.Size = new System.Drawing.Size(249, 406);
            this.grForm.TabIndex = 64;
            this.grForm.TabStop = false;
            this.grForm.Text = "Form";
            // 
            // chkSync
            // 
            this.chkSync.AutoSize = true;
            this.chkSync.Checked = true;
            this.chkSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSync.Location = new System.Drawing.Point(6, 345);
            this.chkSync.Name = "chkSync";
            this.chkSync.Size = new System.Drawing.Size(131, 17);
            this.chkSync.TabIndex = 21;
            this.chkSync.Text = "Synchronize Ke Mesin";
            this.chkSync.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkSync.UseVisualStyleBackColor = true;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(6, 44);
            this.txtID.MaxLength = 20;
            this.txtID.Name = "txtID";
            this.txtID.ShortcutsEnabled = false;
            this.txtID.Size = new System.Drawing.Size(234, 20);
            this.txtID.TabIndex = 1;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Kata Sandi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "ID";
            // 
            // cbJenisKelamin
            // 
            this.cbJenisKelamin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJenisKelamin.FormattingEnabled = true;
            this.cbJenisKelamin.Items.AddRange(new object[] {
            "Laki-laki",
            "Perempuan"});
            this.cbJenisKelamin.Location = new System.Drawing.Point(6, 239);
            this.cbJenisKelamin.Name = "cbJenisKelamin";
            this.cbJenisKelamin.Size = new System.Drawing.Size(234, 21);
            this.cbJenisKelamin.TabIndex = 6;
            // 
            // txtSandi
            // 
            this.txtSandi.Location = new System.Drawing.Point(6, 319);
            this.txtSandi.MaxLength = 6;
            this.txtSandi.Name = "txtSandi";
            this.txtSandi.Size = new System.Drawing.Size(234, 20);
            this.txtSandi.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Hak Akses";
            // 
            // cbHakAkses
            // 
            this.cbHakAkses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHakAkses.FormattingEnabled = true;
            this.cbHakAkses.Items.AddRange(new object[] {
            "Administrator",
            "User"});
            this.cbHakAkses.Location = new System.Drawing.Point(6, 279);
            this.cbHakAkses.Name = "cbHakAkses";
            this.cbHakAkses.Size = new System.Drawing.Size(234, 21);
            this.cbHakAkses.TabIndex = 17;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(289, 4);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(198, 20);
            this.txtCari.TabIndex = 65;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // btnCetak
            // 
            this.btnCetak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCetak.Location = new System.Drawing.Point(1008, 3);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(75, 20);
            this.btnCetak.TabIndex = 68;
            this.btnCetak.Text = "Export Excel";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUploadKeMesin
            // 
            this.btnUploadKeMesin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadKeMesin.Location = new System.Drawing.Point(927, 3);
            this.btnUploadKeMesin.Name = "btnUploadKeMesin";
            this.btnUploadKeMesin.Size = new System.Drawing.Size(75, 20);
            this.btnUploadKeMesin.TabIndex = 69;
            this.btnUploadKeMesin.Text = "Sync. Mesin";
            this.btnUploadKeMesin.UseVisualStyleBackColor = true;
            this.btnUploadKeMesin.Click += new System.EventHandler(this.btnUploadKeMesin_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.Location = new System.Drawing.Point(9, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 13);
            this.panel1.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 476);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 71;
            this.label9.Text = "Belum Synchronize Ke Mesin";
            // 
            // lblJumlah
            // 
            this.lblJumlah.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblJumlah.AutoSize = true;
            this.lblJumlah.Location = new System.Drawing.Point(3, 732);
            this.lblJumlah.Name = "lblJumlah";
            this.lblJumlah.Size = new System.Drawing.Size(40, 13);
            this.lblJumlah.TabIndex = 72;
            this.lblJumlah.Text = "Jumlah";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 73;
            this.label10.Text = "Cari";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
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
            // panggilan
            // 
            this.panggilan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.panggilan.DataPropertyName = "panggilan";
            this.panggilan.HeaderText = "Panggilan";
            this.panggilan.Name = "panggilan";
            this.panggilan.ReadOnly = true;
            this.panggilan.Width = 79;
            // 
            // golongan
            // 
            this.golongan.DataPropertyName = "golongan";
            this.golongan.HeaderText = "Golongan";
            this.golongan.Name = "golongan";
            this.golongan.ReadOnly = true;
            this.golongan.Width = 70;
            // 
            // kelamin
            // 
            this.kelamin.DataPropertyName = "kelamin";
            this.kelamin.HeaderText = "Jenis Kelamin";
            this.kelamin.Name = "kelamin";
            this.kelamin.ReadOnly = true;
            // 
            // izin
            // 
            this.izin.DataPropertyName = "izin";
            this.izin.HeaderText = "Hak Akses";
            this.izin.Name = "izin";
            this.izin.ReadOnly = true;
            // 
            // sandi
            // 
            this.sandi.DataPropertyName = "sandi";
            this.sandi.HeaderText = "Sandi";
            this.sandi.Name = "sandi";
            this.sandi.ReadOnly = true;
            // 
            // upload
            // 
            this.upload.DataPropertyName = "upload";
            this.upload.HeaderText = "Sync. Mesin";
            this.upload.Name = "upload";
            this.upload.ReadOnly = true;
            // 
            // UcPegawai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblJumlah);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUploadKeMesin);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.grForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgPegawai);
            this.Enabled = false;
            this.Name = "UcPegawai";
            this.Size = new System.Drawing.Size(1167, 748);
            this.Load += new System.EventHandler(this.UcPegawai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPegawai)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grForm.ResumeLayout(false);
            this.grForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPegawai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGolongan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPanggilan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNIP;
        private System.Windows.Forms.GroupBox grForm;
        private System.Windows.Forms.ComboBox cbJenisKelamin;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSandi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbHakAkses;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUploadKeMesin;
        private System.Windows.Forms.CheckBox chkSync;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblJumlah;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nip;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn panggilan;
        private System.Windows.Forms.DataGridViewTextBoxColumn golongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kelamin;
        private System.Windows.Forms.DataGridViewTextBoxColumn izin;
        private System.Windows.Forms.DataGridViewTextBoxColumn sandi;
        private System.Windows.Forms.DataGridViewTextBoxColumn upload;
    }
}
