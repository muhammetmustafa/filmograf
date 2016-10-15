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
    public partial class f_KisilerGoruntusu : Form
    {
        Kutuphane anaKutuphane = null;
        List<Kisi> kisiler = null;

        public f_KisilerGoruntusu()
        {
            InitializeComponent();
            this.lvKutuphane.ColumnClick += new ColumnClickEventHandler(lvKutuphane_ColumnClick);
        }
        private void lvKutuphane_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                foreach (ListViewItem basliklar in this.lvKutuphane.Items)
                {
                    basliklar.Checked = !basliklar.Checked;
                }
            }
        }


        private void f_KutuphaneGoruntusu_Load(object sender, EventArgs e)
        {
            if ((anaKutuphane != null) && (kisiler != null))
            {
                foreach (Kisi kisi  in this.kisiler)
                {
                    if (this.anaKutuphane.kisiKutuphanedemi(kisi.ImdbID))
                    {
                        this.lvKutuphane.Items.Add(kisi.ImdbID, "", kisi.ImdbID).SubItems.AddRange(new string[] { kisi.Isim, "Kütüphaneye kaydetmişim" });
                    }
                    else
                    {
                        this.lvKutuphane.Items.Add(kisi.ImdbID, "", kisi.ImdbID).SubItems.AddRange(new string[] { kisi.Isim, "Kayıtlı değil" });
                        this.lvKutuphane.Items[kisi.ImdbID].Checked = true;
                    }
                }
            }

            this.Text = "Kişiler Ekle";
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvKutuphane.Items)
            {
                int indeks = kisiIndeksi(item.ImageKey);
                
                if (item.Checked == false)
                {
                    if (indeks != -1)
                        this.anaKutuphane.kisiGuncelle(item.ImageKey, kisiler[indeks]);
                }
                else
                {
                    if (indeks != -1)
                        this.anaKutuphane.kisiEkle(kisiler[indeks]);
                }
            }

            MessageBox.Show("Seçilenler eklendi", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public int kisiIndeksi(string id)
        {
            int i = 0;
            foreach (Kisi item in this.kisiler)
            {
                if (item.ImdbID == id)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public List<Kisi> Kisiler
        {
            set
            {
                this.kisiler = value;
            }
        }

        public Kutuphane AnaKutuphane
        {
            set
            {
                this.anaKutuphane = value;
            }
        }

    }
}
