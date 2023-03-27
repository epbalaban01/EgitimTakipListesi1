using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Eğitim_Takip
{
    public partial class EgitimDuzenle : Form
    {

        public string a, b, c, d, f, g, h, j;

        SqlConnection baglanti = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
        public EgitimDuzenle()
        {
            InitializeComponent();
    
        }

        private void EgitimDuzenle_Load(object sender, EventArgs e)
        {
         

            lblid.Text = j;
            textboxEgitimAdi.Text = a;
            textboxEgitimZamani.Text = b;
            textboxZoomID.Text = c;
            textboxZoomSifre.Text = d;
            textboxZoomLink.Text = f;
            comboboxSaat.Text = g;
        }


        private void EgitimDuzenle_Shown(object sender, EventArgs e)
        {
            textboxEgitimAdi.Focus();
            textboxEgitimAdi.SelectionStart = textboxEgitimAdi.TextLength;
        }


        private void btn_guncelle_Click(object sender, EventArgs e)
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
                            baglanti.Open();
                            SqlCommand kayit = new SqlCommand("UPDATE gaib SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);
                            kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                            kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                            kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                            kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                            kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                            kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);
                            kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));
                            kayit.ExecuteNonQuery();
                            baglanti.Close();    
                            this.Close();
                            MessageBox.Show("Eğitim başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                        f1.OtoSıraNo();
                    }
                    else if (label6.Text == "İMMİB Akademi")
                    {
                        try
                        {
                            baglanti.Open();
                            SqlCommand kayit = new SqlCommand("UPDATE immib SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);
                            kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                            kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                            kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                            kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                            kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                            kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);
                            kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));
                            kayit.ExecuteNonQuery();
                            MessageBox.Show("Eğitim başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                            this.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                        f1.OtoSıraNo();
                    }
                    else if (label6.Text == "ISO Akademi")
                    {
                        try
                        {
                            baglanti.Open();
                            SqlCommand kayit = new SqlCommand("UPDATE iso SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);
                            kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                            kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                            kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                            kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                            kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                            kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);
                            kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));
                            kayit.ExecuteNonQuery();
                            MessageBox.Show("Eğitim başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                            this.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                        f1.OtoSıraNo();
                    }
                    else if (label6.Text == "AKBANK Akademi")
                    {
                        try
                        {
                            baglanti.Open();
                            SqlCommand kayit = new SqlCommand("UPDATE akbank SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);
                            kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                            kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                            kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                            kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                            kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                            kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);
                            kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));
                            kayit.ExecuteNonQuery();
                            MessageBox.Show("Eğitim başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                            this.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                        f1.OtoSıraNo();
                    }
                    else if (label6.Text == "Microfon")
                    {
                        try
                        {
                            baglanti.Open();
                            SqlCommand kayit = new SqlCommand("UPDATE microfon SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);
                            kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                            kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                            kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                            kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                            kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                            kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);
                            kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));
                            kayit.ExecuteNonQuery();
                            MessageBox.Show("Eğitim başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                            this.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                        f1.OtoSıraNo();
                    }
                    else if (label6.Text == "Solidworks")
                    {
                        try
                        {
                            baglanti.Open();
                            SqlCommand kayit = new SqlCommand("UPDATE solidworks SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);
                            kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                            kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                            kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                            kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                            kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                            kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);
                            kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));
                            kayit.ExecuteNonQuery();
                            MessageBox.Show("Eğitim başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglanti.Close();
                            this.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Form1 f1 = (Form1)Application.OpenForms["Form1"];
                        f1.tablo.Clear();
                        f1.guncelle();
                        f1.OtoSıraNo();
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
