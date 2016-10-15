using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filmograf.Library
{
    [Serializable]
    public class Dizi : Film
    {
        /// <summary>
        /// Dizinin sezon ve bölümlerini saklamak için
        /// </summary>
        List<DiziBolumu> bolumler;

        /// <summary>
        /// Oyuncuların dizide kaç bölümde hangi yıllar arasında rol aldıklarını saklamak için
        /// </summary>
        List<KisiBolumSayisiYillari> oyuncularRolSayilari;

        /// <summary>
        /// Diger ekip elemanlarının kaç bölümde hangi yıllar arasında görev aldıklarını saklamak için.
        /// </summary>
        List<KisiBolumSayisiYillari> digerlerininRolSayilari;

        string oynadigiYillar;

        public Dizi()
            : base()
        {
            bolumler = new List<DiziBolumu>();
            oyuncularRolSayilari = new List<KisiBolumSayisiYillari>();
            digerlerininRolSayilari = new List<KisiBolumSayisiYillari>();
            oynadigiYillar = "";
        }

        public DiziBolumu bolum(string sezon, string bolum)
        {
            foreach (DiziBolumu d in this.bolumler)
            {
                if ((d.SezonNumarasi == sezon) && (d.BolumNumarasi == bolum))
                {
                    return d;
                }
            }
            return null;
        }

        public List<string> sezonlarString()
        {
            List<string> sezonlar = new List<string>();

            foreach (DiziBolumu d in this.bolumler)
            {
                if (!sezonlar.Contains(d.SezonNumarasi))
                    sezonlar.Add(d.SezonNumarasi);
            }

            return sezonlar;
        }
        public List<string> bolumlerString(string sezon)
        {
            List<string> bolumlerString = new List<string>();

            foreach (DiziBolumu d in this.bolumler)
            {
                if (d.SezonNumarasi == sezon)
                {
                    if (!bolumlerString.Contains(d.BolumNumarasi))
                        bolumlerString.Add(d.BolumNumarasi);
                }
            }

            return bolumlerString;
        }

        public string oyuncuRolSayisi(string imdbID)
        {
            string rolSayisi = "";

            foreach (KisiBolumSayisiYillari k in this.oyuncularRolSayilari)
            {
                if (k.kisiID == imdbID)
                    rolSayisi = k.bolumSayisi;
            }

            if (rolSayisi == "") rolSayisi = "Bilinmiyor";

            return rolSayisi;
        }
        public string oyuncuRolYillari(string imdbID)
        {
            string rolYillari = "";

            foreach (KisiBolumSayisiYillari k in this.oyuncularRolSayilari)
            {
                if (k.kisiID == imdbID)
                    rolYillari = k.gorevYillari;
            }

            return rolYillari;
        }
        public string digerKisiRolSayisi(string imdbID)
        {
            string rolSayisi = "";

            foreach (KisiBolumSayisiYillari k in this.digerlerininRolSayilari)
            {
                if (k.kisiID == imdbID)
                    rolSayisi = k.bolumSayisi;
            }

            if (rolSayisi == "") rolSayisi = "Bilinmiyor";

            return rolSayisi;
        }
        public string digerKisiRolYillari(string imdbID)
        {
            string rolYillari = "";

            foreach (KisiBolumSayisiYillari k in this.digerlerininRolSayilari)
            {
                if (k.kisiID == imdbID)
                    rolYillari = k.gorevYillari;
            }

            return rolYillari;
        }

        public void kopyalaFilme(Film film)
        {
            film.Afis = this.afis;
            film.AfisURL = this.afisURL;
            film.Ad = this.ad;
            film.Sure = this.sure;
            film.ImdbID = this.imdbID;
            film.ImdbPuani = this.imdbPuani;
            film.CikisTarihi = this.cikisTarihi;
            film.Odulleri = this.oduller;
            film.Karakterler = this.karakterler;
            film.YonetmenlerID = this.yonetmenlerID;
            film.YazarlarID = this.yazarlarID;
            film.OyuncularID = this.oyuncularID;
            film.DigerKisiler = this.digerKisiler;
            film.Ozetler = this.ozetler;
            film.Turler = this.turler;
            film.AnahtarKelimeler = this.anahtarKelimeler;
            film.WebSayfalari = this.webSayfalari;
            film.Muzikler = this.muzikler;
            film.Ulkeler = this.ulkeler;
            film.Diller = this.diller;
            film.AbartiGercekler = this.abartiGercekler;
            film.DigerAdlariUlkelereGore = this.digerAdlariUlkelereGore;
            film.CekimYerleri = this.cekimYerleri;
            film.Sloganlar = this.sloganlar;
            film.CikisTarihleriYerleri = this.cikisTarihleriYerleri;
            film.Butce = this.butce;
            film.Sirketler = this.sirketler;
            film.Gercekler = this.gercekler;
            film.Hatalar = this.hatalar;
            film.Replikler = this.replikler;
            film.Referanslar = this.referanslar;
        }


        public List<DiziBolumu> Bolumler
        {
            get { return this.bolumler; }
            set { this.bolumler = value; }
        }

        public List<KisiBolumSayisiYillari> OyuncuRolSayilari
        {
            get { return this.oyuncularRolSayilari; }
            set { this.oyuncularRolSayilari = value; }
        }

        public List<KisiBolumSayisiYillari> DigerlerininRolSayilari
        {
            get { return this.digerlerininRolSayilari; }
            set { this.digerlerininRolSayilari = value; }
        }

        public string OynadigiYillar
        {
            get { return this.oynadigiYillar; }
            set { this.oynadigiYillar = value; }
        }
    }
}
