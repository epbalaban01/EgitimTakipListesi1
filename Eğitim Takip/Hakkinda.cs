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
    public partial class Hakkinda : Form
    {
        public Hakkinda()
        {
            InitializeComponent();
        }

        private void Hakkinda_Load(object sender, EventArgs e)
        {
            labelVersion.Text = "Sürüm: " + Program.GetCurrentVersionToString() + " (24/01/2023) " + " - Full";
        }
    }
}
