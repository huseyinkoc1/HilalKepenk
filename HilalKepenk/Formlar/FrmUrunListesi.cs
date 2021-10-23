using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
     
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            // List To-List
            var degerler = db.TBLURUN.ToList();
            gridControl1.DataSource = degerler;


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = txtUrunAd.Text;
            t.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
            t.STOK = short.Parse(txtStok.Text);
            t.KATEGORI = txtKategori.Text;
            t.MARKA = txtMarka.Text;
            t.BIRIM = txtBirim.Text;
            t.URUNKODU = txtUrunKodu.Text;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var degerler = db.TBLURUN.ToList();
            gridControl1.DataSource = degerler;

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.ToList();
            gridControl1.DataSource = degerler;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtUrunId.Text = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
            txtUrunAd.Text = gridView1.GetFocusedRowCellDisplayText("AD").ToString();
            txtAlisFiyat.Text = gridView1.GetFocusedRowCellDisplayText("ALISFIYAT").ToString();
            txtSatisFiyat.Text = gridView1.GetFocusedRowCellDisplayText("SATISFIYAT").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellDisplayText("STOK").ToString();
            txtKategori.Text = gridView1.GetFocusedRowCellDisplayText("KATEGORI").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellDisplayText("MARKA").ToString();
            txtBirim.Text = gridView1.GetFocusedRowCellDisplayText("BIRIM").ToString();
            txtUrunKodu.Text = gridView1.GetFocusedRowCellDisplayText("URUNKODU").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                if (id > 29)
                {
                var deger = db.TBLURUN.Find(id);
                db.TBLURUN.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                var degerler = db.TBLURUN.ToList();
                gridControl1.DataSource = degerler;
                }
                else
                {
                    MessageBox.Show("Bu Kayıt Silinemez", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
               
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                int id = int.Parse(gridView1.GetFocusedRowCellDisplayText("ID").ToString());
                if(id > 29)
                {
                    var deger = db.TBLURUN.Find(id);
                    deger.AD = txtUrunAd.Text;
                    deger.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                    deger.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
                    deger.STOK = short.Parse(txtStok.Text);
                    deger.KATEGORI = txtKategori.Text;
                    deger.MARKA = txtMarka.Text;
                    deger.BIRIM = txtBirim.Text;
                    deger.URUNKODU = txtUrunKodu.Text;
                    db.SaveChanges();
                    var degerler = db.TBLURUN.ToList();
                    gridControl1.DataSource = degerler;
                    MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var deger = db.TBLURUN.Find(id);
                    deger.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                    deger.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text);
                    deger.STOK = short.Parse(txtStok.Text);
                    deger.KATEGORI = txtKategori.Text;
                    deger.MARKA = txtMarka.Text;
                    deger.BIRIM = txtBirim.Text;
                    deger.URUNKODU = txtUrunKodu.Text;
                    db.SaveChanges();
                    var degerler = db.TBLURUN.ToList();
                    gridControl1.DataSource = degerler;
                    MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }

        }
    }
}
