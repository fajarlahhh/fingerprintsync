using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Fingerprint.Class;
using IniParser.Model;
using IniParser;

namespace Fingerprint.View
{
    public partial class UcLog : UserControl
    {
        readonly fingerprintEntities fp = new fingerprintEntities();
        public UcLog()
        {
            InitializeComponent();
            dtTahun.Value = DateTime.Now;
        }

        private void UcPegawai_Load(object sender, EventArgs e)
        {
            GetData();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("app.ini");

            if (data["Sekolah"]["SupportMesin"] == "T")
            {
                btnImport.Enabled = true;
            }
        }

        List<DataLog> log;

        private void GetData()
        {
            try
            {
                string cari = txtCari.Text;
                log = fp.logs.Join(
                    fp.pegawais,
                    a => a.pegawai_id,
                    b => b.pegawai_id,
                    (a, b) => new { log = a, pegawai = b }
                    ).Where(x => x.log.log_tanggal.Year == dtTahun.Value.Year).Select(x => new DataLog
                    {
                        id = x.log.pegawai_id,
                        nip = x.pegawai.pegawai_nip,
                        nama = x.pegawai.pegawai_nama,
                        tanggal = x.log.log_tanggal,
                        waktu = x.log.log_jam,
                        jenis = x.log.log_status
                    }).ToList();
                dgLog.DataSource = log;
               this.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format("Anda akan menghapus data log tahun\n\"{0}\"", dtTahun.Value.Year),
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var log = fp.logs.Where(x => x.log_tanggal.Year.Equals(dtTahun.Value.Year)).ToList();
                fp.logs.RemoveRange(log);
                fp.SaveChanges();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cari = txtCari.Text;
                List<DataLog> filterLog = log.Where(x => x.nama.ToLower().Contains(cari.ToLower()) || x.nip.ToLower().Contains(cari.ToLower())).ToList();
                dgLog.DataSource = filterLog;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FormImportLog import = new FormImportLog();
            import.ShowDialog();
        }
    }
}
