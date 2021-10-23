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
    public partial class FrmServisListesi : Form
    {
        public FrmServisListesi()
        {
            InitializeComponent();
        }

        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmServisListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLSERVISTAKIP
                           select new
                           {
                               x.ISLEMID,
                               x.ACIKLAMA,
                               x.ISLEM,
                               x.TBLCARI.MUSTERIUNVAN,
                               PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                               x.TARIH,
                               x.FIYAT,
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
