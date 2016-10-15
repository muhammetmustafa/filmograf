using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMC_Filmograf
{
    public partial class listeLabelKontrolu : UserControl
    {
        List<string> gosterilenliste;
        RichTextBox metinKontrolu;
        int konum = 0;

        public Delegate rchtxtDurtucu;

        public listeLabelKontrolu()
        {
            InitializeComponent();
            gosterilenliste = new List<string>();
            metinKontrolu = this.richTextBox1;
            this.metinKontrolu.TextChanged += new EventHandler(metinKontrolu_TextChanged);
            Font f = new Font("Microsoft YaHei", 10, FontStyle.Regular);
            this.metinKontrolu.Font = f;
        }

        private void metinKontrolu_TextChanged(object sender, EventArgs e)
        {
            if (rchtxtDurtucu != null)
                rchtxtDurtucu.DynamicInvoke(new object[] { this.metinKontrolu.Text , this.richTextBox1});
        }

        void listeLabelKontrolu_Load(object sender, System.EventArgs e)
        {
            if (metinKontrolu != null)
            {
                if ((gosterilenliste != null) && (gosterilenliste.Count == 0))
                {
                    metinKontrolu.Text = "";
                    lMetinKonumu.Text = "0/0";
                }
                else
                {
                    metinKontrolu.Text = gosterilenliste[konum];
                    lMetinKonumu.Text = (konum + 1).ToString() + "/" + gosterilenliste.Count.ToString();
                }
            }
        }

        public void sonEkleneniGoster()
        {
            if (gosterilenliste == null) throw new ArgumentNullException("Silinecek liste yok");

            if (gosterilenliste.Count == 0)
            {
                metinKontrolu.Text = "";
                lMetinKonumu.Text = "0/0";
            }
            metinKontrolu.Text = gosterilenliste[gosterilenliste.Count - 1];
            lMetinKonumu.Text = (konum + 1).ToString() + "/" + gosterilenliste.Count.ToString();
        }

        public void indeksiniGoster(int indeks)
        {
            if (indeks < 0)
            {
                metinKontrolu.Text = gosterilenliste[this.gosterilenliste.Count-1];
                lMetinKonumu.Text = (this.gosterilenliste.Count - 1).ToString() + "/" + gosterilenliste.Count.ToString();
                return;
            }
            if (indeks >= this.gosterilenliste.Count)
            {
                metinKontrolu.Text = gosterilenliste[indeks];
                lMetinKonumu.Text = "1" + "/" + gosterilenliste.Count.ToString();
                return;
            }

            metinKontrolu.Text = gosterilenliste[indeks];
            lMetinKonumu.Text = (indeks + 1).ToString() + "/" + gosterilenliste.Count.ToString();
        }

        public void yeniGirisEkle(string metin)
        {
            if (metin != "")
            {
                this.gosterilenliste.Add(metin);
                sonEkleneniGoster();
            }
        }

        public void gosterileniSil()
        {
            if (this.gosterilenliste == null) throw new ArgumentNullException("Silinecek liste yok");

            if ((this.gosterilenliste.Count != 0) && (this.gosterilenliste[konum] != null))
            {
                this.gosterilenliste.RemoveAt(konum);
                this.indeksiniGoster(konum);
            }
        }

        private void sonrakiReklamSozu_Click(object sender, EventArgs e)
        {
            if ((gosterilenliste == null) || (gosterilenliste.Count == 0)) return;

            if (konum + 1 >= gosterilenliste.Count)
                konum = 0;
            else
                konum++;
            metinKontrolu.Text = gosterilenliste[konum];
            lMetinKonumu.Text = (konum+1).ToString() + "/" + gosterilenliste.Count.ToString();
        }

        private void oncekiReklamSozu_Click(object sender, EventArgs e)
        {
            if ((gosterilenliste == null) || (gosterilenliste.Count == 0)) return;

            if (konum - 1 == -1)
                konum = gosterilenliste.Count-1;
            else
                konum--;
            metinKontrolu.Text = gosterilenliste[konum];
            lMetinKonumu.Text = (konum + 1).ToString() + "/" + gosterilenliste.Count.ToString();
        }

        public List<string> GosterilecekListe
        {
            get { return gosterilenliste; }
            set { gosterilenliste = value; }
        }

    }
}
