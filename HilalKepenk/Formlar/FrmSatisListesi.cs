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
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
           
            var degerler = from x in db.TBLHAREKET
                           select new
                           {
                               x.HAREKETID,
                               x.ACIKLAMA,
                               x.TBLCARI.MUSTERIUNVAN,
                               PERSONEL = x.TBLPERSONEL.AD +" "+ x.TBLPERSONEL.SOYAD,
                               x.TARIH,
                               x.FIYAT,
                               x.URUNKODU
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string path = "outputHL.pdf";
            gridControl1.ExportToPdf(path);
            Process.Start(path);
        }
    }
}
