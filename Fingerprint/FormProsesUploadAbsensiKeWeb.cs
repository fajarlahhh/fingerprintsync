using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using zkemkeeper;
using System.Collections.Generic;
using Fingerprint.Helper;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Http;
using MyTested.WebApi;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fingerprint
{
    public partial class FormProsesUploadAbsensiKeWeb : Form
    {
        string url = "";
        string kantor = "";
        fingerprintEntities fp = new fingerprintEntities();
        AppSetting setting = new AppSetting();
        public DateTime tgl1 { get; set; }
        public DateTime tgl2 { get; set; }

        public FormProsesUploadAbsensiKeWeb()
        {
            InitializeComponent();
            this.url = setting.GetConnectionString("api");
            this.kantor = Properties.Settings.Default.kantor_id;
        }

        List<string> gagal = new List<string>();

        private async Task PostingAbsenAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(kantor))
                {
                    FormSetKodeKantor setKantor = new FormSetKodeKantor();
                    setKantor.StartPosition = FormStartPosition.CenterParent;
                    setKantor.ShowDialog(this);
                    return;
                }
                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data pegawai"));
                var absen = fp.absens.Join(fp.pegawais, a => a.pegawai_id, b => b.pegawai_id, (a, b) => new { abs = a, peg = b }).Where(x => x.abs.absen_tanggal >= tgl1 && x.abs.absen_tanggal <= tgl2).ToList();
                int jml = absen.Count();

                int i = 1;
                if (jml == 0)
                {
                    MessageBox.Show("Tidak ada data absen");
                    Close();
                    return;
                }
                int no = 0;
                int noGagal = 0;
                foreach (var row in absen)
                {
                    string upload = "";

                    IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("pegawai_nip", row.peg.pegawai_nip),
                        new KeyValuePair<string, string>("absen_tanggal", row.abs.absen_tanggal.ToString("yyyy-MM-dd")),
                        new KeyValuePair<string, string>("absen_hari", row.abs.absen_hari),
                        new KeyValuePair<string, string>("absen_izin", row.abs.absen_izin),
                        new KeyValuePair<string, string>("absen_telat", row.abs.absen_telat.ToString()),
                        new KeyValuePair<string, string>("absen_masuk", row.abs.absen_masuk.ToString()),
                        new KeyValuePair<string, string>("absen_pulang", row.abs.absen_pulang.ToString()),
                        new KeyValuePair<string, string>("absen_istirahat", row.abs.absen_istirahat.ToString()),
                        new KeyValuePair<string, string>("absen_kembali", row.abs.absen_kembali.ToString()),
                        new KeyValuePair<string, string>("absen_lembur", row.abs.absen_lembur.ToString()),
                        new KeyValuePair<string, string>("absen_lembur_pulang", row.abs.absen_lembur_pulang.ToString()),
                        new KeyValuePair<string, string>("kantor_id", kantor)
                    };
                    HttpContent qContent = new FormUrlEncodedContent(queries);
                    using (var client = new HttpClient())
                    {
                        using (HttpResponseMessage response = await client.PostAsync(url + "tambahabsen", qContent))
                        {
                            using (HttpContent content = response.Content)
                            {
                                upload = await content.ReadAsStringAsync();
                            }
                        }
                    }

                    string hasil = "BERHASIL";

                    if (!upload.Contains("berhasil"))
                    {
                        ++noGagal;
                        gagal.Add(row.peg.pegawai_id);
                        hasil = "GAGAL";
                    }
                    lblProses.Invoke(new Action(() => lblProses.Text = ++no + ". Upload data absensi " + row.peg.pegawai_panggilan + " " + row.abs.absen_tanggal.ToString("dd MMMM yyyy") + " " + hasil));
                    int percentage = i * 100 / jml;
                    progressBar.Value = percentage;
                    i += 1;
                }
                if (gagal.Count() > 0)
                {
                    await UploadGagalAsync();
                    return;
                }
                else
                {
                    MessageBox.Show("Berhasil upload semua data absensi", "Result");
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task UploadGagalAsync()
        {
            var absen = fp.absens.Join(fp.pegawais, a => a.pegawai_id, b => b.pegawai_id, (a, b) => new { abs = a, peg = b }).Where(x => gagal.Contains(x.peg.pegawai_id) && x.abs.absen_tanggal >= tgl1 && x.abs.absen_tanggal <= tgl2).ToList();
            int jml = absen.Count();
            gagal.Clear();
            int no = 0;
            int noGagal = 0;
            int i = 1;
            progressBar.Value = 0;
            foreach (var row in absen)
            {
                string upload = "";
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("pegawai_nip", row.peg.pegawai_nip),
                        new KeyValuePair<string, string>("absen_tanggal", row.abs.absen_tanggal.ToString("yyyy-MM-dd")),
                        new KeyValuePair<string, string>("absen_hari", row.abs.absen_hari),
                        new KeyValuePair<string, string>("absen_izin", row.abs.absen_izin),
                        new KeyValuePair<string, string>("absen_telat", row.abs.absen_telat.ToString()),
                        new KeyValuePair<string, string>("absen_masuk", row.abs.absen_masuk.ToString()),
                        new KeyValuePair<string, string>("absen_pulang", row.abs.absen_pulang.ToString()),
                        new KeyValuePair<string, string>("absen_istirahat", row.abs.absen_istirahat.ToString()),
                        new KeyValuePair<string, string>("absen_kembali", row.abs.absen_kembali.ToString()),
                        new KeyValuePair<string, string>("absen_lembur", row.abs.absen_lembur.ToString()),
                        new KeyValuePair<string, string>("absen_lembur_pulang", row.abs.absen_lembur_pulang.ToString()),
                        new KeyValuePair<string, string>("kantor_id", kantor)
                    };
                HttpContent qContent = new FormUrlEncodedContent(queries);
                using (var client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(url + "tambahabsen", qContent))
                    {
                        using (HttpContent content = response.Content)
                        {
                            upload = await content.ReadAsStringAsync();
                        }
                    }
                }
                string hasil = "BERHASIL";

                if (!upload.Contains("berhasil"))
                {
                    ++noGagal;
                    gagal.Add(row.peg.pegawai_id);
                    hasil = "GAGAL";
                }
                lblProses.Invoke(new Action(() => lblProses.Text = ++no + ". Upload data absensi " + row.peg.pegawai_panggilan + " " + row.abs.absen_tanggal.ToString("yyyy-MM-dd") + " " + hasil));
                int percentage = i * 100 / jml;
                progressBar.Value = percentage;
                i += 1;
            }

            if (gagal.Count() > 0)
            {
                await UploadGagalAsync();
            }
            else
            {
                MessageBox.Show("Berhasil upload semua data pegawai 2", "Result");
                Close();
            }
        }

        private void FormProses_Load(object sender, EventArgs e)
        {
            if (kantor.Trim() != "")
            {
                _ = PostingAbsenAsync();
            }
            else
            {
                MessageBox.Show("Kode Sekolah/KCD/Kantor belum diatur");
                this.Close();
            }
        }

        private void FormProses_Shown(object sender, EventArgs e)
        {
        }

        private void FormProses_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
