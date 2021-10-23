using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HilalKepenk.Formlar
{
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-53HGRRK\SQLEXPRESS;Initial Catalog=DBHilalKepenk;Integrated Security=True");
        private void FrmCariEkle_Load(object sender, EventArgs e)
        {


            string sorgu = "select ilAdi from TBLIL order by ilAdi";
            DataSet ds = doldur(sorgu);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }



        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.MUSTERIUNVAN = txtCariUnvan.Text;
            t.TELEFON = maskedTextBox1.Text;
            t.TELEFON2 = maskedTextBox2.Text;
            t.MAIL = txtMail.Text;
            t.IL = comboBox1.Text;
            t.ILCE = comboBox2.Text;
            t.ADRES = txtAdres.Text;
            t.HESAPBILGISI = txtHesapBilgisi.Text;
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Müşteri Başarıyla Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DataSet doldur(string sorgu)
        {
            baglanti.Open();
            SqlDataAdapter adp = new SqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            baglanti.Close();
            return ds;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string sorgu = "select id from TBLIL where ilAdi = '" + comboBox1.Text + "' ";
            DataSet ds = doldur(sorgu);
            sorgu = "select ilceAdi from ilceler where sehirid = '" + ds.Tables[0].Rows[0][0] + "'";
            ds.Clear();
            ds = doldur(sorgu);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboBox2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }
    }
}
