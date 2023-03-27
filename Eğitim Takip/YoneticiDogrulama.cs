using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip
{
    public partial class YoneticiDogrulama : Form
    {
        public YoneticiDogrulama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == localAdminSettings.Default.kullanici && textBox2.Text.Trim() == localAdminSettings.Default.sifre)
            {
                MessageBox.Show("Yönetici bilgileriniz doğrulandı.\nSunucu ayarlarına yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SunucuAyarlari sunucu = new SunucuAyarlari();

                sunucu.Show();
                this.Hide();
            }
        }

        private void YoneticiDogrulama_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void YoneticiDogrulama_Load(object sender, EventArgs e)
        {

        }
    }
}
