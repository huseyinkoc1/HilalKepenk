using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HilalKepenk.Formlar
{
    public partial class FrmCariIller : Form
    {
        public FrmCariIller()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();

        
        public string adres = System.IO.File.ReadAllText(@"C:\Test.txt");
        
        private void FrmCariIller_Load(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection(adres);
            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.ILCE).GroupBy(y => y.ILCE).Select(z => new { ILCE = z.Key, TOPLAM = z.Count() }).ToList();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ILCE, COUNT(*) FROM TBLCARI group by ILCE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                string deger = Convert.ToString(dr[0]);
                if (!deger.Equals(""))
                {
                    chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
                }
                              
            }
            
        }
    }
}
