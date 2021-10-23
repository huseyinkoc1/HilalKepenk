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
    public partial class FrmYeniSatis : Form
    {
        public FrmYeniSatis()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            
           


            try
            {

                TBLHAREKET t = new TBLHAREKET();
                t.ACIKLAMA = txtAciklama.Text;
                t.MUSTERI = int.Parse(txtMusteri.Text);
                t.PERSONEL = short.Parse(txtPersonel.Text);
                t.TARIH = DateTime.Parse(textEdit1.Text);
                t.FIYAT = decimal.Parse(txtFiyat.Text);
                t.URUNKODU = txtUrunKodu.Text;
                db.TBLHAREKET.Add(t);
                db.SaveChanges();
                MessageBox.Show("Satış Gerçekleşti.");
            }

            catch (Exception ec)
            {
                MessageBox.Show("Müşteri Bilgisini Kontrol Et.", "Hatalı Müşteri Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        void metotMusteri()
        {

            var degerler = from u in db.TBLCARI
                           select new
                           {
                               u.ID,
                               u.MUSTERIUNVAN,
                               u.TELEFON,
                               u.TELEFON2,
                               u.MAIL,
                               u.IL,
                               u.ILCE,
                               u.ADRES,
                               u.HESAPBILGISI
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        void metotPersonel()
        {

            var degerler = from u in db.TBLPERSONEL
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                               u.ADRES,

                           };
            gridControl2.DataSource = degerler.ToList();
        }
        private void FrmYeniSatis_Load(object sender, EventArgs e)
        {
            textEdit1.Text = DateTime.Today.ToString();
            txtFiyat.Text = "0";
            metotMusteri();
            metotPersonel();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtMusteri.Text = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtPersonel.Text = gridView2.GetFocusedRowCellDisplayText("ID").ToString();
        }

     
    }
}
