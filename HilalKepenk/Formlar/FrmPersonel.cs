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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            
            metot1();
        }

        void metot1()
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
            gridControl1.DataSource = degerler.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
            TBLPERSONEL t = new TBLPERSONEL();
            t.AD = txtPersonelAd.Text;
            t.SOYAD = txtPersonelSoyad.Text;
            t.MAIL = txtPersonelMail.Text;
            t.TELEFON = maskedTextBox3.Text;           
            t.ADRES = txtPersonelAdres.Text;
            db.TBLPERSONEL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Personel Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            metot1();
            }
            catch (Exception ec)
            {
                MessageBox.Show("Aynı Kayıt Tekrarlanamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

     

        private void btnSil_Click(object sender, EventArgs e)
        {
           
            if (!txtPersonelId.Text.Equals(""))
            {

                if (cardView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
                {
                    int id;
                    try
                    {
                        id = int.Parse(cardView1.GetFocusedRowCellValue("ID").ToString());
                        var deger = db.TBLPERSONEL.Find(id);
                        db.TBLPERSONEL.Remove(deger);
                        db.SaveChanges();
                        MessageBox.Show("Personel Bilgileri Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        metot1();
                        
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show("Bu Personel Kaydı Silinemez Diğer Tablolarla İlişkili Olduğundan", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!txtPersonelId.Equals(""))
            {
                try
                {
                    int id = int.Parse(cardView1.GetFocusedRowCellValue("ID").ToString());
                    var deger = db.TBLPERSONEL.Find(id);
                    deger.AD = txtPersonelAd.Text;
                    deger.SOYAD = txtPersonelSoyad.Text;
                    deger.MAIL = txtPersonelMail.Text;
                    deger.TELEFON = maskedTextBox3.Text;
                    deger.ADRES = txtPersonelAdres.Text;
                    db.SaveChanges();
                    metot1();
                    MessageBox.Show("Personel Bilgisi Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    metot1();
                }
                catch (Exception ec)
                {
                    MessageBox.Show("Aynı Kayıt Tekrarlanamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

    

        private void cardView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtPersonelId.Text = cardView1.GetFocusedRowCellDisplayText("ID").ToString();
            txtPersonelAd.Text = cardView1.GetFocusedRowCellDisplayText("AD").ToString();
            txtPersonelSoyad.Text = cardView1.GetFocusedRowCellDisplayText("SOYAD").ToString();
            txtPersonelMail.Text = cardView1.GetFocusedRowCellDisplayText("MAIL").ToString();
            maskedTextBox3.Text = cardView1.GetFocusedRowCellDisplayText("TELEFON").ToString();
            txtPersonelAdres.Text = cardView1.GetFocusedRowCellDisplayText("ADRES").ToString();
        }
    }
}
