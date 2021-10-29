using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar
{
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            
           
     
            string sorgu = "select ilAdi from TBLIL order by ilAdi";
            DataSet ds = doldur(sorgu);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {             
               comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());                             
            }

            /*comboBox2.Items.Clear();
            string sorguU = "select id from TBLIL where ilAdi = '" + comboBox1.Text + "' ";
            DataSet dsU = doldur(sorguU);
            sorguU = "select ilceadi from ilceler where sehirid = '" + dsU.Tables[0].Rows[0][0] + "'";
            dsU.Clear();
            dsU = doldur(sorguU);
            for (int i = 0; i < dsU.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(dsU.Tables[0].Rows[i][0].ToString());
            }
            */

            metot1();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
                txtMusteriId.Text = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
                txtMusteriUnvan.Text = gridView1.GetFocusedRowCellDisplayText("MUSTERIUNVAN").ToString();
                maskedTextBox1.Text = gridView1.GetFocusedRowCellDisplayText("TELEFON").ToString();
                maskedTextBox1.Text = gridView1.GetFocusedRowCellDisplayText("TELEFON2").ToString();
                txtMail.Text = gridView1.GetFocusedRowCellDisplayText("MAIL").ToString();
                comboBox1.Text = gridView1.GetFocusedRowCellDisplayText("IL").ToString();
                comboBox2.Text = gridView1.GetFocusedRowCellDisplayText("ILCE").ToString();
                txtAdres.Text = gridView1.GetFocusedRowCellDisplayText("ADRES").ToString();
                txtHesapBilgisi.Text = gridView1.GetFocusedRowCellDisplayText("HESAPBILGISI").ToString();
            
        }
     
        
        //SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-53HGRRK\SQLEXPRESS;Initial Catalog=DBHilalKepenk;Integrated Security=True");
        public static string baglanti = ConfigurationManager.ConnectionStrings["HilalKepenk.Properties.Settings.DBHilalKepenkConnectionString"].ConnectionString;
        public DataSet doldur(string sorgu)
        {
            //baglanti.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            //baglanti.Close();
            return ds;
        }

      


        void metot1()
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

  
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLCARI t = new TBLCARI();
                t.MUSTERIUNVAN = txtMusteriUnvan.Text;
                t.TELEFON = maskedTextBox1.Text;
                t.TELEFON2 = maskedTextBox1.Text;
                t.MAIL = txtMail.Text;
                t.IL = comboBox1.Text;
                t.ILCE = comboBox2.Text;
                t.ADRES = txtAdres.Text;
                t.HESAPBILGISI = txtHesapBilgisi.Text;
                db.TBLCARI.Add(t);
                db.SaveChanges();
                metot1();
                MessageBox.Show("Müşteri Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ec)
            {
                MessageBox.Show("Bu Müşteri Kayıt Edilemiyor Diğer Tablolarla İlişkili Olduğundan", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                try
                {
                    int id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                    var deger = db.TBLCARI.Find(id);
                    db.TBLCARI.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Müşteri başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metot1();
                }
                catch(System.Data.Entity.Infrastructure.DbUpdateException ec)
                {
                    MessageBox.Show("Bu Müşteri Kaydı Silinemez Diğer Tablolarla İlişkili Olduğundan", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }                    
        }

        private void btnGuncelle_Click_1(object sender, EventArgs e)
        {

            if (gridView1.GetFocusedRowCellDisplayText("ID").ToString() != "")
            {
                try
                {
                    int id = int.Parse(gridView1.GetFocusedRowCellDisplayText("ID").ToString());
                    var deger = db.TBLCARI.Find(id);
                    deger.MUSTERIUNVAN = txtMusteriUnvan.Text;
                    deger.TELEFON = maskedTextBox1.Text;
                    deger.TELEFON2 = maskedTextBox1.Text;
                    deger.MAIL = txtMail.Text;
                    deger.IL = comboBox1.Text;
                    deger.ILCE = comboBox2.Text;
                    deger.ADRES = txtAdres.Text;
                    deger.HESAPBILGISI = txtHesapBilgisi.Text;
                    db.SaveChanges();
                    MessageBox.Show("Müşteri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    metot1();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ec)
                {
                    MessageBox.Show("Bu Müşteri Kaydı Güncellenemiyor Diğer Tablolarla İlişkili Olduğundan", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                //MessageBox.Show("Müşteri Bilgisi Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnListele_Click_1(object sender, EventArgs e)
        {
            metot1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string sorgu = "select id from TBLIL where ilAdi = '" + comboBox1.Text + "' ";
            DataSet ds = doldur(sorgu);
            sorgu = "select ilceAdi from ilceler where sehirid = '" + ds.Tables[0].Rows[0][0] + "'";
            ds.Clear();
            ds = doldur(sorgu);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
    }
}
