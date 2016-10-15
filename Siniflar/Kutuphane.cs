using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Drawing;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace MMC_Filmograf.Library
{   
    [Serializable]
    public class Kutuphane : IDisposable
    {
        #region Değişken/Delegeler
        string dosyaYolu;
        string kutuphaneAdi;

        List<Film> filmler;
        List<Kisi> kisiler;
        List<Dizi> diziler;


        [NonSerialized]
        public Delegate kutuphaneDegisikligiCagirici;

        ///Bu değişken kütüphaneye eklenen ve nesnesi oluşturulmamış kişilerin imdb idlerinin
        ///ve isimlerinin saklandığı sözlüktür. Eklenen filmde kütüphanede nesnesi olmayan kişilerin 
        ///sadece imdbidleri olduğundan isim için bu sözlüğe başvurulur.
        ///Kişinin nesnesi oluşturulursa bu sözlükten kaydı silinir.
        SortedDictionary<string, string> IDIsimVeritabani; 
        #endregion

        public Kutuphane(string dosyaAdi, string kutuphaneAdi)
        {
            this.dosyaYolu = dosyaAdi;
            this.kutuphaneAdi = kutuphaneAdi;
            filmler = new List<Film>();
            kisiler = new List<Kisi>();
            diziler = new List<Dizi>();
            IDIsimVeritabani = new SortedDictionary<string, string>();
        }

        #region Filmler

        public void filmEkle(Film film, bool otomotikEklendi = false)
        {
            if (film == null) return;

            if ((this.filmler != null) && (!this.kutuphanedekiFilmlerinIDleri().Contains(film.ImdbID)))
            {
                this.filmler.Add(film);

                //Kütüphane değişti diye çağrı gönderiyoruz
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }

        }
        public void filmGuncelle(string id, Film yeniFilm)
        {
            if ((id == "") || (id == null) || (yeniFilm == null)) return;

            int indeks = this.kutuphanedekiFilmIndeksi(id);
            if (indeks != -1)
            {
                this.filmler[indeks] = yeniFilm;
                this.kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }
        }
        public void filmSil(Film film)
        {
            if (film == null) return;

            if (this.kutuphanedekiFilmlerinIDleri().Contains(film.ImdbID))
            {
                this.filmler.Remove(film);
                //Kütüphane değişti diye çağrı gönderiyoruz
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }
        }
        public void filmSil(string imdbID)
        {
            if ((imdbID == null) || (imdbID == "")) return;
            if (!(System.Text.RegularExpressions.Regex.IsMatch(imdbID, "tt\\d{7}"))) return;

            Film film = kutuphanedekiFilm(imdbID);

            if (film != null)
            {
                filmSil(film);
            }
        }
        public void tumFilmleriSil()
        {
            this.filmler.Clear();

            //Kütüphane değişti diye çağrı gönderiyoruz
            kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
        }
        public void baziFilmleriSil(List<Film> baziFilmler)
        {
            int boyut = this.filmler.Count;

            foreach (Film f in baziFilmler)
	        {
		        if (this.filmler.Contains(f))
                {
                    this.filmler.Remove(f);
                }
	        }

            if (this.filmler.Count != boyut)
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
        }
        public bool filmKutuphanedemi(string imdbID)
        {
            return kutuphanedekiFilmlerinIDleri().Contains(imdbID);
        }
        public bool filmKutuphanedemi(Film film)
        {
            return this.filmler.Contains(film);
        }

        /// <summary>
        /// Kütüphanedeki bütün filmlerin IDlerini döndürür.
        /// </summary>
        /// <returns></returns>
        public List<string> kutuphanedekiFilmlerinIDleri()
        {
            List<string> filmlerinIDleri = new List<string>();
            foreach (Film f in this.filmler.ToArray())
            {
                filmlerinIDleri.Add(f.ImdbID);
            }
            return filmlerinIDleri;
        }
        
        /// <summary>
        /// Kişinin kütüphanedeki diğer filmlerini döndürür.
        /// </summary>
        /// <param name="kisi"></param>
        /// <returns></returns>
        public List<Film> kisininKutuphanedekiFilmleri(Kisi kisi)
        {
            if (kisi == null) return null;
            List<Film> filmler = new List<Film>();
            foreach (Film film in this.Filmler.ToArray())
            {
                if (film.TumKisilerID.Contains(kisi.ImdbID))
                {
                    filmler.Add(film);
                }
            }
            return filmler;
        }

        public List<Film> kisininKutuphanedekiFilmleri(string id)
        {
            if (id == "") return null;
            List<Film> filmler = new List<Film>();
            foreach (Film film in this.Filmler.ToArray())
            {
                if (film.TumKisilerID.Contains(id))
                {
                    filmler.Add(film);
                }
            }
            return filmler;
        }

        /// <summary>
        /// Imdb ID ile kütüphaneden film arar ve nesnesini döndürür.
        /// </summary>
        /// <param name="imdbID">Aranacak filmin ID si</param>
        /// <returns>Aranan film bulunamayınca null döndürür</returns>
        public Film kutuphanedekiFilm(string imdbID)
        {
            if (!(System.Text.RegularExpressions.Regex.IsMatch(imdbID, "tt\\d{7}"))) return null;

            foreach (Film y in this.filmler.ToArray())
            {
                if (y.ImdbID == imdbID)
                    return y;
            }
            return null;
        }
        
        /// <summary>
        /// Verilen imdbID ye sahip filmin kütüphanedeki indeksini verir. Bişey bulamazsa -1 döndürür.
        /// </summary>
        /// <param name="imdbID"></param>
        /// <returns></returns>
        public int kutuphanedekiFilmIndeksi(string imdbID)
        {
            for (int i = 0; i < this.filmler.Count; i++)
            {
                if (this.filmler[i].ImdbID == imdbID)
                    return i;
            }
            return -1;
        }
       
        /// <summary>
        /// Verilen film nesnesinin kütüphanedeki indeksini verir. Birşey bulamazsa -1 döndürür.
        /// </summary>
        /// <param name="film"></param>
        /// <returns></returns>
        public int kutuphanedekiFilmIndeksi(Film film)
        {
            for (int i = 0; i < this.filmler.Count; i++)
            {
                if (this.filmler[i] == film)
                    return i;
            }
            return -1;
        }
        
        #endregion

        #region Diziler

        public void diziEkle(Dizi dizi, bool otomotikEklendi = false)
        {
            if (dizi == null) return;

            if ((this.diziler != null) && (!this.diziler.Contains(dizi)))
            {
                this.diziler.Add(dizi);
                //Kütüphane değişti diye çağrı gönderiyoruz
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }

        }
        public void diziGuncelle(string id, Dizi yeniDizi)
        {
            if ((id == "") || (id == null) || (yeniDizi == null)) return;

            int indeks = this.kutuphanedekiDiziIndeksi(id);
            if (indeks != -1)
            {
                this.diziler[indeks] = yeniDizi;
                this.kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }
        }
        public void diziSil(Dizi dizi)
        {
            if (dizi == null) return;

            if (this.diziler.Contains(dizi))
            {
                this.diziler.Remove(dizi);
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }
        }
        public void diziSil(string imdbID)
        {
            if ((imdbID == null) || (imdbID == "")) return;
            if (!(System.Text.RegularExpressions.Regex.IsMatch(imdbID, "tt\\d{7}"))) return;

            Dizi dizi = kutuphanedekiDizi(imdbID);

            if (dizi != null)
            {
                diziSil(dizi);
            }
        }
        public void tumDizileriSil()
        {
            this.diziler.Clear();

            //Kütüphane değişti diye çağrı gönderiyoruz
            kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
        }
        public void baziDizileriSil(List<Dizi> baziDiziler)
        {
            int miktar = this.diziler.Count;

            foreach (Dizi d in baziDiziler)
            {
                if (this.diziler.Contains(d))
                    this.diziler.Remove(d);
            }

            if (this.diziler.Count != miktar)
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
        }
        public bool diziKutuphanedemi(string imdbID)
        {
            return kutuphanedekiDizilerinIDleri().Contains(imdbID);
        }
        public bool diziKutuphanedemi(Dizi dizi)
        {
            return this.diziler.Contains(dizi);
        }
        public Dizi kutuphanedekiDizi(string imdbID)
        {
            if (!(System.Text.RegularExpressions.Regex.IsMatch(imdbID, "tt\\d{7}"))) return null;

            foreach (Dizi y in this.diziler.ToArray())
            {
                if (y.ImdbID == imdbID)
                    return y;
            }
            return null;
        }

        public List<string> kutuphanedekiDizilerinIDleri()
        {
            List<string> dizilerinIDleri = new List<string>();
            foreach (Dizi d in this.diziler.ToArray())
            {
                dizilerinIDleri.Add(d.ImdbID);
            }
            return dizilerinIDleri;
        }
        public List<Dizi> kisininKutuphanedekiDizileri(Kisi kisi)
        {
            if (kisi == null) return null;
            List<Dizi> kisinindizileri = new List<Dizi>();
            foreach (Dizi dizi in this.diziler.ToArray())
            {
                if (dizi.TumKisilerID.Contains(kisi.ImdbID))
                {
                    kisinindizileri.Add(dizi);
                }
            }
            return kisinindizileri;
        }
        public int kutuphanedekiDiziIndeksi(string imdbID)
        {
            for (int i = 0; i < this.diziler.Count; i++)
            {
                if (this.diziler[i].ImdbID == imdbID)
                    return i;
            }
            return -1;
        }
        public int kutuphanedekiDiziIndeksi(Dizi dizi)
        {
            for (int i = 0; i < this.diziler.Count; i++)
            {
                if (this.diziler[i] == dizi)
                    return i;
            }
            return -1;
        }

        #endregion

        #region Kişiler

        public void kisiEkle(Kisi kisi)
        {
            if (kisi == null) return;

            if (!this.kutuphanedekiKisilerinIDleri(-1).Contains(kisi.ImdbID))
            {
                this.kisiler.Add(kisi);
                //Kütüphane değişti diye çağrı gönderiyoruz
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }
        }
        public void kisiGuncelle(string id, Kisi yeniKisi)
        {
            if ((id == "") || (id == null) || (yeniKisi == null)) return;

            int indeks = this.kutuphanedekiKisiIndeksi(id);
            if (indeks != -1)
            {
                this.kisiler[indeks] = yeniKisi;
                this.kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
            }
        }
        public void kisileriSil(List<Kisi> silinecekKisiler)
        {
            if ((silinecekKisiler == null) || (silinecekKisiler.Count == 0)) return;

            for (int i = 0; i < silinecekKisiler.Count; i++)
            {
                if (this.kutuphanedekiKisilerinIDleri(-1).Contains(silinecekKisiler[i].ImdbID))
                {
                    this.kisiler.Remove(silinecekKisiler[i]);
                    //Kütüphane değişti diye çağrı gönderiyoruz
                    kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
                }
            }
        }
        public void kisiSil(Kisi kisi)
        {
            if (kisi == null) return;

            if (this.kutuphanedekiKisilerinIDleri(-1).Contains(kisi.ImdbID))
            {
                this.kisiler.Remove(kisi);
                //Kütüphane değişti diye çağrı gönderiyoruz
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true }); ;
            }
        }
        public void tumKisileriSil()
        {
            this.kisiler.Clear();

            kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
        }
        public void baziKisileriSil(List<Kisi> baziKisiler)
        {
            if ((baziKisiler == null) || (baziKisiler.Count == 0)) return;
            List<string> kisiID = kutuphanedekiKisilerinIDleri(-1);
            if ((kisiID == null) || (kisiID.Count == 0)) return;

            for (int i = 0; i < baziKisiler.Count; i++)
            {
                if (kisiID.Contains(baziKisiler[i].ImdbID))
                {
                    this.kisiler.Remove(baziKisiler[i]);
                    //Kütüphane değişti diye çağrı gönderiyoruz
                    kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
                }
            }
        }
        public string kutuphanedekiKisiAdi(string imdbID)
        {
            if (!(System.Text.RegularExpressions.Regex.IsMatch(imdbID, "nm\\d{7}"))) return "";
            if (this.IDIsimVeritabani.Keys.Contains(imdbID))
            {
                return this.IDIsimVeritabani[imdbID];
            }
            return "";
        }
        public Kisi kutuphanedekiKisi(string imdbID)
        {
            if (!(System.Text.RegularExpressions.Regex.IsMatch(imdbID, "nm\\d{7}"))) return null;
            foreach (Kisi y in this.kisiler.ToArray())
            {
                if (y.ImdbID == imdbID)
                    return y;
            }
            return null;
        }
        public int kutuphanedekiKisiIndeksi(string imdbID)
        {
            for (int i = 0; i < this.kisiler.Count; i++)
            {
                if (this.kisiler[i].ImdbID == imdbID)
                    return i;
            }
            return -1;
        }
        public List<string> kutuphanedekiKisilerinIDleri(int unvan)
        {
            if ((unvan > (int)KisiUnvani.Yonetmen) || (unvan < -1)) return null;

            List<string> kisiler = new List<string>();

            if (unvan == -1) //unvan -1 ise tüm kişilerin imdb idlerini döndür.
            {
                foreach (Kisi kisi in this.kisiler.ToArray())
                {
                    kisiler.Add(kisi.ImdbID);
                }
                return kisiler;
            }
            foreach (Kisi kisi in this.kisiler.ToArray())
            {
                if (kisi.Unvan == unvan)
                    kisiler.Add(kisi.ImdbID);
            }
            return kisiler;
        }
        public List<string> kisininKutuphanedekiFilmlerininAdlari(Kisi kisi)
        {
            if (kisi == null) return null;
            List<Film> tumFilmleri = kisininKutuphanedekiFilmleri(kisi);
            if (tumFilmleri == null) return null;
            List<string> sTumFilmleri = new List<string>();
            foreach (Film f in tumFilmleri)
                sTumFilmleri.Add(f.Ad);

            return sTumFilmleri;
        }
        public List<Kisi> kutuphanedekiKisiler(List<string> imdbIDler)
        {
            if ((imdbIDler == null) || (imdbIDler.Count == 0)) return null;
            List<Kisi> kisiler = new List<Kisi>();
            foreach (string imdbID in imdbIDler)
            {
                Kisi kisi = kutuphanedekiKisi(imdbID);
                if (kisi != null) kisiler.Add(kisi);
            }
            return kisiler;
        }
        public List<Kisi> kutuphanedekiKisiler(int unvan)
        {
            if ((unvan > (int)KisiUnvani.Yonetmen) || (unvan < 0)) return null;

            List<Kisi> kisiler = new List<Kisi>();

            foreach (Kisi kisi in this.kisiler.ToArray())
            {
                if (kisi.Unvan == unvan)
                    kisiler.Add(kisi);
            }
            return kisiler;
        }
        public bool kisiKutuphanedemi(string id)
        {
            foreach (Kisi kKutup in this.kisiler)
            {
                if (kKutup.ImdbID == id) return true;
            }
            return false;
        }
        /// <summary>
        /// "film"deki kişi id'lerinden "unvan" değişkeninin değerine
        /// göre kişi listesi döndürür. Döndürülen kişiler kütüphaneye önceden eklenmiş Kişi sınıfı olarak nesnelenmiş olmalıdır.
        /// </summary>
        /// <param name="film">Kişileri döndürülecek Film nesnesi</param>
        /// <param name="unvan">Kişi filtresi: Diğer için 0, Yönetmen için 1, Yazar için 2, Oyuncu için 3</param>
        /// <returns></returns>
        public List<Kisi> filmdekiKisiler(Film film, int unvan)
        {
            if (film == null) return null;

            List<Kisi> degerler = new List<Kisi>();

            if (unvan == (int)KisiUnvani.Yonetmen)
            {
                foreach (string imdbId in film.YonetmenlerID.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(imdbId);
                    if (kisi != null)
                        degerler.Add(kisi);
                }
                return degerler;
            }
            else if (unvan == (int)KisiUnvani.Yazar)
            {
                foreach (string imdbId in film.YazarlarID.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(imdbId);
                    if (kisi != null)
                        degerler.Add(kisi);
                }
                return degerler;
            }
            else if (unvan == (int)KisiUnvani.Oyuncu)
            {
                foreach (string imdbId in film.OyuncularID.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(imdbId);
                    if (kisi != null)
                        degerler.Add(kisi);
                }
                return degerler;
            }
            else if (unvan == (int)KisiUnvani.Diger)
            {
                foreach (DigerKisi diger in film.DigerKisiler.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(diger.kisiID);
                    if (kisi != null)
                        degerler.Add(kisi);
                }
                return degerler;
            }

            return degerler;
        }
        
        /// <summary>
        /// "film"deki kişileri "unvan" a göre süzerek, isimlerinin listesini döndürür. 
        /// </summary>
        /// <param name="film">Kişileri istenen film</param>
        /// <param name="unvan">Kişi filtresi: Diğer için 0, Yönetmen için 1, Yazar için 2, Oyuncu için 3</param>
        /// <param name="birlesikmi">Döndürülen kişilerin isimleri eğer birleşik olarak isteniyorsa true atanır. Birleşik
        ///  değer dönen listenin ilk elemanına atanır. Birleştirme ", " parametresiyle yapılır.</param>
        /// <returns></returns>
        public List<string> filmdekiKisilerinAdlari(Film film, int unvan, bool birlesikmi = false)
        {
            if (film == null) return null;

            List<string> degerler = new List<string>();

            if (unvan == (int)KisiUnvani.Yonetmen)
            {
                foreach (string imdbId in film.YonetmenlerID.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(imdbId);
                    if (kisi != null)
                        degerler.Add(kisi.Isim);
                }
            }
            else if (unvan == (int)KisiUnvani.Yazar)
            {
                foreach (string imdbId in film.YazarlarID.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(imdbId);
                    if (kisi != null)
                        degerler.Add(kisi.Isim);
                }
            }
            else if (unvan == (int)KisiUnvani.Oyuncu)
            {
                foreach (string imdbId in film.OyuncularID.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(imdbId);
                    if (kisi != null)
                        degerler.Add(kisi.Isim);
                }
            }
            else if (unvan == (int)KisiUnvani.Diger)
            {
                foreach (DigerKisi diger in film.DigerKisiler.ToArray())
                {
                    Kisi kisi = kutuphanedekiKisi(diger.kisiID);
                    if (kisi != null)
                        degerler.Add(kisi.Isim);
                }
            }

            //Eğer birleşik isteniyorsa tüm isimler degerleri listesinin ilk elemanına virgülle birleşik olarak 
            // atanır.
            if ((birlesikmi == true) && (degerler.Count > 0))
            {
                string tumu = ""; int max = 0;
                tumu += degerler[0];
                foreach (string s in degerler.ToArray())
                {
                    if (max == 0) continue;  tumu +=", " + s ; max++; if (max == 2) break;
                }
                degerler.Clear(); degerler.Add(tumu);
            }

            return degerler;
        }
        
        #endregion

        #region Kütüphane
        public int Guncelle(SortedDictionary<string, string> yeniBilgiler)
        {
            if (yeniBilgiler == null) return 0;
            if (yeniBilgiler.Count == 0) return 0;

            SortedDictionary<string, string>.Enumerator a = yeniBilgiler.GetEnumerator();
            a.MoveNext();

            int guncellenenMiktar = 0;
            do
            {
                if (!this.IDVeritabani.ContainsKey(a.Current.Key))
                {
                    guncellenenMiktar++;
                    this.IDVeritabani.Add(a.Current.Key, a.Current.Value);
                }
            }
            while (a.MoveNext());

            return guncellenenMiktar;
        }
        public string karakterAdi(string filmID, string oyuncuID)
        {
            foreach (Film f in this.filmler)
            {
                if (f.ImdbID == filmID)
                {
                    foreach (FilmKarakteri ff in f.Karakterler)
                    {
                        if (ff.oyuncuID == oyuncuID)
                        {
                            foreach (isimID id in ff.karakterler)
                            {
                                return id.isim;
                            }
                        }
                    }
                }
            }
            return "";
        }
        public void TumVeritabaniniSil()
        {
            this.IDVeritabani.Clear();

            kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
        }
        public void kutuphaneyiKaydet()
        {
            if (dosyaYolu == "") return;

            FileStream f  = null;

            try
            {
                if (File.Exists(dosyaYolu)) File.Delete(dosyaYolu);

                if (File.Exists(dosyaYolu))
                    f = new FileStream(dosyaYolu, FileMode.Open, FileAccess.ReadWrite);
                else
                    f = new FileStream(dosyaYolu, FileMode.Create, FileAccess.ReadWrite);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, this);
                kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { false });
                f.Close();
            }
            catch (Exception hata)
            {
                if (f != null)
                    f.Close();
                throw hata;
            }

        }
        public void kutuphaneEkle(Kutuphane eklenecekKutuphane)
        {
            if (eklenecekKutuphane == null) return;

            foreach (Film f in eklenecekKutuphane.filmler)
            {
                this.filmEkle(f);
            }

            foreach (Dizi d in eklenecekKutuphane.diziler)
            {
                this.diziEkle(d);
            }
        }
        #endregion

        #region Diğer Fonksiyonlar
        public List<string> kisininFilmindekiKarakterAdlari(Kisi kisi, Film film)
        {
            if ((kisi == null) || (film == null)) return null;

            List<string> ad = new List<string>();

            foreach (FilmKarakteri karakterler in film.Karakterler.ToArray())
            {
                if (karakterler.oyuncuID == kisi.ImdbID)
                {
                    ad.Add(karakterler.karakterAdlariBirlesik(" / "));
                }
            }
            return ad;
        }
        public List<string> kisininDizisindekiKarakterAdlari(Kisi kisi, Dizi dizi)
        {
            if ((kisi == null) || (dizi == null)) return null;

            List<string> ad = new List<string>();

            foreach (FilmKarakteri karakterler in dizi.Karakterler.ToArray())
            {
                if (karakterler.oyuncuID == kisi.ImdbID)
                {
                    ad.Add(karakterler.karakterAdlariBirlesik(" / "));
                }
            }
            return ad;
        }
        public static Kutuphane kutuphaneAc(string dosyaYolu)
        {
            if ((dosyaYolu == "") || (dosyaYolu == null)) return null;

            if (!File.Exists(dosyaYolu)) return null;
            FileStream f = null;

            try
            {
                f = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Kutuphane yeni = null;

                yeni = (Kutuphane)bf.Deserialize(f);
                yeni.dosyaYolu = dosyaYolu;

                f.Close();
                return yeni;
            }
            catch (Exception hata)
            {
                f.Close();
                throw ;
            }
        }
        private static string dosyaninUzantisizAdi(string dosya)
        {
            FileInfo dossya = new FileInfo(dosya);
            return dossya.Name.Substring(0, dossya.Name.LastIndexOf('.'));
        } 
        #endregion

        #region Ozellikler
        public string DosyaAdi
        {
            get
            {
                return dosyaYolu;
            }
            set
            {
                dosyaYolu = value;
            }
        }
        public string KutuphaneAdi
        {
            get { return kutuphaneAdi; }
            set { kutuphaneAdi = value; }
        }
        public List<Film> Filmler
        {
            get
            {
                return this.filmler;
            }
        }
        public List<Kisi> Kisiler
        {
            get
            {
                return this.kisiler;
            }
        }
        public List<Dizi> Diziler
        {
            get
            {
                return this.diziler;
            }
        }
        public int OyuncuSayisi
        {
            get
            {
                int i = 0;

                foreach (Kisi kisi in this.kisiler)
                {
                    if (kisi.Unvan == (int)KisiUnvani.Oyuncu) i++;
                }

                return i;
            }
        }
        public int YonetmenSayisi
        {
            get
            {
                int i = 0;

                foreach (Kisi kisi in this.kisiler)
                {
                    if (kisi.Unvan == (int)KisiUnvani.Yonetmen) i++;
                }

                return i;
            }
        }
        public int YazarSayisi
        {
            get
            {
                int i = 0;

                foreach (Kisi kisi in this.kisiler)
                {
                    if (kisi.Unvan == (int)KisiUnvani.Yazar) i++;
                }

                return i;
            }
        }
        public int BelirsizKisiSayisi
        {
            get
            {
                int i = 0;

                foreach (Kisi kisi in this.kisiler)
                {
                    if (kisi.Unvan == (int)KisiUnvani.Diger) i++;
                }

                return i;
            }
        }
        public SortedDictionary<string, string> IDVeritabani
        {
            get
            {
                return this.IDIsimVeritabani;
            }
            set
            {
                this.IDIsimVeritabani = value;
            }
        }
        #endregion

        ~Kutuphane()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposeDurumu)
        {
            if (disposeDurumu == true)
            {
                foreach (Film f in this.filmler)
                {
                    if (f != null)
                        f.Dispose();
                }
                foreach (Dizi d in this.diziler)
                {
                    if (d != null)
                    d.Dispose();
                }
                foreach (Kisi k in this.kisiler)
                {
                    if (k != null)
                    k.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
