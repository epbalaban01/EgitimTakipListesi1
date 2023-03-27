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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Drawing.Text;

namespace Eğitim_Takip
{
    public partial class GirisYap : Form
    {
        SqlConnection baglanti = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
        //string server = svsettings.Default.server, database = svsettings.Default.database, username = svsettings.Default.username, password = svsettings.Default.password;

        static Regex ValidEmailRegex = CreateValidEmailRegex();
        SqlDataReader oku;
        public GirisYap()
        {
            InitializeComponent();
        }

        private void GirisYap_Shown(object sender, EventArgs e)
        {
            if (svsettings.Default.server == "" && svsettings.Default.database == "" && svsettings.Default.username == "" && svsettings.Default.password == "")
            {
                DialogResult soru = MessageBox.Show("Sunucu ayarları yapılandırılmamış.\n\nYapılandırmak ister misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (soru == DialogResult.Yes)
                {
                    this.Hide();
                    SunucuAyarlari sunucu = new SunucuAyarlari();
                    sunucu.Show();
                }
                else
                {
                    Application.ExitThread();
                }
            }

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand giris = new SqlCommand("SELECT * FROM yonetici WHERE kullanici=@kullanici and sifre=@sifre", baglanti);
            giris.Parameters.Add("kullanici", SqlDbType.VarChar).Value = textBox1.Text;
            giris.Parameters.Add("sifre", SqlDbType.VarChar).Value = textBox2.Text;
            oku = giris.ExecuteReader();


            if (oku.Read())
            {
                if (oku[4].ToString() == "1")
                {
                    if (oku.HasRows == true)
                    {
                        Form1 yeni = new Form1();
                        yeni.Show();
                        this.Hide();

                     

                    }
                    else
                    {
                        oku.Close();
                        MessageBox.Show("Hata var");
                    }

                }            
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı Alanı Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Şifre Alanı Boş Bırakılamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            baglanti.Close();
            
            //if (benihatirla.Checked)
            //{
            //    Settings.Default.kadi = textBox1.Text;
            //    Settings.Default.parol = textBox2.Text;
            //    Settings.Default.benihatirla = true;
            //}
            //else
            //{
            //    Settings.Default.benihatirla = false;
            //}
            //Settings.Default.Save();
        }

        private void GirisYap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
       

            SunucuAyarlari form2 = new SunucuAyarlari();
            form2.Show();
        }

      
        public static string MD5Sifrele(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }

        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(Application.StartupPath + @"\Font\gilroy.otf");
            label3.Font = new Font(pfc.Families[0], 20, FontStyle.Italic);
        }
    }
}
