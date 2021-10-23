using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar.Araclar
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dBHilalKepenkDataSet2.TBLNOTLAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLNOTLARTableAdapter.Fill(this.dBHilalKepenkDataSet2.TBLNOTLAR);
            gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLAR.Where(y => y.DURUM == true).ToList();     
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLAR t = new TBLNOTLAR();
            t.BASLIK = txtBaslik.Text;
            t.ICERIK = txtİcerik.Text;
            t.DURUM = false;
            db.TBLNOTLAR.Add(t);
            db.SaveChanges();
            gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLAR.Where(y => y.DURUM == true).ToList();
            

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLAR.Where(y => y.DURUM == true).ToList();
        }

        

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(txtNotID.Text);
            if (gridView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                int id = int.Parse(gridView1.GetFocusedRowCellDisplayText("ID").ToString());
                var deger = db.TBLNOTLAR.Find(id);
                deger.DURUM = true;
                db.SaveChanges();
                var degerler = db.TBLNOTLAR.ToList();
                gridControl1.DataSource = degerler;
                gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
                gridControl2.DataSource = db.TBLNOTLAR.Where(y => y.DURUM == true).ToList();
                
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //int id = int.Parse(txtNotID.Text);

            if (gridView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                var deger = db.TBLNOTLAR.Find(id);
                db.TBLNOTLAR.Remove(deger);
                db.SaveChanges();
                gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
                //MessageBox.Show("Not başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
                                  
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridView2.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                int id = int.Parse(gridView2.GetFocusedRowCellValue("ID").ToString());
                var deger = db.TBLNOTLAR.Find(id);
                db.TBLNOTLAR.Remove(deger);
                db.SaveChanges();  
                gridControl2.DataSource = db.TBLNOTLAR.Where(y => y.DURUM == true).ToList();
                //MessageBox.Show("Not başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
   
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtNotID.Text = gridView2.GetFocusedRowCellDisplayText("ID").ToString();          
            txtBaslik.Text = gridView2.GetFocusedRowCellDisplayText("BASLIK").ToString();
            txtİcerik.Text = gridView2.GetFocusedRowCellDisplayText("ICERIK").ToString();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtNotID.Text = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
            txtBaslik.Text = gridView1.GetFocusedRowCellDisplayText("BASLIK").ToString();
            txtİcerik.Text = gridView1.GetFocusedRowCellDisplayText("ICERIK").ToString();
        }
    }
}
