using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Filmograf.Library
{
    [Serializable]
    public class DiziBolumu
    {
        private string bolumID;
        private string bolumAdi;
        private string yayinlanmaTarihi;
        private string sezonNumarasi;
        private string bolumNumarasi;
        private string bolumOzeti;

        public DiziBolumu(string ID)
        {
            this.bolumID = ID;
            this.bolumAdi = "";
            this.yayinlanmaTarihi = "";
            this.sezonNumarasi = "";
            this.bolumNumarasi = "";
            this.bolumOzeti = "";
        }

        public DiziBolumu()
        {
            this.bolumID = "";
            this.bolumAdi = "";
            this.yayinlanmaTarihi = "";
            this.sezonNumarasi = "";
            this.bolumNumarasi = "";
            this.bolumOzeti = "";
        }

        #region Özellikler

        public string BolumID
        {
            get { return this.bolumID; }
            set { this.bolumID = value; }
        }

        public string BolumAdi
        {
            get { return this.bolumAdi; }
            set { this.bolumAdi = value; }
        }

        public string YayinlanmaTarihi
        {
            get { return this.yayinlanmaTarihi; }
            set { this.yayinlanmaTarihi = value; }
        }

        public string SezonNumarasi
        {
            get { return this.sezonNumarasi; }
            set { this.sezonNumarasi = value; }
        }

        public string BolumNumarasi
        {
            get { return this.bolumNumarasi; }
            set { this.bolumNumarasi = value; }
        }

        public string BolumOzeti
        {
            get { return this.bolumOzeti; }
            set { this.bolumOzeti = value; }
        }
        
        #endregion
    }
}
