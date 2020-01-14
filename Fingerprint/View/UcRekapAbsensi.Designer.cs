namespace Fingerprint.View
{
    partial class UcRekapAbsensi
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
            this.dgLog = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtSampai = new System.Windows.Forms.DateTimePicker();
            this.dtDari = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPegawai = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.golongan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masuk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pulang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.istirahat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kembali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lembur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lembur_pulang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgLog
            // 
            this.dgLog.AllowUserToAddRows = false;
            this.dgLog.AllowUserToDeleteRows = false;
            this.dgLog.AllowUserToResizeRows = false;
            this.dgLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nama,
            this.nip,
            this.golongan,
            this.tanggal,
            this.hari,
            this.izin,
            this.telat,
            this.masuk,
            this.pulang,
            this.istirahat,
            this.kembali,
            this.lembur,
            this.lembur_pulang});
            this.dgLog.Location = new System.Drawing.Point(3, 29);
            this.dgLog.MultiSelect = false;
            this.dgLog.Name = "dgLog";
            this.dgLog.RowHeadersVisible = false;
            this.dgLog.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLog.ShowEditingIcon = false;
            this.dgLog.Size = new System.Drawing.Size(1328, 536);
            this.dgLog.TabIndex = 62;
            this.dgLog.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgLog_DataBindingComplete);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(622, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 21);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtSampai
            // 
            this.dtSampai.CustomFormat = "dd MMMM yyyy";
            this.dtSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSampai.Location = new System.Drawing.Point(447, 4);
            this.dtSampai.Name = "dtSampai";
            this.dtSampai.Size = new System.Drawing.Size(169, 20);
            this.dtSampai.TabIndex = 66;
            // 
            // dtDari
            // 
            this.dtDari.CustomFormat = "dd MMMM yyyy";
            this.dtDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDari.Location = new System.Drawing.Point(243, 4);
            this.dtDari.Name = "dtDari";
            this.dtDari.Size = new System.Drawing.Size(169, 20);
            this.dtDari.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "s/d";
            // 
            // cbPegawai
            // 
            this.cbPegawai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPegawai.FormattingEnabled = true;
            this.cbPegawai.Location = new System.Drawing.Point(3, 3);
            this.cbPegawai.Name = "cbPegawai";
            this.cbPegawai.Size = new System.Drawing.Size(234, 21);
            this.cbPegawai.TabIndex = 69;
            this.cbPegawai.SelectedIndexChanged += new System.EventHandler(this.cbPegawai_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(703, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 70;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nama
            // 
            this.nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nama.DataPropertyName = "nama";
            this.nama.HeaderText = "Nama";
            this.nama.Name = "nama";
            this.nama.ReadOnly = true;
            this.nama.Visible = false;
            this.nama.Width = 41;
            // 
            // nip
            // 
            this.nip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nip.DataPropertyName = "nip";
            this.nip.HeaderText = "NIP";
            this.nip.Name = "nip";
            this.nip.ReadOnly = true;
            this.nip.Visible = false;
            this.nip.Width = 31;
            // 
            // golongan
            // 
            this.golongan.DataPropertyName = "golongan";
            this.golongan.HeaderText = "Gol.";
            this.golongan.Name = "golongan";
            this.golongan.ReadOnly = true;
            this.golongan.Visible = false;
            // 
            // tanggal
            // 
            this.tanggal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tanggal.DataPropertyName = "tanggal";
            dataGridViewCellStyle1.Format = "dd MMMM yyyy";
            this.tanggal.DefaultCellStyle = dataGridViewCellStyle1;
            this.tanggal.HeaderText = "Tanggal";
            this.tanggal.Name = "tanggal";
            this.tanggal.ReadOnly = true;
            this.tanggal.Width = 71;
            // 
            // hari
            // 
            this.hari.DataPropertyName = "hari";
            this.hari.HeaderText = "Hari";
            this.hari.Name = "hari";
            this.hari.ReadOnly = true;
            // 
            // izin
            // 
            this.izin.DataPropertyName = "izin";
            this.izin.HeaderText = "Izin";
            this.izin.Name = "izin";
            this.izin.ReadOnly = true;
            // 
            // telat
            // 
            this.telat.DataPropertyName = "telat";
            this.telat.HeaderText = "Telat";
            this.telat.Name = "telat";
            this.telat.ReadOnly = true;
            // 
            // masuk
            // 
            this.masuk.DataPropertyName = "masuk";
            this.masuk.HeaderText = "Jam Masuk";
            this.masuk.Name = "masuk";
            this.masuk.ReadOnly = true;
            // 
            // pulang
            // 
            this.pulang.DataPropertyName = "pulang";
            this.pulang.HeaderText = "Jam Pulang";
            this.pulang.Name = "pulang";
            this.pulang.ReadOnly = true;
            // 
            // istirahat
            // 
            this.istirahat.DataPropertyName = "istirahat";
            this.istirahat.HeaderText = "Jam Istirahat";
            this.istirahat.Name = "istirahat";
            this.istirahat.ReadOnly = true;
            this.istirahat.Visible = false;
            // 
            // kembali
            // 
            this.kembali.DataPropertyName = "kembali";
            this.kembali.HeaderText = "Jam Kembali";
            this.kembali.Name = "kembali";
            this.kembali.ReadOnly = true;
            this.kembali.Visible = false;
            // 
            // lembur
            // 
            this.lembur.DataPropertyName = "lembur";
            this.lembur.HeaderText = "Lembur";
            this.lembur.Name = "lembur";
            this.lembur.ReadOnly = true;
            this.lembur.Visible = false;
            // 
            // lembur_pulang
            // 
            this.lembur_pulang.DataPropertyName = "lembur_pulang";
            this.lembur_pulang.HeaderText = "Jam Pulang Lembur";
            this.lembur_pulang.Name = "lembur_pulang";
            this.lembur_pulang.ReadOnly = true;
            this.lembur_pulang.Visible = false;
            // 
            // UcRekapAbsensi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbPegawai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDari);
            this.Controls.Add(this.dtSampai);
            this.Controls.Add(this.dgLog);
            this.Controls.Add(this.btnRefresh);
            this.Name = "UcRekapAbsensi";
            this.Size = new System.Drawing.Size(1334, 568);
            this.Load += new System.EventHandler(this.UcPegawai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker dtSampai;
        private System.Windows.Forms.DateTimePicker dtDari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPegawai;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn nip;
        private System.Windows.Forms.DataGridViewTextBoxColumn golongan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hari;
        private System.Windows.Forms.DataGridViewTextBoxColumn izin;
        private System.Windows.Forms.DataGridViewTextBoxColumn telat;
        private System.Windows.Forms.DataGridViewTextBoxColumn masuk;
        private System.Windows.Forms.DataGridViewTextBoxColumn pulang;
        private System.Windows.Forms.DataGridViewTextBoxColumn istirahat;
        private System.Windows.Forms.DataGridViewTextBoxColumn kembali;
        private System.Windows.Forms.DataGridViewTextBoxColumn lembur;
        private System.Windows.Forms.DataGridViewTextBoxColumn lembur_pulang;
    }
}
