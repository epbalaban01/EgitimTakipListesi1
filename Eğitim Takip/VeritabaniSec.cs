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
using System.Data.OleDb;

namespace Eğitim_Takip
{
    public partial class VeritabaniSec : Form
    {
        SqlConnection baglanti = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
        OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");

        SqlConnection baglanti2 = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));

        public string a, b, c, d, f, g, h, j;

        public VeritabaniSec()
        {
            InitializeComponent();
        }


       


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (a == "" || b == "" || c == "" || d == "" || f == "" || g == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayın", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (label6.Text == "GAİB")
                    {
                        try
                        {
                            if (sqlsecili.Checked == true)
                            {
                                baglanti2.Open();
                                SqlCommand tekrar = new SqlCommand("select count(*) from gaib where egitim_adi='" + a + "'", baglanti2);
                                int sonuc = (int)tekrar.ExecuteScalar();
                                if (sonuc == 0)
                                {
                                    /*SQL'A KAYDET */
                                    baglanti.Open();
                                    SqlCommand kayit = new SqlCommand("insert into gaib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                    kayit.Parameters.AddWithValue("@egitim_adi", a);
                                    kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                    kayit.Parameters.AddWithValue("@zoom_id", c);
                                    kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                    kayit.Parameters.AddWithValue("@zoom_link", f);
                                    kayit.Parameters.AddWithValue("@saat", g);
                                    kayit.Parameters.AddWithValue("@katildi_mi", h);
                                    kayit.ExecuteNonQuery();
                                    MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kayit.Dispose();
                                    baglanti.Close();
                                    /*SQL'A KAYDET */
                                }
                                if (sonuc > 0)
                                {
                                    MessageBox.Show("Zaten bu kayıt veritabanın da mevcut", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                baglanti2.Close();
                                this.Close();        
                            }
                            else if (accesssecili.Checked == true)
                            {
                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into gaib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else if (hepsisecili.Checked == true)
                            {

                                /*SQL'A KAYDET */
                                baglanti.Open();
                                SqlCommand kayit = new SqlCommand("insert into gaib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                kayit.Parameters.AddWithValue("@egitim_adi", a);
                                kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit.Parameters.AddWithValue("@zoom_id", c);
                                kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit.Parameters.AddWithValue("@zoom_link", f);
                                kayit.Parameters.AddWithValue("@saat", g);
                                kayit.Parameters.AddWithValue("@katildi_mi", h);
                                kayit.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit.Dispose();
                                baglanti.Close();
                                /*SQL'A KAYDET */

                                /////////****************************************************************************////////

                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into gaib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen birini seçiniz!!", "Veritabanı Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                    }
                    else if(label6.Text == "İMMİB Akademi")
                    {
                        try
                        {
                            if (sqlsecili.Checked == true)
                            {
                                baglanti2.Open();
                                SqlCommand tekrar = new SqlCommand("select count(*) from immib where egitim_adi='" + a + "'", baglanti2);
                                int sonuc = (int)tekrar.ExecuteScalar();
                                if (sonuc == 0)
                                {
                                    /*SQL'A KAYDET */
                                    baglanti.Open();
                                    SqlCommand kayit = new SqlCommand("insert into immib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                    kayit.Parameters.AddWithValue("@egitim_adi", a);
                                    kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                    kayit.Parameters.AddWithValue("@zoom_id", c);
                                    kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                    kayit.Parameters.AddWithValue("@zoom_link", f);
                                    kayit.Parameters.AddWithValue("@saat", g);
                                    kayit.Parameters.AddWithValue("@katildi_mi", h);
                                    kayit.ExecuteNonQuery();
                                    MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kayit.Dispose();
                                    baglanti.Close();
                                    /*SQL'A KAYDET */
                                }
                                if (sonuc > 0)
                                {
                                    MessageBox.Show("Zaten bu kayıt veritabanın da mevcut", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                baglanti2.Close();
                                this.Close();
                            }
                            else if (accesssecili.Checked == true)
                            {
                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into immib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else if (hepsisecili.Checked == true)
                            {

                                /*SQL'A KAYDET */
                                baglanti.Open();
                                SqlCommand kayit = new SqlCommand("insert into immib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                kayit.Parameters.AddWithValue("@egitim_adi", a);
                                kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit.Parameters.AddWithValue("@zoom_id", c);
                                kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit.Parameters.AddWithValue("@zoom_link", f);
                                kayit.Parameters.AddWithValue("@saat", g);
                                kayit.Parameters.AddWithValue("@katildi_mi", h);
                                kayit.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit.Dispose();
                                baglanti.Close();
                                /*SQL'A KAYDET */

                                /////////****************************************************************************////////

                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into immib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen birini seçiniz!!", "Veritabanı Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle1();
                    }
                    else if (label6.Text == "ISO Akademi")
                    {
                        try
                        {
                            if (sqlsecili.Checked == true)
                            {
                                baglanti2.Open();
                                SqlCommand tekrar = new SqlCommand("select count(*) from iso where egitim_adi='" + a + "'", baglanti2);
                                int sonuc = (int)tekrar.ExecuteScalar();
                                if (sonuc == 0)
                                {
                                    /*SQL'A KAYDET */
                                    baglanti.Open();
                                    SqlCommand kayit = new SqlCommand("insert into iso ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                    kayit.Parameters.AddWithValue("@egitim_adi", a);
                                    kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                    kayit.Parameters.AddWithValue("@zoom_id", c);
                                    kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                    kayit.Parameters.AddWithValue("@zoom_link", f);
                                    kayit.Parameters.AddWithValue("@saat", g);
                                    kayit.Parameters.AddWithValue("@katildi_mi", h);
                                    kayit.ExecuteNonQuery();
                                    MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kayit.Dispose();
                                    baglanti.Close();
                                    /*SQL'A KAYDET */
                                }
                                if (sonuc > 0)
                                {
                                    MessageBox.Show("Zaten bu kayıt veritabanın da mevcut", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                baglanti2.Close();
                                this.Close();
                            }
                            else if (accesssecili.Checked == true)
                            {
                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into iso ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else if (hepsisecili.Checked == true)
                            {

                                /*SQL'A KAYDET */
                                baglanti.Open();
                                SqlCommand kayit = new SqlCommand("insert into iso ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                kayit.Parameters.AddWithValue("@egitim_adi", a);
                                kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit.Parameters.AddWithValue("@zoom_id", c);
                                kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit.Parameters.AddWithValue("@zoom_link", f);
                                kayit.Parameters.AddWithValue("@saat", g);
                                kayit.Parameters.AddWithValue("@katildi_mi", h);
                                kayit.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit.Dispose();
                                baglanti.Close();
                                /*SQL'A KAYDET */

                                /////////****************************************************************************////////

                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into iso ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen birini seçiniz!!", "Veritabanı Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle2();
                    }
                    else if (label6.Text == "AKBANK Akademi")
                    {
                        try
                        {
                            if (sqlsecili.Checked == true)
                            {
                                baglanti2.Open();
                                SqlCommand tekrar = new SqlCommand("select count(*) from akbank where egitim_adi='" + a + "'", baglanti2);
                                int sonuc = (int)tekrar.ExecuteScalar();
                                if (sonuc == 0)
                                {
                                    /*SQL'A KAYDET */
                                    baglanti.Open();
                                    SqlCommand kayit = new SqlCommand("insert into akbank ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                    kayit.Parameters.AddWithValue("@egitim_adi", a);
                                    kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                    kayit.Parameters.AddWithValue("@zoom_id", c);
                                    kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                    kayit.Parameters.AddWithValue("@zoom_link", f);
                                    kayit.Parameters.AddWithValue("@saat", g);
                                    kayit.Parameters.AddWithValue("@katildi_mi", h);
                                    kayit.ExecuteNonQuery();
                                    MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kayit.Dispose();
                                    baglanti.Close();
                                    /*SQL'A KAYDET */
                                }
                                if (sonuc > 0)
                                {
                                    MessageBox.Show("Zaten bu kayıt veritabanın da mevcut", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                baglanti2.Close();
                                this.Close();
                            }
                            else if (accesssecili.Checked == true)
                            {
                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into akbank ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else if (hepsisecili.Checked == true)
                            {

                                /*SQL'A KAYDET */
                                baglanti.Open();
                                SqlCommand kayit = new SqlCommand("insert into akbank ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                kayit.Parameters.AddWithValue("@egitim_adi", a);
                                kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit.Parameters.AddWithValue("@zoom_id", c);
                                kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit.Parameters.AddWithValue("@zoom_link", f);
                                kayit.Parameters.AddWithValue("@saat", g);
                                kayit.Parameters.AddWithValue("@katildi_mi", h);
                                kayit.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit.Dispose();
                                baglanti.Close();
                                /*SQL'A KAYDET */

                                /////////****************************************************************************////////

                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into akbank ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen birini seçiniz!!", "Veritabanı Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle3();
                    }
                    else if (label6.Text == "Microfon")
                    {
                        try
                        {
                            if (sqlsecili.Checked == true)
                            {
                                baglanti2.Open();
                                SqlCommand tekrar = new SqlCommand("select count(*) from microfon where egitim_adi='" + a + "'", baglanti2);
                                int sonuc = (int)tekrar.ExecuteScalar();
                                if (sonuc == 0)
                                {
                                    /*SQL'A KAYDET */
                                    baglanti.Open();
                                    SqlCommand kayit = new SqlCommand("insert into microfon ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                    kayit.Parameters.AddWithValue("@egitim_adi", a);
                                    kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                    kayit.Parameters.AddWithValue("@zoom_id", c);
                                    kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                    kayit.Parameters.AddWithValue("@zoom_link", f);
                                    kayit.Parameters.AddWithValue("@saat", g);
                                    kayit.Parameters.AddWithValue("@katildi_mi", h);
                                    kayit.ExecuteNonQuery();
                                    MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kayit.Dispose();
                                    baglanti.Close();
                                    /*SQL'A KAYDET */
                                }
                                if (sonuc > 0)
                                {
                                    MessageBox.Show("Zaten bu kayıt veritabanın da mevcut", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                baglanti2.Close();
                                this.Close();
                            }
                            else if (accesssecili.Checked == true)
                            {
                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into microfon ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else if (hepsisecili.Checked == true)
                            {

                                /*SQL'A KAYDET */
                                baglanti.Open();
                                SqlCommand kayit = new SqlCommand("insert into microfon ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                kayit.Parameters.AddWithValue("@egitim_adi", a);
                                kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit.Parameters.AddWithValue("@zoom_id", c);
                                kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit.Parameters.AddWithValue("@zoom_link", f);
                                kayit.Parameters.AddWithValue("@saat", g);
                                kayit.Parameters.AddWithValue("@katildi_mi", h);
                                kayit.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit.Dispose();
                                baglanti.Close();
                                /*SQL'A KAYDET */

                                /////////****************************************************************************////////

                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into microfon ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen birini seçiniz!!", "Veritabanı Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle4();
                    }
                    else if (label6.Text == "Solidworks")
                    {
                        try
                        {
                            if (sqlsecili.Checked == true)
                            {
                                baglanti2.Open();
                                SqlCommand tekrar = new SqlCommand("select count(*) from solidworks where egitim_adi='" + a + "'", baglanti2);
                                int sonuc = (int)tekrar.ExecuteScalar();
                                if (sonuc == 0)
                                {
                                    /*SQL'A KAYDET */
                                    baglanti.Open();
                                    SqlCommand kayit = new SqlCommand("insert into solidworks ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                    kayit.Parameters.AddWithValue("@egitim_adi", a);
                                    kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                    kayit.Parameters.AddWithValue("@zoom_id", c);
                                    kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                    kayit.Parameters.AddWithValue("@zoom_link", f);
                                    kayit.Parameters.AddWithValue("@saat", g);
                                    kayit.Parameters.AddWithValue("@katildi_mi", h);
                                    kayit.ExecuteNonQuery();
                                    MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kayit.Dispose();
                                    baglanti.Close();
                                    /*SQL'A KAYDET */
                                }
                                if (sonuc > 0)
                                {
                                    MessageBox.Show("Zaten bu kayıt veritabanın da mevcut", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                baglanti2.Close();
                                this.Close();
                            }
                            else if (accesssecili.Checked == true)
                            {
                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into solidworks ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else if (hepsisecili.Checked == true)
                            {

                                /*SQL'A KAYDET */
                                baglanti.Open();
                                SqlCommand kayit = new SqlCommand("insert into solidworks ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat],[katildi_mi]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi)", baglanti);
                                kayit.Parameters.AddWithValue("@egitim_adi", a);
                                kayit.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit.Parameters.AddWithValue("@zoom_id", c);
                                kayit.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit.Parameters.AddWithValue("@zoom_link", f);
                                kayit.Parameters.AddWithValue("@saat", g);
                                kayit.Parameters.AddWithValue("@katildi_mi", h);
                                kayit.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit.Dispose();
                                baglanti.Close();
                                /*SQL'A KAYDET */

                                /////////****************************************************************************////////

                                /*VERİTABANINA KAYDET */
                                baglanti1.Open();
                                OleDbCommand kayit1 = new OleDbCommand("insert into solidworks ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti1);
                                kayit1.Parameters.AddWithValue("@egitim_adi", a);
                                kayit1.Parameters.AddWithValue("@egitim_zamani", b);
                                kayit1.Parameters.AddWithValue("@zoom_id", c);
                                kayit1.Parameters.AddWithValue("@zoom_sifre", d);
                                kayit1.Parameters.AddWithValue("@zoom_link", f);
                                kayit1.Parameters.AddWithValue("@saat", g);
                                kayit1.ExecuteNonQuery();
                                MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Access Veritabanı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kayit1.Dispose();
                                baglanti1.Close();
                                /*VERİTABANINA KAYDET*/

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Lütfen birini seçiniz!!", "Veritabanı Seçiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle5();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void VeritabaniSec_Load(object sender, EventArgs e)
        {
          
            textBox1.Text = a;
            textBox2.Text = b;
            textBox3.Text = c;
            textBox4.Text = d;
            textBox5.Text = f;
            textBox6.Text = g;
            textBox7.Text = h;
            label6.Text = j;

        }
    }
}
