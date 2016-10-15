using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filmograf.Library;

namespace Filmograf
{
    public partial class f_Referans : Form
    {
        Kutuphane kutuphane;
        BaglantiKategorisi yeni;

        public f_Referans(Kutuphane kutuphane)
        {
            InitializeComponent();
            this.kutuphane = kutuphane;

            yeni = new BaglantiKategorisi();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f_BaslikArayicisi yeni = new f_BaslikArayicisi(this.kutuphane);
            DialogResult d = yeni.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                linkLabel1.Name = yeni.SecilenID;
                linkLabel1.Text = this.kutuphane.kutuphanedekiFilm(yeni.SecilenID).Ad;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if ((this.txtHataBasligi.Text == "") && (!System.Text.RegularExpressions.Regex.IsMatch(this.linkLabel1.Name, "tt\\d{7}")))
            {
                MessageBox.Show("Ekleyebilmeniz için Bağlantı kategorisini ve Bağlantı yapılacak filmi belirlemeniz gerekiyor", Sabitler.ProgramBasligi,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            yeni.kategoriAdi = this.txtHataBasligi.Text;
            yeni.filmID_Aciklama.Add(this.linkLabel1.Name, this.rchtxtHataIcerigi.Text);
            
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public BaglantiKategorisi EklenenBaglanti
        {
            get
            {
                return this.yeni;
            }
            set
            {
                this.yeni = value;
            }
        }

    }
}
