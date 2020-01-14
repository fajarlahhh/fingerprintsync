using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormUploadAbsensiKeWeb : Form
    {
        readonly fingerprintEntities fp = new fingerprintEntities();
        public FormUploadAbsensiKeWeb(fingerprintEntities db)
        {
            InitializeComponent();
            dtTanggal1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTanggal2.Value = DateTime.Now;
        }
        private void LoadLog()
        {
        }


        private void FormAturan_Load(object sender, EventArgs e)
        {
            var log = fp.upload_download.Where(x => x.upload_download_jenis == "Upload Absen").OrderByDescending(x => x.upload_download_id).FirstOrDefault();
            lblLog.Text = "Posting Terakhir " + log.upload_download_tanggal.ToString("dd MMMM yyyy, hh:mm:ss") + "\n" + log.upload_download_keterangan;
        }

        private void FormSetKodeKantor_Shown(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                fingerprintEntities fp = new fingerprintEntities();
                upload_download upload = new upload_download();
                upload.upload_download_keterangan = "Data " + dtTanggal1.Value.ToString("dd MMMM yyyy") + " s/d " + dtTanggal2.Value.ToString("dd MMMM yyyy");
                upload.upload_download_jenis = "Upload Absen";
                upload.upload_download_tanggal = DateTime.Now;
                fp.upload_download.Add(upload);
                fp.SaveChanges();

                FormProsesUploadAbsensiKeWeb proses = new FormProsesUploadAbsensiKeWeb();
                proses.tgl1 = dtTanggal1.Value;
                proses.tgl2 = dtTanggal2.Value;
                proses.StartPosition = FormStartPosition.CenterParent;
                proses.ShowDialog(this);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
