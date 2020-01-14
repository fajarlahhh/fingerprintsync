using Fingerprint.Helper;
using Fingerprint.View;
using SharpUpdate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormMain : Form
    {
        readonly fingerprintEntities fp = new fingerprintEntities();

        private SharpUpdater updater;

        public FormMain()
        {

            updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri("https://dikbud.ntbprov.go.id/absensi/download/update.xml"));

            Cursor.Current = Cursors.WaitCursor;
            Thread thread = new Thread(new ThreadStart(StartForm));
            thread.Start();
            Thread.Sleep(2000);
            InitializeComponent();
            fp.Database.Connection.Open();
            thread.Abort();
        }

        public void StartForm()
        {
            Application.Run(new FormSplashScreen());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Activate();
            AppSetting setting = new AppSetting();
            this.Text = this.Text + " v"+ Assembly.GetExecutingAssembly().GetName().Version.ToString() + " - " + Properties.Settings.Default.kantor_nama + ", " + Properties.Settings.Default.kantor_lokasi;

            if (string.IsNullOrEmpty(Properties.Settings.Default.kantor_id) == true)
            {
                FormSetKodeKantor setKantor = new FormSetKodeKantor();
                setKantor.StartPosition = FormStartPosition.CenterParent;
                setKantor.ShowDialog(this);
            }
        }

        private bool TabExist(string tabName)
        {
            foreach (TabPage tab in tabMain.TabPages)
            {
                if (tab.Name == tabName)
                    return true;
            }
            return false;
        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataPegawai"))
                {
                    tabMain.SelectTab("DataPegawai");
                }
                else
                {
                    TabPage tab = new TabPage("Data Pegawai");
                    tab.Name = "DataPegawai";
                    UcPegawai uc = new UcPegawai();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataMesin"))
                {
                    tabMain.SelectTab("DataMesin");
                }
                else
                {
                    TabPage tab = new TabPage("Data Mesin");
                    tab.Name = "DataMesin";
                    UcMesin uc = new UcMesin();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hariKhususToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataHariKhusus"))
                {
                    tabMain.SelectTab("DataHariKhusus");
                }
                else
                {
                    TabPage tab = new TabPage("Data Hari Khusus");
                    tab.Name = "DataHariKhusus";
                    UcHariKhusus uc = new UcHariKhusus();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void hariLiburToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataHariLibur"))
                {
                    tabMain.SelectTab("DataHariLibur");
                }
                else
                {
                    TabPage tab = new TabPage("Data Hari Libur");
                    tab.Name = "DataHariLibur";
                    UcHariLibur uc = new UcHariLibur();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aturanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updater.DoUpdate(false);
            FormAturan aturan = new FormAturan();
            aturan.StartPosition = FormStartPosition.CenterParent;
            aturan.ShowDialog(this);
        }

        private void izinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataIzin"))
                {
                    tabMain.SelectTab("DataIzin");
                }
                else
                {
                    TabPage tab = new TabPage("Data Izin/Tidak Ha");
                    tab.Name = "DataIzin";
                    UcIzin uc = new UcIzin();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataLog"))
                {
                    tabMain.SelectTab("DataLog");
                }
                else
                {
                    TabPage tab = new TabPage("Data Log");
                    tab.Name = "DataLog";
                    UcLog uc = new UcLog();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void downloadAbsensiMesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            if (MessageBox.Show(String.Format("Proses ini akan menghapus semua data absen di mesin.\nPastikan semua data pegawai telah di download dan telah dilakukan sinkronisasi.\nApakah anda akan melanjutkan proses ini?"),
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormProsesDownloadAbsensiDariMesin download = new FormProsesDownloadAbsensiDariMesin();
                download.StartPosition = FormStartPosition.CenterParent;
                download.ShowDialog(this);
            }
        }

        private void uploadPegawaiMesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            var log = fp.upload_download.Where(x => x.upload_download_jenis == "Upload Pegawai ke Mesin").OrderByDescending(x => x.upload_download_id).FirstOrDefault();

            if (log != null)
            {
                if (MessageBox.Show("Upload Terakhir " + log.upload_download_tanggal.ToString("dd MMMM yyyy, hh:mm:ss") + "\nApakah anda ingin upload?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    upload_download upload = new upload_download();
                    upload.upload_download_jenis = "Upload Pegawai ke Mesin";
                    upload.upload_download_tanggal = DateTime.Now;
                    fp.upload_download.Add(upload);
                    fp.SaveChanges();

                    FormProsesUploadPegawaiKeMesin proses = new FormProsesUploadPegawaiKeMesin();
                    proses.StartPosition = FormStartPosition.CenterParent;
                    proses.ShowDialog(this);
                }
            }
            else
            {
                upload_download upload = new upload_download();
                upload.upload_download_jenis = "Upload Pegawai ke Mesin";
                upload.upload_download_tanggal = DateTime.Now;
                fp.upload_download.Add(upload);
                fp.SaveChanges();

                FormProsesUploadPegawaiKeMesin proses = new FormProsesUploadPegawaiKeMesin();
                proses.StartPosition = FormStartPosition.CenterParent;
                proses.ShowDialog(this);
            }
        }
        
        private void uploadAbsensiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            FormUploadAbsensiKeWeb proses = new FormUploadAbsensiKeWeb(fp);
            proses.StartPosition = FormStartPosition.CenterParent;
            proses.ShowDialog(this);
        }

        private void uploadPegawaiKeWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            var log = fp.upload_download.Where(x => x.upload_download_jenis == "Upload Pegawai").OrderByDescending(x => x.upload_download_id).FirstOrDefault();

            if (log != null)
            {
                if (MessageBox.Show("Upload Terakhir " + log.upload_download_tanggal.ToString("dd MMMM yyyy, hh:mm:ss") + "\nApakah anda ingin upload?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    upload_download upload = new upload_download();
                    upload.upload_download_jenis = "Upload Pegawai";
                    upload.upload_download_tanggal = DateTime.Now;
                    fp.upload_download.Add(upload);
                    fp.SaveChanges();

                    FormProsesUploadPegawaiKeWeb proses = new FormProsesUploadPegawaiKeWeb();
                    proses.StartPosition = FormStartPosition.CenterParent;
                    proses.ShowDialog(this);
                }
            }
            else
            {
                upload_download upload = new upload_download();
                upload.upload_download_jenis = "Upload Pegawai";
                upload.upload_download_tanggal = DateTime.Now;
                fp.upload_download.Add(upload);
                fp.SaveChanges();

                FormProsesUploadPegawaiKeWeb proses = new FormProsesUploadPegawaiKeWeb();
                proses.StartPosition = FormStartPosition.CenterParent;
                proses.ShowDialog(this);
            }
        }



        private void setKodeKantorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            FormSetKodeKantor setKantor = new FormSetKodeKantor();
            setKantor.StartPosition = FormStartPosition.CenterParent;
            setKantor.ShowDialog(this);
        }

        private void postingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            FormPosting posting = new FormPosting();
            posting.StartPosition = FormStartPosition.CenterParent;
            posting.ShowDialog(this);
        }

        private void downloadPegawaiDariMesinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            var log = fp.upload_download.Where(x => x.upload_download_jenis == "Download Pegawai ke Mesin").OrderByDescending(x => x.upload_download_id).FirstOrDefault();

            if (log != null)
            {
                if (MessageBox.Show("Download Terakhir " + log.upload_download_tanggal.ToString("dd MMMM yyyy, hh:mm:ss") + "\nApakah anda ingin download?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    upload_download upload = new upload_download();
                    upload.upload_download_jenis = "Download Pegawai ke Mesin";
                    upload.upload_download_tanggal = DateTime.Now;
                    fp.upload_download.Add(upload);
                    fp.SaveChanges();

                    FormProsesDownloadPegawaiDariMesin proses = new FormProsesDownloadPegawaiDariMesin();
                    proses.StartPosition = FormStartPosition.CenterParent;
                    proses.ShowDialog(this);
                }
            }
            else
            {
                upload_download upload = new upload_download();
                upload.upload_download_jenis = "Download Pegawai ke Mesin";
                upload.upload_download_tanggal = DateTime.Now;
                fp.upload_download.Add(upload);
                fp.SaveChanges();

                FormProsesDownloadPegawaiDariMesin proses = new FormProsesDownloadPegawaiDariMesin();
                proses.StartPosition = FormStartPosition.CenterParent;
                proses.ShowDialog(this);
            }
        }

        private void hasilRekapitulasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                updater.DoUpdate(false);
                if (TabExist("DataRekapAbsen"))
                {
                    tabMain.SelectTab("DataRekapAbsen");
                }
                else
                {
                    TabPage tab = new TabPage("Hasil Rekapitulasi Absensi");
                    tab.Name = "DataRekapAbsen";
                    UcRekapAbsensi uc = new UcRekapAbsensi();
                    uc.Dock = DockStyle.Fill;
                    tab.Controls.Add(uc);
                    tabMain.TabPages.Add(tab);
                    tabMain.SelectedTab = tab;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kodeMasukPulangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            updater.DoUpdate(false);
            FormKodeMasukPulang mp = new FormKodeMasukPulang();
            mp.StartPosition = FormStartPosition.CenterParent;
            mp.ShowDialog(this);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }

        private void bukuManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://dikbud.ntbprov.go.id/absensi/download/manual.pdf");
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updater.DoUpdate();
        }
    }
}
