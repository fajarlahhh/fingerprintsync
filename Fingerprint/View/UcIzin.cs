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

namespace Fingerprint.View
{
    public partial class UcIzin : UserControl
    {
        fingerprintEntities fp = new fingerprintEntities();
        private DateTime izin_tgl;
        private string ID;
        private string pegawai_nip;

        public UcIzin()
        {
            InitializeComponent();
            cbJenis.SelectedIndex = 0;
            dtTahun.Value = DateTime.Now;
            dtTanggal1.Value = DateTime.Now;
            dtTanggal2.Value = DateTime.Now;
        }

        private void UcPegawai_Load(object sender, EventArgs e)
        {
            GetPegawai();
            GetData();
        }

        private void GetPegawai()
        {
            try
            {
                fingerprintEntities fp2 = new fingerprintEntities();
                var pegawai = fp2.pegawais.Select(x => new
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

        List<DataIzin> izin;

        private void GetData()
        {
            try
            {
                string cari = txtCari.Text;
                izin = fp.izins.Join(
                    fp.pegawais,
                    a => a.pegawai_id,
                    b => b.pegawai_id,
                    (a,b) => new { iz = a, pegawai = b }
                    ).Where(x => x.iz.izin_tanggal.Year == dtTahun.Value.Year).Select(x => new DataIzin
                    {
                        pegawai = x.iz.pegawai_id,
                        nip = x.pegawai.pegawai_nip,
                        nama = x.pegawai.pegawai_nama,
                        tanggal = x.iz.izin_tanggal,
                        jenis = x.iz.izin_jenis,
                        keterangan = x.iz.izin_keterangan
                    }).ToList();
                dgIzin.DataSource = izin;
                this.Enabled = true;
                if (izin.Count() > 0)
                {
                    btnHapus.Enabled = true;
                }
                else
                {
                    btnHapus.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupAksi(bool aktif, string text = null)
        {
            btnTambah.Enabled = aktif;
            btnHapus.Enabled = aktif;
            btnRefresh.Enabled = aktif;
            txtCari.Enabled = aktif;
            dgIzin.Enabled = aktif;

            if (text != null)
            {
                txtKeterangan.ResetText();
                dtTahun.Value = DateTime.Now;
            }

            grForm.Enabled = !aktif;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            GetPegawai();
            GroupAksi(false, "");
            dtTahun.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                var diff = (dtTanggal2.Value.Date - dtTanggal1.Value.Date).TotalDays;
                DateTime tanggal = dtTanggal1.Value;
                for (int i = 0; i <= diff; i++)
                {
                    DateTime inputDate = tanggal.AddDays(i);
                    if (fp.izins.Where(x => x.izin_tanggal.Equals(inputDate.Date) && x.pegawai_id.Equals(cbPegawai.SelectedValue.ToString())).Count() == 0)
                    {
                        izin data = new izin();
                        data.pegawai_id = cbPegawai.SelectedValue.ToString();
                        data.izin_tanggal = inputDate.Date;
                        data.izin_jenis = cbJenis.Text;
                        data.izin_keterangan = txtKeterangan.Text;
                        fp.izins.Add(data);
                        fp.SaveChanges();
                    }
                }
                GetData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            GroupAksi(true);
            GetSelectedRow();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            GroupAksi(true);
            GetSelectedRow();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(String.Format("Anda akan menghapus data izin\nPegawai NIP {1} tgl. {0}", izin_tgl.Date.ToString("dd MMMM YYYY"), pegawai_nip),
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var dt = fp.izins.Where(x => x.izin_tanggal.Year == izin_tgl.Year && x.izin_tanggal.Month == izin_tgl.Month && x.izin_tanggal.Day == izin_tgl.Day && x.pegawai_id == ID).FirstOrDefault();
                    fp.izins.Remove(dt);
                    fp.SaveChanges();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgPegawai_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedRow();
        }

        private void GetSelectedRow()
        {
            try
            {
                foreach (DataGridViewRow row in dgIzin.SelectedRows)
                {
                    ID = row.Cells["pegawai"].Value.ToString();
                    cbPegawai.Text = row.Cells[1].Value.ToString();
                    pegawai_nip = row.Cells[1].Value.ToString();
                    izin_tgl = Convert.ToDateTime(row.Cells["tanggal"].Value.ToString());
                    dtTanggal1.Value = Convert.ToDateTime(row.Cells[3].Value);
                    cbJenis.Text = row.Cells[4].Value.ToString();
                    txtKeterangan.Text = row.Cells[5].Value.ToString();
                }
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

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cari = txtCari.Text;
                List<DataIzin> filter = izin.Where(x => x.keterangan.ToLower().Contains(cari.ToLower()) || x.jenis.ToLower().Contains(cari.ToLower()) || x.nip.ToLower().Contains(cari.ToLower()) || x.nama.ToLower().Contains(cari.ToLower())).ToList();
                dgIzin.DataSource = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
