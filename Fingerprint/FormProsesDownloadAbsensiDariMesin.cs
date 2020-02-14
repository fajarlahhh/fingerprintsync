using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using zkemkeeper;
using System.Collections.Generic;

namespace Fingerprint
{
    public partial class FormProsesDownloadAbsensiDariMesin : Form
    {
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        readonly fingerprintEntities fp = new fingerprintEntities();

        public FormProsesDownloadAbsensiDariMesin()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bwDownload.CancelAsync();
        }

        List<mesin> mesin = new List<mesin>();
        List<string> gagal = new List<string>();
        int iMachineNumber = 1;

        private void bwPosting_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool bIsConnected = false;
            int idwErrorCode = 0;

            lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data mesin"));
            var mesin = fp.mesins.ToList();
            int no = 1;
            int jumlah = 0;
            foreach (var msn in mesin)
            {
                progressBar.Value = 0;
                bwDownload.ReportProgress(0);
                lblProses.Invoke(new Action(() => lblProses.Text = "Melakukan koneksi ke mesin " + msn.mesin_nama + ", IP " + msn.mesin_ip + ", port " + msn.mesin_key));
                bIsConnected = axCZKEM1.Connect_Net(msn.mesin_ip.Trim(), Convert.ToInt32(msn.mesin_key.Trim()));

                if (bIsConnected == false)
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    lblProses.Invoke(new Action(() => lblProses.Text = "Koneksi ke mesin " + msn.mesin_nama + ", IP " + msn.mesin_ip + ", port " + msn.mesin_key + " GAGAL " + idwErrorCode.ToString()));
                    gagal.Add("gagal");
                }
                else
                {
                    iMachineNumber = no;
                    axCZKEM1.RegEvent(iMachineNumber, 65535);

                    string sdwEnrollNumber = "";
                    int idwVerifyMode = 0;
                    int idwInOutMode = 0;
                    int idwYear = 0;
                    int idwMonth = 0;
                    int idwDay = 0;
                    int idwHour = 0;
                    int idwMinute = 0;
                    int idwSecond = 0;
                    int idwWorkcode = 0;

                    int iValue = 400;

                    axCZKEM1.EnableDevice(iMachineNumber, false);
                    lblProses.Invoke(new Action(() => lblProses.Text = "Menghitung jumlah data absensi"));
                    if (!axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref iValue))
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        lblProses.Invoke(new Action(() => lblProses.Text = "Operation failed,ErrorCode=" + idwErrorCode.ToString()));
                        e.Cancel = true;
                        return;
                    }
                    lblProses.Invoke(new Action(() => lblProses.Text = "Mendownload " + iValue.ToString() + " data absensi"));
                    if (axCZKEM1.ReadAllGLogData(iMachineNumber))
                    {
                        var pegawai = fp.pegawais.ToList();
                        int nomor = 1;
                        while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                                    out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))
                        {
                            try
                            {
                                if (pegawai.Where(s => s.pegawai_id.Equals(sdwEnrollNumber)).Count() > 0)
                                {
                                    log data = new log();
                                    data.pegawai_id = sdwEnrollNumber;
                                    data.log_tanggal = DateTime.Parse(idwYear + "-" + idwMonth + "-" + idwDay);
                                    data.log_jam = TimeSpan.Parse(idwHour + ":" + idwMinute + ":" + idwSecond);
                                    data.log_kode = idwVerifyMode.ToString();
                                    data.log_status = idwInOutMode.ToString();
                                    fp.logs.Add(data);
                                    lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data ke " + nomor + "/" + iValue + " ID " + sdwEnrollNumber + ", tanggal " + idwYear + "-" + idwMonth + "-" + idwDay + ", waktu " + idwHour + ":" + idwMinute + ":" + idwSecond + " status " + idwInOutMode.ToString() + ", BERHASIL"));
                                    jumlah += 1;
                                }
                            }
                            catch (Exception ex)
                            {
                                gagal.Add("ID " + sdwEnrollNumber + ", tanggal " + idwYear + "-" + idwMonth + "-" + idwDay + ", waktu " + idwHour + ":" + idwMinute + ":" + idwSecond + " status " + idwInOutMode.ToString() + " ke " + nomor + "/" + iValue);
                                lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data ke " + nomor + "/" + iValue + " ID " + sdwEnrollNumber + ", tanggal " + idwYear + "-" + idwMonth + "-" + idwDay + ", waktu " + idwHour + ":" + idwMinute + ":" + idwSecond + " status " + idwInOutMode.ToString() + ", GAGAL " + ex.Message));
                            }
                            fp.SaveChanges();
                            int percentage = nomor * 100 / iValue;
                            nomor++;
                            bwDownload.ReportProgress(percentage);
                        }
                        if (axCZKEM1.ClearGLog(iMachineNumber))
                        {
                            axCZKEM1.RefreshData(iMachineNumber);
                            lblProses.Invoke(new Action(() => lblProses.Text = "Menghapus Data absen di mesin"));
                        }
                        else
                        {
                            axCZKEM1.GetLastError(ref idwErrorCode);
                            lblProses.Invoke(new Action(() => lblProses.Text = "Operation failed,ErrorCode=" + idwErrorCode.ToString()));
                        }
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        axCZKEM1.GetLastError(ref idwErrorCode);

                        if (idwErrorCode != 0)
                        {
                            lblProses.Invoke(new Action(() => lblProses.Text = "Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString().ToString()));
                        }
                        else
                        {
                            lblProses.Invoke(new Action(() => lblProses.Text = "No data from terminal returns!"));
                        }
                    }
                    no += 1;
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                    axCZKEM1.Disconnect();
                }
            }
            if (gagal.Count > 0)
            {
                lblProses.Invoke(new Action(() => lblProses.Text = "Gagal mendownload " + gagal.Count + " data absensi"));
                MessageBox.Show("Gagal mendownload " + gagal.Count + " data absensi");
                e.Cancel = true;
            }
            else
            {
                lblProses.Invoke(new Action(() => lblProses.Text = "Berhasil mendownload " + jumlah.ToString() + " data absensi dari mesin"));
                MessageBox.Show("Berhasil mendownload " + jumlah.ToString() + " data absensi dari mesin");
            }
        }

        private void bwPosting_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            axCZKEM1.EnableDevice(iMachineNumber, true);
            axCZKEM1.Disconnect();
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                this.Close();
                return;
            }
            if (e.Cancelled)
            {
                MessageBox.Show("Proses download dibatalkan");
                this.Close();
                return;
            }
            this.Close();
        }

        private void FormProses_Load(object sender, EventArgs e)
        {
            try
            {
                mesin = fp.mesins.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bwPosting_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void FormProses_Shown(object sender, EventArgs e)
        {
            bwDownload.RunWorkerAsync();
        }

        private void FormProses_FormClosing(object sender, FormClosingEventArgs e)
        {
            axCZKEM1.Disconnect();
            if (bwDownload.IsBusy)
                e.Cancel = true;
        }
    }
}
