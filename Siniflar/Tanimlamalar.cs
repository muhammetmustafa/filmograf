using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMC_Filmograf.Library
{
    public enum Genre //Film Türleri
    {
        Action, Adventure, Animation, Biography, Comedy, Crime, Documentary, Drama,
        Family, Fantasy, FilmNoir, GameShow, History, Horror, Music, Musical,
        Mystery, News, RealityTV, Romance, SciFi, Sport, TalkShow, Thriller, War, Western
    }
    public enum SirketTuru
    {
        Production,
        Distributor,
        SpecialEffects,
        Other
    }
    public enum KisiUnvani
    {
        Diger,
        Yonetmen,
        Yazar,
        Oyuncu
    }
    public enum KisiDuzenlemeModu
    {
        KisiEkle,
        KisiDuzenle,
        OyuncuKarakterEkle
    }
    public enum OdulSonucu
    {
        Kazandi,
        AdayGosterildi
    }

    [Serializable]
    public class isimID
    {
        public string id;
        public string isim;
        public isimID()
        {
            this.isim = "";
            this.id = "";
        }
        public isimID(string id, string isim)
        {
            this.isim = isim;
            this.id = id;
        }
        public override string ToString()
        {
            return this.isim;
        }
    }

    public class IMDBAramaKategorisi
    {
        public string kategori;
        public List<isimID> isimlerSonuclar;

        public IMDBAramaKategorisi()
        {
            this.kategori = "";
            isimlerSonuclar = new List<isimID>();
        }
    }

    [Serializable]
    public class FilmKarakteri
    {
        /// <summary>
        /// Karakteri gerçekleyen oyuncunun idsi
        /// </summary>
        public string oyuncuID;
        /// <summary>
        /// oyuncuID sine sahip oyuncu tarafından oynanılan karakterler.
        /// </summary>
        public List<isimID> karakterler;
        /// <summary>
        /// karakter adlarından sonraki (voice), (uncredited), (as Someone Else) gibi alanlar için.
        /// </summary>
        public string aciklama; 
        
        public FilmKarakteri()
        {
            this.oyuncuID = "";
            this.karakterler = new List<isimID>();
            this.aciklama = "";
        }

        public string karakterAdlariBirlesik(string birlestirici)
        {
            string birlesik = "";

            if (this.karakterler.Count > 0)
            {
                birlesik += this.karakterler[0].isim;
                int i = 0;
                foreach (isimID s in this.karakterler)
                {
                    i++; if (i == 1) continue;
                    birlesik += birlestirici + s.isim;
                }
            }

            return birlesik;
        }
    }

    [Serializable]
    public class DigerKisi
    {
        public string kisiID;
        public string departmanVeyaGorev; //emun haline getir
        public string gorevAciklamasi; //tüm kişiler için geçerli olmayabilir.

        public DigerKisi()
        {
            this.kisiID = "";
            this.departmanVeyaGorev = "";
            this.gorevAciklamasi = "";
        }
    }

    [Serializable]
    public class CikisTarihiYeri
    {
        public string releaseCountry;
        public DateTime releaseDate;

        public CikisTarihiYeri()
        {
            this.releaseCountry = "";
            this.releaseDate = new DateTime();
        }
    }

    [Serializable]
    public class Sirket
    {
        public string companyID;
        public string companyName;
        public List<string> companyTypes;

        public Sirket()
        {
            this.companyID = "";
            this.companyName = "";
            this.companyTypes = new List<string>();
        }

    }

    [Serializable]
    public class IsimUlkeler
    {
        public string isim;
        public List<string> ulkeler;

        public IsimUlkeler()
        {
            this.isim = "";
            this.ulkeler = new List<string>();
        }

        public IsimUlkeler(string isim, List<string> ulkeler)
        {
            this.isim = isim;
            this.ulkeler = ulkeler;
        }

    }

    [Serializable]
    public class CekimHatasi
    {
        public string hataBasligi;
        public string metin;

        public CekimHatasi()
        {
            this.hataBasligi = "";
            this.metin = "";
        }

        public CekimHatasi(string hataBasligi, string metin)
        {
            this.hataBasligi = hataBasligi;
            this.metin = metin;
        }

        public string ToString()
        {
            return this.hataBasligi + "\x000A" + this.metin;
        }
    }

    [Serializable]
    public class Replik
    {
        [Serializable]
        public class KisiSoz
        {
            public string kisiID;
            public string soz;

            public KisiSoz()
            {
                this.kisiID = "";
                this.soz = "";
            }

            public KisiSoz(string kisiID, string soz)
            {
                this.kisiID = kisiID;
                this.soz = soz;
            }
        }

        public string replikID;
        public List<KisiSoz> alintilar;

        public Replik()
        {
            this.replikID = "";
            this.alintilar = new List<KisiSoz>();
        }

        /// <summary>
        /// he aynısı
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string rep = "";
            foreach (Replik.KisiSoz soz in this.alintilar)
            {
                rep += ">" + soz.kisiID + "<" + ": ";
                rep += soz.soz + "\x000A";
            }
            rep += "\x000A";
            return rep;
        }
    }

    [Serializable]
    public class BaglantiKategorisi
    {
        public string kategoriAdi;
        public Dictionary<string, string> filmID_Aciklama;

        public BaglantiKategorisi()
        {
            this.kategoriAdi = "";
            this.filmID_Aciklama = new Dictionary<string, string>();
        }

        public void baglantiEkle(string filmID, string aciklama = "")
        {
            this.filmID_Aciklama.Add(filmID, aciklama);
        }

        /// <summary>
        /// Elemanı stringe çevirir anında.
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            foreach (string s in this.filmID_Aciklama.Keys)
            {
                string refe = "";
                refe += this.kategoriAdi + "\x000A";
                refe += ">" + s + "<";
                refe += this.filmID_Aciklama[s];
                refe += "\x000A";
                return refe;
            }
            return "";
        }
    }

    [Serializable]
    public class FilmMuzigi
    {
        public string muzikAdi;
        public string metin;

        public FilmMuzigi()
        {
            this.muzikAdi = "";
            this.metin = "";
        }

        /// <summary>
        /// Stringci geldi hanımlar
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            string muz = "";
            muz += this.muzikAdi + "\x000A";
            muz += this.metin;
            muz = muz.Replace("<br>", "\x000A");
            return muz;
        }
    }

    [Serializable]
    public class KisiBolumSayisiYillari
    {
        public string kisiID;
        public string bolumSayisi;
        public string gorevYillari;

        public KisiBolumSayisiYillari()
        {
            this.kisiID = "";
            this.bolumSayisi = "";
            this.gorevYillari = "";
        }
    }

    public class KategoriKisi
    {
        public object deger;
        public string tur;

        public KategoriKisi()
        {
            deger = ""; tur = "";
        }

        public KategoriKisi(object deger, string tur)
        {
            this.deger = deger; this.tur = tur;
        }
    }

    public class IsimlerAciklama
    {
        public string aciklama;
        public List<isimID> isimler;

        public IsimlerAciklama()
        {
            this.aciklama = "";
            this.isimler = new List<isimID>();
        }
    }

    [Serializable]
    public class BaslikUyusmadiHatasi : Exception
    {
        public BaslikUyusmadiHatasi() { }
        public BaslikUyusmadiHatasi(string message) : base(message) { }
        public BaslikUyusmadiHatasi(string message, Exception inner) : base(message, inner) { }
        protected BaslikUyusmadiHatasi(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class SayfaYokHatasi : Exception
    {
      public SayfaYokHatasi() { }
      public SayfaYokHatasi( string message ) : base( message ) { }
      public SayfaYokHatasi( string message, Exception inner ) : base( message, inner ) { }
      protected SayfaYokHatasi( 
	    System.Runtime.Serialization.SerializationInfo info, 
	    System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
    }

    [Serializable]
    public class KisiEvlilik
    {
        public string esiID;
        public string evlilikTarihi;
        public string bosanmaTarihi;
        public string evlilikDurumu;
        public string cocukSayisi;

        public KisiEvlilik()
        {
            this.esiID = "";
            this.evlilikTarihi = "";
            this.bosanmaTarihi = "";
            this.evlilikDurumu = "";
            this.cocukSayisi = "";
        }
    }

    [Serializable]
    public class IDKazandigiPara
    {
        public string filmID;
        public string paraMiktari;

        public IDKazandigiPara()
        {
            this.filmID = "";
            this.paraMiktari = "";
        }

        public IDKazandigiPara(string filmID, string paraMiktari)
        {
            this.filmID = filmID;
            this.paraMiktari = paraMiktari;
        }
    }
    public class Sabitler{
        public const string RegexFilmBasligi = "(tt\\d{7})";
        public const string RegexKisiBasligi = "(nm\\d{7})";
        public const string RegexFilmKisiBasligi = "((?:tt|nm)\\d{7})";
        public const string RegexKarakterBasligi = "(ch\\d{7})";
        public const string RegexSirketBasligi = "(co\\d{7})";
        public const string RegexTumBasliklar = "((?:tt|nm|ch|co)\\d{7})";

        public const string RegexHTMLLinki = "<a\\s+href=\"([^<>])\">(.*?)</a>";


        /// <summary>
        /// "MMC Filmograf"
        /// </summary>
        public const string ProgramBasligi = "MMC Filmograf";

        /// <summary>
        /// "http://www.imdb.com/title/"
        /// </summary>
        public const string IMDBBasligi = "http://www.imdb.com/title/";

        /// <summary>
        /// "http://www.imdb.com/name/"
        /// </summary>
        public const string IMDBKisisi = "http://www.imdb.com/name/";

        /// <summary>
        /// "Filmograf Film Dosyası (*.ffd)|*.ffd"
        /// </summary>
        public const string FilmografFilmDosyasi = "Filmograf Film Dosyası (*.ffd)|*.ffd";

        /// <summary>
        /// "Filmograf Kütüphane Dosyası (*.fkh)|*.fkh"
        /// </summary>
        public const string FilmografKutuphaneDosyasi = "Filmograf Kütüphane Dosyası (*.fkh)|*.fkh";

        /// <summary>
        /// "Filmograf Kişi Dosyası (*.fkd)|*.fkd"
        /// </summary>
        public const string FilmografKisiDosyasi = "Filmograf Kişi Dosyası (*.fkd)|*.fkd";

        /// <summary>
        /// "Filmograf Çoklu Kişi Dosyası (*.fckd)|*.fckd"
        /// </summary>
        public const string FilmografCokluKisiDosyasi = "Filmograf Çoklu Kişi Dosyası (*.fckd)|*.fckd";

        /// <summary>
        /// "MMC Filmograf Kütüphane Veritabanı (*.fkv)|*.fkv"
        /// </summary>
        public const string FilmografKutuphaneVeritabaniDosyasi = "MMC Filmograf Kütüphane Veritabanı (*.fkv)|*.fkv";

        public static string[] burclarIngilizce = new string[] 
            {"Aries", 
            "Taurus", 
            "Gemini",
            "Cancer",
            "Leo", 
            "Virgo", 
            "Libra", 
            "Scorpio", 
            "Sagittarius", 
            "Capricorn", 
            "Aquarius", 
            "Pisces"};

        public static string[] burclarTurkce = new string[] 
            {"Koç", 
            "Boğa", 
            "İkizler",
            "Yengeç",
            "Aslan", 
            "Başak", 
            "Terazi", 
            "Akrep", 
            "Yay", 
            "Oğlak", 
            "Kova", 
            "Balık"};
    }
}
