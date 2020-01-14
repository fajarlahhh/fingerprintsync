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
using System.Data.Entity;
using Fingerprint.Class;

namespace Fingerprint.View
{
    public partial class UcRekapAbsensi : UserControl
    {
        readonly fingerprintEntities fp = new fingerprintEntities();
        DateTime now = DateTime.Now;

        public UcRekapAbsensi()
        {
            InitializeComponent();
            dtDari.Value = new DateTime(now.Year, now.Month, 1);
            dtSampai.Value = now;
            dgLog.AutoGenerateColumns = false;
        }

        private void UcPegawai_Load(object sender, EventArgs e)
        {
            GetPegawai();
        }

        private void GetPegawai()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var pegawai = fp.pegawais.Select(x => new
                {
                    id = x.pegawai_id,
                    nip = x.pegawai_nip,
                    nama = x.pegawai_nama
                }).ToList();

                cbPegawai.DataSource = pegawai.OrderBy(x => x.nama).ToList();
                cbPegawai.ValueMember = "id";
                cbPegawai.DisplayMember = "nama";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var log = fp.absens.Select(x => new RekapAbsen
                {
                    id = x.pegawai.pegawai_id,
                    tanggal = x.absen_tanggal,
                    izin = x.absen_izin,
                    hari = x.absen_hari == "b" ? "Hari Kerja" : (x.absen_hari == "k" ? "Hari Khusus" : "Hari Libur"),
                    telat = x.absen_telat,
                    masuk = x.absen_masuk,
                    pulang = x.absen_pulang,
                    istirahat = x.absen_istirahat,
                    kembali = x.absen_kembali,
                    lembur = x.absen_lembur,
                    lembur_pulang = x.absen_lembur_pulang
                }).ToList();
                dgLog.DataSource = log.Where(x => x.tanggal.Date >= dtDari.Value.Date && x.tanggal.Date <= dtSampai.Value.Date).Where(x => x.id.Equals(cbPegawai.SelectedValue.ToString())).ToList();
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

        private void cbPegawai_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Documents (.xlsx)|*.xlsx"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < 13; i++)
                    {
                        excel.Cells[1, i] = dgLog.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgLog.Rows.Count; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            excel.Cells[i + 2, j + 1] = dgLog.Rows[i].Cells[j].Value != null? dgLog.Rows[i].Cells[j].Value.ToString(): "";
                        }
                    }
                    excel.ActiveWorkbook.SaveCopyAs(sfd.FileName);
                    excel.ActiveWorkbook.Saved = true;
                    excel.Quit();
                    MessageBox.Show("Export Data Berhasil");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgLog.Rows)
            {
                switch (row.Cells["hari"].Value.ToString())
                {
                    case "Hari Khusus":
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkOrange;
                        break;
                    case "Hari Libur":
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            }
        }
    }
}
