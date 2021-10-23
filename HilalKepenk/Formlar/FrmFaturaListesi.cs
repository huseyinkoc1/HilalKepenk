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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dBHilalKepenkDataSet4.TBLPERSONEL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLPERSONELTableAdapter.Fill(this.dBHilalKepenkDataSet4.TBLPERSONEL);
            // TODO: Bu kod satırı 'dBHilalKepenkDataSet3.TBLCARI' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tBLCARITableAdapter.Fill(this.dBHilalKepenkDataSet3.TBLCARI);
            txtTarih.Text = DateTime.Today.ToString();         
            dateTimeOffsetEdit1.DateTimeOffset = DateTimeOffset.Now.AddDays(5);
            txtSeri.Text = "HL";
            txtSiraNo.Text = "00000";


            metot1();
            
        }

        private void txtSeri_TextChanged(object sender, EventArgs e)
        {
            txtSeri.Text = txtSeri.Text.ToUpper();
            txtSeri.SelectionStart = txtSeri.Text.Length;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.Text == "[EditValue is null]" || lookUpEdit1.Text == "[EditValue is null]")
            {
                MessageBox.Show("Müşteri ve Personel Seçimi Yapınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                 TBLFATURABILGI t = new TBLFATURABILGI();
                 t.SERI = txtSeri.Text;
                 t.SIRANO = txtSiraNo.Text;
                 t.TARIH = Convert.ToDateTime(txtTarih.Text);
                 t.SAAT = dateTimeOffsetEdit1.Text;
                 t.CARI = int.Parse(searchLookUpEdit1.EditValue.ToString());
                 t.TEKLIFHAZIRLAYAN = short.Parse(lookUpEdit1.EditValue.ToString());
                 MessageBox.Show("Fatura Sisteme Kayıt Edilmiştir. Kalem Girişi Yapabilirsiniz","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                 db.TBLFATURABILGI.Add(t);
                 db.SaveChanges();
                 metot1();
            }
            

            
        }

        void metot1()
        {
            var degerler = from u in db.TBLFATURABILGI
                           select new
                           {
                               u.ID,
                               u.SERI,
                               u.SIRANO,
                               u.TARIH,
                               u.SAAT,
                               TEKLIFHAZIRLAYAN = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                               CARI = u.TBLCARI.MUSTERIUNVAN
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            /*txtId.Text = gridView1.GetFocusedRowCellDisplayText("ID").ToString();
            txtSeri.Text = gridView1.GetFocusedRowCellDisplayText("SERI").ToString();
            txtSiraNo.Text = gridView1.GetFocusedRowCellDisplayText("SIRANO").ToString();
            txtTarih.Text = gridView1.GetFocusedRowCellDisplayText("TARIH").ToString();
            dateTimeOffsetEdit1.DateTimeOffset = DateTimeOffset.Parse(gridView1.GetFocusedRowCellDisplayText("TARIH"));
            searchLookUpEdit1.Text = gridView1.GetFocusedRowCellDisplayText("CARI").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellDisplayText("TEKLIFHAZIRLAYAN").ToString();*/  
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.FrmFaturaKalemPopup fr = new Formlar.FrmFaturaKalemPopup();
            fr.id = int.Parse(gridView1.GetFocusedRowCellDisplayText("ID").ToString());
            fr.Show();
        }
    }
}
