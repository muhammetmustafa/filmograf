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
    public partial class f_FilmlerListesi : Form
    {
        Kutuphane kutuphane;
        List<Film> filmler;
        List<Dizi> diziler;

        public f_FilmlerListesi(Kutuphane kutuphane, List<Film> filmler = null, List<Dizi> diziler = null)
        {
            InitializeComponent();
            this.kutuphane = kutuphane;

            if (filmler != null)
            {
                this.filmler = filmler;
            }

            if (diziler != null)
            {
                this.diziler = diziler;
            }
        }

        private int diziIndeksi(string id)
        {
            int indeks = -1;

            if (diziler != null)
            {
                foreach (Dizi f in this.diziler)
                {
                    indeks++;
                    if (f.ImdbID == id)
                        return indeks;
                }
            }

            return indeks;
        }

        private int filmIndeksi(string id)
        {
            int indeks = -1;

            if (filmler != null)
            {
                foreach (Film f in this.filmler)
                {
                    indeks++;
                    if (f.ImdbID == id)
                        return indeks;
                }
            }

            return indeks;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.lvKutuphane.CheckedItems)
            {
                foreach (Film f in filmler)
                {
                    if (item.ImageKey == f.ImdbID)
                    {
                        if (this.kutuphane.filmKutuphanedemi(item.ImageKey))
                        {
                            if (this.filmler != null)
                            {
                                this.kutuphane.filmGuncelle(item.ImageKey, f);
                            }
                        }
                        else 
                        {
                            this.kutuphane.filmEkle(f);
                        }
                        break; // id eğer filmlerin arasındaysa bulup işlemini yaptıktan sonra döngüyü kır.
                    }
                }
                foreach (Dizi f in diziler)
                {
                    if (item.ImageKey == f.ImdbID)
                    {
                        if (this.kutuphane.diziKutuphanedemi(item.ImageKey))
                        {
                            if (this.diziler != null)
                            {
                                this.kutuphane.diziGuncelle(item.ImageKey, f);
                            }
                        }
                        else
                        {
                            this.kutuphane.diziEkle(f);
                        }
                        break; // id eğer filmlerin arasındaysa bulup işlemini yaptıktan sonra döngüyü kır.
                    }
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_FilmlerListesi_Load(object sender, EventArgs e)
        {
            if (this.filmler != null)
            {
                if (this.filmler.Count != 0)
                {
                    foreach (Film f in this.filmler)
                    {
                        if (this.kutuphane.kutuphanedekiFilmlerinIDleri().Contains(f.ImdbID))
                        {
                            this.lvKutuphane.Items.Add(f.ImdbID, "", f.ImdbID).SubItems.AddRange(new string[] { f.Ad, "Aynı ID ile kütüphanede mevcut" });
                        }
                        else
                        {
                            this.lvKutuphane.Items.Add(f.ImdbID, "", f.ImdbID).SubItems.AddRange(new string[] { f.Ad, "Kütüphanede yok" });
                            this.lvKutuphane.Items[f.ImdbID].Checked = true;
                        }
                    }
                }
            }

            if (this.diziler != null)
            {
                if (this.diziler.Count != 0)
                {
                    foreach (Dizi f in this.diziler)
                    {
                        if (this.kutuphane.kutuphanedekiDizilerinIDleri().Contains(f.ImdbID))
                        {
                            this.lvKutuphane.Items.Add(f.ImdbID, "", f.ImdbID).SubItems.AddRange(new string[] { f.Ad, "Aynı ID ile kütüphanede mevcut" });
                        }
                        else
                        {
                            this.lvKutuphane.Items.Add(f.ImdbID, "", f.ImdbID).SubItems.AddRange(new string[] { f.Ad, "Kütüphanede yok" });
                            this.lvKutuphane.Items[f.ImdbID].Checked = true;
                        }
                    }
                }
            }
        }


    }
}
