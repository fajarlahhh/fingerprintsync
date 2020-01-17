using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using Fingerprint.Helper;
using System.Net.Http;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace Fingerprint
{
    public partial class FormProsesUploadPegawaiKeWeb : Form
    {
        string url = "";
        string kantor = "";
        fingerprintEntities fp = new fingerprintEntities();
        AppSetting setting = new AppSetting();

        public FormProsesUploadPegawaiKeWeb()
        {
            InitializeComponent();
            this.url = setting.GetConnectionString("api");
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("app.ini");

                this.kantor = data["Sekolah"]["IDSekolah"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        List<string> gagal = new List<string>();
        
        private async Task PostingPegawaiAsync()
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
                var pegawai = fp.pegawais.ToList();
                int jml = pegawai.Count();
                int i = 1;
                string hapus = "";
                lblProses.Invoke(new Action(() => lblProses.Text = "Menghapus data pegawai di web"));
                using (var client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.DeleteAsync(url + "hapuspegawai/" + kantor))
                    {
                        using (HttpContent content = response.Content)
                        {
                            hapus = await content.ReadAsStringAsync();
                        }
                    }
                }
                if(!hapus.Contains("berhasil"))
                {
                    MessageBox.Show("Terjadi kesalahan\n" + hapus);
                    Close();
                }
                //string result = "";
                int no = 0;
                int noGagal = 0;
                gagal.Clear();
                foreach (var row in pegawai)
                {
                    IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("pegawai_nip", row.pegawai_nip),
                        new KeyValuePair<string, string>("pegawai_nama", row.pegawai_nama),
                        new KeyValuePair<string, string>("pegawai_golongan", row.pegawai_golongan),
                        new KeyValuePair<string, string>("pegawai_jenis_kelamin", row.pegawai_jenis_kelamin),
                        new KeyValuePair<string, string>("kantor_id", kantor)
                    };
                    HttpContent qContent = new FormUrlEncodedContent(queries);
                    string upload = "";
                    using (var client = new HttpClient())
                    {
                        using (HttpResponseMessage response = await client.PostAsync(url + "tambahpegawai", qContent))
                        {
                            using (HttpContent content = response.Content)
                            {
                                upload = await content.ReadAsStringAsync();
                            }
                        }
                    }

                    string hasil = "berhasil";

                    if (!upload.Contains("berhasil"))
                    {
                        ++noGagal;
                        gagal.Add(row.pegawai_id);
                        hasil = "gagal";
                    }
                    lblProses.Invoke(new Action(() => lblProses.Text = ++no + ". Upload data pegawai " + row.pegawai_panggilan + " " + hasil));
                    int percentage = i * 100 / jml;
                    progressBar.Value = percentage;
                    i += 1;
                }
                if(gagal.Count() > 0)
                {
                    await UploadGagalAsync();
                    return;
                }
                else
                {
                    MessageBox.Show("Berhasil upload semua data pegawai", "Result");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task UploadGagalAsync()
        {
            var pegawai = fp.pegawais.Where(x => gagal.Contains(x.pegawai_id)).ToList();
            
            int jml = pegawai.Count();
            gagal.Clear();
            int no = 0;
            int i = 1;
            progressBar.Value = 0;
            foreach (var row in pegawai)
            {
                IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("pegawai_nip", row.pegawai_nip),
                        new KeyValuePair<string, string>("pegawai_nama", row.pegawai_nama),
                        new KeyValuePair<string, string>("pegawai_golongan", row.pegawai_golongan),
                        new KeyValuePair<string, string>("pegawai_jenis_kelamin", row.pegawai_jenis_kelamin),
                        new KeyValuePair<string, string>("kantor_id", kantor)
                    };
                HttpContent qContent = new FormUrlEncodedContent(queries);
                string upload = "";
                using (var client = new HttpClient())
                {
                    using (HttpResponseMessage response = await client.PostAsync(url + "tambahpegawai", qContent))
                    {
                        using (HttpContent content = response.Content)
                        {
                            upload = await content.ReadAsStringAsync();
                        }
                    }
                }

                string hasil = "berhasil";

                if (!upload.Contains("berhasil"))
                {
                    if (!upload.Contains("berhasil"))
                    {
                        gagal.Add(row.pegawai_id);
                    }
                    hasil = "gagal";
                }
                lblProses.Invoke(new Action(() => lblProses.Text = ++no + ". Upload data pegawai " + row.pegawai_panggilan + " " + hasil));
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
                MessageBox.Show("Berhasil upload semua data pegawai", "Result");
                Close();
            }
        }

        private void FormProses_Load(object sender, EventArgs e)
        {
            if (kantor.Trim() != "")
            {
                _ = PostingPegawaiAsync();
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
