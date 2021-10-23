using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HilalKepenk.Formlar
{
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }
        public int id;
        public int cd;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            //labelControl1.Text = id.ToString();
            DBHilalKepenkEntities db = new DBHilalKepenkEntities();
            //gridControl1.DataSource = db.TBLFATURADETAY.Where(x=>x.FATURAID==id).ToList();
            //gridControl2.DataSource = db.TBLFATURABILGI.Where(x => x.ID == id).ToList();
           
            var degerlerBilgi = from u in db.TBLFATURABILGI.Where(x => x.ID == id)
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

        

            var degerlerDetay = from u in db.TBLFATURADETAY.Where(x => x.FATURAID == id)
                                select new
                                {
                                    u.ACIKLAMA,
                                    u.BIRIM,
                                    u.BIRIMFIYAT,
                                    u.RENK,
                                    u.MİKTAR,
                                    u.URUNKODU,
                                    u.FATURAID,
                                    u.TUTAR,
                                };
            gridControl2.DataSource = degerlerBilgi.ToList();
            gridControl1.DataSource = degerlerDetay.ToList();
           
        }


        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string path = "output.pdf";
            gridControl1.ExportToPdf(path);
            Process.Start(path);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "output.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string customername, customermail, customerphone, customeradress, invoicedate,personelTel,personelName, path;

       
        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            Raporlar.XtraReport2 xtraReport2 = new Raporlar.XtraReport2();

            xtraReport2.faturaBilgi(customername, customeradress, customerphone, customermail, invoicedate, path, personelTel, personelName);
            xtraReport2.initData(id);
            xtraReport2.not(textEditNot.Text);
            //xtra.ExportToPdf(path+".pdf");
            //Process.Start(path+".pdf");

            Formlar.FrmPrint frmPrint = new Formlar.FrmPrint();
            frmPrint.initPdf2(xtraReport2, path);
            frmPrint.Show();




        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            Raporlar.XtraReport1 xtra = new Raporlar.XtraReport1();

            xtra.faturaBilgi(customername, customeradress, customerphone, customermail, invoicedate, path, personelTel, personelName);
            xtra.initData(id);
            xtra.not(textEditNot.Text);
            xtra.ExportToXlsx(path + ".xlsx");
            Process.Start(path + ".xlsx");
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            path = gridView2.GetFocusedRowCellDisplayText("SERI").ToString() + gridView2.GetFocusedRowCellDisplayText("SIRANO").ToString();
            customername = gridView2.GetFocusedRowCellDisplayText("CARI").ToString();
            customermail = gridView2.GetFocusedRowCellDisplayText("MAIL").ToString();
            customerphone = gridView2.GetFocusedRowCellDisplayText("CARITELEFON").ToString();
            customeradress = gridView2.GetFocusedRowCellDisplayText("IL").ToString() + " " + gridView2.GetFocusedRowCellDisplayText("ILCE").ToString() + " " + gridView2.GetFocusedRowCellDisplayText("ADRES").ToString();
            personelName = gridView2.GetFocusedRowCellDisplayText("TEKLIFHAZIRLAYAN".ToString());
            personelTel = gridView2.GetFocusedRowCellDisplayText("PERSONELTELEFON").ToString();
            invoicedate = gridView2.GetFocusedRowCellDisplayText("TARIH").ToString() + " " + gridView2.GetFocusedRowCellDisplayText("SAAT").ToString();
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {


            Raporlar.XtraReport1 xtra = new Raporlar.XtraReport1();

            xtra.faturaBilgi(customername,customeradress,customerphone,customermail,invoicedate,path,personelTel,personelName);
            xtra.initData(id);
            xtra.not(textEditNot.Text);
            // xtra.ExportToPdf(path+".pdf");
            //Process.Start(path+".pdf");

            Formlar.FrmPrint frmPrint = new Formlar.FrmPrint();
            frmPrint.initPdf(xtra, path);
            frmPrint.Show();
           
        }


      
    }
}
