using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Filmograf.Library
{
    [Serializable]
    public class Kisi : IDisposable
    {
        #region Degiskenler
        Image resim;
        string resimURL;

        string imdbID;
        string isim;
        string dogumAdi;
        string takmaAdi;
        string dogumYeri;
        string biyografi;
        string boyUzunlugu;
        string dogumTarihi;
        string burc;
        bool cinsiyet;
        List<string> hakkindakiGercekler;
        List<string> kisiselSozler;
        List<string> resmiWebSayfalari;
        int unvan;

        List<IDKazandigiPara> kazandigiParalar;

        List<KisiEvlilik> yaptigiEvlilikler;

        #endregion

        public Kisi(string imdbID)
        {
            this.resim = (System.Drawing.Image)global::Filmograf.Properties.Resources.Kisi;
            this.resimURL = "";

            this.isim = "";
            this.imdbID = imdbID;
            this.dogumAdi = "";
            this.takmaAdi = "";
            this.dogumTarihi = "";
            this.burc = "";

            this.yaptigiEvlilikler = new List<KisiEvlilik>();

            this.resmiWebSayfalari = new List<string>();
            this.hakkindakiGercekler = new List<string>();
            this.kisiselSozler = new List<string>();
            this.dogumYeri = "";
            this.boyUzunlugu = "";
            this.cinsiyet = true;
            this.biyografi = "";
            this.unvan = (int)KisiUnvani.Diger;

            this.kazandigiParalar = new List<IDKazandigiPara>();
        }

        public Kisi(string isim, int unvan, string imdbID)
        {
            this.resim =  (System.Drawing.Image)global::Filmograf.Properties.Resources.Kisi;
            this.resimURL = "";

            this.isim = isim;
            this.imdbID = imdbID;
            this.dogumAdi = "";
            this.burc = "";

            this.yaptigiEvlilikler = new List<KisiEvlilik>();

            this.hakkindakiGercekler = new List<string>();
            this.kisiselSozler = new List<string>();
            this.takmaAdi = "";
            this.dogumTarihi = "";
            this.dogumYeri = "";
            this.resmiWebSayfalari = new List<string>();
            this.boyUzunlugu = "";
            this.cinsiyet = true;
            this.biyografi = "";
            this.unvan = unvan;

            this.kazandigiParalar = new List<IDKazandigiPara>();
        }

        public void kisiKopyala(Kisi hedefKisi)
        {
            if (hedefKisi == null) return;

            hedefKisi.resim = this.resim;
            hedefKisi.resimURL = this.resimURL;

            hedefKisi.isim = this.isim;
            hedefKisi.imdbID = this.imdbID;
            hedefKisi.dogumTarihi = this.dogumTarihi;
            hedefKisi.burc = this.burc;

            hedefKisi.dogumAdi = this.dogumAdi;
            hedefKisi.takmaAdi = this.takmaAdi;
            hedefKisi.hakkindakiGercekler = this.hakkindakiGercekler;
            hedefKisi.kisiselSozler = this.kisiselSozler;

            hedefKisi.yaptigiEvlilikler = this.yaptigiEvlilikler;

            hedefKisi.dogumYeri = this.dogumYeri;
            hedefKisi.resmiWebSayfalari = this.resmiWebSayfalari;
            hedefKisi.boyUzunlugu = this.boyUzunlugu;
            hedefKisi.cinsiyet = this.cinsiyet;
            hedefKisi.biyografi = this.biyografi;
            hedefKisi.unvan = this.unvan;

            hedefKisi.kazandigiParalar = this.kazandigiParalar;
        }

        #region Ozellikler
        public Image Resim { get { return resim; } set { resim = value; } }
        public string ResimURL { get { return resimURL; } set { resimURL = value; } }
        public long ResimVeriBoyutu { 
            get 
            {
                if (resim != null)
                {
                    resim.Save("tmp.bmp");
                    byte[] veri = File.ReadAllBytes("tmp.bmp");
                    File.Delete("tmp.bmp");
                    return veri.Length;
                }
                else
                    return 0;
            } 
        }
        
        public string Isim { get { return isim; } set { isim = value; } }
        public string ImdbID { get { return imdbID; } set { imdbID = value; } }
        public string DogumAdi { get { return dogumAdi; } set { dogumAdi = value; } }
        public string TakmaAdi { get { return takmaAdi; } set { takmaAdi = value; } }
        public string Burc { get { return burc; } set { burc = value; } }
        public string DogumTarihi { get { return dogumTarihi; } set { dogumTarihi = value; } }
        public string DogumYeri { get { return dogumYeri; } set { dogumYeri = value; } }
        public string BoyUzunlugu { get { return boyUzunlugu; } set { boyUzunlugu = value; } }
        public string Biyografi { get { return biyografi; } set { biyografi = value; } }
        public bool Cinsiyet { get { return cinsiyet; } set { cinsiyet = value; } }
        public int Unvan { get { return this.unvan; } set { this.unvan = value; } }

        public List<KisiEvlilik> YaptigiEvlilikler { get { return yaptigiEvlilikler; } set { yaptigiEvlilikler = value; } }

        public List<string> ResmiWebSayfalari { get { return resmiWebSayfalari; } set { resmiWebSayfalari = value; } }
        public List<string> KisiselSozler { get { return kisiselSozler; } set { kisiselSozler = value; } }
        public List<string> HakkindakiGercekler { get { return hakkindakiGercekler; } set { hakkindakiGercekler = value; } }

        public List<IDKazandigiPara> KazandigiParalar { get { return this.kazandigiParalar; } set { this.kazandigiParalar = value; } }
        #endregion

        ~Kisi()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposeDurumu)
        {
            if (disposeDurumu == true)
            {
                this.resim.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
