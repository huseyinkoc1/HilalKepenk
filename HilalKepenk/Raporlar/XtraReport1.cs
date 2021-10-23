using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace HilalKepenk.Raporlar
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        public void faturaBilgi(string customername, string customeradress, string customerphone, string customermail ,string date, string invoiceno, string personelPhone, string personelName)
        {
            
            customerName.Text = customername;
            customerAddress.Text = customeradress;
            customerPhone.Text = customerphone;
            customerMail.Text = customermail;
            invoiceDate.Text = date;
            invoiceNumber.Text = invoiceno;
            xrPersonelPhone.Text = personelPhone;
            xrPersonelName.Text = personelName;
            
        }

   


        public void initData(int id)
        {
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
            objectDataSource2.DataSource = degerlerDetay.ToList();
        }

        public void init(GridView gridView)
        {
            objectDataSource2.DataSource = gridView.DataSource;
        }

        public void not(string not)
        {
            xrNot.Text = not;
        }
    }
}
