using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormImportLog : Form
    {
        readonly fingerprintEntities fp = new fingerprintEntities();

        public FormImportLog()
        {
            InitializeComponent();
        }

        private void FormAturan_Load(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (DataGridViewRow row in dgLog.Rows)
                {
                    DateTime wkt = DateTime.Parse(row.Cells["Waktu"].Value.ToString());
                    log data = new log(); 
                    data.pegawai_id = row.Cells["ID"].Value.ToString();
                    data.log_tanggal = DateTime.Parse(row.Cells["Tanggal"].Value.ToString());
                    data.log_jam = wkt.TimeOfDay;
                    data.log_kode = "100";
                    data.log_status = row.Cells["Jenis"].Value.ToString();
                    fp.logs.Add(data);
                    fp.SaveChanges();
                }
                MessageBox.Show("Berhasil menyimpan data log");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try {
                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    string pathName = OpenFile.FileName;
                    string fileName = Path.GetFileNameWithoutExtension(OpenFile.FileName);
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    string sheetName = "data";

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                    OleDbConnection cnnxls = new OleDbConnection(strConn);
                    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                    oda.Fill(tbContainer);

                    dgLog.DataSource = tbContainer;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://dikbud.ntbprov.go.id/absensi/download/absen.xlsx");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=13255");
        }
    }
}
