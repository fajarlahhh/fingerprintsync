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

namespace Fingerprint.View
{
    public partial class UcHariLibur : UserControl
    {
        readonly fingerprintEntities fp = new fingerprintEntities();
        private DateTime libur_id;
        private int rowIndex;
        private string aksi;

        public UcHariLibur()
        {
            InitializeComponent();
            dtTahun.Value = DateTime.Now;
        }

        private void UcPegawai_Load(object sender, EventArgs e)
        {
            GetData();
        }

        List<DataLibur> libur;

        private void GetData()
        {
            try
            {
                string cari = txtCari.Text;
                libur = (from p in fp.liburs
                                   where p.libur_keterangan.Contains(cari) && p.libur_tanggal.Year.Equals(dtTahun.Value.Year)
                                   select new DataLibur
                                   {
                                       tanggal = p.libur_tanggal,
                                       keterangan = p.libur_keterangan
                                   }).ToList();
                dgHariLibur.DataSource = libur;
                this.Enabled = true;
                if (libur.Count() > 0)
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
            dgHariLibur.Enabled = aktif;

            if (text != null)
            {
                txtKeterangan.ResetText();
                dtTahun.Value = DateTime.Now;
            }

            grForm.Enabled = !aktif;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            GroupAksi(false, "");
            dtTahun.Focus();
            aksi = "Tambah";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GroupAksi(false);
            dtTahun.Focus();
            aksi = "Edit";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (aksi == "Tambah")
                {
                    var diff = (dtTanggal2.Value.Date - dtTanggal1.Value.Date).TotalDays;
                    DateTime tanggal = dtTanggal1.Value;
                    for (int i = 0; i <= diff; i++)
                    {
                        DateTime inputDate = tanggal.AddDays(i);
                        if (fp.liburs.Where(x => x.libur_tanggal.Equals(dtTanggal1.Value)).Count() == 0)
                        {
                            libur data = new libur();
                            data.libur_tanggal = inputDate.Date;
                            data.libur_keterangan = txtKeterangan.Text;
                            fp.liburs.Add(data);
                            fp.SaveChanges();
                        }
                    }
                    GetData();
                    GetData();
                }
                else
                {
                    var libur = fp.liburs.Where(x => x.libur_tanggal.Equals(libur_id)).FirstOrDefault();

                    libur.libur_keterangan = txtKeterangan.Text;
                    fp.SaveChanges();

                    DataGridViewRow dataRow = dgHariLibur.Rows[rowIndex];
                    dataRow.Cells[0].Value = dtTanggal1.Value;
                    dataRow.Cells[1].Value = txtKeterangan.Text;
                }
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
                var libur = fp.liburs.Where(x => x.libur_tanggal.Equals(libur_id)).FirstOrDefault();
                if (libur != null)
                {
                    if (MessageBox.Show(String.Format("Anda akan menghapus data libur\n\"{0} {1}\"", dtTanggal1.Value.ToString("dd MMMM yyyy"), txtKeterangan.Text),
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fp.liburs.Remove(libur);
                        fp.SaveChanges();
                        GetData();
                    }
                }
                GetSelectedRow();
            }
            catch(Exception ex)
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
                dtTanggal1.Value = DateTime.Now;
                txtKeterangan.ResetText();
                foreach (DataGridViewRow row in dgHariLibur.SelectedRows)
                {
                    rowIndex = row.Index;
                    libur_id = Convert.ToDateTime(row.Cells[0].Value.ToString());
                    dtTanggal1.Value = Convert.ToDateTime(row.Cells[0].Value);
                    txtKeterangan.Text = row.Cells[1].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                dtTanggal1.Value = DateTime.Now;
                txtKeterangan.ResetText();
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
                List<DataLibur> filter = libur.Where(x => x.keterangan.ToLower().Contains(cari.ToLower())).ToList();
                dgHariLibur.DataSource = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
