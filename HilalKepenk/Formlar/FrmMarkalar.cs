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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(Y => Y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl5.Text = db.TBLURUN.Count().ToString();
            labelControl29.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl3.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.MARKA).FirstOrDefault();

            chartControl1.Series["Series 1"].Points.AddPoint("Siemens",4);
            chartControl1.Series["Series 1"].Points.AddPoint("Samsung",5);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik",3);
            chartControl1.Series["Series 1"].Points.AddPoint("Vestel",7);
            chartControl1.Series["Series 1"].Points.AddPoint("Asus",11);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Samsung",12);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Lenovo",5);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Hp",18);
        
        
        
        
        }
    }
}
