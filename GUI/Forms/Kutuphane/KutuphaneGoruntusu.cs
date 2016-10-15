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
    public partial class f_KutuphaneGoruntusu : Form
    {
        Kutuphane eklenecekKutuphane;
        Kutuphane anaKutuphane;

        public f_KutuphaneGoruntusu()
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

        private void cbFilmleriEkle_CheckedChanged(object sender, EventArgs e)
        {
            cbFilmleriGuncelle.Enabled = cbFilmleriEkle.Checked;
        }

        private void cbDizileriEkle_CheckedChanged(object sender, EventArgs e)
        {
            cbDizileriGuncelle.Enabled = cbDizileriEkle.Checked;
        }

        private void cbKisileriEkle_CheckedChanged(object sender, EventArgs e)
        {
            cbKisileriGuncelle.Enabled = cbKisileriEkle.Checked;
        }

        private void f_KutuphaneGoruntusu_Load(object sender, EventArgs e)
        {
            #region Kütüphane Eklemesi
            if ((this.eklenecekKutuphane != null) && (this.anaKutuphane != null))
            {
                foreach (Film fEklenen in eklenecekKutuphane.Filmler)
                {
                    if (this.anaKutuphane.filmKutuphanedemi(fEklenen.ImdbID))
                    {
                        this.lvKutuphane.Items.Add(fEklenen.ImdbID, "", fEklenen.ImdbID)
                                                    .SubItems.AddRange(new string[] { fEklenen.Ad, "Kütüphaneye kaydetmişim" });
                    }
                    else
                    {
                        this.lvKutuphane.Items.Add(fEklenen.ImdbID, "", fEklenen.ImdbID)
                                                    .SubItems.AddRange(new string[] { fEklenen.Ad, "Kütüphaneye yok" });
                        this.lvKutuphane.Items[fEklenen.ImdbID].Checked = true;
                    }

                    this.lvKutuphane.Items[fEklenen.ImdbID].Group = this.lvKutuphane.Groups[0];
                }
                foreach (Dizi dEklenen in eklenecekKutuphane.Diziler)
                {
                    if (this.anaKutuphane.diziKutuphanedemi(dEklenen.ImdbID))
                    {
                        this.lvKutuphane.Items.Add(dEklenen.ImdbID, "", dEklenen.ImdbID)
                                                    .SubItems.AddRange(new string[] { dEklenen.Ad, "Kütüphaneye kaydetmişim" });
                    }
                    else
                    {
                        this.lvKutuphane.Items.Add(dEklenen.ImdbID, "", dEklenen.ImdbID)
                                                    .SubItems.AddRange(new string[] { dEklenen.Ad, "Kütüphaneye yok" });
                        this.lvKutuphane.Items[dEklenen.ImdbID].Checked = true;
                    }

                    this.lvKutuphane.Items[dEklenen.ImdbID].Group = this.lvKutuphane.Groups[1];
                }
                foreach (Kisi kEklenen in eklenecekKutuphane.Kisiler)
                {
                    if (this.anaKutuphane.kisiKutuphanedemi(kEklenen.ImdbID))
                    {
                        this.lvKutuphane.Items.Add(kEklenen.ImdbID, "", kEklenen.ImdbID)
                                                    .SubItems.AddRange(new string[] { kEklenen.Isim, "Kütüphaneye kaydetmişim" });
                    }
                    else
                    {
                        this.lvKutuphane.Items.Add(kEklenen.ImdbID, "", kEklenen.ImdbID)
                                                    .SubItems.AddRange(new string[] { kEklenen.Isim, "Kütüphaneye yok" });
                        this.lvKutuphane.Items[kEklenen.ImdbID].Checked = true;
                    }

                    this.lvKutuphane.Items[kEklenen.ImdbID].Group = this.lvKutuphane.Groups[2];
                }

                this.tsslFilmSayisi.Text = this.eklenecekKutuphane.Filmler.Count + " Film";
                this.tsslDiziSayisi.Text = this.eklenecekKutuphane.Diziler.Count + " Dizi";
                this.tsslKisiSayisi.Text = this.eklenecekKutuphane.Kisiler.Count + " Film";
                this.tsslVeritabaniDurumu.Text = this.eklenecekKutuphane.IDVeritabani.Count + " Giriş";
                this.Text = "\"" + this.eklenecekKutuphane.KutuphaneAdi + "\"" + " Kütüphanesi";
            } 
            #endregion

        }

        public Kutuphane EklenecekKutuphane
        {
            set
            {
                this.eklenecekKutuphane = value;
            }
        }

        public Kutuphane AnaKutuphane
        {
            get
            {
                return this.anaKutuphane;
            }
            set
            {
                this.anaKutuphane = value;
            }
        }


        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cbFilmleriEkle.Checked)
            {
                foreach (ListViewItem item in this.lvKutuphane.Groups[0].Items) //Filmler
                {
                    if (item.Checked == false) continue;

                    if (this.anaKutuphane.kutuphanedekiFilmlerinIDleri().Contains(item.ImageKey))
                    {
                        if (cbFilmleriGuncelle.Checked == true)
                        {
                            this.anaKutuphane.filmGuncelle(item.ImageKey, this.eklenecekKutuphane.kutuphanedekiFilm(item.ImageKey));
                        }
                    }
                    else
                    {
                        this.anaKutuphane.filmEkle(this.eklenecekKutuphane.kutuphanedekiFilm(item.ImageKey));
                    }
                }
            }

            if (cbDizileriEkle.Checked)
            {
                foreach (ListViewItem item in this.lvKutuphane.Groups[1].Items) //Diziler
                {
                    if (item.Checked == false) continue;

                    if (this.anaKutuphane.kutuphanedekiDizilerinIDleri().Contains(item.ImageKey))
                    {
                        if (cbDizileriGuncelle.Checked == true)
                        {
                            this.anaKutuphane.diziGuncelle(item.ImageKey, this.eklenecekKutuphane.kutuphanedekiDizi(item.ImageKey));
                        }
                    }
                    else
                    {
                        this.anaKutuphane.diziEkle(this.eklenecekKutuphane.kutuphanedekiDizi(item.ImageKey));
                    }
                }
            }


            if (cbKisileriEkle.Checked)
            {
                foreach (ListViewItem item in this.lvKutuphane.Groups[2].Items) //Kisiler
                {
                    if (item.Checked == false) continue;
                    
                    if (this.anaKutuphane.kutuphanedekiKisilerinIDleri(-1).Contains(item.ImageKey))
                    {
                        if (cbKisileriGuncelle.Checked == true)
                        {
                            this.anaKutuphane.kisiGuncelle(item.ImageKey, this.eklenecekKutuphane.kutuphanedekiKisi(item.ImageKey));
                        }
                    }
                    else
                    {
                        this.anaKutuphane.kisiEkle(this.eklenecekKutuphane.kutuphanedekiKisi(item.ImageKey));
                    }
                }
            }

            //veritabanı güncellemesi

            if (rbVeritabaniBirlestir.Checked)
            {
                this.anaKutuphane.Guncelle(this.eklenecekKutuphane.IDVeritabani);
            }

            if (rbEskiyiSil.Checked)
            {
                this.anaKutuphane.IDVeritabani = this.eklenecekKutuphane.IDVeritabani;
            }

            MessageBox.Show("Seçilenler eklendi", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
