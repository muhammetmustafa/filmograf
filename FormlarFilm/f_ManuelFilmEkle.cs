using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Filmograf.Library;
using System.Text.RegularExpressions;

namespace Filmograf
{
    public partial class f_ManuelFilmEkle : Form
    {
        #region Değişkenler, Delegeler, Olaylar
        Kutuphane kutuphane;
        Film yeniFilm;
        Dizi yeniDizi;

        List<string> yonetmenlerID;
        List<string> yazarlarID;
        List<string> oyuncularID;
        List<DigerKisi> digerleriID;

        List<CekimHatasi> cekimHatalari;
        List<Replik> filmReplikleri;
        List<BaglantiKategorisi> filmReferanslari;
        List<FilmMuzigi> filmMuzikleri;

        bool duzenleMod = false;
        public Image.GetThumbnailImageAbort resimCeviriciHataToplayici = new Image.GetThumbnailImageAbort(bosis);
        public delegate void rchtxtDurtuAlici(string gelenDurtu, RichTextBox kimiDurtdun);
        private event rchtxtDurtuAlici rchtxtDurtuldum;
        private event rchtxtDurtuAlici rchtxtReplikDurtuldu; 
        #endregion
        
        private static bool bosis()
        {
            return true;
        }
        
        public f_ManuelFilmEkle(bool duzenle, Kutuphane kutuphane)
        {
            InitializeComponent();

            this.duzenleMod = duzenle;
            this.kutuphane = kutuphane;

            this.yonetmenlerID = new List<string>();
            this.yazarlarID = new List<string>();
            this.oyuncularID = new List<string>();
            this.digerleriID = new List<DigerKisi>();
            
            this.cekimHatalari = new List<CekimHatasi>();
            this.filmReplikleri = new List<Replik>();
            this.filmReferanslari = new List<BaglantiKategorisi>();
            this.filmMuzikleri = new List<FilmMuzigi>();

            this.rchtxtDurtuldum += new rchtxtDurtuAlici(f_ManuelFilmEkle_rchtxtDurtuldum);
            this.rchtxtReplikDurtuldu += new rchtxtDurtuAlici(f_ManuelFilmEkle_rchtxtReplikDurtuldu);

            this.llkCekimGercegiGezinti.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkCekimGercegiGezinti.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkHatalarGezgini.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkMuzikGezici.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkOlayOrgusu.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkReferansGezici.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkReklamsalSoz.rchtxtDurtucu = this.rchtxtDurtuldum;
            this.llkRepliklerGezgini.rchtxtDurtucu = this.rchtxtReplikDurtuldu;

            this.FormClosed += new FormClosedEventHandler(f_ManuelFilmEkle_FormClosed);
        }

        private void f_ManuelFilmEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.IsDisposed)
                this.Dispose(true);
        }
        private void f_ManuelFilmEkle_rchtxtReplikDurtuldu(string gelenDurtu, RichTextBox kimiDurtdun)
        {
            string metin = gelenDurtu;
            Regex r = new Regex(">((?:tt|nm)\\d{7})<", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (this.kutuphane.IDVeritabani.ContainsKey(mm.Groups[1].Value))
                {
                    if (yeniFilm != null)
                    {
                        string karakteradi = "";
                        karakteradi = this.kutuphane.karakterAdi(yeniFilm.ImdbID, mm.Groups[1].Value);
                        gelenDurtu = gelenDurtu.Replace(mm.Value, karakteradi);
                    }
                    else
                    {
                        string kisiAdi = "";
                        kisiAdi = this.kutuphane.IDVeritabani[mm.Groups[1].Value];
                        gelenDurtu = gelenDurtu.Replace(mm.Value, kisiAdi);
                    }
                }
            }
            kimiDurtdun.Text = gelenDurtu;
        }
        private void f_ManuelFilmEkle_rchtxtDurtuldum(string gelenDurtu, RichTextBox kimiDurtdun)
        {
            string metin = gelenDurtu;
            Regex r = new Regex(">((?:tt|nm)\\d{7})<", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (this.kutuphane.IDVeritabani.ContainsKey(mm.Groups[1].Value))
                {
                    string isim = this.kutuphane.IDVeritabani[mm.Groups[1].Value];
                    metin = gelenDurtu.Replace(mm.Value, isim);
                }
            }
            kimiDurtdun.Text = metin;
        }

        private void filmDuzenlemeModunuIlklendir()
        {
            
            this.yonetmenlerID = yeniFilm.YonetmenlerID;
            this.yazarlarID = yeniFilm.YazarlarID;
            this.oyuncularID = yeniFilm.OyuncularID;
            this.digerleriID = yeniFilm.DigerKisiler;

            if (yeniFilm.Ad == "")
            {
                this.Text = "Düzenleme Modu" + "(İsim Belirlenmemiş)";
            }
            else
            {
                this.Text = yeniFilm.Ad + " - " + "Düzenleme Modu";
            }

            this.pFilmAfisi.Image = this.yeniFilm.Afis != null ? this.yeniFilm.Afis : (Image)global::Filmograf.Properties.Resources.Movies;
            
            this.txtFilmAdi.Text = this.yeniFilm.Ad;
            this.txtImdbID.Text = this.yeniFilm.ImdbID;
            this.txtFilmSuresi.Text = this.yeniFilm.Sure;
            this.txtButce.Text = this.yeniFilm.Butce;
            this.txtImdbPuani.Text = this.yeniFilm.ImdbPuani;
            this.txtCikisTarihi.Text = this.yeniFilm.CikisTarihi;

            this.llkReklamsalSoz.GosterilecekListe = this.yeniFilm.Sloganlar;
            this.llkOlayOrgusu.GosterilecekListe  = this.yeniFilm.Ozetler;
            this.llkGaripGercek.GosterilecekListe =  this.yeniFilm.AbartiGercekler;
            this.llkCekimGercegiGezinti.GosterilecekListe =  this.yeniFilm.Gercekler;
            this.llkHatalarGezgini.GosterilecekListe = this.yeniFilm.hatalarString();
            this.llkRepliklerGezgini.GosterilecekListe = this.yeniFilm.repliklerString();
            this.llkReferansGezici.GosterilecekListe = this.yeniFilm.referanslarString();
            this.llkMuzikGezici.GosterilecekListe = this.yeniFilm.muziklerString();

            if (this.yeniFilm.Turler.Count > 0)
            {
                int indeks = 0;
                foreach (string tur in this.yeniFilm.Turler)
                {
                    indeks = StaticFonksiyonlar.tur(tur);
                    if (indeks != -1)
                        this.chlTurListesi.SetItemCheckState(indeks, CheckState.Checked);
                }
            }

            if (this.yeniFilm.YonetmenlerID.Count > 0) //Eğer filme atanmış yönetmen varsa
            {
                List<Kisi> filmKisileri = this.kutuphane.filmdekiKisiler(this.yeniFilm, (int)KisiUnvani.Yonetmen);
                if (filmKisileri.Count == 0) //Eğer filme atanmış yönetmenlerin kütüphanede nesneleri yoksa !!! BURDA EKLENENLERİN KÜTÜPHANEDE NESNELERİ YOKK!!!
                {
                    foreach (string kisi in this.yeniFilm.YonetmenlerID)
                    {
                        if (!this.kutuphane.IDVeritabani.ContainsKey(kisi)) continue;

                        kisiResimleri.Images.Add(kisi, (Image)global::Filmograf.Properties.Resources.Kisi);
                        lvYonetmenler.Items.Add(kisi, this.kutuphane.IDVeritabani[kisi].Trim(), kisi);
                    }
                }
                else
                {
                    foreach (Kisi kisi in filmKisileri)
                    {
                        if (kisi == null) continue;
                        kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
                        lvYonetmenler.Items.Add(kisi.ImdbID, kisi.Isim.Trim(), kisi.ImdbID);
                    }
                }
            }

            if (this.yeniFilm.YazarlarID.Count > 0) //eğer filme atanmış yazar varsa
            {
                List<Kisi> filmKisileri = this.kutuphane.filmdekiKisiler(this.yeniFilm, (int)KisiUnvani.Yazar);
                if (filmKisileri.Count == 0) //Eğer filme atanmış yönetmenlerin kütüphanede nesneleri yoksa !!! BURDA EKLENENLERİN KÜTÜPHANEDE NESNELERİ YOKK!!!
                {
                    foreach (string kisi in this.yeniFilm.YazarlarID)
                    {
                        if (!this.kutuphane.IDVeritabani.ContainsKey(kisi)) continue;

                        kisiResimleri.Images.Add(kisi, (Image)global::Filmograf.Properties.Resources.Kisi);
                        lvYazarlar.Items.Add(kisi, this.kutuphane.IDVeritabani[kisi].Trim(), kisi);
                    }
                }
                else
                {
                    foreach (Kisi kisi in filmKisileri)
                    {
                        if (kisi == null) continue;
                        kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
                        lvYazarlar.Items.Add(kisi.ImdbID, kisi.Isim.Trim(), kisi.ImdbID);
                    }
                }
            }

            if ((this.yeniDizi == null) && (this.yeniFilm.Karakterler.Count > 0))
            {
                foreach (FilmKarakteri karakter in this.yeniFilm.Karakterler)
                {
                    Kisi kisi = this.kutuphane.kutuphanedekiKisi(karakter.oyuncuID);

                    if (kisi != null)
                    {
                        Image kucukKisiResmi = kisi.Resim.GetThumbnailImage(23, 32, resimCeviriciHataToplayici, System.IntPtr.Zero);
                        oyuncuKadrosu.Rows.Add(kucukKisiResmi, kisi.Isim, karakter.karakterAdlariBirlesik(" / ").Trim(), kisi.ImdbID);
                    }
                    else
                    {
                        string oyuncuIsim = "";
                        string karakterIsmi = "";
                        if ((this.kutuphane.IDVeritabani.ContainsKey(karakter.oyuncuID)))
                        {
                            oyuncuIsim = this.kutuphane.IDVeritabani[karakter.oyuncuID].Trim();
                            karakterIsmi = karakter.karakterAdlariBirlesik(" / ");

                            if (karakter.aciklama != "")
                            {
                                if (karakter.aciklama.Contains("@"))
                                {
                                    string[] aciklamalar = karakter.aciklama.Split('@');

                                    foreach (string ss in aciklamalar.ToArray())
                                        karakterIsmi += " " + ss;
                                }
                                else
                                {
                                    karakterIsmi += " " + karakter.aciklama;
                                }
                            }
                        }

                        if ((oyuncuIsim == "") && (karakterIsmi == ""))
                        {
                            continue;
                        }
                        
                        Image resim = (Image)global::Filmograf.Properties.Resources.Kisi;
                        resim = resim.GetThumbnailImage(23, 32, resimCeviriciHataToplayici, System.IntPtr.Zero);

                        oyuncuKadrosu.Rows.Add(resim, oyuncuIsim.Trim(), karakterIsmi.Trim(), karakter.oyuncuID);
                    }
                }

            }

            if (this.yeniFilm.Odulleri.Count > 0)
            {
                string a = "";
                string b = "";
                string c = "";

                foreach (Odul o in this.yeniFilm.Odulleri)
                {
                    a = o.odulVerenKurum.Trim() + " (" + o.yil + ")";
                    b = (o.sonuc.Trim() == "" ? "SONUCYOK" : o.sonuc.Trim());
                    c = (o.kategori.Trim() == "" ? "KATEGORIYOK" : o.kategori.Trim());

                    if (tvOduller.Nodes[a] == null)
                    {
                        tvOduller.Nodes.Add(a, a);
                    }
                    if (tvOduller.Nodes[a].Nodes[b] == null)
                    {
                        tvOduller.Nodes[a].Nodes.Add(b, b);
                    }
                    if (tvOduller.Nodes[a].Nodes[b].Nodes[c] == null)
                    {
                        if (c != "")
                            tvOduller.Nodes[a].Nodes[b].Nodes.Add(c, c);
                        else
                            tvOduller.Nodes[a].Nodes[b].Nodes.Add("BOS", " ");
                    }
                    if (this.kutuphane.IDVeritabani.ContainsKey(o.aliciID))
                    {
                        string alici = "";
                        alici = this.kutuphane.IDVeritabani[o.aliciID];
                        tvOduller.Nodes[a].Nodes[b].Nodes[c].Nodes.Add(o.aliciID, alici.Trim());
                    }
                }
            }


            if ((yeniDizi == null) & (this.digerleriID.Count > 0))
            {
                List<string> departmanlar = yeniFilm.digerKisilerinDepartmanlari();

                foreach (string departman in departmanlar)
                    tvOyuncuKadrosu.Nodes.Add(departman, departman);

                foreach (DigerKisi dkisi in this.digerleriID)
                {
                    Kisi kisi = this.kutuphane.kutuphanedekiKisi(dkisi.kisiID);

                    if (kisi != null)
                    {
                        kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
                        tvOyuncuKadrosu.Nodes[dkisi.departmanVeyaGorev].Nodes.Add(kisi.ImdbID, kisi.Isim.Trim(), kisi.ImdbID);
                    }
                    else
                    {
                        Image resim = (Image)global::Filmograf.Properties.Resources.Kisi;
                        string kisiIsim = "";

                        if (this.kutuphane.IDVeritabani.ContainsKey(dkisi.kisiID))
                        {
                            kisiIsim = this.kutuphane.IDVeritabani[dkisi.kisiID].Trim();
                        }
                        if (kisiIsim == "") continue;

                        kisiResimleri.Images.Add(dkisi.kisiID, resim);
                        tvOyuncuKadrosu.Nodes[dkisi.departmanVeyaGorev].Nodes.Add(dkisi.kisiID, kisiIsim.Trim() + (dkisi.gorevAciklamasi != "" ? "  ... " + dkisi.gorevAciklamasi.Trim() : ""), dkisi.kisiID);
                    }
                }
            }

            if (this.yeniFilm.Sirketler.Count > 0)
            {
                foreach (string s in this.yeniFilm.sirketTurleriHepsi())
                {
                    if (!tvSirketler.Nodes.ContainsKey(s))
                        tvSirketler.Nodes.Add(s, s);
                }

                foreach (Sirket s in this.yeniFilm.Sirketler)
                {
                    foreach (string ss in s.companyTypes)
                    {
                        if (tvSirketler.Nodes[ss] != null)
                        {
                            tvSirketler.Nodes[ss].Nodes.Add(s.companyID, s.companyName);
                        }
                    }
                }
            }

            if (this.yeniFilm.AnahtarKelimeler.Count > 0)
            {
                lbAnahtarKelimeler.Items.Clear();
                lbAnahtarKelimeler.Items.AddRange(this.yeniFilm.AnahtarKelimeler.ToArray());
            }

            if (this.yeniFilm.WebSayfalari.Count > 0)
            {
                foreach (string websayfasi in this.yeniFilm.WebSayfalari)
                {
                    LinkLabel yeni = new LinkLabel();
                    yeni.Text = websayfasi;
                    yeni.Name = websayfasi;
                    yeni.AutoSize = true;
                    yeni.ContextMenuStrip = this.cmsLinkSaklayici;
                    flpLinkTutucu.Controls.Add(yeni);
                }
            }

            if (this.yeniFilm.CekimYerleri.Count > 0)
            {
                lbFilmCekimYerleri.Items.Clear();
                lbFilmCekimYerleri.Items.AddRange(this.yeniFilm.CekimYerleri.ToArray());
            }

            if (this.yeniFilm.DigerAdlariSadeceMetin.Count > 0)
            {
                dgvIsimUlke.Rows.Clear();

                foreach (IsimUlkeler isimulke in this.yeniFilm.DigerAdlariUlkelereGore)
                {
                    foreach (string ulke in isimulke.ulkeler)
                        dgvIsimUlke.Rows.Add(isimulke.isim.Trim(), ulke);
                }
                
            }

            if (this.yeniFilm.Ulkeler.Count > 0)
            {
                fwpUlkeler.Controls.Clear();

                foreach (string ulke in this.yeniFilm.Ulkeler)
                {
                    Label yeniUlke = new Label();
                    yeniUlke.BackColor = Color.Gainsboro;
                    yeniUlke.DoubleClick += new EventHandler(Label_DoubleClick);
                    yeniUlke.AutoSize = true;
                    yeniUlke.Text = ulke;
                    yeniUlke.Name = ulke;
                    fwpUlkeler.Controls.Add(yeniUlke);
                }
            }

            if (this.yeniFilm.Diller.Count > 0)
            {
                fwpDiller.Controls.Clear();

                foreach (string ulke in this.yeniFilm.Diller)
                {
                    Label yeniDil = new Label();
                    yeniDil.AutoSize = true;
                    yeniDil.BackColor = Color.Gainsboro;
                    yeniDil.Text = ulke;
                    yeniDil.Name = ulke;
                    yeniDil.DoubleClick += new EventHandler(Label_DoubleClick);
                    fwpDiller.Controls.Add(yeniDil);
                }
            }
        }

        private void Label_DoubleClick(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label label = ((Label)sender);

                if (label.BackColor == Color.Gainsboro)
                    label.BackColor = Color.RosyBrown;
                else
                    label.BackColor = Color.Gainsboro;
            }
        }

        private void diziDuzenlemeModunuIlklendir()
        {
            if ((this.yeniDizi != null) && (this.yeniDizi.Karakterler.Count > 0))
            {
                this.txtOynadigiTarihler.Text = yeniDizi.OynadigiYillar;
                this.lOynadigiTarihler.Visible = true;
                this.txtOynadigiTarihler.Visible = true;

                foreach (string s in this.yeniDizi.sezonlarString())
                {
                    lvSezonlar.Items.Add(s, s, s);
                }

                this.tBolumler.Show();
                foreach (FilmKarakteri karakter in this.yeniFilm.Karakterler)
                {
                    Kisi kisi = this.kutuphane.kutuphanedekiKisi(karakter.oyuncuID);

                    if (kisi != null)
                    {
                        Image kucukKisiResmi = kisi.Resim.GetThumbnailImage(22, 22, resimCeviriciHataToplayici, System.IntPtr.Zero);
                        string ikinciSutun = "";
                        ikinciSutun = karakter.karakterAdlariBirlesik(" / ").Trim() + 
                                            " ( " + this.yeniDizi.oyuncuRolSayisi(karakter.oyuncuID) + " bölüm " + 
                                            this.yeniDizi.oyuncuRolYillari(karakter.oyuncuID) + " )";

                        oyuncuKadrosu.Rows.Add(kucukKisiResmi, kisi.Isim, ikinciSutun, kisi.ImdbID);
                    }
                    else
                    {
                        string oyuncuIsim = "";
                        string karakterIsmi = "";
                        if ((this.kutuphane.IDVeritabani.ContainsKey(karakter.oyuncuID)))
                        {
                            oyuncuIsim = this.kutuphane.IDVeritabani[karakter.oyuncuID].Trim();
                            karakterIsmi = karakter.karakterAdlariBirlesik(" / ");

                            if (karakter.aciklama != "")
                            {
                                if (karakter.aciklama.Contains("@"))
                                {
                                    string[] aciklamalar = karakter.aciklama.Split('@');

                                    foreach (string ss in aciklamalar.ToArray())
                                        karakterIsmi += " " + ss;
                                }
                                else
                                {
                                    karakterIsmi += " " + karakter.aciklama;
                                }
                            }
                        }

                        if ((oyuncuIsim == "") && (karakterIsmi == ""))
                        {
                            continue;
                        }
                        string ikinciSutun = "";
                        ikinciSutun = karakterIsmi +
                                            " ( " + this.yeniDizi.oyuncuRolSayisi(karakter.oyuncuID) + " bölüm, " +
                                            this.yeniDizi.oyuncuRolYillari(karakter.oyuncuID) + " )";

                        Image resim = (Image)global::Filmograf.Properties.Resources.Kisi;
                        resim = resim.GetThumbnailImage(22, 22, resimCeviriciHataToplayici, System.IntPtr.Zero);

                        oyuncuKadrosu.Rows.Add(resim, oyuncuIsim.Trim(), ikinciSutun, karakter.oyuncuID);
                    }
                }

            }

            if ((yeniDizi != null) & (this.digerleriID.Count > 0))
            {
                List<string> departmanlar = yeniFilm.digerKisilerinDepartmanlari();

                foreach (string departman in departmanlar)
                    tvOyuncuKadrosu.Nodes.Add(departman, departman);

                foreach (DigerKisi dkisi in this.digerleriID)
                {
                    Kisi kisi = this.kutuphane.kutuphanedekiKisi(dkisi.kisiID);

                    if (kisi != null)
                    {
                        string kisiIsmiTam = "";
                        kisiIsmiTam = kisi.Isim.Trim() + (dkisi.gorevAciklamasi != "" ? "  ... " + dkisi.gorevAciklamasi.Trim() : "");
                        kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
                        tvOyuncuKadrosu.Nodes[dkisi.departmanVeyaGorev].Nodes.Add(kisi.ImdbID, kisiIsmiTam, kisi.ImdbID);
                    }
                    else
                    {
                        Image resim = (Image)global::Filmograf.Properties.Resources.Kisi;
                        string kisiIsim = "";

                        if (this.kutuphane.IDVeritabani.ContainsKey(dkisi.kisiID))
                        {
                            kisiIsim = this.kutuphane.IDVeritabani[dkisi.kisiID].Trim();
                        }
                        if (kisiIsim == "") continue;

                        kisiIsim = kisiIsim.Trim() + (dkisi.gorevAciklamasi != "" ? "  ... " + dkisi.gorevAciklamasi.Trim() : "") +
                             " ( " + this.yeniDizi.digerKisiRolSayisi(dkisi.kisiID) + " bölüm, " +
                                            this.yeniDizi.digerKisiRolYillari(dkisi.kisiID) + " )";
                        
                        kisiResimleri.Images.Add(dkisi.kisiID, resim);
                        tvOyuncuKadrosu.Nodes[dkisi.departmanVeyaGorev].Nodes.Add(dkisi.kisiID, kisiIsim, dkisi.kisiID);
                    }
                }
            }
        }
        private bool degisiklikleriKaydet()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtImdbID.Text, "tt\\d{7}"))
            {
                MessageBox.Show("IMDB ID kısmını yanlış girilmiş. Örnekteki gibi girilmeli", "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filmAyarlari.SelectTab("tGenelBilgiler");
                txtImdbID.Focus();
                txtImdbID.SelectAll();
                return false;
            }

            if ((this.kutuphane.kutuphanedekiFilm(this.txtImdbID.Text) != null)
                &&
                (this.kutuphane.kutuphanedekiFilm(this.txtImdbID.Text) != this.yeniFilm))
            {
                MessageBox.Show("Ekleyeceğiniz IMDB ID ile aynı IMDB ID'ye sahip bir film kütüphanede var!", "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImdbID.Focus();
                return false;
            }

            if (txtFilmAdi.Text == "")
            {
                MessageBox.Show("Film adını boş geçemezsiniz", "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filmAyarlari.SelectTab("tGenelBilgiler");
                txtFilmAdi.Focus();
                return false;
            }

            this.yeniFilm.Afis = this.pFilmAfisi.Image;
            this.yeniFilm.Ad = this.txtFilmAdi.Text;
            this.yeniFilm.CikisTarihi = this.txtCikisTarihi.Text;
            this.yeniFilm.Sure = this.txtFilmSuresi.Text;
            this.yeniFilm.ImdbPuani = this.txtImdbPuani.Text;
            this.yeniFilm.ImdbID = this.txtImdbID.Text;
            this.yeniFilm.YonetmenlerID = this.yonetmenlerID;
            this.yeniFilm.YazarlarID = this.yazarlarID;
            this.yeniFilm.OyuncularID = this.oyuncularID;
            this.yeniFilm.DigerKisiler = this.digerleriID;
            this.yeniFilm.Butce = this.txtButce.Text;

            yeniFilm.Ozetler = this.llkOlayOrgusu.GosterilecekListe; //gösterilecekliste de yeni eklenmiş elemanlar da var.
            yeniFilm.Sloganlar = this.llkReklamsalSoz.GosterilecekListe; //gösterilecekliste de yeni eklenmiş elemanlar da var.
            yeniFilm.AbartiGercekler = this.llkGaripGercek.GosterilecekListe; //gösterilecekliste de yeni eklenmiş elemanlar da var.
            yeniFilm.Gercekler = this.llkCekimGercegiGezinti.GosterilecekListe;



            //
            // Film türü
            //
            for (int i = 0; i < chlTurListesi.CheckedIndices.Count; i++)
            {
                yeniFilm.Turler.Add(StaticFonksiyonlar.tur(chlTurListesi.CheckedIndices[i]));
            }

            //
            // Anahtar Kelimeler
            //
            List<string> anhtrKelimeler = new List<string>();
            for (int i = 0; i < lbAnahtarKelimeler.Items.Count; i++)
            {
                anhtrKelimeler.Add(Convert.ToString(lbAnahtarKelimeler.Items[i]));
            }
            yeniFilm.AnahtarKelimeler = anhtrKelimeler;

            //
            // Resmi Web Sayfalari
            //
            if (flpLinkTutucu.Controls.Count > 0)
            {
                yeniFilm.WebSayfalari.Clear();
                foreach (LinkLabel webSayfasi in flpLinkTutucu.Controls)
                {
                    yeniFilm.WebSayfalari.Add(webSayfasi.Text);
                }
            }

            //
            // Film  Çekim Yerleri
            //
            if (lbFilmCekimYerleri.Items.Count > 0)
            {
                yeniFilm.CekimYerleri.Clear();
                foreach (string filmCekimYeri in lbFilmCekimYerleri.Items)
                {
                    yeniFilm.CekimYerleri.Add(filmCekimYeri);
                }
            }

            //
            // Baska Isimler
            //
            if (dgvIsimUlke.Rows.Count > 0)
            {
                yeniFilm.DigerAdlariUlkelereGore.Clear();
                dgvIsimUlke.Sort(dgvIsimUlke.Columns[0], ListSortDirection.Ascending);

                for (int i = 0; i < dgvIsimUlke.Rows.Count; i++)
                {
                    try
                    {
                        if ((dgvIsimUlke.Rows[i].Cells[0].Value.ToString() == "") || (dgvIsimUlke.Rows[i].Cells[1].Value.ToString() == "")) continue;
                    }
                    catch (NullReferenceException)
                    {
                        continue;
                    }

                    int konum = 0;
                    foreach (IsimUlkeler isimulke in yeniFilm.DigerAdlariUlkelereGore)
                    {
                        if (dgvIsimUlke.Rows[i].Cells[0].Value.ToString() == isimulke.isim)
                        {
                            break;
                        }
                        konum++;
                    }

                    if (konum == yeniFilm.DigerAdlariUlkelereGore.Count)
                    {
                        List<string> ulke = new List<string>();
                        ulke.Add(dgvIsimUlke.Rows[i].Cells[1].Value.ToString());
                        yeniFilm.DigerAdlariUlkelereGore.Add(new IsimUlkeler(dgvIsimUlke.Rows[i].Cells[0].Value.ToString(), ulke));
                    }
                    else
                    {
                        yeniFilm.DigerAdlariUlkelereGore[konum].ulkeler.Add(dgvIsimUlke.Rows[i].Cells[1].Value.ToString());
                    }
                    
                }
            }

            //
            // Ulke
            //
            if (fwpUlkeler.Controls.Count > 0)
            {
                yeniFilm.Ulkeler.Clear();

                for (int i = 0; i < fwpUlkeler.Controls.Count; i++)
                {
                    if (fwpUlkeler.Controls[i] is Label)
                    {
                        yeniFilm.Ulkeler.Add(((Label)fwpUlkeler.Controls[i]).Text);
                    }
                }
            }

            //
            // Dil
            //
            if (fwpDiller.Controls.Count > 0)
            {
                yeniFilm.Diller.Clear();

                for (int i = 0; i < fwpDiller.Controls.Count; i++)
                {
                    if (fwpDiller.Controls[i] is Label)
                    {
                        yeniFilm.Diller.Add(((Label)fwpDiller.Controls[i]).Text);
                    }
                }
            }

            if ((yeniDizi != null) && (yeniFilm != null))
            {
                //Dizi ekleme/düzenleme modundayiz.
                yeniFilm.kopyalaDiziye(yeniDizi);
                if (this.kutuphane.diziKutuphanedemi(this.yeniDizi.ImdbID))
                {
                    //Eğer dizi kütüphanedeyse kütüphanedeki diziyle değiştir.
                    this.kutuphane.Diziler[this.kutuphane.kutuphanedekiDiziIndeksi(yeniDizi.ImdbID)] = yeniDizi;
                }
                else
                {
                    //Eğer dizi kütüphanede yoksa kütüphaneye yeni dizi ekle.
                    this.kutuphane.diziEkle(yeniDizi, true);
                }
            }
            else if ((yeniFilm != null) && (yeniDizi == null))
            {
                //film ekleme/düzenleme modundayiz
                if (this.kutuphane.filmKutuphanedemi(this.yeniFilm.ImdbID))
                {
                    //Eğer film kütüphanedeyse kütüphanedeki filmle değiştir.
                    this.kutuphane.Filmler[this.kutuphane.kutuphanedekiFilmIndeksi(yeniFilm.ImdbID)] = yeniFilm;
                }
                else
                {
                    //Eğer film kütüphanede değilse kütüphaneye ekle
                    this.kutuphane.filmEkle(yeniFilm, true);
                }
            }

            return true;
        }

        public int imdbIDdenIndeksBul(string imdbID)
        {
            foreach (DataGridViewRow d in this.oyuncuKadrosu.Rows)
            {
                foreach (DataGridViewCell c in d.Cells)
                {
                    if (c.Value.ToString() == imdbID)
                    {
                        return d.Index;
                    }
                }
            }
            return -1;
        }
        private void f_ManuelFilmEkle_Load(object sender, EventArgs e)
        {
            this.txtFilmAdi.Focus();

            if (duzenleMod == true)
            {
                btnEkle.Text = "Güncelle";
                if ((yeniFilm == null) && (yeniDizi != null))
                {
                    yeniFilm = new Library.Film();
                    yeniDizi.kopyalaFilme(yeniFilm);
                    yeniDizi.ImdbID = yeniFilm.ImdbID;
                    filmDuzenlemeModunuIlklendir();
                    diziDuzenlemeModunuIlklendir();
                }
                else
                {
                    this.tBolumler.Hide();
                    filmDuzenlemeModunuIlklendir();
                }
            }
        }
        private void iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Tamam_Click(object sender, EventArgs e)
        {
            if (degisiklikleriKaydet() == true)
            {
                this.Close();
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.None;

        }

        #region Başlangıç Tabı
        private void pictureBox1_DoubleClick(object sender, System.EventArgs e)
        {
            openFileDialog1.Title = "Film afisini seciniz";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Jpeg dosyalari (*.jpg)|*.jpg|Bmp dosyalari (*.bmp)|*.bmp";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {
                return;
            }
            else
            {
                pFilmAfisi.ImageLocation = openFileDialog1.FileName;
            }
        }


        #endregion  

        #region Kadro Tabı
        private void kütüphanedenEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control tus = kisiEklemeMenusu.SourceControl;

            //unvan değişkeni eklenecek kişinin hangi kısma gideceğini belirlemek amaçlıdır.
            int unvan = tus == btnSeceneklerYonK ? (int)KisiUnvani.Yonetmen: 
                    ( tus == btnSeceneklerYazK ? (int)KisiUnvani.Yazar : 
                    ( tus == btnSeceneklerOyunK ? (int)KisiUnvani.Oyuncu : (int)KisiUnvani.Diger));

            f_KisiListesi eklenecekKisi = new f_KisiListesi(this.kutuphane);
            eklenecekKisi.Unvan = unvan;
            DialogResult d = eklenecekKisi.ShowDialog();
            Kisi kisi = eklenecekKisi.Kisi;

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (kisi == null) return;

                if (unvan == (int)KisiUnvani.Yonetmen)
                {
                    if (!this.yeniFilm.YonetmenlerID.Contains(kisi.ImdbID))
                    {
                        kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
                        lvYonetmenler.Items.Add(kisi.ImdbID, kisi.Isim, kisi.ImdbID);
                        this.kutuphane.kisiEkle(kisi); //Kütüphaneye eklemek için. Eğer eklenecek kisi varsa eklenmez
                        this.yeniFilm.YonetmenlerID.Add(kisi.ImdbID);//Manuel eklediğimiz filmin yönetmen listesi için.
                    }
                    else
                        return;
                }
                if (unvan == (int)KisiUnvani.Yazar)
                {
                    if (!this.yeniFilm.YazarlarID.Contains(kisi.ImdbID))
                    {
                        kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
                        lvYazarlar.Items.Add(kisi.ImdbID, kisi.Isim, kisi.ImdbID);
                        this.kutuphane.kisiEkle(kisi); //Kütüphaneye eklemek için. Eğer eklenecek kisi varsa eklenmez
                        this.yeniFilm.YazarlarID.Add(kisi.ImdbID);//Manuel eklediğimiz filmin yönetmen listesi için.
                    }
                    else
                        return;
                }
                if (unvan == (int)KisiUnvani.Oyuncu)
                {
                    f_KelimeEkle karakterAdi = new f_KelimeEkle("\"" + kisi.Isim + "\"" + " oyuncusu için karakter adı");
                    karakterAdi.ShowDialog();

                    if (karakterAdi.Girilen == "")
                    {
                        return;
                    }

                    this.kutuphane.kisiEkle(kisi); //Kütüphaneye eklemek için
                    this.yeniFilm.OyuncularID.Add(kisi.ImdbID);

                    oyuncuKadrosu.Rows.Add(kisi.Resim.GetThumbnailImage(22, 22, resimCeviriciHataToplayici, System.IntPtr.Zero), kisi.Isim, karakterAdi.Girilen, kisi.ImdbID);

                    FilmKarakteri yeni = new FilmKarakteri();
                    yeni.karakterler.Add(new isimID("", karakterAdi.Girilen));
                    yeni.oyuncuID = kisi.ImdbID;
                    this.yeniFilm.Karakterler.Add(yeni);
                }
            }
        }
        private void yeniYonetmenEkle_Click(object sender, EventArgs e)
        {
            if (this.kutuphane == null)
            {
                MessageBox.Show("Kişi eklemek için kütüphane oluşturmalısınız", "MMC Filmograf",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //manüel kişi ekleyicimize yeni bir kişi ekleyeceğimiz ve kişinin yönetmen olacağını söylüyoruz.
            f_ManuelKisiEkle kisiekle = new f_ManuelKisiEkle((int)KisiDuzenlemeModu.KisiEkle, this.kutuphane);
            kisiekle.Unvan = (int)KisiUnvani.Yonetmen;

            DialogResult d = kisiekle.ShowDialog();

            //manüel kişi ekleyicimizden gelen kişiyi yeni bir kişiye atayalım.
            Kisi kisi = kisiekle.Kisi;
            if (kisi == null) return;

            if (this.yonetmenlerID.Contains(kisi.ImdbID)) return; //ekleyeceğimiz yönetmen filmimize daha önce eklenmişse işlemi sonlandır.

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                kisi.Unvan = (int)KisiUnvani.Yonetmen;
                kutuphane.kisiEkle(kisi); //Kütüphaneye eklemek için
                this.yonetmenlerID.Add(kisi.ImdbID); //Manuel eklediğimiz filme eklemek için
            }
            else if (d == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
            lvYonetmenler.Items.Add(kisi.ImdbID, kisi.Isim, kisi.ImdbID);

        }
        private void yazarEkle_Click(object sender, EventArgs e)
        {
            if (this.kutuphane == null)
            {
                MessageBox.Show("Kişi eklemek için kütüphane oluşturmalısınız", "MMC Filmograf",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            f_ManuelKisiEkle kisiekle = new f_ManuelKisiEkle((int)KisiDuzenlemeModu.KisiEkle, this.kutuphane);
            kisiekle.Unvan = (int)KisiUnvani.Yazar;
            DialogResult d = kisiekle.ShowDialog();

            Kisi kisi = kisiekle.Kisi;
            if (kisi == null) return;

            if (this.yazarlarID.Contains(kisi.ImdbID)) return;

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                kisi.Unvan = (int)KisiUnvani.Yazar;
                kutuphane.kisiEkle(kisi); //Kütüphaneye eklemek için
                this.yazarlarID.Add(kisi.ImdbID); //Manuel eklediğimiz filme eklemek için
            }
            else if (d == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            kisiResimleri.Images.Add(kisi.ImdbID, kisi.Resim);
            lvYazarlar.Items.Add(kisi.ImdbID, kisi.Isim, kisi.ImdbID);
        }
        private void oyuncuEkle_Click(object sender, EventArgs e)
        {
            if (this.kutuphane == null)
            {
                MessageBox.Show("Kişi eklemek için kütüphane oluşturmalısınız", "MMC Filmograf",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            f_ManuelKisiEkle kisiekle = new f_ManuelKisiEkle((int)KisiDuzenlemeModu.OyuncuKarakterEkle, this.kutuphane);
            kisiekle.Unvan = (int)KisiUnvani.Oyuncu;
            DialogResult d = kisiekle.ShowDialog();

            Kisi kisi = kisiekle.Kisi;
            if (kisi == null) return;

            string karakterAdi = kisiekle.KarakterAdi;
            if ((karakterAdi == "") || (karakterAdi == null)) return;

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                kisi.Unvan = (int)KisiUnvani.Oyuncu;

                kutuphane.kisiEkle(kisi); //Kütüphaneye eklemek için
                this.oyuncularID.Add(kisi.ImdbID); //Manuel eklediğimiz filme eklemek için

                oyuncuKadrosu.Rows.Add(kisi.Resim.GetThumbnailImage(22, 22, resimCeviriciHataToplayici, System.IntPtr.Zero), kisi.Isim, karakterAdi, kisi.ImdbID);

                FilmKarakteri yeni = new FilmKarakteri();
                yeni.karakterler.Add(new isimID("", karakterAdi));
                yeni.oyuncuID = kisi.ImdbID;
                this.yeniFilm.Karakterler.Add(yeni);
            }
            else if (d == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
        }
        private void yK_dahaFazlaTusu_Click(object sender, EventArgs e)
        {
            kisiEklemeMenusu.Show(btnSeceneklerYonK, 10, 10);
        }
        private void yzrK_dahaFazlaTusu_Click(object sender, EventArgs e)
        {
            kisiEklemeMenusu.Show(btnSeceneklerYazK, 10, 10);
        }
        private void oK_dahaFazlaTusu_Click(object sender, EventArgs e)
        {
            kisiEklemeMenusu.Show(btnSeceneklerOyunK, 10, 10);
        }
        private void yonetmeniSil_Click(object sender, EventArgs e)
        {
            if (lvYonetmenler.SelectedItems.Count == 0) return;
            
            DialogResult d = MessageBox.Show("Seçtiğiniz yönetmenler listeden kaldırılsın mı?", 
                                            "MMC Filmograf", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (d == System.Windows.Forms.DialogResult.No) return;
            
            List<string> imdbIDler = new List<string>();
            foreach (ListViewItem eleman in this.lvYonetmenler.SelectedItems)
                imdbIDler.Add(eleman.ImageKey);

            foreach (string imdbID in imdbIDler)
            {
                this.yeniFilm.YonetmenlerID.Remove(imdbID); 
                this.kisiResimleri.Images.RemoveByKey(imdbID);
                this.lvYonetmenler.Items.RemoveByKey(imdbID);
            }
        }
        private void yazariSil_Click(object sender, EventArgs e)
        {
            if (lvYazarlar.SelectedItems.Count == 0) return;

             DialogResult d = MessageBox.Show("Seçtiğiniz yazarlar listeden kaldırılsın mı?", 
                                                "MMC Filmograf", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (d == System.Windows.Forms.DialogResult.No) return;
            
            List<string> imdbIDler = new List<string>();
            foreach (ListViewItem eleman in this.lvYazarlar.SelectedItems)
                imdbIDler.Add(eleman.ImageKey);
    
            foreach (string imdbID in imdbIDler.ToArray())
            {
                this.yeniFilm.YazarlarID.Remove(imdbID); 
                this.kisiResimleri.Images.RemoveByKey(imdbID);
                this.lvYonetmenler.Items.RemoveByKey(imdbID);
            }
        }
        private void oyuncuyuSil_Click(object sender, EventArgs e)
        {
            if (oyuncuKadrosu.SelectedRows.Count == 0) return;

            DialogResult d = MessageBox.Show("Seçtiğiniz oyuncular listeden kaldırılsın mı?",
                        "MMC Filmograf", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (d == System.Windows.Forms.DialogResult.No) return;

            List<string> imdbIDler = new List<string>();
            foreach (DataGridViewRow eleman in this.oyuncuKadrosu.SelectedRows)
                imdbIDler.Add(eleman.Cells[3].Value.ToString());
            
            foreach (string imdbID in imdbIDler.ToArray())
            {
                this.yeniFilm.OyuncularID.Remove(imdbID); //düzenlediğimiz filmin yonetmen imdb id listesinden kaldır
                this.kisiResimleri.Images.RemoveByKey(imdbID);
                int indeks = imdbIDdenIndeksBul(imdbID);

                if (indeks >= 0) this.oyuncuKadrosu.Rows.RemoveAt(indeks);

                FilmKarakteri ka = this.yeniFilm.imdbIDden_KarakterAdi(imdbID);
                if (ka != null) this.yeniFilm.Karakterler.Remove(ka);
            }
        }
        #endregion

        #region Ödüller Tabı
        private void tvOyuncuKadrosu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.IsSelected)
            {
                Kisi kisi = this.kutuphane.kutuphanedekiKisi(e.Node.SelectedImageKey);

                if (kisi != null)
                {
                    //Kişi varsa
                    lGosterID.Text = kisi.ImdbID.Trim();
                    lGosterIsim.Text = kisi.Isim.Trim();
                    lGosterKutuphaneDurumu.Text = "Kütüphaneye Kayıtlı";
                    if (e.Node.Parent != null)
                    {
                        lGosterDepartmanGorev.Text = e.Node.Parent.Text.Trim();
                    }
                    else
                        lGosterDepartmanGorev.Text = "";

                    if (e.Node.Text.Contains("..."))
                    {
                        lGosterGorevAciklama.Text = e.Node.Text.Replace("...", "@").Split('@')[1].Trim();
                    }
                    else
                        lGosterGorevAciklama.Text = "";
                }
                else
                {
                    //Kişi yoksa
                    lGosterID.Text = e.Node.ImageKey.Trim();
                    if (this.kutuphane.IDVeritabani.ContainsKey(e.Node.ImageKey))
                    {
                        string isim = this.kutuphane.IDVeritabani[e.Node.ImageKey];
                        lGosterIsim.Text = isim.Trim();
                    }
                    lGosterKutuphaneDurumu.Text = "Kütüphaneye Kayıtlı Değil";
                    if (e.Node.Parent != null)
                    {
                        lGosterDepartmanGorev.Text = e.Node.Parent.Text.Trim();
                    }
                    else
                        lGosterDepartmanGorev.Text = "";

                    if (e.Node.Text.Contains("..."))
                    {
                        lGosterGorevAciklama.Text = e.Node.Text.Replace("...", "@").Split('@')[1].Trim();
                    }
                    else
                        lGosterGorevAciklama.Text = "";
                }
            }
        }
        private void tvOduller_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.IsSelected)
            {
                if (!Regex.IsMatch(e.Node.Name, "nm\\d{7}"))
                {
                    this.lGosterAlanKisi.Text = "";
                    this.lGosterOdulVerenKurum.Text = "";
                    this.lGosterYil.Text = "";
                    this.lGosterKategori.Text = "";
                    this.lGosterSonuc.Text = "";
                    return;
                }

                if (this.kutuphane.IDVeritabani.ContainsKey(e.Node.Name))
                    this.lGosterAlanKisi.Text = this.kutuphane.IDVeritabani[e.Node.Name];

                if (e.Node.Parent != null)
                {
                    if (e.Node.Parent.Parent != null)
                    {
                        if (e.Node.Parent.Parent.Parent != null)
                        {
                            string text = e.Node.Parent.Parent.Parent.Text;
                            this.lGosterOdulVerenKurum.Text = text.Substring(0, text.Length - 7);
                            this.lGosterYil.Text = text.Substring(text.Length - 7, 7);
                        }
                    }
                }

                if (e.Node.Parent != null)
                {
                    if (e.Node.Parent.Parent != null)
                    {
                        this.lGosterSonuc.Text = e.Node.Parent.Parent.Text;
                    }
                }

                if (e.Node.Parent != null)
                {
                    this.lGosterKategori.Text = e.Node.Parent.Text;
                }
            }
        }
        #endregion  

        #region Detaylar Tabı

        private void resmiWebSayfalariEkle_Click(object sender, EventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(txtWebSayfasi.Text, "^http://.*[.].*$"))
                &&
               (!yeniFilm.WebSayfalari.Contains(txtWebSayfasi.Text)))
            {
                LinkLabel yeni = new LinkLabel();
                yeni.Text = txtWebSayfasi.Text;
                yeni.Name = txtWebSayfasi.Text;
                yeni.AutoSize = true;
                yeni.ContextMenuStrip = this.cmsLinkSaklayici;
                flpLinkTutucu.Controls.Add(yeni);
                txtWebSayfasi.Text = "";
                txtWebSayfasi.Focus();
            }
        }
        private void cmsLinkSaklayici_Opening(object sender, CancelEventArgs e)
        {
            if (!(cmsLinkSaklayici.SourceControl is LinkLabel)) {e.Cancel = true; }

            cmsLinkSaklayici.Enabled = !(cmsLinkSaklayici.SourceControl == null);
            if (cmsLinkSaklayici.Enabled)
            {
                if (cmsLinkSaklayici.SourceControl is LinkLabel)
                tstxtLinkDuzenle.Text = ((LinkLabel)cmsLinkSaklayici.SourceControl).Text;
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsLinkSaklayici.SourceControl != null)
            {
                flpLinkTutucu.Controls.Remove(cmsLinkSaklayici.SourceControl);
            }
        }
        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tstxtLinkDuzenle.Text, "^http://.*[.].*$"))
            {
                ((ContextMenuStrip)kaydetToolStripMenuItem.Owner).SourceControl.Text = tstxtLinkDuzenle.Text;
                ((ContextMenuStrip)kaydetToolStripMenuItem.Owner).SourceControl.Name = tstxtLinkDuzenle.Text;
            }
        }

        #endregion

        #region Diğer Bilgiler Tabı
        private void anahtarKelimeEkle_Click(object sender, EventArgs e)
        {
            f_KelimeEkle yeni = new f_KelimeEkle();
            yeni.ShowDialog();
            if (yeni.Kelime != "")
            {
                lbAnahtarKelimeler.Items.Add(yeni.Kelime);
            }
        }
        private void anahtarKelimeSil_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbAnahtarKelimeler.SelectedItems.Count; i++)
            {
                lbAnahtarKelimeler.Items.RemoveAt(lbAnahtarKelimeler.SelectedIndices[i]);
            }
        }
        private void tumAnahtarKelimeleriSil_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Anahtar kelimelerin eklenecegi dosyayi secin";
            openFileDialog1.Filter = "Metin dosyalari (*.txt)|*.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                FileStream dosyaSistem = null;
                try
                {
                    dosyaSistem = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader akisOkuyucu = new StreamReader(dosyaSistem, Encoding.GetEncoding(0));

                    ArrayList kelimeler = new ArrayList();
                    while (!akisOkuyucu.EndOfStream)
                    {
                        kelimeler.Add(akisOkuyucu.ReadLine().ToString());
                    }

                    foreach (string kelime in kelimeler.ToArray())
                    {
                        if ((kelime != "") && (!kelime.Contains(' ')))
                        {
                            lbAnahtarKelimeler.Items.Add(kelime);
                        }
                    }

                    dosyaSistem.Close();
                    akisOkuyucu.Close();
                }
                catch (Exception hata)
                {
                    if (dosyaSistem != null) dosyaSistem.Close(); 
                    MessageBox.Show("Hata olustu: " + hata.Message);
                }
            }

        }
        private void tumunuSil_Click(object sender, EventArgs e)
        {
            lbAnahtarKelimeler.Items.Clear();
        }
        private void filmCekimYerleriEkle_Click(object sender, EventArgs e)
        {
            if ((txtFilmCekimYeri.Text != "")
                &&
                (!lbFilmCekimYerleri.Items.Contains(txtFilmCekimYeri.Text)))
            {
                lbFilmCekimYerleri.Items.Add(txtFilmCekimYeri.Text);
                txtFilmCekimYeri.Text = "";
                txtFilmCekimYeri.Focus();
            }
        }

        #endregion

        #region Dizi Düzenleme
        private void lvSezonlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yeniDizi == null) return;

            if (lvSezonlar.SelectedItems.Count == 1)
            {
                lvBolumler.Items.Clear();
                foreach (string s in this.yeniDizi.bolumlerString(lvSezonlar.SelectedItems[0].ImageKey))
                {
                    lvBolumler.Items.Add(s, s, s);
                }
            }
        }
        private void lvBolumler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yeniDizi == null) return;

            if (lvBolumler.SelectedItems.Count == 1)
            {
                DiziBolumu d = this.yeniDizi.bolum(this.lvSezonlar.SelectedItems[0].ImageKey, this.lvBolumler.SelectedItems[0].ImageKey);
                if (d != null)
                {
                    this.txtBolumAdi.Text = d.BolumAdi;
                    this.txtBolumCikisTarihi.Text = d.YayinlanmaTarihi;
                    this.txtBolumID.Text = d.BolumID;
                    this.rchtxtBolumOzeti.Text = d.BolumOzeti;
                }
            }
        }
        #endregion

        #region Eğlence Tabı Silme Tuşları
        private void btnMuzikSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Müziği silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkMuzikGezici.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReferansSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Referansı silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkReferansGezici.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReplikSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Repliği silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkRepliklerGezgini.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHataSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Hatayı silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkHatalarGezgini.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCekimGercegiSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Çekim gerçeğini silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkCekimGercegiGezinti.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGaripGercekSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Garip gerçeği silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkGaripGercek.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSloganSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Sloganı silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkReklamsalSoz.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnHakkindakiGercegiSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Olay örgüsünü silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkOlayOrgusu.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region  Eğlence Tabı Ekleme Tuşları
        private void btnHataEkle_Click(object sender, EventArgs e)
        {
            f_KategoriMetin yeniCekimHatasi = new f_KategoriMetin(true);
            DialogResult d = yeniCekimHatasi.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (yeniCekimHatasi.GirilenCekimHatasi != null)
                {
                    this.cekimHatalari.Add(yeniCekimHatasi.GirilenCekimHatasi);
                    this.llkHatalarGezgini.yeniGirisEkle(yeniCekimHatasi.GirilenCekimHatasi.ToString());
                }
            }
        }
        private void btnReplikEkle_Click(object sender, EventArgs e)
        {
            f_Replik yenireplik = new f_Replik(this.kutuphane);
            DialogResult d = yenireplik.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (yenireplik.Replik != null)
                {
                    this.filmReplikleri.Add(yenireplik.Replik);
                    this.llkRepliklerGezgini.yeniGirisEkle(yenireplik.Replik.ToString());
                }
            }
        }
        private void btnMuzikEkle_Click(object sender, EventArgs e)
        {
            f_KategoriMetin yeniMuzik = new f_KategoriMetin(false, true);
            DialogResult sonuc = yeniMuzik.ShowDialog();

            if (sonuc == System.Windows.Forms.DialogResult.OK)
            {
                if (yeniMuzik.GirilenFilmMuzigi != null)
                {
                    this.filmMuzikleri.Add(yeniMuzik.GirilenFilmMuzigi);
                    this.llkMuzikGezici.GosterilecekListe.Add(yeniMuzik.GirilenFilmMuzigi.ToString());
                }
            }
        }
        private void btnReferansEkle_Click(object sender, EventArgs e)
        {
            f_Referans yeniRef = new f_Referans(this.kutuphane);
            DialogResult d = yeniRef.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (yeniRef.EklenenBaglanti != null)
                {
                    this.llkReferansGezici.yeniGirisEkle(yeniRef.EklenenBaglanti.ToString());
                    this.filmReferanslari.Add(yeniRef.EklenenBaglanti);
                }
            }
        }
        private void btnCekimGercegiEkle_Click(object sender, EventArgs e)
        {
            f_MetinGirisi yeniMetin = new f_MetinGirisi();

            if (yeniMetin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((yeniMetin.Metin != "") && (!this.llkCekimGercegiGezinti.GosterilecekListe.Contains(yeniMetin.Metin)))
                {
                    this.llkCekimGercegiGezinti.GosterilecekListe.Add(yeniMetin.Metin);
                    llkCekimGercegiGezinti.sonEkleneniGoster();
                }
            }
        }
        private void btnOlayOrgusuEkle_Click(object sender, EventArgs e)
        {
            f_MetinGirisi yeniMetin = new f_MetinGirisi();

            if (yeniMetin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((yeniMetin.Metin != "") && (!this.llkOlayOrgusu.GosterilecekListe.Contains(yeniMetin.Metin)))
                {
                    this.llkOlayOrgusu.GosterilecekListe.Add(yeniMetin.Metin);
                    llkOlayOrgusu.sonEkleneniGoster();
                }
            }
        }
        private void btnCrazyCreditEkle_Click(object sender, EventArgs e)
        {
            f_MetinGirisi yeniMetin = new f_MetinGirisi();

            if (yeniMetin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((yeniMetin.Metin != "") && (!this.llkOlayOrgusu.GosterilecekListe.Contains(yeniMetin.Metin)))
                {
                    this.llkOlayOrgusu.GosterilecekListe.Add(yeniMetin.Metin);
                    llkOlayOrgusu.sonEkleneniGoster();
                }
            }
        }
        private void btnReklamSozuEkle_Click(object sender, EventArgs e)
        {
            f_MetinGirisi yeniMetin = new f_MetinGirisi();

            if (yeniMetin.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((yeniMetin.Metin != "") && (!this.llkReklamsalSoz.GosterilecekListe.Contains(yeniMetin.Metin)))
                {
                    this.llkReklamsalSoz.GosterilecekListe.Add(yeniMetin.Metin);
                    llkReklamsalSoz.sonEkleneniGoster();
                }
            }
        }
        #endregion

        #region Özellikler
        public Film Film
        {
            get
            {
                return yeniFilm;
            }
            set
            {
                yeniFilm = value;
            }
        }
        public Dizi Dizi
        {
            get
            {
                return yeniDizi;
            }
            set
            {
                yeniDizi = value;
            }
        }
        #endregion  

        private void btnUlkeSil_Click(object sender, EventArgs e)
        {
            List<Control> silinecekler = new List<Control>();

            foreach (Control c in this.fwpUlkeler.Controls)
            {
                if (c is Label)
                {
                    Label l = (Label)c;

                    if (l.BackColor == Color.RosyBrown)
                    {
                        silinecekler.Add(c);
                    }
                }
            }

            foreach (Control c in silinecekler)
            {
                if (this.fwpUlkeler.Controls.Contains(c))
                    this.fwpUlkeler.Controls.Remove(c);
            }
        }

        private void btnDilSil_Click(object sender, EventArgs e)
        {
            List<Control> silinecekler = new List<Control>();

            foreach (Control c in this.fwpDiller.Controls)
            {
                if (c is Label)
                {
                    Label l = (Label)c;

                    if (l.BackColor == Color.RosyBrown)
                    {
                        silinecekler.Add(c);
                    }
                }
            }

            foreach (Control c in silinecekler)
            {
                if (this.fwpUlkeler.Controls.Contains(c))
                    this.fwpUlkeler.Controls.Remove(c);
            }
        }


        private void btnUlkeEkle_Click(object sender, EventArgs e)
        {
            if (this.cmbUlke.SelectedItem != null)
            {
                if (!this.fwpUlkeler.Controls.ContainsKey(this.cmbUlke.SelectedItem.ToString()))
                {
                    Label yeniUlke = new Label();
                    yeniUlke.AutoSize = true;
                    yeniUlke.BackColor = Color.Gainsboro;
                    yeniUlke.DoubleClick += new EventHandler(Label_DoubleClick);
                    yeniUlke.Name = this.cmbUlke.SelectedItem.ToString();
                    yeniUlke.Text = this.cmbUlke.SelectedItem.ToString();
                    this.fwpUlkeler.Controls.Add(yeniUlke);
                }
            }
        }

        private void btnDilEkle_Click(object sender, EventArgs e)
        {
            if (this.cmbDil.SelectedItem != null)
            {
                if (!this.fwpDiller.Controls.ContainsKey(this.cmbDil.SelectedItem.ToString()))
                {
                    Label yeniUlke = new Label();
                    yeniUlke.AutoSize = true;
                    yeniUlke.BackColor = Color.Gainsboro;
                    yeniUlke.DoubleClick += new EventHandler(Label_DoubleClick);
                    yeniUlke.Name = this.cmbDil.SelectedItem.ToString();
                    yeniUlke.Text = this.cmbDil.SelectedItem.ToString();
                    this.fwpDiller.Controls.Add(yeniUlke);
                }
            }
        }

    }
}
