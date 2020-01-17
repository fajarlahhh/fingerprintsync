using Fingerprint.Class;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormKodeMasukPulang : Form
    {

        public FormKodeMasukPulang()
        {
            InitializeComponent();
        }

        private void FormAturan_Load(object sender, EventArgs e)
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("app.ini");

                txtMasuk.Text = data["MasukPulang"]["Masuk"];
                txtPulang.Text = data["MasukPulang"]["Pulang"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("app.ini");

                data["MasukPulang"]["Masuk"] = txtMasuk.Text;
                data["MasukPulang"]["Pulang"] = txtPulang.Text;
                parser.WriteFile("app.ini", data);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
