using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMC_Filmograf
{
    public partial class f_KelimeEkle : Form
    {
        string metin;
        string baslik;

        public f_KelimeEkle(string baslik)
        {
            InitializeComponent();
            this.baslik = baslik;
        }
        
        public f_KelimeEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.metin = textBox1.Text;
            this.Close();
        }

        public string Kelime
        {
            get { return metin; }
        }


        void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.metin = textBox1.Text;
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public string Girilen
        {
            get
            {
                return this.metin;
            }
        }
        private void KelimeEkle_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (this.baslik != null)
            {
                this.Text = baslik;
            }
        }
    }
}
