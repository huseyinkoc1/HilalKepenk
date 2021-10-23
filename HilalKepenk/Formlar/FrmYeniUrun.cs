using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HilalKepenk.Formlar
{
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DBHilalKepenkEntities db = new DBHilalKepenkEntities();
            TBLURUN t = new TBLURUN();
            
            
            t.AD = txtUrunAd.Text;
            if (String.IsNullOrEmpty(txtAlisFiyat.Text))
            {
                t.ALISFIYAT = 0;
            }
            else { t.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text); }

            if (String.IsNullOrEmpty(txtSatisFiyat.Text))
            {
                t.SATISFIYAT = 0;
            }
            else { t.SATISFIYAT = decimal.Parse(txtSatisFiyat.Text); }
                      
            if (String.IsNullOrEmpty(txtStok.Text))
            {   
                t.STOK = 0; 
            }
            else { t.STOK = short.Parse(txtStok.Text); }
            t.KATEGORI = txtKategori.Text;
            t.MARKA = txtMarka.Text;
            t.BIRIM = txtBirim.Text;
            t.URUNKODU = txtUrunKodu.Text;
            db.TBLURUN.Add(t);
            db.SaveChanges();
          
            MessageBox.Show("Ürün Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            
        }

    }
}
