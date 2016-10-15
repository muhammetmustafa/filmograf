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
    public partial class f_KutuphaneBilgisi : Form
    {
        Kutuphane kutuphane;

        public Delegate formIsimCagiricisi;

        public f_KutuphaneBilgisi()
        {
            InitializeComponent();
            kutuphane = new Kutuphane("", "");
        }
        
        private void f_KutuphaneBilgisi_Load(object sender, EventArgs e)
        {
            lAciklamaDosyaYolu.Text = kutuphane.DosyaAdi;
            lAciklamaKutuphaneAdi.Text = kutuphane.KutuphaneAdi;
            lAciklamaFilmSayisi.Text = kutuphane.Filmler.Count.ToString();
            lAciklamaKisiSayisi.Text = kutuphane.Kisiler.Count.ToString();
            tsslVeritabaniMiktari.Text = kutuphane.IDVeritabani.Count.ToString() + " adet giriş";
            SortedDictionary<string, string>.Enumerator i = kutuphane.IDVeritabani.GetEnumerator();
            i.MoveNext();

            do
            {
                dgvIsimIdler.Rows.Add(i.Current.Key, i.Current.Value);
            }
            while (i.MoveNext());
        }

        public Kutuphane Kutuphane
        {
            get
            {
                return this.kutuphane;
            }
            set
            {
                this.kutuphane = value;
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            this.txtKutuphaneAdiDuzenle.Text = kutuphane.KutuphaneAdi;
            this.txtKutuphaneAdiDuzenle.Visible = !this.txtKutuphaneAdiDuzenle.Visible;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (this.txtKutuphaneAdiDuzenle.Visible)
            {
                kutuphane.KutuphaneAdi = (this.txtKutuphaneAdiDuzenle.Text == "" ? kutuphane.KutuphaneAdi : this.txtKutuphaneAdiDuzenle.Text);
                this.txtKutuphaneAdiDuzenle.Visible = false;
                this.lAciklamaKutuphaneAdi.Text = kutuphane.KutuphaneAdi;
                this.txtKutuphaneAdiDuzenle.SelectAll();
                formIsimCagiricisi.DynamicInvoke(new object[] { kutuphane.KutuphaneAdi });
            }
        }

    }
}
