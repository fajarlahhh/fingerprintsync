using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using zkemkeeper;
using System.Collections.Generic;

namespace Fingerprint
{
    public partial class FormProsesUploadPegawaiKeMesin : Form
    {
        CZKEMClass axCZKEM1 = new CZKEMClass();
        fingerprintEntities fp = new fingerprintEntities();

        public FormProsesUploadPegawaiKeMesin()
        {
            InitializeComponent();
            lblProses.Text = "Mengambil data mesin";
        }

        private void btnBatal_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            bwDownload.CancelAsync();
        }

        private void bwPosting_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                bool bIsConnected = false;
                int iMachineNumber = 1;
                int idwErrorCode = 0;

                lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data mesin"));
                var mesin = fp.mesins.ToList();
                foreach (var msn in mesin)
                {
                    lblProses.Invoke(new Action(() => lblProses.Text = "Melakukan koneksi ke mesin " + msn.mesin_nama + ", IP " + msn.mesin_ip + ", port " + msn.mesin_key));
                    bIsConnected = axCZKEM1.Connect_Net(msn.mesin_ip, Convert.ToInt32(msn.mesin_key));
                    if (bIsConnected == true)
                    {

                        int iUpdateFlag = 1;
                        axCZKEM1.EnableDevice(iMachineNumber, false);
                        if (axCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag))//create memory space for batching data
                        {
                            string sdwEnrollNumber = "";
                            string nip = "";
                            string sName = "";
                            int idwFingerIndex = 0;
                            string sTmpData = "";
                            int iPrivilege = 0;
                            string sPassword = "";
                            bool bEnabled = true;
                            int iFlag = 1;
                            lblProses.Invoke(new Action(() => lblProses.Text = "Mengambil data pegawai"));
                            var pegawai = fp.pegawais.ToList();
                            string sLastEnrollNumber = "";//the former enrollnumber you have upload(define original value as 0)
                            var nomor = 1;
                            int iValue = pegawai.Count();
                            foreach(var row in pegawai)
                            {
                                sdwEnrollNumber = row.pegawai_id.ToString();
                                sName = row.pegawai_panggilan;
                                nip = row.pegawai_nip;
                                iPrivilege = row.pegawai_izin == "0" ? 3 : 0;
                                sPassword = row.pegawai_sandi;

                                if (sdwEnrollNumber != sLastEnrollNumber)//identify whether the user information(except fingerprint templates) has been uploaded
                                {
                                    if (axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload user information to the memory
                                    {
                                        lblProses.Invoke(new Action(() => lblProses.Text = "Mengupload data pegawai " + nip));
                                    }
                                    else
                                    {
                                        axCZKEM1.GetLastError(ref idwErrorCode);
                                        MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
                                        axCZKEM1.EnableDevice(iMachineNumber, true);
                                        return;
                                    }
                                }
                                else//the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                                {
                                    axCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, iFlag, sTmpData);
                                }
                                sLastEnrollNumber = sdwEnrollNumber;//change the value of iLastEnrollNumber dynamicly

                                int percentage = nomor * 100 / iValue;
                                nomor++;
                                bwDownload.ReportProgress(percentage);
                            }
                        }
                        bwDownload.ReportProgress(100);
                        lblProses.Invoke(new Action(() => lblProses.Text = "Upload data pegawai berhasil"));
                        MessageBox.Show("Upload data pegawai berhasil");
                        axCZKEM1.BatchUpdate(iMachineNumber);//upload all the information in the memory
                        axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                        axCZKEM1.EnableDevice(iMachineNumber, true);                        
                    }
                    else
                    {
                        axCZKEM1.GetLastError(ref idwErrorCode);
                        MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");
                        e.Cancel = true;
                    }
                    iMachineNumber += 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                MessageBox.Show("Proses upload dibatalkan");
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
