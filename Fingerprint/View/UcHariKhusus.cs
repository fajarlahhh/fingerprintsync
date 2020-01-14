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
    public partial class UcHariKhusus : UserControl
    {
        fingerprintEntities fp = new fingerprintEntities();
        private DateTime hari_khusus_id;
        private int rowIndex;
        private string aksi;

        public UcHariKhusus()
        {
            InitializeComponent();
            dtTahun.Value = DateTime.Now;
            dtTanggal1.Value = DateTime.Now;
            dtTanggal2.Value = DateTime.Now;
        }

        private void UcPegawai_Load(object sender, EventArgs e)
        {
            GetData();
        }

        List<DataHariKhusus> hari_khusus;

        private void GetData()
        {
            try
            {
                string cari = txtCari.Text;
                hari_khusus = (from p in fp.hari_khusus
                                   where p.hari_khusus_tanggal.Year.Equals(dtTahun.Value.Year)
                                   select new DataHariKhusus
                                   {
                                       tanggal = p.hari_khusus_tanggal,
                                       keterangan = p.hari_khusus_keterangan
                                   }).ToList();
                dgHariKhusus.DataSource = hari_khusus;
                this.Enabled = true;
                if (hari_khusus.Count() > 0)
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
            dgHariKhusus.Enabled = aktif;

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
                        if (fp.hari_khusus.Where(x => x.hari_khusus_tanggal.Equals(inputDate.Date)).Count() == 0)
                        {
                            hari_khusus data = new hari_khusus();
                            data.hari_khusus_tanggal = inputDate.Date;
                            data.hari_khusus_keterangan = txtKeterangan.Text;
                            fp.hari_khusus.Add(data);
                            fp.SaveChanges();
                        }
                    }
                    GetData();
                }
                else
                {
                    var hari_khusus = fp.hari_khusus.Where(x => x.hari_khusus_tanggal.Equals(hari_khusus_id)).FirstOrDefault();

                    hari_khusus.hari_khusus_keterangan = txtKeterangan.Text;
                    fp.SaveChanges();

                    DataGridViewRow dataRow = dgHariKhusus.Rows[rowIndex];
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
                var hari_khusus = fp.hari_khusus.Where(x => x.hari_khusus_tanggal.Equals(hari_khusus_id)).FirstOrDefault();
                if (hari_khusus != null)
                {
                    if (MessageBox.Show(String.Format("Anda akan menghapus data hari_khusus\n\"{0} {1}\"", dtTanggal1.Value.ToString("dd MMMM yyyy"), txtKeterangan.Text),
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        fp.hari_khusus.Remove(hari_khusus);
                        fp.SaveChanges();
                        GetData(); GetSelectedRow();
                    }
                }
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
                foreach (DataGridViewRow row in dgHariKhusus.SelectedRows)
                {
                    rowIndex = row.Index;
                    hari_khusus_id = Convert.ToDateTime(row.Cells[0].Value.ToString());
                    dtTanggal1.Value = Convert.ToDateTime(row.Cells[0].Value);
                    dtTanggal2.Value = Convert.ToDateTime(row.Cells[0].Value);
                    txtKeterangan.Text = row.Cells[1].Value.ToString();
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
                List<DataHariKhusus> filterKhusus = hari_khusus.Where(x => x.keterangan.ToLower().Contains(cari.ToLower())).ToList();
                dgHariKhusus.DataSource = filterKhusus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
