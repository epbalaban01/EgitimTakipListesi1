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
using System.IO;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace Eğitim_Takip
{
    public partial class Form1 : Form
    {
        //string server2 = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password{3};", svsettings.Default.server
        //    , svsettings.Default.database, svsettings.Default.username, svsettings.Default.password);


        SqlConnection baglanti = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server
            , svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
        //SqlConnection baglanti = new SqlConnection("Server=" + svsettings.Default.server + ";Database=" + svsettings.Default.database + ";Uid=" + svsettings.Default.username + ";Pwd=" + svsettings.Default.password + ";");


       
        // SqlConnection baglanti = new SqlConnection("Data Source=IT-EYUP-LP\\SQLEXPRESS;Initial Catalog=veritabani;MultipleActiveResultSets=True;Integrated Security=True");
        OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");

        SqlDataAdapter adapter = new SqlDataAdapter();

        public DataTable tablo = new DataTable();
        DataTable dt = new DataTable();
        SqlDataReader oku1;
        SqlDataReader okuyucu;

        SqlCommand komut = new SqlCommand();

        //private SqlConnection baglantiYap()
        //{
        //    SqlConnection baglanti = new SqlConnection("Server=" + svsettings.Default.server + ";Database=" + svsettings.Default.database + ";Uid=" + svsettings.Default.username + ";Pwd=" + svsettings.Default.database + ";");
        //    if (baglanti.State == ConnectionState.Closed)
        //    {
        //        baglanti.Open();
        //    }
        //    return baglanti;
        //}




        public Form1()
        {
            InitializeComponent();



        }

        
        public void Form1_Load(object sender, EventArgs e)
        {
            
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile(Application.StartupPath + @"\Font\gilroy.otf");
            //label15.Font = new Font(pfc.Families[0], 24, FontStyle.Italic);
            //lblsaat.Font = new Font(pfc.Families[0], 22, FontStyle.Regular);
            //lbltarih.Font = new Font(pfc.Families[0], 12, FontStyle.Regular);


            timer3.Start();
            timer1.Start();

            comboBox1.Text = "GAİB";
            label13.Text = comboBox1.Text;
            bos();

            DateTime tarih = dateTimePicker2.Value;

            timer2.Start();
            timer4.Start();
            timer5.Start();

            //using (SqlDataReader oku1 = komut.ExecuteReader())
            //{
            //    oku1.Close();
            //}

        }

      


        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }





        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


       


        #region Güncelle

        public void bos()
        {
           baglanti.Open();
       

            
            SqlDataAdapter adtr = new SqlDataAdapter("select *from bos", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            //DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();  /*** NORMAL BUTON EKLEME ***/
            //dgvBtn.HeaderText = "Zoom Link";   //Kolon Başlığı
            //dgvBtn.Text = "Sayfaya Git";      // Butonun Text
            //dgvBtn.UseColumnTextForButtonValue = true;     // Butonda Text Kullanılmasını aktifleştirme
            //dgvBtn.DefaultCellStyle.BackColor = Color.Blue;        // Buton çerçeve rengi
            //dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;        // Buton seçiliykenki çerçeve rengi
            //dgvBtn.Width = 120;         // Butonun genişiliği
            //dataGridView1.Columns.Add(dgvBtn);         // DataGridView e ekleme
            add();
            adtr.Dispose();
            renklendir();

            baglanti.Close();



        }

        public void guncelle()
        {
           baglanti.Open();


            //SQL BAĞLANTISI

            SqlDataAdapter adtr = new SqlDataAdapter("select *from gaib", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();




            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM gaib";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {


                    gaib_egitimadi.Text = okuyucu[2].ToString();
                    gaib_egitimtarihi.Text = okuyucu[3].ToString();
                    gaib_zoomlink.Text = okuyucu[6].ToString();
                    gaib_egitimsaati.Text = okuyucu[7].ToString();
                    gaib_egitimbildirimi.Text = "Eğitim Var";
                }

            }
            //


          
            // EKLENEN LİSTE SAYISI
            SqlCommand adtr4 = new SqlCommand("SELECT  count(id) as toplamkayit from gaib", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel2.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }
            //
            adtr4.Dispose();
            oku1.Close();


            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle1()
        {
           baglanti.Open();

            //SQL BAĞLANTISI

            SqlDataAdapter adtr = new SqlDataAdapter("select *from immib", baglanti);
            adtr.Fill(tablo);


            dataGridView1.DataSource = tablo;
            add();
            adtr.Dispose();
            renklendir();



            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM immib";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    immib_egitimbildirimi.Text = "Eğitim Var";

                    immib_egitimadi.Text = okuyucu[2].ToString();
                    immib_egitimtarihi.Text = okuyucu[3].ToString();
                    immib_zoomlink.Text = okuyucu[6].ToString();
                    immib_egitimsaati.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            SqlCommand adtr4 = new SqlCommand("SELECT  count(id) as toplamkayit from immib", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }
            //

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle2()
        {
           baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from iso", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM iso";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    iso_egitimbildirimi.Text = "Eğitim Var";

                    iso_egitimadi.Text = okuyucu[2].ToString();
                    iso_egitimtarihi.Text = okuyucu[3].ToString();
                    iso_zoomlink.Text = okuyucu[6].ToString();
                    iso_egitimsaati.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            SqlCommand adtr4 = new SqlCommand("SELECT  count(id) as toplamkayit from iso", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle3()
        {
           baglanti.Open();

            //SQL BAĞLANTISI

            SqlDataAdapter adtr = new SqlDataAdapter("select *from akbank", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM akbank";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    iso_egitimbildirimi.Text = "Eğitim Var";

                    akbank_egitimadi.Text = okuyucu[2].ToString();
                    akbank_egitimtarihi.Text = okuyucu[3].ToString();
                    akbank_zoomlink.Text = okuyucu[6].ToString();
                    akbank_egitimbildirimi.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            SqlCommand adtr4 = new SqlCommand("SELECT  count(id) as toplamkayit from akbank", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle4()
        {
           

            //SQL BAĞLANTISI
           baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from microfon", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM microfon";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    microfon_egitimbildirimi.Text = "Eğitim Var";

                    microfon_egitimadi.Text = okuyucu[2].ToString();
                    microfon_egitimtarihi.Text = okuyucu[3].ToString();
                    microfon_zoomlink.Text = okuyucu[6].ToString();
                    microfon_egitimsaati.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            SqlCommand adtr4 = new SqlCommand("SELECT  count(id) as toplamkayit from microfon", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle5()
        {
          

            //SQL BAĞLANTISI
           baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from solidworks", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            // EKLENEN LİSTE SAYISI
            SqlCommand adtr4 = new SqlCommand("SELECT  count(id) as toplamkayit from solidworks", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }
        #endregion

        #region Add
        public void add()
        {

            dataGridView1.AllowUserToAddRows = false; // remove the null line
            dataGridView1.ReadOnly = false;
            dataGridView1.Columns["sira_no"].DisplayIndex = 0;
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].Width = 45;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderText = "";
            dataGridView1.Columns[1].ReadOnly = true;

            dataGridView1.Columns[2].Width = 174;
            dataGridView1.Columns[2].HeaderText = "Eğitim Adı";
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[3].HeaderText = "Eğitim Zamanı";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[4].HeaderText = "Zoom ID";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].ReadOnly = true;

            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[5].HeaderText = "Zoom Şifre";
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].ReadOnly = true;

            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[6].HeaderText = "Zoom Link";
            dataGridView1.Columns[6].Width = 115;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].ReadOnly = true;

            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[7].HeaderText = "Saat";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].ReadOnly = true;

            dataGridView1.Columns[8].Visible = true;
            dataGridView1.Columns[8].ReadOnly = false;

        }
        #endregion

        #region Silme İşlemi
        public void delete()
        {
            if (comboBox1.Text == "GAİB")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   

                    //SQL BAĞLANTISI
                   baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("DELETE FROM gaib WHERE egitim_adi=@egitim_adi", baglanti);
                    komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle();
                    OtoSıraNo();

                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "İMMİB Akademi")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {


                    //SQL BAĞLANTISI
                   baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("DELETE FROM immib WHERE egitim_adi=@egitim_adi", baglanti);
                    komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle1();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "ISO Akademi")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //SQL BAĞLANTISI
                   baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("DELETE FROM iso WHERE egitim_adi=@egitim_adi", baglanti);
                    komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle2();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }

            else if (comboBox1.Text == "AKBANK Akademi")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //SQL BAĞLANTISI
                   baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("DELETE FROM akbank WHERE egitim_adi=@egitim_adi", baglanti);
                    komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle3();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "Microfon")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //SQL BAĞLANTISI
                   baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("DELETE FROM microfon WHERE egitim_adi=@egitim_adi", baglanti);
                    komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle4();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "Solidworks")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //SQL BAĞLANTISI
                   baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("DELETE FROM solidworks WHERE egitim_adi=@egitim_adi", baglanti);
                    komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle5();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else
            {
                MessageBox.Show("Seçim Yap");
            }


        }
        #endregion


        #region Renklendirme
        public void renklendir()
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dataGridView1.Rows[i].Cells["egitim_zamani"].Value.ToString()) == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }

                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }


        }
        #endregion


        #region Otomatik Sıra No
        public void OtoSıraNo() //For Döngüsünü Tanımlama
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) //DataGridView satır sayısı kadar int i yi bir artırma
            {
                dataGridView1.Rows[i].Cells[1].Value = (i + 1).ToString();//Belirlediğimiz 2.Sutuna ( Cells[1] ) DataGridView satır sayısı kadar otomatik artan sayı verme
            }
            dataGridView1.AllowUserToAddRows = false;//DataGridView in son sırasını gizleme
        }
        #endregion

        #region İleri Gitme, Geri Gitme

        public void btn_ileri_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
                label13.Text = comboBox1.Text;        
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
                label13.Text = comboBox1.Text;
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltarih.Text = DateTime.Now.ToShortDateString();
            lblsaat.Text = DateTime.Now.ToLongTimeString();

            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {// hangi kolona göre işlem yapacaksak onun index i ile karşılaştırıyoruz

                System.Diagnostics.Process.Start(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            }

            lblegitimadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblegitimzamani.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lblzoomid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            lblzoomsifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            lblzoomlink.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            lblegitimsaati.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();



        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblegitimadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblegitimzamani.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lblzoomid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            lblzoomsifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            lblzoomlink.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            lblegitimsaati.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            if (lblegitimzamani.Text == lbltarih.Text)
            {
                label11.Text = "Bugün eğitimin var";
                pictureBox6.Image = Properties.Resources._01_Warning_icon;
            }
            else
            {
                label11.Text = "Bugün eğitimin yok";
                pictureBox6.Image = Properties.Resources._15_Tick_icon;
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "GAİB")
            {
                pictureBox1.Image = Properties.Resources.gaiblogo;
                tablo.Clear();
                guncelle();
            }
            else if (comboBox1.Text == "İMMİB Akademi")
            {
                pictureBox1.Image = Properties.Resources.immib;
                tablo.Clear();
                guncelle1();
            }
            else if (comboBox1.Text == "ISO Akademi")
            {
                pictureBox1.Image = Properties.Resources.ISO_logo_1280_146;
                tablo.Clear();
                guncelle2();
            }

            else if (comboBox1.Text == "AKBANK Akademi")
            {
                pictureBox1.Image = Properties.Resources.akbank;
                tablo.Clear();
                guncelle3();
            }
            else if (comboBox1.Text == "Microfon")
            {
                pictureBox1.Image = Properties.Resources.microfon;
                tablo.Clear();
                guncelle4();
            }
            else if (comboBox1.Text == "Solidworks")
            {
                pictureBox1.Image = Properties.Resources.solidworks;
                tablo.Clear();
                guncelle5();
            }
            else
            {
                MessageBox.Show("Seçim Yap");
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EgitimDuzenle yeni = new EgitimDuzenle();
            yeni.label6.Text = label13.Text;
            yeni.j = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            yeni.a = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            yeni.b = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            yeni.c = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            yeni.d = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            yeni.f = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            yeni.g = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            yeni.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkinda yeni = new Hakkinda();
            yeni.Show();
        }

        private void genelAyarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar yeni = new Ayarlar();
            yeni.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_link_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(dataGridView1.CurrentRow.Cells[6].Value.ToString());
        }

        private void btn_ac_Click(object sender, EventArgs e)
        {

            EgitimEkle yeni = new EgitimEkle();
            yeni.label6.Text = label13.Text;
            yeni.Show();
        }


        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            EgitimDuzenle yeni = new EgitimDuzenle();
            yeni.label6.Text = label13.Text;
            yeni.j = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            yeni.a = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            yeni.b = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            yeni.c = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            yeni.d = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            yeni.f = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            yeni.g = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            yeni.Show();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{

            //    bool isCellChecked = (bool)dataGridView1.Rows[i].Cells[8].Value;
            //    if (isCellChecked == true)
            //    {
            //        MessageBox.Show("Tebrikler");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Hata");
            //    }
            //}


            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if ((bool)dataGridView1.Rows[i].Cells["katildi_mi"].Value == false)
            //    {
            //        MessageBox.Show("Tebrikler");
            //    }

            //    else
            //    {
            //        MessageBox.Show("Hata");
            //    }
            //}

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    bool isCellChecked = (bool)dataGridView1.Rows[i].Cells[8].Value;
            //    if(isCellChecked == true)
            //    {
            //        MessageBox.Show("Tebrikler");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Tebrikler değil" );
            //    }
            //}


            //if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == false)
            //{
            //    if (MessageBox.Show("Eğitime Katıldın Mı?", "Arşiv'e Taşıma İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        MessageBox.Show("Tebrikler katıldın");
            //    }
            //    else
            //    {
            //         MessageBox.Show("Tebrikler katıldın");
            //    }
            //}
            //else if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
            //{
            //    MessageBox.Show("Tebrikler beceremedin");
            //}


            //foreach(DataGridViewRow r in dataGridView1.Rows)
            //{
            //    bool is_Approved = Convert.ToBoolean(r.Cells[8].Value);

            //    if(is_Approved == false)
            //    {
            //        MessageBox.Show("Tebrikler");
            //    }
            //    else if(is_Approved == true)
            //    {
            //        MessageBox.Show("Hata");
            //    }

            //}



            //foreach (DataGridViewRow r in dataGridView1.Rows)
            //{
            //    bool is_Approved = Convert.ToBoolean(r.Cells[8].Value);

            //    if (is_Approved == false)
            //    {
            //        r.DefaultCellStyle.BackColor = Color.Red;
            //        r.DefaultCellStyle.ForeColor = Color.White;
            //    }
            //    else if (is_Approved == true)
            //    {
            //        r.DefaultCellStyle.BackColor = Color.Green;
            //        r.DefaultCellStyle.ForeColor = Color.White;
            //    }

            //}




        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable _dt = (DataTable)dataGridView1.DataSource;

            //foreach (DataGridViewRow _row in _dt.Rows)
            //{
            //    if (Convert.ToBoolean(_row.Cells[8].Value) == true)
            //    {
            //        MessageBox.Show("Checked");
            //    }
            //}


        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.Text == "GAİB")
                {
                    if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
                    {
                        if(MessageBox.Show("Eğitime Katıldın Mı?", "GAİB Arşiv İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                /* SQL SERVER KAYDETME */

                                //SQL BAĞLANTISI
                               baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("DELETE FROM gaib WHERE egitim_adi=@egitim_adi", baglanti);
                                komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut2.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    SqlConnection baglanti2 = new SqlConnection("Data Source=IT-EYUP-LP\\SQLEXPRESS;Initial Catalog=veritabani;MultipleActiveResultSets=True;Integrated Security=True");
                                    
                                    baglanti2.Open();
                                    SqlCommand logkomutu = new SqlCommand("insert into gaib_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti2);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);
                                  
                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti2.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti.Close();
                                MessageBox.Show("SQL arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                /* SQL SERVER KAYDETME */

                                /*////////////////////////////////////////////////////////////////////////////////////////*/


                                /* ACCESS VERİTABANI KAYDETME */
                                baglanti1.Open();
                                OleDbCommand komut3 = new OleDbCommand("DELETE FROM gaib WHERE egitim_adi=@egitim_adi", baglanti1);
                                komut3.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut3.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    OleDbConnection baglanti2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
                                    baglanti2.Open();
                                    OleDbCommand logkomutu = new OleDbCommand("insert into gaib_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti2);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);

                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti2.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti1.Close();
                                MessageBox.Show("Access veritabanı arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                /* ACCESS VERİTABANI KAYDETME */

                                tablo.Clear();
                                guncelle();
                              
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show(hata.Message);
                            }
                        }    
                    }
                }
                else if (comboBox1.Text == "İMMİB Akademi")
                {
                    if(Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
                    {
                        if (MessageBox.Show("Eğitime Katıldın Mı?", "İMMİB Akademi Arşiv İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                //SQL BAĞLANTISI
                               baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("DELETE FROM immib WHERE egitim_adi=@egitim_adi", baglanti);
                                komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut2.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
                                    baglanti1.Open();
                                    SqlCommand logkomutu = new SqlCommand("insert into immib_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);
                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti1.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti.Close();

                                MessageBox.Show("Arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tablo.Clear();
                                guncelle1();
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show(hata.Message);
                            }
                        }
                    }
                }
                else if (comboBox1.Text == "ISO Akademi")
                {
                    if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
                    {
                        if(MessageBox.Show("Eğitime Katıldın Mı?", "ISO Akademi Arşiv İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                //SQL BAĞLANTISI
                               baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("DELETE FROM iso WHERE egitim_adi=@egitim_adi", baglanti);
                                komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut2.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
                                    baglanti1.Open();
                                    SqlCommand logkomutu = new SqlCommand("insert into iso_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);
                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti1.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti.Close();

                                MessageBox.Show("Arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tablo.Clear();
                                guncelle2();
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show(hata.Message);
                            }
                        }
                    }
                }

                else if (comboBox1.Text == "AKBANK Akademi")
                {
                    if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
                    {
                        if(MessageBox.Show("Eğitime Katıldın Mı?", "Akbank Akademi Arşiv İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                //SQL BAĞLANTISI
                               baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("DELETE FROM akbank WHERE egitim_adi=@egitim_adi", baglanti);
                                komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut2.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
                                    baglanti1.Open();
                                    SqlCommand logkomutu = new SqlCommand("insert into akbank_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);
                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti1.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti.Close();

                                MessageBox.Show("Arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tablo.Clear();
                                guncelle3();
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show(hata.Message);
                            }
                        }
                    }
                }
                else if (comboBox1.Text == "Microfon")
                {
                    if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
                    {
                        if(MessageBox.Show("Eğitime Katıldın Mı?", "Microfon Arşiv İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                //SQL BAĞLANTISI
                               baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("DELETE FROM microfon WHERE egitim_adi=@egitim_adi", baglanti);
                                komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut2.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
                                    baglanti1.Open();
                                    SqlCommand logkomutu = new SqlCommand("insert into microfon_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);
                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti1.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti.Close();

                                MessageBox.Show("Arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tablo.Clear();
                                guncelle3();
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show(hata.Message);
                            }
                        }  
                    }
                }
                else if (comboBox1.Text == "Solidworks")
                {
                    if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value.ToString()) == true)
                    {
                        if(MessageBox.Show("Eğitime Katıldın Mı?", "Solidworks Arşiv İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {

                                //SQL BAĞLANTISI
                               baglanti.Open();
                                SqlCommand komut2 = new SqlCommand("DELETE FROM solidworks WHERE egitim_adi=@egitim_adi", baglanti);
                                komut2.Parameters.AddWithValue("@egitim_adi", dataGridView1.CurrentRow.Cells[2].Value);
                                komut2.ExecuteNonQuery();

                                /* Log Başlangıç */
                                try
                                {
                                    OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
                                    baglanti1.Open();
                                    SqlCommand logkomutu = new SqlCommand("insert into solidworks_arsiv ([egitim_adi], [egitim_zamani],[zoom_id], [zoom_sifre],[zoom_link],[saat],[katildi_mi], [tarih]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat, @katildi_mi, @tarih)", baglanti);
                                    logkomutu.Parameters.AddWithValue("@egitim_adi", lblegitimadi.Text);
                                    logkomutu.Parameters.AddWithValue("@egitim_zamani", lblegitimzamani.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_id", lblzoomid.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_sifre", lblzoomsifre.Text);
                                    logkomutu.Parameters.AddWithValue("@zoom_link", lblzoomlink.Text);
                                    logkomutu.Parameters.AddWithValue("@saat", lblegitimsaati.Text);
                                    logkomutu.Parameters.AddWithValue("@katildi_mi", label39.Text);
                                    logkomutu.Parameters.AddWithValue("@tarih", lbltarih.Text);
                                    logkomutu.ExecuteNonQuery();
                                    logkomutu.Dispose();
                                    baglanti1.Close();
                                }
                                catch (InvalidCastException ex)
                                {
                                    MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                /* Log Bitiş */

                                baglanti.Close();

                                MessageBox.Show("Arşivlere taşındı", "Balaban Eğitim Takip Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                tablo.Clear();
                                guncelle3();
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show(hata.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seçim Yap");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            notification();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            notification1();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            notification2();
        }


        #region KALAN VAKİT HESAPLAMA

        string vakit, kalanvakit, kalanvakit1, kalanvakit2;

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablo.Clear();
       
        }

        string immibvakit, immibkalanvakit, immibkalanvakit1, immibkalanvakit2;
        string isovakit, isokalanvakit, isokalanvakit1, isokalanvakit2;

    

        string microfonvakit, microfonkalanvakit, microfonkalanvakit1, microfonkalanvakit2;
        string akbankvakit, akbankkalanvakit, akbankkalanvakit1, akbankkalanvakit2;



        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (gaib_egitimtarihi.Text == DateTime.Now.ToShortDateString()) //GAİB KALAN SAAT
                {
                    string suankiSaat = DateTime.Now.ToShortTimeString();
                    string bitisSaati = gaib_egitimsaati.Text;
                    TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                    string calismasüresi = fark.TotalMinutes.ToString();
                    gaib_kalanvakit.Text = calismasüresi;

                    vakit = gaib_kalanvakit.Text;
                    kalanvakit = "60";
                    kalanvakit1 = "30";
                    kalanvakit2 = "15";
                }
                if (immib_egitimtarihi.Text == DateTime.Now.ToShortDateString()) // İMMİB AKADEMİ KALAN SAAT
                {
                    string suankiSaat = DateTime.Now.ToShortTimeString();
                    string bitisSaati = immib_egitimsaati.Text;
                    TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                    string calismasüresi = fark.TotalMinutes.ToString();
                    immib_kalanvakit.Text = calismasüresi;

                    immibvakit = immib_kalanvakit.Text;
                    immibkalanvakit = "60";
                    immibkalanvakit1 = "30";
                    immibkalanvakit2 = "15";
                }
                if (iso_egitimtarihi.Text == DateTime.Now.ToShortDateString()) // İSO KALAN SAAT
                {
                    string suankiSaat = DateTime.Now.ToShortTimeString();
                    string bitisSaati = iso_egitimsaati.Text;
                    TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                    string calismasüresi = fark.TotalMinutes.ToString();
                    iso_kalanvakit.Text = calismasüresi;

                    isovakit = iso_kalanvakit.Text;
                    isokalanvakit = "60";
                    isokalanvakit1 = "30";
                    isokalanvakit2 = "15";
                }
                if (microfon_egitimtarihi.Text == DateTime.Now.ToShortDateString()) // MİCROFON KALAN SAAT
                {
                    string suankiSaat = DateTime.Now.ToShortTimeString();
                    string bitisSaati = akbank_egitimtarihi.Text;
                    TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                    string calismasüresi = fark.TotalMinutes.ToString();
                    microfon_kalanvakit.Text = calismasüresi;

                    microfonvakit = microfon_kalanvakit.Text;
                    microfonkalanvakit = "60";
                    microfonkalanvakit1 = "30";
                    microfonkalanvakit2 = "15";
                }
                if (akbank_egitimtarihi.Text == DateTime.Now.ToShortDateString()) // AKBANK KALAN SAAT
                {
                    string suankiSaat = DateTime.Now.ToShortTimeString();
                    string bitisSaati = akbank_egitimtarihi.Text;
                    TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                    string calismasüresi = fark.TotalMinutes.ToString();
                    akbank_kalanvakit.Text = calismasüresi;

                    akbankvakit = akbank_kalanvakit.Text;
                    akbankkalanvakit = "60";
                    akbankkalanvakit1 = "30";
                    akbankkalanvakit2 = "15";
                }
                else
                {
                    //
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        #endregion


        #region BİLDİRİM 1
        private void notification()
        {

            try
            {
                //--------------------------------------GAİB----------------------------------------//
                if (gaib_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {

                    if (vakit == kalanvakit)
                    {
                        timer2.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + gaib_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + gaib_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(gaib_zoomlink.Text);
                        }
                        else
                        {
                            //
                        }
                    }
                  
                }

                //-----------------------------------------------------------------------------------//


                //-----------------------------------İMMİB AKADEMİ------------------------------------//
                if (immib_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (immibvakit == immibkalanvakit)
                    {
                        timer2.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + immib_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + immib_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(immib_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //----------------------------------------------------------------------------------//


                //-----------------------------------İSO AKADEMİ------------------------------------//
                if (iso_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (isovakit == isokalanvakit)
                    {
                        timer2.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + iso_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + iso_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(iso_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }

                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //--------------------------------------------------------------------------------//


                //-----------------------------------AKBANK AKADEMİ------------------------------------//
                if (akbank_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (akbankvakit == akbankkalanvakit)
                    {
                        timer2.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + akbank_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + akbank_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(akbank_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //-----------------------------------------------------------------------------//


                //-----------------------------------MİCROFON------------------------------------//
                if (microfon_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (microfonvakit == microfonkalanvakit)
                    {
                        timer2.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + microfon_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + microfon_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(microfon_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //-----------------------------------------------------------------------------//
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        #endregion 

        #region BİLDİRİM 2
        private void notification1()
        {
            try
            {
                //-----------------------------------GAİB------------------------------------//
                if (gaib_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (vakit == kalanvakit1)
                    {
                        timer4.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + gaib_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + gaib_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(gaib_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //----------------------------------------------------------------------------------//


                //-----------------------------------İMMİB AKADEMİ------------------------------------//
                if (immib_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (immibvakit == immibkalanvakit1)
                    {
                        timer4.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + immib_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + immib_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(immib_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //----------------------------------------------------------------------------------//


                //-----------------------------------İSO AKADEMİ------------------------------------//
                if (iso_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (isovakit == isokalanvakit1)
                    {
                        timer4.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + iso_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + iso_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(iso_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }

                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //--------------------------------------------------------------------------------//


                //-----------------------------------AKBANK AKADEMİ------------------------------------//
                if (akbank_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (akbankvakit == akbankkalanvakit1)
                    {
                        timer4.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + akbank_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + akbank_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(akbank_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //-----------------------------------------------------------------------------//


                //-----------------------------------MİCROFON------------------------------------//
                if (microfon_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (microfonvakit == microfonkalanvakit1)
                    {
                        timer4.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + microfon_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + microfon_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(microfon_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //-----------------------------------------------------------------------------//
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }      
        }
        #endregion


        #region BİLDİRİM 3
        private void notification2()
        {
            try
            {
                //-----------------------------------GAİB------------------------------------//
                if (gaib_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (vakit == kalanvakit2)
                    {
                        timer5.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + gaib_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + gaib_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(gaib_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                }
                //----------------------------------------------------------------------------------//


                //-----------------------------------İMMİB AKADEMİ------------------------------------//
                if (immib_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (immibvakit == immibkalanvakit2)
                    {
                        timer5.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + immib_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + immib_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(immib_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //----------------------------------------------------------------------------------//


                //-----------------------------------İSO AKADEMİ------------------------------------//
                if (iso_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (isovakit == isokalanvakit2)
                    {
                        timer5.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + iso_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + iso_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(iso_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }

                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //--------------------------------------------------------------------------------//


                //-----------------------------------AKBANK AKADEMİ------------------------------------//
                if (akbank_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (akbankvakit == akbankkalanvakit2)
                    {
                        timer5.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + akbank_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + akbank_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(akbank_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //-----------------------------------------------------------------------------//


                //-----------------------------------MİCROFON------------------------------------//
                if (microfon_egitimtarihi.Text == DateTime.Now.ToShortDateString())
                {
                    if (microfonvakit == microfonkalanvakit2)
                    {
                        timer5.Stop();
                        if (MessageBox.Show("Eğitim Adı: " + microfon_egitimadi.Text + "\n" + "\n" + "Eğitim Saati: " + microfon_egitimsaati.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start(microfon_zoomlink.Text);
                        }
                        else
                        {
                            //ZAMAN HESAPLAMA
                        }
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }
                }
                //-----------------------------------------------------------------------------//
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        #endregion

    }



}



