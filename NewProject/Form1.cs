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
using System.Data.Sql;

namespace NewProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string baglantiCumlesi = "Data Source=OnurComp;Initial Catalog=bankData;Integrated Security=True";
        SqlConnection baglanti = new SqlConnection(baglantiCumlesi);
        //int i = 1;
        int gelenPara;
        int gidenPara;
        string secilenTarih;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        { 
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM kullaniciTablosu where kullaniciAdi='" + textBox1.Text + "' AND kullaniciSifresi='" + textBox2.Text + "'";
            SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giris Yapildi");
                    tabControl1.TabPages.Add(tabPage2);
                    tabControl1.SelectedTab = tabPage2;
                    tabControl1.TabPages.Remove(tabPage1);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Yanlis Kullanici Adi veya Sifre\nLutfen Tekrar Deneyiniz..");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            dr.Close();
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.TabPages.Remove(tabPage9);
            tabControl1.TabPages.Remove(tabPage10);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "insert into kullaniciTablosu(kullaniciAdi,kullaniciSifresi) values (@ad,@sifre)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ad", textBox4.Text);
            komut.Parameters.AddWithValue("@sifre", textBox3.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Yeni Admin Kaydi Yapildi");
            textBox4.Text = "";
            textBox3.Text = "";
            baglanti.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectedTab = tabPage3;
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectedTab = tabPage4;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string ad = this.textBox11.Text;
            string sil = "DELETE from kullaniciTablosu where kullaniciAdi='" + ad + "'";
            SqlDataAdapter adp = new SqlDataAdapter(sil,baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            MessageBox.Show(ad + "İsimli kullanici silindi");
            baglanti.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectedTab = tabPage1;
            tabControl1.TabPages.Remove(tabPage4);
            groupBox2.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectedTab = tabPage4;
            tabControl1.TabPages.Remove(tabPage1);
            groupBox3.Visible = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string kadi;
            int sifre = 0;
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sorgu="select * from kullaniciTablosu where kullaniciAdi='"+textBox13.Text+"'";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Connection = baglanti;
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (textBox12.Text==textBox14.Text)
                {
                    string guncelle = "update kullaniciTablosu set kullaniciSifresi=@sifre";
                    SqlCommand guncelleKomut = new SqlCommand(guncelle, baglanti);
                    guncelleKomut.Parameters.AddWithValue("@sifre", Convert.ToInt32(textBox12.Text));
                    dr.Close();
                    guncelleKomut.ExecuteNonQuery();
                    MessageBox.Show("Sifre Basariyla Degistirildi");
                }
                else
                {
                    MessageBox.Show("Sifre Eslesmesi Yanlis\nTekrar Deneyiniz..");
                }
            }
            else
            {
                MessageBox.Show("Lutfen Dogru Bir Kullanici Adi Giriniz..");
            }
            baglanti.Close();
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectedTab = tabPage1;
            tabControl1.TabPages.Remove(tabPage4);
            groupBox3.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "insert into musterilerTablosu(musteriNo,musteriAdi,musteriSoyadi,Adres,Telefon,email) values (@no,@ad,@soyad,@adres,@telefon,@email)";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@no", textBox7.Text);
            komut.Parameters.AddWithValue("@ad", textBox6.Text);
            komut.Parameters.AddWithValue("@soyad", textBox15.Text);
            komut.Parameters.AddWithValue("@adres", textBox8.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.Parameters.AddWithValue("@email", textBox9.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Yeni musteri Kaydi Yapildi");
            textBox7.Text = "";
            textBox6.Text = "";
            textBox15.Text = "";
            textBox8.Text = "";
            textBox5.Text = "";
            textBox9.Text = "";
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectedTab = tabPage5;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectedTab = tabPage5;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int kbakiye = 0;
            int mBakiye = 0;
            int ekHesap = 0;
            int cekilen = Convert.ToInt32(textBox17.Text);
            DateTime tarih = DateTime.Now;
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM hesaplarTablosu where hesapNo='" + textBox16.Text +"'";
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                mBakiye=Convert.ToInt32(dr[3]);
                ekHesap = Convert.ToInt32(dr[2]);
                kbakiye = Convert.ToInt32(dr[4]);
            }
            dr.Close();
            if (comboBox1.Text=="PARA CEK")
            {
                if ((mBakiye+ekHesap)>=Convert.ToInt32(textBox17.Text))
                {
                    if (750>= Convert.ToInt32(textBox17.Text))
                    {
                        string sorgu = "Update hesaplarTablosu Set bakiye=(bakiye-@cekilen),kullanilabilirBakiye=(kullanilabilirBakiye-@cekilen) where hesapNo=@hesapNo";
                        string kayit = "insert into islemlerTablosu(hesapNo,islemTuru,miktar,tarih)values (@hesap,@islem,@miktar,@tarih)";
                        string hesapOzet = "insert into hesapOzetiTablosu(hesapNumarasi,islemTuru,miktar,tarih)values (@hnumara,@islTuru,@cek_miktar,@cek_tarih)";
                        SqlCommand ozetKomut = new SqlCommand(hesapOzet, baglanti);
                        SqlCommand kayitKomut = new SqlCommand(kayit, baglanti);    //islemler tablosuna verileri ekledim..
                        SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                        cmd.Parameters.AddWithValue("@cekilen", cekilen);
                        cmd.Parameters.AddWithValue("@hesapNo", Convert.ToInt32(textBox16.Text));
                        kayitKomut.Parameters.AddWithValue("@hesap", Convert.ToInt32(textBox16.Text));
                        kayitKomut.Parameters.AddWithValue("@islem", 2);
                        kayitKomut.Parameters.AddWithValue("@miktar", cekilen);
                        kayitKomut.Parameters.AddWithValue("@tarih", tarih);
                        ozetKomut.Parameters.AddWithValue("@hnumara", Convert.ToInt32(textBox16.Text));
                        ozetKomut.Parameters.AddWithValue("@islTuru", "PARA CEKME");
                        ozetKomut.Parameters.AddWithValue("@cek_miktar", cekilen);
                        ozetKomut.Parameters.AddWithValue("@cek_tarih", tarih);
                        cmd.ExecuteNonQuery();
                        kayitKomut.ExecuteNonQuery();
                        ozetKomut.ExecuteNonQuery();
                        MessageBox.Show("Isleminiz Basariyla Gerceklesti");
                        gidenPara += cekilen;
                    }
                    else
                    {
                        MessageBox.Show("Gunluk Para Cekim Limitine Ulastiniz..");
                    }
                }
                else
                {
                    MessageBox.Show("Yeterli Bakiyeniz Bulunmamaktadir..\nŞuanki Bakiyeniz :" + mBakiye.ToString());
                }
            }
            else if (comboBox1.Text=="PARA YATIR")
            {
                string sorgu = "Update hesaplarTablosu Set bakiye=(bakiye+@cekilen),kullanilabilirBakiye=(kullanilabilirBakiye+@cekilen) where hesapNo=@hesapNo";
                string kayit = "insert into islemlerTablosu(hesapNo,islemTuru,miktar,tarih)values (@hesap,@islem,@miktar,@tarih)";
                string hesapOzet = "insert into hesapOzetiTablosu(hesapNumarasi,islemTuru,miktar,tarih)values (@hnumara,@islTuru,@cek_miktar,@cek_tarih)";
                SqlCommand kayitKomut = new SqlCommand(kayit, baglanti);
                SqlCommand ozetKomut = new SqlCommand(hesapOzet, baglanti);
                SqlCommand cmd = new SqlCommand(sorgu, baglanti);
                cmd.Parameters.AddWithValue("@cekilen", cekilen);
                cmd.Parameters.AddWithValue("@hesapNo", Convert.ToInt32(textBox16.Text));
                kayitKomut.Parameters.AddWithValue("@hesap", Convert.ToInt32(textBox16.Text));
                kayitKomut.Parameters.AddWithValue("@islem", 1);
                kayitKomut.Parameters.AddWithValue("@miktar", cekilen);
                kayitKomut.Parameters.AddWithValue("@tarih", tarih);
                ozetKomut.Parameters.AddWithValue("@hnumara", Convert.ToInt32(textBox16.Text));
                ozetKomut.Parameters.AddWithValue("@islTuru", "PARA YATIRMA");
                ozetKomut.Parameters.AddWithValue("@cek_miktar", cekilen);
                ozetKomut.Parameters.AddWithValue("@cek_tarih", tarih);
                ozetKomut.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                kayitKomut.ExecuteNonQuery();
                MessageBox.Show("Isleminiz Basariyla Gerceklesti");
                gelenPara += cekilen;
            }
            baglanti.Close();
            textBox16.Text = "";
            textBox17.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectedTab = tabPage6;
            tabControl1.TabPages.Remove(tabPage2);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM musterilerTablosu where musteriNo='" + textBox20.Text + "'";
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                string kayit = "insert into hesaplarTablosu(musteriNo,ekHesap,bakiye,kullanilabilirBakiye) values (@no,@ekHesap,@bakiye,@kbakiye)";
                SqlCommand cmd = new SqlCommand(kayit, baglanti);
                int bakiye1 = Convert.ToInt32(textBox19.Text);
                int bakiye2 = Convert.ToInt32(textBox18.Text);
                int tbakiye = bakiye1 + bakiye2;
                cmd.Parameters.AddWithValue("@no", textBox20.Text);
                cmd.Parameters.AddWithValue("@ekHesap", textBox18.Text);
                cmd.Parameters.AddWithValue("@bakiye", textBox19.Text);
                cmd.Parameters.AddWithValue("@kbakiye", Convert.ToString(tbakiye));
                cmd.Parameters.AddWithValue("@telefon", textBox5.Text);
                dr.Close();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Musteri Hesabi Acildi");
            }
            else
            {
                MessageBox.Show("Bir Hata Olustu.Bilgileri Tekrar giriniz");
            }
            baglanti.Close();
            textBox20.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.SelectedTab = tabPage2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectedTab = tabPage5;
            groupBox4.Visible = true;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            DateTime tarih = DateTime.Now;
            int gBakiye=0, aBakiye=0;
            int ghesapNo=0,ahesapNo=0;
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM hesaplarTablosu where hesapNo='" + textBox21.Text + "'";
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                gBakiye = Convert.ToInt32(dr[3]);
                ghesapNo = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandText= "SELECT * FROM hesaplarTablosu where hesapNo='" + textBox22.Text + "'";
            SqlDataReader datar = cmd.ExecuteReader();
            while (datar.Read())
            {
                aBakiye = Convert.ToInt32(datar[3]);
                ahesapNo = Convert.ToInt32(datar[0]);
            }
            datar.Close();
            if (textBox21.Text==textBox22.Text)
            {
                MessageBox.Show("Ayni Hesaba Aktarim Yapamazsiniz..");
            }
            else
            {
                string havale = "insert into havaleTablosu(gonderenHesap,alanHesap,tarih)values(@gHesap,@aHesap,@tarih)";
                string havaleOzet = "insert into havaleOzetTablosu(gonderenHesapNo,alanHesapNo,miktar,tarih)values (@gHesapNo,@aHesapNo,@havaleTarih)";
                SqlCommand comd = new SqlCommand(havale, baglanti);
                SqlCommand ozetKomut = new SqlCommand(havaleOzet, baglanti);
                comd.Parameters.Add("@gHesap", Convert.ToInt32(textBox21.Text));
                comd.Parameters.Add("@aHesap", Convert.ToInt32(textBox22.Text));
                comd.Parameters.Add("@tarih", tarih);
                ozetKomut.Parameters.Add("@gHesapNo", Convert.ToInt32(textBox21.Text));
                ozetKomut.Parameters.Add("@aHesapNo", Convert.ToInt32(textBox22.Text));
                ozetKomut.Parameters.Add("@havaleTarih", tarih);
                ozetKomut.ExecuteNonQuery();
                comd.ExecuteNonQuery();
                MessageBox.Show("Havale Islemi Tamamlandi..");
            }
            while (true)
            {
                    string gonderenKayit = "update hesaplarTablosu set bakiye=(bakiye-@giden),kullanilabilirBakiye=(kullanilabilirBakiye-@giden) where hesapNo=@hesapNo";
                    SqlCommand gonKomut = new SqlCommand (gonderenKayit, baglanti);
                    gonKomut.Parameters.AddWithValue("@hesapNo", ghesapNo);
                    gonKomut.Parameters.AddWithValue("@giden", Convert.ToInt32(textBox23.Text));
                    gonKomut.ExecuteNonQuery();

                    string alanKayit = "update hesaplarTablosu set bakiye=(bakiye+@alan),kullanilabilirBakiye=(kullanilabilirBakiye+@alan) where hesapNo=@hesapNo";
                    SqlCommand alanKomut = new SqlCommand(alanKayit, baglanti);
                    alanKomut.Parameters.AddWithValue("@hesapNo", ahesapNo);
                    alanKomut.Parameters.AddWithValue("@alan", Convert.ToInt32(textBox23.Text));
                    alanKomut.ExecuteNonQuery();
                break;
            }
            baglanti.Close();
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.TabPages.Remove(tabPage5);
            groupBox4.Visible = false;
            tabControl1.SelectedTab = tabPage2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage7);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectedTab = tabPage7;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            //string tarih = dateTimePicker1.Text;
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string kayit = "SELECT * from islemlerTablosu where tarih='"+ dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'";
            SqlCommand komut = new SqlCommand(kayit,baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable tablo = new DataTable();
            //while (dr.Read())
            //{
               // secilenTarih = Convert.ToString((dr[4]));
            //}

            //if (tarih==secilenTarih)
            //{
                tablo.Load(dr);
                dataGridView1.DataSource = tablo;
            //}
            dr.Close();
            baglanti.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.TabPages.Remove(tabPage7);
            tabControl1.SelectedTab = tabPage2;
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sorgu = "select * from hesapOzetiTablosu where tarih>='" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and tarih<='" + dateTimePicker3.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable tablo = new DataTable();
            tablo.Load(dr);
            dataGridView2.DataSource=tablo;
            //SqlDataAdapter adaptor = new SqlDataAdapter("select * from hesapOzetiTablosu where tarih>='" + dateTimePicker2.Text + "' and tarih<='" + dateTimePicker3.Text + "'", baglanti);
            //SqlDataAdapter adaptor2 = new SqlDataAdapter("select * from havaleOzetiTablosu where tarih>='" + dateTimePicker2.Text + "' and tarih<='" + dateTimePicker3.Text + "'", baglanti);
            //DataTable tablo = new DataTable();
            //adaptor.Fill(tablo);
            //adaptor2.Fill(tablo);
            //dataGridView2.DataSource = tablo;
            //dataGridView3.DataSource = tablo;
            dr.Close();

            string sorgu2 = "select * from havaleOzetiTablosu where tarih>='" + dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm") + "' and tarih<='" + dateTimePicker3.Value.Date.ToString("yyyy-MM-dd HH:mm") + "'";
            SqlCommand cmd = new SqlCommand(sorgu2, baglanti);
            SqlDataReader datar = cmd.ExecuteReader();
            DataTable tablo2 = new DataTable();
            tablo2.Load(datar);
            dataGridView3.DataSource = tablo2;

            datar.Close();
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage8);
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.SelectedTab = tabPage8;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.TabPages.Remove(tabPage8);
            tabControl1.SelectedTab = tabPage2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage9);
            tabControl1.SelectedTab = tabPage9;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            int bakiye=0;
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sorgu="select * from hesaplarTablosu where hesapNo='"+textBox25.Text+"'";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                bakiye=Convert.ToInt32(dr[3]);
            }
            if (bakiye!=0)
            {
                MessageBox.Show("Hesabinizdaki Tum Parayi Cekiniz\nSuanki bakiyeniz :" + bakiye+"TL");
            }
            else
            {
                string hesap = this.textBox25.Text;
                string sil = "DELETE from kullaniciTablosu where kullaniciAdi='" + hesap + "'";
                SqlDataAdapter adp = new SqlDataAdapter(sil, baglanti);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                MessageBox.Show(hesap + "Numarali Hesap silindi");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage10);
            tabControl1.SelectedTab = tabPage10;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            int musteri = 0;
            int musNo = Convert.ToInt32(textBox29.Text);
            string guncel = "SELECT * from musterilerTablosu where musteriNo='" + textBox29.Text + "'";
            string sorgu = "update musterilerTablosu set musteriAdi=@yeniAd,musteriSoyadi=@yeniSoyad,Adres=@yeniAdres,Telefon=@yeniTel,email=@yeniEmail where musteriNo=@musteriNumara";
            SqlCommand cmd = new SqlCommand(guncel, baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                musteri = Convert.ToInt32(dr[0]);
            }
            dr.Close();
            //if (musteri==musNo)
            //{
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@musteriNumara", musNo);
                komut.Parameters.AddWithValue("@yeniAd", Convert.ToString(textBox31.Text));
                komut.Parameters.AddWithValue("@yeniSoyad", Convert.ToString(textBox26.Text));
                komut.Parameters.AddWithValue("@yeniAdres", Convert.ToString(textBox28.Text));
                komut.Parameters.AddWithValue("@yeniTel", Convert.ToDecimal(textBox30.Text));
                komut.Parameters.AddWithValue("@yeniEmail", Convert.ToString(textBox27.Text));
                komut.ExecuteNonQuery();
                MessageBox.Show("Musteri Kaydi Guncellendi");
            //}
            baglanti.Close();

        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }
            string sorgu = "SELECT * from musterilerTablosu where musteriNo='" + textBox29.Text + "'";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                groupBox5.Visible = true;
            }
            else
            {
                MessageBox.Show("Yanlis bir Musteri Numarasi girdiniz\nTekrar Deneyiniz");
            }
            dr.Close();
            baglanti.Close();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            textBox29.Text = "";
            textBox26.Text = "";
            textBox31.Text = "";
            textBox30.Text = "";
            textBox27.Text = "";

        }

        private void button37_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            tabControl1.TabPages.Remove(tabPage10);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectedTab = tabPage2;
        }
    }
}
