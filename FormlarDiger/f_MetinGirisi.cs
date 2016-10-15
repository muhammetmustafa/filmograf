using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMC_Filmograf.Library;

namespace MMC_Filmograf
{
    public partial class f_MetinGirisi : Form
    {
        string metin;

        public f_MetinGirisi()
        {
            InitializeComponent();
            this.metin = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.rchtxtMetin.Text = this.metin;
            this.rchtxtMetin.SelectAll();
        }

        public string Metin
        {
            get { return this.metin; }
            set { this.metin = value; }
        }

        private void rchtxtMetin_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.metin = this.rchtxtMetin.Text;
        }

    }
}
