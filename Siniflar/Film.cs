using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace Filmograf.Library
{
    
    [Serializable]
    public class Film : IDisposable
    {
        protected Image afis;                          //Film afişi
        protected string afisURL;
        protected string ad;                           //Film adı
        protected string sure;                           //Film süresi
        protected string imdbPuani;                     //IMDB puanı
        protected string imdbID;                         //IMDB ID
        protected string butce;                         //Filmin yapım bütçesi
        protected string cikisTarihi;                  //Çıkış tarihi

        protected List<string> yonetmenlerID;              //filmin yönetmenlerinin imdb id lerinin tutulacağı liste
        protected List<string> yazarlarID;                //filmin yazarlarının imdb idlerinin tutulacağı liste
        protected List<string> oyuncularID;                 //filmin oyuncularının imdb idlerinin tutulacağı liste
        protected List<string> anahtarKelimeler;                      //plot keywords
        protected List<string> webSayfalari;                    //official websites
        protected List<string> ulkeler;                         //Filmin yapımının geçtiği ülkeler
        protected List<string> diller;                              //filmin hangi dillerde mecvut olduğu
        protected List<IsimUlkeler> digerAdlariUlkelereGore;             //Filmin diğer ülkelerde hangi adlarda olduğu
        protected List<string> cekimYerleri;                    //Filmin çekim yerleri
        protected List<string> turler;                          //Film türü
        protected List<string> ozetler;                     //Olay örgüsü, filmin özeti
        protected List<string> sloganlar;                 //Reklamsal sözler
        protected List<string> abartiGercekler;
        protected List<CikisTarihiYeri> cikisTarihleriYerleri;           //Filmin hangi ülkede hangi tarihde çıktığını saklıyor.
        protected List<FilmKarakteri> karakterler;          //filimde rol alan oyuncuların imdb idlerinin ve filmdeki rol adlarının yer aldığı liste
        protected List<DigerKisi> digerKisiler;           //filmin üretimi sırasında (prodüktör, muzisyen, dublör...) görev alan kişiler
        protected List<Odul> oduller;
        protected List<Sirket> sirketler;
        protected List<string> gercekler;
        protected List<CekimHatasi> hatalar;
        protected List<Replik> replikler;
        protected List<BaglantiKategorisi> referanslar;
        protected List<FilmMuzigi> muzikler;

        public Film()
        {
            afis = (System.Drawing.Image) global::Filmograf.Properties.Resources.varsayilanfilmafisi;
            afisURL = "";
            ad = "";
            sure = "";
            imdbID = "";
            imdbPuani = "";
            cikisTarihi = "";
            oduller = new List<Odul>();
            karakterler = new List<FilmKarakteri>();
            yonetmenlerID = new List<string>();
            yazarlarID = new List<string>();
            oyuncularID = new List<string>();
            digerKisiler = new List<DigerKisi>();
            ozetler = new List<string>();
            turler = new List<string>();
            anahtarKelimeler = new List<string>();
            webSayfalari = new List<string>();
            muzikler = new List<FilmMuzigi>();
            ulkeler = new List<string>(); 
            diller = new List<string>();
            abartiGercekler = new List<string>();
            digerAdlariUlkelereGore = new List<IsimUlkeler>();
            cekimYerleri = new List<string>();
            sloganlar = new List<string>();
            cikisTarihleriYerleri = new List<CikisTarihiYeri>();
            butce = "";
            sirketler = new List<Sirket>();
            gercekler = new List<string>();
            hatalar = new List<CekimHatasi>();
            replikler = new List<Replik>();
            referanslar = new List<BaglantiKategorisi>();
        }

        public FilmKarakteri imdbIDden_KarakterAdi(string imdbID)
        {
            foreach (FilmKarakteri ka in this.karakterler.ToArray())
            {
                if (ka.oyuncuID == imdbID) return ka;
            }
            return null;
        }
        public List<string> digerKisilerinDepartmanlari()
        {
            List<string> departmanlar = new List<string>();
            foreach (DigerKisi dkisi in this.DigerKisiler)
            {
                if (!departmanlar.Contains(dkisi.departmanVeyaGorev))
                    departmanlar.Add(dkisi.departmanVeyaGorev);
            }
            return departmanlar;
        }
        public List<string> odulVerenKurumlar()
        {
            List<string> odulverenkurumlar = new List<string>();

            foreach (Odul item in this.oduller)
            {
                if (odulverenkurumlar.Contains(item.odulVerenKurum))
                    odulverenkurumlar.Add(item.odulVerenKurum);
            }

            return odulverenkurumlar;
        }
        public List<string> sirketTurleriHepsi()
        {
            List<string> turler = new List<string>();

            foreach (Sirket s in this.sirketler)
            {
                foreach (string ss in s.companyTypes)
                {
                    turler.Add(ss);
                }
            }

            return turler;
        }
        public List<string> hatalarString()
        {
            List<string> hatalar = new List<string>();
            foreach (CekimHatasi c in this.hatalar)
            {
                hatalar.Add(c.ToString());
            }
            return hatalar;
        }
        public List<string> repliklerString()
        {
            List<string> replikler = new List<string>();
            foreach (Replik r in this.replikler)
            {
                replikler.Add(r.ToString());
            }
            return replikler;
        }
        public List<string> referanslarString()
        {
            List<string> referanslar = new List<string>();
            foreach (BaglantiKategorisi b in this.referanslar)
            {
                referanslar.Add(b.ToString());
            }
            return referanslar;
        }
        public List<string> muziklerString()
        {
            List<string> muzikler = new List<string>();
            foreach (FilmMuzigi f in this.muzikler)
            {
                muzikler.Add(f.ToString());
            }
            return muzikler;
        }
        public void kopyalaDiziye(Dizi dizi)
        {
            dizi.afis = this.afis;
            dizi.afisURL = this.afisURL; 
            dizi.ad = this.ad; 
            dizi.sure = this.sure;
            dizi.imdbPuani = this.imdbPuani;
            dizi.cikisTarihi = this.cikisTarihi;
            dizi.oduller = this.oduller;

            dizi.yonetmenlerID = this.yonetmenlerID;
            dizi.yazarlarID = this.yazarlarID;
            dizi.oyuncularID = this.oyuncularID;

            dizi.ozetler = this.ozetler;
            dizi.turler = this.turler;
            dizi.anahtarKelimeler = this.anahtarKelimeler;
            dizi.webSayfalari = this.webSayfalari;
            dizi.muzikler = this.muzikler;
            dizi.ulkeler = this.ulkeler;
            dizi.diller = this.diller;
            dizi.abartiGercekler = this.abartiGercekler;
            dizi.digerAdlariUlkelereGore = this.digerAdlariUlkelereGore;
            dizi.cekimYerleri = this.cekimYerleri;
            dizi.sloganlar = this.sloganlar;
            dizi.cikisTarihleriYerleri = this.cikisTarihleriYerleri;
            dizi.butce = this.butce;
            dizi.sirketler = this.sirketler;
            dizi.gercekler = this.gercekler;
            dizi.hatalar = this.hatalar;
            dizi.replikler = this.replikler;
            dizi.referanslar = this.referanslar;
        }
        #region Ozellikler
        public Image Afis 
        { 
            get 
            { 
                return afis; 
            } 
            set
            {
                afis = value; 
            } 
        }
        public string AfisURL
        {
            get { return this.afisURL; }
            set { this.afisURL = value; }
        }
        public long AfisUzunlugu 
        {
            get
            {
                if (afis != null)
                {
                    afis.Save("tmp.bmp");
                    byte[] veri = File.ReadAllBytes("tmp.bmp");
                    File.Delete("tmp.bmp");
                    return veri.Length;
                }
                else
                    return 0;
            } 
        }
        public string Ad 
        { 
            get 
            { 
                return ad; 
            } 
            set 
            { 
                ad = value; 
            } 
        }
        public string CikisTarihi 
        { 
            get 
            { 
                return cikisTarihi; 
            } 
            set 
            { 
                cikisTarihi = value; 
            } 
        }  
        public string Sure 
        { 
            get 
            { 
                return sure; 
            } 
            set 
            { 
                sure = value; 
            } 
        }
        
        /// <summary>
        /// Film Turleri alanında filmin Action, Comedy, Drama...
        /// gibi kategorize adları yer alır.
        /// </summary>
        public List<string> Turler 
        { 
            get 
            { 
                return turler; 
            } 
            set 
            { 
                turler = value; 
            } 
        }
        public string ImdbPuani 
        { 
            get 
            {
                return imdbPuani;
            } 
            set
            { imdbPuani = value;
            } 
        }
        public string ImdbID
        { 
            get 
            { 
                return imdbID; 
            } 
            set
            { 
                imdbID = value; 
            } 
        }
        
        /// <summary>
        /// Bu alanda filme çeşitli kurumlarca verilmiş ödüller saklanmaktadır.
        /// Odul sınıfı türünden nesneleri saklamaktadır.
        /// </summary>
        public List<Odul> Odulleri
        {
            get { return oduller; }
            set { oduller = value; }
        }
        
        /// <summary>
        /// Filim nesnesinde yazarlar, yönetmenler, aktörler 
        /// alanlarında aynı kişiler olabileceğinden bu özellikle
        /// bir filim nesnesinde benzerlerden arınmış tüm kişiler bulunmaktadır.
        /// </summary>
        public List<string> TumKisilerID
        {
            get
            {
                List<string> kisiler = new List<string>();
                List<string> aynilarSilinmis = new List<string>();
                kisiler.AddRange(this.yonetmenlerID);
                kisiler.AddRange(this.yazarlarID);
                kisiler.AddRange(this.oyuncularID);
                kisiler.Sort();
                if (kisiler.Count > 1)
                {
                    for (int i = 1; i < kisiler.Count; i++)
                    {
                        if (!aynilarSilinmis.Contains(kisiler[i])) aynilarSilinmis.Add(kisiler[i]);
                    }
                }
                return aynilarSilinmis;
            }
        }
        
        /// <summary>
        /// Filmi yöneten kişilerin imdb id'lerinin saklandığı alan.
        /// Bu alanda yazarlar alanına eklenen, oyuncular alanına eklenen id'ler de eklenebilir.
        /// </summary>
        public List<string> YonetmenlerID
        {
            get
            {
                return this.yonetmenlerID;
            }
            set
            {
                this.yonetmenlerID = value;
            }
        }

        /// <summary>
        /// Filmin senaristliğini yapan kişilerin id'lerinin saklandığı alan.
        /// Başka kişi ile alakalı bilgi saklayan alanlardaki kişiler buraya da eklenebilir.
        /// </summary>
        public List<string> YazarlarID
        {
            get
            {
                return this.yazarlarID;
            }
            set
            {
                this.yazarlarID = value;
            }
        }
        
        /// <summary>
        /// Filmin oyuncularının id lerinin saklandığı alan.
        /// </summary>
        public List<string> OyuncularID
        {
            get
            {
                return this.oyuncularID;
            }
            set
            {
                this.oyuncularID = value;
            }
        }
        
        /// <summary>
        /// Filmin özel efektlerinin yapımında, prodüktörlüğünde, makyajında görev almış; 
        /// düblörlerin de saklandığı alan.
        /// </summary>
        public List<DigerKisi> DigerKisiler
        {
            get
            {
                return this.digerKisiler;
            }
            set
            {
                this.digerKisiler = value;
            }
        }
        
        /// <summary>
        /// Filmin özeti. Birden fazla olabilir. 
        /// </summary>
        public List<string> Ozetler 
        { 
            get 
            { 
                return ozetler; 
            }
            set 
            { 
                ozetler = value; 
            }
        }   
        
        public List<string> AnahtarKelimeler  
        { 
            get 
            { 
                return anahtarKelimeler; 
            } 
            set 
            { 
                anahtarKelimeler = value; 
            } 
        }
        public List<string> WebSayfalari   
        { 
            get 
            { 
                return webSayfalari; 
            } 
            set 
            { 
                webSayfalari = value; 
            } 
        }
        
        /// <summary>
        /// Filmin gectigi ülkeler
        /// </summary>
        public List<string> Ulkeler 
        { 
            get 
            { 
                return ulkeler; 
            }  
            set 
            { 
                ulkeler = value; 
            } 
        }
        
        public List<string> Diller 
        { 
            get 
            { 
                return diller; 
            } 
            set 
            { 
                diller = value; 
            } 
        }
        
        /// <summary>
        /// Bu alanda filmin oynadığı diğer ülkelerde hangi başka adlarda bulunduğu vardır.
        /// Ad ve Ülke olarak devam eder.
        /// </summary>
        public List<IsimUlkeler> DigerAdlariUlkelereGore 
        {
            get 
            { 
                return digerAdlariUlkelereGore; 
            } 
            set 
            { 
                digerAdlariUlkelereGore = value; 
            } 
        }
        
        /// <summary>
        /// Sadece filmin diğer adlari.
        /// </summary>
        public List<string> DigerAdlariSadeceMetin
        {
            get
            {
                List<string> isimler = new List<string>();
                foreach (IsimUlkeler i in this.digerAdlariUlkelereGore)
                    isimler.Add(i.isim);
                return isimler;
            }
        }
        
        public List<string> CekimYerleri
        {
            get
            {
                return cekimYerleri;
            }
            set
            {
                cekimYerleri = value;
            }
        }
        public string Butce 
        { 
            get 
            { 
                return butce; 
            } 
            set 
            { 
                butce = value; 
            } 
        }       
        
        /// <summary>
        /// Bu listede filmdeki oyuncuların id leri ve oyuncuların karakterlerinin bilgileri bulunmaktadır.
        /// </summary>
        public List<FilmKarakteri> Karakterler
        {
            get
            {
                return this.karakterler;
            }
            set
            {
                this.karakterler = value;
            }
        }
        
        public List<string> Sloganlar
        {
            get { return sloganlar; }
            set { sloganlar = value; }
        }
        public List<CikisTarihiYeri> CikisTarihleriYerleri
        {
            get { return cikisTarihleriYerleri; }
            set { cikisTarihleriYerleri = value; }
        }
        public List<Sirket> Sirketler
        {
            get { return sirketler; }
            set { sirketler = value; }
        }
        public List<string> Gercekler 
        { 
            get 
            { 
                return gercekler; 
            }
            set
            {
            gercekler = value;
            }
        }
        public List<CekimHatasi> Hatalar
        {
            get
            {
                return hatalar;
            }
            set
            {
                hatalar = value;
            }
        }
        public List<Replik> Replikler
        {
            get
            {
                return this.replikler;
            }
            set
            {
                this.replikler = value;
            }
        }
        public List<string> AbartiGercekler
        {
            get
            {
                return abartiGercekler;
            }
            set
            {
                abartiGercekler = value;
            }
        }
        
        /// <summary>
        /// Bu listede filmde başka filmlere yapılan, başka filmlerde bu filme yapılan referanslar 
        /// kategoriksel olarak saklanmaktadır.
        /// </summary>
        public List<BaglantiKategorisi> Referanslar
        {
            get
            {
                return this.referanslar;
            }
            set 
            {
                this.referanslar = value;
            }
        }
        
        public List<FilmMuzigi> Muzikler
        {
            get
            {
                return this.muzikler;
            }
            set
            {
                this.muzikler = value;
            }
        }
        #endregion

         ~Film()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposeDurumu)
        {
            if (disposeDurumu == true)
            {
                this.afis.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
