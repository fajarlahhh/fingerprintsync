using Fingerprint.Class;
using Fingerprint.Helper;
using IniParser;
using IniParser.Model;
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
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("app.ini");

            this.id = data["Sekolah"]["IDSekolah"];
            this.nama = data["Sekolah"]["NamaSekolah"];
            this.lokasi = data["Sekolah"]["LokasiSekolah"];
            this.mesin = data["Sekolah"]["SupportMesin"];
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

        private void FormSetKodeKantor_FormClosed(object sender, FormClosedEventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("app.ini");

            string id = data["Sekolah"]["IDSekolah"];
            if (string.IsNullOrEmpty(id))
                Application.Exit();
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
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile("app.ini");

                    data["Sekolah"]["IDSekolah"] = row.Cells[0].Value.ToString();
                    data["Sekolah"]["NamaSekolah"] = row.Cells[2].Value.ToString();
                    data["Sekolah"]["LokasiSekolah"] = row.Cells[1].Value.ToString();
                    data["Sekolah"]["SupportMesin"] = row.Cells[3].Value.ToString();
                    parser.WriteFile("app.ini", data);
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
