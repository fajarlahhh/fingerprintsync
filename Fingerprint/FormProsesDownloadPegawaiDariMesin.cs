using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using zkemkeeper;
using System.Collections.Generic;

namespace Fingerprint
{
    public partial class FormProsesDownloadPegawaiDariMesin : Form
    {
        public CZKEMClass axCZKEM1 = new CZKEMClass();
        readonly fingerprintEntities fp = new fingerprintEntities();

        public FormProsesDownloadPegawaiDariMesin()
        {
            InitializeComponent();
        }

        private void btnBatal_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bwDownload.CancelAsync();
        }

        List<string> gagal = new List<string>();

        private void bwPosting_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bool bIsConnected = false;
            int iMachineNumber = 1;
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
                    string sName = "";
                    string sPassword = "";
                    int iPrivilege = 0;
                    bool bEnabled = false;
                    int iValue = 0;
                    lblProses.Invoke(new Action(() => lblProses.Text = "Menghitung jumlah data pegawai"));

                    if (axCZKEM1.GetDeviceStatus(iMachineNumber, 2, ref iValue))
                    {
                        int nomor = 1;
                        axCZKEM1.EnableDevice(iMachineNumber, false);
                        axCZKEM1.ReadAllUserID(iMachineNumber);
                        lblProses.Invoke(new Action(() => lblProses.Text = "Mendownload " + iValue.ToString() + " data pegawai"));
                        while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
                        {
                            try
                            {
                                if (fp.pegawais.Where(x => x.pegawai_id.Equals(sdwEnrollNumber)).Count() == 0)
                                {
                                    pegawai data = new pegawai();
                                    data.pegawai_id = sdwEnrollNumber;
                                    data.pegawai_nip = "";
                                    data.pegawai_nama = "";
                                    data.pegawai_panggilan = sName;
                                    data.pegawai_golongan = "";
                                    data.pegawai_jenis_kelamin = "";
                                    data.pegawai_izin = iPrivilege == 3 ? "0" : "1";
                                    data.pegawai_sandi = sPassword;
                                    data.upload = true;
                                    fp.pegawais.Add(data);
                                    fp.SaveChanges();
                                }
                                else
                                {
                                    var data = fp.pegawais.Where(x => x.pegawai_id.Equals(sdwEnrollNumber)).FirstOrDefault();
                                    data.pegawai_id = sdwEnrollNumber;
                                    data.pegawai_panggilan = sName;
                                    data.pegawai_izin = iPrivilege == 3 ? "0" : "1";
                                    data.pegawai_sandi = sPassword;
                                    data.upload = true;
                                    fp.SaveChanges();
                                }
                                jumlah += 1;
                                lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data ID " + sdwEnrollNumber + ", nama " + sName + ", BERHASIL"));
                            }
                            catch
                            {
                                gagal.Add("ID " + sdwEnrollNumber + ", nama " + sName);
                                lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data ID " + sdwEnrollNumber + ", nama " + sName + ", GAGAL"));
                            }
                            int percentage = nomor * 100 / iValue;
                            nomor++;
                            bwDownload.ReportProgress(percentage);
                        }
                        axCZKEM1.EnableDevice(iMachineNumber, true);
                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        lblProses.Invoke(new Action(() => lblProses.Text = "Operation failed,ErrorCode=" + idwErrorCode.ToString()));
                    }
                    no += 1;
                    axCZKEM1.Disconnect();
                }
            }
            if (gagal.Count > 0)
            {
                lblProses.Invoke(new Action(() => lblProses.Text = "Gagal mendownload " + gagal.Count + " data pegawai"));
                MessageBox.Show("Gagal mendownload " + gagal.Count + " data pegawai");
                e.Cancel = true;
            }
            else
            {
                lblProses.Invoke(new Action(() => lblProses.Text = "Berhasil mendownload " + jumlah.ToString() + " data pegawai dari mesin"));
                MessageBox.Show("Berhasil mendownload " + jumlah.ToString() + " data pegawai dari mesin");
            }
        }

        private void bwPosting_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
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
