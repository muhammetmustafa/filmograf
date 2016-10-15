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
    public partial class f_Istatistikler : Form
    {
        Kutuphane kutuphane;

        public f_Istatistikler(Kutuphane kutuphane)
        {
            InitializeComponent();
            this.kutuphane = kutuphane;
        }

        private void f_Istatistikler_Load(object sender, EventArgs e)
        {
            if (this.kutuphane != null)
            {
                lFilmSayisi.Text = kutuphane.Filmler.Count.ToString() + " Adet";
                lDiziSayisi.Text = kutuphane.Diziler.Count.ToString() + " Adet";
                lKisiSayisi.Text = kutuphane.Kisiler.Count.ToString() + " Adet";

                int toplamFilmSuresi = 0;
                foreach (Film f in kutuphane.Filmler)
                    toplamFilmSuresi += Convert.ToInt32(f.Sure);
                lToplamFilmSuresi.Text = toplamFilmSuresi.ToString() + " Dakika";

                int toplamDiziSuresi = 0;
                foreach (Dizi f in kutuphane.Diziler)
                {
                    int tumBolumlerSayisi = 1;
                    tumBolumlerSayisi = Convert.ToInt32(f.Bolumler.Count);
                    toplamDiziSuresi += Convert.ToInt32(f.Sure)*tumBolumlerSayisi;
                }
                lToplamDiziSuresi.Text = toplamDiziSuresi.ToString() + " Dakika";

                lToplamSure.Text = (toplamFilmSuresi + toplamDiziSuresi).ToString() + " Dakika";


                //En uzun süreli filmin bulunması
                if (this.kutuphane.Filmler.Count > 0)
                {
                    Film enUzunFilm = null;
                    int enYuksekSure = 0;
                    enUzunFilm = this.kutuphane.Filmler[0];
                    enYuksekSure = Convert.ToInt32(this.kutuphane.Filmler[0].Sure);
                    
                    for (int i = 1; i < this.kutuphane.Filmler.Count; i++)
                    {
                        if (Convert.ToInt32(this.kutuphane.Filmler[i].Sure) > enYuksekSure)
                        {
                            enUzunFilm = this.kutuphane.Filmler[i];
                            enYuksekSure = Convert.ToInt32(this.kutuphane.Filmler[i].Sure);
                        }
                    }

                    if ((enUzunFilm != null) && (enYuksekSure != 0))
                    {
                        this.llEnUzunFilm.Text = enUzunFilm.Ad + " (" + enUzunFilm.Sure + " Dakika" + ")";
                        this.llEnUzunFilm.Name = enUzunFilm.ImdbID;
                    }
                }

                //En yüksek imdb puanli filmin bulunması
                if (this.kutuphane.Filmler.Count > 0)
                {
                    Film enUzunFilm = null;
                    double enYuksekPuan = 0;
                    enUzunFilm = this.kutuphane.Filmler[0];

                    string imdbPuani = "";
                    
                    imdbPuani = this.kutuphane.Filmler[0].ImdbPuani;
                    if (imdbPuani.Contains("."))
                        imdbPuani = imdbPuani.Replace('.', ',');
                    enYuksekPuan = ((int)Convert.ToDouble(imdbPuani)*100);

                    for (int i = 1; i < this.kutuphane.Filmler.Count; i++)
                    {
                        imdbPuani = this.kutuphane.Filmler[i].ImdbPuani;
                        if (imdbPuani.Contains("."))
                            imdbPuani = imdbPuani.Replace('.', ',');

                        if ((int)Convert.ToDouble(imdbPuani) * 100 > enYuksekPuan)
                        {
                            enUzunFilm = this.kutuphane.Filmler[i];
                            enYuksekPuan = Convert.ToDouble(imdbPuani);
                        }
                    }

                    if ((enUzunFilm != null) && (enYuksekPuan != 0))
                    {
                        this.llEnYuksekIMDBFilm.Text = enUzunFilm.Ad + " (" + enUzunFilm.ImdbPuani + ")";
                        this.llEnYuksekIMDBFilm.Name = enUzunFilm.ImdbID;
                    }
                }

                //en uzun süreli dizinin bulunması
                if (this.kutuphane.Diziler.Count > 0)
                {
                    Dizi enUzunDizi = null;
                    int enUzunSure = 0;
                    int iDiziSuresi = Convert.ToInt32(this.kutuphane.Diziler[0].Sure);
                    int iDiziBolumSayisi = this.kutuphane.Diziler[0].Bolumler.Count;

                    enUzunDizi = this.kutuphane.Diziler[0];
                    enUzunSure = iDiziSuresi*iDiziBolumSayisi;

                    for (int i = 1; i < this.kutuphane.Diziler.Count; i++)
                    {
                        iDiziBolumSayisi = this.kutuphane.Diziler[0].Bolumler.Count;
                        iDiziSuresi = Convert.ToInt32(this.kutuphane.Diziler[i].Sure) * iDiziBolumSayisi;
                        if (iDiziSuresi > enUzunSure)
                        {
                            enUzunDizi = this.kutuphane.Diziler[i];
                            enUzunSure = iDiziSuresi;
                        }
                    }

                    if ((enUzunDizi != null) && (enUzunSure != 0))
                    {
                        this.llEnYuksekIMDBDizi.Text = enUzunDizi.Ad + " (" + enUzunDizi.Sure + " Dakika" + ")";
                        this.llEnYuksekIMDBDizi.Name = enUzunDizi.ImdbID;
                    }
                }

                //en yüksek imdb puanina sahip dizinin bulunması
                if (this.kutuphane.Diziler.Count > 0)
                {
                    Dizi enUzunDizi = null;
                    double enYuksekPuan = 0;
                    enUzunDizi = this.kutuphane.Diziler[0];

                    string imdbPuani = "";
                    imdbPuani = this.kutuphane.Diziler[0].ImdbPuani;
                    if (imdbPuani.Contains("."))
                        imdbPuani = imdbPuani.Replace('.', ',');
                    enYuksekPuan = ((int)Convert.ToDouble(imdbPuani) * 100);

                    for (int i = 1; i < this.kutuphane.Diziler.Count; i++)
                    {
                        imdbPuani = this.kutuphane.Diziler[i].ImdbPuani;
                        if (imdbPuani.Contains("."))
                            imdbPuani = imdbPuani.Replace('.', ',');

                        if ((int)Convert.ToDouble(imdbPuani) * 100 > enYuksekPuan)
                        {
                            enUzunDizi = this.kutuphane.Diziler[i];
                            enYuksekPuan = Convert.ToDouble(imdbPuani);
                        }
                    }

                    if ((enUzunDizi != null) && (enYuksekPuan != 0))
                    {
                        this.llEnUzunDizi.Text = enUzunDizi.Ad + " (" + enUzunDizi.ImdbPuani + ")";
                        this.llEnUzunDizi.Name = enUzunDizi.ImdbID;
                    }
                }

            }
        }
    }
}
