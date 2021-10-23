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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }
        DBHilalKepenkEntities db = new DBHilalKepenkEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            // MessageBox.Show(searchLookUpEdit1.EditValue.ToString());
            //int id =  int.Parse(searchLookUpEdit1.EditValue.ToString());
            //var deger = db.TBLFATURABILGI.Find(id);

            //MessageBox.Show(deger.TBLCARI.MUSTERIUNVAN.ToString());

            // int id = int.Parse(searchLookUpEdit3.EditValue.ToString());
            // var deger = db.TBLFATURABILGI.Find(id);
            // MessageBox.Show(deger.TBLCARI.MUSTERIUNVAN.ToString());

            if (searchLookUpEdit3.Text == "[EditValue is null]" || hesapIslemi == false)
            {
                MessageBox.Show("Fatura Seçimi Yapınız Veya En Boy Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (en == -1 || boy == -1)
                {
                    MessageBox.Show("Farklı Bir Kalem Girişi Yapınız", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int id = int.Parse(searchLookUpEdit3.EditValue.ToString());
                    motorKayit(id);
                    kumandaKayit(id);
                    dikmeKayit(id);
                    lamelKayit(id);
                    if (radioSecim == 0)
                    {
                        davlumbazKayitU(en, id);
                    }
                    else
                    {
                        davlumbazKayitL(en, id);
                    }
                    yanKapakKayit(id);
                    boruKayit(id);
                    boruBasiRulmanKayit(id);
                    altBazaKayit(id);
                    dikmeFitilKayit(id);
                    if(radioProfilSecim == 1)
                    {
                        uSacKayit(id);
                    }
                    else
                    {
                        profilKayit(id);
                    }
                    
                   
                    tapaKayit(id);
                    percinKayit(id);
                    en = -1;
                    boy = -1;
                    MessageBox.Show("Faturaya ait kalem girişi başarı ile yapıldı.");
                }
                
            
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

            searchLookUpEdit3.Properties.DataSource = degerler.ToList();
            searchLookUpEdit3.Properties.ValueMember = "ID";
            searchLookUpEdit3.Properties.DisplayMember = "CARI";
            
        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
    
            radioU.Checked = true;
            radioUSac.Checked = true;
            metot1();
        }

        class Urun
        {
            public string Id { get; set; }
            public string Aciklama { get; set; }
            public string Tutar { get; set; }
           
        }

        int en, boy,radioSecim,radioProfilSecim;
        Boolean hesapIslemi = false;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            
           

            if(txtEn.Text != "" && txtBoy.Text != "")
            {
                en = int.Parse(txtEn.Text);
                boy = int.Parse(txtBoy.Text);

                profilTutar = 0;
                uSacTutar = 0;
                
                

                if (radioU.Checked == true)
                {
                    radioSecim = 0;
                    kumandaHesap();

                    lamelHesapla();
                    List <Urun> urunListesi = new List<Urun>();

                    urunListesi.Add(new Urun() {Id = "1" , Aciklama = "Motor: " + motorHesapla(lamelSayisi, en, boy), Tutar= motorTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "2", Aciklama = "1 Adet Kumanda Takımı", Tutar = kumandaTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "3", Aciklama = "Dikme Uzunluğu: " + dikmeHesapla(), Tutar = dikmeTutar.ToString() });
                    
                    urunListesi.Add(new Urun() { Id = "4", Aciklama = "Lamel Adet: " + lamelSayisi, Tutar = lamelTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "5", Aciklama =  "U Davlumbaz "+davlumbazSecimiU(boy) + "'luk." , Tutar = uDavlumbazTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "6", Aciklama = "Yan Kapak " + yanKapak(boy) + "'luk." , Tutar = yanKapakTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "7", Aciklama = "Dikme Fitili " + dikmeFitili(), Tutar = dikmeFitilTutar.ToString() });
                    
                    if (radioUSac.Checked == true)
                    {
                        radioProfilSecim = 1;
                        uSac();
                        urunListesi.Add(new Urun() { Id = "8", Aciklama = "U Sac ", Tutar = uSacTutar.ToString() });
                    }
                    else
                    {
                        radioProfilSecim = 2;
                        boydanProfil();
                        urunListesi.Add(new Urun() { Id = "8", Aciklama = "Boydan Profil ", Tutar = profilTutar.ToString() });
                    }

                    urunListesi.Add(new Urun() { Id = "9", Aciklama = "Boru " + boru(radioProfilSecim) + "'luk. "+boruUzunluk, Tutar = boruTutar.ToString() });
                    
                    urunListesi.Add(new Urun() { Id = "10", Aciklama = boruSecim + "'lik Boru Başı Rulman", Tutar = boruBasiRulmanTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "11", Aciklama = "Alt Baza " + altBaza(radioProfilSecim), Tutar = altBazaTutar.ToString() });
                   
                    urunListesi.Add(new Urun() { Id = "12", Aciklama = "Tapa " + tapaHesap(boy), Tutar = tapaTutar.ToString() });
                    
                    urunListesi.Add(new Urun() { Id = "13", Aciklama = "Percin " + percinHesap(boy), Tutar = percinTutar.ToString() });

                    double toplamTutar = double.Parse(motorTutar.ToString())+kumandaTutar+dikmeTutar+lamelTutar+uSacTutar+profilTutar+uDavlumbazTutar+yanKapakTutar+boruTutar+boruBasiRulmanTutar+altBazaTutar+dikmeFitilTutar+tapaTutar+percinTutar;

                    labelToplamTutar.Text = toplamTutar+"";
                    labelAlisTutar.Text = alisFiyat + "";
                    labelMalzemeKar.Text = toplamTutar - alisFiyat + "";
                    double montajEn = Convert.ToDouble(en) / 100;
                    double montajBoy = Convert.ToDouble(boy) / 100;
                    double montajHesap = (montajEn * montajBoy) * 400;
                    labelControl7.Text = montajHesap.ToString();


                    gridControl2.DataSource = urunListesi;
                    hesapIslemi = true;
                    alisFiyat = 0;
                }
                else
                {
                    radioSecim = 1;
                    kumandaHesap();
                    lamelHesapla();

                    List<Urun> urunListesi = new List<Urun>();

                    urunListesi.Add(new Urun() { Id = "1", Aciklama = "Motor: " + motorHesapla(lamelSayisi, en, boy), Tutar = motorTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "2", Aciklama = "1 Adet Kumanda Takımı", Tutar = kumandaTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "3", Aciklama = "Dikme Uzunluğu " + dikmeHesapla(), Tutar = dikmeTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "4", Aciklama = "Lamel Adet " + lamelSayisi, Tutar = lamelTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "5", Aciklama = "L Davlumbaz  " + davlumbazSecimiL(boy) + "'luk.", Tutar = lDavlumbazTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "6", Aciklama = "Yan Kapak " + yanKapak(boy) + "'luk.", Tutar = yanKapakTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "7", Aciklama = "Dikme Fitili " + dikmeFitili(), Tutar = dikmeFitilTutar.ToString() });
 
                    if (radioUSac.Checked == true)
                    {
                        radioProfilSecim = 1;
                        uSac();
                        urunListesi.Add(new Urun() { Id = "8", Aciklama = "U Sac " , Tutar = uSacTutar.ToString() });
                    }
                    else
                    {
                        radioProfilSecim = 2;
                        boydanProfil();
                        urunListesi.Add(new Urun() { Id = "8", Aciklama = "Boydan Profil ", Tutar = profilTutar.ToString() });
                    }

                    urunListesi.Add(new Urun() { Id = "9", Aciklama = "Boru " + boru(radioProfilSecim) + "'luk. "+ boruUzunluk, Tutar = boruTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "10", Aciklama = boruSecim + "'lik Boru Başı Rulman", Tutar = boruBasiRulmanTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "11", Aciklama = "Alt Baza " + altBaza(radioProfilSecim), Tutar = altBazaTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "12", Aciklama = "Tapa " + tapaHesap(boy), Tutar = tapaTutar.ToString() });

                    urunListesi.Add(new Urun() { Id = "13", Aciklama = "Percin " + percinHesap(boy), Tutar = percinTutar.ToString() });

                    double toplamTutar = double.Parse(motorTutar.ToString()) + kumandaTutar + dikmeTutar + lamelTutar + uSacTutar + profilTutar + lDavlumbazTutar + yanKapakTutar + boruTutar + boruBasiRulmanTutar + altBazaTutar + dikmeFitilTutar + tapaTutar + percinTutar;

                    labelToplamTutar.Text = toplamTutar + "";
                    labelAlisTutar.Text = alisFiyat + "";

                    gridControl2.DataSource = urunListesi;
                    hesapIslemi = true;
                    alisFiyat = 0;
                }
                
            }
            else
            {
                MessageBox.Show("En ve Boy Ölçülerini Giriniz.");
            }
        }


        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            string path = "outputHL.pdf";
            gridControl2.ExportToPdf(path);
            Process.Start(path);
        }
        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "outputHL.xlsx";
            gridControl2.ExportToXlsx(path);
            Process.Start(path);
        }












        double alisFiyat = 0;
        int lamelSayisi ;
        double lamelTutar;
        int lamelHesapla()
        {
            double lamel = boy / 7.7;

           // Double lamelSayisi = Math.Round((Double)lamel, 2);

            int ondalik = ((int)(lamel * 100)) % 100;
            lamelSayisi = ((int)lamel * 100) / 100;


            

                int id = 12;
                var deger = db.TBLURUN.Find(id);
                double enn = Convert.ToDouble(en) / 100;
                lamelTutar = lamelSayisi * enn * Convert.ToDouble(deger.SATISFIYAT);
                alisFiyat += lamelSayisi * enn * Convert.ToDouble(deger.ALISFIYAT);
                return lamelSayisi;            
           
         

           

        }


        double kumandaTutar;
        void kumandaHesap()
        {
            int id = 10;
            var deger = db.TBLURUN.Find(id);
            kumandaTutar = double.Parse(deger.SATISFIYAT.ToString());
            alisFiyat += double.Parse(deger.ALISFIYAT.ToString());

        }


        int motorSecim = 0;
        
        decimal motorTutar;
        string motorHesapla(int lamelSayisi, int en, int boy)
        {
            double enn = Convert.ToDouble(en);
            double agirlik = (((lamelSayisi * enn )/ 100)*0.7);
            agirlik = (agirlik / 2)+agirlik;

            if (agirlik <= 80)
            {
                motorSecim = 1;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "60N MOTOR";
            }
            else if (agirlik > 80 && agirlik <= 120)
            {
                motorSecim =2;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "80N MOTOR";
            }
            else if (agirlik > 120 && agirlik <= 150)
            {
                motorSecim = 3;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "100N MOTOR";
            }
            else if (agirlik > 150 && agirlik <= 180)
            {
                motorSecim = 4;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "120N MOTOR";
            }
            else if (agirlik > 180 && agirlik <= 210)
            {
                motorSecim = 5;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "140N MOTOR ";
            }
            else if (agirlik > 210 && agirlik <= 270)
            {
                motorSecim = 6;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "180N MOTOR";
            }
            else if (agirlik > 270 && agirlik <= 335)
            {
                motorSecim = 7;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "230N MOTOR";
            }
            else if (agirlik > 335 && agirlik <= 500)
            {
                motorSecim = 8;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "330N MOTOR";
            }
            else 
            {
                motorSecim = 9;
                int id = motorSecim;
                var deger = db.TBLURUN.Find(id);
                motorTutar = decimal.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return "Zincirli Motor";
            }
            
        }

        double dikmeBoy;
        double dikmeTutar;
        double dikmeHesapla()
        {
            if(boy >=350)
            {
                dikmeBoy = boy - 35;
                int id = 11;
                var deger = db.TBLURUN.Find(id);
                dikmeTutar = ((dikmeBoy / 100) * Convert.ToDouble(deger.SATISFIYAT)) * 2;
                alisFiyat += ((dikmeBoy / 100) * Convert.ToDouble(deger.ALISFIYAT)) * 2;
                return dikmeBoy;
            }
            else
            {
                dikmeBoy = boy - 30;
                int id = 11;
                var deger = db.TBLURUN.Find(id);
                dikmeTutar = ((dikmeBoy / 100) * Convert.ToDouble(deger.SATISFIYAT)) * 2;
                alisFiyat += ((dikmeBoy / 100) * Convert.ToDouble(deger.ALISFIYAT)) * 2;
                return dikmeBoy;
            }
        }

        int lDavlumbazSecim;
        double lDavlumbazTutar;
        int davlumbazSecimiL(int boy)
        {
            if (boy <= 340)
            {
                lDavlumbazSecim = 30;
                int id = 16;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                lDavlumbazTutar = enn * Convert.ToDouble(satisFiyat);
                alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
                return 30;
            }
            else if(boy >340 && boy <= 450)
            {
                lDavlumbazSecim = 35;
                int id = 17;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                lDavlumbazTutar = enn * Convert.ToDouble(satisFiyat);
                alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
                return 35;
            }
            else
            {
                lDavlumbazSecim = 40;
                int id = 18;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                lDavlumbazTutar = enn * Convert.ToDouble(satisFiyat);
                alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
                return 40;
            }
        }

        int uDavlumbazSecim;
        double uDavlumbazTutar;
        int davlumbazSecimiU(int boy)
        {
            if (boy <= 340)
            {
                uDavlumbazSecim = 30;
                int id = 13;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                uDavlumbazTutar = enn * Convert.ToDouble(satisFiyat);
                alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
                return 30;
            }
            else if (boy > 340 && boy <= 450)
            {
                uDavlumbazSecim = 35;
                int id = 14;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                uDavlumbazTutar = enn * Convert.ToDouble(satisFiyat);
                alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
                return 35;
            }
            else
            {
                uDavlumbazSecim = 40;
                int id = 15;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                uDavlumbazTutar = enn * Convert.ToDouble(satisFiyat);
                alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
                return 40;
            }
        }

        int yanKapakSecim;
        double yanKapakTutar;
        int yanKapak(int boy)
        {
            if (boy <=340)
            {
                yanKapakSecim = 30;
                int id = 19;
                var deger = db.TBLURUN.Find(id);
                yanKapakTutar = double.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return 30;
            }
            else if(boy >340 && boy <= 450)
            {
                yanKapakSecim = 35;
                int id = 20;
                var deger = db.TBLURUN.Find(id);
                yanKapakTutar = double.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return 35;
            }
            else 
            {
                yanKapakSecim = 40;
                int id = 21;
                var deger = db.TBLURUN.Find(id);
                yanKapakTutar = double.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
                return 40;
            }
           
            
        }
    
        int boruSecim;
        double boruTutar;
        double boruBasiRulmanTutar;
        double boruUzunluk;
        int boru(int profil)
        {
            
            if (profil == 1)
            {
                boruUzunluk = en - 1.5;
            }
            else if (profil == 2)
            {
                boruUzunluk = en - 7.5;
            }
            
            if (boruUzunluk < 450)
            {
                boruSecim = 70;
                int id = 23;
                var deger = db.TBLURUN.Find(id);
                boruTutar = double.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());

                int idR = 25;
                var degerR = db.TBLURUN.Find(idR);
                boruBasiRulmanTutar = double.Parse(degerR.SATISFIYAT.ToString());
                alisFiyat += double.Parse(degerR.ALISFIYAT.ToString());
                return 70;
            }
            else
            {
                boruSecim = 102;
                int id = 24;
                var deger = db.TBLURUN.Find(id);
                boruTutar = double.Parse(deger.SATISFIYAT.ToString());
                alisFiyat += double.Parse(deger.ALISFIYAT.ToString());

                int idR = 26;
                var degerR = db.TBLURUN.Find(idR);
                boruBasiRulmanTutar = double.Parse(degerR.SATISFIYAT.ToString());
                alisFiyat += double.Parse(degerR.ALISFIYAT.ToString());
                return 102;
            }
        }

        int altBazaSecim;
        double altBazaTutar;
        int altBaza(int profil)
        {
            if (profil == 1)
            {
                altBazaSecim = en - 4;
            }
            else if(profil == 2)
            {
                altBazaSecim = en - 10;
            }
            
            int id = 27;

            var deger = db.TBLURUN.Find(id);
            var satisFiyat = deger.SATISFIYAT;
            double enn = Convert.ToDouble(altBazaSecim) / 100;
            altBazaTutar = enn * Convert.ToDouble(satisFiyat);
            alisFiyat += enn * Convert.ToDouble(deger.ALISFIYAT.ToString());
            return altBazaSecim;
        }


        double dikmeFitilTutar;
        double dikmeFitili()
        {
            int id = 28;

            var deger = db.TBLURUN.Find(id);
            var satisFiyat = deger.SATISFIYAT;
            double boy = Convert.ToDouble(dikmeBoy) / 100;
            dikmeFitilTutar = (boy * Convert.ToDouble(satisFiyat)) * 4;
            alisFiyat += (boy * Convert.ToDouble(deger.ALISFIYAT.ToString())) * 4;
            return dikmeBoy;
        }

        int tapaSecim;
        double tapaTutar;
        int tapaHesap(int boy)
        {
            tapaSecim = lamelSayisi;
            int id = 31;
            var deger = db.TBLURUN.Find(id);
            tapaTutar = Convert.ToDouble(deger.SATISFIYAT * tapaSecim);
            alisFiyat += Convert.ToDouble(deger.ALISFIYAT * tapaSecim);
            return tapaSecim;
        }

        int percinSecim;
        double percinTutar;
        int percinHesap(int boy)
        {
            percinSecim = tapaSecim*2;

            int id = 32;
            var deger = db.TBLURUN.Find(id);
            percinTutar = Convert.ToDouble(deger.SATISFIYAT * percinSecim);
            alisFiyat += Convert.ToDouble(deger.ALISFIYAT * percinSecim);

            return percinSecim;
        }

        double uSacTutar;
        void uSac()
        {
            int id = 29;

            var deger = db.TBLURUN.Find(id);
            uSacTutar = double.Parse(deger.SATISFIYAT.ToString());
            alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
        }

        double profilTutar;
        void boydanProfil()
        {
            int id = 30;

            var deger = db.TBLURUN.Find(id);
            profilTutar = double.Parse(deger.SATISFIYAT.ToString());
            alisFiyat += double.Parse(deger.ALISFIYAT.ToString());
        }


        void motorKayit(int idM)
        {


            if (motorSecim != 0)
            {
                int id = motorSecim;
                
                var deger = db.TBLURUN.Find(id);


                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = deger.SATISFIYAT;
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
               
            }
            

            
        }
    
        void kumandaKayit(int idM)
        {
            
                int id = 10;
                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;

                
                

                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = deger.SATISFIYAT;
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
               
            }
        
        void dikmeKayit(int idM)
        {
            
            int id = 11;

            var deger = db.TBLURUN.Find(id);
            var satisFiyat = deger.SATISFIYAT;
            var tutar = ((dikmeBoy / 100) * Convert.ToDouble(satisFiyat))*2;

            
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = "2";
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = Convert.ToDecimal(tutar);
            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
           
        }
    
        void lamelKayit(int idM)
        {
            int id = 12;
            var deger = db.TBLURUN.Find(id);
           

            
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = lamelSayisi.ToString();
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = Convert.ToDecimal(lamelTutar);
            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
           
        }    
    
        void davlumbazKayitL(int en, int idM)
        {
            if (lDavlumbazSecim == 30)
            {
                
                int id = 16;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                double tutar =  enn * Convert.ToDouble(satisFiyat);
               

                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = Convert.ToDecimal(tutar);
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
               
            }
            else if (lDavlumbazSecim == 35)
            {
                int id = 17;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                double tutar = enn * Convert.ToDouble(satisFiyat);
                

                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = Convert.ToDecimal(tutar);
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
                
            }
            else if (lDavlumbazSecim == 40)
            {
                int id = 18;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                double tutar = enn * Convert.ToDouble(satisFiyat);


                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = Convert.ToDecimal(tutar);
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();

            }
        }

        void davlumbazKayitU(int en, int idM)
        {
            if (uDavlumbazSecim == 30)
            {

                int id = 13;

                var deger = db.TBLURUN.Find(id);          
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                double tutar = enn * Convert.ToDouble(satisFiyat);
              

                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = Convert.ToDecimal(tutar);
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
                
            }
            else if (uDavlumbazSecim == 35)
            {
                int id = 14;

                var deger = db.TBLURUN.Find(id);               
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                double tutar = enn * Convert.ToDouble(satisFiyat);
                

                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = Convert.ToDecimal(tutar);
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
                
            }
            else if (uDavlumbazSecim == 40)
            {
                int id = 15;

                var deger = db.TBLURUN.Find(id);
                var satisFiyat = deger.SATISFIYAT;
                double enn = Convert.ToDouble(en) / 100;
                double tutar = enn * Convert.ToDouble(satisFiyat);


                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = Convert.ToDecimal(tutar);
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();

            }
        }
    
        void yanKapakKayit(int idM)
        {
            switch (yanKapakSecim)
            {
                case 30:
                    int id = 19;

                    var deger = db.TBLURUN.Find(id);                
                    TBLFATURADETAY t = new TBLFATURADETAY();
                    t.URUNKODU = deger.URUNKODU;
                    t.ACIKLAMA = deger.AD;
                    t.RENK = "";
                    t.MİKTAR = "1";
                    t.BIRIM = deger.BIRIM;
                    t.BIRIMFIYAT = deger.SATISFIYAT;
                    t.TUTAR = deger.SATISFIYAT;
                    t.FATURAID = idM;
                    db.TBLFATURADETAY.Add(t);
                    db.SaveChanges();                  
                    break;

                case 35:
                    int id18 = 20;

                    var deger18 = db.TBLURUN.Find(id18);
                    TBLFATURADETAY t18 = new TBLFATURADETAY();
                    t18.URUNKODU = deger18.URUNKODU;
                    t18.ACIKLAMA = deger18.AD;
                    t18.RENK = "";
                    t18.MİKTAR = "1";
                    t18.BIRIM = deger18.BIRIM;
                    t18.BIRIMFIYAT = deger18.SATISFIYAT;
                    t18.TUTAR = deger18.SATISFIYAT;
                    t18.FATURAID = idM;
                    db.TBLFATURADETAY.Add(t18);
                    db.SaveChanges();
                    break;

                case 40:
                    int id19 = 21;

                    var deger19 = db.TBLURUN.Find(id19);
                    TBLFATURADETAY t19 = new TBLFATURADETAY();
                    t19.URUNKODU = deger19.URUNKODU;
                    t19.ACIKLAMA = deger19.AD;
                    t19.RENK = "";
                    t19.MİKTAR = "1";
                    t19.BIRIM = deger19.BIRIM;
                    t19.BIRIMFIYAT = deger19.SATISFIYAT;
                    t19.TUTAR = deger19.SATISFIYAT;
                    t19.FATURAID = idM;
                    db.TBLFATURADETAY.Add(t19);
                    db.SaveChanges();
                    break;

            }
        }
    
        void boruKayit(int idM)
        {
            if (boruSecim == 70)
            {
                int id = 23;

                var deger = db.TBLURUN.Find(id);
                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = deger.SATISFIYAT;
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
            }
            else if (boruSecim == 102)
            {
                int id = 24;

                var deger = db.TBLURUN.Find(id);
                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = deger.SATISFIYAT;
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
            }
        }
    
        void boruBasiRulmanKayit(int idM)
        {
            if (boruSecim == 70)
            {
                int id = 25;

                var deger = db.TBLURUN.Find(id);
                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = deger.SATISFIYAT;
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
            }
            else if (boruSecim == 102)
            {
                int id = 26;

                var deger = db.TBLURUN.Find(id);
                TBLFATURADETAY t = new TBLFATURADETAY();
                t.URUNKODU = deger.URUNKODU;
                t.ACIKLAMA = deger.AD;
                t.RENK = "";
                t.MİKTAR = "1";
                t.BIRIM = deger.BIRIM;
                t.BIRIMFIYAT = deger.SATISFIYAT;
                t.TUTAR = deger.SATISFIYAT;
                t.FATURAID = idM;
                db.TBLFATURADETAY.Add(t);
                db.SaveChanges();
            }
        }
    
        void altBazaKayit(int idM)
        {
            int id = 27;

            var deger = db.TBLURUN.Find(id);
            var satisFiyat = deger.SATISFIYAT;
            double enn = Convert.ToDouble(altBazaSecim) / 100;
            double tutar = enn * Convert.ToDouble(satisFiyat);


            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = "1";
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = Convert.ToDecimal(tutar);
            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
           
        }
    
        void dikmeFitilKayit(int idM)
        {
            int id = 28;

            var deger = db.TBLURUN.Find(id);
            var satisFiyat = deger.SATISFIYAT;
            double boy = Convert.ToDouble(dikmeBoy) / 100;
            double tutar = (boy * Convert.ToDouble(satisFiyat))*4;


            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = "1";
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = Convert.ToDecimal(tutar);
            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
        }
    
        void uSacKayit(int idM)
        {
            int id = 29;

            var deger = db.TBLURUN.Find(id);
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = "1";
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = deger.SATISFIYAT;
            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
        }


        void profilKayit(int idM)
        {
            int id = 30;

            var deger = db.TBLURUN.Find(id);
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = "1";
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = deger.SATISFIYAT;
            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
        }

     
        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            Raporlar.XtraReport2 xtraReport2 = new Raporlar.XtraReport2();

            xtraReport2.init(gridView2);
            xtraReport2.not(textEditNot.Text);
            
            Formlar.FrmPrint frmPrint = new Formlar.FrmPrint();
            frmPrint.initPdf2(xtraReport2, "dd");
            frmPrint.Show();
        }

        void tapaKayit(int idM)
        {
            int id = 31;

            var deger = db.TBLURUN.Find(id);
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = tapaSecim.ToString();
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = deger.SATISFIYAT * tapaSecim;

            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
        }


        void percinKayit(int idM)
        {
            int id = 32;

            var deger = db.TBLURUN.Find(id);
            TBLFATURADETAY t = new TBLFATURADETAY();
            t.URUNKODU = deger.URUNKODU;
            t.ACIKLAMA = deger.AD;
            t.RENK = "";
            t.MİKTAR = percinSecim.ToString();
            t.BIRIM = deger.BIRIM;
            t.BIRIMFIYAT = deger.SATISFIYAT;
            t.TUTAR = deger.SATISFIYAT * percinSecim;

            t.FATURAID = idM;
            db.TBLFATURADETAY.Add(t);
            db.SaveChanges();
        }
    }
}
