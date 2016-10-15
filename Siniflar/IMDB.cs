using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;

namespace MMC_Filmograf.Library
{
    class IMDB
    {
        
        Film film;
        Kisi kisi;
        Dizi dizi;
        List<IMDBAramaKategorisi> tumSonuclar;

        /// <summary>
        /// 1 için Film, 2 için Dizi, 3 için kişi
        /// </summary>
        int indirmeTuru = 1;
        
        List<Exception> olusanHatalar;
        
        SortedDictionary<string, string> idIsimVeritabani;

        public Delegate intIlerlemeYuzdesi;
        public Delegate stringIlerlemeKonumu;
        public Delegate idStringIlerlemeKonumu;
        public Delegate islemYapilanBaslikID;

        public IMDB()
        {
            this.olusanHatalar = new List<Exception>();
            idIsimVeritabani = new SortedDictionary<string, string>();
        }

        /// <summary>
        /// Verilen başlığın filme mi ait olduğunu
        /// yoksa diziye mi ait olduğunu döndürür.
        /// Geçersiz için 0, Film için 1, Dizi için 2.
        /// </summary>
        /// <param name="baslik"></param>
        /// <returns></returns>
        private int FilmDiziGecersiz(string baslik, out string indirilenSayfa )
        {
            int tur = 1;

            string sayfa = "";
            sayfa = sayfayiTemizle(sayfaIndir(Sabitler.IMDBBasligi + baslik));
            indirilenSayfa = sayfa;

            if (sayfa != "")
            {
                Regex r = new Regex("<title>(.*?)</title>", RegexOptions.Singleline);
                Match m = r.Match(sayfa);

                if (m.Success)
                {
                    if (m.Value.ToLower().Contains("(tv series"))
                        return 2;
                    if (m.Value.ToLower().Contains("IMDb: Page not found".ToLower()))
                        return 0;
                }
            }
            
            return tur;
        }
        
        /// <summary>
        /// Verilen başlığın filme mi ait olduğunu
        /// yoksa diziye mi ait olduğunu döndürür.
        /// Geçersiz için 0, Film için 1, Dizi için 2.
        /// </summary>
        /// <param name="baslik"></param>
        /// <returns></returns>
        private int FilmDiziGecersiz(string baslik)
        {
            int tur = 1;

            string sayfa = "";
            sayfa = sayfayiTemizle(sayfaIndir(Sabitler.IMDBBasligi + baslik));

            if (sayfa != "")
            {
                Regex r = new Regex("<title>(.*?)</title>", RegexOptions.Singleline);
                Match m = r.Match(sayfa);

                if (m.Success)
                {
                    if (m.Value.ToLower().Contains("(tv series"))
                        return 2;
                    if (m.Value.ToLower().Contains("IMDb: Page not found".ToLower()))
                        return 0;
                }
            }

            return tur;
        }

        public void indir(string baslik)
        {
            //Başta basligin uygun olup olmadigina bakalim.
            Regex r = new Regex(Sabitler.RegexFilmKisiBasligi, RegexOptions.Singleline);
            Match m = r.Match(baslik);

            if (!m.Success)
            {
                BaslikUyusmadiHatasi yeni = new BaslikUyusmadiHatasi();
                throw yeni;
            }

            if (Regex.IsMatch(baslik, Sabitler.RegexKisiBasligi))
            {
                indirmeTuru = 3;

                kisiIndir(baslik);
                return;
            }

            int sayfaTuru = FilmDiziGecersiz(baslik);

            if (sayfaTuru==1)
            {
                indirmeTuru = 1;
                //Eğer başlık filme aitse;
                filmIndir(baslik);
            }
            else if (sayfaTuru == 2)
            {
                indirmeTuru = 2;
                //Eğer başlık diziye aitse
                diziIndir(baslik);
            }
            else if (sayfaTuru == 0)
            {
                //Sayfa yoksa
                SayfaYokHatasi yeni = new SayfaYokHatasi("İstenilen sayfa mevcut değil");
                throw yeni;
            }
        }

        private void filmIndir(string baslik)
        {
            film = new Film();
            film.ImdbID = baslik;
            this.idIsimVeritabani = new SortedDictionary<string, string>();

            if (islemYapilanBaslikID != null)
                islemYapilanBaslikID.DynamicInvoke(new object[] { baslik });

            #region İndirilecek sayfaların link değişkenleri
            string lAnaSayfa = Sabitler.IMDBBasligi + baslik;
            string lOduller = lAnaSayfa + "/awards";
            string lTumKadro = lAnaSayfa + "/fullcredits";
            string lOzetler = lAnaSayfa + "/plotsummary";
            string lKelimeler = lAnaSayfa + "/keywords";
            string lSloganlar = lAnaSayfa + "/taglines";
            string lResmiSiteler = lAnaSayfa + "/officialsites";
            string lSirketler = lAnaSayfa + "/companycredits";
            string lCikisBilgisi = lAnaSayfa + "/releaseinfo";
            string lGercekler = lAnaSayfa + "/trivia";
            string lHatalar = lAnaSayfa + "/goofs";
            string lReplikler = lAnaSayfa + "/quotes";
            string lAbartiGercekler = lAnaSayfa + "/crazycredits";
            string lReferanslar = lAnaSayfa + "/movieconnections";
            string lMuzikler = lAnaSayfa + "/soundtrack"; 
            #endregion

            try
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });

                #region Ana sayfa 
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Anasayfa işleniyor" });
                    string pHome = sayfaIndir(lAnaSayfa); isleAnaSayfa(pHome);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eHomepage) { olusanHatalar.Add(eHomepage); } 

                #endregion

                #region Ödüller
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Ödüller sayfası işleniyor" });
                    string pAwards = sayfaIndir(lOduller); isleOduller(pAwards);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eAwards) { olusanHatalar.Add(eAwards); } 
                #endregion

                #region Tüm kadro
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Tüm oyuncular ve kişiler alınıyor" });
                    string pFullCastCrew = sayfaIndir(lTumKadro); isleTumKadro(pFullCastCrew);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eFullCastCrew) { olusanHatalar.Add(eFullCastCrew); } 
                #endregion

                #region Özetler
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Özetler alınıyor" });
                    string pPlotSummary = sayfaIndir(lOzetler); isleOzetler(pPlotSummary);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });

                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception ePlotSummary) { olusanHatalar.Add(ePlotSummary); } 
                #endregion

                #region Kelimeler
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Anahtar kelimeler alınıyor" });
                    string pKeywords = sayfaIndir(lKelimeler); isleKelimeler(pKeywords);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });

                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eKeywords) { olusanHatalar.Add(eKeywords); } 
                #endregion

                #region Sloganlar
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Film sloganları alınıyor" });
                    string pTaglines = sayfaIndir(lSloganlar); isleSloganlar(pTaglines);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eTaglines) { olusanHatalar.Add(eTaglines); } 
                #endregion

                #region Resmi Siteler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Resmi web sayfaları alınıyor" });
                    string pOfficialSites = sayfaIndir(lResmiSiteler); isleResmiSiteler(pOfficialSites);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eOfficialSites) { olusanHatalar.Add(eOfficialSites); } 
                #endregion

                #region Çıkış bilgileri
               
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Çıkış bilgileri alınıyor" });
                    string pReleaseInfo = sayfaIndir(lCikisBilgisi); isleCikisBilgileri(pReleaseInfo);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eReleaseInfo) { olusanHatalar.Add(eReleaseInfo); } 
                #endregion

                #region Şirketler
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Şirket bilgileri alınıyor" });
                    string pCompanyCredits = sayfaIndir(lSirketler); isleSirketler(pCompanyCredits);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eCompanyCredits) { olusanHatalar.Add(eCompanyCredits); } 
                #endregion

                #region Gerçekler
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Çekim gerçekleri alınıyor" });
                    string pTrivias = sayfaIndir(lGercekler); isleGercekler(pTrivias);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eTrivias) { olusanHatalar.Add(eTrivias); } 
                #endregion

                #region Hatalar
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Çekim hataları alınıyor" });
                    string pGoofs = sayfaIndir(lHatalar); isleHatalar(pGoofs);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eGoofs) { olusanHatalar.Add(eGoofs); } 
                #endregion

                #region Replikler
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Film replikleri alınıyor" });
                    string pQuotes = sayfaIndir(lReplikler); isleReplikler(pQuotes);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eQuotes) { olusanHatalar.Add(eQuotes); } 
                #endregion

                #region Abartı Gerçekler

                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Crazy credits alınıyor" });
                    string pCrazyCredits = sayfaIndir(lAbartiGercekler); isleAbartiGercekler(pCrazyCredits);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eCrazyCredits) { olusanHatalar.Add(eCrazyCredits); } 
                #endregion

                #region Referanslar
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Film referansları alınıyor" });
                    string pMovieConnections = sayfaIndir(lReferanslar); isleReferanslar(pMovieConnections);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eMovieConnections) { olusanHatalar.Add(eMovieConnections); } 
                #endregion

                #region Müzikler
                
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Film müzikleri alınıyor" });
                    string pSoundtrack = sayfaIndir(lMuzikler); isleMuzikler(pSoundtrack);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eSoundrack) { olusanHatalar.Add(eSoundrack); } 
                #endregion

                if (this.Hatalar.Count > 0) throw new Exception("Hatalar oluştu");

                filmNesnesiniDuzenle();

                intIlerlemeYuzdesi.DynamicInvoke(new object[] { 10 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "Tamamlandı" });
            }
            catch (WebException internetYok)
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "İnternet Yok" });
                throw internetYok;
            }
            catch (Exception hata)
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "Hata Oluştu" });
                throw hata;
            }

        }
        private void diziIndir(string baslik)
        {
            film = new Film();
            dizi = new Dizi();
            dizi.ImdbID = baslik;
            this.idIsimVeritabani = new SortedDictionary<string, string>();

            if (islemYapilanBaslikID != null)
                islemYapilanBaslikID.DynamicInvoke(new object[] { baslik });

            #region İndirilecek sayfaların link değişkenleri
            string lAnaSayfa = Sabitler.IMDBBasligi + baslik;
            string lOduller = lAnaSayfa + "/awards";
            string lBolumler = lAnaSayfa + "/episodes";
            string lTumKadro = lAnaSayfa + "/fullcredits";
            string lOzetler = lAnaSayfa + "/plotsummary";
            string lKelimeler = lAnaSayfa + "/keywords";
            string lSloganlar = lAnaSayfa + "/taglines";
            string lResmiSiteler = lAnaSayfa + "/officialsites";
            string lSirketler = lAnaSayfa + "/companycredits";
            string lCikisBilgisi = lAnaSayfa + "/releaseinfo";
            string lGercekler = lAnaSayfa + "/trivia";
            string lHatalar = lAnaSayfa + "/goofs";
            string lReplikler = lAnaSayfa + "/quotes";
            string lAbartiGercekler = lAnaSayfa + "/crazycredits";
            string lReferanslar = lAnaSayfa + "/movieconnections";
            string lMuzikler = lAnaSayfa + "/soundtrack"; 
            #endregion

            try
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });

                #region Anasayfa
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Anasayfa işleniyor" });
                    string syfAna = sayfaIndir(lAnaSayfa); isleAnaSayfa(syfAna);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eHomepage) { olusanHatalar.Add(eHomepage); }
                #endregion

                #region Ödüller
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Ödüller sayfası işleniyor" });
                    string pAwards = sayfaIndir(lOduller); isleOduller(pAwards);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eAwards) { olusanHatalar.Add(eAwards); }
                #endregion

                #region Tüm kadro
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Tüm oyuncular ve kişiler alınıyor" });
                    string pFullCastCrew = sayfaIndir(lTumKadro); isleTumKadroDizi(pFullCastCrew);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eFullCastCrew) { olusanHatalar.Add(eFullCastCrew); }
                #endregion

                #region Dizi bölümleri
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Dizinin bölümleri alınıyor" });
                    string syfDiziBolumleri = sayfaIndir(lBolumler); isleDiziBolumleri(syfDiziBolumleri);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception hDiziBolumleri) { olusanHatalar.Add(hDiziBolumleri); } 
                #endregion

                #region Özetler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Özetler alınıyor" });
                    string pPlotSummary = sayfaIndir(lOzetler); isleOzetler(pPlotSummary);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });

                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception ePlotSummary) { olusanHatalar.Add(ePlotSummary); } 
                #endregion

                #region Kelimeler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Anahtar kelimeler alınıyor" });
                    string pKeywords = sayfaIndir(lKelimeler); isleKelimeler(pKeywords);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });

                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eKeywords) { olusanHatalar.Add(eKeywords); } 
                #endregion

                #region Slogan
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Dizi sloganları alınıyor" });
                    string pTaglines = sayfaIndir(lSloganlar); isleSloganlar(pTaglines);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eTaglines) { olusanHatalar.Add(eTaglines); } 
                #endregion

                #region Resmi siteler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Resmi web sayfaları alınıyor" });
                    string pOfficialSites = sayfaIndir(lResmiSiteler); isleResmiSiteler(pOfficialSites);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eOfficialSites) { olusanHatalar.Add(eOfficialSites); } 
                #endregion

                #region Çıkış bilgisi
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Çıkış bilgileri alınıyor" });
                    string pReleaseInfo = sayfaIndir(lCikisBilgisi); isleCikisBilgileri(pReleaseInfo);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eReleaseInfo) { olusanHatalar.Add(eReleaseInfo); } 
                #endregion

                #region Şirketler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Şirket bilgileri alınıyor" });
                    string pCompanyCredits = sayfaIndir(lSirketler); isleSirketler(pCompanyCredits);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eCompanyCredits) { olusanHatalar.Add(eCompanyCredits); } 
                #endregion

                #region Gerçekler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Çekim gerçekleri alınıyor" });
                    string pTrivias = sayfaIndir(lGercekler); isleGercekler(pTrivias);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eTrivias) { olusanHatalar.Add(eTrivias); } 
                #endregion

                #region Hatalar
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Çekim hataları alınıyor" });
                    string pGoofs = sayfaIndir(lHatalar); isleHatalar(pGoofs);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eGoofs) { olusanHatalar.Add(eGoofs); } 
                #endregion

                #region Replikler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Dizi replikleri alınıyor" });
                    string pQuotes = sayfaIndir(lReplikler); isleReplikler(pQuotes);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eQuotes) { olusanHatalar.Add(eQuotes); } 
                #endregion

                #region Abartı Gerçekler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Abartı gerçekler alınıyor" });
                    string pCrazyCredits = sayfaIndir(lAbartiGercekler); isleAbartiGercekler(pCrazyCredits);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eCrazyCredits) { olusanHatalar.Add(eCrazyCredits); } 
                #endregion

                #region Referanslar
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Dizi referansları alınıyor" });
                    string pMovieConnections = sayfaIndir(lReferanslar); isleReferanslar(pMovieConnections);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eMovieConnections) { olusanHatalar.Add(eMovieConnections); } 
                #endregion

                #region Müzikler
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Dizi müzikleri alınıyor" });
                    string pSoundtrack = sayfaIndir(lMuzikler); isleMuzikler(pSoundtrack);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 6 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eSoundrack) { olusanHatalar.Add(eSoundrack); } 
                #endregion

                if (this.Hatalar.Count > 0) throw new Exception("Hatalar oluştu");

                diziNesnesiniDuzenle();

                intIlerlemeYuzdesi.DynamicInvoke(new object[] { 4 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "Tamamlandı" });
            }
            catch (WebException internetYok)
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "İnternet Yok" });
                throw internetYok;
            }
            catch (Exception hata)
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "Hata Oluştu" });
                throw hata;
            }
        }
        private void kisiIndir(string baslik)
        {
            if (!Regex.IsMatch(baslik, Sabitler.RegexKisiBasligi))
            {
                BaslikUyusmadiHatasi yeni = new BaslikUyusmadiHatasi("Girilen kişi başlığı uygun formda değil");
                throw yeni;
            }

            kisi = new Kisi(baslik);
            kisi.ImdbID = baslik;
            kisi.Unvan = (int)KisiUnvani.Diger;

            string lAnaSayfa = Sabitler.IMDBKisisi + baslik;
            string lBio = Sabitler.IMDBKisisi + baslik + "/bio";

            try
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                if (islemYapilanBaslikID != null)
                    islemYapilanBaslikID.DynamicInvoke(new object[] { baslik });
                #region Anasayfa
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Kişi resmi indiriliyor ve anasayfa işleniyor" });
                    string syfAnaSayfa = sayfaIndir(lAnaSayfa); isleAnasayfaKisi(syfAnaSayfa);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 40 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eHomepage) { olusanHatalar.Add(eHomepage); }
                #endregion

                #region Biyografi
                try
                {
                    stringIlerlemeKonumu.DynamicInvoke(new object[] { "Biyografi sayfası işleniyor" });
                    string syfBio = sayfaIndir(lBio); isleBioKisi(syfBio);
                    intIlerlemeYuzdesi.DynamicInvoke(new object[] { 40 });
                }
                catch (WebException internetYok) { throw internetYok; }
                catch (Exception eHomepage) { olusanHatalar.Add(eHomepage); }
                #endregion

               
                if (this.Hatalar.Count > 0) throw new Exception("Hatalar oluştu");

                intIlerlemeYuzdesi.DynamicInvoke(new object[] { 20 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "Tamamlandı" });
            }
            catch (WebException internetYok)
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "İnternet Yok" });
                throw internetYok;
            }
            catch (Exception hata)
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "Hata Oluştu" });
                throw hata;
            }
        }
        public void aramaYap(string aranacak)
        {
            if ((aranacak == null) || (aranacak == "")) return;

            string pAramaSayfasi = "";

            try
            {
                pAramaSayfasi = sayfaIndir("http://www.imdb.com/find?s=all&q=" + aranacak);
            }
            catch (Exception hata)
            {
                throw hata;
            }

            tumSonuclar = new List<IMDBAramaKategorisi>();

            Regex r = new Regex("<p>(.*?</td></tr></table>)\\s*</p>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(pAramaSayfasi);

            foreach (Match mm in m) //Tüm kategorileri gezen döngü
            {
                string kisimKat = mm.Groups[1].Value;

                IMDBAramaKategorisi sonuclar = new IMDBAramaKategorisi();

                Regex rKategori = new Regex("<b>([^<>]*?)</b>", RegexOptions.Singleline);
                Match mKategori = rKategori.Match(kisimKat);

                if (mKategori.Success) sonuclar.kategori = mKategori.Groups[1].Value;

                Regex r2 = new Regex("<tr>(.*?)</tr>", RegexOptions.Singleline);
                MatchCollection m2 = r2.Matches(kisimKat);

                foreach (Match m2m in m2) //Kategori içindeki her bir sonucu gezen döngü
                {
                    string kisimSonuc = m2m.Groups[1].Value;
                    isimID isid = new isimID();

                    Regex rLink = new Regex("<a\\s+href=\"/(?:title|name|company|character)/(?<id>(?:tt|nm|co|ch)\\d{7})/\"\\s+onclick=\"[^<>]*?\">(?<isim>[^<>]*?)</a>\\s*(?:[(](?<yil>\\d{4})[)]|<small>)", RegexOptions.Singleline);
                    Match mLink = rLink.Match(kisimSonuc);

                    if (mLink.Success)
                    {
                        isid.id = mLink.Groups["id"].Value;
                        isid.isim = mLink.Groups["isim"].Value + "@" + mLink.Groups["yil"].Value.Trim();
                    }
                    sonuclar.isimlerSonuclar.Add(isid);
                }

                if (!tumSonuclar.Contains(sonuclar))
                    tumSonuclar.Add(sonuclar);
            }


        }

        private void isleAnasayfaKisi(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            if (kisi == null) return;

            Regex r = new Regex("<img\\s+src=\"(?<link>[^<>]*?)\"\\s+height=\"\\d+\"\\s+width=\"\\d+\"\\s+alt=\"[^<>]*?\"\\s+title=\"[^<>]*?\"\\s*/>", RegexOptions.Singleline);
            Match m = r.Match(metin);

            if (m.Success)
            {
                kisi.ResimURL = m.Groups["link"].Value.Trim();
            }


            try
            {
                if (kisi.ResimURL != "")
                {
                    WebClient resim = new WebClient();
                    byte[] byteResim = resim.DownloadData(kisi.ResimURL);
                    ImageConverter a = new ImageConverter();
                    kisi.Resim = (Image)a.ConvertFrom(byteResim);
                }
            }
            catch (Exception hata)
            {
                olusanHatalar.Add(hata);
            }

            r = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/starsign/[^<>]*\">([^<>]*)</a>", RegexOptions.Singleline);
            m = r.Match(metin);

            if (m.Success)
            {
                kisi.Burc = m.Groups[1].Value;
            }
        }
        private void isleBioKisi(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            if (kisi == null) return;

            {
                //Kişi isminin ayrıştırılması

                Regex r = new Regex("<title>([^<>]*?)\\s*-\\s*Biography</title>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    kisi.Isim = m.Groups[1].Value.Trim();
                }
            }

            {
                //doğum tarihi ve yerinin ayrıştırılması

                Regex r = new Regex("<h5>Date of Birth</h5>(.*?)<br/><br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    //Tarihin ayrıştırılması
                    string tarih = "";

                    r = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/date/[^<>]*?/\">([^<>]*?)</a>", RegexOptions.Singleline);
                    Match m2 = r.Match(m.Groups[1].Value);

                    if (m2.Success)
                    {
                        tarih += m2.Groups[1].Value.Trim() + " ";
                    }

                    r = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/search/[^<>]*?\">([^<>]*?)</a>", RegexOptions.Singleline);
                    Match m3 = r.Match(m.Groups[1].Value);

                    if (m3.Success)
                    {
                        tarih += m3.Groups[1].Value.Trim();
                    }
                    kisi.DogumTarihi = tarih;

                    //Yerin ayrıştırılması
                    string yer = "";

                    r = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/search/name[?]birth_place[^<>]*\">([^<>]*?)</a>\\s*", RegexOptions.Singleline);
                    Match m4 = r.Match(m.Groups[1].Value);

                    if (m4.Success)
                    {
                        yer = m4.Groups[1].Value.Trim();
                    }
                    kisi.DogumYeri = yer;
                }
            }

            //Doğum Adının ayrıştırılması
            {
                Regex r = new Regex("<h5>Birth Name</h5>(.*?)<br/><br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    kisi.DogumAdi = m.Groups[1].Value.Trim();
                }
            }

            //Takma adının ayrıştırılması
            {
                Regex r = new Regex("<h5>Nickname</h5>(.*?)<br/>\\s*<br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    kisi.TakmaAdi = m.Groups[1].Value.Trim().Replace("<br/>", ";");
                }
            }

            //Boy Uzunluğunun ayrıştırılması
            {
                Regex r = new Regex("<h5>Height</h5>(.*?)<br/><br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    kisi.BoyUzunlugu = m.Groups[1].Value.Trim();
                }
            }

            //Mini biyografinin ayrıştırılması
            {
                Regex r = new Regex("<h5>Mini Biography</h5>(.*?)<br/><br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    string ozgecmisblogu = m.Groups[1].Value;

                    //Alınan ozgecmisblogu  temizliği
                    Regex rg = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/search/name[?]{1}[^<>]*?\">([^<>]*?)</a>", RegexOptions.Singleline);
                    MatchCollection mg = rg.Matches(ozgecmisblogu);
                    foreach (Match mmg in mg)
                        ozgecmisblogu = ozgecmisblogu.Replace(mmg.Value, mmg.Groups[1].Value);

                    r = new Regex("<p>(.*?)</p>", RegexOptions.Singleline);
                    Match m2 = r.Match(ozgecmisblogu);

                    Regex r2 = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/(?:title|name)/(?<id>(?:tt|nm)\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                    MatchCollection m3 = r2.Matches(m2.Groups[1].Value);

                    string bio = ""; bio = m2.Groups[1].Value;

                    foreach (Match mm in m3)
                    {
                        bio = bio.Replace(mm.Value, ">" + mm.Groups["id"].Value + "<");

                        if (!this.idIsimVeritabani.ContainsKey(mm.Groups["id"].Value))
                            this.idIsimVeritabani.Add(mm.Groups["id"].Value, mm.Groups["isim"].Value);
                    }

                    bio = Regex.Replace(bio, "<b>(.*?)</a>", "", RegexOptions.Singleline);
                    bio = bio.Trim();
                    bio = bio.Replace("<br>", "");
                    kisi.Biyografi = bio;
                }
            }

            //Eş bilgisinin ayrıştırılması
            {
                Regex r = new Regex("<h5>Spouse</h5>(.*?)<br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    Regex rtr = new Regex("<tr>(.*?)</tr>", RegexOptions.Singleline);
                    MatchCollection mtr = rtr.Matches(m.Groups[1].Value);

                    foreach (Match mmtr in mtr)
                    {
                        KisiEvlilik yeni = new KisiEvlilik();

                        Regex r2 = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/name/(?<id>nm\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                        Match m2 = r2.Match(mmtr.Groups[1].Value);

                        if (m.Success)
                        {
                            yeni.esiID = m2.Groups["id"].Value;
                        }

                        string es = mmtr.Groups[1].Value;

                        es = Regex.Replace(es, "<a.*?>", "", RegexOptions.Singleline);
                        es = Regex.Replace(es, "</a>", "", RegexOptions.Singleline);

                        Regex r3 = new Regex("[(](\\s*\\d*\\s+\\w+\\s+\\d+\\s*)[-](?:(\\s*\\d*\\s+\\w+\\s+\\d+\\s*)|(\\s*present\\s*))[)]");
                        Match m3 = r3.Match(es);

                        if (m3.Success)
                        {
                            yeni.evlilikTarihi = m3.Groups[1].Value;
                            yeni.bosanmaTarihi = m3.Groups[2].Value;
                        }

                        if (mmtr.Groups[1].Value.Contains("divorced"))
                            yeni.evlilikDurumu = "boşanmış";
                        else if (mmtr.Groups[1].Value.Contains("present"))
                            yeni.evlilikDurumu = "devam ediyor";

                        yeni.cocukSayisi = Regex.Match(mmtr.Groups[1].Value, "(\\d+)\\s*children", RegexOptions.Singleline).Groups[1].Value;

                        if (!this.idIsimVeritabani.ContainsKey(m.Groups["id"].Value))
                            this.idIsimVeritabani.Add(m.Groups["id"].Value, m.Groups["isim"].Value);

                        kisi.YaptigiEvlilikler.Add(yeni);
                    }
                }
            }

            //Kazandığı Paralar
            {
                Regex r = new Regex("<h5>Salary</h5>(.*?)<br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    Regex rtr = new Regex("<tr>(.*?)</tr>", RegexOptions.Singleline);
                    MatchCollection mtr = rtr.Matches(m.Groups[1].Value);

                    foreach (Match mmtr in mtr)
                    {
                        IDKazandigiPara yeni = new IDKazandigiPara();

                        Regex r2 = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/(?:title|name)/(?<id>(?:tt|nm)\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                        Match m2 = r2.Match(mmtr.Groups[1].Value);

                        if (m2.Success)
                        {
                            yeni.filmID = m2.Groups["id"].Value;
                        }

                        yeni.paraMiktari = Regex.Match(mmtr.Groups[1].Value, "<td\\s+valign=\"top\">([^<>]*?)</td>", RegexOptions.Singleline).Groups[1].Value;

                        if (!this.idIsimVeritabani.ContainsKey(m2.Groups["id"].Value))
                            this.idIsimVeritabani.Add(m2.Groups["id"].Value, m2.Groups["isim"].Value);

                        kisi.KazandigiParalar.Add(yeni);
                    }
                }
            }

            //Hakkındaki gerçeklerin ayrıştırılması
            {
                Regex r = new Regex("<h5>Trivia</h5>(.*?)<br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    List<string> gercekler = new List<string>();
                    string gerceklerBlogu = m.Groups[1].Value;

                    //Alınan gerçekler bloğunun temizliği
                    Regex rg = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/search/name[?]{1}[^<>]*?\">([^<>]*?)</a>", RegexOptions.Singleline);
                    MatchCollection mg = rg.Matches(gerceklerBlogu);
                    foreach (Match mmg in mg)
                        gerceklerBlogu = gerceklerBlogu.Replace(mmg.Value, mmg.Groups[1].Value);
                    gerceklerBlogu.Replace("<br>", "");

                    r = new Regex("<p>(.*?)</p>", RegexOptions.Singleline);
                    MatchCollection mim = r.Matches(gerceklerBlogu);

                    foreach (Match mmm in mim)
	                {
                        string gercek = "";
                        gercek = mmm.Groups[1].Value;

		                Regex r2 = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/(?:name|title)/(?<id>(?:tt|nm)\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                        MatchCollection m2 = r2.Matches(gercek);

                        foreach (Match mm in m2)
                        {
                            gercek = gercek.Replace(mm.Value, ">" + mm.Groups["id"].Value + "<");

                            if (!this.idIsimVeritabani.ContainsKey(mm.Groups["id"].Value))
                                this.idIsimVeritabani.Add(mm.Groups["id"].Value, mm.Groups["isim"].Value);
                        }

                        gercekler.Add(gercek);
	                }

                    kisi.HakkindakiGercekler = gercekler;
                }
            }

            //Kişisel sözlerinin ayrıştırılması
            {
                Regex r = new Regex("<h5>Personal\\s+Quotes</h5>(.*?)<br/>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    List<string> sozler = new List<string>();
                    string kisiselSozler = m.Groups[1].Value;

                    //Alınan kişisel sözler bloğunun temizliği
                    Regex rg = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/search/name?[^<>]*?\">([^<>]*?)</a>", RegexOptions.Singleline);
                    MatchCollection mg = rg.Matches(kisiselSozler);
                    foreach (Match mmg in mg)
                        kisiselSozler = kisiselSozler.Replace(mmg.Value, mmg.Groups[1].Value);
                    kisiselSozler.Replace("<br>", "");

                    r = new Regex("<p>(.*?)</p>", RegexOptions.Singleline);
                    MatchCollection mim = r.Matches(kisiselSozler);

                    foreach (Match mmm in mim)
	                {
                        string soz = "";
                        soz = mmm.Groups[1].Value;

		                Regex r2 = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/(?:title|name)/(?<id>(?:tt|nm)\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                        MatchCollection m2 = r2.Matches(soz);

                        foreach (Match mm in m2)
                        {
                            soz = soz.Replace(mm.Value, ">" + mm.Groups["id"].Value + "<");

                            if (!this.idIsimVeritabani.ContainsKey(mm.Groups["id"].Value))
                                this.idIsimVeritabani.Add(mm.Groups["id"].Value, mm.Groups["isim"].Value);
                        }

                        sozler.Add(soz);
	                }

                    kisi.KisiselSozler = sozler;
                }
            }

        }

        private string prcsHomePageFilmAdi(string metin, int sayfaTuru)
        {
            if ((metin == null) || (metin == "")) return "";

            Regex r = new Regex("<td\\s+rowspan=\"2\"\\s+id=\"img_primary\">(?<icerik>.*?)</td>", RegexOptions.Singleline);
            Regex r2 = new Regex("<title>(?<filmadi>.*?)\\s*[(].*?</title>", RegexOptions.Singleline);
            Match m = r.Match(metin);
            Match m2 = r2.Match(metin);
            
            string donenIsim = "";

            if ((m2.Success) & (m.Success))
            {
                donenIsim =  m2.Groups["filmadi"].Value.Trim();
            }

            if (sayfaTuru == 2)
            {
                Regex rDizi = new Regex("<title>(.*?)</title>", RegexOptions.Singleline);
                Match mDizi1 = rDizi.Match(metin);

                if (mDizi1.Success)
                {
                    rDizi = new Regex("[(].*?(\\d{4}-(?:\\d{4}|\\s*))[)]", RegexOptions.Singleline);
                    mDizi1 = rDizi.Match(mDizi1.Groups[1].Value);
                    if (mDizi1.Success)
                    {
                        donenIsim += " (TV Dizisi " + mDizi1.Groups[1].Value;
                    }
                }
            }

            return donenIsim;
        }
        private string prcHomePageCikisTarihi(string metin)
        {
            string cikisTarihi = "";
            Regex r = new Regex("<h4\\s+class=\"inline\">Release Date:</h4>(?<cikistarihi>.*?)\\s*[(]", RegexOptions.Singleline);
            Match m = r.Match(metin);

            if (m.Success)
            {
                r = new Regex("(\\d*\\s*[^<>()]*\\s*\\d{4})");
                m = r.Match(m.Groups["cikistarihi"].Value);
                cikisTarihi = m.Groups[1].Value.Trim();
            }

            return cikisTarihi;
        }
        
        public Image ResimIndir(string id)
        {
            Image resim;
            string sayfa = "";

            if (id.StartsWith("nm"))
            {
                sayfa = sayfaIndir(Sabitler.IMDBKisisi + id);
                resim = kisiAfisiIndir(sayfa);
                return resim;
            }
            else if (id.StartsWith("tt"))
            {
                sayfa = sayfaIndir(Sabitler.IMDBBasligi + id);
                resim = filmAfisiIndir(sayfa);
                return resim;
            }

            return null;
        }
        private Image kisiAfisiIndir(string metin)
        {
            if ((metin == null) || (metin == "")) return null;

            Regex r = new Regex("<img\\s+src=\"(?<link>[^<>]*?)\"\\s+height=\"\\d+\"\\s+width=\"\\d+\"\\s+alt=\"[^<>]*?\"\\s+title=\"[^<>]*?\"\\s*/>", RegexOptions.Singleline);
            Match m = r.Match(metin);

            string url = "";
            Image resim;

            if (m.Success)
            {
                url = m.Groups["link"].Value.Trim();
            }

            if (url != "")
            {
                WebClient resimindirici = new WebClient();
                byte[] byteResim = resimindirici.DownloadData(url);
                ImageConverter a = new ImageConverter();
                resim = (Image)a.ConvertFrom(byteResim);
                return resim;
            }
            return null;
        }
        private Image filmAfisiIndir(string metin)
        {
            if ((metin == null) || (metin == "")) return null;

            Image afis;
            string filmAfisURL = "";
            Regex r = new Regex("<td\\s+rowspan=\"2\"\\s+id=\"img_primary\">(?<icerik>.*?)</td>", RegexOptions.Singleline);
            Regex r1 = new Regex("<img\\s+src=\"(?<resimlinki>.*?)\".*?/>", RegexOptions.Singleline);
            Match m = r.Match(metin);
            Match m1 = r1.Match(m.Groups["icerik"].Value);

            if ((m1.Success) & (m.Success))
            {
                filmAfisURL = m1.Groups["resimlinki"].Value.Trim();
            }

            if (filmAfisURL != "")
            {
                WebClient resim = new WebClient();
                byte[] byteResim = resim.DownloadData(filmAfisURL);
                ImageConverter a = new ImageConverter();
                afis = (Image)a.ConvertFrom(byteResim);
                return afis;
            }

            return null;
        }

        private void isleAnaSayfa(string metin)
        {
            //Ana Sayfadan Film Afişi, Film Adı, IMDB Puanı, Film Süresi, Çıkış Tarihini, 
            //Ülkeler, Türler, Diller, Bütçe bilgilerini alıcaz.

            //
            // Film afişinin urlsini ana sayfadan ayırıp resmi bizim film nesnemize atıyoruz.
            //
            if ((metin == null) || (metin == "")) return;
            if (film == null) return;

            {
                string filmAfisURL = "";
                Regex r = new Regex("<td\\s+rowspan=\"2\"\\s+id=\"img_primary\">(?<icerik>.*?)</td>", RegexOptions.Singleline);
                Regex r1 = new Regex("<img\\s+src=\"(?<resimlinki>.*?)\".*?/>", RegexOptions.Singleline);
                Regex r2 = new Regex("<title>(?<filmadi>.*?)\\s*[(].*?</title>", RegexOptions.Singleline);
                Match m = r.Match(metin);
                Match m1 = r1.Match(m.Groups["icerik"].Value);
                Match m2 = r2.Match(metin);

                if (dizi != null)
                {
                    Regex rDizi = new Regex("<title>(.*?)</title>", RegexOptions.Singleline);
                    Match mDizi1 = rDizi.Match(metin);

                    if (mDizi1.Success)
                    {
                        rDizi = new Regex("[(].*?(\\d{4}-(?:\\d{4}|\\s*))[)]", RegexOptions.Singleline);
                        mDizi1 = rDizi.Match(mDizi1.Groups[1].Value);
                        if (mDizi1.Success)
                        {
                            dizi.OynadigiYillar = mDizi1.Groups[1].Value;
                        }
                    }
                }

                if ((m1.Success) & (m.Success))
                {
                    filmAfisURL = m1.Groups["resimlinki"].Value.Trim();
                }

                if (m2.Success)
                    film.Ad = m2.Groups["filmadi"].Value.Trim();

                try
                {
                    if (filmAfisURL != "")
                    {
                        film.AfisURL = filmAfisURL;
                        stringIlerlemeKonumu.DynamicInvoke(new object[] { "Film afişi alınıyor" });
                        WebClient resim = new WebClient();
                        byte[] byteResim = resim.DownloadData(filmAfisURL);
                        ImageConverter a = new ImageConverter();
                        film.Afis = (Image)a.ConvertFrom(byteResim);
                    }
                }
                catch (Exception hata)
                {
                    olusanHatalar.Add(hata);
                }
            }
            //
            // IMDB Puanini ayrıştırıyoruz.
            //
            {
                string imdbPuani = "";
                Regex r = new Regex("<span\\s+class=\"rating-rating\">(?<imdbpuani>.*?)<span>", RegexOptions.Singleline);
                Regex r2 = new Regex("<span\\s+style=\"display:none\"\\s+id=\"star-bar-user-rate\"><b>(?<imdbpuani>.*?)</b>", RegexOptions.Singleline);
                Match m = r.Match(metin);
                
                if (m.Success == false) m = r2.Match(metin);

                if (m.Success)
                {
                    imdbPuani = m.Groups["imdbpuani"].Value.Trim();
                }

                film.ImdbPuani = imdbPuani.Trim();
            }

            //
            // Film Süresini ayrıştırıyoruz.   !!! Film Sürelerini Tam AYrıştıramıyor !!!
            //
            {
                string filmSuresi = "";
                Regex r = new Regex("<div\\s+class=\"txt-block\">.*?<h4\\s+class=\"inline\">Runtime:</h4>(?<filmsuresi>.*?)</div>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    r = new Regex("(\\d+)\\s+min");
                    Match mm = r.Match(m.Groups["filmsuresi"].Value);

                    filmSuresi = mm.Groups[1].Value;
                }

                film.Sure = filmSuresi.Trim();
            }

            //
            // Çıkış Tarihini ayrıştırıyoruz.
            //
            {
                string cikisTarihi = "";
                Regex r = new Regex("<h4\\s+class=\"inline\">Release Date:</h4>(?<cikistarihi>[^<>()]*?)\\s*[(]", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    r = new Regex("(\\d*\\s*[^()<>]*\\s*\\d{4})", RegexOptions.Singleline);
                    m = r.Match(m.Groups["cikistarihi"].Value);
                    cikisTarihi = m.Value.Trim();
                }

                film.CikisTarihi = cikisTarihi.Trim();
            }

            //
            // Ülkeleri ayrıştırıyoruz.
            //
            {
                List<string> ulkeler = new List<string>();
                Regex r = new Regex("<a\\s+href=\"/country/[^<>]*\">(?<ulke>.*?)</a>", RegexOptions.Singleline);
                MatchCollection m = r.Matches(metin);

                if (m.Count > 0)
                {
                    foreach (Match mm in m)
                    {
                        ulkeler.Add(mm.Groups["ulke"].Value.Trim());
                    }
                }

                if (ulkeler.Count > 0)
                {
                    film.Ulkeler = ulkeler;
                }
            }

            //
            // Türleri ayrıştırıyoruz.
            //
            {
                List<string> turler = new List<string>();
                Regex r = new Regex("<a\\s+href=\"/genre/[^<>]*\">(?<tur>.*?)</a>", RegexOptions.Singleline);
                MatchCollection m = r.Matches(metin);

                if (m.Count > 0)
                {
                    foreach (Match mm in m)
                    {
                        turler.Add(mm.Groups["tur"].Value.Trim());
                    }
                }

                if (turler.Count > 0)
                {
                    film.Turler = turler;
                }
            }

            //
            // Dilleri ayrıştırıyoruz
            //
            {
                List<string> diller = new List<string>();
                Regex r = new Regex("<a\\s+href=\"/language/[^<>]*\">(?<dil>.*?)</a>", RegexOptions.Singleline);
                MatchCollection m = r.Matches(metin);

                if (m.Count > 0)
                {
                    foreach (Match mm in m)
                    {
                        diller.Add(mm.Groups["dil"].Value.Trim());
                    }
                }

                if (diller.Count > 0)
                {
                    film.Diller = diller;
                }
            }

            //
            // Bütçe ayrıştırıyoruz.
            //
            {
                string butce = "";
                Regex r = new Regex("<h4\\s+class=\"inline\">Budget:</h4>(?<butce>.*?)</div>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    r = new Regex("([$]{1}[\\d,]*)");
                    m = r.Match(m.Groups["butce"].Value);
                    butce = m.Groups[1].Value.Trim();
                }

                film.Butce = butce.Trim();
            }
        }
        private void isleOduller(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            SortedDictionary<int, KategoriKisi> elemanlar = new SortedDictionary<int, KategoriKisi>();

            Regex r1 = new Regex("<big><a\\s+href=\"/Sections/Awards/\\w*/\">(?<odulverenkurum>[^<>]*?)</a></big>", RegexOptions.Singleline);
            Regex r2 = new Regex("<a\\s+href=\"/Sections/Awards/\\w*/\\d{4}\">(?<yil>[^<>]*?)</a>", RegexOptions.Singleline);
            Regex r3 = new Regex("<td\\s+rowspan=\"\\d*\"\\s+align=\"center\"\\s+valign=\"middle\"><b>(?<sonuc>[^<>]*?)</b></td>", RegexOptions.Singleline);
            Regex r4 = new Regex("<td\\s+rowspan=\"\\d*\"\\s+align=\"center\"\\s+valign=\"middle\">(?<odul>[^<>]*?)</td>", RegexOptions.Singleline);
            Regex r5 = new Regex("<td\\s+valign=\"top\">(?<kategoriadi>[^<>]*?)<br>", RegexOptions.Singleline);
            Regex r6 = new Regex("<a\\s+href=\"/name/(?<imdbid>nm\\d{7})/\">(?<kisiadi>[^<>]*?)</a>", RegexOptions.Singleline);

            MatchCollection m1 = r1.Matches(metin);
            MatchCollection m2 = r2.Matches(metin);
            MatchCollection m3 = r3.Matches(metin);
            MatchCollection m4 = r4.Matches(metin);
            MatchCollection m5 = r5.Matches(metin);
            MatchCollection m6 = r6.Matches(metin);

            foreach (Match mm in m1) { if (mm.Success) { elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["odulverenkurum"].Value, "kurumadi")); } }
            foreach (Match mm in m2) { if (mm.Success) { elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["yil"].Value, "yil")); } }
            foreach (Match mm in m3) { if (mm.Success) { elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["sonuc"].Value, "sonuc")); } }
            foreach (Match mm in m4) { if (mm.Success) { elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["odul"].Value, "odul")); } }
            foreach (Match mm in m5) { if (mm.Success) { elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["kategoriadi"].Value, "kategoriadi")); } }
            foreach (Match mm in m6) { if (mm.Success) { elemanlar.Add(mm.Index, new KategoriKisi(new isimID(mm.Groups["imdbid"].Value, mm.Groups["kisiadi"].Value), "kisi")); } }

            SortedDictionary<int, KategoriKisi>.Enumerator a = elemanlar.GetEnumerator();
            a.MoveNext();
            List<Odul> oduller = new List<Odul>();

            string odulverenkurum = ""; string yil = ""; string sonuc = ""; string odulAdi = ""; string kategoriadi = ""; 

            for (int i = 0; i < elemanlar.Count; i++)
            {
                if (a.Current.Value.tur == "kurumadi")
                {
                    odulverenkurum = (string)a.Current.Value.deger;
                }
                if (a.Current.Value.tur == "yil")
                {
                    yil = (string)a.Current.Value.deger;
                }
                if (a.Current.Value.tur == "sonuc")
                {
                    sonuc = (string)a.Current.Value.deger;
                }
                if (a.Current.Value.tur == "odul")
                {
                    odulAdi = (string)a.Current.Value.deger;
                }
                if (a.Current.Value.tur == "kategoriadi")
                {
                    kategoriadi = (string)a.Current.Value.deger;
                }
                if (a.Current.Value.tur == "kisi")
                {
                    Odul odul = new Odul();
                    odul.odulAdi = odulAdi.Trim();
                    odul.odulVerenKurum = odulverenkurum.Trim();
                    odul.yil = yil.Trim();
                    odul.sonuc = sonuc.Trim();
                    odul.kategori = kategoriadi.Trim();
                    odul.aliciID = ((isimID)a.Current.Value.deger).id.Trim();
                    oduller.Add(odul);

                    if (!idIsimVeritabani.ContainsKey(odul.aliciID))
                        idIsimVeritabani.Add(odul.aliciID.Trim(), ((isimID)a.Current.Value.deger).isim.Trim());
                }
                a.MoveNext();
            }

            film.Odulleri = oduller;
        }
        private void isleTumKadro(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            SortedDictionary<int, KategoriKisi> kisiID = new SortedDictionary<int, KategoriKisi>();
            SortedDictionary<int, KategoriKisi> castID = new SortedDictionary<int, KategoriKisi>();
            SortedDictionary<int, KategoriKisi> karakterID = new SortedDictionary<int, KategoriKisi>();
            
            //sayfadaki tüm kategorilerin listesi ve indeksleri
            Regex r = new Regex("<a\\s+class=\"glossary\"\\s+name=\"\\w*\"\\s+href=\"/glossary/[a-zA-Z0-9_#]*\">(?<kategoriadi>[^<>]*?)</a>", RegexOptions.Singleline);
            MatchCollection mc = r.Matches(metin);
            foreach (Match m in mc)
                kisiID.Add(m.Index, new KategoriKisi(m.Groups["kategoriadi"].Value.Trim(), "kategori"));
            
            //Cast listesi hariç kategoriler altındaki kişilerin imdidleri ve indeksleri
            r = new Regex("<a\\s+href=\"/name/(?<imdbid>nm\\d{7})/\">(?<isim>.*?)</a>", RegexOptions.Singleline);
            mc = r.Matches(metin);
            foreach (Match m in mc)
            {
                isimID yeni = new isimID();
                yeni.id = m.Groups["imdbid"].Value.Trim();
                yeni.isim = m.Groups["isim"].Value.Trim();
                kisiID.Add(m.Index, new KategoriKisi(yeni, "kisi"));
            }

            r = new Regex("<td valign=\"top\">(?:<a href=\"[^<>]*\">|\\s*)(?<gorev>[^<>\\xA0]*?)(?:</a>\\s*|\\s*)</td></tr>", RegexOptions.Singleline);
            mc = r.Matches(metin);
            foreach (Match m in mc)
            {
                if (m.Groups["gorev"].Value != "")
                {
                    kisiID.Add(m.Index, new KategoriKisi(m.Groups["gorev"].Value.Trim(), "gorev"));
                }
            }

            //Cast listesindeki kişilerin imdbidleri ve indeksleri
            r = new Regex("<td\\s+class=\"nm\">(.*?)</td>", RegexOptions.Singleline);
            mc = r.Matches(metin);
            foreach (Match m in mc)
            {
                Regex r2 = new Regex("link=/name/(?<imdbid>nm\\d{7})/';\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                MatchCollection m2 = r2.Matches(m.Groups[1].Value);

                foreach (Match mm in m2)
                {
                    isimID yeni = new isimID();
                    yeni.id = mm.Groups["imdbid"].Value.Trim();
                    yeni.isim = mm.Groups["isim"].Value.Trim();
                    castID.Add(m.Index + mm.Index, new KategoriKisi(yeni, "kisi"));
                }
            }

            r = new Regex("<td\\s+class=\"char\">(.*?)</td>", RegexOptions.Singleline);
            mc = r.Matches(metin);
            string eslesme = "";
            foreach (Match m in mc)
            {
                List<isimID> karakterler = new List<isimID>();
                string aciklama = "";

                eslesme = m.Groups[1].Value;
                Regex r2 = new Regex("<a\\s+href=\"(?:http://www.imdb.com|\\s*)/character/(?<imdbid>ch\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                MatchCollection m2 = r2.Matches(eslesme);
                foreach (Match mm in m2)
                {
                    isimID yeni = new isimID();
                    yeni.id = mm.Groups["imdbid"].Value.Trim();
                    yeni.isim = mm.Groups["isim"].Value.Trim();
                    karakterler.Add(yeni);
                    eslesme = eslesme.Replace(mm.Value, "");
                }
                eslesme = eslesme.Trim();

                if ((eslesme != "") && (eslesme.Contains('/')))
                {
                    string[] parcalar = eslesme.Split('/');
                    foreach (string s in parcalar.ToArray())
                    {
                        if (s.Trim() != "")
                        {
                            r2 = new Regex("([(](.*?)[)])");
                            m2 = r2.Matches(s);
                            foreach (Match mm in m2)
                            {
                                aciklama += mm.Groups[1].Value + "@";
                                eslesme = eslesme.Replace(mm.Value.Trim(), "").Trim();
                            }
                
                            isimID yeni = new isimID();
                            yeni.isim = s.Trim();
                            yeni.id = "xx0000000";
                            karakterler.Add(yeni);
                        }
                    }
                }
                else if (eslesme != "")
                {
                    r2 = new Regex("([(](.*?)[)])");
                    m2 = r2.Matches(eslesme);
                    foreach (Match mm in m2)
                    {
                        aciklama += mm.Groups[1].Value + "@";
                        eslesme = eslesme.Replace(mm.Value, "").Trim();
                    }
                }

                if (eslesme != "")
                {
                    isimID yeni = new isimID();
                    yeni.isim = eslesme.Trim();
                    yeni.id = "xx0000000";
                    karakterler.Add(yeni);
                }

                IsimlerAciklama yepyeni = new IsimlerAciklama();
                yepyeni.aciklama = aciklama;
                yepyeni.isimler = karakterler;

                karakterID.Add(m.Index, new KategoriKisi(yepyeni, "karakter"));
            }

            {
                SortedDictionary<int, KategoriKisi>.Enumerator kisiIlerleyici = kisiID.GetEnumerator();

                List<DigerKisi> kisiler = new List<DigerKisi>();
                kisiIlerleyici.MoveNext();
                string guncelKategori = "";

                for (int i = 0; i < kisiID.Count; i++)
                {
                    if (kisiIlerleyici.Current.Value.tur == "kategori")
                    {
                        guncelKategori = ((string)kisiIlerleyici.Current.Value.deger).Trim();
                    }

                    if (kisiIlerleyici.Current.Value.tur == "kisi")
                    {
                        DigerKisi kisi = new DigerKisi();
                        kisi.departmanVeyaGorev = guncelKategori.Trim();
                        kisi.kisiID = ((isimID)kisiIlerleyici.Current.Value.deger).id.Trim();
                        kisiler.Add(kisi);

                        if (!idIsimVeritabani.ContainsKey(kisi.kisiID))
                            idIsimVeritabani.Add(kisi.kisiID.Trim(), ((isimID)kisiIlerleyici.Current.Value.deger).isim.Trim());
                    }
                    if (kisiIlerleyici.Current.Value.tur == "gorev")
                    {
                        kisiler[kisiler.Count - 1].gorevAciklamasi = ((string)kisiIlerleyici.Current.Value.deger).Trim();
                    }
                    if (!kisiIlerleyici.MoveNext()) break;
                }

                film.DigerKisiler = kisiler;
            }

            {
                SortedDictionary<int, KategoriKisi>.Enumerator karakterIlerleyici = karakterID.GetEnumerator();
                SortedDictionary<int, KategoriKisi>.Enumerator castIlerleyici = castID.GetEnumerator();

                List<FilmKarakteri> karakterListesi = new List<FilmKarakteri>();
                karakterIlerleyici.MoveNext();
                castIlerleyici.MoveNext();

                do
                {
                    FilmKarakteri karakter = new FilmKarakteri();

                    karakter.oyuncuID = ((isimID)castIlerleyici.Current.Value.deger).id.Trim();
                    if (!idIsimVeritabani.ContainsKey(karakter.oyuncuID))
                    {
                        idIsimVeritabani.Add(karakter.oyuncuID.Trim(), ((isimID)castIlerleyici.Current.Value.deger).isim.Trim());
                    }

                    karakter.karakterler = ((IsimlerAciklama)karakterIlerleyici.Current.Value.deger).isimler;
                    karakter.aciklama = ((IsimlerAciklama)karakterIlerleyici.Current.Value.deger).aciklama;

                    foreach (isimID isimid in karakter.karakterler)
                    {
                        if ((isimid.id != "xx0000000") && (!idIsimVeritabani.ContainsKey(isimid.id.Trim())))
                            idIsimVeritabani.Add(isimid.id.Trim(), isimid.isim.Trim());
                    }

                    karakterListesi.Add(karakter);

                } while (karakterIlerleyici.MoveNext() & castIlerleyici.MoveNext());

                film.Karakterler = karakterListesi;
            }
        }
        private void isleTumKadroDizi(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            #region Cast Listesi Haricindeki Kişilerin İşlenmesi
            {
                Regex r = new Regex("<table\\s+border=\"\\d*\"\\s+cellpadding=\"\\d*\"\\s*cellspacing=\"\\d*\">(.*?)</table>", RegexOptions.Singleline);
                MatchCollection m = r.Matches(metin);

                List<DigerKisi> digerKisiler = new List<DigerKisi>();
                List<KisiBolumSayisiYillari> kisiBolumSayisiYillari = new List<KisiBolumSayisiYillari>();

                foreach (Match mm in m)
                {
                    r = new Regex("<tr>(.*?)</tr>", RegexOptions.Singleline);
                    MatchCollection m2 = r.Matches(mm.Groups[1].Value);

                    string kategori = "";
                    if (m2.Count > 0)
                    {
                        kategori = Regex.Match(m2[0].Value, "<a.*?>([^<>]*?)</a>", RegexOptions.Singleline).Groups[1].Value;
                    }

                    int kategoriyiAtla = 0;
                    foreach (Match mmm in m2)
                    {
                        #region Herbir Kategorideki Kişilerin İşlenmesi
                        kategoriyiAtla++; if (kategoriyiAtla == 1) continue;

                        DigerKisi yeniDigerkisi = new DigerKisi();
                        yeniDigerkisi.departmanVeyaGorev = kategori;

                        KisiBolumSayisiYillari yeniKisiBolumSayisiYillari = new KisiBolumSayisiYillari();

                        Regex r2 = new Regex("<td\\s+valign=\"top\"><a\\s+href=\"/name/(nm\\d{7})/\">([^<>]*?)</a></td>", RegexOptions.Singleline);
                        Match m3 = r2.Match(mmm.Value);

                        if (m3.Success)
                        {
                            yeniKisiBolumSayisiYillari.kisiID = yeniDigerkisi.kisiID = m3.Groups[1].Value.Trim();

                            //id isim veritabanının güncelle
                            if (!idIsimVeritabani.ContainsKey(yeniDigerkisi.kisiID))
                                idIsimVeritabani.Add(yeniDigerkisi.kisiID, m3.Groups[2].Value.Trim());
                        }

                        r2 = new Regex("<td\\s+valign=\"top\">(?:<a\\s+href=\"(?:http://www.imdb.com|\\s*)/glossary/[^<>]*?\">(?<a>[^<>]*)</a>)|(?:(?<a>[^<>]*?|\\s*))[(](?<bs>\\d+|unknown)\\s*episodes\\s*[,]?\\s*(?<th>\\d{4}-\\d{4}|\\d{4}|\\s*)[)]</td>", RegexOptions.Singleline);
                        m3 = r2.Match(mmm.Value);
                        if (m3.Success)
                        {
                            if (m3.Groups[1].Value == "unknown")
                            {
                                yeniKisiBolumSayisiYillari.bolumSayisi = ""; 
                            }
                            else
                            {
                                yeniKisiBolumSayisiYillari.bolumSayisi = m3.Groups["bs"].Value.Trim();
                            }
                            yeniKisiBolumSayisiYillari.gorevYillari = m3.Groups["th"].Value.Trim();

                            string aciklama = "";
                            aciklama = m3.Groups["a"].Value.Trim();
                            if (aciklama != "")
                            {
                                if (aciklama.Contains("...")) aciklama = aciklama.Replace("...", "").Trim();
                                if (aciklama.EndsWith("/")) aciklama = aciklama.Remove(aciklama.LastIndexOf('/'), 1).Trim();
                            }

                            yeniDigerkisi.gorevAciklamasi = aciklama; 
                        }
                        digerKisiler.Add(yeniDigerkisi);
                        kisiBolumSayisiYillari.Add(yeniKisiBolumSayisiYillari);
                        #endregion
                    }
                }

                if (dizi != null)
                {
                    dizi.DigerKisiler = digerKisiler;
                    dizi.DigerlerininRolSayilari.AddRange(kisiBolumSayisiYillari);
                }
            }
            #endregion

            #region Cast Listesinin İşlenmesi
            {
                List<FilmKarakteri> karakterler = new List<FilmKarakteri>();
                List<KisiBolumSayisiYillari> kbs = new List<KisiBolumSayisiYillari>();

                Regex r = new Regex("<table\\s+class=\"cast\">(.*?)</table>", RegexOptions.Singleline);
                Match m = r.Match(metin);

                if (m.Success)
                {
                    Regex r2 = new Regex("<tr\\s+class=\"(?:odd|even)\">(.*?)</tr>", RegexOptions.Singleline);
                    MatchCollection m2 = r2.Matches(m.Groups[1].Value);

                    foreach (Match m2m in m2)
                    {
                        #region Cast İsimleri Parsers
                        FilmKarakteri yeniKarakter = new FilmKarakteri();
                        KisiBolumSayisiYillari yenikbsy = new KisiBolumSayisiYillari();

                        Regex r3 = new Regex("<a\\s+href=\"/name/(?<id>nm\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                        Match m3 = r3.Match(m2m.Groups[1].Value);
                        if (m3.Success)
                        {
                            yeniKarakter.oyuncuID = m3.Groups["id"].Value.Trim();
                            yenikbsy.kisiID = yeniKarakter.oyuncuID;

                            //veritabanını güncelleyelim.
                            if (!idIsimVeritabani.ContainsKey(yeniKarakter.oyuncuID))
                                idIsimVeritabani.Add(yeniKarakter.oyuncuID, m3.Groups["isim"].Value.Trim());

                        }

                        r3 = new Regex("<td\\s+class=\"char\">(.*?)</td>", RegexOptions.Singleline);
                        m3 = r3.Match(m2m.Groups[1].Value);
                        string icerik = "";

                        if (m3.Success)
                        {
                            #region Karakter İsimleri Parsers
                            icerik = m3.Groups[1].Value;
                            Regex r4 = new Regex("[(](?<bs>\\d+|unknown)\\s*episodes\\s*[,]?\\s*(?<th>\\d{4}-\\d{4}|\\d{4}|\\s*)[)]", RegexOptions.Singleline);
                            Match m4 = r4.Match(icerik);

                            if (m4.Success)
                            {
                                yenikbsy.bolumSayisi = (m4.Groups["bs"].Value == "unknown" ? "" : m4.Groups["bs"].Value.Trim());
                                yenikbsy.gorevYillari = m4.Groups["th"].Value.Trim();
                                icerik = icerik.Replace(m4.Value, "").Trim();
                            }

                            r4 = new Regex("<a\\s+href=\"/character/(?<id>ch\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                            m4 = r4.Match(icerik);
                            if (m4.Success)
                            {
                                string id = ""; id = m4.Groups["id"].Value.Trim();
                                string isim = ""; isim = m4.Groups["isim"].Value.Trim();
                                yeniKarakter.karakterler.Add(new isimID(id, isim));

                                //veritabanını güncelleyelim.
                                if (!idIsimVeritabani.ContainsKey(id))
                                    idIsimVeritabani.Add(id, isim);

                                icerik = icerik.Replace(m4.Value, "").Trim();
                            }

                            if (icerik != "")
                            {
                                if (icerik.Contains("...")) icerik = icerik.Replace("...", "").Trim();
                                if (icerik.EndsWith("/")) icerik = icerik.Remove(icerik.LastIndexOf('/'), 1).Trim();
                            }

                            if (icerik.Trim() != "")
                            {
                                yeniKarakter.karakterler.Add(new isimID("xx0000000", icerik.Trim()));
                            }
                            #endregion
                        }

                        karakterler.Add(yeniKarakter);
                        kbs.Add(yenikbsy);
                        #endregion
                    }
                }

                dizi.Karakterler = karakterler;
                dizi.OyuncuRolSayilari.AddRange(kbs);
            } 
            #endregion
        }
        private void isleOzetler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<p\\s+class=\"plotpar\">(?<olayorgusu>.*?)</p>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (mm.Success)
                {
                    string ozet = Regex.Replace(mm.Groups["olayorgusu"].Value, "<i>.*?</i>", "", RegexOptions.Singleline);
                    film.Ozetler.Add(ozet.Trim());
                }
            }
        }
        private void isleKelimeler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<a\\s+href=\"/keyword/[^<>]*?/\">(?<keyword>.*?)</a>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (mm.Success)
                {
                    film.AnahtarKelimeler.Add(mm.Groups["keyword"].Value.Trim());
                }
            }
        }
        private void isleSloganlar(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<p>(?<tagline>[^<>]*?)</p>", RegexOptions.Singleline);
            MatchCollection mm = r.Matches(metin);
            foreach (Match mmm in mm)
            {
                if (mmm.Success)
                {
                    film.Sloganlar.Add(mmm.Groups["tagline"].Value.Trim());
                }
            }
        }
        private void isleResmiSiteler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<ol><li>(?<linkler>.*)</li>\\s*</ol>\\s*.*<h3>Related\\s+Links.*</h3>");
            Match m = r.Match(metin);
            string linkler = "";

            if (m.Success)
            {
                linkler = m.Groups["linkler"].Value.Trim();

                film.WebSayfalari = StaticFonksiyonlar.linkCozucu(linkler);
            }
        }
        private void isleSirketler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            SortedDictionary<int, KategoriKisi> sirketler = new SortedDictionary<int, KategoriKisi>();

            //Prodüksiyon şirketi
            Regex r = new Regex("<h2>Production\\s+Companies</h2>");
            Match m = r.Match(metin);
            if (m.Success) sirketler.Add(m.Index, new KategoriKisi("Prodüksiyon Şirketleri", "kategori"));

            //Distribitor
            r = new Regex("<h2>Distributors</h2>");
            m = r.Match(metin);
            if (m.Success) sirketler.Add(m.Index, new KategoriKisi("Dağıtım Şirketleri", "kategori"));

            //Special Effects
            r = new Regex("<h2>Special\\s+Effects</h2>");
            m = r.Match(metin);
            if (m.Success) sirketler.Add(m.Index, new KategoriKisi("Özel Efekt Şirketleri", "kategori"));

            //Other Companies
            r = new Regex("<h2>Other\\s+Companies</h2>");
            m = r.Match(metin);
            if (m.Success) sirketler.Add(m.Index, new KategoriKisi("Diğer Şirketler", "kategori"));

            Regex r3 = new Regex("<a\\s+href=\"/company/(?<sirketid>co[0-9]{7})/\">(?<sirketadi>[^<>]*?)</a>", RegexOptions.Singleline);
            MatchCollection m2 = r3.Matches(metin);

            
            foreach (Match mm in m2)
            {
                if (mm.Success)
                {
                    sirketler.Add(mm.Index, new KategoriKisi(new isimID(mm.Groups["sirketid"].Value.Trim(), mm.Groups["sirketadi"].Value.Trim()), "sirket"));
                }
            }

            {
                SortedDictionary<int, KategoriKisi>.Enumerator sirketIlerleyici = sirketler.GetEnumerator();

                List<Sirket> sirkets = new List<Sirket>();
                sirketIlerleyici.MoveNext();
                string guncelKategori = "";

                for (int i = 0; i < sirketler.Count; i++)
                {
                    if (sirketIlerleyici.Current.Value.tur == "kategori")
                    {
                        guncelKategori = ((string)sirketIlerleyici.Current.Value.deger).Trim();
                    }

                    if (sirketIlerleyici.Current.Value.tur == "sirket")
                    {
                        Sirket sirket = new Sirket();
                        sirket.companyTypes.Add(guncelKategori);
                        sirket.companyName = ((isimID)sirketIlerleyici.Current.Value.deger).isim.Trim();
                        sirket.companyID = ((isimID)sirketIlerleyici.Current.Value.deger).id.Trim();
                        sirkets.Add(sirket);

                        if (!idIsimVeritabani.ContainsKey(sirket.companyID.Trim()))
                            idIsimVeritabani.Add(sirket.companyID.Trim(), sirket.companyName.Trim());
                    }
                    if (!sirketIlerleyici.MoveNext()) break;
                }

                film.Sirketler = sirkets;
            }
        }
        private void isleCikisBilgileri(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            {
                Regex r = new Regex("<a\\s+href=\"/calendar/[?]{1}region=.{2}\">(?<ulke>[^<>]*)</a></b></td>\\s*<td\\s+align=\"right\"><a\\s+href=\"/date/.{5}/\">(?<tarih1>[^<>]*)</a>\\s+<a\\s+href=\"/year/.{4}/\">(?<tarih2>[^<>]*)</a></td>");
                MatchCollection m = r.Matches(metin);
                List<CikisTarihiYeri> cikisbilgileri = new List<CikisTarihiYeri>();
                foreach (Match mm in m)
                {
                    if (mm.Success)
                    {
                        CikisTarihiYeri yeni = new CikisTarihiYeri();
                        yeni.releaseDate = Convert.ToDateTime(mm.Groups["tarih1"].Value.Trim() + mm.Groups["tarih2"].Value.Trim());
                        yeni.releaseCountry = mm.Groups["ulke"].Value.Trim();
                        cikisbilgileri.Add(yeni);
                    }
                }

                film.CikisTarihleriYerleri = cikisbilgileri;
            }

            {
                Regex r = new Regex("<h5><a\\s+name=\"akas\">[^<>]*</a></h5>");
                Match m = r.Match(metin);
                int konum = m.Index;

                if (m.Success)
                {
                    Regex r2 = new Regex("<td>(?<digeradi>[^<>]*)</td>");
                    MatchCollection m2 = r2.Matches(metin, konum);

                    SortedDictionary<int, KategoriKisi> baskaisimler = new SortedDictionary<int, KategoriKisi>();

                    foreach (Match mm in m2)
                    {
                        if (mm.Success)
                        {
                            baskaisimler.Add(mm.Index, new KategoriKisi(mm.Groups["digeradi"].Value.Trim(), "digeradi"));
                        }
                    }

                    if (baskaisimler.Count % 2 != 0) return; //eğer liste digeri adi / ülke şeklinde gitmiyorsa.

                    SortedDictionary<int, KategoriKisi>.Enumerator baskaisimIlerleyici = baskaisimler.GetEnumerator();
                    baskaisimIlerleyici.MoveNext();
                    List<IsimUlkeler> isimler = new List<IsimUlkeler>();

                    for (int i = 0; i < baskaisimler.Count; i++)
			        {
                        if (i % 2 == 0)
                        {
                            isimler.Add(new IsimUlkeler());
                            isimler[isimler.Count - 1].isim = ((string)baskaisimIlerleyici.Current.Value.deger).Trim();
                        }
                        if (i % 2 == 1)
                        {
                            if (((string)baskaisimIlerleyici.Current.Value.deger).Contains('/'))
                            {
                                isimler[isimler.Count - 1].ulkeler.AddRange(((string)baskaisimIlerleyici.Current.Value.deger).Split('/').ToArray<string>());
                            }
                            else
                                isimler[isimler.Count - 1].ulkeler.Add((string)baskaisimIlerleyici.Current.Value.deger);
                        }
                        baskaisimIlerleyici.MoveNext();
			        }
                    film.DigerAdlariUlkelereGore = isimler;
                }
            }
        }
        private void isleGercekler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<div\\s+class=\"sodatext\">(?<icerik>.*?)<br>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);
            List<string> cekimGercegi = new List<string>();

            foreach (Match mm in m)
	        {
		        if (mm.Success)
                {
                    string cekimgercegi = "";
                    cekimgercegi = mm.Groups["icerik"].Value.Trim();
                    Regex r2 = new Regex("<a\\s+href=\"/(?:title|name)/(?<id>(?:tt|nm)\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                    MatchCollection m2 = r2.Matches(cekimgercegi);
                    
                    foreach (Match mmm in m2)
                    {
                        if (mmm.Success)
                        {
                            if (cekimgercegi.Contains(mmm.Value))
                            {
                                cekimgercegi = cekimgercegi.Replace(mmm.Value, ">" + mmm.Groups["id"].Value.Trim() + "<");
                            }


                            if (!idIsimVeritabani.ContainsKey(mmm.Groups["id"].Value.Trim()))
                                idIsimVeritabani.Add(mmm.Groups["id"].Value.Trim(), mmm.Groups["isim"].Value.Trim());
                        }
                    }
                    cekimGercegi.Add(cekimgercegi);
                }
	        }

            film.Gercekler = cekimGercegi;

        }
        private void isleHatalar(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<li><a\\s+name=\"#gf\\d{7}\">(?<icerik>.*?)</li>", RegexOptions.Singleline);
            Regex r2 = new Regex("<b>(?<hatabasligi>.*?):</b>");
            Regex r3 = new Regex("</b>(?<hatametni>.*?)<br>");

            MatchCollection m = r.Matches(metin);
            List<CekimHatasi> hatalar = new List<CekimHatasi>();

            foreach (Match mm in m)
            {
                if (mm.Success)
                {
                    CekimHatasi yeni = new CekimHatasi();
                    
                    {
                        Match m2 = r2.Match(mm.Groups["icerik"].Value);
                        yeni.hataBasligi = m2.Groups["hatabasligi"].Value.Trim();
                    }
                    {
                        Match m2 = r3.Match(mm.Groups["icerik"].Value);
                        yeni.metin = m2.Groups["hatametni"].Value.Trim();
                    }

                    hatalar.Add(yeni);
                }
            }

            film.Hatalar = hatalar;
        }
        private void isleReplikler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<div\\s+id=\"(?<repid>qt\\d{7})\"\\s+class=\"soda\"><div\\s+class=\"sodatext\">(?<icerik>.*?)</div>", RegexOptions.Singleline);
            Regex r2 = new Regex("<a\\s+href=\"/name/(?<id>nm\\d{7})/\">(?<isim>.*?)</a>", RegexOptions.Singleline);
            Regex r3 = new Regex("</b>(?<soz>.*?)<br>", RegexOptions.Singleline);
            Regex r4 = new Regex("<i\\s+class=\"fine\">(?<davranis>.*?)</i>", RegexOptions.Singleline); //Repliklerin başındaki [aktör sahneye girer...] gibi kısımlar.

            MatchCollection m = r.Matches(metin);
            List<Replik> alintilar = new List<Replik>();

            foreach (Match mm in m)
            {

                Match m2 = r2.Match(mm.Groups["icerik"].Value);
                Match m3 = r3.Match(mm.Groups["icerik"].Value);
                    
                Replik y = new Replik();
                y.replikID = mm.Groups["repid"].Value;

                while ((m2.Success) & (m3.Success))
                {
                    Replik.KisiSoz yeni = new Replik.KisiSoz();
                    yeni.kisiID = m2.Groups["id"].Value.Trim();
                    yeni.soz = m3.Groups["soz"].Value.StartsWith(":") == true ?
                                                                m3.Groups["soz"].Value.Substring(1).Trim() :
                                                                m3.Groups["soz"].Value.Trim();
                    Match m4 = r4.Match(yeni.soz);
                    if (m4.Success) 
                    {
                        yeni.soz = yeni.soz.Replace(m4.Value, m4.Groups["davranis"].Value.Trim()); 
                    }

                    y.alintilar.Add(yeni);
                    m2 = m2.NextMatch();
                    m3 = m3.NextMatch();

                    if (!idIsimVeritabani.ContainsKey(yeni.kisiID.Trim()))
                        idIsimVeritabani.Add(yeni.kisiID.Trim(), m2.Groups["isim"].Value.Trim());
                }

                alintilar.Add(y);
            }

            film.Replikler = alintilar;
        }
        private void isleAbartiGercekler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<tt>(?<metin>.*?)</tt>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (mm.Success)
                {
                    string txt = mm.Groups["metin"].Value.Trim();
                    txt = Regex.Replace(txt, "\\n", " ").Trim();
                    txt = Regex.Replace(txt, "<br>", "").Trim();
                    film.AbartiGercekler.Add(txt.Trim());
                }
            }
        }
        private void isleReferanslar(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            SortedDictionary<int, KategoriKisi> elemanlar = new SortedDictionary<int, KategoriKisi>();
            List<BaglantiKategorisi> baglantilar = new List<BaglantiKategorisi>();

            Regex r = new Regex("<h5>(?<katadi>[^<>]*?)</h5>", RegexOptions.Singleline);
            Regex r2 = new Regex("<a\\s+href=\"/title/(?<id>tt\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
            Regex r3 = new Regex("<h3>Related\\s+Links</h3>");
            Regex r4 = new Regex("<br/>(?<aciklama>[^<>]*?)<br/>");
            MatchCollection m = r.Matches(metin);
            if (m.Count == 0)
            {
                film.Referanslar = new List<BaglantiKategorisi>();
                return;
            }
            MatchCollection m2 = r2.Matches(metin, m[0].Index);
            MatchCollection m4 = r4.Matches(metin, m[0].Index);
            Match m3 = r3.Match(metin);

            foreach (Match mm in m)
            {
                if (mm.Success)
                {
                    elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["katadi"].Value.Trim(), "kategori"));
                }
            }

            foreach (Match mm in m2)
            {
                if ((mm.Success) & (mm.Index < m3.Index))
                {
                    elemanlar.Add(mm.Index, new KategoriKisi(new isimID(mm.Groups["id"].Value.Trim(), mm.Groups["isim"].Value.Trim()), "kisiid"));
                }
            }

            foreach (Match mm in m4)
            {
                if ((mm.Success) & (mm.Index < m3.Index))
                {
                    elemanlar.Add(mm.Index, new KategoriKisi(mm.Groups["aciklama"].Value.Trim(), "aciklama"));
                }
            }

            SortedDictionary<int, KategoriKisi>.Enumerator i = elemanlar.GetEnumerator();
            i.MoveNext();
            string katadi = "";
            string id = "";

            do
            {
                if (i.Current.Value.tur == "kategori")
                {
                    BaglantiKategorisi yeni = new BaglantiKategorisi();
                    katadi = ((string)i.Current.Value.deger).Trim();
                    yeni.kategoriAdi = katadi.Trim();
                    baglantilar.Add(yeni);
                }
                if (i.Current.Value.tur == "kisiid")
                {
                    id = ((isimID)i.Current.Value.deger).id.Trim();
                    baglantilar[baglantilar.Count - 1].filmID_Aciklama.Add(id.Trim(), "");

                    if (!idIsimVeritabani.ContainsKey(id))
                        idIsimVeritabani.Add(id, ((isimID)i.Current.Value.deger).isim.Trim());
                }
                if (i.Current.Value.tur == "aciklama")
                {
                    string aciklama = "";
                    aciklama = ((string)i.Current.Value.deger).Trim();
                    aciklama = aciklama.Replace("<br/>", "");
                    baglantilar[baglantilar.Count - 1].filmID_Aciklama[id] = aciklama;
                }
                
            }
            while (i.MoveNext());

            film.Referanslar = baglantilar;
        }
        private void isleMuzikler(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex kes = new Regex("<ul\\s+class=\"trivia\">(?<kabuk>.*?)</ul>", RegexOptions.Singleline);
            Match m = kes.Match(metin);
            List<FilmMuzigi> muzikler = new List<FilmMuzigi>();

            if (!m.Success) return;
            
            Regex parcala = new Regex("<li>(?<parca>.*?)</li>", RegexOptions.Singleline);
            MatchCollection mm = parcala.Matches(m.Groups["kabuk"].Value);

            foreach (Match song in mm)
            {
                if (!song.Success) continue;
                
                FilmMuzigi yeni = new FilmMuzigi();

                Regex sarki = new Regex("^(?<sarkiadi>.*?)</b><br>", RegexOptions.Singleline);
                Match msarki = sarki.Match(song.Groups["parca"].Value);

                if (msarki.Success)
                    yeni.muzikAdi = msarki.Groups["sarkiadi"].Value.Trim();

                sarki = new Regex("</b><br>(?<ayrintilar>.*?)(<br><br>|$)", RegexOptions.Singleline);
                msarki = sarki.Match(song.Groups["parca"].Value);

                if (!msarki.Success) continue;
                string ayrintilar = msarki.Groups["ayrintilar"].Value.Trim();
                sarki = new Regex("<a\\s+href=\"/name/(?<id>nm\\d{7})/\">(?<isim>.*?)</a>", RegexOptions.Singleline);
                MatchCollection mms = sarki.Matches(ayrintilar);

                foreach (Match mc in mms)
                {
                    if (!mc.Success) continue;
                    ayrintilar = ayrintilar.Replace(mc.Value, ">" + mc.Groups["id"].Value.Trim() + "<");
                    yeni.metin = ayrintilar;

                    if (!idIsimVeritabani.ContainsKey(mc.Groups["id"].Value.Trim()))
                        idIsimVeritabani.Add(mc.Groups["id"].Value.Trim(), mc.Groups["isim"].Value.Trim());
                }

                if (mms.Count == 0)
                {
                    yeni.metin = ayrintilar.Trim();
                }

                muzikler.Add(yeni);
            }
            film.Muzikler = muzikler;   
        }
        private void filmNesnesiniDuzenle()
        {
            if (this.film != null)
            {
                //yönetmen ve yazarları ata, diğerlerinden sil
                {
                    List<DigerKisi> digerleri = this.film.DigerKisiler;
                    List<DigerKisi> kaldirilacaklar = new List<DigerKisi>();

                    foreach (DigerKisi kisi in digerleri)
                    {
                        if (kisi.departmanVeyaGorev.ToLower(CultureInfo.CurrentCulture).Contains("Directed by".ToLower(CultureInfo.CurrentCulture)))
                        {
                            if (!this.Film.YonetmenlerID.Contains(kisi.kisiID))
                                this.Film.YonetmenlerID.Add(kisi.kisiID);

                            kaldirilacaklar.Add(kisi);
                        }
                        if (kisi.departmanVeyaGorev.ToLower(CultureInfo.CurrentCulture).Contains("Writing credits".ToLower(CultureInfo.CurrentCulture)))
                        {
                            if (!this.Film.YazarlarID.Contains(kisi.kisiID))
                                this.Film.YazarlarID.Add(kisi.kisiID);

                            kaldirilacaklar.Add(kisi);
                        }
                    }

                    foreach (DigerKisi kisi in kaldirilacaklar)
                    {
                        if (digerleri.Contains(kisi))
                            digerleri.Remove(kisi);
                    }

                    this.Film.DigerKisiler = digerleri;
                }

                //oyuncular id yi doldurduk.
                {
                    List<FilmKarakteri> karakterler = this.film.Karakterler;
                    foreach (FilmKarakteri kisi in karakterler)
                    {
                        if ((kisi.oyuncuID != "") && (!this.Film.OyuncularID.Contains(kisi.oyuncuID)))
                        {
                            this.Film.OyuncularID.Add(kisi.oyuncuID);
                        }
                    }
                }
            }
        }
        private void isleDiziBolumleri(string metin)
        {
            if ((metin == null) || (metin == "")) return;

            Regex r = new Regex("<div\\s+class=\"filter-all\\s+filter-year-\\d{4}\">(.*?)</td></tr></table></div>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                DiziBolumu yeni = new DiziBolumu();

                r = new Regex("<a\\s+href=\"/title/(?<id>tt\\d{7})/\">(?<isim>[^<>]*?)</a>", RegexOptions.Singleline);
                Match m2 = r.Match(mm.Value);
                yeni.BolumID = m2.Groups["id"].Value;
                yeni.BolumAdi = m2.Groups["isim"].Value.Trim();

                r = new Regex("Season\\s*(\\d*)[,]?\\s*Episode\\s*(\\d*)[:]?\\s*", RegexOptions.Singleline);
                m2 = r.Match(mm.Value);
                yeni.SezonNumarasi = m2.Groups[1].Value.Trim();
                yeni.BolumNumarasi = m2.Groups[2].Value.Trim();

                r = new Regex("<strong>(.*?)</strong>", RegexOptions.Singleline);
                m2 = r.Match(mm.Value);
                yeni.YayinlanmaTarihi = m2.Groups[1].Value.Trim();

                r = new Regex("<br>(.*?)</td></tr></table></div>", RegexOptions.Singleline);
                m2 = r.Match(mm.Value);
                yeni.BolumOzeti = m2.Groups[1].Value.Trim();

                if (dizi != null)
                    dizi.Bolumler.Add(yeni);
            }
        }
        private void diziNesnesiniDuzenle()
        {
            if (this.dizi != null)
            {
                //filme atanan değerleri dizi nesnemize ata
                if (this.film != null)
                    this.film.kopyalaDiziye(this.dizi);

                List<DigerKisi> kaldirilacaklar = new List<DigerKisi>();

                //yönetmen ve yazarları ata, diğerlerinden sil
                foreach (DigerKisi kisi in this.dizi.DigerKisiler)
                {
                    if (kisi.departmanVeyaGorev.ToLower(CultureInfo.CurrentCulture).Contains("Directed by".ToLower(CultureInfo.CurrentCulture)))
                    {
                        if (!this.dizi.YonetmenlerID.Contains(kisi.kisiID))
                            this.dizi.YonetmenlerID.Add(kisi.kisiID);

                        kaldirilacaklar.Add(kisi);
                    }
                    if (kisi.departmanVeyaGorev.ToLower(CultureInfo.CurrentCulture).Contains("Writing credits".ToLower(CultureInfo.CurrentCulture)))
                    {
                        if (!this.dizi.YazarlarID.Contains(kisi.kisiID))
                            this.dizi.YazarlarID.Add(kisi.kisiID);

                        kaldirilacaklar.Add(kisi);
                    }
                }

                foreach (DigerKisi silinecek in kaldirilacaklar)
                {
                    if (this.dizi.DigerKisiler.Contains(silinecek))
                        this.dizi.DigerKisiler.Remove(silinecek);
                }

                //oyuncular id yi doldurduk.
                foreach (FilmKarakteri kisi in this.dizi.Karakterler)
                {
                    if ((kisi.oyuncuID != "") && (!this.dizi.OyuncularID.Contains(kisi.oyuncuID)))
                    {
                        this.dizi.OyuncularID.Add(kisi.oyuncuID);
                    }
                }
            }
        }

        public List<string> kisaBilgileriIndir(string baslik)
        {
            List<string> kisaBilgiler = new List<string>();

            try
            {
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 });
                stringIlerlemeKonumu.DynamicInvoke(new object[] { "İsimler ve çıkış tarihleri alınıyor" });
                string pHome = "";
                int sayfaTuru = FilmDiziGecersiz(baslik, out pHome);
                intIlerlemeYuzdesi.DynamicInvoke(new object[] { 100 });

                kisaBilgiler.Add(prcsHomePageFilmAdi(pHome, sayfaTuru));
                kisaBilgiler.Add(prcHomePageCikisTarihi(pHome));

                if (idStringIlerlemeKonumu != null)
                    idStringIlerlemeKonumu.DynamicInvoke(new object[] { baslik, "Bilgiler Alındı", kisaBilgiler });
            }
            catch (WebException indirmeHatasi) 
            {
                if (indirmeHatasi.Message.Contains("(404) Not Found."))
                {
                    kisaBilgiler.Add("");
                    kisaBilgiler.Add("Başlık Yok");
                    idStringIlerlemeKonumu.DynamicInvoke(new object[] { baslik, "Başlık Yok", kisaBilgiler });
                }

                intIlerlemeYuzdesi.DynamicInvoke(new object[] { -100 }); 
                throw indirmeHatasi; 
            }
            catch (Exception eHomepage) { throw eHomepage; }

            return kisaBilgiler;
        }

        private string sayfayiTemizle(string sayfa)
        {
            sayfa = sayfa.Replace("&#38;", "&").Replace("&#233;", "é").Replace("&#225;", "á").Replace("&#237;", "í").Replace("&nbsp;", "");
            sayfa = sayfa.Replace("&#243;", "ó").Replace("&#250;", "ú").Replace("&#224;", "à").Replace("&#232;", "è");
            sayfa = sayfa.Replace("&#236;", "ì").Replace("&#242;", "ò").Replace("&#249;", "ù").Replace("&#193;", "Á");
            sayfa = sayfa.Replace("&#201;", "É").Replace("&#205;", "Í").Replace("&#211;", "Ó").Replace("&#218;", "Ú");
            sayfa = sayfa.Replace("&#192;", "À").Replace("&#200;", "È").Replace("&#204;", "Ì").Replace("&#210;", "Ò");
            sayfa = sayfa.Replace("&#217;", "Ù").Replace("&#227;", "ã").Replace("&#245;", "õ").Replace("&#241;", "ñ");
            sayfa = sayfa.Replace("&#195;", "Ã").Replace("&#213;", "Õ").Replace("&#209;", "Ñ").Replace("&#226;", "â");
            sayfa = sayfa.Replace("&#234;", "ê").Replace("&#194;", "Â").Replace("&#202;", "Ê").Replace("&#34;", "\"");
            sayfa = sayfa.Replace("&#x27;", "'").Replace("&quot;", "\"").Replace("&#160;", "").Replace("&#x26;", "&").Replace("&ndash;", "-");
            sayfa = sayfa.Replace("&#x22;", "\"");
            return sayfa;
        }
        private string sayfaIndir(string url)
        {
            string sayfa = "";
            try
            {
                HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(url);
                istek.AllowAutoRedirect = true;

                HttpWebResponse cevap = (HttpWebResponse)istek.GetResponse();
                
                StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), System.Text.Encoding.GetEncoding(0));
                sayfa = okuyucu.ReadToEnd();
                okuyucu.Close();
                cevap.Close();
            }
            catch (WebException internetYok)
            {
                throw internetYok;
            }
            catch (Exception hata)
            {
                throw hata;
            }
            sayfa = sayfayiTemizle(sayfa);
            return sayfa;
        }
        
        #region Özellikler

        public Film Film
        {
            get
            {
                return film;
            }
        }
        public Dizi Dizi
        {
            get { return this.dizi; }
        }
        public Kisi Kisi { get { return this.kisi; } }
        public int IndirmeTuru
        {
            get { return this.indirmeTuru; }
        }
        public SortedDictionary<string, string> KisilerIDVeritabani
        {
            get
            {
                return this.idIsimVeritabani;
            }
        }
        public List<Exception> Hatalar
        {
            get
            {
                return this.olusanHatalar;
            }
        }
        public List<IMDBAramaKategorisi> AramaSonuclari
        {
            get
            {
                return this.tumSonuclar;
            }
        }
        #endregion
    }
}
