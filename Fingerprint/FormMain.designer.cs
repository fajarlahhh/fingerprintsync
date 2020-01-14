namespace Fingerprint
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bacaMeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegawaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.hariKhususToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hariLiburToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mesinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pengaturanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aturanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setKodeKantorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kodeMasukPulangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.absensiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasilRekapitulasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinkronisasiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAbsensiMesinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadAbsensiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadPegawaiDariMesinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadPegawaiMesinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadPegawaiKeWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bantuanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bukuManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new Fingerprint.Helper.TabMain();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bacaMeterToolStripMenuItem,
            this.pengaturanToolStripMenuItem,
            this.absensiToolStripMenuItem,
            this.sinkronisasiToolStripMenuItem,
            this.bantuanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bacaMeterToolStripMenuItem
            // 
            this.bacaMeterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pegawaiToolStripMenuItem,
            this.toolStripSeparator1,
            this.hariKhususToolStripMenuItem,
            this.hariLiburToolStripMenuItem,
            this.toolStripSeparator2,
            this.mesinToolStripMenuItem});
            this.bacaMeterToolStripMenuItem.Name = "bacaMeterToolStripMenuItem";
            this.bacaMeterToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.bacaMeterToolStripMenuItem.Text = "Data Master";
            // 
            // pegawaiToolStripMenuItem
            // 
            this.pegawaiToolStripMenuItem.Name = "pegawaiToolStripMenuItem";
            this.pegawaiToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pegawaiToolStripMenuItem.Text = "Pegawai";
            this.pegawaiToolStripMenuItem.Click += new System.EventHandler(this.pegawaiToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
            // 
            // hariKhususToolStripMenuItem
            // 
            this.hariKhususToolStripMenuItem.Name = "hariKhususToolStripMenuItem";
            this.hariKhususToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hariKhususToolStripMenuItem.Text = "Hari Khusus";
            this.hariKhususToolStripMenuItem.Click += new System.EventHandler(this.hariKhususToolStripMenuItem_Click);
            // 
            // hariLiburToolStripMenuItem
            // 
            this.hariLiburToolStripMenuItem.Name = "hariLiburToolStripMenuItem";
            this.hariLiburToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hariLiburToolStripMenuItem.Text = "Hari Libur";
            this.hariLiburToolStripMenuItem.Click += new System.EventHandler(this.hariLiburToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // mesinToolStripMenuItem
            // 
            this.mesinToolStripMenuItem.Name = "mesinToolStripMenuItem";
            this.mesinToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.mesinToolStripMenuItem.Text = "Mesin Absensi";
            this.mesinToolStripMenuItem.Click += new System.EventHandler(this.mesinToolStripMenuItem_Click);
            // 
            // pengaturanToolStripMenuItem
            // 
            this.pengaturanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aturanToolStripMenuItem,
            this.setKodeKantorToolStripMenuItem,
            this.kodeMasukPulangToolStripMenuItem});
            this.pengaturanToolStripMenuItem.Name = "pengaturanToolStripMenuItem";
            this.pengaturanToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.pengaturanToolStripMenuItem.Text = "Pengaturan";
            // 
            // aturanToolStripMenuItem
            // 
            this.aturanToolStripMenuItem.Name = "aturanToolStripMenuItem";
            this.aturanToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.aturanToolStripMenuItem.Text = "Aturan Jam Kerja";
            this.aturanToolStripMenuItem.Click += new System.EventHandler(this.aturanToolStripMenuItem_Click);
            // 
            // setKodeKantorToolStripMenuItem
            // 
            this.setKodeKantorToolStripMenuItem.Name = "setKodeKantorToolStripMenuItem";
            this.setKodeKantorToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.setKodeKantorToolStripMenuItem.Text = "Set Kode Sekolah/KCD/Kantor";
            this.setKodeKantorToolStripMenuItem.Click += new System.EventHandler(this.setKodeKantorToolStripMenuItem_Click);
            // 
            // kodeMasukPulangToolStripMenuItem
            // 
            this.kodeMasukPulangToolStripMenuItem.Name = "kodeMasukPulangToolStripMenuItem";
            this.kodeMasukPulangToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.kodeMasukPulangToolStripMenuItem.Text = "Kode Masuk/Pulang";
            this.kodeMasukPulangToolStripMenuItem.Visible = false;
            this.kodeMasukPulangToolStripMenuItem.Click += new System.EventHandler(this.kodeMasukPulangToolStripMenuItem_Click);
            // 
            // absensiToolStripMenuItem
            // 
            this.absensiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izinToolStripMenuItem,
            this.postingToolStripMenuItem,
            this.toolStripSeparator3,
            this.logToolStripMenuItem,
            this.hasilRekapitulasiToolStripMenuItem});
            this.absensiToolStripMenuItem.Name = "absensiToolStripMenuItem";
            this.absensiToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.absensiToolStripMenuItem.Text = "Absensi";
            // 
            // izinToolStripMenuItem
            // 
            this.izinToolStripMenuItem.Name = "izinToolStripMenuItem";
            this.izinToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.izinToolStripMenuItem.Text = "Izin/Tidak Hadir";
            this.izinToolStripMenuItem.Click += new System.EventHandler(this.izinToolStripMenuItem_Click);
            // 
            // postingToolStripMenuItem
            // 
            this.postingToolStripMenuItem.Name = "postingToolStripMenuItem";
            this.postingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.postingToolStripMenuItem.Text = "Rekapitulasi Absensi";
            this.postingToolStripMenuItem.Click += new System.EventHandler(this.postingToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(207, 6);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // hasilRekapitulasiToolStripMenuItem
            // 
            this.hasilRekapitulasiToolStripMenuItem.Name = "hasilRekapitulasiToolStripMenuItem";
            this.hasilRekapitulasiToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.hasilRekapitulasiToolStripMenuItem.Text = "Hasil Rekapitulasi Absensi";
            this.hasilRekapitulasiToolStripMenuItem.Click += new System.EventHandler(this.hasilRekapitulasiToolStripMenuItem_Click);
            // 
            // sinkronisasiToolStripMenuItem
            // 
            this.sinkronisasiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadAbsensiMesinToolStripMenuItem,
            this.uploadAbsensiToolStripMenuItem,
            this.toolStripSeparator4,
            this.downloadPegawaiDariMesinToolStripMenuItem,
            this.uploadPegawaiMesinToolStripMenuItem,
            this.uploadPegawaiKeWebToolStripMenuItem});
            this.sinkronisasiToolStripMenuItem.Name = "sinkronisasiToolStripMenuItem";
            this.sinkronisasiToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.sinkronisasiToolStripMenuItem.Text = "Sinkronisasi";
            // 
            // downloadAbsensiMesinToolStripMenuItem
            // 
            this.downloadAbsensiMesinToolStripMenuItem.Name = "downloadAbsensiMesinToolStripMenuItem";
            this.downloadAbsensiMesinToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.downloadAbsensiMesinToolStripMenuItem.Text = "Download Absensi dari Mesin";
            this.downloadAbsensiMesinToolStripMenuItem.Click += new System.EventHandler(this.downloadAbsensiMesinToolStripMenuItem_Click);
            // 
            // uploadAbsensiToolStripMenuItem
            // 
            this.uploadAbsensiToolStripMenuItem.Name = "uploadAbsensiToolStripMenuItem";
            this.uploadAbsensiToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.uploadAbsensiToolStripMenuItem.Text = "Upload Absensi ke Web";
            this.uploadAbsensiToolStripMenuItem.Click += new System.EventHandler(this.uploadAbsensiToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(231, 6);
            // 
            // downloadPegawaiDariMesinToolStripMenuItem
            // 
            this.downloadPegawaiDariMesinToolStripMenuItem.Name = "downloadPegawaiDariMesinToolStripMenuItem";
            this.downloadPegawaiDariMesinToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.downloadPegawaiDariMesinToolStripMenuItem.Text = "Download Pegawai Dari Mesin";
            this.downloadPegawaiDariMesinToolStripMenuItem.Click += new System.EventHandler(this.downloadPegawaiDariMesinToolStripMenuItem_Click);
            // 
            // uploadPegawaiMesinToolStripMenuItem
            // 
            this.uploadPegawaiMesinToolStripMenuItem.Name = "uploadPegawaiMesinToolStripMenuItem";
            this.uploadPegawaiMesinToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.uploadPegawaiMesinToolStripMenuItem.Text = "Upload Pegawai ke Mesin";
            this.uploadPegawaiMesinToolStripMenuItem.Click += new System.EventHandler(this.uploadPegawaiMesinToolStripMenuItem_Click);
            // 
            // uploadPegawaiKeWebToolStripMenuItem
            // 
            this.uploadPegawaiKeWebToolStripMenuItem.Name = "uploadPegawaiKeWebToolStripMenuItem";
            this.uploadPegawaiKeWebToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.uploadPegawaiKeWebToolStripMenuItem.Text = "Upload Pegawai ke Web";
            this.uploadPegawaiKeWebToolStripMenuItem.Click += new System.EventHandler(this.uploadPegawaiKeWebToolStripMenuItem_Click);
            // 
            // bantuanToolStripMenuItem
            // 
            this.bantuanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bukuManualToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.bantuanToolStripMenuItem.Name = "bantuanToolStripMenuItem";
            this.bantuanToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.bantuanToolStripMenuItem.Text = "Bantuan";
            // 
            // bukuManualToolStripMenuItem
            // 
            this.bukuManualToolStripMenuItem.Name = "bukuManualToolStripMenuItem";
            this.bukuManualToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bukuManualToolStripMenuItem.Text = "Buku Manual";
            this.bukuManualToolStripMenuItem.Click += new System.EventHandler(this.bukuManualToolStripMenuItem_Click);
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Location = new System.Drawing.Point(12, 27);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(776, 411);
            this.tabMain.TabIndex = 11;
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "SIM Kendali";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bacaMeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegawaiToolStripMenuItem;
        private Helper.TabMain tabMain;
        private System.Windows.Forms.ToolStripMenuItem hariLiburToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hariKhususToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pengaturanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aturanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem absensiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinkronisasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadPegawaiMesinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadAbsensiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAbsensiMesinToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem uploadPegawaiKeWebToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setKodeKantorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem downloadPegawaiDariMesinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasilRekapitulasiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kodeMasukPulangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bantuanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bukuManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}