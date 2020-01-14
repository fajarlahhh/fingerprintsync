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
using System.Diagnostics;
using zkemkeeper;
using Fingerprint.Class;

namespace Fingerprint.View
{
    public partial class UcPegawai : UserControl
    {
        private string pegawai_id, pegawai_nip;
        private int rowIndex;
        private string aksi;
        readonly fingerprintEntities fp = new fingerprintEntities();
        CZKEMClass axCZKEM1 = new CZKEMClass();

        public UcPegawai()
        {
            InitializeComponent();
            cbJenisKelamin.SelectedIndex = 0;
            cbHakAkses.SelectedIndex = 1;
        }

        private void UcPegawai_Load(object sender, EventArgs e)
        {
            GetData();
        }

        List<DataPegawai> pegawai = new List<DataPegawai>();

        private void GetData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                pegawai = (from p in fp.pegawais
                               select new DataPegawai
                               {
                                   id = p.pegawai_id,
                                   nip = p.pegawai_nip,
                                   nama = p.pegawai_nama,
                                   panggilan = p.pegawai_panggilan,
                                   golongan = p.pegawai_golongan,
                                   kelamin = p.pegawai_jenis_kelamin,
                                   izin = (p.pegawai_izin == "0"? "Administrator": "User"),
                                   sandi = p.pegawai_sandi,
                                   upload = p.upload
                               }).ToList();
                dgPegawai.DataSource = pegawai.OrderBy(x => x.nama).ToList();
                lblJumlah.Text = "Jumlah Pegawai : " + pegawai.Count;
                Enabled = true;
                if (pegawai.Count() > 0)
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
            catch(Exception ex)
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
            dgPegawai.Enabled = aktif;
            btnCetak.Enabled = aktif;
            btnUploadKeMesin.Enabled = aktif;

            if (text != null)
            {
                txtID.ResetText();
                txtNIP.ResetText();
                txtNama.ResetText();
                txtPanggilan.ResetText();
                txtGolongan.ResetText();
                cbJenisKelamin.SelectedIndex = 0;
                cbHakAkses.SelectedIndex = 1;
                txtSandi.ResetText();
            }

            grForm.Enabled = !aktif;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            GroupAksi(false, "");
            txtID.Enabled = true;
            txtID.Focus();
            aksi = "Tambah";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GroupAksi(false);
            txtID.Enabled = false;
            txtNIP.Focus();
            aksi = "Edit";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (fp.pegawais.Where(x => x.pegawai_nip.Equals(txtNIP.Text)).Count() > 0 && txtNIP.Text != pegawai_nip)
                {
                    MessageBox.Show("NIP sudah ada");
                    txtNIP.Focus();
                    return;
                }
                if (aksi == "Tambah")
                {
                    if (fp.pegawais.Where(x => x.pegawai_id.Equals(txtID.Text)).Count() > 0)
                    {
                        MessageBox.Show("ID sudah ada");
                        txtNIP.Focus();
                        return;
                    }
                    pegawai data = new pegawai();
                    data.pegawai_id = txtID.Text;
                    data.pegawai_nip = txtNIP.Text;
                    data.pegawai_nama = txtNama.Text;
                    data.pegawai_panggilan = txtPanggilan.Text;
                    data.pegawai_golongan = txtGolongan.Text;
                    data.pegawai_jenis_kelamin = cbJenisKelamin.Text;
                    data.pegawai_izin = cbHakAkses.SelectedIndex.ToString();
                    data.upload = false;
                    if (cbHakAkses.SelectedIndex == 1)
                        data.pegawai_sandi = "";
                    else
                        data.pegawai_sandi = txtSandi.Text;
                    fp.pegawais.Add(data);
                    fp.SaveChanges();

                    if (chkSync.Checked)
                        UploadKeMesin(txtID.Text);
                    GetData();
                }
                else
                {
                    var pegawai = fp.pegawais.Where(x => x.pegawai_id.Equals(pegawai_id)).FirstOrDefault();
                    pegawai.pegawai_nip = txtNIP.Text;
                    pegawai.pegawai_nama = txtNama.Text;
                    pegawai.pegawai_panggilan = txtPanggilan.Text;
                    pegawai.pegawai_golongan = txtGolongan.Text;
                    pegawai.pegawai_jenis_kelamin = cbJenisKelamin.Text;
                    pegawai.pegawai_izin = cbHakAkses.SelectedIndex.ToString();
                    pegawai.upload = false;
                    if (cbHakAkses.SelectedIndex == 1)
                    {
                        pegawai.pegawai_sandi = "";
                    }
                    else
                    {
                        if (txtSandi.Text != "")
                            pegawai.pegawai_sandi = txtSandi.Text;
                    }
                    fp.SaveChanges();

                    if(chkSync.Checked)
                        UploadKeMesin(txtID.Text);

                    DataGridViewRow dataRow = dgPegawai.Rows[rowIndex];
                    dataRow.Cells[1].Value = txtNIP.Text;
                    dataRow.Cells[2].Value = txtNama.Text;
                    dataRow.Cells[3].Value = txtPanggilan.Text;
                    dataRow.Cells[4].Value = txtGolongan.Text;
                    dataRow.Cells[5].Value = cbJenisKelamin.Text;
                    dataRow.Cells[6].Value = cbHakAkses.Text;
                    dataRow.Cells[7].Value = txtSandi.Text;
                }
                txtSandi.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            GroupAksi(true);
            GetSelectedRow();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            GroupAksi(true, "");
            GetSelectedRow();
            txtSandi.Text = "";
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var pegawai = fp.pegawais.Where(x => x.pegawai_id == pegawai_id).FirstOrDefault();
                if (pegawai != null)
                {
                    if (MessageBox.Show(String.Format("Anda akan menghapus data pegawai\n\"{0} {1}\"", txtNIP.Text, txtNama.Text),
                        "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgPegawai.SelectedRows)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            if(sincron == true)
                            {
                                bool bIsConnected = false;
                                int iMachineNumber = 1;
                                int idwErrorCode = 0;

                                var mesin = fp.mesins.ToList();
                                foreach (var msn in mesin)
                                {
                                    bIsConnected = axCZKEM1.Connect_Net(msn.mesin_ip.Trim(), Convert.ToInt32(msn.mesin_key.Trim()));
                                    if (bIsConnected == true)
                                    {
                                        if (axCZKEM1.SSR_DeleteEnrollData(iMachineNumber, pegawai_id, 12))
                                        {
                                            axCZKEM1.RefreshData(iMachineNumber);
                                            fp.pegawais.Remove(pegawai);
                                            fp.SaveChanges();
                                            GetData();
                                        }
                                        else
                                        {
                                            axCZKEM1.GetLastError(ref idwErrorCode);
                                            MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        axCZKEM1.GetLastError(ref idwErrorCode);
                                        MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                                        return;
                                    }
                                    iMachineNumber += 1;
                                }
                            }
                            else
                            {
                                fp.pegawais.Remove(pegawai);
                                fp.SaveChanges();
                                GetData();
                            }
                        }
                    }
                }
                GroupAksi(true, "");
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
        bool sincron = false;
        private void GetSelectedRow()
        {
            try
            {
                foreach (DataGridViewRow row in dgPegawai.SelectedRows)
                {
                    rowIndex = row.Index;
                    pegawai_id = row.Cells[0].Value.ToString();
                    pegawai_nip = row.Cells[1].Value.ToString();
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtNIP.Text = row.Cells[1].Value.ToString();
                    txtNama.Text = row.Cells[2].Value.ToString();
                    txtPanggilan.Text = row.Cells[3].Value.ToString();
                    txtGolongan.Text = row.Cells[4].Value.ToString();
                    cbJenisKelamin.Text = row.Cells[5].Value.ToString();
                    cbHakAkses.Text = row.Cells[6].Value.ToString();
                    txtSandi.Text = row.Cells[7].Value.ToString();
                    sincron = Convert.ToBoolean(row.Cells[8].Value);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    for (int i = 1; i < 9; i++)
                    {
                        excel.Cells[1, i] = dgPegawai.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dgPegawai.Rows.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            excel.Cells[i + 2, j + 1] = dgPegawai.Rows[i].Cells[j].Value.ToString();
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

        private void UploadKeMesin(string id = null)
        {
            bool bIsConnected = false;
            int iMachineNumber = 1;
            int idwErrorCode = 0;

            var mesin = fp.mesins.ToList();

            foreach (var msn in mesin)
            {
                bIsConnected = axCZKEM1.Connect_Net(msn.mesin_ip.Trim(), Convert.ToInt32(msn.mesin_key.Trim()));
                if (bIsConnected == true)
                {
                    int iUpdateFlag = 1;
                    axCZKEM1.EnableDevice(iMachineNumber, false);
                    if (axCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag))
                    {
                        if (!axCZKEM1.SSR_SetUserInfo(iMachineNumber, txtID.Text, txtPanggilan.Text, txtSandi.Text, (cbHakAkses.SelectedIndex == 0 ? 3 : 0), true))
                        {
                            axCZKEM1.GetLastError(ref idwErrorCode);
                            MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                            axCZKEM1.EnableDevice(iMachineNumber, true);
                        }
                        else
                        {

                            var pegawai = fp.pegawais.Where(x => x.pegawai_id.Equals(id == null? pegawai_id: id)).FirstOrDefault();
                            pegawai.upload = true;
                            fp.SaveChanges();
                        }
                    }
                    axCZKEM1.BatchUpdate(iMachineNumber);
                    axCZKEM1.RefreshData(iMachineNumber);
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                }
                iMachineNumber += 1;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgPegawai_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgPegawai.Rows)
            {
                if ((bool)row.Cells["upload"].Value == false)
                {
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                }
            }
        }

        private void btnUploadKeMesin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UploadKeMesin();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cari = txtCari.Text;
                List<DataPegawai> filterPegawai = pegawai.Where(x => x.nip.ToLower().Contains(cari.ToLower()) || x.nama.ToLower().Contains(cari.ToLower()) || x.panggilan.ToLower().Contains(cari.ToLower())).ToList();
                dgPegawai.DataSource = filterPegawai;

                lblJumlah.Text = "Jumlah Pegawai : " + filterPegawai.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
