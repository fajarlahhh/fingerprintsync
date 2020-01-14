using Fingerprint.Class;
using Fingerprint.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormSetKodeKantor : Form
    {
        string url = "";
        string id, nama, lokasi, mesin;
        AppSetting setting = new AppSetting();
        public FormSetKodeKantor()
        {
            InitializeComponent();
        }

        private void FormAturan_Load(object sender, EventArgs e)
        {
            this.url = setting.GetConnectionString("api");
            this.id = Properties.Settings.Default.kantor_id;
            this.nama = Properties.Settings.Default.kantor_nama;
            this.lokasi = Properties.Settings.Default.kantor_lokasi;
            this.mesin = Properties.Settings.Default.kantor_mesin;
            _ = GetKantorAsync();
        }

        private void FormSetKodeKantor_Shown(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgKantor.Rows)
                {
                    if (row.Cells[0].Value.ToString() == id)
                        row.Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cari = txtCari.Text;
                IEnumerable<DataKantor> filterKantor = kantor.Where(x => x.kantor_lokasi.ToLower().Contains(cari.ToLower()) || x.kantor_nama.ToLower().Contains(cari.ToLower())).ToList();
                dgKantor.DataSource = filterKantor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        IEnumerable<DataKantor> kantor;

        private async Task GetKantorAsync()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(this.url + "listkantor").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var customerJsonString = await response.Content.ReadAsStringAsync();
                        kantor = JsonConvert.DeserializeObject<IEnumerable<DataKantor>>(custome‌​rJsonString);
                        dgKantor.DataSource = kantor;

                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgKantor.SelectedRows)
                {
                    Properties.Settings.Default.kantor_id = row.Cells[0].Value.ToString();
                    Properties.Settings.Default.kantor_lokasi = row.Cells[1].Value.ToString();
                    Properties.Settings.Default.kantor_nama = row.Cells[2].Value.ToString();
                    Properties.Settings.Default.kantor_mesin = row.Cells[3].Value.ToString();
                    Properties.Settings.Default.Save();
                }
                Application.Restart();
                Environment.Exit(0);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
