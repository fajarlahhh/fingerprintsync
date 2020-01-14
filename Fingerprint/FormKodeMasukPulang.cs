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
            txtMasuk.Text = Properties.Settings.Default.masuk;
            txtPulang.Text = Properties.Settings.Default.pulang;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.masuk = txtMasuk.Text;
                Properties.Settings.Default.pulang = txtPulang.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
