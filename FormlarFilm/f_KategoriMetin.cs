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
    public partial class f_KategoriMetin : Form
    {
        CekimHatasi yeniCekimHatasi = null;
        FilmMuzigi yeniFilmMuzigi = null;

        public f_KategoriMetin(bool BCekimHatasi = false, bool BFilmMuzigi = false)
        {
            InitializeComponent();

            if (BCekimHatasi == true)
            yeniCekimHatasi = new CekimHatasi();

            if (BFilmMuzigi == true)
                yeniFilmMuzigi = new FilmMuzigi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtHataBasligi.Text == "") || (rchtxtHataIcerigi.Text == ""))
            {
                MessageBox.Show("Dostum ekleyebilmem için birşeyler girmen lazım.", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            if (this.yeniCekimHatasi != null)
            {
                this.Text = "Çekim Hatası Ekle";
                yeniCekimHatasi.hataBasligi = this.txtHataBasligi.Text;
                yeniCekimHatasi.metin = this.rchtxtHataIcerigi.Text;
            }

            if (this.yeniFilmMuzigi != null)
            {
                this.Text = "Film Müziği Ekle";
                yeniFilmMuzigi.muzikAdi = this.txtHataBasligi.Text;
                yeniFilmMuzigi.metin = this.rchtxtHataIcerigi.Text;
            }
        }

        public CekimHatasi GirilenCekimHatasi
        {
            get
            {
                return this.yeniCekimHatasi;
            }
            set
            {
                this.yeniCekimHatasi = value;
            }
        }
        public FilmMuzigi GirilenFilmMuzigi
        {
            get
            {
                return this.yeniFilmMuzigi;
            }
            set
            {
                this.yeniFilmMuzigi = value;
            }
        }
        private void f_KategoriMetin_Load(object sender, EventArgs e)
        {
            if (yeniCekimHatasi != null)
            {
                this.label1.Text = "Hata Başlığı";
                this.label2.Text = "Hata İçeriği";
            }
            if (yeniFilmMuzigi != null)
            {
                this.label1.Text = "Müziğin Adı";
                this.label2.Text = "Açıklama";
            }
        }
    }
}
