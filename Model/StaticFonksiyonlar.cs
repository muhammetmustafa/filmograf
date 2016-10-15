using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Filmograf.Library
{
    class StaticFonksiyonlar
    {
        /// <summary>
        /// Fonksiyon film türleri olan (Action, Comedy, Drama ...)
        /// kelimelerden verilen turun kaçıncı sırada olduğunu, bulamazsa -1 döndürür.
        /// </summary>
        /// <returns></returns>
        public static int tur(string tur)
        {
            int konum = -1;
            try
            {
                List<string> turler = new List<string>();
                turler.AddRange(global::Filmograf.Properties.Resources.FilmTurleri.ToString().Split(','));
                for (int i = 0; i < turler.Count; i++)
                {
                    if (turler[i] == tur)
                        return i;
                }
            }
            catch (Exception)
            {
                return konum;
            }
            return konum;
        }
        public static string tur(int tur)
        {
            string bultur = ""; 
            try
            {
                List<string> turler = new List<string>();
                turler.AddRange(global::Filmograf.Properties.Resources.FilmTurleri.ToString().Split(','));
                return turler[tur];
            }
            catch (Exception)
            {
                return bultur;
            }
        }
        /// <summary>
        /// Turlerin string listesi halini döndürür. Bişey bulamazsa boş bir liste, hata oluşursa null değeri döndürür.
        /// </summary>
        /// <returns></returns>
        public static List<string> turler()
        {
            try
            {
                List<string> turler = new List<string>();
                turler.AddRange(global::Filmograf.Properties.Resources.FilmTurleri.ToString().Split(','));
                return turler;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<string> idIsimCozucu(string deger)
        {
            if (!Regex.IsMatch(deger, ".*?@\\w{2}\\d{7}")) return null;

            Regex r = new Regex("(.*?)@(\\w{2}\\d{7})");
            Match m = r.Match(deger);

            if (m.Success)
            {
                List<string> yeni = new List<string>();
                yeni.Add(m.Groups[1].Value);
                yeni.Add(m.Groups[2].Value);
                return yeni;
            }
            return null;
        }

        /// <summary>
        /// Metindeki linkleri çözüp string listesi halinde döndürür. Bişey bulamazsa boş liste döndürür.
        /// </summary>
        /// <param name="metin"></param>
        /// <returns></returns>
        public static List<string> linkCozucu(string metin)
        {
            List<string> linkler = new List<string>();

            Regex r = new Regex("<a\\s+href=\"(?<link>[^<>]*)\">[^<>]*?</a>", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (mm.Success) linkler.Add(mm.Groups["link"].Value);
            }

            return linkler;
        }
        
        public static string birlestir(List<string> liste, string birlestirici, int maxKel)
        {
            if (liste.Count == 0) return "";
            if (liste.Count == 1) return liste[0];

            string metin = "";

            int maxAnahKel = 1; int ilkdeAtla = 0;
            metin += liste[0];

            foreach (string s in liste.ToArray())
            {
                ilkdeAtla++;
                if (ilkdeAtla == 1) continue;
                metin += birlestirici + s;
                if (maxAnahKel == maxKel) break;
                maxAnahKel++;
            }

            return metin;
        }
    }
}
