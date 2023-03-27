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
    public partial class EgitimEkle : Form
    {
        //SqlConnection baglanti2 = new SqlConnection("Data Source=IT-EYUP-LP\\SQLEXPRESS;Initial Catalog=veritabani;MultipleActiveResultSets=True;Integrated Security=True");
        SqlConnection baglanti2 = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
        public EgitimEkle()
        {
            InitializeComponent();
        }
       
        private void EgitimEkle_Load(object sender, EventArgs e)
        {
            textboxEgitimZamani.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textboxEgitimAdi.Text == "" || textboxEgitimZamani.Text == "" || textboxZoomID.Text == "" || textboxZoomSifre.Text == "" || textboxZoomLink.Text == "" || comboboxSaat.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayın", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (label6.Text == "GAİB")
                    {
                        try
                        {
                            baglanti2.Open();
                            SqlCommand tekrar = new SqlCommand("select count(*) from gaib where egitim_adi='" + textboxEgitimAdi.Text + "'", baglanti2);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                            
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else if (label6.Text == "İMMİB Akademi")
                    {
                        try
                        {
                            baglanti2.Open();
                            SqlCommand tekrar = new SqlCommand("select count(*) from immib where egitim_adi='" + textboxEgitimAdi.Text + "'", baglanti2);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (label6.Text == "ISO Akademi")
                    {
                        try
                        {
                            baglanti2.Open();
                            SqlCommand tekrar = new SqlCommand("select count(*) from iso where egitim_adi='" + textboxEgitimAdi.Text + "'", baglanti2);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (label6.Text == "AKBANK Akademi")
                    {
                        try
                        {
                            baglanti2.Open();
                            SqlCommand tekrar = new SqlCommand("select count(*) from akbank where egitim_adi='" + textboxEgitimAdi.Text + "'", baglanti2);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (label6.Text == "Microfon")
                    {
                        try
                        {
                            baglanti2.Open();
                            SqlCommand tekrar = new SqlCommand("select count(*) from microfon where egitim_adi='" + textboxEgitimAdi.Text + "'", baglanti2);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (label6.Text == "Solidworks")
                    {
                        try
                        {
                            baglanti2.Open();
                            SqlCommand tekrar = new SqlCommand("select count(*) from solidworks where egitim_adi='" + textboxEgitimAdi.Text + "'", baglanti2);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
