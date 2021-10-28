using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HilalKepenk.Formlar
{
    public partial class FrmFaturaPdf : Form
    {
        public FrmFaturaPdf()
        {
            InitializeComponent();
        }

        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmFaturaPdf_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.ToList();
            gridControl1.DataSource = degerler;
            dovizGoster();

            var degerlerBilgi = from u in db.TBLFATURABILGI
                                select new
                                {
                                    u.ID,
                                    u.SERI,
                                    u.SIRANO,
                                    u.TARIH,
                                    u.SAAT,
                                    TEKLIFHAZIRLAYAN = u.TBLPERSONEL.AD + " " + u.TBLPERSONEL.SOYAD,
                                    PERSONELTELEFON = u.TBLPERSONEL.TELEFON,
                                    CARI = u.TBLCARI.MUSTERIUNVAN,
                                    MAIL = u.TBLCARI.MAIL,
                                    IL = u.TBLCARI.IL,
                                    ILCE = u.TBLCARI.ILCE,
                                    ADRES = u.TBLCARI.ADRES,
                                    CARITELEFON = u.TBLCARI.TELEFON,
                                };
           
            searchLookUpEdit1.Properties.DataSource = degerlerBilgi.ToList();
            searchLookUpEdit1.Properties.DisplayMember = "CARI";
        }

        string customername, customermail, customerphone, customeradress, invoicedate, personelTel, personelName, path;

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.Text == "[EditValue is null]")
            {

            }
            else
            {
                path = searchLookUpEdit1View.GetFocusedRowCellDisplayText("SERI").ToString() + searchLookUpEdit1View.GetFocusedRowCellDisplayText("SIRANO").ToString();
                customername = searchLookUpEdit1View.GetFocusedRowCellDisplayText("CARI").ToString();
                customermail = searchLookUpEdit1View.GetFocusedRowCellDisplayText("MAIL").ToString();
                customerphone = searchLookUpEdit1View.GetFocusedRowCellDisplayText("CARITELEFON").ToString();
                customeradress = searchLookUpEdit1View.GetFocusedRowCellDisplayText("IL").ToString() + " " + searchLookUpEdit1View.GetFocusedRowCellDisplayText("ILCE").ToString() + " " + searchLookUpEdit1View.GetFocusedRowCellDisplayText("ADRES").ToString();
                personelName = searchLookUpEdit1View.GetFocusedRowCellDisplayText("TEKLIFHAZIRLAYAN".ToString());
                personelTel = searchLookUpEdit1View.GetFocusedRowCellDisplayText("PERSONELTELEFON").ToString();
                invoicedate = searchLookUpEdit1View.GetFocusedRowCellDisplayText("TARIH").ToString() + " " + searchLookUpEdit1View.GetFocusedRowCellDisplayText("SAAT").ToString();
            }


            Raporlar.XtraReport2 xtraReport = new Raporlar.XtraReport2();

            xtraReport.faturaBilgi(customername, customeradress, customerphone, customermail, invoicedate, path, personelTel, personelName);

            xtraReport.init(gridView2);

            Formlar.FrmPrint frmPrint = new Formlar.FrmPrint();
            frmPrint.initPdf2(xtraReport, path);
            frmPrint.Show();
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            if (searchLookUpEdit1.Text == "[EditValue is null]")
            {

            }
            else
            {
                path = searchLookUpEdit1View.GetFocusedRowCellDisplayText("SERI").ToString() + searchLookUpEdit1View.GetFocusedRowCellDisplayText("SIRANO").ToString();
                customername = searchLookUpEdit1View.GetFocusedRowCellDisplayText("CARI").ToString();
                customermail = searchLookUpEdit1View.GetFocusedRowCellDisplayText("MAIL").ToString();
                customerphone = searchLookUpEdit1View.GetFocusedRowCellDisplayText("CARITELEFON").ToString();
                customeradress = searchLookUpEdit1View.GetFocusedRowCellDisplayText("IL").ToString() + " " + searchLookUpEdit1View.GetFocusedRowCellDisplayText("ILCE").ToString() + " " + searchLookUpEdit1View.GetFocusedRowCellDisplayText("ADRES").ToString();
                personelName = searchLookUpEdit1View.GetFocusedRowCellDisplayText("TEKLIFHAZIRLAYAN".ToString());
                personelTel = searchLookUpEdit1View.GetFocusedRowCellDisplayText("PERSONELTELEFON").ToString();
                invoicedate = searchLookUpEdit1View.GetFocusedRowCellDisplayText("TARIH").ToString() + " " + searchLookUpEdit1View.GetFocusedRowCellDisplayText("SAAT").ToString();
            }


            Raporlar.XtraReport1 xtraReport = new Raporlar.XtraReport1();

            xtraReport.faturaBilgi(customername, customeradress, customerphone, customermail, invoicedate, path, personelTel, personelName);

            xtraReport.init(gridView2);

            Formlar.FrmPrint frmPrint = new Formlar.FrmPrint();
            frmPrint.initPdf(xtraReport, path);
            frmPrint.Show();
        }


        class Urun
        {
            public string UrunKodu { get; set; }
            public string Aciklama { get; set; }
            public string Miktar { get; set; }
            public string Birim { get; set; }
            public string BirimFiyat { get; set; }
            public double Tutar { get; set; }
            

        }

        List<Urun> urunListesi = new List<Urun>();
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            

            urunListesi.Add(new Urun() { UrunKodu = gridView1.GetFocusedRowCellDisplayText("URUNKODU").ToString(), Aciklama = gridView1.GetFocusedRowCellDisplayText("AD").ToString(), Miktar =  "1", Birim = gridView1.GetFocusedRowCellDisplayText("BIRIM").ToString(), BirimFiyat = gridView1.GetFocusedRowCellDisplayText("SATISFIYAT").ToString() + "$", Tutar = double.Parse(gridView1.GetFocusedRowCellDisplayText("SATISFIYAT"))*double.Parse(textEditUsd.Text) });


            gridControl2.DataSource = urunListesi.ToList();



          
        }


        public void dovizGoster()
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");


                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

                textEditUsd.Text = dolar.ToString();
                textEdit2.Text = euro.ToString();






            }
            catch (Exception xml)
            {
                timer1.Stop();
                textEditUsd.Text = "0,0000";
                textEdit2.Text = "0,0000";
            }

        }
    }
}
