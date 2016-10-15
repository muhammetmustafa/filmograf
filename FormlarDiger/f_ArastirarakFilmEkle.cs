using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MMC_Filmograf.Library;

namespace MMC_Filmograf
{
    public partial class f_ArastirarakEkle : Form
    {
        #region Değişkenler, Olaylar, Delegeler
        Kutuphane kutuphane;
        List<string> basliklar;

        List<string> indirilecekBasliklar;
        List<Exception> indirilirkenOlusanHatalar;
        List<Film> filmler;
        List<Dizi> diziler;
        List<Kisi> kisiler;
        SortedDictionary<string, string> gelenKeyIsimler;

        public delegate void ilerlemeYuzdesi(int deger);
        private event ilerlemeYuzdesi intIlerlemeYuzdesi;

        public delegate void ilerlemeKonumu(string deger);
        private event ilerlemeKonumu konumIlerleyici;

        public delegate void bilgiAlimDurumu(string id, string deger, List<string> bilgiler);
        private event bilgiAlimDurumu bilgiAlici;

        public delegate void progressHandler(int deger);
        public delegate void listviewBilgiHandler(string id, string deger, List<string> bilgiler);
        public delegate void konumBilgiHalledici(string deger);

        public delegate void islemYapilanBaslik(string baslik);
        private event islemYapilanBaslik baslikDegisti;

        int toplamDeger = 0;
        int arastirmaModu = 0;
        int arastirmaMiktari = 0;
        bool secenek = true;
        bool bilgileriAlTusu = false; 
        #endregion

        /// <summary>
        /// Kaynaklardan araştırarak ekler
        /// </summary>
        /// <param name="ArastirmaModu">Ekleyeceğimiz nesnenin kodu. Film için 0, kişi için 1</param>
        public f_ArastirarakEkle(int ArastirmaModu, Kutuphane kutuphane)
        {
            InitializeComponent();
            this.arastirmaModu = ArastirmaModu;
            this.kutuphane = kutuphane;
            this.basliklar = new List<string>();
            intIlerlemeYuzdesi += new ilerlemeYuzdesi(yuzdeIlerleyiciTopluEkleme);
            konumIlerleyici += new ilerlemeKonumu(konumBilgilendirici);
            bilgiAlici += new bilgiAlimDurumu(indirilenBilgiAlici);
            baslikDegisti += new islemYapilanBaslik(f_ArastirarakEkle_baslikDegisti);
            this.lvsonuclar.DoubleClick += new EventHandler(lvsonuclar_DoubleClick);
            this.txtAranacak.KeyUp += new KeyEventHandler(txtAranacak_KeyUp);
            AutoCompleteStringCollection veritabani = new AutoCompleteStringCollection();

            foreach (string s in this.kutuphane.IDVeritabani.Values)
            {
                veritabani.Add(s);
            }

            this.txtAranacak.AutoCompleteCustomSource = veritabani;
        }

        private void lvsonuclar_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                IMDB yeni = new IMDB();

                if (this.lvsonuclar.SelectedItems.Count == 1)
                {
                    f_ResimGosterici resim = new f_ResimGosterici();
                    this.Cursor = Cursors.WaitCursor;
                    System.Drawing.Image inresim = yeni.ResimIndir(this.lvsonuclar.SelectedItems[0].ImageKey);
                    this.Cursor = Cursors.Default;
                    if (inresim != null)
                        resim.Resim = inresim;
                    resim.Show();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtAranacak_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.btnAra_Click(sender, e);
        }

        private void f_ArastirarakEkle_baslikDegisti(string baslik)
        {
            BaslikDegistiYazici(baslik);
        }
        private void BaslikDegistiYazici(string baslik)
        {
            if (this.lvBulunanBasliklar.InvokeRequired)
            {
                islemYapilanBaslik yeni = new islemYapilanBaslik(BaslikDegistiYazici);
                this.Invoke(yeni, new object[] { baslik });
            }
            else
            {
                if (this.lvBulunanBasliklar.Items[baslik] != null)
                {
                    this.lvBulunanBasliklar.Items[baslik].SubItems.AddRange(new string[] { "", "", "Bilgiler alınıyor" });
                }
            }
        }
        
        private void indirilenBilgiAlici(string id, string deger, List<string> bilgiler)
        {
            BilgiIndirmeListeYazicisi(id, deger, bilgiler);
        }
        private void BilgiIndirmeListeYazicisi(string id, string deger, List<string> bilgiler)
        {
            if (this.lvBulunanBasliklar.InvokeRequired)
            {
                listviewBilgiHandler yeni = new listviewBilgiHandler(BilgiIndirmeListeYazicisi);
                this.Invoke(yeni, new object[] { id, deger, bilgiler });
            }
            else
            {
                if ((this.lvBulunanBasliklar.Items[id] != null) && (bilgiler.Count > 0))
                {
                    this.lvBulunanBasliklar.Items[id].SubItems.AddRange(new string[] { bilgiler[0], bilgiler[1], deger });
                }
            }
        }

        private void yuzdeIlerleyiciTopluEkleme(int deger)
        {
            toplamDeger += deger;
            if (toplamDeger < 0) toplamDeger = 0;
            if (toplamDeger > 100) toplamDeger = 0;

            IlerleyiciyiAyarla(toplamDeger);
        }
        private void IlerleyiciyiAyarla(int deger)
        {
            if (this.pbIlerleme.ProgressBar.InvokeRequired)
            {
                progressHandler ph = new progressHandler(IlerleyiciyiAyarla);
                this.Invoke(ph, new object[] { deger });
            }
            else
            {
                this.pbIlerleme.ProgressBar.Value = deger;
            }
        }
        
        private void konumBilgilendirici(string deger)
        {
            konumBilgiYazici(deger);
        }
        private void konumBilgiYazici(string deger)
        {
            if (this.statusStrip1.InvokeRequired)
            {
                konumBilgiHalledici yeni = new konumBilgiHalledici(konumBilgiYazici);
                this.Invoke(yeni, new object[] { deger });
            }
            else
            {
                tsslBilgi.Text = deger;
            }
        }
        
        private void tArastirma_Selected(object sender, TabControlEventArgs e)
        {
            if (!arkaPlanAmelesi.IsBusy)
            {
                if (e.TabPageIndex == 0)
                {
                    tsslEklenenBaslikSayisi.Visible = false;

                    foreach (Control c in this.tArastirma.TabPages[0].Controls)
                        c.Enabled = true;
                    foreach (Control c in this.tArastirma.TabPages[1].Controls)
                        c.Enabled = false;
                }
                if (e.TabPageIndex == 1)
                {
                    tsslEklenenBaslikSayisi.Visible = true;

                    foreach (Control c in this.tArastirma.TabPages[0].Controls)
                        c.Enabled = false;
                    foreach (Control c in this.tArastirma.TabPages[1].Controls)
                        c.Enabled = true;
                }
            }
        }
        private void tuslarAktifPasif(bool durum)
        {
            this.btnAra.Enabled = durum;
            this.btnEkle.Enabled = durum;
            this.btnEkle2.Enabled = durum;
            this.btnGozat.Enabled = durum;
            this.btnIptal.Enabled = durum;
            this.btnIptal2.Enabled = durum;
            this.btnVarOlanlariKaldir.Enabled = durum;
            this.bntBilgileriAl.Enabled = durum;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIptal2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Dosya Seçin";
            openFileDialog1.Filter = "Tüm Dosyalar (*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.Multiselect = false;
            DialogResult d = openFileDialog1.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    this.Cursor = Cursors.WaitCursor;
                    this.lDosya.Text = openFileDialog1.FileName;

                    string dosya = "";

                    if (System.IO.File.Exists(openFileDialog1.FileName))
                        dosya = System.IO.File.ReadAllText(openFileDialog1.FileName);

                    Regex r = new Regex("((?:tt|nm)\\d{7})");
                    MatchCollection m = r.Matches(dosya);

                    if (m.Count == 0) return;

                    foreach (Match mm in m)
                    {
                        if (!basliklar.Contains(mm.Value))
                        basliklar.Add(mm.Value);
                    }
                    basliklar.Sort();

                    foreach (string s in basliklar)
                    {
                        if ((this.kutuphane.filmKutuphanedemi(s))||(this.kutuphane.diziKutuphanedemi(s)))
                        {
                            Film listedekiFilm = this.kutuphane.kutuphanedekiFilm(s);
                            if (listedekiFilm != null)
                            {
                                lvBulunanBasliklar.Items.Add(s, "", s).Checked = false;
                                lvBulunanBasliklar.Items[s].SubItems.AddRange(new string[] { s, listedekiFilm.Ad, listedekiFilm.CikisTarihi, "Film Kütüphanede" });
                            }
                            else
                            {
                                Dizi listedekiDizi = this.kutuphane.kutuphanedekiDizi(s);
                                if (listedekiDizi != null)
                                {
                                    lvBulunanBasliklar.Items.Add(s, "", s).Checked = false;
                                    lvBulunanBasliklar.Items[s].SubItems.AddRange(new string[] { s, listedekiDizi.Ad, listedekiDizi.CikisTarihi, "Dizi Kütüphanede" });
                                }
                            }
                        }
                        else
                        {
                            lvBulunanBasliklar.Items.Add(s, "", s).Checked = false;
                            lvBulunanBasliklar.Items[s].SubItems.AddRange(new string[] { s});
                        }

                    }
                    tsslEklenenBaslikSayisi.Text = basliklar.Count.ToString() + " Başlık";
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu: " + hata.Message, "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void lvBulunanBasliklar_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                foreach (ListViewItem eleman  in lvBulunanBasliklar.Items)
                {
                    eleman.Checked = secenek;
                }
                secenek = !secenek;
            }
        }

        private void bntBilgileriAl_Click(object sender, EventArgs e)
        {
            if (lvBulunanBasliklar.CheckedItems.Count == 0)
            {
                MessageBox.Show("Bilgilerini almak için önce seçmelisiniz", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            indirilecekBasliklar = new List<string>();
            indirilirkenOlusanHatalar = new List<Exception>();

            arastirmaMiktari = lvBulunanBasliklar.CheckedItems.Count;
            pbIlerleme.Value = toplamDeger = 0;

            foreach (ListViewItem secilen in lvBulunanBasliklar.CheckedItems)
            {
                indirilecekBasliklar.Add(secilen.ImageKey);
            }

            tsslIslemiIptalEt.Visible = true;
            tsslIslemiIptalEt.Enabled = true;
            bilgileriAlTusu = true;
            tuslarAktifPasif(false);
            arkaPlanAmelesi.RunWorkerAsync();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            bool ayniFilmVarmi = false;
            
            if (this.lvsonuclar.CheckedItems.Count > 0)
            {
                this.indirilecekBasliklar = new List<string>();
                foreach (ListViewItem key in this.lvsonuclar.CheckedItems)
	            {
                    if (!this.indirilecekBasliklar.Contains(key.ImageKey))
                        this.indirilecekBasliklar.Add(key.ImageKey);
	            }

                foreach (string item in this.indirilecekBasliklar)
                {
                    if (this.kutuphane.kutuphanedekiDizilerinIDleri().Contains(item))
                    {
                        ayniFilmVarmi = true;
                        break;
                    }
                    else if (this.kutuphane.kutuphanedekiKisilerinIDleri(-1).Contains(item))
                    {
                        ayniFilmVarmi = true;
                        break;
                    }
                    else if (this.kutuphane.kutuphanedekiFilmlerinIDleri().Contains(item))
                    {
                        ayniFilmVarmi = true;
                        break;
                    }             
                }
            }
            
            if ((this.indirilecekBasliklar.Count == 0) && (!Regex.IsMatch(this.txtAranacak.Text, "((tt|nm)\\d{7})")))
            {
                MessageBox.Show("Girdiğiniz IMDB ID'nin formatı uygun değil",
                                                        Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtAranacak.Focus();
                return;
            }
            else if (this.indirilecekBasliklar.Count==0)
            {
                string eklenecekID = Regex.Match(this.txtAranacak.Text, "((?:tt|nm)\\d{7})", RegexOptions.Singleline).Groups[1].Value;

                if (this.kutuphane.kutuphanedekiDizilerinIDleri().Contains(eklenecekID))
                {
                    ayniFilmVarmi = true;
                }
                else if (this.kutuphane.kutuphanedekiKisilerinIDleri(-1).Contains(eklenecekID))
                {
                    ayniFilmVarmi = true;
                }
                else if (this.kutuphane.kutuphanedekiFilmlerinIDleri().Contains(eklenecekID))
                {
                    ayniFilmVarmi = true;
                }

                if (eklenecekID != "")
                {
                    if (this.indirilecekBasliklar == null)
                    {
                        this.indirilecekBasliklar = new List<string>();
                    }
                    this.indirilecekBasliklar.Add(eklenecekID);
                }
            }

            if (ayniFilmVarmi)
            {
                DialogResult d = MessageBox.Show("Kütüphanede aynı ID ile bir başlık var. Başlığın bilgilerini güncellemek ister misiniz?",
                                                        Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            arastirmaMiktari = this.indirilecekBasliklar.Count;
            
            indirilirkenOlusanHatalar = new List<Exception>();
            gelenKeyIsimler = new SortedDictionary<string, string>();

            filmler = new List<Film>();
            diziler = new List<Dizi>();
            kisiler = new List<Kisi>();

            tuslarAktifPasif(false);
            tsslIslemiIptalEt.Visible = true;
            tsslIslemiIptalEt.Enabled = true;
            arkaPlanAmelesi.RunWorkerAsync();
        }
        private void btnEkle2_Click(object sender, EventArgs e)
        {
            bool ayniFilmVarmi = false;
            bilgileriAlTusu = false;

            if (lvBulunanBasliklar.CheckedItems.Count == 0)
            {
                MessageBox.Show("Ekleme yapmak için önce seçmelisiniz", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.None; return;
            }

            foreach (ListViewItem secilen in lvBulunanBasliklar.CheckedItems)
            {
                if (this.kutuphane.kutuphanedekiFilmlerinIDleri().Contains(secilen.ImageKey))
                {
                    ayniFilmVarmi = true;
                    break;
                }
                if (this.kutuphane.kutuphanedekiDizilerinIDleri().Contains(secilen.ImageKey))
                {
                    ayniFilmVarmi = true;
                    break;
                }
                if (this.kutuphane.kutuphanedekiKisilerinIDleri(-1).Contains(secilen.ImageKey))
                {
                    ayniFilmVarmi = true;
                    break;
                }
            }

            if (ayniFilmVarmi)
            {
                DialogResult soru = MessageBox.Show("Eklemek için seçtiğiniz bazı başlıklar kütüphaneye eklenmiş durumda." 
                                                        + "Eklemeye devam etmek isterseniz bu başlıkların bilgileri yenileriyle değiştirilecektir ",
                            Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (soru == System.Windows.Forms.DialogResult.No)
                {
                    DialogResult soru2 = MessageBox.Show("Eklenmemiş başlıkların yüklenmesi devam etsin mi?",
                            Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (soru2 == System.Windows.Forms.DialogResult.No)
                    return;
                }
            }

            indirilecekBasliklar = new List<string>();
            indirilirkenOlusanHatalar = new List<Exception>();
            filmler = new List<Film>();
            diziler = new List<Dizi>();
            kisiler = new List<Kisi>();
            gelenKeyIsimler = new SortedDictionary<string, string>();
            
            foreach (ListViewItem secilen in lvBulunanBasliklar.CheckedItems)
            {
                indirilecekBasliklar.Add(secilen.ImageKey);
            }

            tuslarAktifPasif(false);
            tsslIslemiIptalEt.Visible = true;
            tsslIslemiIptalEt.Enabled = true;
            arkaPlanAmelesi.RunWorkerAsync();
        }
        private void siraliIndirme()
        {
            IMDB yeni = new IMDB();
            yeni.intIlerlemeYuzdesi = this.intIlerlemeYuzdesi;
            yeni.stringIlerlemeKonumu = this.konumIlerleyici;
            yeni.islemYapilanBaslikID = this.baslikDegisti;

            foreach (string baslik in indirilecekBasliklar)
            {
                if (arkaPlanAmelesi.CancellationPending)
                    break;

                try
                {
                    yeni.indir(baslik);
                }
                catch (System.Net.WebException hata)
                {
                    MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                catch (SayfaYokHatasi hata)
                {
                    indirilirkenOlusanHatalar.Add(hata);
                    continue;
                }
                catch (Exception)
                {
                    indirilirkenOlusanHatalar.AddRange(yeni.Hatalar);
                    continue;
                }

                if (yeni.IndirmeTuru == 1)
                    filmler.Add(yeni.Film);
                else if (yeni.IndirmeTuru == 2)
                    diziler.Add(yeni.Dizi);
                else if (yeni.IndirmeTuru == 3)
                    kisiler.Add(yeni.Kisi);

                SortedDictionary<string, string>.Enumerator a = yeni.KisilerIDVeritabani.GetEnumerator();
                a.MoveNext();

                do
                {
                    if (!gelenKeyIsimler.ContainsKey(a.Current.Key))
                        gelenKeyIsimler.Add(a.Current.Key, a.Current.Value);
                }
                while (a.MoveNext());
            }

        }
        private void filmEklemeTumIlerleme()
        {

            this.kutuphane.Guncelle(gelenKeyIsimler);

            if (filmler.Count > 0)
            {
                foreach (Film film in filmler)
                {
                    //Filmi silmek yerine kütüphanede varsa direk indeksine atama yapıyoruz.
                    if (this.kutuphane.kutuphanedekiFilmlerinIDleri().Contains(film.ImdbID))
                    {
                        int indeks = this.kutuphane.kutuphanedekiFilmIndeksi(film.ImdbID);
                        if (indeks != -1)
                        {
                            this.kutuphane.Filmler[indeks] = film;
                            this.kutuphane.kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
                        }
                    }
                    else
                        this.kutuphane.filmEkle(film, true);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                if (pbIlerleme.Value != 100)
                    pbIlerleme.Value = 100;
            }

            if (diziler.Count > 0)
            {
                foreach (Dizi dizi in diziler)
                {
                    //Filmi silmek yerine kütüphanede varsa direk indeksine atama yapıyoruz.
                    if (this.kutuphane.kutuphanedekiDizilerinIDleri().Contains(dizi.ImdbID))
                    {
                        int indeks = this.kutuphane.kutuphanedekiDiziIndeksi(dizi.ImdbID);
                        if (indeks != -1)
                        {
                            this.kutuphane.Diziler[indeks] = dizi;
                            this.kutuphane.kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
                        }
                    }
                    else
                        this.kutuphane.diziEkle(dizi, true);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                if (pbIlerleme.Value != 100)
                    pbIlerleme.Value = 100;
            }

            if (kisiler.Count > 0)
            {
                foreach (Kisi kisi in kisiler)
                {
                    //Filmi silmek yerine kütüphanede varsa direk indeksine atama yapıyoruz.
                    if (this.kutuphane.kutuphanedekiKisilerinIDleri(-1).Contains(kisi.ImdbID))
                    {
                        int indeks = this.kutuphane.kutuphanedekiKisiIndeksi(kisi.ImdbID);
                        if (indeks != -1)
                        {
                            this.kutuphane.Kisiler[indeks] = kisi;
                            this.kutuphane.kutuphaneDegisikligiCagirici.DynamicInvoke(new object[] { true });
                        }
                    }
                    else
                        this.kutuphane.kisiEkle(kisi);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                if (pbIlerleme.Value != 100)
                    pbIlerleme.Value = 100;
            }

            if (indirilirkenOlusanHatalar.Count > 0)
            {
                DialogResult hatalar = MessageBox.Show("Hatalar oluştu", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (hatalar == System.Windows.Forms.DialogResult.OK)
                {
                    f_HataGosterici hatalariGoster = new f_HataGosterici();
                    hatalariGoster.Hatalar = indirilirkenOlusanHatalar;
                    hatalariGoster.ShowDialog();
                    pbIlerleme.Value = 0;
                }
            }
        }
        private void filmBilgisiTumIlerleme()
        {
            IMDB yeni = new IMDB();
            yeni.intIlerlemeYuzdesi = this.intIlerlemeYuzdesi;
            yeni.stringIlerlemeKonumu = this.konumIlerleyici;
            yeni.idStringIlerlemeKonumu = this.bilgiAlici;

            foreach (string s in this.indirilecekBasliklar)
            {
                try
                {
                    List<string> bilgiler = yeni.kisaBilgileriIndir(s);
                }
                catch (System.Net.WebException hata)
                {
                    if (hata.Message.Contains("404"))
                        continue;

                    MessageBox.Show("İnternet bağlantınızda sorun var. Bağlantınız olduğundan emin olduktan sonra tekrar deneyin.",
                                                   Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception hata)
                {
                    indirilirkenOlusanHatalar.Add(hata);
                    continue;
                }
            }

            if (indirilirkenOlusanHatalar.Count > 0)
            {
                MessageBox.Show("Hatalar oluştu", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);
                f_HataGosterici yeniGosterici = new f_HataGosterici();
                yeniGosterici.Hatalar = indirilirkenOlusanHatalar;
                yeniGosterici.ShowDialog();
                pbIlerleme.Value = 0;
            }
        }
        

        #region Form Olayları
        private void f_ArastirarakEkle_Load(object sender, EventArgs e)
        {
            this.tsslEklenenBaslikSayisi.Visible = false;
            tsslIslemiIptalEt.Visible = false;
            tsslIslemiIptalEt.Enabled = false;
            if (this.txtAranacak.CanFocus)
                this.txtAranacak.Focus();
        } 
        private void f_ArastirarakEkle_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (this.arkaPlanAmelesi.IsBusy)
            {
                DialogResult d = MessageBox.Show("Şu anda işlem yapılmaktadır. Çıkmak istediğinize emin misiniz? İşlem iptal edilecek.",
                        Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (d == System.Windows.Forms.DialogResult.Yes)
                {
                    arkaPlanAmelesi.CancelAsync();
                    filmEklemeTumIlerleme();
                    e.Cancel = false;
                }
                else
                    e.Cancel = true;

            }
        }

        #endregion

        private void btnVarOlanlariKaldir_Click(object sender, EventArgs e)
        {
            if (this.basliklar.Count > 0)
            {
                foreach (string baslik in this.basliklar)
                {
                    if ((lvBulunanBasliklar.Items[baslik] != null) && ((this.kutuphane.kutuphanedekiFilm(baslik) != null)||(this.kutuphane.kutuphanedekiDizi(baslik) != null)))
                        lvBulunanBasliklar.Items[baslik].Remove();
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!bilgileriAlTusu)
            {
                filmEklemeTumIlerleme();
            }
            tuslarAktifPasif(true);
            tsslIslemiIptalEt.Visible = false;
            tsslIslemiIptalEt.Enabled = false;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bilgileriAlTusu)
            {
                filmBilgisiTumIlerleme();
            }
            else
            {
                siraliIndirme();
            }
        }
        private void tsslIslemiIptalEt_Click(object sender, EventArgs e)
        {
            if (arkaPlanAmelesi.WorkerSupportsCancellation)
            {
                arkaPlanAmelesi.CancelAsync();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAranacak.Text == "")
            {
                MessageBox.Show("Arayabilmem için birşey girmen lazım", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.lvsonuclar.Items.Clear();

            foreach (string key in this.kutuphane.IDVeritabani.Keys)
            {
                if (key == "") continue;

                if (this.kutuphane.IDVeritabani[key].Contains(txtAranacak.Text))
                {
                    this.lvsonuclar.Items.Add(key, "", key).SubItems.AddRange(new string[] { this.kutuphane.IDVeritabani[key], "Bilmiyorum", "Bilmiyorum" });
                }
            }

            try
            {
                IMDB yeni = new IMDB();
                yeni.aramaYap(txtAranacak.Text);

                if (yeni.AramaSonuclari != null)
                {
                    foreach (IMDBAramaKategorisi i in yeni.AramaSonuclari)
                    {
                        foreach (isimID isid in i.isimlerSonuclar)
                        {
                            string isim = "";
                            string yil = "";
                            if (isid.isim.Contains("@"))
                            {
                                isim = isid.isim.Split('@')[0];
                                yil = isid.isim.Split('@')[1];
                            }
                            else
                            {
                                isim = isid.isim;
                            }
                            if ((isim != "") || (yil != ""))
                            this.lvsonuclar.Items.Add(isid.id, "", isid.id).SubItems.AddRange(new string[] { isim, yil });
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
