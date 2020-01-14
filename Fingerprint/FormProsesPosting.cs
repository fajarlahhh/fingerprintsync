using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using zkemkeeper;
using System.Collections.Generic;
using Fingerprint.View;

namespace Fingerprint
{
    public partial class FormProsesPosting : Form
    {
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        readonly fingerprintEntities fp = new fingerprintEntities();
        public DateTime tgl1 { get; set; }
        public DateTime tgl2 { get; set; }
        //string kd_masuk = "";
        //string kd_pulang = "";

        public FormProsesPosting()
        {
            InitializeComponent();
            //kd_masuk = Properties.Settings.Default.masuk;
            //kd_pulang = Properties.Settings.Default.pulang;
            //if(kd_masuk.Length == 0 || kd_pulang.Length == 0)
            //{
            //    MessageBox.Show("Mohon setting kode masuk dan kode pulang");
            //    FormKodeMasukPulang mp = new FormKodeMasukPulang();
            //    mp.ShowDialog();
            //}
        }

        private void btnBatal_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bwUpload.CancelAsync();
        }

        private void bwPosting_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var noNIP = fp.pegawais.Where(x => x.pegawai_nip.Equals(null) || x.pegawai_nip.Trim().Equals("")).Count();
                if (noNIP > 0)
                {
                    MessageBox.Show("Tidak dapat memposting.\nMasih ada data pegawai dengan nip kosong");
                    e.Cancel = true;
                }

                upload_download upload = new upload_download();
                upload.upload_download_keterangan = "Data " + tgl1.ToString("dd MMMM yyyy") + " s/d " + tgl1.ToString("dd MMMM yyyy");
                upload.upload_download_jenis = "Rekap Absen";
                upload.upload_download_tanggal = DateTime.Now;
                fp.upload_download.Add(upload);
                fp.SaveChanges();

                lblProses.Invoke(new Action(() => lblProses.Text = "Menghapus data " + tgl1.ToString("dd MMMM yyyy") + " s/d " + tgl1.ToString("dd MMMM yyyy")));
                fp.absens.RemoveRange(fp.absens.Where(x => x.absen_tanggal >= tgl1.Date || x.absen_tanggal <= tgl1.Date));
                fp.SaveChanges();

                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data aturan"));
                var dtAturan = fp.aturans.ToList();
                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data hari khusus"));
                var dtKhusus = fp.hari_khusus.Where(x => x.hari_khusus_tanggal >= tgl1 && x.hari_khusus_tanggal <= tgl2).ToList();
                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data hari libur"));
                var dtLibur = fp.liburs.Where(x => x.libur_tanggal >= tgl1 || x.libur_tanggal <= tgl2).ToList();
                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data hari log"));
                var log = fp.logs.Where(x => x.log_tanggal >= tgl1 && x.log_tanggal <= tgl2).ToList();
                Console.WriteLine(log.Count);
                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data izin"));
                var izin = fp.izins.Where(x => x.izin_tanggal >= tgl1 && x.izin_tanggal <= tgl2).ToList();
                var pegawai = fp.pegawais.ToList();
                var jml = pegawai.Count() <= 0 ? 1 : pegawai.Count();
                int i = 1;
                foreach(var row in pegawai)
                {
					var pegawai_id = row.pegawai_id;
                    List<absen> dtAbsen = new List<absen>();
                    for (var tgl = tgl1; tgl <= tgl2; tgl = tgl.AddDays(1))
                    {
                        lblProses.Invoke(new Action(() => lblProses.Text = "Memproses log " + row.pegawai_nama + " tanggal " + tgl.ToString()));
                        var aturan = dtAturan.Where(x => x.aturan_hari.Equals((int)tgl.DayOfWeek + 1)).FirstOrDefault();

                        string absen_hari = "b";
                        TimeSpan masuk = aturan.aturan_jam_masuk;
                        TimeSpan pulang = aturan.aturan_jam_pulang;

                        var khusus = dtKhusus.Where(x => x.hari_khusus_tanggal.Equals(tgl)).FirstOrDefault();
                        var libur = dtLibur.Where(x => x.libur_tanggal.Equals(tgl)).FirstOrDefault();
                        if (aturan.aturan_kegiatan == false)
                        {
                            absen_hari = "l";
                        }
                        else
                        {
                            if (libur != null)
                            {
                                absen_hari = "l";
                            }
                            else
                            {
                                if (khusus != null)
                                {
                                    absen_hari = "k";
                                    masuk = aturan.aturan_jam_masuk_khusus;
                                    pulang = aturan.aturan_jam_pulang_khusus;
                                }
                                else
                                {
                                    absen_hari = "b";
                                }
                            }
                        }
                        
                        DateTime absen_tanggal = tgl;
                        string absen_izin = izin.Where(x => x.izin_tanggal.Equals(tgl) && x.pegawai_id.Equals(pegawai_id)).Select(x => x.izin_jenis).SingleOrDefault();

                        TimeSpan absen_masuk = log.Where(x => x.pegawai_id.Equals(pegawai_id) && x.log_tanggal.Equals(tgl)).OrderBy(x => x.log_jam).Select(x => x.log_jam).FirstOrDefault();
                        TimeSpan absen_telat = TimeSpan.Parse("00:00:00");
                        if (absen_hari == "b")
                        {
                            if (absen_masuk > aturan.aturan_jam_masuk)
                                absen_telat = absen_masuk - aturan.aturan_jam_masuk;
                        }

                        TimeSpan absen_pulang = log.Where(x => x.pegawai_id.Equals(pegawai_id) && x.log_tanggal.Equals(tgl)).OrderByDescending(x => x.log_jam).Select(x => x.log_jam).FirstOrDefault();
                        
                        absen data = new absen()
                        {
                            pegawai_id = pegawai_id,
                            absen_tanggal = absen_tanggal,
                            absen_hari = absen_hari,
                            absen_izin = absen_izin,
                            absen_telat = (absen_izin != null || absen_hari == "l"? TimeSpan.Parse("00:00:00") : absen_telat),
                            absen_masuk = (absen_izin != null || absen_hari == "l" ? TimeSpan.Parse("00:00:00") : absen_masuk),
                            absen_pulang = (absen_izin != null || absen_hari == "l" ? TimeSpan.Parse("00:00:00") : absen_pulang),
                            absen_istirahat =  TimeSpan.Parse("00:00:00"),
                            absen_kembali = TimeSpan.Parse("00:00:00"),
                            absen_lembur = TimeSpan.Parse("00:00:00"),
                            absen_lembur_pulang = TimeSpan.Parse("00:00:00")
                        };
                        fp.absens.Add(data);
                        fp.SaveChanges();
                    }
                    var persentage = i * 100 / jml;
                    bwUpload.ReportProgress(persentage);
                    i += 1;
                }
                bwUpload.ReportProgress(100);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bwPosting_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                this.Close();
                return;
            }
            if (e.Cancelled)
            {
                MessageBox.Show("Proses download dibatalkan");
                this.Close();
                return;
            }
            if (MessageBox.Show(String.Format("Proses rekap data absensi selesai.\nApakah anda akan melanjutkan ke proses upload absensi ke web?"),
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                upload_download upload = new upload_download();
                upload.upload_download_keterangan = "Data " + tgl1.ToString("dd MMMM yyyy") + " s/d " + tgl2.ToString("dd MMMM yyyy");
                upload.upload_download_jenis = "Upload Absen";
                upload.upload_download_tanggal = DateTime.Now;
                fp.upload_download.Add(upload);
                fp.SaveChanges();

                FormProsesUploadAbsensiKeWeb proses = new FormProsesUploadAbsensiKeWeb();
                proses.tgl1 = tgl1;
                proses.tgl2 = tgl2;
                proses.StartPosition = FormStartPosition.CenterParent;
                proses.ShowDialog(this);
            }
            this.Close();
        }

        private void FormProses_Load(object sender, EventArgs e)
        {
        }

        private void bwPosting_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void FormProses_Shown(object sender, EventArgs e)
        {
            bwUpload.RunWorkerAsync();
        }

        private void FormProses_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(bwUpload.IsBusy)
                e.Cancel = true;
        }
    }
}
