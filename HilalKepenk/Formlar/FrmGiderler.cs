using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar
{
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dBHilalKepenkDataSet12.TBLGIDER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLGIDERTableAdapter.Fill(this.dBHilalKepenkDataSet12.TBLGIDER);

            txtTarih.Text = DateTime.Today.ToString();

        }

        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLGIDER t = new TBLGIDER();
            t.GIDERACIKLAMA = txtAciklama.Text;
            t.TUTAR = decimal.Parse(txtTutar.Text);
            t.TARIH = Convert.ToDateTime(txtTarih.Text);
            db.TBLGIDER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            var degerler = db.TBLGIDER.ToList();
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellDisplayText("GIDERID").ToString();
            txtAciklama.Text = gridView1.GetFocusedRowCellDisplayText("GIDERACIKLAMA").ToString();
            txtTutar.Text = gridView1.GetFocusedRowCellDisplayText("TUTAR").ToString();
            txtTarih.Text = gridView1.GetFocusedRowCellDisplayText("TARIH").ToString(); 
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("GIDERID").ToString());
        
                var deger = db.TBLGIDER.Find(id);
                db.TBLGIDER.Remove(deger);
                db.SaveChanges();
                var degerler = db.TBLGIDER.ToList();
                gridControl1.DataSource = degerler.ToList();
                MessageBox.Show("Kayıt Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
           
          

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
                int id = int.Parse(gridView1.GetFocusedRowCellDisplayText("GIDERID").ToString());
            
                var deger = db.TBLGIDER.Find(id);
                deger.GIDERACIKLAMA = txtAciklama.Text;
                deger.TUTAR = decimal.Parse(txtTutar.Text);
                if(txtTarih.Text != "")
                {
                deger.TARIH = Convert.ToDateTime(txtTarih.Text);
                }
                
                db.SaveChanges();
                var degerler = db.TBLGIDER.ToList();
                gridControl1.DataSource = degerler.ToList();
                MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = "outputHL.pdf";
            gridControl1.ExportToPdf(path);
            Process.Start(path);
        }
    }
}
