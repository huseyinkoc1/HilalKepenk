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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLAR.Where(x => x.DURUM == false).ToList();
            DovizGoster();
            timer1.Start();


        }

        public void DovizGoster()
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
               
               
                    decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                    decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

                    lblUsd.Text = dolar.ToString();
                    lblEuro.Text = euro.ToString();
                
               

                
                
                
            }
            catch (Exception xml)
            {
                timer1.Stop();
                lblUsd.Text = "";
                lblEuro.Text = "";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            DovizGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Formlar.FrmCariListesi fr = new Formlar.FrmCariListesi();
           
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formlar.Araclar.FrmNotlar fr = new Formlar.Araclar.FrmNotlar();
           
            fr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Formlar.FrmPersonel fr = new Formlar.FrmPersonel();
            
            fr.Show();
        }

       
    }
}
