using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filmograf.Library
{
    [Serializable]
    public class Odul
    {
        public string odulVerenKurum;
        public string yil;
        public string odulAdi;
        public string sonuc;
        public string kategori;
        public string aliciID;

        public Odul()
        {
            this.odulVerenKurum = "";
            this.yil = "";
            this.odulAdi = "";
            this.sonuc = "";
            this.kategori = "";
            this.aliciID = "";
        }

        public Odul(string odulVerenKurum)
        {
            this.odulVerenKurum = odulVerenKurum;
            this.yil = "";
            this.sonuc = "";
            this.odulAdi = "";
            this.kategori = "";
            this.aliciID = "";
        }
    }
}
