using Fingerprint.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormPosting : Form
    {
        readonly fingerprintEntities fp = new fingerprintEntities();

        public FormPosting()
        {
            InitializeComponent();
            dtTanggal1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTanggal2.Value = DateTime.Now;
        }

        private void FormAturan_Load(object sender, EventArgs e)
        {
            var log = fp.upload_download.Where(x => x.upload_download_jenis == "Rekap Absen").OrderByDescending(x => x.upload_download_id).FirstOrDefault();
            if (log != null)
                lblLog.Text = "Rekap Terakhir " + log.upload_download_tanggal.ToString("dd MMMM yyyy, hh:mm:ss") + "\n" + log.upload_download_keterangan;
        }

        private void FormSetKodeKantor_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnPosting_Click(object sender, EventArgs e)
        {

            try
            {
                FormProsesPosting proses = new FormProsesPosting();
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
