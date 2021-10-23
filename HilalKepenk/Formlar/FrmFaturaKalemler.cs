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
    public partial class FrmFaturaKalemler : Form
    {
        public FrmFaturaKalemler()
        {
            InitializeComponent();
        }

        private void FrmFaturaKalemler_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dBHilalKepenkDataSet7.TBLFATURABILGI' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLFATURABILGITableAdapter.Fill(this.dBHilalKepenkDataSet7.TBLFATURABILGI);
           
        }

      
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(searchLookUpEdit1.Text == "")
            {
                MessageBox.Show("Fatura Seçimi Yapılmadı.");
            }
            else
            {
                int id = Convert.ToInt32(searchLookUpEdit1.Text);

                var degerler = (from u in db.TBLFATURADETAY
                                select new
                                {
                                    u.FATURADETAYID,
                                    u.URUNKODU,
                                    u.ACIKLAMA,
                                    u.RENK,
                                    u.MİKTAR,
                                    u.BIRIM,
                                    u.BIRIMFIYAT,
                                    u.TUTAR,
                                    u.FATURAID
                                }).Where(x => x.FATURAID == id);
                gridControl1.DataSource = degerler.ToList();
            }
            
        }
    }
}
