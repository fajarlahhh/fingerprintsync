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
            foreach (var msn in mesin)
            {
                lblProses.Invoke(new Action(() => lblProses.Text = "Melakukan koneksi ke mesin " + msn.mesin_nama + ", IP " + msn.mesin_ip + ", port " + msn.mesin_key));
                bIsConnected = axCZKEM1.Connect_Net(msn.mesin_ip.Trim(), Convert.ToInt32(msn.mesin_key.Trim()));
                if (bIsConnected == true)
                {
                    lblProses.Invoke(new Action(() => lblProses.Text = "Koneksi ke mesin " + msn.mesin_nama + ", IP " + msn.mesin_ip + ", port " + msn.mesin_key + " berhasil"));
                        
                    //axCZKEM1.RegEvent(iMachineNumber, 65535);
                    //axCZKEM1.EnableDevice(iMachineNumber, false);

                    string sdwEnrollNumber = "";
                    string sName = "";
                    string sPassword = "";
                    int iPrivilege = 0;
                    bool bEnabled = false;

                    axCZKEM1.EnableDevice(iMachineNumber, false);

                    //axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                    //axCZKEM1.ReadAllTemplate(iMachineNumber);//read all the users' fingerprint templates to the memory
                        
                    lblProses.Invoke(new Action(() => lblProses.Text = "Mendownload data Pegawai dari mesin"));
                    while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
                    {
                        try
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
                            lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data ID " + sdwEnrollNumber + ", nama " + sName + ", BERHASIL"));
                        }
                        catch
                        {
                            gagal.Add("ID " + sdwEnrollNumber + ", nama " + sName);
                            lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data ID " + sdwEnrollNumber + ", nama " + sName + ", GAGAL"));
                        }
                    }
                    bwDownload.ReportProgress(100);
                    lblProses.Invoke(new Action(() => lblProses.Text = "Menyimpan data pegawai ke database"));
                    fp.SaveChanges();
                    axCZKEM1.EnableDevice(iMachineNumber, true);
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                    e.Cancel = true;
                }
            }
            lblProses.Invoke(new Action(() => lblProses.Text = "Download data pegawai berhasil"));
            MessageBox.Show("Download data pegawai berhasil");
        }

        private void bwPosting_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
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
            if(bwDownload.IsBusy)
                e.Cancel = true;
        }
    }
}
