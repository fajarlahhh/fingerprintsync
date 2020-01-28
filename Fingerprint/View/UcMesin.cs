using Fingerprint.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using zkemkeeper;

namespace Fingerprint.View
{
    public partial class UcMesin : UserControl
    {
        CZKEMClass axCZKEM1 = new CZKEMClass();
        readonly fingerprintEntities fp = new fingerprintEntities();
        private int mesin_id, rowIndex;
        private string aksi;

        public UcMesin()
        {
            InitializeComponent();
        }

        private void UcMesin_Load(object sender, EventArgs e)
        {
            GetData();
        }

        List<DataMesin> mesin;
        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string cari = txtCari.Text;
                mesin = (from p in fp.mesins 
                             select new DataMesin
                               {
                                   id = p.mesin_id,
                                   nama = p.mesin_nama,
                                   ip = p.mesin_ip,
                                   key = p.mesin_key,
                                   sn = p.mesin_sn
                               }).ToList();
                dgMesin.DataSource = mesin;
                this.Enabled = true;
                if (mesin.Count() > 0)
                {
                    btnEdit.Enabled = true;
                    btnHapus.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnHapus.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupAksi(bool aktif, string text = null)
        {
            btnTambah.Enabled = aktif;
            btnEdit.Enabled = aktif;
            btnHapus.Enabled = aktif;
            btnRefresh.Enabled = aktif;
            txtCari.Enabled = aktif;
            dgMesin.Enabled = aktif;
            btnKoneksi.Enabled = aktif;
            if (text != null)
            {
                txtNama.ResetText();
                txtIP.ResetText();
            }

            grForm.Enabled = !aktif;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            GroupAksi(false, "");
            txtNama.Focus();
            txtKey.Text = "4370";
            aksi = "Tambah";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GroupAksi(false);
            txtNama.Focus();
            aksi = "Edit";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (aksi == "Tambah")
                {
                    mesin data = new mesin();
                    data.mesin_nama = txtNama.Text;
                    data.mesin_ip = txtIP.Text;
                    data.mesin_key = txtKey.Text;
                    data.mesin_sn = "123";
                    fp.mesins.Add(data);
                    fp.SaveChanges();
                    GetData();
                }
                else
                {
                    var mesin = fp.mesins.Where(x => x.mesin_id.Equals(mesin_id)).FirstOrDefault();
                    mesin.mesin_nama = txtNama.Text;
                    mesin.mesin_ip = txtIP.Text;
                    mesin.mesin_key = txtKey.Text;
                    mesin.mesin_sn = "123";
                    fp.SaveChanges();

                    DataGridViewRow dataRow = dgMesin.Rows[rowIndex];
                    dataRow.Cells[1].Value = txtNama.Text;
                    dataRow.Cells[2].Value = txtIP.Text;
                    dataRow.Cells[3].Value = txtKey.Text;
                    dataRow.Cells[4].Value = "123";
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
                var mesin = fp.mesins.Where(x => x.mesin_id.Equals(mesin_id)).FirstOrDefault();
                if (mesin != null)
                {
                    if (MessageBox.Show(String.Format("Anda akan menghapus data mesin\n\"{0}\"", txtNama.Text),
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        fp.mesins.Remove(mesin);
                        fp.SaveChanges();
                        GetData();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgMesin_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedRow();
        }

        private void GetSelectedRow()
        {
            try 
            { 
                foreach (DataGridViewRow row in dgMesin.SelectedRows)
                {
                    rowIndex = row.Index;
                    mesin_id = Convert.ToInt32(row.Cells[0].Value.ToString());
                    txtNama.Text = row.Cells[1].Value.ToString();
                    txtIP.Text = row.Cells[2].Value.ToString();
                    txtKey.Text = row.Cells[3].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKoneksi_Click(object sender, EventArgs e)
        {
            bool bIsConnected = false;
            int idwErrorCode = 0;
            foreach (DataGridViewRow row in dgMesin.SelectedRows)
            {
                Cursor.Current = Cursors.WaitCursor;
                bIsConnected = axCZKEM1.Connect_Net(row.Cells[2].Value.ToString(), Convert.ToInt32(row.Cells[3].Value.ToString()));
                if (bIsConnected == true)
                {
                    MessageBox.Show("Koneksi ke mesin absensi berhasil");
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                }
                axCZKEM1.Disconnect();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cari = txtCari.Text;
                List<DataMesin> filterMesin = mesin.Where(x => x.nama.ToLower().Contains(cari.ToLower()) || x.ip.ToLower().Contains(cari.ToLower())).ToList();
                dgMesin.DataSource = filterMesin;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
