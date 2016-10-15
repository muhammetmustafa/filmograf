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
    public partial class f_KisiListesi : Form
    {
        Kutuphane kutuphane;
        Kisi eklenecekKisi;
        int unvan = -1;

        public f_KisiListesi(Kutuphane kutuphane)
        {
            InitializeComponent();
            this.kutuphane = kutuphane;
            eklenecekKisi = new Kisi("") ;
            eklenecekKisi.Unvan = unvan;
        }

        private void f_KisiListesi_Load(object sender, EventArgs e)
        {
            cmbMeslek.SelectedIndex = eklenecekKisi.Unvan;
            txtIsim.Focus();
            kisiListesiniYenile();
        }
        private void kisiListesiniYenile()
        {
            this.kisiListesi.Items.Clear();
            this.kisiResimListesi.Images.Clear();
            if (kutuphane != null)
            {
                if (this.kutuphane.Kisiler.Count > 0)
                {
                    foreach (Kisi eklenen in this.kutuphane.Kisiler)
                    {
                        this.kisiListesi.Items.Add(eklenen.ImdbID, eklenen.Isim, eklenen.ImdbID);
                        this.kisiResimListesi.Images.Add(eklenen.ImdbID, eklenen.Resim);
                    }
                }
            }
        }
        private void kisiListesiniYenile(List<Kisi> kisiler)
        {
            this.kisiListesi.Items.Clear();
            this.kisiResimListesi.Images.Clear();
            if (kisiler == null) return;
            if (kisiler.Count > 0)
            {
                foreach (Kisi eklenen in kisiler)
                {
                    this.kisiListesi.Items.Add(eklenen.ImdbID, eklenen.Isim, eklenen.ImdbID);
                    this.kisiResimListesi.Images.Add(eklenen.ImdbID, eklenen.Resim);
                }
            }
        }
        private string unvanMetni(int unvan, bool tekilCogul)
        {
            if (unvan == (int)KisiUnvani.Diger) return ("Belirsiz" + ((tekilCogul == true)?"":"ler"));
            if (unvan == (int)KisiUnvani.Yonetmen) return ("Yönetmen" + ((tekilCogul == true) ? "" : "ler"));
            if (unvan == (int)KisiUnvani.Yazar) return ("Yazar" + ((tekilCogul == true) ? "" : "lar"));
            if (unvan == (int)KisiUnvani.Oyuncu) return ("Oyuncu" + ((tekilCogul == true) ? "" : "lar"));
            return "";
        }
        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (this.btnFiltrele.Text == "Filtrele")
            {
                List<Kisi> kisiler = this.kutuphane.kutuphanedekiKisiler(this.cmbMeslek.SelectedIndex);

                if (txtIsim.Text == "")
                {
                    kisiListesiniYenile(kisiler);
                }
                else
                {
                    List<Kisi> filtreliKisiler = new List<Kisi>();

                    foreach (Kisi kisi in kisiler.ToArray())
                    {
                        if (kisi.Isim.Contains(txtIsim.Text))
                            filtreliKisiler.Add(kisi);
                    }

                    kisiListesiniYenile(filtreliKisiler);
                }


                this.btnFiltrele.Text = "Filtreyi Sil";
                this.lDurum.Text = this.txtIsim.Text + " adındaki " + unvanMetni(this.cmbMeslek.SelectedIndex, true) + " arandı";
            }
            else
            {
                kisiListesiniYenile();
                this.btnFiltrele.Text = "Filtrele";
            }
        }
        private Kisi IMDB_den_Kisi(string imdb)
        {
            if (this.kutuphane != null)
            {
                foreach (Kisi oc in this.kutuphane.Kisiler.ToArray())
                {
                    if (oc.ImdbID == imdb)
                    {
                        return oc;
                    }
                }
            }
            return null;
        }
        private void kisiListesi_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.kisiListesi.SelectedItems.Count == 1)
            {
                Kisi secilen = IMDB_den_Kisi(this.kisiListesi.SelectedItems[0].ImageKey);

                if (secilen != null)
                {
                    secilen.kisiKopyala(eklenecekKisi);            
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                if (secilen == null)
                {
                    return;
                }
            }


        }
        private void kisiListesi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public Kisi Kisi
        {
            get
            {
                return eklenecekKisi;
            }
            set
            {
                eklenecekKisi = value;
            }
        }
        public int Unvan
        {
            get
            {
                return unvan;
            }
            set
            {
                unvan = value;
            }
        }
    }
}
