using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fingerprint
{
    public partial class FormGagal : Form
    {
        private List<string> gagal;
        public FormGagal(List<string> data)
        {
            InitializeComponent();
            gagal = data;
        }

        private void FormGagal_Load(object sender, EventArgs e)
        {
            listGagal.DataSource = gagal;
            lblTotal.Text = "Jumlah data : " + gagal.Count();
        }

        private void LoadGagal()
        {
            try
            {
                listGagal.Invoke(new Action(() => listGagal.Items.Add("tes")));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
