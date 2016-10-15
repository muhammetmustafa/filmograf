using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MMC_Filmograf.Library;
using System.Collections.Generic;

namespace MMC_Filmograf
{
    public partial class f_ManuelKisiEkle : Form
    {
        Kisi kisi;
        Kutuphane kutuphane;

        List<IDKazandigiPara> kazandigiParalar;

        int duzenleMod = (int)KisiDuzenlemeModu.KisiEkle;
        string karAdi;
        int unvan=-1;

        public delegate void metinDurtucu(string gelenDurtu, RichTextBox durtulen);
        private event metinDurtucu metinDurtuldu;

        public f_ManuelKisiEkle(int duzenle, Kutuphane kutuphane)
        {
            InitializeComponent();
            this.kisi = new Kisi("") ;
            this.duzenleMod = duzenle;
            this.kutuphane = kutuphane;
            this.kazandigiParalar = new List<IDKazandigiPara>();
            
            this.metinDurtuldu += new metinDurtucu(f_ManuelKisiEkle_metinDurtuldu);
            this.karAdi = "";
            this.llkGercekler.rchtxtDurtucu = this.metinDurtuldu;
            this.llkKisiselSozler.rchtxtDurtucu = this.metinDurtuldu;

            this.rbBurc0.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc1.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc2.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc3.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc4.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc5.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc6.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc7.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc8.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc9.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc10.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
            this.rbBurc11.CheckedChanged += new EventHandler(rbBurc_CheckedChanged);
        }

        private void f_ManuelKisiEkle_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (!this.IsDisposed)
                this.Dispose(true);
        }

        private void ozGecmisYazdir(string ozgecmis)
        {
            string metin = ozgecmis;
            Regex r = new Regex(">((?:tt|nm)\\d{7})<", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (this.kutuphane.IDVeritabani.ContainsKey(mm.Groups[1].Value))
                {
                    string isim = this.kutuphane.IDVeritabani[mm.Groups[1].Value];
                    metin = metin.Replace(mm.Value, isim);
                }
            }

            txtOzGecmis.Text = metin;
        }


        private void rbBurc_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                ((RadioButton)sender).BackColor = System.Drawing.Color.Gainsboro;
                this.gBurclar.Text = "Burcu" +  " > " + Sabitler.burclarTurkce[Convert.ToInt32(Regex.Match(((RadioButton)sender).Name, "(\\d+)", RegexOptions.Singleline).Groups[1].Value)];
            }
            else if (((RadioButton)sender).Checked == false)
            {
                ((RadioButton)sender).BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }
        private void f_ManuelKisiEkle_metinDurtuldu(string gelenDurtu, RichTextBox durtulen)
        {
            string metin = gelenDurtu;
            Regex r = new Regex(">((?:tt|nm)\\d{7})<", RegexOptions.Singleline);
            MatchCollection m = r.Matches(metin);

            foreach (Match mm in m)
            {
                if (this.kutuphane.IDVeritabani.ContainsKey(mm.Groups[1].Value))
                {
                    string isim = this.kutuphane.IDVeritabani[mm.Groups[1].Value];
                    gelenDurtu = gelenDurtu.Replace(mm.Value, isim);
                }
            }

            durtulen.Text = gelenDurtu;
        }
        private void duzenlemeModunuIlklendir()
        {
            this.Text = kisi.Isim + " - " + "Düzenleme Modu";
            this.Tamam.Text = "Güncelle";

            this.pResim.Image = this.kisi.Resim;
            this.txtAd.Text = this.kisi.Isim;
            this.txtImdbID.Text = this.kisi.ImdbID;
            this.txtDogumTarihi.Text = this.kisi.DogumTarihi;
            this.txtDogumYeri.Text = this.kisi.DogumYeri;
            this.txtDogumAdi.Text = this.kisi.DogumAdi;
            this.txtTakmaAdi.Text = this.kisi.TakmaAdi;

            Regex r = new Regex("(\\d+)[.](\\d+)\\s*m\\s*", RegexOptions.Singleline);
            Match m = r.Match(this.kisi.BoyUzunlugu);

            if (m.Success)
            {
                this.tbBoyBelirtici.Value = Convert.ToInt32((m.Groups[1].Value + m.Groups[2].Value)) / 10;
                double yeni = Convert.ToDouble(this.tbBoyBelirtici.Value) / 10.0;
                this.lBoyUzunlugu.Text = yeni.ToString() + " m";
            }

            int indeks = 0;
            foreach (string s in Sabitler.burclarIngilizce)
            {
                if (this.kisi.Burc.ToLower() == s.ToLower())
                {
                    string buttonAdi = "rbBurc" + indeks.ToString();
                    if (this.gBurclar.Controls[buttonAdi] is RadioButton)
                    {
                        (((RadioButton)this.gBurclar.Controls[buttonAdi])).Checked = true;
                        break;
                    }
                }
                indeks++;
            }

            this.kazandigiParalar = kisi.KazandigiParalar;

            this.llkGercekler.GosterilecekListe = this.kisi.HakkindakiGercekler;
            this.llkKisiselSozler.GosterilecekListe = this.kisi.KisiselSozler;

            this.cUnvan.SelectedIndex = this.kisi.Unvan;
            this.cmbCinsiyet.SelectedIndex = this.kisi.Cinsiyet == true ? 0 : 1;

            if (this.kisi.ResmiWebSayfalari.Count > 0)
            {
                foreach (string websayfasi in this.kisi.ResmiWebSayfalari)
                {
                    LinkLabel yeni = new LinkLabel();
                    yeni.Text = websayfasi;
                    yeni.Name = websayfasi;
                    yeni.AutoSize = true;
                    yeni.ContextMenuStrip = this.cmsLinkSaklayici;
                    flpLinkTutucu.Controls.Add(yeni);
                }
            }

            if (this.kisi.KazandigiParalar.Count > 0)
            {
                foreach (IDKazandigiPara ip in this.kisi.KazandigiParalar)
                {
                    string filmAdi = "";
                    if (this.kutuphane.IDVeritabani.ContainsKey(ip.filmID))
                        filmAdi = this.kutuphane.IDVeritabani[ip.filmID];
                    this.dgvKazandigiParalar.Rows.Add(filmAdi, ip.paraMiktari);
                }
            }

            this.ozGecmisYazdir(this.kisi.Biyografi);
        }
        private bool yenileriAta()
        {
            if (this.txtAd.Text == "")
            {
                MessageBox.Show("Kişi eklemeniz icin \"İsim\" kısmını doldurmanız gerekiyor",
                                "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((this.duzenleMod == (int)KisiDuzenlemeModu.OyuncuKarakterEkle) && (this.txtKarakterAdi.Text == ""))
            {
                MessageBox.Show("Oyuncu eklemeniz icin \"Karakter Adı\" kısmını doldurmanız gerekiyor",
                                "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtImdbID.Text == "")
            {
                MessageBox.Show("IMDB ID kısmını boş geçemezsiniz", "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtImdbID.Text.Length != 9)
            {
                MessageBox.Show("IMDB ID kısmını savsaklamayın. 9 karakter olmalı.", "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if ((this.kutuphane.kutuphanedekiKisi(this.txtImdbID.Text) != null)
                && 
                (this.kutuphane.kutuphanedekiKisi(this.txtImdbID.Text) != this.kisi))
            {
                MessageBox.Show("Ekleyeceğiniz IMDB ID ile aynı IMDB ID'ye sahip bir film kütüphanede var!", "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            this.kisi.Resim = this.pResim.Image;
            this.kisi.Unvan = this.cUnvan.SelectedIndex;
            
            if (this.txtDogumAdi.Text != "")
                this.kisi.DogumAdi = this.txtDogumAdi.Text;

            if (this.lBoyUzunlugu.Text != "")
            {
                this.kisi.BoyUzunlugu = this.lBoyUzunlugu.Text;
            }

            foreach (RadioButton items in this.gBurclar.Controls)
            {
                if (items.Checked == true)
                {
                    this.kisi.Burc = Sabitler.burclarIngilizce[Convert.ToInt32(Regex.Match(items.Name, "(\\d+)", RegexOptions.Singleline).Groups[1].Value)];
                    break;
                }
            }

            if (this.txtTakmaAdi.Text != "")
                this.kisi.TakmaAdi = this.txtTakmaAdi.Text;
            
            if (this.txtAd.Text != "")
                this.kisi.Isim = this.txtAd.Text;

            if ((this.duzenleMod == (int)KisiDuzenlemeModu.OyuncuKarakterEkle) && (this.karAdi != null))
                this.karAdi = this.txtKarakterAdi.Text;

            if (this.txtImdbID.Text != "")
                this.kisi.ImdbID = this.txtImdbID.Text;

            if (this.txtDogumTarihi.Text != "")
                this.kisi.DogumTarihi = this.txtDogumTarihi.Text;

            if (this.txtDogumYeri.Text != "")
                this.kisi.DogumYeri = this.txtDogumYeri.Text;

            if (flpLinkTutucu.Controls.Count > 0)
            {
                kisi.ResmiWebSayfalari.Clear();
                foreach (LinkLabel webSayfasi in flpLinkTutucu.Controls)
                {
                    kisi.ResmiWebSayfalari.Add(webSayfasi.Text);
                }
            }

            this.kisi.KazandigiParalar = this.kazandigiParalar;

            if (this.txtOzGecmis.Text != "")
                this.kisi.Biyografi = this.txtOzGecmis.Text;

            if (this.cmbCinsiyet.SelectedIndex != -1)
                this.kisi.Cinsiyet = (this.cmbCinsiyet.Text == "Erkek" ? true : false);

            kisi.HakkindakiGercekler = this.llkGercekler.GosterilecekListe;
            kisi.KisiselSozler = this.llkKisiselSozler.GosterilecekListe;

            if (kisi != null)
            {
                if (this.kutuphane.kutuphanedekiKisi(this.kisi.ImdbID)!=null)
                {
                    //Eğer dizi kütüphanedeyse kütüphanedeki diziyle değiştir.
                    this.kutuphane.Kisiler[this.kutuphane.kutuphanedekiKisiIndeksi(kisi.ImdbID)] = kisi;
                }
                else
                {
                    //Eğer dizi kütüphanede yoksa kütüphaneye yeni dizi ekle.
                    this.kutuphane.kisiEkle(kisi);
                }
            }

            return true;
        }
        private void Tamam_Click(object sender, EventArgs e)
        {
            if (yenileriAta() == true)
            {
                this.Close();
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
        private void iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pResim_DoubleClick(object sender, System.EventArgs e)
        {
            openFileDialog1.Title = "Kişi resmini seçiniz";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Jpeg dosyalari (*.jpg)|*.jpg|Bmp dosyalari (*.bmp)|*.bmp";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
            {
                return;
            }
            else
            {
                this.pResim.ImageLocation = openFileDialog1.FileName;
            }
        }
        private void karakterModu(bool durum)
        {
            this.lKarakterAdi.Enabled = this.lKarakterAdi.Visible = durum;
            this.txtKarakterAdi.Enabled = this.txtKarakterAdi.Visible = durum;
        }
        private void f_ManuelKisiEkle_Load(object sender, EventArgs e)
        {
            if (this.duzenleMod == (int)KisiDuzenlemeModu.KisiDuzenle)
            {
                duzenlemeModunuIlklendir();
                karakterModu(false);
            }
            else if (this.duzenleMod == (int)KisiDuzenlemeModu.KisiEkle)
            {
                if (unvan == -1)
                    this.cUnvan.SelectedIndex = 0;
                else
                    this.cUnvan.SelectedIndex = unvan;

                this.cmbCinsiyet.SelectedIndex = 0;

                karakterModu(false);
            }
            else if (this.duzenleMod == (int)KisiDuzenlemeModu.OyuncuKarakterEkle)
            {
                this.cUnvan.SelectedIndex = Unvan;
                this.cmbCinsiyet.SelectedIndex = 0;
                karakterModu(true);
            }
            this.txtAd.Focus();
        }

        #region Özellikler
        public Kisi Kisi
        {
            get
            {
                return kisi;
            }
            set
            {
                kisi = value;
            }
        }
        public string KarakterAdi
        {
            get
            {
                return karAdi;
            }
        }
        public int Unvan
        {
            get
            {
                return unvan;
            }
            set
            {
                unvan = value;
            }
        } 
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            f_BaslikArayicisi yeniBaslik = new f_BaslikArayicisi(this.kutuphane);
            DialogResult d = yeniBaslik.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                f_KelimeEkle yeniKelime = new f_KelimeEkle("Para Miktarını Giriniz");
                DialogResult d2 = yeniKelime.ShowDialog();

                if (d2 == System.Windows.Forms.DialogResult.OK)
                {
                    IDKazandigiPara yeni = new IDKazandigiPara();
                    yeni.filmID = yeniBaslik.SecilenID;
                    yeni.paraMiktari = yeniKelime.Kelime;
                    this.kazandigiParalar.Add(yeni);
                    if (this.kutuphane.IDVeritabani.ContainsKey(yeni.filmID))
                        this.dgvKazandigiParalar.Rows.Add(this.kutuphane.IDVeritabani[yeni.filmID], yeni.paraMiktari);
                    else
                        this.dgvKazandigiParalar.Rows.Add(yeni.filmID, yeni.paraMiktari);
                }
            }
        }

        private void tbBoyBelirtici_Scroll(object sender, EventArgs e)
        {
            double yeni = Convert.ToDouble(this.tbBoyBelirtici.Value) / 10.0;
            this.lBoyUzunlugu.Text = yeni.ToString() + " m";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_MetinGirisi metinduzenle = new f_MetinGirisi();
            metinduzenle.Metin = this.txtOzGecmis.Text;
            DialogResult d = metinduzenle.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                this.txtOzGecmis.Text = metinduzenle.Metin;
            }
        }

        #region Resmi Web Sayfası Ekleme
        private void yeniResmiWebSayfasiEkle_Click_1(object sender, EventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(txtResmiWebSayfasi.Text, "^http://.*[.].*$"))
                &&
               (!kisi.ResmiWebSayfalari.Contains(txtResmiWebSayfasi.Text)))
            {
                LinkLabel yeni = new LinkLabel();
                yeni.Text = txtResmiWebSayfasi.Text;
                yeni.Name = txtResmiWebSayfasi.Text;
                yeni.AutoSize = true;
                yeni.ContextMenuStrip = this.cmsLinkSaklayici;
                flpLinkTutucu.Controls.Add(yeni);
                txtResmiWebSayfasi.Text = "";
                txtResmiWebSayfasi.Focus();
            }
        }

        private void cmsLinkSaklayici_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!(cmsLinkSaklayici.SourceControl is LinkLabel)) { e.Cancel = true; }

            cmsLinkSaklayici.Enabled = !(cmsLinkSaklayici.SourceControl == null);
            if (cmsLinkSaklayici.Enabled)
            {
                if (cmsLinkSaklayici.SourceControl is LinkLabel)
                    tstxtLinkDuzenle.Text = ((LinkLabel)cmsLinkSaklayici.SourceControl).Text;
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

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmsLinkSaklayici.SourceControl != null)
            {
                flpLinkTutucu.Controls.Remove(cmsLinkSaklayici.SourceControl);
            }
        } 
        #endregion

        private void btnGercekEkle_Click(object sender, EventArgs e)
        {
            f_MetinGirisi yenimetin = new f_MetinGirisi();
            DialogResult d = yenimetin.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (yenimetin.Metin != "")
                {
                    this.llkGercekler.yeniGirisEkle(yenimetin.Metin);
                }
            }
        }

        private void btnKisiselSozEkle_Click(object sender, EventArgs e)
        {
            f_MetinGirisi yenimetin = new f_MetinGirisi();
            DialogResult d = yenimetin.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (yenimetin.Metin != "")
                {
                    this.llkKisiselSozler.yeniGirisEkle(yenimetin.Metin);
                }
            }
        }

        private void btnHakkindakiGercegiSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Gerçeği silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkGercekler.gosterileniSil();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKisiselSozuSil_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Kişisel sözü silmek istediğine emin misin?", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                llkKisiselSozler.gosterileniSil(); 
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOzgecmisEkle_Click(object sender, EventArgs e)
        {

        }

    }
}
