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
    public partial class FormAturan : Form
    {
        readonly fingerprintEntities fp = new fingerprintEntities();

        public FormAturan()
        {
            InitializeComponent();
            cbHariSenin.Checked = true;
            cbHariSelasa.Checked = true;
            cbHariRabu.Checked = true;
            cbHariKamis.Checked = true;
            cbHariJumat.Checked = true;
            cbHariSabtu.Checked = true;
            cbHariMinggu.Checked = false;
        }

        private void FormAturan_Load(object sender, EventArgs e)
        {
            try
            {
                var aturan = fp.aturans.ToList();
                if (aturan.Count > 0)
                {
                    var senin = aturan.Where(x => x.aturan_hari.Equals(2)).FirstOrDefault();
                    if (senin != null)
                    {
                        cbHariSenin.Checked = senin.aturan_kegiatan;
                        dtMasukSenin.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(senin.aturan_jam_masuk.ToString()));
                        dtPulangSenin.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(senin.aturan_jam_pulang.ToString()));
                        dtMasukKhususSenin.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(senin.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususSenin.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(senin.aturan_jam_pulang_khusus.ToString()));
                    }

                    var selasa = aturan.Where(x => x.aturan_hari.Equals(3)).FirstOrDefault();
                    if (selasa != null)
                    {
                        cbHariSelasa.Checked = selasa.aturan_kegiatan;
                        dtMasukSelasa.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(selasa.aturan_jam_masuk.ToString()));
                        dtPulangSelasa.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(selasa.aturan_jam_pulang.ToString()));
                        dtMasukKhususSelasa.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(selasa.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususSelasa.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(selasa.aturan_jam_pulang_khusus.ToString()));
                    }

                    var rabu = aturan.Where(x => x.aturan_hari.Equals(4)).FirstOrDefault();
                    if (rabu != null)
                    {
                        cbHariRabu.Checked = rabu.aturan_kegiatan;
                        dtMasukRabu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(rabu.aturan_jam_masuk.ToString()));
                        dtPulangRabu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(rabu.aturan_jam_pulang.ToString()));
                        dtMasukKhususRabu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(rabu.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususRabu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(rabu.aturan_jam_pulang_khusus.ToString()));
                    }

                    var kamis = aturan.Where(x => x.aturan_hari.Equals(5)).FirstOrDefault();
                    if (kamis != null)
                    {
                        cbHariKamis.Checked = kamis.aturan_kegiatan;
                        dtMasukKamis.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(kamis.aturan_jam_masuk.ToString()));
                        dtPulangKamis.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(kamis.aturan_jam_pulang.ToString()));
                        dtMasukKhususKamis.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(kamis.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususKamis.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(kamis.aturan_jam_pulang_khusus.ToString()));
                    }

                    var jumat = aturan.Where(x => x.aturan_hari.Equals(6)).FirstOrDefault();
                    if (jumat != null)
                    {
                        cbHariJumat.Checked = jumat.aturan_kegiatan;
                        dtMasukJumat.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(jumat.aturan_jam_masuk.ToString()));
                        dtPulangJumat.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(jumat.aturan_jam_pulang.ToString()));
                        dtMasukKhususJumat.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(jumat.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususJumat.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(jumat.aturan_jam_pulang_khusus.ToString()));
                    }

                    var sabtu = aturan.Where(x => x.aturan_hari.Equals(7)).FirstOrDefault();
                    if (sabtu != null)
                    {
                        cbHariSabtu.Checked = sabtu.aturan_kegiatan;
                        dtMasukSabtu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(sabtu.aturan_jam_masuk.ToString()));
                        dtPulangSabtu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(sabtu.aturan_jam_pulang.ToString()));
                        dtMasukKhususSabtu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(sabtu.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususSabtu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(sabtu.aturan_jam_pulang_khusus.ToString()));
                    }

                    var minggu = aturan.Where(x => x.aturan_hari.Equals(1)).FirstOrDefault();
                    if (minggu != null)
                    {
                        cbHariMinggu.Checked = minggu.aturan_kegiatan;
                        dtMasukMinggu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(minggu.aturan_jam_masuk.ToString()));
                        dtPulangMinggu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(minggu.aturan_jam_pulang.ToString()));
                        dtMasukKhususMinggu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(minggu.aturan_jam_masuk_khusus.ToString()));
                        dtPulangKhususMinggu.Value = DateTime.Parse("2019-11-01 " + TimeSpan.Parse(minggu.aturan_jam_pulang_khusus.ToString()));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fingerprintEntities fp = new fingerprintEntities();
                fp.Database.ExecuteSqlCommand("delete from aturan");

                aturan senin = new aturan();
                senin.aturan_hari = 2;
                senin.aturan_kegiatan = cbHariSenin.Checked;
                senin.aturan_jam_masuk = dtMasukSenin.Value.TimeOfDay;
                senin.aturan_jam_pulang = dtPulangSenin.Value.TimeOfDay;
                senin.aturan_jam_masuk_khusus = dtMasukKhususSenin.Value.TimeOfDay;
                senin.aturan_jam_pulang_khusus = dtPulangKhususSenin.Value.TimeOfDay;
                fp.aturans.Add(senin);

                aturan selasa = new aturan();
                selasa.aturan_hari = 3;
                selasa.aturan_kegiatan = cbHariSelasa.Checked;
                selasa.aturan_jam_masuk = dtMasukSelasa.Value.TimeOfDay;
                selasa.aturan_jam_pulang = dtPulangSelasa.Value.TimeOfDay;
                selasa.aturan_jam_masuk_khusus = dtMasukKhususSelasa.Value.TimeOfDay;
                selasa.aturan_jam_pulang_khusus = dtPulangKhususSelasa.Value.TimeOfDay;
                fp.aturans.Add(selasa);

                aturan rabu = new aturan();
                rabu.aturan_hari = 4;
                rabu.aturan_kegiatan = cbHariRabu.Checked;
                rabu.aturan_jam_masuk = dtMasukRabu.Value.TimeOfDay;
                rabu.aturan_jam_pulang = dtPulangRabu.Value.TimeOfDay;
                rabu.aturan_jam_masuk_khusus = dtMasukKhususRabu.Value.TimeOfDay;
                rabu.aturan_jam_pulang_khusus = dtPulangKhususRabu.Value.TimeOfDay;
                fp.aturans.Add(rabu);

                aturan kamis = new aturan();
                kamis.aturan_hari = 5;
                kamis.aturan_kegiatan = cbHariKamis.Checked;
                kamis.aturan_jam_masuk = dtMasukKamis.Value.TimeOfDay;
                kamis.aturan_jam_pulang = dtPulangKamis.Value.TimeOfDay;
                kamis.aturan_jam_masuk_khusus = dtMasukKhususKamis.Value.TimeOfDay;
                kamis.aturan_jam_pulang_khusus = dtPulangKhususKamis.Value.TimeOfDay;
                fp.aturans.Add(kamis);

                aturan jumat = new aturan();
                jumat.aturan_hari = 6;
                jumat.aturan_kegiatan = cbHariJumat.Checked;
                jumat.aturan_jam_masuk = dtMasukJumat.Value.TimeOfDay;
                jumat.aturan_jam_pulang = dtPulangJumat.Value.TimeOfDay;
                jumat.aturan_jam_masuk_khusus = dtMasukKhususJumat.Value.TimeOfDay;
                jumat.aturan_jam_pulang_khusus = dtPulangKhususJumat.Value.TimeOfDay;
                fp.aturans.Add(jumat);

                aturan sabtu = new aturan();
                sabtu.aturan_hari = 7;
                sabtu.aturan_kegiatan = cbHariSabtu.Checked;
                sabtu.aturan_jam_masuk = dtMasukSabtu.Value.TimeOfDay;
                sabtu.aturan_jam_pulang = dtPulangSabtu.Value.TimeOfDay;
                sabtu.aturan_jam_masuk_khusus = dtMasukKhususSabtu.Value.TimeOfDay;
                sabtu.aturan_jam_pulang_khusus = dtPulangKhususSabtu.Value.TimeOfDay;
                fp.aturans.Add(sabtu);

                aturan minggu = new aturan();
                minggu.aturan_hari = 1;
                minggu.aturan_kegiatan = cbHariMinggu.Checked;
                minggu.aturan_jam_masuk = dtMasukMinggu.Value.TimeOfDay;
                minggu.aturan_jam_pulang = dtPulangMinggu.Value.TimeOfDay;
                minggu.aturan_jam_masuk_khusus = dtMasukKhususMinggu.Value.TimeOfDay;
                minggu.aturan_jam_pulang_khusus = dtPulangKhususMinggu.Value.TimeOfDay;
                fp.aturans.Add(minggu);

                fp.SaveChanges();
                MessageBox.Show("Berhasil menyimpan data aturan");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
