using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Filmograf.Library;

namespace Filmograf
{
    public partial class f_AnaPencere : Form
    {
        #region Değişkenler, Delegeler, Olaylar
        Kutuphane kutuphane;
        List<string> olusturulanResimler;

        public delegate void ilerlemeCagrisi(int deger);
        private event ilerlemeCagrisi ilerleyici;

        public delegate void stringDurumCagrisi(string deger);
        private event stringDurumCagrisi stringDegistirici;

        public delegate void baslikDurumCagrisi(string baslik);
        private event baslikDurumCagrisi baslikDegisti;

        public delegate void formIsimDegistirmeCagrisi(string deger);
        private event formIsimDegistirmeCagrisi formIsimDegistirici;

        public delegate void kutuphaneDegistiCagrisi(bool deger);
        private event kutuphaneDegistiCagrisi kutuphaneDegiskigiCagirici;
        int toplamDeger = 0;

        public delegate void ilermeCagirici(int deger);
        public delegate void stringDurumCagirici(string deger);
        public delegate void islemYapilanBaslik(string baslik);

        #region Film Dizi Güncellemeyle Alakalı Değişkenler
        List<string> indirilecekBasliklar;
        List<Exception> indirilirkenOlusanHatalar;
        List<Film> filmler;
        List<Dizi> diziler;
        List<Kisi> kisiler;
        SortedDictionary<string, string> gelenKeyIsimler;
        public delegate void progressHandler(int deger);
        int arastirmaMiktari = 1;
        #endregion

        /// <summary>
        /// true ise Filmler gosterilir
        /// false ise Kisiler gosterilir
        /// </summary>
        bool gorunumModu = true;
        
        #endregion

        public f_AnaPencere()
        {
            InitializeComponent();
            olusturulanResimler = new List<string>();
            ilerleyici += new ilerlemeCagrisi(f_AnaPencere_ilerleyici);
            formIsimDegistirici += new formIsimDegistirmeCagrisi(f_AnaPencere_formIsimDegistirici);
            kutuphaneDegiskigiCagirici += new kutuphaneDegistiCagrisi(f_AnaPencere_kutuphaneDegiskigiCagirici);
            stringDegistirici += new stringDurumCagrisi(f_AnaPencere_stringDegistirici);
            baslikDegisti += new baslikDurumCagrisi(f_AnaPencere_baslikDegisti);

            this.mmcf_AnaMenu1.MenuDosya.SubmenuOpened += new System.Windows.RoutedEventHandler(MenuDosya_SubmenuOpened);
            this.mmcf_AnaMenu1.MI_yeniDosyaAc.Click += new System.Windows.RoutedEventHandler(MI_yeniDosyaAc_Click);
            this.mmcf_AnaMenu1.MI_yeniDosyaOlustur.Click += new System.Windows.RoutedEventHandler(MI_yeniDosyaOlustur_Click);
            this.mmcf_AnaMenu1.MI_programdanCikis.Click += new System.Windows.RoutedEventHandler(MI_programdanCikis_Click);
            this.mmcf_AnaMenu1.MI_kutuphaneyiSifrele.Click += new System.Windows.RoutedEventHandler(MI_kutuphaneyiSifrele_Click);
            this.mmcf_AnaMenu1.MI_kutuphaneyiKaydet.Click += new System.Windows.RoutedEventHandler(MI_kutuphaneyiKaydet_Click);
            this.mmcf_AnaMenu1.MI_kutuphaneyiFarkliKaydet.Click += new System.Windows.RoutedEventHandler(MI_kutuphaneyiFarkliKaydet_Click);
            this.mmcf_AnaMenu1.MI_kutuphaneKapat.Click += new System.Windows.RoutedEventHandler(MI_kutuphaneKapat_Click);

            this.mmcf_AnaMenu1.MenuDuzen.SubmenuOpened += new System.Windows.RoutedEventHandler(MenuDuzen_SubmenuOpened);
            this.mmcf_AnaMenu1.MI_TumunuSec.Click += new System.Windows.RoutedEventHandler(MI_TumunuSec_Click);
            this.mmcf_AnaMenu1.MI_Kes.Click += new System.Windows.RoutedEventHandler(MI_Kes_Click);
            this.mmcf_AnaMenu1.MI_Kopyala.Click += new System.Windows.RoutedEventHandler(MI_Kopyala_Click);
            this.mmcf_AnaMenu1.MI_Yapistir.Click += new System.Windows.RoutedEventHandler(MI_Yapistir_Click);
            this.mmcf_AnaMenu1.MI_Bul.Click += new System.Windows.RoutedEventHandler(MI_Bul_Click);

            this.mmcf_AnaMenu1.MI_BuyukSimgeler.Click += new System.Windows.RoutedEventHandler(MI_BuyukSimgeler_Click);
            this.mmcf_AnaMenu1.MI_KucukSimgeler.Click += new System.Windows.RoutedEventHandler(MI_KucukSimgeler_Click);
            this.mmcf_AnaMenu1.MI_Dose.Click += new System.Windows.RoutedEventHandler(MI_Dose_Click);
            this.mmcf_AnaMenu1.MI_Detaylar.Click += new System.Windows.RoutedEventHandler(MI_Detaylar_Click);
            this.mmcf_AnaMenu1.MI_Liste.Click += new System.Windows.RoutedEventHandler(MI_Liste_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziModu.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziModu_Click);
            this.mmcf_AnaMenu1.MI_KisiModu.Click += new System.Windows.RoutedEventHandler(MI_KisiModu_Click);

            this.mmcf_AnaMenu1.MenuFilmDizi.SubmenuOpened += new System.Windows.RoutedEventHandler(MenuFilmDizi_SubmenuOpened);
            this.mmcf_AnaMenu1.MI_ManuelFilmDiziEkle.Click += new System.Windows.RoutedEventHandler(MI_ManuelFilmDiziEkle_Click);
            this.mmcf_AnaMenu1.MI_ArastirarakFilmDiziEkle.Click += new System.Windows.RoutedEventHandler(MI_ArastirarakFilmDiziEkle_Click);
            this.mmcf_AnaMenu1.MI_DosyadanFilmDiziEkle.Click += new System.Windows.RoutedEventHandler(MI_DosyadanFilmDiziEkle_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziDuzenle.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziDuzenle_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziSil.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziSil_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziTumunuSil.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziTumunuSil_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziAfisleriniYenile.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziAfisleriniYenile_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziAfisleriniKaydet.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziAfisleriniKaydet_Click);
            this.mmcf_AnaMenu1.MI_FilmDiziBilgileriniYenile.Click += new System.Windows.RoutedEventHandler(MI_FilmDiziBilgileriniYenile_Click);

            this.mmcf_AnaMenu1.MenuKisi.SubmenuOpened += new System.Windows.RoutedEventHandler(MenuKisi_SubmenuOpened);
            this.mmcf_AnaMenu1.MI_ManuelKisiEkle.Click += new System.Windows.RoutedEventHandler(MI_ManuelKisiEkle_Click);
            this.mmcf_AnaMenu1.MI_ArastirarakKisiEkle.Click += new System.Windows.RoutedEventHandler(MI_ArastirarakKisiEkle_Click);
            this.mmcf_AnaMenu1.MI_DosyadanKisiEkle.Click += new System.Windows.RoutedEventHandler(MI_DosyadanKisiEkle_Click);
            this.mmcf_AnaMenu1.MI_KisiDuzenle.Click += new System.Windows.RoutedEventHandler(MI_KisiDuzenle_Click);
            this.mmcf_AnaMenu1.MI_KisiSil.Click += new System.Windows.RoutedEventHandler(MI_KisiSil_Click);
            this.mmcf_AnaMenu1.MI_KisiTumunuSil.Click += new System.Windows.RoutedEventHandler(MI_KisiTumunuSil_Click);
            this.mmcf_AnaMenu1.MI_KisilerinResimleriniYenile.Click += new System.Windows.RoutedEventHandler(MI_KisilerinResimleriniYenile_Click);
            this.mmcf_AnaMenu1.MI_KisilerinResimleriniKaydet.Click += new System.Windows.RoutedEventHandler(MI_KisilerinResimleriniKaydet_Click);
            this.mmcf_AnaMenu1.MI_KisilerinBilgileriniYenile.Click += new System.Windows.RoutedEventHandler(MI_KisilerinBilgileriniYenile_Click);

            this.mmcf_AnaMenu1.MI_BilgileriGoster.Click += new System.Windows.RoutedEventHandler(MI_BilgileriGoster_Click);
            this.mmcf_AnaMenu1.MI_BilgileriYedekle.Click += new System.Windows.RoutedEventHandler(MI_BilgileriYedekle_Click);
            this.mmcf_AnaMenu1.MI_BilgileriAl.Click += new System.Windows.RoutedEventHandler(MI_BilgileriAl_Click);
            this.mmcf_AnaMenu1.MI_HerseyiTemizle.Click += new System.Windows.RoutedEventHandler(MI_HerseyiTemizle_Click);
            this.mmcf_AnaMenu1.MI_KutuphaneyiDuzenle.Click += new System.Windows.RoutedEventHandler(MI_KutuphaneyiDuzenle_Click);
            this.mmcf_AnaMenu1.MI_Istatistikler.Click += new System.Windows.RoutedEventHandler(MI_Istatistikler_Click);
            this.mmcf_AnaMenu1.MI_Donustur.Click += new System.Windows.RoutedEventHandler(MI_Donustur_Click);

            this.mmcf_AnaMenu1.MI_CiciGoster.Click += new System.Windows.RoutedEventHandler(MI_CiciGoster_Click);
            this.mmcf_AnaMenu1.MI_Ayarlar.Click += new System.Windows.RoutedEventHandler(MI_Ayarlar_Click);
            this.mmcf_AnaMenu1.MI_YardimKonulari.Click += new System.Windows.RoutedEventHandler(MI_YardimKonulari_Click);
            this.mmcf_AnaMenu1.MI_Hakkinda.Click += new System.Windows.RoutedEventHandler(MI_Hakkinda_Click);
        }

        

        #region mmcf_AnaMenu Metodlar
        void MenuKisi_SubmenuOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            this.mmcf_AnaMenu1.MI_KisiSil.IsEnabled = (!gorunumModu) & (this.filmKisiListesi.SelectedItems.Count > 0);
            this.mmcf_AnaMenu1.MI_KisiTumunuSil.IsEnabled = (!gorunumModu);
            this.mmcf_AnaMenu1.MI_KisiDuzenle.IsEnabled = (!gorunumModu) & (this.filmKisiListesi.SelectedItems.Count == 1);
        }

        void MenuFilmDizi_SubmenuOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            this.mmcf_AnaMenu1.MI_FilmDiziSil.IsEnabled = (gorunumModu) & (this.filmKisiListesi.SelectedItems.Count > 0);
            this.mmcf_AnaMenu1.MI_FilmDiziTumunuSil.IsEnabled = (gorunumModu);
            this.mmcf_AnaMenu1.MI_FilmDiziDuzenle.IsEnabled = (gorunumModu) & (this.filmKisiListesi.SelectedItems.Count == 1);
        }

        void MenuDuzen_SubmenuOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            this.mmcf_AnaMenu1.MI_Kes.IsEnabled = (Clipboard.ContainsData("List<Kisi>") | Clipboard.ContainsData("List<Film>"));
            this.mmcf_AnaMenu1.MI_Kopyala.IsEnabled = (this.filmKisiListesi.SelectedItems.Count > 0);
            this.mmcf_AnaMenu1.MI_Yapistir.IsEnabled = (this.filmKisiListesi.SelectedItems.Count > 0);
        }

        void MenuDosya_SubmenuOpened(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_DosyadanFilmDiziEkle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dosyadanKutuphaneyeFilmEkle();
        }

        void MI_Hakkinda_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            f_Hakkinda yeni = new f_Hakkinda();
            yeni.ShowDialog();
        }

        void MI_YardimKonulari_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_Ayarlar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_CiciGoster_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
        }

        void MI_Donustur_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_Istatistikler_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            istatistiklerFormunuGoster();
        }

        void MI_KutuphaneyiDuzenle_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_HerseyiTemizle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult d = MessageBox.Show("Herşeyi temizlemek istediğinize emin misiniz? Eklediğiniz tüm başlıklar ve kişiler silenecektir", Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No) return;

            if (this.kutuphane != null)
            {
                this.kutuphane.tumDizileriSil();
                this.kutuphane.tumFilmleriSil();
                this.kutuphane.tumKisileriSil();
                this.kutuphane.TumVeritabaniniSil();
                this.kutuphane.Dispose();
            }
        }

        void MI_BilgileriAl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.kutuphane == null) return;

            OpenFileDialog yeni = new OpenFileDialog();
            yeni.Title = "Bilgileri alacağınız dosyayı seçin";
            yeni.Filter = Sabitler.FilmografKutuphaneVeritabaniDosyasi;
            DialogResult d = yeni.ShowDialog();

            if ((d == System.Windows.Forms.DialogResult.OK) && (yeni.FileName != ""))
            {
                FileStream f = null;
                try
                {
                    f = new FileStream(yeni.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();

                    SortedDictionary<string, string> gelenIDIsimler = new SortedDictionary<string, string>();

                    gelenIDIsimler = (SortedDictionary<string, string>)b.Deserialize(f);

                    f.Close();

                    int guncellenenMiktar = 0;
                    guncellenenMiktar = this.kutuphane.Guncelle(gelenIDIsimler);

                    MessageBox.Show(guncellenenMiktar.ToString() + " adet giriş eklendi", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception hata)
                {
                    if (f != null) f.Close();
                    MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void MI_BilgileriYedekle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.kutuphane == null) return;

            SaveFileDialog yeni = new SaveFileDialog();
            yeni.Title = "Bilgileri kaydedeceğiniz dosyayı seçin";
            yeni.Filter = Sabitler.FilmografKutuphaneVeritabaniDosyasi;
            yeni.FileName = this.kutuphane.KutuphaneAdi;
            DialogResult d = yeni.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                FileStream f = null;
                try
                {
                    f = new FileStream(yeni.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    BinaryFormatter b = new BinaryFormatter();

                    if ((this.kutuphane.IDVeritabani != null) && (this.kutuphane.IDVeritabani.Count != 0))
                    {
                        b.Serialize(f, this.kutuphane.IDVeritabani);
                    }

                    f.Close();
                }
                catch (Exception hata)
                {
                    if (f != null) f.Close();
                    MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void MI_BilgileriGoster_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.kutuphane != null)
            {
                f_KutuphaneBilgisi kutuphanebilgisi = new f_KutuphaneBilgisi();
                kutuphanebilgisi.formIsimCagiricisi = this.formIsimDegistirici;
                kutuphanebilgisi.Kutuphane = this.kutuphane;
                kutuphanebilgisi.ShowDialog();
            }
        }

        void MI_KisilerinBilgileriniYenile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_KisilerinResimleriniKaydet_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_KisilerinResimleriniYenile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_KisiTumunuSil_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Tüm kişileri siliyoruz. 
            DialogResult soru;

            soru = MessageBox.Show("Tüm kişileri silmek istediğine emin misin? İyice düşündün İnşallah? ", Sabitler.ProgramBasligi,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (soru == System.Windows.Forms.DialogResult.Yes)
            {
                this.kutuphane.tumKisileriSil();
                this.filmKisiListesi.Items.Clear();
                this.fkBuyukResimler.Images.Clear();
                yenile();
            }
            else
            {
            }
        }

        void MI_KisiSil_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            secilenKisileriSil();
        }

        void MI_KisiDuzenle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (gorunumModu == false)
            {
                filmKisiDuzenle();
            }
        }

        void MI_DosyadanKisiEkle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dosyadanKutuphaneyeKisiEkle();
        }

        void MI_ArastirarakKisiEkle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            arastirarakKisiEkleGoster();
        }

        void MI_ManuelKisiEkle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            manuelKisiEkleGoster();
        }

        void MI_FilmDiziBilgileriniYenile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_FilmDiziAfisleriniKaydet_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_FilmDiziAfisleriniYenile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_FilmDiziTumunuSil_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Tüm filmleri siliyoruz. 
            DialogResult soru;

            soru = MessageBox.Show("Tüm filmleri silmek istediğine emin misin? İyice düşündün İnşallah? ", Sabitler.ProgramBasligi,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (soru == System.Windows.Forms.DialogResult.Yes)
            {
                this.kutuphane.tumFilmleriSil();
                this.kutuphane.tumDizileriSil();

                yenile();
            }
            else
            {
            }
        }

        void MI_FilmDiziSil_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            secilenFilmleriSil();
        }

        void MI_FilmDiziDuzenle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (gorunumModu == true)
            {
                filmKisiDuzenle();
            }
        }

        void MI_ArastirarakFilmDiziEkle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            arastirarakFilmEkleGoster();
        }

        void MI_ManuelFilmDiziEkle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            manuelFilmEkleGoster();
        }

        void MI_KisiModu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            kisiModunuAktiflestir();
        }

        void MI_FilmDiziModu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            filmModunuAktiflestir();
        }

        void MI_Liste_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_Detaylar_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_Dose_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_KucukSimgeler_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_BuyukSimgeler_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_Bul_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_Yapistir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            yapistir();
        }

        void MI_Kopyala_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            kopyala();
        }

        void MI_Kes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            kes();
        }

        void MI_TumunuSec_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if ((this.kutuphane != null) && (this.kutuphane.Filmler.Count > 0) &&
                  (this.filmKisiListesi.Items.Count > 0))
            {
                for (int i = 0; i < this.filmKisiListesi.Items.Count; i++)
                {
                    this.filmKisiListesi.Items[i].Selected = true;
                }
            }
        }

        void MI_kutuphaneKapat_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            kutuphaneyiKapatKardes();
        }

        void MI_kutuphaneyiFarkliKaydet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            farkliKaydet();
        }

        void MI_kutuphaneyiKaydet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            guncelKutuphaneyiKaydet();
        }

        void MI_kutuphaneyiSifrele_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        void MI_programdanCikis_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        void MI_yeniDosyaOlustur_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            yeniKutuphaneOlustur();
        }

        void MI_yeniDosyaAc_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            mevcutKutuphaneAc();
        } 
        #endregion

        #region Olaylar Ve Thread Yazıcılar
        private void f_AnaPencere_baslikDegisti(string baslik)
        {
            BaslikDegistir(baslik);
        }
        private void BaslikDegistir(string baslik)
        {
            if (this.filmKisiListesi.InvokeRequired)
            {
                islemYapilanBaslik yeni = new islemYapilanBaslik(BaslikDegistir);
                this.Invoke(yeni, new object[] { baslik });
            }
            else
            {
                this.filmKisiListesi.Items[baslik].Font = new System.Drawing.Font("Microsoft YaHei", 10, System.Drawing.FontStyle.Bold);
            }
        }
        private void f_AnaPencere_stringDegistirici(string deger)
        {
            stringDegistir(deger);
        }
        private void stringDegistir(string deger)
        {
            if (this.DurumCubugu.InvokeRequired)
            {
                stringDurumCagirici yeni = new stringDurumCagirici(stringDegistir);
                this.Invoke(yeni, new object[] { deger });
            }
            else
            {
                this.tsslDurumBilgisi.Text = deger;
            }
        }
        private void f_AnaPencere_kutuphaneDegiskigiCagirici(bool deger)
        {
            if (deger)
            {
                if (!this.Text.StartsWith("*"))
                {
                    this.Text = "*" + " " + this.Text;
                }
            }
            else
            {
                this.Text = this.kutuphane.KutuphaneAdi + " - " + Sabitler.ProgramBasligi;
            }
        }
        private void f_AnaPencere_formIsimDegistirici(string deger)
        {
            this.Text = deger + " - " + Sabitler.ProgramBasligi;
        }
        private void f_AnaPencere_ilerleyici(int deger)
        {
            toplamDeger += (deger / arastirmaMiktari);
            if (toplamDeger < 0) toplamDeger = 0;
            if (toplamDeger > 100) toplamDeger = 100;

            IlerleyiciyiAyarla(toplamDeger);
        }
        private void IlerleyiciyiAyarla(int deger)
        {
            if (this.tspIlerlemeCubugu.ProgressBar.InvokeRequired)
            {
                progressHandler ph = new progressHandler(IlerleyiciyiAyarla);
                this.Invoke(ph, new object[] { deger });
            }
            else
            {
                this.tspIlerlemeCubugu.ProgressBar.Value = deger;
            }
        } 
        #endregion

        #region Ana Pencere Olayları
        private void f_AnaPencere_Load(object sender, EventArgs e)
        {
            string komutSatiri = Environment.CommandLine;

            Regex r = new Regex("\"([^\"]*)\"(\\s+|$)");
            MatchCollection m = r.Matches(komutSatiri);

            if (m.Count == 1) //The program hasn't been open by clicking any of its files.
            {
                kutuphaneYok();
            }
            else if (m.Count == 2) //There is a request to open the program's file.
            {
                string dosya = m[1].Groups[1].Value;

                if (dosyaUzantisi(dosya) == "fkh") //Dosya uzantılarının desteğini sonra yerleştir.
                {
                    try
                    {
                        this.kutuphane = Kutuphane.kutuphaneAc(dosya);
                        this.Text = kutuphane.KutuphaneAdi + " - " + this.Text;
                        this.kutuphane.kutuphaneDegisikligiCagirici = this.kutuphaneDegiskigiCagirici;
                        yenile();
                        kutuphaneVar();
                    }
                    catch (Exception)
                    {
                        if (this.kutuphane != null) //Hata kütüphaneyi açmaktan dolayı oluşmadıysa
                        {
                            this.Text = kutuphane.KutuphaneAdi + " - " + this.Text;
                            yenile();
                            kutuphaneVar();
                        }
                        else
                        {
                            kutuphaneYok();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dosya desteklenmiyor");
                    kutuphaneYok();

                }
            }
            else //Multiple files requesting to be opened.
            {
            }
        }
        private void f_AnaPencere_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //kütüphaneden çıkılmamışsa 
            if (this.kutuphane != null)
            {
                if (this.Text.StartsWith("*"))
                {
                    DialogResult d = MessageBox.Show(this.kutuphane.KutuphaneAdi +
                        " - Kütüphanesinde kaydedilmemiş değişiklik var. Bunlar kaydedilsin mi?",
                        Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (d == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            this.kutuphane.kutuphaneyiKaydet();
                        }
                        catch (Exception hata)
                        {
                            DialogResult d2 = MessageBox.Show("Kütüphane kaydedilemedi: " + hata.Message +
                                ". Kaydetmeden çıkmak ister misiniz?",
                                         Sabitler.ProgramBasligi, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (d2 == System.Windows.Forms.DialogResult.No)
                            {
                                e.Cancel = true;
                                return;
                            }
                            else if (d2 == System.Windows.Forms.DialogResult.Yes)
                            {
                            }
                        }

                        kutuphaneyiKapatKardes();
                    }
                    else if (d == System.Windows.Forms.DialogResult.No)
                    {
                        kutuphaneyiKapatKardes();
                    }
                }
                else
                    kutuphaneyiKapatKardes();
            }
            else
                kutuphaneyiKapatKardes();
        } 
        #endregion

        #region Fonksiyonlar
        private List<Film> seciliFilmlerdenDondur()
        {
            List<Film> seciliFilmler = new List<Film>();

            for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
            {
                Film f = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[i].ImageKey);
                if (f != null)
                    seciliFilmler.Add(f);
            }

            return seciliFilmler;
        }
        private List<Dizi> seciliDiziler()
        {
            List<Dizi> seciliDiziler = new List<Dizi>();

            for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
            {
                Dizi d = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                if (d != null)
                    seciliDiziler.Add(d);
            }

            return seciliDiziler;
        }
        private List<Kisi> seciliKisilerdenDondur()
        {
            List<Kisi> seciliKisiler = new List<Kisi>();

            for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
            {
                Kisi k = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                if (k != null)
                    seciliKisiler.Add(k);
            }

            return seciliKisiler;
        } 
        #endregion

        #region Serialize/Deserialize

        private string Serialize(object objectToSerialize)
        {
            string serialString = null;
            MemoryStream ms1 = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();

            b.Serialize(ms1, objectToSerialize);
            byte[] arrayByte = ms1.ToArray();
            serialString = Convert.ToBase64String(arrayByte);

            return serialString;
        }
        private object DeSerialize(string serializationString)
        {
            object deserialObject = null;
            byte[] arrayByte = Convert.FromBase64String(serializationString);
            MemoryStream ms1 = new MemoryStream(arrayByte);
            BinaryFormatter b = new BinaryFormatter();

            deserialObject = b.Deserialize(ms1);

            return deserialObject;
        }

        #endregion

        #region Dosya Uzantısı

        private string dosyaUzantisi(string dosya)
        {
            Regex r = new Regex("^.*[.]([^.]*)$");
            Match m = r.Match(dosya);
            return m.Groups[1].Value;
        }
        private string dosyaninUzantisizAdi(string dosya)
        {
            FileInfo dossya = new FileInfo(dosya);
            return dossya.Name.Substring(0, dossya.Name.LastIndexOf('.'));
        }

        #endregion

        #region Tuşlar Aktif/Pasif

        public void tuslarAktif()
        {
            kutuphaneyiKaydet.Enabled = true;
            manuelFilmEkle.Enabled = true;
            arastirarakFilmEkle.Enabled = true;
            manuelKisiEkle.Enabled = true;
            arastirarakKisiEkle.Enabled = true;
            kutuphaneAramaMetni.Enabled = true;
            kutuphaneAra.Enabled = true;
            istatistikleriGoster.Enabled = true;
            dosyadanFilmEkle.Enabled = true;
            dosyadanKisiEkle.Enabled = true;
        }
        public void tuslarPasif()
        {
            kutuphaneyiKaydet.Enabled = false;
            manuelFilmEkle.Enabled = false;
            arastirarakFilmEkle.Enabled = false;
            manuelKisiEkle.Enabled = false;
            arastirarakKisiEkle.Enabled = false;
            kutuphaneAramaMetni.Enabled = false;
            kutuphaneAra.Enabled = false;
            istatistikleriGoster.Enabled = false;
            dosyadanFilmEkle.Enabled = false;
            dosyadanKisiEkle.Enabled = false;
        }

        #endregion

        #region Kütüphane Var/Yok

        public void kutuphaneYok()
        {
            tuslarPasif();
        }
        public void kutuphaneVar()
        {
            tuslarAktif();
            kutuphaneIstatistikleriniGoster();
        }

        #endregion

        #region Kütüphane Güncelleyici Fonksiyonlar

        /// <summary>
        /// Sanal kütüphane sinifina film eklendiginde veya silindiginde
        /// etkisinin filmlistesinde gosterilmesidir.
        /// </summary>
        /// <param name="filmListesi">kütüphaneye eklenen filmler</param>
        /// <param name="ekleVeyaSil">eger filmler kütüphaneye eklenmisse true, silinmisse false</param>
        public void filmleriGoster(List<Film> filmListesi, bool ekleVeyaSil)
        {
            if (gorunumModu == false) return; //Kişi görünüm modunda ise

            if ((filmListesi != null) && (ekleVeyaSil == true))
            {
                for (int i = 0; i < filmListesi.Count; i++)
                {
                    this.filmKisiListesi.Items.Add(filmListesi[i].ImdbID, filmListesi[i].Ad, filmListesi[i].ImdbID);
                    this.fkBuyukResimler.Images.Add(filmListesi[i].ImdbID, filmListesi[i].Afis);
                    this.fkKucukResimler.Images.Add(filmListesi[i].ImdbID, filmListesi[i].Afis);

                    this.filmKisiListesi.Items[filmListesi[i].ImdbID].SubItems.AddRange(new string[] { filmListesi[i].CikisTarihi, filmListesi[i].Sure });
                    
                }
            }

            if ((filmListesi != null) && (ekleVeyaSil == false))
            {
                for (int i = 0; i < filmListesi.Count; i++)
                {
                    this.filmKisiListesi.Items.RemoveByKey(filmListesi[i].ImdbID);
                    this.fkBuyukResimler.Images.RemoveByKey(filmListesi[i].ImdbID);
                    this.fkKucukResimler.Images.RemoveByKey(filmListesi[i].ImdbID);
                }
            }
            kutuphaneIstatistikleriniGoster();
        }

        public void dizileriGoster(List<Dizi> diziListesi, bool ekleVeyaSil)
        {
            if (gorunumModu == false) return; //Kişi görünüm modunda ise

            if ((diziListesi != null) && (ekleVeyaSil == true))
            {
                for (int i = 0; i < diziListesi.Count; i++)
                {
                    this.filmKisiListesi.Items.Add(diziListesi[i].ImdbID, diziListesi[i].Ad, diziListesi[i].ImdbID);
                    this.fkBuyukResimler.Images.Add(diziListesi[i].ImdbID, diziListesi[i].Afis);
                    this.fkKucukResimler.Images.Add(diziListesi[i].ImdbID, diziListesi[i].Afis);

                    this.filmKisiListesi.Items[diziListesi[i].ImdbID].SubItems.AddRange(new string[] { diziListesi[i].CikisTarihi, diziListesi[i].Sure });
                }
            }

            if ((diziListesi != null) && (ekleVeyaSil == false))
            {
                for (int i = 0; i < diziListesi.Count; i++)
                {
                    this.filmKisiListesi.Items.RemoveByKey(diziListesi[i].ImdbID);
                    this.fkBuyukResimler.Images.RemoveByKey(diziListesi[i].ImdbID);
                    this.fkKucukResimler.Images.RemoveByKey(diziListesi[i].ImdbID);
                }
            }
            kutuphaneIstatistikleriniGoster();
        }

        /// <summary>
        /// Parametre olarak verilen kütüphanedeki kişileri 
        /// filmKisiListesine listeler
        /// </summary>
        /// <param name="gosterilecekKutuphane">Kişileri listelenecek kütüphane</param>
        public void kisileriGoster(Kutuphane gosterilecekKutuphane, bool ekleVeyaSil)
        {
            if ((gosterilecekKutuphane == null) || (gorunumModu == true))
            {
                return;
            }

            if (ekleVeyaSil == true) //Gösterilecek kütüphane elemanları mevcut kütüphaneye eklenmişse
            {
                if (gosterilecekKutuphane.Kisiler.Count > 0)
                {
                    foreach (Kisi eklenen in gosterilecekKutuphane.Kisiler)
                    {
                        this.filmKisiListesi.Items.Add(eklenen.ImdbID, eklenen.Isim, eklenen.ImdbID);
                        this.fkBuyukResimler.Images.Add(eklenen.ImdbID, eklenen.Resim);
                        this.fkKucukResimler.Images.Add(eklenen.ImdbID, eklenen.Resim);
                    }
                }

            }
            else //Kütüphanenin elemanları; filmKisiListesinde yoksa kaldır.
            {
                if (gosterilecekKutuphane.Kisiler.Count > 0)
                {
                    foreach (Kisi silinen in gosterilecekKutuphane.Kisiler)
                    {
                        if (this.filmKisiListesi.Items.IndexOfKey(silinen.ImdbID) != -1)
                        {
                            this.filmKisiListesi.Items.RemoveByKey(silinen.ImdbID);
                            this.fkBuyukResimler.Images.RemoveByKey(silinen.ImdbID);
                            this.fkKucukResimler.Images.RemoveByKey(silinen.ImdbID);
                        }
                    }
                }

            }

            kutuphaneIstatistikleriniGoster();
        }
        
        /// <summary>
        /// Tüm kütüphaneyi filmKisiListesinde gösterecek şekilde yeniler
        /// </summary>
        private void yenile()
        {
            if (this.kutuphane == null)
            {
                this.fkBuyukResimler.Images.Clear();
                this.filmKisiListesi.Items.Clear();
                return;
            }

            if (gorunumModu == true)
            {
                //Once kisi resimlerini temizleyelim.
                this.fkBuyukResimler.Images.Clear();
                this.filmKisiListesi.Items.Clear();

                //Daha sonra film afislerini yerlestirelim.
                filmleriGoster(this.kutuphane.Filmler, true);
                dizileriGoster(this.kutuphane.Diziler, true);
            }
            else
            {
                //Once film afislerini temizleyelim
                this.fkBuyukResimler.Images.Clear();
                this.filmKisiListesi.Items.Clear();

                //Daha sonra kisi afislerini yerlestirelim.
                kisileriGoster(this.kutuphane, true);
            }
        }
        
        private void kutuphaneIstatistikleriniGoster()
        {
            kutuphaneFilmSayisi.Text = this.kutuphane.Filmler.Count.ToString() + " Film";
            kutuphaneDiziSayisi.Text = this.kutuphane.Diziler.Count.ToString() + " Dizi";
            tsslKisiSayisi.Text = this.kutuphane.Kisiler.Count.ToString() + " Kisi";
        }
        #endregion

        #region Başlangıçta Açılan Menünün Komutları

        private void cikisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void yeniKütüphaneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            yeniKutuphaneOlustur();
        }
        private void kütüphaneAcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mevcutKutuphaneAc();
        }

        #endregion

        #region Araç Çubuğu Metodları

        private void kutuphaneyiKaydet_Click(object sender, EventArgs e)
        {
            guncelKutuphaneyiKaydet();
        }
        private void kutuphaneAc_Click(object sender, EventArgs e)
        {
            mevcutKutuphaneAc();
        }
        private void Kes_Click(object sender, EventArgs e)
        {
            kes();
        }
        private void Kopyala_Click(object sender, EventArgs e)
        {
            kopyala();
        }
        private void Yapistir_Click(object sender, EventArgs e)
        {
            yapistir();
        }
        private void manuelKisiEkle_Click(object sender, EventArgs e)
        {
            manuelKisiEkleGoster();
        }
        private void arastirarakFilmEkle_Click(object sender, EventArgs e)
        {
            arastirarakFilmEkleGoster();
        }
        private void arastirarakKisiEkle_Click(object sender, EventArgs e)
        {
            arastirarakKisiEkleGoster();
        }
        private void yeniKutuphane_Click(object sender, EventArgs e)
        {
            yeniKutuphaneOlustur();
        }
        private void manuelFilmEkle_Click(object sender, EventArgs e)
        {
            manuelFilmEkleGoster();
        }
        private void dosyadanFilmEkle_Click(object sender, EventArgs e)
        {
            dosyadanKutuphaneyeFilmEkle();
        }
        private void dosyadanKisiEkle_Click(object sender, EventArgs e)
        {
            dosyadanKutuphaneyeKisiEkle();
        }

        #endregion

        #region Ortak Görevli Metodlar

        private void yeniKutuphaneOlustur()
        {
            //kütüphaneden çıkılmamışsa 
            if ((this.kutuphane != null))
            {
                if (this.Text.StartsWith("*"))
                {
                    DialogResult d = MessageBox.Show(this.kutuphane.KutuphaneAdi +
                        " - Kütüphanesinde kaydedilmemiş değişiklikler var. Bunlar kaydedilsin mi?",
                        Sabitler.ProgramBasligi, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (d == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            this.kutuphane.kutuphaneyiKaydet();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show("Kütüphane kaydedilemedi: " + hata.Message,
                                                Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        kutuphaneyiKapatKardes();
                    }
                    else if (d == System.Windows.Forms.DialogResult.No)
                    {
                        kutuphaneyiKapatKardes();
                    }
                    else if (d == System.Windows.Forms.DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                        kutuphaneyiKapatKardes();
                }
            }
            else
                kutuphaneyiKapatKardes();

            dosyaKaydetDiyalokKutusu.Filter = Sabitler.FilmografKutuphaneDosyasi;
            dosyaKaydetDiyalokKutusu.Title = "Kütüphaneyi Kaydedeceginiz yeri ve kütüphanenin ismini belirleyin";
            dosyaKaydetDiyalokKutusu.FileName = "";
            DialogResult d1 = dosyaKaydetDiyalokKutusu.ShowDialog();
            if ((dosyaKaydetDiyalokKutusu.FileName != "") && (d1 == System.Windows.Forms.DialogResult.OK))
            {
                FileInfo kutuphanee = new FileInfo(dosyaKaydetDiyalokKutusu.FileName);
                kutuphane = new Kutuphane(dosyaKaydetDiyalokKutusu.FileName, dosyaninUzantisizAdi(kutuphanee.Name));
                kutuphane.kutuphaneDegisikligiCagirici = this.kutuphaneDegiskigiCagirici;
                this.Text = kutuphane.KutuphaneAdi + " - " + this.Text;
                kutuphaneVar();
            }
            else if (d1 == System.Windows.Forms.DialogResult.Cancel)
            {
            }

        }
        private void mevcutKutuphaneAc()
        {
            
                dosyaAcDiyalokKutusu.Title = "Kütüphaneyi seçin";
                dosyaAcDiyalokKutusu.FileName = "";
                dosyaAcDiyalokKutusu.Filter = Sabitler.FilmografKutuphaneDosyasi;
                DialogResult d1 = dosyaAcDiyalokKutusu.ShowDialog();

            try
            {
                if ((dosyaAcDiyalokKutusu.FileName != "") && (d1 == System.Windows.Forms.DialogResult.OK))
                {
                    //kütüphaneden çıkılmamışsa 
                    if (this.kutuphane != null)
                    {
                        if (this.Text.StartsWith("*"))
                        {
                            DialogResult d = MessageBox.Show("\"" + this.kutuphane.KutuphaneAdi + "\"" +
                                " - kütüphanesinde kaydedilmemiş değişiklikler var. Bunlar kaydedilsin mi?",
                                Sabitler.ProgramBasligi, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            if (d == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {
                                    this.kutuphane.kutuphaneyiKaydet();
                                }
                                catch (Exception hata)
                                {
                                    MessageBox.Show("Kütüphane kaydedilemedi: " + hata.Message,
                                                    Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return;
                                }
                            }
                            else if (d == System.Windows.Forms.DialogResult.No)
                            {
                                kutuphaneyiKapatKardes();
                            }
                            else if (d == System.Windows.Forms.DialogResult.Cancel)
                            {
                                return;
                            }
                        }
                        else
                            kutuphaneyiKapatKardes();
                    }
                    else
                        kutuphaneyiKapatKardes();

                    try
                    {
                        this.kutuphane = Kutuphane.kutuphaneAc(dosyaAcDiyalokKutusu.FileName);
                        this.Text = this.kutuphane.KutuphaneAdi + " - " + Sabitler.ProgramBasligi;
                        this.kutuphane.kutuphaneDegisikligiCagirici = this.kutuphaneDegiskigiCagirici;
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (this.kutuphane != null)
                    {
                        yenile();
                        kutuphaneVar();
                    }
                }
                else if (d1 == System.Windows.Forms.DialogResult.Cancel)
                {
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata olustu: " + hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                kutuphaneYok();
            }
        }
        private void guncelKutuphaneyiKaydet()
        {
            try
            {
                if (kutuphane != null)
                {
                    kutuphane.kutuphaneyiKaydet();
                    this.Text = kutuphane.KutuphaneAdi + " - " + Sabitler.ProgramBasligi;
                }
                else
                {
                    MessageBox.Show("Kaydetmek icin öncelikle kütüphane oluşturmalısınız.",
                        Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata olustu: " + hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void kes()
        {
            try
            {
                if ((this.kutuphane != null) && (this.kutuphane.Filmler.Count > 0) && (this.filmKisiListesi.Items.Count > 0)
                        && (this.filmKisiListesi.SelectedItems.Count > 0))
                {
                    if (this.gorunumModu == true)
                    {
                        List<object> seciliFilmlerDiziler = new List<object>();

                        for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
                        {
                            Film f = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[i].ImageKey);
                            if (f != null)
                            {
                                seciliFilmlerDiziler.Add(f);
                                this.kutuphane.filmSil(f);
                            }
                            else
                            {
                                Dizi d = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                                if (d != null)
                                {
                                    seciliFilmlerDiziler.Add(d);
                                    this.kutuphane.diziSil(d);
                                }
                            }
                        }

                        Clipboard.SetData("List<object>", Serialize(seciliFilmlerDiziler));
                    }
                    else
                    {
                        List<Kisi> seciliKisiler = new List<Kisi>();

                        for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
                        {
                            Kisi k = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                            if (k != null)
                                seciliKisiler.Add(k);
                        }

                        Clipboard.SetData("List<Kisi>", Serialize(seciliKisiler));
                        this.kutuphane.kisileriSil(seciliKisiler);

                    }

                    yenile();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void kopyala()
        {
            try
            {
                if ((this.kutuphane != null) && (this.kutuphane.Filmler.Count > 0) && (this.filmKisiListesi.Items.Count > 0)
                   && (this.filmKisiListesi.SelectedItems.Count > 0))
                {
                    if (this.gorunumModu == true)
                    {
                        List<object> seciliFilmlerDiziler = new List<object>();

                        for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
                        {
                            Film f = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[i].ImageKey);
                            if (f != null)
                                seciliFilmlerDiziler.Add(f);
                            else
                            {
                                Dizi d = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                                if (d != null)
                                    seciliFilmlerDiziler.Add(d);
                            }
                        }

                        Clipboard.SetData("List<object>", Serialize(seciliFilmlerDiziler));
                    }
                    else
                    {
                        List<Kisi> seciliKisiler = new List<Kisi>();

                        for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
                        {
                            Kisi k = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[i].Name);
                            if (k != null)
                                seciliKisiler.Add(k);
                        }

                        Clipboard.SetData("List<Kisi>", Serialize(seciliKisiler));
                    }

                    yenile();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void yapistir()
        {
            IDataObject veri = Clipboard.GetDataObject();

            try
            {
                if (veri.GetDataPresent("List<object>"))
                {
                    List<object> gelenFilmler = (List<object>)DeSerialize((veri.GetData("List<object>").ToString()));

                    if (gelenFilmler != null)
                    {
                        for (int i = 0; i < gelenFilmler.Count; i++)
                        {
                            if (gelenFilmler[i] is Film)
                            {
                                if (gelenFilmler[i] != null)
                                {
                                    this.kutuphane.filmEkle((Film)gelenFilmler[i]);
                                }
                            }
                            if (gelenFilmler[i] is Dizi)
                            {
                                if (gelenFilmler[i] != null)
                                {
                                    this.kutuphane.diziEkle((Dizi)gelenFilmler[i]);
                                }
                            }
                        }

                        yenile();
                    }
                }

                if (veri.GetDataPresent("List<Kisi>"))
                {
                    List<Kisi> gelenKisiler = (List<Kisi>)DeSerialize((veri.GetData("List<Kisi>").ToString()));

                    if (gelenKisiler != null)
                    {
                        for (int i = 0; i < gelenKisiler.Count; i++)
                        {
                            if (!this.kutuphane.kutuphanedekiKisilerinIDleri(-1).Contains(gelenKisiler[i].ImdbID))
                            {
                                this.kutuphane.kisiEkle(gelenKisiler[i]);
                            }
                        }

                        yenile();
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void manuelFilmEkleGoster()
        {
            if (kutuphane == null)
            {
                MessageBox.Show("Film eklemek için kütüphane oluşturmalısınız", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //film ekleme işlemleri diyalokta yapılıyor.
            f_ManuelFilmEkle filmekle = new f_ManuelFilmEkle(false, this.kutuphane);
            DialogResult d = filmekle.ShowDialog();
            
            if (d == System.Windows.Forms.DialogResult.OK)
            {
                yenile();
            }

        }
        private void manuelKisiEkleGoster()
        {
            if (kutuphane == null)
            {
                MessageBox.Show("Kişi eklemek icin kütüphane olusturmalisiniz", Sabitler.ProgramBasligi,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            f_ManuelKisiEkle kisiekle = new f_ManuelKisiEkle((int)KisiDuzenlemeModu.KisiEkle, this.kutuphane);

            DialogResult d = kisiekle.ShowDialog();
            Kisi kisi = kisiekle.Kisi;

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                yenile();
            }

        }
        private void arastirarakFilmEkleGoster()
        {
            if (kutuphane == null)
            {
                MessageBox.Show("Film eklemek için kütüphane oluşturmalısınız", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            f_ArastirarakEkle filmekle = new f_ArastirarakEkle(0, this.kutuphane);

            DialogResult d = filmekle.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                yenile();
            }

        }
        private void arastirarakKisiEkleGoster()
        {
            if (kutuphane == null)
            {
                MessageBox.Show("Kişi eklemek için kütüphane oluşturmalısınız", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            f_ArastirarakEkle kisiEkle = new f_ArastirarakEkle(1, this.kutuphane);

            DialogResult d = kisiEkle.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                yenile();
            }

        }
        private void filmModunuAktiflestir()
        {
            if (gorunumModu == false)
            {
                //Gorünüm modunu degistir
                this.gorunumModu = true;

                //Once kisi resimlerini temizleyelim.
                this.fkBuyukResimler.Images.Clear();
                this.filmKisiListesi.Items.Clear();

                //Daha sonra film afislerini yerlestirelim.
                filmleriGoster(this.kutuphane.Filmler, true);

            }
        }
        private void kisiModunuAktiflestir()
        {
            if (gorunumModu == true)
            {
                //Gorünüm modunu degistir
                this.gorunumModu = false;

                //Once film afislerini temizleyelim
                this.fkBuyukResimler.Images.Clear();
                this.filmKisiListesi.Items.Clear();

                //Daha sonra kisi afislerini yerlestirelim.
                kisileriGoster(this.kutuphane, true);

            }
        }
        private void filmKisiDuzenle()
        {
            if (this.filmKisiListesi.SelectedIndices.Count == 1)
            {
                if (gorunumModu == true)
                {
                    Film secilenFilm = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[0].ImageKey);
                    Dizi secilenDizi = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[0].ImageKey);

                    if (secilenFilm != null)
                    {
                        f_ManuelFilmEkle filmiDuzenle = new f_ManuelFilmEkle(true, this.kutuphane);
                        filmiDuzenle.Film = secilenFilm;

                        DialogResult d = filmiDuzenle.ShowDialog();

                        if (d == System.Windows.Forms.DialogResult.OK)
                        {
                            yenile();
                        }

                    }
                    else if (secilenDizi != null)
                    {
                        f_ManuelFilmEkle filmiDuzenle = new f_ManuelFilmEkle(true, this.kutuphane);
                        filmiDuzenle.Dizi = secilenDizi;

                        DialogResult d = filmiDuzenle.ShowDialog();

                        if (d == System.Windows.Forms.DialogResult.OK)
                        {
                            yenile();
                        }

                    }
                }
                else
                {
                    Kisi secilenKisi = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[0].ImageKey);

                    if (secilenKisi != null)
                    {
                        f_ManuelKisiEkle kisiDuzenle = new f_ManuelKisiEkle((int)KisiDuzenlemeModu.KisiDuzenle, this.kutuphane);
                        kisiDuzenle.Kisi = secilenKisi;
                        DialogResult d = kisiDuzenle.ShowDialog();

                        if (d == System.Windows.Forms.DialogResult.OK)
                        {
                            yenile();
                        }

                    }
                }
            }
        }
        private void farkliKaydet()
        {
            if (gorunumModu == true)
            {
                if (this.filmKisiListesi.SelectedItems.Count == 0)
                {
                    //Farklı kaydet seçeneği
                    //Belki ilerde farklı formatlarda kaydetme seçeneği sunulabilir.
                }
                else if (this.filmKisiListesi.SelectedItems.Count == 1)
                {
                    //Secilen elemanı tek başına kaydedebiliriz.

                    dosyaKaydetDiyalokKutusu.Title = "Filmi Kaydet";
                    dosyaKaydetDiyalokKutusu.Filter = Sabitler.FilmografFilmDosyasi;

                    string dosyaAdi = "";
                    {
                        Film f = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[0].ImageKey);
                        if (f != null)
                            dosyaAdi = f.Ad;
                        else
                        {
                            Dizi dd = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[0].ImageKey);
                            if (dd != null)
                                dosyaAdi = dd.Ad;
                        }
                    }

                    dosyaKaydetDiyalokKutusu.FileName = dosyaAdi;
                    DialogResult d = dosyaKaydetDiyalokKutusu.ShowDialog();

                    if ((d == System.Windows.Forms.DialogResult.OK) && (dosyaKaydetDiyalokKutusu.FileName != ""))
                    {
                        FileStream f = null;
                        try
                        {
                            f = new FileStream(dosyaKaydetDiyalokKutusu.FileName,
                                                FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            BinaryFormatter b = new BinaryFormatter();

                            Film seciliFilm = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[0].ImageKey);
                            if (seciliFilm != null)
                            {
                                b.Serialize(f, seciliFilm);
                            }
                            else
                            {
                                Dizi seciliDizi = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[0].ImageKey);
                                if (seciliDizi != null)
                                    b.Serialize(f, seciliDizi);
                            }

                            f.Close();
                        }
                        catch (Exception hata)
                        {
                            if (f != null) f.Close();
                            MessageBox.Show("Hata oluştu: " + hata.Message, Sabitler.ProgramBasligi,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else if (this.filmKisiListesi.SelectedItems.Count > 1)
                {
                    //Seçilenler birden fazla ise tek başına kütüphane olarak kaydedebiliriz.

                    dosyaKaydetDiyalokKutusu.Title = "Seçilenleri Kütüphane Olarak Kaydet";
                    dosyaKaydetDiyalokKutusu.Filter = Sabitler.FilmografKutuphaneDosyasi;
                    dosyaKaydetDiyalokKutusu.FileName = "";
                    DialogResult d = dosyaKaydetDiyalokKutusu.ShowDialog();

                    if ((d == System.Windows.Forms.DialogResult.OK) && (dosyaKaydetDiyalokKutusu.FileName != ""))
                    {
                        FileStream f = null;
                        try
                        {
                            f = new FileStream(dosyaKaydetDiyalokKutusu.FileName,
                                                FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            BinaryFormatter b = new BinaryFormatter();

                            Kutuphane serilizeEdilecekKtp = new Kutuphane(dosyaKaydetDiyalokKutusu.FileName,
                                                                         dosyaninUzantisizAdi(dosyaKaydetDiyalokKutusu.FileName));

                            serilizeEdilecekKtp.IDVeritabani = this.kutuphane.IDVeritabani; //Kütüphane bilgileri de kaydedilmeli

                            List<Film> seciliFilmler = seciliFilmlerdenDondur();
                            foreach (Film film in seciliFilmler)
                                serilizeEdilecekKtp.filmEkle(film);

                            List<Dizi> seciliDiziler = this.seciliDiziler();
                            foreach (Dizi dizi in seciliDiziler)
                                serilizeEdilecekKtp.diziEkle(dizi);

                            if (serilizeEdilecekKtp.Filmler.Count > 0)
                            {
                                b.Serialize(f, serilizeEdilecekKtp);
                            }

                            f.Close();
                        }
                        catch (Exception hata)
                        {
                            if (f != null) f.Close();
                            MessageBox.Show("Hata oluştu: " + hata.Message, Sabitler.ProgramBasligi,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            else
            {
                if (this.filmKisiListesi.SelectedItems.Count == 0)
                {
                    //Farklı kaydet seçeneği
                    //Belki ilerde farklı formatlarda kaydetme seçeneği sunulabilir.
                }
                else if (this.filmKisiListesi.SelectedItems.Count == 1)
                {
                    //Secilen elemanı tek başına kaydedebiliriz.

                    dosyaKaydetDiyalokKutusu.Title = "Kişiyi Kaydet";
                    dosyaKaydetDiyalokKutusu.Filter = Sabitler.FilmografKisiDosyasi;
                    dosyaKaydetDiyalokKutusu.FileName = "";
                    DialogResult d = dosyaKaydetDiyalokKutusu.ShowDialog();

                    if ((d == System.Windows.Forms.DialogResult.OK) && (dosyaKaydetDiyalokKutusu.FileName != ""))
                    {
                        FileStream f = null;
                        try
                        {
                            f = new FileStream(dosyaKaydetDiyalokKutusu.FileName,
                                                FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            BinaryFormatter b = new BinaryFormatter();

                            Kisi seciliKisi = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[0].ImageKey);
                            if (seciliKisi != null)
                            {
                                b.Serialize(f, seciliKisi);
                            }

                            f.Close();
                        }
                        catch (Exception hata)
                        {
                            if (f != null) f.Close();
                            MessageBox.Show("Hata oluştu: " + hata.Message, Sabitler.ProgramBasligi,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else if (this.filmKisiListesi.SelectedItems.Count > 1)
                {
                    //Seçilenler birden fazla ise tek başına kütüphane olarak kaydedebiliriz.

                    dosyaKaydetDiyalokKutusu.Title = "Seçilenleri Kaydet";
                    dosyaKaydetDiyalokKutusu.Filter = Sabitler.FilmografCokluKisiDosyasi;
                    dosyaKaydetDiyalokKutusu.FileName = "";
                    DialogResult d = dosyaKaydetDiyalokKutusu.ShowDialog();

                    if ((d == System.Windows.Forms.DialogResult.OK) && (dosyaKaydetDiyalokKutusu.FileName != ""))
                    {
                        FileStream f = null;
                        try
                        {
                            f = new FileStream(dosyaKaydetDiyalokKutusu.FileName,
                                                FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            BinaryFormatter b = new BinaryFormatter();

                            List<Kisi> seciliKisiler = seciliKisilerdenDondur();

                            if ((seciliKisiler != null) && (seciliKisiler.Count > 0))
                            {
                                b.Serialize(f, seciliKisiler);
                            }

                            f.Close();
                        }
                        catch (Exception hata)
                        {
                            if (f != null) f.Close();
                            MessageBox.Show("Hata oluştu: " + hata.Message, Sabitler.ProgramBasligi,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void dosyadanKutuphaneyeFilmEkle()
        {
            dosyaAcDiyalokKutusu.Title = "Dosyadan Film Ekle";
            dosyaAcDiyalokKutusu.Multiselect = true;
            dosyaAcDiyalokKutusu.Filter = Sabitler.FilmografFilmDosyasi + "|" + Sabitler.FilmografKutuphaneDosyasi;
            dosyaAcDiyalokKutusu.FileName = "";
            DialogResult d = dosyaAcDiyalokKutusu.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                if (dosyaAcDiyalokKutusu.FileNames.Length <= 0) return;

                List<Film> acilanFilmler = new List<Film>();
                List<Dizi> acilanDiziler = new List<Dizi>();

                foreach (string dosya in dosyaAcDiyalokKutusu.FileNames)
                {
                    FileInfo acilanDosya = new FileInfo(dosya);
                    FileStream f = null;
                    try
                    {
                        f = new FileStream(dosya, FileMode.Open, FileAccess.Read);
                        BinaryFormatter b = new BinaryFormatter();

                        if (acilanDosya.Extension == ".ffd")
                        {
                            Film eklenenFilm = (Film)b.Deserialize(f);
                            if (eklenenFilm != null)
                                acilanFilmler.Add(eklenenFilm);

                            Dizi eklenenDizi = (Dizi)b.Deserialize(f);
                            if (eklenenDizi != null)
                                acilanDiziler.Add(eklenenDizi);
                        }
                        else if (acilanDosya.Extension == ".fkh")
                        {
                            Kutuphane eklenenKutuphane = (Kutuphane)b.Deserialize(f);

                            f_KutuphaneGoruntusu yenikutuphanegoruntusu = new f_KutuphaneGoruntusu();
                            yenikutuphanegoruntusu.EklenecekKutuphane = eklenenKutuphane;
                            yenikutuphanegoruntusu.AnaKutuphane = this.kutuphane;

                            DialogResult dKutEkleme = yenikutuphanegoruntusu.ShowDialog();

                            if (dKutEkleme == System.Windows.Forms.DialogResult.OK)
                            {
                                yenile();
                            }
                        }

                        f.Close();
                    }
                    catch (Exception hata)
                    {
                        if (f != null) f.Close();
                        MessageBox.Show("Hata oluştu: " + hata.Message, Sabitler.ProgramBasligi,
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (acilanFilmler.Count + acilanDiziler.Count == 0) return;

                f_FilmlerListesi yeniFilmler = new f_FilmlerListesi(this.kutuphane, acilanFilmler, acilanDiziler);

                DialogResult dia = yeniFilmler.ShowDialog();

                if (dia == System.Windows.Forms.DialogResult.OK)
                {
                    yenile();
                }
            }
        }
        private void dosyadanKutuphaneyeKisiEkle()
        {
            dosyaAcDiyalokKutusu.Title = "Dosyadan Kişi Ekle";
            dosyaAcDiyalokKutusu.Multiselect = true;
            dosyaAcDiyalokKutusu.Filter = Sabitler.FilmografKisiDosyasi + "|" + Sabitler.FilmografCokluKisiDosyasi;
            dosyaAcDiyalokKutusu.FileName = "";
            DialogResult d = dosyaAcDiyalokKutusu.ShowDialog();

            if (d == System.Windows.Forms.DialogResult.OK)
            {
                List<Kisi> acilanKisiler = new List<Kisi>();

                foreach (string dosya in dosyaAcDiyalokKutusu.FileNames)
                {
                    FileInfo yeniDosya = new FileInfo(dosya);
                    FileStream f = null;
                    try
                    {
                        f = new FileStream(dosya, FileMode.Open, FileAccess.Read);
                        BinaryFormatter b = new BinaryFormatter();
                        if (yeniDosya.Extension == ".fkd")
                        {
                            Kisi eklenenKisi = (Kisi)b.Deserialize(f);
                            if (eklenenKisi != null)
                                acilanKisiler.Add(eklenenKisi);

                        }
                        if (yeniDosya.Extension == ".fckd")
                        {
                            f_KisilerGoruntusu yeniKi = new f_KisilerGoruntusu();
                            yeniKi.AnaKutuphane = this.kutuphane;
                            yeniKi.Kisiler = (List<Kisi>)b.Deserialize(f);

                            yeniKi.ShowDialog();
                        }

                        f.Close();
                    }
                    catch (Exception hata)
                    {
                        if (f != null) f.Close();
                        MessageBox.Show("Hata oluştu: " + hata.Message, Sabitler.ProgramBasligi,
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }

                if (acilanKisiler.Count > 0)
                {
                    f_KisilerGoruntusu yeniKi = new f_KisilerGoruntusu();
                    yeniKi.AnaKutuphane = this.kutuphane;
                    yeniKi.Kisiler = acilanKisiler;
                    yeniKi.ShowDialog();
                }
                yenile();
            }
        }
        private void kutuphaneyiKapatKardes()
        {
            if (this.kutuphane != null)
            this.kutuphane.Dispose();

            this.kutuphane = null;
            this.Text = Sabitler.ProgramBasligi;
            kutuphaneYok();
            yenile();
            if (this.olusturulanResimler.Count > 0)
            {
                foreach (string resim in this.olusturulanResimler.ToArray())
                {
                    if (File.Exists(resim)) File.Delete(resim);
                }
            }
        }
        private void secilenKisileriSil()
        {
            //Kişileri siliyoruz

            if (gorunumModu == true)
            {
                return;
            }
            else
            {
                DialogResult soru;

                soru = MessageBox.Show("Seçtiğin kişileri silmek istediğine emin misin? İyice düşündün Inşallah? ", Sabitler.ProgramBasligi,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (soru == System.Windows.Forms.DialogResult.Yes)
                {

                    if ((this.kutuphane != null) && (this.kutuphane.Kisiler.Count > 0) && (this.filmKisiListesi.Items.Count > 0)
                            && (this.filmKisiListesi.SelectedItems.Count > 0))
                    {
                        List<Kisi> seciliKisiler = new List<Kisi>();

                        for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
                        {
                            Kisi f = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                            if (f != null)
                                seciliKisiler.Add(f);
                        }

                        this.kutuphane.kisileriSil(seciliKisiler);

                        yenile();
                    }
                }
                else
                {
                }
            }
        }
        private void secilenFilmleriSil()
        {
            //Filmleri siliyoruz

            if (this.kutuphane == null) return;

            if (gorunumModu == false)
            {
                return;
            }
            else
            {
                DialogResult soru;

                soru = MessageBox.Show("Seçtiğiniz filmleri silmek istediğine emin misin? İyice düşündün İnşallah? ", Sabitler.ProgramBasligi,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (soru == System.Windows.Forms.DialogResult.Yes)
                {

                    if (((this.kutuphane.Filmler.Count > 0) || (this.kutuphane.Diziler.Count>0)) && (this.filmKisiListesi.SelectedItems.Count > 0))
                    {
                        List<Film> seciliFilmler = new List<Film>();
                        List<Dizi> seciliDiziler = new List<Dizi>();

                        for (int i = 0; i < this.filmKisiListesi.SelectedItems.Count; i++)
                        {
                            Film f = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[i].ImageKey);
                            if (f != null)
                            {
                                seciliFilmler.Add(f);
                            }
                            else
                            {
                                Dizi d = this.kutuphane.kutuphanedekiDizi(this.filmKisiListesi.SelectedItems[i].ImageKey);
                                if (d != null)
                                    seciliDiziler.Add(d);
                            }
                        }

                        if (seciliFilmler.Count > 0)
                           this.kutuphane.baziFilmleriSil(seciliFilmler);

                        if (seciliDiziler.Count > 0)
                            this.kutuphane.baziDizileriSil(seciliDiziler);

                        yenile();
                    }
                }
                else
                {
                }
            }
        }
        private string birlestir(List<string> liste, string birlestirici, int maxKel)
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
        //private void ciciGosteriver()
        //{
        //    if (this.kutuphane == null) return;

        //    if ((gorunumModu == true) && (this.filmKisiListesi.SelectedItems.Count == 1))
        //    {
        //        #region Film Göster
        //        Film film = this.kutuphane.kutuphanedekiFilm(this.filmKisiListesi.SelectedItems[0].ImageKey);

        //        if (film != null)
        //        {
        //            string sayfa = "";
        //            try
        //            {
        //                sayfa = global::Filmograf.Properties.Resources.FilmHtmlMetni.ToString();
        //            }
        //            catch (Exception hata)
        //            {
        //                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }

        //            if (sayfa == "") return;

        //            try
        //            {
        //                film.Afis.Save(Application.StartupPath + film.ImdbID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //                if (!olusturulanResimler.Contains(Application.StartupPath + film.ImdbID + ".jpg"))
        //                    olusturulanResimler.Add(Application.StartupPath + film.ImdbID + ".jpg");
        //                sayfa = sayfa.Replace("{filmAfisi}", Application.StartupPath + film.ImdbID + ".jpg");
        //            }
        //            catch (Exception)
        //            {
        //            }

        //            sayfa = sayfa.Replace("{baslik}", film.Ad.Trim() + " (" + film.CikisTarihi + ")");
        //            sayfa = sayfa.Replace("{filmAdi}", film.Ad.Trim());

        //            string anahKel = ""; int maxAnahKel = 0;
        //            List<string> turler = new List<string>();
                    
        //            turler = StaticFonksiyonlar.turler();
        //            if (turler == null)
        //            {
        //                //turlerin alımında hata olmuştur.
        //                turler = new List<string>();
        //            }

        //            if (film.Turler.Count > 1)
        //            {
        //                foreach (string s in film.Turler.ToArray())
        //                {
        //                    anahKel += turler[maxAnahKel] + " | ";
        //                    maxAnahKel++;
        //                    if (maxAnahKel == 3) break;
        //                }
        //                anahKel = anahKel.Remove(anahKel.LastIndexOf('|'), 1);
        //            }
        //            else if (turler.Count == 1)
        //            {
        //                anahKel = turler[Convert.ToInt32(film.Turler[0])];
        //            }
        //            else
        //            {
        //                anahKel = "";
        //            }
        //            sayfa = sayfa.Replace("{turler}", anahKel.Trim());

        //            sayfa = sayfa.Replace("{cikisYili}", " (" + film.CikisTarihi + ")");
        //            sayfa = sayfa.Replace("{imdbID}", film.ImdbID.Trim());
        //            sayfa = sayfa.Replace("{imdbPuani}", film.ImdbPuani.Trim());

        //            List<string> yonetmenAdlari = this.kutuphane.filmdekiKisilerinAdlari(film, (int)KisiUnvani.Yonetmen, true);
        //            sayfa = sayfa.Replace("{yonetmenler}", yonetmenAdlari.Count > 0 ? yonetmenAdlari[0].Trim() : "");

        //            List<string> yazarAdlari = this.kutuphane.filmdekiKisilerinAdlari(film, (int)KisiUnvani.Yazar, true);
        //            sayfa = sayfa.Replace("{yazarlar}", yazarAdlari.Count > 0 ? yazarAdlari[0].Trim() : "");

        //            List<string> yildizAdlari = this.kutuphane.filmdekiKisilerinAdlari(film, (int)KisiUnvani.Oyuncu, true);
        //            sayfa = sayfa.Replace("{yildizlar}", yildizAdlari.Count > 0 ? yildizAdlari[0].Trim() : "");

        //            string kadro = "";
        //            string taslak = "";
        //            string tumKadro = "";

        //            try
        //            {
        //                taslak = kadro = global::Filmograf.Properties.Resources.OyuncuKadrosuMetni.ToString();


        //                int maxKadroSayisi = 0;

        //                foreach (FilmKarakteri o in film.Karakterler.ToArray())
        //                {
        //                    kadro = taslak;
        //                    tumKadro += kadro.Replace("{oyuncuAdi}", this.kutuphane.kutuphanedekiKisi(o.oyuncuID).Isim.Trim())
        //                                     .Replace("{karakterAdi}", o.karakterAdlariBirlesik(" / ").Trim());
        //                    maxKadroSayisi++;
        //                    if (maxKadroSayisi == 10) break;
        //                }
        //            }
        //            catch (Exception hata)
        //            {
        //                MessageBox.Show(hata.Message, "MMC Filmograf", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }

        //            if (kadro == "")
        //            {
        //                sayfa = sayfa.Replace("{oyuncuAdi}", "");
        //                sayfa = sayfa.Replace("{karakterAdi}", "");
        //            }
        //            else
        //            {
        //                sayfa = sayfa.Replace(taslak, tumKadro);
        //            }

        //            sayfa = sayfa.Replace("{anahtarKelimeler}", birlestir(film.AnahtarKelimeler, " | ", 4).Trim());

        //            sayfa = sayfa.Replace("{olayOrgusu}", film.Ozetler[0].Trim());

        //            sayfa = sayfa.Replace("{resmiSiteler}", birlestir(film.WebSayfalari, " | ", 4).Trim());

        //            sayfa = sayfa.Replace("{ulke}", birlestir(film.Ulkeler, " | ", 4).Trim());
        //            sayfa = sayfa.Replace("{dil}", birlestir(film.Diller, " | ", 4).Trim());
        //            sayfa = sayfa.Replace("{cikisTarihi}", film.CikisTarihi.Trim());
        //            sayfa = sayfa.Replace("{baskaIsim}", birlestir(film.DigerAdlariSadeceMetin, " | ", 4).Trim());
        //            sayfa = sayfa.Replace("{filmCekimYerleri}", birlestir(film.Ulkeler, " | ", 1).Trim());
        //            sayfa = sayfa.Replace("{butce}", film.Butce.Trim());

        //            this.filmCiciGosterici.DocumentText = sayfa;
        //        } 
        //        #endregion
        //    }
        //    else if ((gorunumModu == false) && (this.filmKisiListesi.SelectedItems.Count == 1))
        //    {
        //        #region Kişi göster

        //        Kisi kisi = this.kutuphane.kutuphanedekiKisi(this.filmKisiListesi.SelectedItems[0].ImageKey);

        //        if (kisi != null)
        //        {
        //            string sayfa = "";
        //            try
        //            {
        //                sayfa = global::Filmograf.Properties.Resources.KisiHtmlMetni.ToString();
        //            }
        //            catch (Exception hata)
        //            {
        //                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }

        //            if (sayfa == "") return;
                    
        //            try
        //            {
        //                kisi.Resim.Save(Application.StartupPath + kisi.ImdbID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //                if (!olusturulanResimler.Contains(Application.StartupPath + kisi.ImdbID + ".jpg"))
        //                    olusturulanResimler.Add(Application.StartupPath + kisi.ImdbID + ".jpg");
        //                sayfa = sayfa.Replace("{kisiResmi}", Application.StartupPath + kisi.ImdbID + ".jpg");
        //            }
        //            catch (Exception)
        //            {
        //            }

        //            sayfa = sayfa.Replace("{baslik}", kisi.Isim.Trim());
        //            sayfa = sayfa.Replace("{kisiAdi}", kisi.Isim.Trim());
        //            sayfa = sayfa.Replace("{imdbID}", kisi.ImdbID.Trim());
        //            sayfa = sayfa.Replace("{dogumTarihi}", kisi.DogumTarihi);
        //            sayfa = sayfa.Replace("{dogumYeri}", kisi.DogumYeri.Trim());
        //            sayfa = sayfa.Replace("{boyUzunlugu}", kisi.BoyUzunlugu.Trim());

        //            string anahKel = ""; int maxAnahKel = 0;

        //            string kadro = "";
        //            string taslak = "";
        //            string tumKadro = "";

        //            try
        //            {
        //                taslak = kadro = global::Filmograf.Properties.Resources.OynadigiFilmMetni.ToString();

        //                int maxKadroSayisi = 0;
        //                List<Film> filmler = this.kutuphane.kisininKutuphanedekiFilmleri(kisi);
        //                if (filmler != null)
        //                {
        //                    foreach (Film f in filmler.ToArray())
        //                    {
        //                        kadro = taslak;
        //                        List<string> karakterAdlari = this.kutuphane.kisininFilmindekiKarakterAdlari(kisi, f);
        //                        if (karakterAdlari == null)
        //                        {
        //                            continue;
        //                        }
        //                        foreach (string karakterAdi in karakterAdlari.ToArray())
        //                        {
        //                            tumKadro += kadro.Replace("{filmAdi}", f.Ad + " (" + f.CikisTarihi + ")")
        //                                .Replace("{karakterAdi}", karakterAdi.Trim());
        //                        }
        //                        maxKadroSayisi++;
        //                        if (maxKadroSayisi == 10) break;
        //                    }
        //                }
        //            }
        //            catch (Exception hata)
        //            {
        //                MessageBox.Show(hata.Message, Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            }

        //            if (tumKadro == "")
        //            {
        //                sayfa = sayfa.Replace("{filmAdi}", "");
        //                sayfa = sayfa.Replace("{karakterAdi}", "");
        //            }
        //            else
        //            {
        //                sayfa = sayfa.Replace(taslak, tumKadro);
        //            }


        //            sayfa = sayfa.Replace("{ozGecmisi}", kisi.Biyografi.Trim());
        //            sayfa = sayfa.Replace("{resmiWebSayfalari}", birlestir(kisi.ResmiWebSayfalari, " |", 4).Trim());

        //            this.filmCiciGosterici.DocumentText = sayfa;
        //        }
        //        #endregion
        //    }
        //}
        private void istatistiklerFormunuGoster()
        {
            f_Istatistikler yeni = new f_Istatistikler(this.kutuphane);
            yeni.Show();
        }
        #endregion

        #region Film/Kişi Listesi

        private void filmKisiListesi_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            filmKisiDuzenle();
        }
        private void filmKisiListesi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void filmKisiListesiMenusu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.filmKisiListesiMenusu.Enabled = !(this.kutuphane == null);
            this.yenileToolStripMenuItem.Enabled = !(this.kutuphane == null);
            this.ciciGösterToolStripMenuItem.Enabled = this.filmKisiListesi.SelectedItems.Count == 1;
            this.kesToolStripMenuItem1.Enabled = this.filmKisiListesi.SelectedItems.Count > 0;
            this.kopyalaToolStripMenuItem1.Enabled = this.filmKisiListesi.SelectedItems.Count > 0;
            this.silToolStripMenuItem2.Enabled = this.filmKisiListesi.SelectedItems.Count > 0;
            this.yapıştırToolStripMenuItem.Enabled = (this.filmKisiListesi.SelectedItems.Count == 0) &&
                (Clipboard.ContainsData("List<Kisi>") | Clipboard.ContainsData("List<Film>"));
            this.düzenleToolStripMenuItem2.Enabled = this.filmKisiListesi.SelectedItems.Count == 1;
            this.farklıKaydetToolStripMenuItem.Enabled = this.filmKisiListesi.SelectedItems.Count > 0;
            this.bilgileriGüncelleToolStripMenuItem.Enabled = this.filmKisiListesi.SelectedItems.Count > 0;
        }
        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yenile();
        }
        private void düzenleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            filmKisiDuzenle();
        }
        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            farkliKaydet();
        }
        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kes();
        }
        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kopyala();
        }
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yapistir();
        }
        private void silToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (gorunumModu == false)
                secilenKisileriSil();
            else
                secilenFilmleriSil();
        }
        private void ciciGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void filmKisiListesi_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.kutuphane == null) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                ListViewItem secilen = this.filmKisiListesi.GetItemAt(e.X, e.Y);
                if ( secilen == null ) return;
                secilen.Selected = true;
                secilen.Selected = false;
            }
        }

        #endregion

        void istatistikleriGoster_Click(object sender, System.EventArgs e)
        {
            istatistiklerFormunuGoster();
        }

        #region Film Dizi Bilgisi Güncelleme (OLAY SIRASINA GÖRE SIRALI)
        private void bilgileriGuncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bilgileri güncellemek istediğinize emin misiniz? Eski bilgiler silinecek!", Sabitler.ProgramBasligi,
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == System.Windows.Forms.DialogResult.No) return;

            indirilecekBasliklar = new List<string>();
            indirilirkenOlusanHatalar = new List<Exception>();
            filmler = new List<Film>();
            diziler = new List<Dizi>();
            kisiler = new List<Kisi>();
            gelenKeyIsimler = new SortedDictionary<string, string>();

            foreach (ListViewItem secilen in this.filmKisiListesi.SelectedItems)
            {
                indirilecekBasliklar.Add(secilen.ImageKey);
            }

            AracCubugu.Enabled = false;
            this.filmKisiListesi.Enabled = false;
            tspIlerlemeCubugu.Visible = true;

            arkaPlanCalistirici.RunWorkerAsync();
        }
        private void arkaPlanCalistirici_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            siraliIndirme();
        }
        private void siraliIndirme()
        {
            IMDB yeni = new IMDB();
            yeni.intIlerlemeYuzdesi = this.ilerleyici;
            yeni.stringIlerlemeKonumu = this.stringDegistirici;
            yeni.islemYapilanBaslikID = this.baslikDegisti;

            foreach (string baslik in indirilecekBasliklar)
            {
                try
                {
                    yeni.indir(baslik);
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show("İnternet bağlantınızda sorun var. Bağlantınız olduğundan emin olduktan sonra tekrar deneyin.",
                                                Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (gelenKeyIsimler.Count > 0)
                {
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

        }
        private void arkaPlanCalistirici_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            filmEklemeTumIlerleme();
            
            AracCubugu.Enabled = true;
            this.filmKisiListesi.Enabled = true;
            this.filmKisiListesi.Font = new System.Drawing.Font("Microsoft YaHei", 10, System.Drawing.FontStyle.Regular);
            tspIlerlemeCubugu.Visible = false;
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
            }

            MessageBox.Show((this.diziler.Count + this.filmler.Count + this.kisiler.Count).ToString() + " adet başlık güncellendi", Sabitler.ProgramBasligi,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (indirilirkenOlusanHatalar.Count > 0)
            {
                DialogResult hatalar = MessageBox.Show("Hatalar oluştu", Sabitler.ProgramBasligi, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (hatalar == System.Windows.Forms.DialogResult.OK)
                {
                    f_HataGosterici hatalariGoster = new f_HataGosterici();
                    hatalariGoster.Hatalar = indirilirkenOlusanHatalar;
                    hatalariGoster.ShowDialog();
                }
            }
        }
        #endregion
    }
}
