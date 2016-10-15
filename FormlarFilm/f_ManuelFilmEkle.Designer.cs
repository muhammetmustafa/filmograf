namespace Filmograf
{
    partial class f_ManuelFilmEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();

                foreach (System.Windows.Forms.Control c in this.Controls)
                {
                    if (c != null)
                    {
                        if (!c.IsDisposed)
                            c.Dispose();
                    }
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ManuelFilmEkle));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tDetaylar = new System.Windows.Forms.TabPage();
            this.gDil = new System.Windows.Forms.GroupBox();
            this.fwpDiller = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsLinkSaklayici = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tstxtLinkDuzenle = new System.Windows.Forms.ToolStripTextBox();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDilEkle = new System.Windows.Forms.Button();
            this.cmbDil = new System.Windows.Forms.ComboBox();
            this.btnDilSil = new System.Windows.Forms.Button();
            this.gUlke = new System.Windows.Forms.GroupBox();
            this.fwpUlkeler = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbUlke = new System.Windows.Forms.ComboBox();
            this.btnUlkeEkle = new System.Windows.Forms.Button();
            this.btnUlkeSil = new System.Windows.Forms.Button();
            this.gBaskaIsimler = new System.Windows.Forms.GroupBox();
            this.dgvIsimUlke = new System.Windows.Forms.DataGridView();
            this.Isim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ulke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gResmiWebSayfalari = new System.Windows.Forms.GroupBox();
            this.flpLinkTutucu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWebSayfasiEkle = new System.Windows.Forms.Button();
            this.txtWebSayfasi = new System.Windows.Forms.TextBox();
            this.tDigerBilgiler = new System.Windows.Forms.TabPage();
            this.gSirketler = new System.Windows.Forms.GroupBox();
            this.tvSirketler = new System.Windows.Forms.TreeView();
            this.gAnahtarKelimeler = new System.Windows.Forms.GroupBox();
            this.lbAnahtarKelimeler = new System.Windows.Forms.ListBox();
            this.btnAnahtarKelimeSil = new System.Windows.Forms.Button();
            this.btnAnahtarKelimeEkle = new System.Windows.Forms.Button();
            this.btnTumAnahtarKelimeleriSil = new System.Windows.Forms.Button();
            this.btnDosyadanAnahtarKelimelerAl = new System.Windows.Forms.Button();
            this.gFilmCekimYerleri = new System.Windows.Forms.GroupBox();
            this.lbFilmCekimYerleri = new System.Windows.Forms.ListBox();
            this.txtFilmCekimYeri = new System.Windows.Forms.TextBox();
            this.btnFilmCekimYeriEkle = new System.Windows.Forms.Button();
            this.tKadro = new System.Windows.Forms.TabPage();
            this.gOyuncuKadrosu = new System.Windows.Forms.GroupBox();
            this.oyuncuKadrosu = new System.Windows.Forms.DataGridView();
            this.Vesikalik = new System.Windows.Forms.DataGridViewImageColumn();
            this.OyuncuAdi = new System.Windows.Forms.DataGridViewLinkColumn();
            this.KarakterAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imdbIDSutunu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOyuncuSil = new System.Windows.Forms.Button();
            this.btnYeniOyuncu = new System.Windows.Forms.Button();
            this.btnSeceneklerOyunK = new System.Windows.Forms.Button();
            this.gYazarlar = new System.Windows.Forms.GroupBox();
            this.lvYazarlar = new System.Windows.Forms.ListView();
            this.kisiResimleri = new System.Windows.Forms.ImageList(this.components);
            this.btnYazarSil = new System.Windows.Forms.Button();
            this.btnSeceneklerYazK = new System.Windows.Forms.Button();
            this.btnYeniYazar = new System.Windows.Forms.Button();
            this.gYonetmenler = new System.Windows.Forms.GroupBox();
            this.lvYonetmenler = new System.Windows.Forms.ListView();
            this.btnYonetmenSil = new System.Windows.Forms.Button();
            this.btnSeceneklerYonK = new System.Windows.Forms.Button();
            this.btnYeniYonetmen = new System.Windows.Forms.Button();
            this.tGenelBilgiler = new System.Windows.Forms.TabPage();
            this.gGenelBilgiler = new System.Windows.Forms.GroupBox();
            this.lButce = new System.Windows.Forms.Label();
            this.txtButce = new System.Windows.Forms.TextBox();
            this.txtOynadigiTarihler = new System.Windows.Forms.TextBox();
            this.lOynadigiTarihler = new System.Windows.Forms.Label();
            this.txtCikisTarihi = new System.Windows.Forms.TextBox();
            this.txtFilmSuresi = new System.Windows.Forms.TextBox();
            this.txtImdbPuani = new System.Windows.Forms.TextBox();
            this.txtImdbID = new System.Windows.Forms.TextBox();
            this.lOrnekImdbID = new System.Windows.Forms.Label();
            this.lIMDBPuani = new System.Windows.Forms.Label();
            this.lIMDBId = new System.Windows.Forms.Label();
            this.chlTurListesi = new System.Windows.Forms.CheckedListBox();
            this.lFilmTuru = new System.Windows.Forms.Label();
            this.lDakika = new System.Windows.Forms.Label();
            this.lFilmTarihi = new System.Windows.Forms.Label();
            this.lCikisTarihi = new System.Windows.Forms.Label();
            this.lFilmAdi = new System.Windows.Forms.Label();
            this.txtFilmAdi = new System.Windows.Forms.TextBox();
            this.pFilmAfisi = new System.Windows.Forms.PictureBox();
            this.filmAyarlari = new System.Windows.Forms.TabControl();
            this.tDigerKisiler = new System.Windows.Forms.TabPage();
            this.gDüzenle = new System.Windows.Forms.GroupBox();
            this.gBilgiler = new System.Windows.Forms.GroupBox();
            this.lGorevDurumu = new System.Windows.Forms.Label();
            this.lGorevAciklama = new System.Windows.Forms.Label();
            this.lID = new System.Windows.Forms.Label();
            this.lIsim = new System.Windows.Forms.Label();
            this.lGosterKutuphaneDurumu = new System.Windows.Forms.Label();
            this.lGosterGorevAciklama = new System.Windows.Forms.Label();
            this.lGosterID = new System.Windows.Forms.Label();
            this.lGosterIsim = new System.Windows.Forms.Label();
            this.lGosterDepartmanGorev = new System.Windows.Forms.Label();
            this.lDepartmanGorev = new System.Windows.Forms.Label();
            this.tvOyuncuKadrosu = new System.Windows.Forms.TreeView();
            this.tOduller = new System.Windows.Forms.TabPage();
            this.gDuzenle = new System.Windows.Forms.GroupBox();
            this.gDurum = new System.Windows.Forms.GroupBox();
            this.lAlanKisi = new System.Windows.Forms.Label();
            this.lKategori = new System.Windows.Forms.Label();
            this.lSonuc = new System.Windows.Forms.Label();
            this.lYil = new System.Windows.Forms.Label();
            this.lGosterAlanKisi = new System.Windows.Forms.Label();
            this.lGosterKategori = new System.Windows.Forms.Label();
            this.lGosterSonuc = new System.Windows.Forms.Label();
            this.lGosterYil = new System.Windows.Forms.Label();
            this.lGosterOdulVerenKurum = new System.Windows.Forms.Label();
            this.lOdulVerenKurum = new System.Windows.Forms.Label();
            this.tvOduller = new System.Windows.Forms.TreeView();
            this.tEglencelik = new System.Windows.Forms.TabPage();
            this.tabEglencelik = new System.Windows.Forms.TabControl();
            this.tOlayOrgusu = new System.Windows.Forms.TabPage();
            this.btnOlayOrgusuSil = new System.Windows.Forms.Button();
            this.btnOlayOrgusuEkle = new System.Windows.Forms.Button();
            this.tReklamsalSozler = new System.Windows.Forms.TabPage();
            this.btnSloganSil = new System.Windows.Forms.Button();
            this.btnReklamSozuEkle = new System.Windows.Forms.Button();
            this.tCrazyCredits = new System.Windows.Forms.TabPage();
            this.btnGaripGercekSil = new System.Windows.Forms.Button();
            this.btnCrazyCreditEkle = new System.Windows.Forms.Button();
            this.tCekimGercegi = new System.Windows.Forms.TabPage();
            this.btnCekimGercegiSil = new System.Windows.Forms.Button();
            this.btnCekimGercegiEkle = new System.Windows.Forms.Button();
            this.tHatalar = new System.Windows.Forms.TabPage();
            this.btnHataSil = new System.Windows.Forms.Button();
            this.btnHataEkle = new System.Windows.Forms.Button();
            this.tReplikler = new System.Windows.Forms.TabPage();
            this.btnReplikSil = new System.Windows.Forms.Button();
            this.btnReplikEkle = new System.Windows.Forms.Button();
            this.tReferanslar = new System.Windows.Forms.TabPage();
            this.btnReferansSil = new System.Windows.Forms.Button();
            this.btnReferansEkle = new System.Windows.Forms.Button();
            this.tMuzikler = new System.Windows.Forms.TabPage();
            this.btnMuzikSil = new System.Windows.Forms.Button();
            this.btnMuzikEkle = new System.Windows.Forms.Button();
            this.tBolumler = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gBolumBilgileri = new System.Windows.Forms.GroupBox();
            this.rchtxtBolumOzeti = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBolumID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBolumCikisTarihi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBolumAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvBolumler = new System.Windows.Forms.ListView();
            this.lvSezonlar = new System.Windows.Forms.ListView();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.kisiEklemeMenusu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kütüphanedenEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llkOlayOrgusu = new Filmograf.listeLabelKontrolu();
            this.llkReklamsalSoz = new Filmograf.listeLabelKontrolu();
            this.llkGaripGercek = new Filmograf.listeLabelKontrolu();
            this.llkCekimGercegiGezinti = new Filmograf.listeLabelKontrolu();
            this.llkHatalarGezgini = new Filmograf.listeLabelKontrolu();
            this.llkRepliklerGezgini = new Filmograf.listeLabelKontrolu();
            this.llkReferansGezici = new Filmograf.listeLabelKontrolu();
            this.llkMuzikGezici = new Filmograf.listeLabelKontrolu();
            this.tDetaylar.SuspendLayout();
            this.gDil.SuspendLayout();
            this.cmsLinkSaklayici.SuspendLayout();
            this.gUlke.SuspendLayout();
            this.gBaskaIsimler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIsimUlke)).BeginInit();
            this.gResmiWebSayfalari.SuspendLayout();
            this.tDigerBilgiler.SuspendLayout();
            this.gSirketler.SuspendLayout();
            this.gAnahtarKelimeler.SuspendLayout();
            this.gFilmCekimYerleri.SuspendLayout();
            this.tKadro.SuspendLayout();
            this.gOyuncuKadrosu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oyuncuKadrosu)).BeginInit();
            this.gYazarlar.SuspendLayout();
            this.gYonetmenler.SuspendLayout();
            this.tGenelBilgiler.SuspendLayout();
            this.gGenelBilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFilmAfisi)).BeginInit();
            this.filmAyarlari.SuspendLayout();
            this.tDigerKisiler.SuspendLayout();
            this.gBilgiler.SuspendLayout();
            this.tOduller.SuspendLayout();
            this.gDurum.SuspendLayout();
            this.tEglencelik.SuspendLayout();
            this.tabEglencelik.SuspendLayout();
            this.tOlayOrgusu.SuspendLayout();
            this.tReklamsalSozler.SuspendLayout();
            this.tCrazyCredits.SuspendLayout();
            this.tCekimGercegi.SuspendLayout();
            this.tHatalar.SuspendLayout();
            this.tReplikler.SuspendLayout();
            this.tReferanslar.SuspendLayout();
            this.tMuzikler.SuspendLayout();
            this.tBolumler.SuspendLayout();
            this.gBolumBilgileri.SuspendLayout();
            this.kisiEklemeMenusu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEkle
            // 
            this.btnEkle.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEkle.Location = new System.Drawing.Point(598, 371);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 1;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.Tamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(679, 371);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "Çıkış";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 402);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tDetaylar
            // 
            this.tDetaylar.BackColor = System.Drawing.Color.Gainsboro;
            this.tDetaylar.Controls.Add(this.gDil);
            this.tDetaylar.Controls.Add(this.gUlke);
            this.tDetaylar.Controls.Add(this.gBaskaIsimler);
            this.tDetaylar.Controls.Add(this.gResmiWebSayfalari);
            this.tDetaylar.Location = new System.Drawing.Point(4, 22);
            this.tDetaylar.Name = "tDetaylar";
            this.tDetaylar.Size = new System.Drawing.Size(746, 332);
            this.tDetaylar.TabIndex = 3;
            this.tDetaylar.Text = "Detaylar";
            // 
            // gDil
            // 
            this.gDil.Controls.Add(this.fwpDiller);
            this.gDil.Controls.Add(this.btnDilEkle);
            this.gDil.Controls.Add(this.cmbDil);
            this.gDil.Controls.Add(this.btnDilSil);
            this.gDil.Location = new System.Drawing.Point(425, 163);
            this.gDil.Name = "gDil";
            this.gDil.Size = new System.Drawing.Size(318, 162);
            this.gDil.TabIndex = 47;
            this.gDil.TabStop = false;
            this.gDil.Text = "Dil";
            // 
            // fwpDiller
            // 
            this.fwpDiller.AutoScroll = true;
            this.fwpDiller.ContextMenuStrip = this.cmsLinkSaklayici;
            this.fwpDiller.Location = new System.Drawing.Point(6, 46);
            this.fwpDiller.Name = "fwpDiller";
            this.fwpDiller.Size = new System.Drawing.Size(306, 110);
            this.fwpDiller.TabIndex = 30;
            // 
            // cmsLinkSaklayici
            // 
            this.cmsLinkSaklayici.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstxtLinkDuzenle,
            this.kaydetToolStripMenuItem,
            this.toolStripMenuItem1,
            this.silToolStripMenuItem});
            this.cmsLinkSaklayici.Name = "cmsLinkSaklayici";
            this.cmsLinkSaklayici.Size = new System.Drawing.Size(161, 79);
            this.cmsLinkSaklayici.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLinkSaklayici_Opening);
            // 
            // tstxtLinkDuzenle
            // 
            this.tstxtLinkDuzenle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstxtLinkDuzenle.Name = "tstxtLinkDuzenle";
            this.tstxtLinkDuzenle.Size = new System.Drawing.Size(100, 23);
            this.tstxtLinkDuzenle.ToolTipText = "Linki Düzenle";
            // 
            // kaydetToolStripMenuItem
            // 
            this.kaydetToolStripMenuItem.Name = "kaydetToolStripMenuItem";
            this.kaydetToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.kaydetToolStripMenuItem.Text = "Kaydet";
            this.kaydetToolStripMenuItem.Click += new System.EventHandler(this.kaydetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // btnDilEkle
            // 
            this.btnDilEkle.FlatAppearance.BorderSize = 0;
            this.btnDilEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDilEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnDilEkle.Image")));
            this.btnDilEkle.Location = new System.Drawing.Point(293, 19);
            this.btnDilEkle.Name = "btnDilEkle";
            this.btnDilEkle.Size = new System.Drawing.Size(19, 19);
            this.btnDilEkle.TabIndex = 49;
            this.btnDilEkle.UseVisualStyleBackColor = true;
            this.btnDilEkle.Click += new System.EventHandler(this.btnDilEkle_Click);
            // 
            // cmbDil
            // 
            this.cmbDil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDil.FormattingEnabled = true;
            this.cmbDil.Items.AddRange(new object[] {
            "Abanyom dili (Bantu dil ailesi)",
            "Abazaca",
            "Abhazca",
            "Adamorobe isaret dili (Isaret dili)",
            "Acarca",
            "Adigece",
            "Afrikaans",
            "Ahtnaca",
            "Almanca",
            "Altayca",
            "Amharca",
            "Aragonca",
            "Arberesce",
            "Aramice",
            "Aranese",
            "Arapca",
            "Arnavutca",
            "Asturyasca",
            "Asagi Tananaca",
            "Auvergnat dili",
            "Avarca",
            "Aymara dili",
            "Ayni dili",
            "Aynu dili",
            "Azerbaycanca",
            "Baskca",
            "Bantu",
            "Bati Apacicesi",
            "Bengalce",
            "Bretonca",
            "Beyaz Rusca",
            "Bosnakca",
            "Bulgarca",
            "Burgonyaca",
            "Buryatca",
            "Champenois",
            "Çecence",
            "Çekce",
            "Çilkotince",
            "Çince",
            "Çingene Dili",
            "Çukcice",
            "Çupikce",
            "Çuvasca",
            "Dakelce",
            "Danca",
            "Danezaca",
            "Dargince",
            "Dauphinois",
            "Deginakca",
            "Denaginaca",
            "Denesulinece",
            "Denetaca",
            "Dzongka",
            "Endonezyaca",
            "Ermenice",
            "Eski Ingilizce",
            "Eski Nors dili",
            "Estonca",
            "Eyakca",
            "Farsca",
            "Faroe dili",
            "Filipince",
            "Flamanca",
            "Frizce",
            "Fince",
            "Felemenkce",
            "Fransizca",
            "Gagavuzca",
            "Galce",
            "Galicyaca",
            "Gaskonca",
            "Gilanice",
            "Goranice",
            "Goktürkce",
            "Guarani",
            "Gucince",
            "Güney Pikence",
            "Hakasca",
            "Hakka",
            "Hanca (Atabask)",
            "Hausa",
            "Hirvatca",
            "Hikarilaca",
            "Hintce",
            "Holikacukca",
            "Hollandaca",
            "Hunca",
            "Hupaca",
            "Ibranice",
            "Ingilizce",
            "Iran dilleri",
            "Irlandaca",
            "Ingusca",
            "Inyupikce",
            "Iskoc dili",
            "Ispanyolca",
            "Isvecce",
            "Italyanca",
            "Izlandaca",
            "Japonca",
            "Kabardeyce",
            "Kalabriyaca",
            "Kalmikca",
            "Kannada dili",
            "Kurmanci",
            "Kantonca",
            "Kaskaca",
            "Karakalpakca",
            "Kartca",
            "Kasgayca",
            "Kanuri dili",
            "Katalanca",
            "Kazakca",
            "Kazan Tatarcasi",
            "Kernevekce",
            "Khmer",
            "Kirgizca",
            "Kirim Tatarcasi",
            "Korsikaca",
            "Koryakca",
            "Koyukonca",
            "Kuskokvimce",
            "Kuzey Tuconcasi",
            "Kürtce",
            "Kapa",
            "Ladino",
            "Lakca",
            "Latince",
            "Laponca",
            "Lehce",
            "Letonyaca",
            "Leonca",
            "Lezgice",
            "Limousin dili",
            "Lipanca",
            "Litvanyaca",
            "Lombardca",
            "Lorrain dili",
            "Lorraine Frankcasi",
            "Lüksemburgca",
            "Macarca",
            "Malay dili",
            "Maltaca",
            "Makedonca",
            "Mari dili",
            "Manca",
            "Mancuca",
            "Mandarin",
            "Maori",
            "Mapudungun",
            "Maya dili",
            "Megrelce",
            "Meskalero-Çirikavaca",
            "Miranda dili",
            "Mogolca",
            "Moldovca",
            "Nadoten-Vetsuvetence",
            "Napolice",
            "Naukan Yupikcesi",
            "Navahoca",
            "Nissart dili",
            "Normanca",
            "Norvecce",
            "Nunivak Çupikcesi",
            "Oksitanca",
            "Osetce",
            "Osmanli Türkcesi",
            "Ova Apacicesi",
            "Ozbekce",
            "Pali dili",
            "Papiamento",
            "Pecenekce",
            "Pestuca",
            "Picard dili",
            "Portekizce",
            "Polinezya",
            "Provensal",
            "Quechua",
            "Romans",
            "Rumca",
            "Rumence",
            "Rusca",
            "Saho",
            "Salarca",
            "Sanskritce",
            "Satuca",
            "Sekanice",
            "Sirpca",
            "Sibirya Yupikcesi",
            "Sicilyaca",
            "Sirenik Yupikcesi",
            "Slovakca",
            "Slovence",
            "Sorb dili",
            "Sorani",
            "Supikce",
            "Svanca",
            "Swahili",
            "Süryanice",
            "Sivandi",
            "Tacikce",
            "Tagisce",
            "Tahltanca",
            "Takalotca",
            "Tai",
            "Tamilce",
            "Tanakrosca",
            "Tatarca",
            "Tayvanca",
            "Telugu",
            "Tibetce",
            "Tlinconca",
            "Tlingitce",
            "Tsetsautca",
            "Tsutinaca",
            "Tswana",
            "Tupi",
            "Tuvaca",
            "Türkce",
            "Türkiye Türkcesi",
            "Türkmence",
            "Udmurtca",
            "Ukrayna dili",
            "Ulahca",
            "Urduca",
            "Uygurca",
            "Valensiyaca",
            "Venedikce",
            "Vietnamca",
            "Vikingce",
            "Yakutca",
            "Yidis",
            "Yukari Tananaca",
            "Yunanca",
            "Yupikce",
            "Zazaca",
            "Zentce",
            "Zhong Hua Yu Zi",
            "Zhuang",
            "Zhùyīn fúhào",
            "Zulu"});
            this.cmbDil.Location = new System.Drawing.Point(6, 19);
            this.cmbDil.Name = "cmbDil";
            this.cmbDil.Size = new System.Drawing.Size(281, 21);
            this.cmbDil.TabIndex = 42;
            // 
            // btnDilSil
            // 
            this.btnDilSil.FlatAppearance.BorderSize = 0;
            this.btnDilSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDilSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnDilSil.Location = new System.Drawing.Point(46, -1);
            this.btnDilSil.Name = "btnDilSil";
            this.btnDilSil.Size = new System.Drawing.Size(15, 14);
            this.btnDilSil.TabIndex = 40;
            this.btnDilSil.UseVisualStyleBackColor = true;
            this.btnDilSil.Click += new System.EventHandler(this.btnDilSil_Click);
            // 
            // gUlke
            // 
            this.gUlke.Controls.Add(this.fwpUlkeler);
            this.gUlke.Controls.Add(this.cmbUlke);
            this.gUlke.Controls.Add(this.btnUlkeEkle);
            this.gUlke.Controls.Add(this.btnUlkeSil);
            this.gUlke.Location = new System.Drawing.Point(425, 7);
            this.gUlke.Name = "gUlke";
            this.gUlke.Size = new System.Drawing.Size(318, 150);
            this.gUlke.TabIndex = 46;
            this.gUlke.TabStop = false;
            this.gUlke.Text = "Ülke";
            // 
            // fwpUlkeler
            // 
            this.fwpUlkeler.AutoScroll = true;
            this.fwpUlkeler.ContextMenuStrip = this.cmsLinkSaklayici;
            this.fwpUlkeler.Location = new System.Drawing.Point(6, 46);
            this.fwpUlkeler.Name = "fwpUlkeler";
            this.fwpUlkeler.Size = new System.Drawing.Size(306, 98);
            this.fwpUlkeler.TabIndex = 29;
            // 
            // cmbUlke
            // 
            this.cmbUlke.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUlke.FormattingEnabled = true;
            this.cmbUlke.Items.AddRange(new object[] {
            "Afganistan",
            "Almanya",
            "Amerikan Samoa",
            "Amerika Birleşik Devletleri",
            "Andorra",
            "Angola",
            "Anguilla, İngiltere",
            "Antigua ve Barbuda",
            "Arjantin",
            "Arnavutluk",
            "Aruba, Hollanda",
            "Avustralya",
            "Avusturya",
            "Azerbaycan",
            "Bahama Adaları",
            "Bahreyn",
            "Bangladeş",
            "Barbados",
            "Belçika",
            "Belize",
            "Benin",
            "Bermuda, İngiltere",
            "Beyaz Rusya",
            "Bhutan",
            "Birleşik Arap Emirlikleri",
            "Birmanya (Myanmar)",
            "Bolivya",
            "Bosna Hersek",
            "Botswana",
            "Brezilya",
            "Brunei",
            "Bulgaristan",
            "Burkina Faso",
            "Burundi",
            "Cape Verde",
            "Cayman Adaları, İngiltere",
            "Cebelitarık, İngiltere",
            "Cezayir",
            "Christmas Adası , Avusturalya",
            "Cibuti",
            "Çad",
            "Çek Cumhuriyeti",
            "Çin",
            "Danimarka",
            "Dominika",
            "Dominik Cumhuriyeti",
            "Ekvator",
            "Ekvator Ginesi",
            "El Salvador",
            "Endonezya",
            "Eritre",
            "Ermenistan",
            "Estonya",
            "Etiyopya",
            "Fas",
            "Fiji",
            "Fildişi Sahili",
            "Filipinler",
            "Filistin",
            "Finlandiya",
            "Folkland Adaları, İngiltere",
            "Fransa",
            "Fransız Guyanası",
            "Fransız Güney Eyaletleri (Kerguelen Adaları)",
            "Fransız Polinezyası",
            "Gabon",
            "Galler",
            "Gambiya",
            "Gana",
            "Gine",
            "Gine-Bissau",
            "Grenada",
            "Grönland",
            "Guadalup, Fransa",
            "Guam, Amerika",
            "Guatemala",
            "Guyana",
            "Güney Afrika",
            "Güney Georgia ve Güney Sandviç Adaları, İngiltere",
            "Güney Kıbrıs Rum Yönetimi",
            "Güney Kore",
            "Gürcistan",
            "Haiti",
            "Hırvatistan",
            "Hindistan",
            "Hollanda",
            "Hollanda Antilleri",
            "Honduras",
            "Irak",
            "İngiltere",
            "İran",
            "İrlanda",
            "İspanya",
            "İsrail",
            "İsveç",
            "İsviçre",
            "İtalya",
            "İzlanda",
            "Jamaika",
            "Japonya",
            "Johnston Atoll, Amerika",
            "Kamboçya",
            "Kamerun",
            "Kanada",
            "Kanarya Adaları",
            "Karadağ",
            "Katar",
            "Kazakistan",
            "Kenya",
            "Kırgızistan",
            "Kiribati",
            "Kolombiya",
            "Komorlar",
            "Kongo",
            "Kongo Demokratik Cumhuriyeti",
            "Kosova",
            "Kosta Rika",
            "Kuveyt",
            "Kuzey İrlanda",
            "Kuzey Kore",
            "Kuzey Maryana Adaları",
            "Küba",
            "K.K.T.C.",
            "Laos",
            "Lesotho",
            "Letonya",
            "Liberya",
            "Libya",
            "Liechtenstein",
            "Litvanya",
            "Lübnan",
            "Lüksemburg",
            "Macaristan",
            "Madagaskar",
            "Makau (Makao)",
            "Makedonya",
            "Malavi",
            "Maldiv Adaları",
            "Malezya",
            "Mali",
            "Malta",
            "Marşal Adaları",
            "Martinik, Fransa",
            "Mauritius",
            "Mayotte, Fransa",
            "Meksika",
            "Mısır",
            "Midway Adaları, Amerika",
            "Mikronezya",
            "Moğolistan",
            "Moldavya",
            "Monako",
            "Montserrat",
            "Moritanya",
            "Mozambik",
            "Namibia",
            "Nauru",
            "Nepal",
            "Nijer",
            "Nijerya",
            "Nikaragua",
            "Niue, Yeni Zelanda",
            "Norveç",
            "Orta Afrika Cumhuriyeti",
            "Özbekistan",
            "Pakistan",
            "Palau Adaları",
            "Palmyra Atoll, Amerika",
            "Panama",
            "Papua Yeni Gine",
            "Paraguay",
            "Peru",
            "Polonya",
            "Portekiz",
            "Porto Riko, Amerika",
            "Reunion, Fransa",
            "Romanya",
            "Ruanda",
            "Rusya Federasyonu",
            "Saint Helena, İngiltere",
            "Saint Martin, Fransa",
            "Saint Pierre ve Miquelon, Fransa",
            "Samoa",
            "San Marino",
            "Santa Kitts ve Nevis",
            "Santa Lucia",
            "Santa Vincent ve Grenadinler",
            "Sao Tome ve Principe",
            "Senegal",
            "Seyşeller",
            "Sırbistan",
            "Sierra Leone",
            "Singapur",
            "Slovakya",
            "Slovenya",
            "Solomon Adaları",
            "Somali",
            "Sri Lanka",
            "Sudan",
            "Surinam",
            "Suriye",
            "Suudi Arabistan",
            "Svalbard, Norveç",
            "Svaziland",
            "Şili",
            "Tacikistan",
            "Tanzanya",
            "Tayland",
            "Tayvan",
            "Togo",
            "Tonga",
            "Trinidad ve Tobago",
            "Tunus",
            "Turks ve Caicos Adaları, İngiltere",
            "Tuvalu",
            "Türkiye",
            "Türkmenistan",
            "Uganda",
            "Ukrayna",
            "Umman",
            "Uruguay",
            "Ürdün",
            "Vallis ve Futuna, Fransa",
            "Vanuatu",
            "Venezuela",
            "Vietnam",
            "Virgin Adaları, Amerika",
            "Virgin Adaları, İngiltere",
            "Wake Adaları, Amerika",
            "Yemen",
            "Yeni Kaledonya, Fransa",
            "Yeni Zelanda",
            "Yunanistan",
            "Zambiya",
            "Zimbabve"});
            this.cmbUlke.Location = new System.Drawing.Point(6, 19);
            this.cmbUlke.Name = "cmbUlke";
            this.cmbUlke.Size = new System.Drawing.Size(281, 21);
            this.cmbUlke.TabIndex = 41;
            // 
            // btnUlkeEkle
            // 
            this.btnUlkeEkle.FlatAppearance.BorderSize = 0;
            this.btnUlkeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUlkeEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnUlkeEkle.Image")));
            this.btnUlkeEkle.Location = new System.Drawing.Point(293, 19);
            this.btnUlkeEkle.Name = "btnUlkeEkle";
            this.btnUlkeEkle.Size = new System.Drawing.Size(19, 19);
            this.btnUlkeEkle.TabIndex = 48;
            this.btnUlkeEkle.UseVisualStyleBackColor = true;
            this.btnUlkeEkle.Click += new System.EventHandler(this.btnUlkeEkle_Click);
            // 
            // btnUlkeSil
            // 
            this.btnUlkeSil.FlatAppearance.BorderSize = 0;
            this.btnUlkeSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUlkeSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnUlkeSil.Location = new System.Drawing.Point(46, 0);
            this.btnUlkeSil.Name = "btnUlkeSil";
            this.btnUlkeSil.Size = new System.Drawing.Size(15, 14);
            this.btnUlkeSil.TabIndex = 40;
            this.btnUlkeSil.UseVisualStyleBackColor = true;
            this.btnUlkeSil.Click += new System.EventHandler(this.btnUlkeSil_Click);
            // 
            // gBaskaIsimler
            // 
            this.gBaskaIsimler.Controls.Add(this.dgvIsimUlke);
            this.gBaskaIsimler.Location = new System.Drawing.Point(8, 163);
            this.gBaskaIsimler.Name = "gBaskaIsimler";
            this.gBaskaIsimler.Size = new System.Drawing.Size(411, 162);
            this.gBaskaIsimler.TabIndex = 18;
            this.gBaskaIsimler.TabStop = false;
            this.gBaskaIsimler.Text = "Baska Isimler";
            // 
            // dgvIsimUlke
            // 
            this.dgvIsimUlke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIsimUlke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Isim,
            this.Ulke});
            this.dgvIsimUlke.Location = new System.Drawing.Point(6, 19);
            this.dgvIsimUlke.Name = "dgvIsimUlke";
            this.dgvIsimUlke.RowHeadersVisible = false;
            this.dgvIsimUlke.Size = new System.Drawing.Size(399, 137);
            this.dgvIsimUlke.TabIndex = 37;
            // 
            // Isim
            // 
            this.Isim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Isim.HeaderText = "İsim";
            this.Isim.Name = "Isim";
            // 
            // Ulke
            // 
            this.Ulke.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ulke.HeaderText = "Ülke";
            this.Ulke.Name = "Ulke";
            // 
            // gResmiWebSayfalari
            // 
            this.gResmiWebSayfalari.Controls.Add(this.flpLinkTutucu);
            this.gResmiWebSayfalari.Controls.Add(this.btnWebSayfasiEkle);
            this.gResmiWebSayfalari.Controls.Add(this.txtWebSayfasi);
            this.gResmiWebSayfalari.Location = new System.Drawing.Point(7, 6);
            this.gResmiWebSayfalari.Name = "gResmiWebSayfalari";
            this.gResmiWebSayfalari.Size = new System.Drawing.Size(412, 151);
            this.gResmiWebSayfalari.TabIndex = 15;
            this.gResmiWebSayfalari.TabStop = false;
            this.gResmiWebSayfalari.Text = "Resmi Web Sayfalari";
            // 
            // flpLinkTutucu
            // 
            this.flpLinkTutucu.AutoScroll = true;
            this.flpLinkTutucu.ContextMenuStrip = this.cmsLinkSaklayici;
            this.flpLinkTutucu.Location = new System.Drawing.Point(7, 45);
            this.flpLinkTutucu.Name = "flpLinkTutucu";
            this.flpLinkTutucu.Size = new System.Drawing.Size(399, 100);
            this.flpLinkTutucu.TabIndex = 28;
            // 
            // btnWebSayfasiEkle
            // 
            this.btnWebSayfasiEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWebSayfasiEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnWebSayfasiEkle.Image")));
            this.btnWebSayfasiEkle.Location = new System.Drawing.Point(387, 19);
            this.btnWebSayfasiEkle.Name = "btnWebSayfasiEkle";
            this.btnWebSayfasiEkle.Size = new System.Drawing.Size(19, 19);
            this.btnWebSayfasiEkle.TabIndex = 26;
            this.btnWebSayfasiEkle.UseVisualStyleBackColor = true;
            this.btnWebSayfasiEkle.Click += new System.EventHandler(this.resmiWebSayfalariEkle_Click);
            // 
            // txtWebSayfasi
            // 
            this.txtWebSayfasi.Location = new System.Drawing.Point(6, 19);
            this.txtWebSayfasi.Name = "txtWebSayfasi";
            this.txtWebSayfasi.Size = new System.Drawing.Size(375, 20);
            this.txtWebSayfasi.TabIndex = 25;
            // 
            // tDigerBilgiler
            // 
            this.tDigerBilgiler.BackColor = System.Drawing.Color.Gainsboro;
            this.tDigerBilgiler.Controls.Add(this.gSirketler);
            this.tDigerBilgiler.Controls.Add(this.gAnahtarKelimeler);
            this.tDigerBilgiler.Controls.Add(this.gFilmCekimYerleri);
            this.tDigerBilgiler.Location = new System.Drawing.Point(4, 22);
            this.tDigerBilgiler.Name = "tDigerBilgiler";
            this.tDigerBilgiler.Size = new System.Drawing.Size(746, 332);
            this.tDigerBilgiler.TabIndex = 2;
            this.tDigerBilgiler.Text = "Diger Bilgiler";
            // 
            // gSirketler
            // 
            this.gSirketler.Controls.Add(this.tvSirketler);
            this.gSirketler.Location = new System.Drawing.Point(3, 3);
            this.gSirketler.Name = "gSirketler";
            this.gSirketler.Size = new System.Drawing.Size(339, 322);
            this.gSirketler.TabIndex = 27;
            this.gSirketler.TabStop = false;
            this.gSirketler.Text = "Şirketler";
            // 
            // tvSirketler
            // 
            this.tvSirketler.Location = new System.Drawing.Point(7, 19);
            this.tvSirketler.Name = "tvSirketler";
            this.tvSirketler.Size = new System.Drawing.Size(326, 297);
            this.tvSirketler.TabIndex = 0;
            // 
            // gAnahtarKelimeler
            // 
            this.gAnahtarKelimeler.Controls.Add(this.lbAnahtarKelimeler);
            this.gAnahtarKelimeler.Controls.Add(this.btnAnahtarKelimeSil);
            this.gAnahtarKelimeler.Controls.Add(this.btnAnahtarKelimeEkle);
            this.gAnahtarKelimeler.Controls.Add(this.btnTumAnahtarKelimeleriSil);
            this.gAnahtarKelimeler.Controls.Add(this.btnDosyadanAnahtarKelimelerAl);
            this.gAnahtarKelimeler.Location = new System.Drawing.Point(348, 3);
            this.gAnahtarKelimeler.Name = "gAnahtarKelimeler";
            this.gAnahtarKelimeler.Size = new System.Drawing.Size(381, 163);
            this.gAnahtarKelimeler.TabIndex = 26;
            this.gAnahtarKelimeler.TabStop = false;
            this.gAnahtarKelimeler.Text = "Anahtar Kelimeler";
            // 
            // lbAnahtarKelimeler
            // 
            this.lbAnahtarKelimeler.ColumnWidth = 200;
            this.lbAnahtarKelimeler.FormattingEnabled = true;
            this.lbAnahtarKelimeler.Location = new System.Drawing.Point(15, 19);
            this.lbAnahtarKelimeler.MultiColumn = true;
            this.lbAnahtarKelimeler.Name = "lbAnahtarKelimeler";
            this.lbAnahtarKelimeler.Size = new System.Drawing.Size(317, 134);
            this.lbAnahtarKelimeler.TabIndex = 25;
            // 
            // btnAnahtarKelimeSil
            // 
            this.btnAnahtarKelimeSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnahtarKelimeSil.Location = new System.Drawing.Point(338, 50);
            this.btnAnahtarKelimeSil.Name = "btnAnahtarKelimeSil";
            this.btnAnahtarKelimeSil.Size = new System.Drawing.Size(31, 21);
            this.btnAnahtarKelimeSil.TabIndex = 22;
            this.btnAnahtarKelimeSil.Text = "Sil";
            this.btnAnahtarKelimeSil.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAnahtarKelimeSil.UseVisualStyleBackColor = true;
            this.btnAnahtarKelimeSil.Click += new System.EventHandler(this.anahtarKelimeSil_Click);
            // 
            // btnAnahtarKelimeEkle
            // 
            this.btnAnahtarKelimeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnahtarKelimeEkle.Location = new System.Drawing.Point(338, 21);
            this.btnAnahtarKelimeEkle.Name = "btnAnahtarKelimeEkle";
            this.btnAnahtarKelimeEkle.Size = new System.Drawing.Size(31, 23);
            this.btnAnahtarKelimeEkle.TabIndex = 21;
            this.btnAnahtarKelimeEkle.Text = "Ekle";
            this.btnAnahtarKelimeEkle.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAnahtarKelimeEkle.UseVisualStyleBackColor = true;
            this.btnAnahtarKelimeEkle.Click += new System.EventHandler(this.anahtarKelimeEkle_Click);
            // 
            // btnTumAnahtarKelimeleriSil
            // 
            this.btnTumAnahtarKelimeleriSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTumAnahtarKelimeleriSil.Location = new System.Drawing.Point(338, 104);
            this.btnTumAnahtarKelimeleriSil.Name = "btnTumAnahtarKelimeleriSil";
            this.btnTumAnahtarKelimeleriSil.Size = new System.Drawing.Size(31, 21);
            this.btnTumAnahtarKelimeleriSil.TabIndex = 24;
            this.btnTumAnahtarKelimeleriSil.Text = "Tümünü sil";
            this.btnTumAnahtarKelimeleriSil.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTumAnahtarKelimeleriSil.UseVisualStyleBackColor = true;
            this.btnTumAnahtarKelimeleriSil.Click += new System.EventHandler(this.tumunuSil_Click);
            // 
            // btnDosyadanAnahtarKelimelerAl
            // 
            this.btnDosyadanAnahtarKelimelerAl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDosyadanAnahtarKelimelerAl.Location = new System.Drawing.Point(338, 77);
            this.btnDosyadanAnahtarKelimelerAl.Name = "btnDosyadanAnahtarKelimelerAl";
            this.btnDosyadanAnahtarKelimelerAl.Size = new System.Drawing.Size(31, 21);
            this.btnDosyadanAnahtarKelimelerAl.TabIndex = 23;
            this.btnDosyadanAnahtarKelimelerAl.Text = "Dosyadan...";
            this.btnDosyadanAnahtarKelimelerAl.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDosyadanAnahtarKelimelerAl.UseVisualStyleBackColor = true;
            this.btnDosyadanAnahtarKelimelerAl.Click += new System.EventHandler(this.tumAnahtarKelimeleriSil_Click);
            // 
            // gFilmCekimYerleri
            // 
            this.gFilmCekimYerleri.Controls.Add(this.lbFilmCekimYerleri);
            this.gFilmCekimYerleri.Controls.Add(this.txtFilmCekimYeri);
            this.gFilmCekimYerleri.Controls.Add(this.btnFilmCekimYeriEkle);
            this.gFilmCekimYerleri.Location = new System.Drawing.Point(348, 169);
            this.gFilmCekimYerleri.Name = "gFilmCekimYerleri";
            this.gFilmCekimYerleri.Size = new System.Drawing.Size(382, 158);
            this.gFilmCekimYerleri.TabIndex = 25;
            this.gFilmCekimYerleri.TabStop = false;
            this.gFilmCekimYerleri.Text = "Film Çekim Yerleri";
            // 
            // lbFilmCekimYerleri
            // 
            this.lbFilmCekimYerleri.FormattingEnabled = true;
            this.lbFilmCekimYerleri.Location = new System.Drawing.Point(15, 44);
            this.lbFilmCekimYerleri.Name = "lbFilmCekimYerleri";
            this.lbFilmCekimYerleri.Size = new System.Drawing.Size(317, 108);
            this.lbFilmCekimYerleri.TabIndex = 30;
            // 
            // txtFilmCekimYeri
            // 
            this.txtFilmCekimYeri.Location = new System.Drawing.Point(15, 18);
            this.txtFilmCekimYeri.Name = "txtFilmCekimYeri";
            this.txtFilmCekimYeri.Size = new System.Drawing.Size(317, 20);
            this.txtFilmCekimYeri.TabIndex = 28;
            // 
            // btnFilmCekimYeriEkle
            // 
            this.btnFilmCekimYeriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFilmCekimYeriEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnFilmCekimYeriEkle.Image")));
            this.btnFilmCekimYeriEkle.Location = new System.Drawing.Point(338, 18);
            this.btnFilmCekimYeriEkle.Name = "btnFilmCekimYeriEkle";
            this.btnFilmCekimYeriEkle.Size = new System.Drawing.Size(19, 19);
            this.btnFilmCekimYeriEkle.TabIndex = 29;
            this.btnFilmCekimYeriEkle.UseVisualStyleBackColor = true;
            // 
            // tKadro
            // 
            this.tKadro.BackColor = System.Drawing.Color.Gainsboro;
            this.tKadro.Controls.Add(this.gOyuncuKadrosu);
            this.tKadro.Controls.Add(this.gYazarlar);
            this.tKadro.Controls.Add(this.gYonetmenler);
            this.tKadro.Location = new System.Drawing.Point(4, 22);
            this.tKadro.Name = "tKadro";
            this.tKadro.Padding = new System.Windows.Forms.Padding(3);
            this.tKadro.Size = new System.Drawing.Size(746, 332);
            this.tKadro.TabIndex = 1;
            this.tKadro.Text = "Kadro";
            // 
            // gOyuncuKadrosu
            // 
            this.gOyuncuKadrosu.Controls.Add(this.oyuncuKadrosu);
            this.gOyuncuKadrosu.Controls.Add(this.btnOyuncuSil);
            this.gOyuncuKadrosu.Controls.Add(this.btnYeniOyuncu);
            this.gOyuncuKadrosu.Controls.Add(this.btnSeceneklerOyunK);
            this.gOyuncuKadrosu.Location = new System.Drawing.Point(281, 6);
            this.gOyuncuKadrosu.Name = "gOyuncuKadrosu";
            this.gOyuncuKadrosu.Size = new System.Drawing.Size(459, 320);
            this.gOyuncuKadrosu.TabIndex = 10;
            this.gOyuncuKadrosu.TabStop = false;
            this.gOyuncuKadrosu.Text = "Oyuncu Kadrosu";
            // 
            // oyuncuKadrosu
            // 
            this.oyuncuKadrosu.AllowDrop = true;
            this.oyuncuKadrosu.AllowUserToAddRows = false;
            this.oyuncuKadrosu.AllowUserToDeleteRows = false;
            this.oyuncuKadrosu.AllowUserToResizeRows = false;
            this.oyuncuKadrosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.oyuncuKadrosu.BackgroundColor = System.Drawing.SystemColors.Control;
            this.oyuncuKadrosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oyuncuKadrosu.ColumnHeadersVisible = false;
            this.oyuncuKadrosu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vesikalik,
            this.OyuncuAdi,
            this.KarakterAdi,
            this.imdbIDSutunu});
            this.oyuncuKadrosu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.oyuncuKadrosu.Location = new System.Drawing.Point(6, 23);
            this.oyuncuKadrosu.Name = "oyuncuKadrosu";
            this.oyuncuKadrosu.RowHeadersVisible = false;
            this.oyuncuKadrosu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.oyuncuKadrosu.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.oyuncuKadrosu.RowTemplate.Height = 32;
            this.oyuncuKadrosu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.oyuncuKadrosu.Size = new System.Drawing.Size(447, 291);
            this.oyuncuKadrosu.TabIndex = 23;
            // 
            // Vesikalik
            // 
            this.Vesikalik.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Vesikalik.HeaderText = "Vesikalık";
            this.Vesikalik.Name = "Vesikalik";
            this.Vesikalik.Width = 5;
            // 
            // OyuncuAdi
            // 
            this.OyuncuAdi.HeaderText = "Oyuncu Adı";
            this.OyuncuAdi.Name = "OyuncuAdi";
            // 
            // KarakterAdi
            // 
            this.KarakterAdi.HeaderText = "KarakterAdi";
            this.KarakterAdi.Name = "KarakterAdi";
            // 
            // imdbIDSutunu
            // 
            this.imdbIDSutunu.HeaderText = "IMDB ID";
            this.imdbIDSutunu.Name = "imdbIDSutunu";
            this.imdbIDSutunu.Visible = false;
            // 
            // btnOyuncuSil
            // 
            this.btnOyuncuSil.BackColor = System.Drawing.Color.Transparent;
            this.btnOyuncuSil.FlatAppearance.BorderSize = 0;
            this.btnOyuncuSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOyuncuSil.Image = ((System.Drawing.Image)(resources.GetObject("btnOyuncuSil.Image")));
            this.btnOyuncuSil.Location = new System.Drawing.Point(181, 1);
            this.btnOyuncuSil.Name = "btnOyuncuSil";
            this.btnOyuncuSil.Size = new System.Drawing.Size(13, 12);
            this.btnOyuncuSil.TabIndex = 19;
            this.btnOyuncuSil.UseVisualStyleBackColor = false;
            this.btnOyuncuSil.Click += new System.EventHandler(this.oyuncuyuSil_Click);
            // 
            // btnYeniOyuncu
            // 
            this.btnYeniOyuncu.BackColor = System.Drawing.Color.Transparent;
            this.btnYeniOyuncu.FlatAppearance.BorderSize = 0;
            this.btnYeniOyuncu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniOyuncu.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniOyuncu.Image")));
            this.btnYeniOyuncu.Location = new System.Drawing.Point(162, 2);
            this.btnYeniOyuncu.Name = "btnYeniOyuncu";
            this.btnYeniOyuncu.Size = new System.Drawing.Size(12, 11);
            this.btnYeniOyuncu.TabIndex = 17;
            this.btnYeniOyuncu.UseVisualStyleBackColor = false;
            this.btnYeniOyuncu.Click += new System.EventHandler(this.oyuncuEkle_Click);
            // 
            // btnSeceneklerOyunK
            // 
            this.btnSeceneklerOyunK.BackColor = System.Drawing.Color.Transparent;
            this.btnSeceneklerOyunK.FlatAppearance.BorderSize = 0;
            this.btnSeceneklerOyunK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeceneklerOyunK.Image = ((System.Drawing.Image)(resources.GetObject("btnSeceneklerOyunK.Image")));
            this.btnSeceneklerOyunK.Location = new System.Drawing.Point(201, 3);
            this.btnSeceneklerOyunK.Name = "btnSeceneklerOyunK";
            this.btnSeceneklerOyunK.Size = new System.Drawing.Size(11, 9);
            this.btnSeceneklerOyunK.TabIndex = 14;
            this.btnSeceneklerOyunK.UseVisualStyleBackColor = false;
            this.btnSeceneklerOyunK.Click += new System.EventHandler(this.oK_dahaFazlaTusu_Click);
            // 
            // gYazarlar
            // 
            this.gYazarlar.Controls.Add(this.lvYazarlar);
            this.gYazarlar.Controls.Add(this.btnYazarSil);
            this.gYazarlar.Controls.Add(this.btnSeceneklerYazK);
            this.gYazarlar.Controls.Add(this.btnYeniYazar);
            this.gYazarlar.Location = new System.Drawing.Point(6, 163);
            this.gYazarlar.Name = "gYazarlar";
            this.gYazarlar.Size = new System.Drawing.Size(269, 162);
            this.gYazarlar.TabIndex = 9;
            this.gYazarlar.TabStop = false;
            this.gYazarlar.Text = "Yazar Kadrosu";
            // 
            // lvYazarlar
            // 
            this.lvYazarlar.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvYazarlar.AllowDrop = true;
            this.lvYazarlar.LargeImageList = this.kisiResimleri;
            this.lvYazarlar.Location = new System.Drawing.Point(10, 18);
            this.lvYazarlar.Name = "lvYazarlar";
            this.lvYazarlar.Size = new System.Drawing.Size(253, 138);
            this.lvYazarlar.SmallImageList = this.kisiResimleri;
            this.lvYazarlar.StateImageList = this.kisiResimleri;
            this.lvYazarlar.TabIndex = 21;
            this.lvYazarlar.UseCompatibleStateImageBehavior = false;
            this.lvYazarlar.View = System.Windows.Forms.View.List;
            // 
            // kisiResimleri
            // 
            this.kisiResimleri.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.kisiResimleri.ImageSize = new System.Drawing.Size(23, 23);
            this.kisiResimleri.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnYazarSil
            // 
            this.btnYazarSil.BackColor = System.Drawing.Color.Transparent;
            this.btnYazarSil.FlatAppearance.BorderSize = 0;
            this.btnYazarSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYazarSil.Image = ((System.Drawing.Image)(resources.GetObject("btnYazarSil.Image")));
            this.btnYazarSil.Location = new System.Drawing.Point(103, 1);
            this.btnYazarSil.Name = "btnYazarSil";
            this.btnYazarSil.Size = new System.Drawing.Size(13, 12);
            this.btnYazarSil.TabIndex = 11;
            this.btnYazarSil.UseVisualStyleBackColor = false;
            this.btnYazarSil.Click += new System.EventHandler(this.yazariSil_Click);
            // 
            // btnSeceneklerYazK
            // 
            this.btnSeceneklerYazK.BackColor = System.Drawing.Color.Transparent;
            this.btnSeceneklerYazK.FlatAppearance.BorderSize = 0;
            this.btnSeceneklerYazK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeceneklerYazK.Image = ((System.Drawing.Image)(resources.GetObject("btnSeceneklerYazK.Image")));
            this.btnSeceneklerYazK.Location = new System.Drawing.Point(123, 3);
            this.btnSeceneklerYazK.Name = "btnSeceneklerYazK";
            this.btnSeceneklerYazK.Size = new System.Drawing.Size(11, 9);
            this.btnSeceneklerYazK.TabIndex = 19;
            this.btnSeceneklerYazK.UseVisualStyleBackColor = false;
            this.btnSeceneklerYazK.Click += new System.EventHandler(this.yzrK_dahaFazlaTusu_Click);
            // 
            // btnYeniYazar
            // 
            this.btnYeniYazar.BackColor = System.Drawing.Color.Transparent;
            this.btnYeniYazar.FlatAppearance.BorderSize = 0;
            this.btnYeniYazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniYazar.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniYazar.Image")));
            this.btnYeniYazar.Location = new System.Drawing.Point(82, 2);
            this.btnYeniYazar.Name = "btnYeniYazar";
            this.btnYeniYazar.Size = new System.Drawing.Size(12, 11);
            this.btnYeniYazar.TabIndex = 12;
            this.btnYeniYazar.UseVisualStyleBackColor = false;
            this.btnYeniYazar.Click += new System.EventHandler(this.yazarEkle_Click);
            // 
            // gYonetmenler
            // 
            this.gYonetmenler.Controls.Add(this.lvYonetmenler);
            this.gYonetmenler.Controls.Add(this.btnYonetmenSil);
            this.gYonetmenler.Controls.Add(this.btnSeceneklerYonK);
            this.gYonetmenler.Controls.Add(this.btnYeniYonetmen);
            this.gYonetmenler.Location = new System.Drawing.Point(6, 6);
            this.gYonetmenler.Name = "gYonetmenler";
            this.gYonetmenler.Size = new System.Drawing.Size(269, 153);
            this.gYonetmenler.TabIndex = 8;
            this.gYonetmenler.TabStop = false;
            this.gYonetmenler.Text = "Yönetmen Kadrosu";
            // 
            // lvYonetmenler
            // 
            this.lvYonetmenler.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvYonetmenler.AllowDrop = true;
            this.lvYonetmenler.LargeImageList = this.kisiResimleri;
            this.lvYonetmenler.Location = new System.Drawing.Point(10, 23);
            this.lvYonetmenler.Name = "lvYonetmenler";
            this.lvYonetmenler.Size = new System.Drawing.Size(253, 124);
            this.lvYonetmenler.SmallImageList = this.kisiResimleri;
            this.lvYonetmenler.StateImageList = this.kisiResimleri;
            this.lvYonetmenler.TabIndex = 20;
            this.lvYonetmenler.UseCompatibleStateImageBehavior = false;
            this.lvYonetmenler.View = System.Windows.Forms.View.List;
            // 
            // btnYonetmenSil
            // 
            this.btnYonetmenSil.BackColor = System.Drawing.Color.Transparent;
            this.btnYonetmenSil.FlatAppearance.BorderSize = 0;
            this.btnYonetmenSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYonetmenSil.Image = ((System.Drawing.Image)(resources.GetObject("btnYonetmenSil.Image")));
            this.btnYonetmenSil.Location = new System.Drawing.Point(121, 1);
            this.btnYonetmenSil.Name = "btnYonetmenSil";
            this.btnYonetmenSil.Size = new System.Drawing.Size(13, 12);
            this.btnYonetmenSil.TabIndex = 10;
            this.btnYonetmenSil.UseVisualStyleBackColor = false;
            this.btnYonetmenSil.Click += new System.EventHandler(this.yonetmeniSil_Click);
            // 
            // btnSeceneklerYonK
            // 
            this.btnSeceneklerYonK.BackColor = System.Drawing.Color.Transparent;
            this.btnSeceneklerYonK.FlatAppearance.BorderSize = 0;
            this.btnSeceneklerYonK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeceneklerYonK.Image = ((System.Drawing.Image)(resources.GetObject("btnSeceneklerYonK.Image")));
            this.btnSeceneklerYonK.Location = new System.Drawing.Point(140, 3);
            this.btnSeceneklerYonK.Name = "btnSeceneklerYonK";
            this.btnSeceneklerYonK.Size = new System.Drawing.Size(11, 9);
            this.btnSeceneklerYonK.TabIndex = 6;
            this.btnSeceneklerYonK.UseVisualStyleBackColor = false;
            this.btnSeceneklerYonK.Click += new System.EventHandler(this.yK_dahaFazlaTusu_Click);
            // 
            // btnYeniYonetmen
            // 
            this.btnYeniYonetmen.BackColor = System.Drawing.Color.Transparent;
            this.btnYeniYonetmen.FlatAppearance.BorderSize = 0;
            this.btnYeniYonetmen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniYonetmen.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniYonetmen.Image")));
            this.btnYeniYonetmen.Location = new System.Drawing.Point(104, 2);
            this.btnYeniYonetmen.Name = "btnYeniYonetmen";
            this.btnYeniYonetmen.Size = new System.Drawing.Size(12, 11);
            this.btnYeniYonetmen.TabIndex = 8;
            this.btnYeniYonetmen.UseVisualStyleBackColor = false;
            this.btnYeniYonetmen.Click += new System.EventHandler(this.yeniYonetmenEkle_Click);
            // 
            // tGenelBilgiler
            // 
            this.tGenelBilgiler.BackColor = System.Drawing.Color.Gainsboro;
            this.tGenelBilgiler.Controls.Add(this.gGenelBilgiler);
            this.tGenelBilgiler.Controls.Add(this.pFilmAfisi);
            this.tGenelBilgiler.Location = new System.Drawing.Point(4, 22);
            this.tGenelBilgiler.Name = "tGenelBilgiler";
            this.tGenelBilgiler.Padding = new System.Windows.Forms.Padding(3);
            this.tGenelBilgiler.Size = new System.Drawing.Size(746, 332);
            this.tGenelBilgiler.TabIndex = 0;
            this.tGenelBilgiler.Text = "Genel Bilgiler";
            // 
            // gGenelBilgiler
            // 
            this.gGenelBilgiler.Controls.Add(this.lButce);
            this.gGenelBilgiler.Controls.Add(this.txtButce);
            this.gGenelBilgiler.Controls.Add(this.txtOynadigiTarihler);
            this.gGenelBilgiler.Controls.Add(this.lOynadigiTarihler);
            this.gGenelBilgiler.Controls.Add(this.txtCikisTarihi);
            this.gGenelBilgiler.Controls.Add(this.txtFilmSuresi);
            this.gGenelBilgiler.Controls.Add(this.txtImdbPuani);
            this.gGenelBilgiler.Controls.Add(this.txtImdbID);
            this.gGenelBilgiler.Controls.Add(this.lOrnekImdbID);
            this.gGenelBilgiler.Controls.Add(this.lIMDBPuani);
            this.gGenelBilgiler.Controls.Add(this.lIMDBId);
            this.gGenelBilgiler.Controls.Add(this.chlTurListesi);
            this.gGenelBilgiler.Controls.Add(this.lFilmTuru);
            this.gGenelBilgiler.Controls.Add(this.lDakika);
            this.gGenelBilgiler.Controls.Add(this.lFilmTarihi);
            this.gGenelBilgiler.Controls.Add(this.lCikisTarihi);
            this.gGenelBilgiler.Controls.Add(this.lFilmAdi);
            this.gGenelBilgiler.Controls.Add(this.txtFilmAdi);
            this.gGenelBilgiler.Location = new System.Drawing.Point(231, 11);
            this.gGenelBilgiler.Name = "gGenelBilgiler";
            this.gGenelBilgiler.Size = new System.Drawing.Size(509, 314);
            this.gGenelBilgiler.TabIndex = 5;
            this.gGenelBilgiler.TabStop = false;
            this.gGenelBilgiler.Text = "Genel Bilgiler";
            // 
            // lButce
            // 
            this.lButce.AutoSize = true;
            this.lButce.Location = new System.Drawing.Point(11, 154);
            this.lButce.Name = "lButce";
            this.lButce.Size = new System.Drawing.Size(35, 13);
            this.lButce.TabIndex = 37;
            this.lButce.Text = "Bütçe";
            // 
            // txtButce
            // 
            this.txtButce.Location = new System.Drawing.Point(86, 151);
            this.txtButce.Name = "txtButce";
            this.txtButce.Size = new System.Drawing.Size(116, 20);
            this.txtButce.TabIndex = 36;
            // 
            // txtOynadigiTarihler
            // 
            this.txtOynadigiTarihler.Location = new System.Drawing.Point(317, 100);
            this.txtOynadigiTarihler.Name = "txtOynadigiTarihler";
            this.txtOynadigiTarihler.Size = new System.Drawing.Size(102, 20);
            this.txtOynadigiTarihler.TabIndex = 22;
            this.txtOynadigiTarihler.Visible = false;
            // 
            // lOynadigiTarihler
            // 
            this.lOynadigiTarihler.AutoSize = true;
            this.lOynadigiTarihler.Location = new System.Drawing.Point(225, 105);
            this.lOynadigiTarihler.Name = "lOynadigiTarihler";
            this.lOynadigiTarihler.Size = new System.Drawing.Size(86, 13);
            this.lOynadigiTarihler.TabIndex = 21;
            this.lOynadigiTarihler.Text = "Oynadığı Tarihler";
            this.lOynadigiTarihler.Visible = false;
            // 
            // txtCikisTarihi
            // 
            this.txtCikisTarihi.Location = new System.Drawing.Point(87, 100);
            this.txtCikisTarihi.Name = "txtCikisTarihi";
            this.txtCikisTarihi.Size = new System.Drawing.Size(102, 20);
            this.txtCikisTarihi.TabIndex = 20;
            // 
            // txtFilmSuresi
            // 
            this.txtFilmSuresi.Location = new System.Drawing.Point(87, 125);
            this.txtFilmSuresi.Name = "txtFilmSuresi";
            this.txtFilmSuresi.Size = new System.Drawing.Size(42, 20);
            this.txtFilmSuresi.TabIndex = 19;
            // 
            // txtImdbPuani
            // 
            this.txtImdbPuani.Location = new System.Drawing.Point(87, 74);
            this.txtImdbPuani.Name = "txtImdbPuani";
            this.txtImdbPuani.Size = new System.Drawing.Size(42, 20);
            this.txtImdbPuani.TabIndex = 18;
            // 
            // txtImdbID
            // 
            this.txtImdbID.Location = new System.Drawing.Point(87, 22);
            this.txtImdbID.MaxLength = 9;
            this.txtImdbID.Name = "txtImdbID";
            this.txtImdbID.Size = new System.Drawing.Size(102, 20);
            this.txtImdbID.TabIndex = 16;
            // 
            // lOrnekImdbID
            // 
            this.lOrnekImdbID.AutoSize = true;
            this.lOrnekImdbID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lOrnekImdbID.Location = new System.Drawing.Point(213, 23);
            this.lOrnekImdbID.Name = "lOrnekImdbID";
            this.lOrnekImdbID.Size = new System.Drawing.Size(92, 14);
            this.lOrnekImdbID.TabIndex = 12;
            this.lOrnekImdbID.Text = "Örnek: tt0980970";
            // 
            // lIMDBPuani
            // 
            this.lIMDBPuani.AutoSize = true;
            this.lIMDBPuani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lIMDBPuani.Location = new System.Drawing.Point(11, 75);
            this.lIMDBPuani.Name = "lIMDBPuani";
            this.lIMDBPuani.Size = new System.Drawing.Size(64, 13);
            this.lIMDBPuani.TabIndex = 14;
            this.lIMDBPuani.Text = "IMDB Puani";
            // 
            // lIMDBId
            // 
            this.lIMDBId.AutoSize = true;
            this.lIMDBId.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIMDBId.Location = new System.Drawing.Point(12, 25);
            this.lIMDBId.Name = "lIMDBId";
            this.lIMDBId.Size = new System.Drawing.Size(45, 16);
            this.lIMDBId.TabIndex = 15;
            this.lIMDBId.Text = "IMBD Id";
            // 
            // chlTurListesi
            // 
            this.chlTurListesi.CheckOnClick = true;
            this.chlTurListesi.FormattingEnabled = true;
            this.chlTurListesi.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Animation",
            "Biography",
            "Comedy",
            "Crime",
            "Documentary",
            "Drama",
            "Family",
            "Fantasy",
            "FilmNoir",
            "GameShow ",
            "History ",
            "Horror",
            "Music",
            "Musical",
            "Mystery ",
            "News",
            "RealityTV",
            "Romance ",
            "SciFi ",
            "Sport",
            "TalkShow",
            "Thriller",
            "War",
            "Western"});
            this.chlTurListesi.Location = new System.Drawing.Point(86, 177);
            this.chlTurListesi.MultiColumn = true;
            this.chlTurListesi.Name = "chlTurListesi";
            this.chlTurListesi.Size = new System.Drawing.Size(417, 124);
            this.chlTurListesi.TabIndex = 8;
            this.chlTurListesi.ThreeDCheckBoxes = true;
            // 
            // lFilmTuru
            // 
            this.lFilmTuru.AutoSize = true;
            this.lFilmTuru.Location = new System.Drawing.Point(11, 181);
            this.lFilmTuru.Name = "lFilmTuru";
            this.lFilmTuru.Size = new System.Drawing.Size(50, 13);
            this.lFilmTuru.TabIndex = 10;
            this.lFilmTuru.Text = "Film Türü";
            // 
            // lDakika
            // 
            this.lDakika.AutoSize = true;
            this.lDakika.Location = new System.Drawing.Point(135, 128);
            this.lDakika.Name = "lDakika";
            this.lDakika.Size = new System.Drawing.Size(39, 13);
            this.lDakika.TabIndex = 9;
            this.lDakika.Text = "dakika";
            // 
            // lFilmTarihi
            // 
            this.lFilmTarihi.AutoSize = true;
            this.lFilmTarihi.Location = new System.Drawing.Point(11, 128);
            this.lFilmTarihi.Name = "lFilmTarihi";
            this.lFilmTarihi.Size = new System.Drawing.Size(57, 13);
            this.lFilmTarihi.TabIndex = 7;
            this.lFilmTarihi.Text = "Film Süresi";
            // 
            // lCikisTarihi
            // 
            this.lCikisTarihi.AutoSize = true;
            this.lCikisTarihi.Location = new System.Drawing.Point(11, 103);
            this.lCikisTarihi.Name = "lCikisTarihi";
            this.lCikisTarihi.Size = new System.Drawing.Size(58, 13);
            this.lCikisTarihi.TabIndex = 5;
            this.lCikisTarihi.Text = "Çıkış Tarihi";
            // 
            // lFilmAdi
            // 
            this.lFilmAdi.AutoSize = true;
            this.lFilmAdi.BackColor = System.Drawing.Color.Gainsboro;
            this.lFilmAdi.Location = new System.Drawing.Point(11, 49);
            this.lFilmAdi.Name = "lFilmAdi";
            this.lFilmAdi.Size = new System.Drawing.Size(43, 13);
            this.lFilmAdi.TabIndex = 3;
            this.lFilmAdi.Text = "Film Adi";
            // 
            // txtFilmAdi
            // 
            this.txtFilmAdi.Location = new System.Drawing.Point(87, 46);
            this.txtFilmAdi.Name = "txtFilmAdi";
            this.txtFilmAdi.Size = new System.Drawing.Size(204, 20);
            this.txtFilmAdi.TabIndex = 4;
            // 
            // pFilmAfisi
            // 
            this.pFilmAfisi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFilmAfisi.Image = global::Filmograf.Properties.Resources.varsayilanfilmafisi1;
            this.pFilmAfisi.Location = new System.Drawing.Point(10, 19);
            this.pFilmAfisi.Name = "pFilmAfisi";
            this.pFilmAfisi.Size = new System.Drawing.Size(217, 305);
            this.pFilmAfisi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pFilmAfisi.TabIndex = 3;
            this.pFilmAfisi.TabStop = false;
            this.pFilmAfisi.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // filmAyarlari
            // 
            this.filmAyarlari.Controls.Add(this.tGenelBilgiler);
            this.filmAyarlari.Controls.Add(this.tKadro);
            this.filmAyarlari.Controls.Add(this.tDigerKisiler);
            this.filmAyarlari.Controls.Add(this.tOduller);
            this.filmAyarlari.Controls.Add(this.tEglencelik);
            this.filmAyarlari.Controls.Add(this.tDetaylar);
            this.filmAyarlari.Controls.Add(this.tDigerBilgiler);
            this.filmAyarlari.Controls.Add(this.tBolumler);
            this.filmAyarlari.Location = new System.Drawing.Point(7, 7);
            this.filmAyarlari.Name = "filmAyarlari";
            this.filmAyarlari.SelectedIndex = 0;
            this.filmAyarlari.Size = new System.Drawing.Size(754, 358);
            this.filmAyarlari.TabIndex = 0;
            // 
            // tDigerKisiler
            // 
            this.tDigerKisiler.BackColor = System.Drawing.Color.Gainsboro;
            this.tDigerKisiler.Controls.Add(this.gDüzenle);
            this.tDigerKisiler.Controls.Add(this.gBilgiler);
            this.tDigerKisiler.Controls.Add(this.tvOyuncuKadrosu);
            this.tDigerKisiler.Location = new System.Drawing.Point(4, 22);
            this.tDigerKisiler.Name = "tDigerKisiler";
            this.tDigerKisiler.Size = new System.Drawing.Size(746, 332);
            this.tDigerKisiler.TabIndex = 5;
            this.tDigerKisiler.Text = "Diğer Kişiler";
            // 
            // gDüzenle
            // 
            this.gDüzenle.Location = new System.Drawing.Point(370, 150);
            this.gDüzenle.Name = "gDüzenle";
            this.gDüzenle.Size = new System.Drawing.Size(364, 169);
            this.gDüzenle.TabIndex = 27;
            this.gDüzenle.TabStop = false;
            this.gDüzenle.Text = "Düzenle";
            // 
            // gBilgiler
            // 
            this.gBilgiler.Controls.Add(this.lGorevDurumu);
            this.gBilgiler.Controls.Add(this.lGorevAciklama);
            this.gBilgiler.Controls.Add(this.lID);
            this.gBilgiler.Controls.Add(this.lIsim);
            this.gBilgiler.Controls.Add(this.lGosterKutuphaneDurumu);
            this.gBilgiler.Controls.Add(this.lGosterGorevAciklama);
            this.gBilgiler.Controls.Add(this.lGosterID);
            this.gBilgiler.Controls.Add(this.lGosterIsim);
            this.gBilgiler.Controls.Add(this.lGosterDepartmanGorev);
            this.gBilgiler.Controls.Add(this.lDepartmanGorev);
            this.gBilgiler.Location = new System.Drawing.Point(370, 6);
            this.gBilgiler.Name = "gBilgiler";
            this.gBilgiler.Size = new System.Drawing.Size(364, 138);
            this.gBilgiler.TabIndex = 26;
            this.gBilgiler.TabStop = false;
            this.gBilgiler.Text = "Durum";
            // 
            // lGorevDurumu
            // 
            this.lGorevDurumu.AutoSize = true;
            this.lGorevDurumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGorevDurumu.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lGorevDurumu.Location = new System.Drawing.Point(11, 109);
            this.lGorevDurumu.Name = "lGorevDurumu";
            this.lGorevDurumu.Size = new System.Drawing.Size(119, 13);
            this.lGorevDurumu.TabIndex = 9;
            this.lGorevDurumu.Text = "Kütüphane Durumu:";
            // 
            // lGorevAciklama
            // 
            this.lGorevAciklama.AutoSize = true;
            this.lGorevAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lGorevAciklama.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lGorevAciklama.Location = new System.Drawing.Point(11, 86);
            this.lGorevAciklama.Name = "lGorevAciklama";
            this.lGorevAciklama.Size = new System.Drawing.Size(100, 13);
            this.lGorevAciklama.TabIndex = 8;
            this.lGorevAciklama.Text = "Görev Açıklama:";
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lID.Location = new System.Drawing.Point(11, 64);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(24, 13);
            this.lID.TabIndex = 7;
            this.lID.Text = "ID:";
            // 
            // lIsim
            // 
            this.lIsim.AutoSize = true;
            this.lIsim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lIsim.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lIsim.Location = new System.Drawing.Point(11, 43);
            this.lIsim.Name = "lIsim";
            this.lIsim.Size = new System.Drawing.Size(33, 13);
            this.lIsim.TabIndex = 6;
            this.lIsim.Text = "İsim:";
            // 
            // lGosterKutuphaneDurumu
            // 
            this.lGosterKutuphaneDurumu.AutoSize = true;
            this.lGosterKutuphaneDurumu.Location = new System.Drawing.Point(137, 109);
            this.lGosterKutuphaneDurumu.Name = "lGosterKutuphaneDurumu";
            this.lGosterKutuphaneDurumu.Size = new System.Drawing.Size(0, 13);
            this.lGosterKutuphaneDurumu.TabIndex = 5;
            // 
            // lGosterGorevAciklama
            // 
            this.lGosterGorevAciklama.AutoSize = true;
            this.lGosterGorevAciklama.Location = new System.Drawing.Point(137, 86);
            this.lGosterGorevAciklama.Name = "lGosterGorevAciklama";
            this.lGosterGorevAciklama.Size = new System.Drawing.Size(0, 13);
            this.lGosterGorevAciklama.TabIndex = 4;
            // 
            // lGosterID
            // 
            this.lGosterID.AutoSize = true;
            this.lGosterID.Location = new System.Drawing.Point(137, 64);
            this.lGosterID.Name = "lGosterID";
            this.lGosterID.Size = new System.Drawing.Size(0, 13);
            this.lGosterID.TabIndex = 3;
            // 
            // lGosterIsim
            // 
            this.lGosterIsim.AutoSize = true;
            this.lGosterIsim.Location = new System.Drawing.Point(137, 43);
            this.lGosterIsim.Name = "lGosterIsim";
            this.lGosterIsim.Size = new System.Drawing.Size(0, 13);
            this.lGosterIsim.TabIndex = 2;
            // 
            // lGosterDepartmanGorev
            // 
            this.lGosterDepartmanGorev.AutoSize = true;
            this.lGosterDepartmanGorev.Location = new System.Drawing.Point(137, 21);
            this.lGosterDepartmanGorev.Name = "lGosterDepartmanGorev";
            this.lGosterDepartmanGorev.Size = new System.Drawing.Size(0, 13);
            this.lGosterDepartmanGorev.TabIndex = 1;
            // 
            // lDepartmanGorev
            // 
            this.lDepartmanGorev.AutoSize = true;
            this.lDepartmanGorev.BackColor = System.Drawing.Color.Gainsboro;
            this.lDepartmanGorev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lDepartmanGorev.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lDepartmanGorev.Location = new System.Drawing.Point(11, 21);
            this.lDepartmanGorev.Name = "lDepartmanGorev";
            this.lDepartmanGorev.Size = new System.Drawing.Size(112, 13);
            this.lDepartmanGorev.TabIndex = 0;
            this.lDepartmanGorev.Text = "Departman/Görev:";
            // 
            // tvOyuncuKadrosu
            // 
            this.tvOyuncuKadrosu.ImageIndex = 0;
            this.tvOyuncuKadrosu.ImageList = this.kisiResimleri;
            this.tvOyuncuKadrosu.Location = new System.Drawing.Point(12, 12);
            this.tvOyuncuKadrosu.Name = "tvOyuncuKadrosu";
            this.tvOyuncuKadrosu.SelectedImageIndex = 0;
            this.tvOyuncuKadrosu.Size = new System.Drawing.Size(351, 307);
            this.tvOyuncuKadrosu.TabIndex = 25;
            this.tvOyuncuKadrosu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOyuncuKadrosu_AfterSelect);
            // 
            // tOduller
            // 
            this.tOduller.BackColor = System.Drawing.Color.Gainsboro;
            this.tOduller.Controls.Add(this.gDuzenle);
            this.tOduller.Controls.Add(this.gDurum);
            this.tOduller.Controls.Add(this.tvOduller);
            this.tOduller.Location = new System.Drawing.Point(4, 22);
            this.tOduller.Name = "tOduller";
            this.tOduller.Size = new System.Drawing.Size(746, 332);
            this.tOduller.TabIndex = 6;
            this.tOduller.Text = "Ödüller";
            // 
            // gDuzenle
            // 
            this.gDuzenle.Location = new System.Drawing.Point(370, 150);
            this.gDuzenle.Name = "gDuzenle";
            this.gDuzenle.Size = new System.Drawing.Size(364, 169);
            this.gDuzenle.TabIndex = 30;
            this.gDuzenle.TabStop = false;
            this.gDuzenle.Text = "Düzenle";
            // 
            // gDurum
            // 
            this.gDurum.Controls.Add(this.lAlanKisi);
            this.gDurum.Controls.Add(this.lKategori);
            this.gDurum.Controls.Add(this.lSonuc);
            this.gDurum.Controls.Add(this.lYil);
            this.gDurum.Controls.Add(this.lGosterAlanKisi);
            this.gDurum.Controls.Add(this.lGosterKategori);
            this.gDurum.Controls.Add(this.lGosterSonuc);
            this.gDurum.Controls.Add(this.lGosterYil);
            this.gDurum.Controls.Add(this.lGosterOdulVerenKurum);
            this.gDurum.Controls.Add(this.lOdulVerenKurum);
            this.gDurum.Location = new System.Drawing.Point(370, 6);
            this.gDurum.Name = "gDurum";
            this.gDurum.Size = new System.Drawing.Size(364, 138);
            this.gDurum.TabIndex = 29;
            this.gDurum.TabStop = false;
            this.gDurum.Text = "Durum";
            // 
            // lAlanKisi
            // 
            this.lAlanKisi.AutoSize = true;
            this.lAlanKisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lAlanKisi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lAlanKisi.Location = new System.Drawing.Point(11, 109);
            this.lAlanKisi.Name = "lAlanKisi";
            this.lAlanKisi.Size = new System.Drawing.Size(60, 13);
            this.lAlanKisi.TabIndex = 9;
            this.lAlanKisi.Text = "Alan Kişi:";
            // 
            // lKategori
            // 
            this.lKategori.AutoSize = true;
            this.lKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lKategori.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lKategori.Location = new System.Drawing.Point(11, 86);
            this.lKategori.Name = "lKategori";
            this.lKategori.Size = new System.Drawing.Size(58, 13);
            this.lKategori.TabIndex = 8;
            this.lKategori.Text = "Kategori:";
            // 
            // lSonuc
            // 
            this.lSonuc.AutoSize = true;
            this.lSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSonuc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lSonuc.Location = new System.Drawing.Point(11, 64);
            this.lSonuc.Name = "lSonuc";
            this.lSonuc.Size = new System.Drawing.Size(47, 13);
            this.lSonuc.TabIndex = 7;
            this.lSonuc.Text = "Sonuç:";
            // 
            // lYil
            // 
            this.lYil.AutoSize = true;
            this.lYil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lYil.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lYil.Location = new System.Drawing.Point(11, 43);
            this.lYil.Name = "lYil";
            this.lYil.Size = new System.Drawing.Size(25, 13);
            this.lYil.TabIndex = 6;
            this.lYil.Text = "Yıl:";
            // 
            // lGosterAlanKisi
            // 
            this.lGosterAlanKisi.AutoSize = true;
            this.lGosterAlanKisi.Location = new System.Drawing.Point(137, 109);
            this.lGosterAlanKisi.Name = "lGosterAlanKisi";
            this.lGosterAlanKisi.Size = new System.Drawing.Size(0, 13);
            this.lGosterAlanKisi.TabIndex = 5;
            // 
            // lGosterKategori
            // 
            this.lGosterKategori.AutoSize = true;
            this.lGosterKategori.Location = new System.Drawing.Point(137, 86);
            this.lGosterKategori.Name = "lGosterKategori";
            this.lGosterKategori.Size = new System.Drawing.Size(0, 13);
            this.lGosterKategori.TabIndex = 4;
            // 
            // lGosterSonuc
            // 
            this.lGosterSonuc.AutoSize = true;
            this.lGosterSonuc.Location = new System.Drawing.Point(137, 64);
            this.lGosterSonuc.Name = "lGosterSonuc";
            this.lGosterSonuc.Size = new System.Drawing.Size(0, 13);
            this.lGosterSonuc.TabIndex = 3;
            // 
            // lGosterYil
            // 
            this.lGosterYil.AutoSize = true;
            this.lGosterYil.Location = new System.Drawing.Point(137, 43);
            this.lGosterYil.Name = "lGosterYil";
            this.lGosterYil.Size = new System.Drawing.Size(0, 13);
            this.lGosterYil.TabIndex = 2;
            // 
            // lGosterOdulVerenKurum
            // 
            this.lGosterOdulVerenKurum.AutoSize = true;
            this.lGosterOdulVerenKurum.Location = new System.Drawing.Point(137, 21);
            this.lGosterOdulVerenKurum.Name = "lGosterOdulVerenKurum";
            this.lGosterOdulVerenKurum.Size = new System.Drawing.Size(0, 13);
            this.lGosterOdulVerenKurum.TabIndex = 1;
            // 
            // lOdulVerenKurum
            // 
            this.lOdulVerenKurum.AutoSize = true;
            this.lOdulVerenKurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lOdulVerenKurum.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lOdulVerenKurum.Location = new System.Drawing.Point(11, 21);
            this.lOdulVerenKurum.Name = "lOdulVerenKurum";
            this.lOdulVerenKurum.Size = new System.Drawing.Size(113, 13);
            this.lOdulVerenKurum.TabIndex = 0;
            this.lOdulVerenKurum.Text = "Ödül Veren Kurum:";
            // 
            // tvOduller
            // 
            this.tvOduller.ImageIndex = 0;
            this.tvOduller.ImageList = this.kisiResimleri;
            this.tvOduller.Location = new System.Drawing.Point(12, 12);
            this.tvOduller.Name = "tvOduller";
            this.tvOduller.SelectedImageIndex = 0;
            this.tvOduller.Size = new System.Drawing.Size(351, 307);
            this.tvOduller.TabIndex = 28;
            this.tvOduller.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOduller_AfterSelect);
            // 
            // tEglencelik
            // 
            this.tEglencelik.BackColor = System.Drawing.Color.Gainsboro;
            this.tEglencelik.Controls.Add(this.tabEglencelik);
            this.tEglencelik.Location = new System.Drawing.Point(4, 22);
            this.tEglencelik.Name = "tEglencelik";
            this.tEglencelik.Size = new System.Drawing.Size(746, 332);
            this.tEglencelik.TabIndex = 4;
            this.tEglencelik.Text = "Eğlencelik";
            // 
            // tabEglencelik
            // 
            this.tabEglencelik.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabEglencelik.Controls.Add(this.tOlayOrgusu);
            this.tabEglencelik.Controls.Add(this.tReklamsalSozler);
            this.tabEglencelik.Controls.Add(this.tCrazyCredits);
            this.tabEglencelik.Controls.Add(this.tCekimGercegi);
            this.tabEglencelik.Controls.Add(this.tHatalar);
            this.tabEglencelik.Controls.Add(this.tReplikler);
            this.tabEglencelik.Controls.Add(this.tReferanslar);
            this.tabEglencelik.Controls.Add(this.tMuzikler);
            this.tabEglencelik.Location = new System.Drawing.Point(16, 15);
            this.tabEglencelik.Multiline = true;
            this.tabEglencelik.Name = "tabEglencelik";
            this.tabEglencelik.SelectedIndex = 0;
            this.tabEglencelik.Size = new System.Drawing.Size(711, 297);
            this.tabEglencelik.TabIndex = 17;
            // 
            // tOlayOrgusu
            // 
            this.tOlayOrgusu.BackColor = System.Drawing.Color.Gainsboro;
            this.tOlayOrgusu.Controls.Add(this.btnOlayOrgusuSil);
            this.tOlayOrgusu.Controls.Add(this.btnOlayOrgusuEkle);
            this.tOlayOrgusu.Controls.Add(this.llkOlayOrgusu);
            this.tOlayOrgusu.Location = new System.Drawing.Point(4, 4);
            this.tOlayOrgusu.Name = "tOlayOrgusu";
            this.tOlayOrgusu.Padding = new System.Windows.Forms.Padding(3);
            this.tOlayOrgusu.Size = new System.Drawing.Size(703, 271);
            this.tOlayOrgusu.TabIndex = 1;
            this.tOlayOrgusu.Text = "Olay Örgüsü";
            // 
            // btnOlayOrgusuSil
            // 
            this.btnOlayOrgusuSil.FlatAppearance.BorderSize = 0;
            this.btnOlayOrgusuSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOlayOrgusuSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnOlayOrgusuSil.Location = new System.Drawing.Point(484, 9);
            this.btnOlayOrgusuSil.Name = "btnOlayOrgusuSil";
            this.btnOlayOrgusuSil.Size = new System.Drawing.Size(15, 14);
            this.btnOlayOrgusuSil.TabIndex = 39;
            this.btnOlayOrgusuSil.UseVisualStyleBackColor = true;
            this.btnOlayOrgusuSil.Click += new System.EventHandler(this.btnHakkindakiGercegiSil_Click);
            // 
            // btnOlayOrgusuEkle
            // 
            this.btnOlayOrgusuEkle.FlatAppearance.BorderSize = 0;
            this.btnOlayOrgusuEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOlayOrgusuEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnOlayOrgusuEkle.Image")));
            this.btnOlayOrgusuEkle.Location = new System.Drawing.Point(505, 7);
            this.btnOlayOrgusuEkle.Name = "btnOlayOrgusuEkle";
            this.btnOlayOrgusuEkle.Size = new System.Drawing.Size(19, 19);
            this.btnOlayOrgusuEkle.TabIndex = 38;
            this.btnOlayOrgusuEkle.UseVisualStyleBackColor = true;
            this.btnOlayOrgusuEkle.Click += new System.EventHandler(this.btnOlayOrgusuEkle_Click);
            // 
            // tReklamsalSozler
            // 
            this.tReklamsalSozler.BackColor = System.Drawing.Color.Gainsboro;
            this.tReklamsalSozler.Controls.Add(this.btnSloganSil);
            this.tReklamsalSozler.Controls.Add(this.btnReklamSozuEkle);
            this.tReklamsalSozler.Controls.Add(this.llkReklamsalSoz);
            this.tReklamsalSozler.Location = new System.Drawing.Point(4, 4);
            this.tReklamsalSozler.Name = "tReklamsalSozler";
            this.tReklamsalSozler.Padding = new System.Windows.Forms.Padding(3);
            this.tReklamsalSozler.Size = new System.Drawing.Size(703, 271);
            this.tReklamsalSozler.TabIndex = 0;
            this.tReklamsalSozler.Text = "Sloganları";
            // 
            // btnSloganSil
            // 
            this.btnSloganSil.FlatAppearance.BorderSize = 0;
            this.btnSloganSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSloganSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnSloganSil.Location = new System.Drawing.Point(484, 9);
            this.btnSloganSil.Name = "btnSloganSil";
            this.btnSloganSil.Size = new System.Drawing.Size(15, 14);
            this.btnSloganSil.TabIndex = 38;
            this.btnSloganSil.UseVisualStyleBackColor = true;
            this.btnSloganSil.Click += new System.EventHandler(this.btnSloganSil_Click);
            // 
            // btnReklamSozuEkle
            // 
            this.btnReklamSozuEkle.FlatAppearance.BorderSize = 0;
            this.btnReklamSozuEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReklamSozuEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnReklamSozuEkle.Image")));
            this.btnReklamSozuEkle.Location = new System.Drawing.Point(505, 7);
            this.btnReklamSozuEkle.Name = "btnReklamSozuEkle";
            this.btnReklamSozuEkle.Size = new System.Drawing.Size(19, 19);
            this.btnReklamSozuEkle.TabIndex = 37;
            this.btnReklamSozuEkle.UseVisualStyleBackColor = true;
            this.btnReklamSozuEkle.Click += new System.EventHandler(this.btnReklamSozuEkle_Click);
            // 
            // tCrazyCredits
            // 
            this.tCrazyCredits.BackColor = System.Drawing.Color.Gainsboro;
            this.tCrazyCredits.Controls.Add(this.btnGaripGercekSil);
            this.tCrazyCredits.Controls.Add(this.btnCrazyCreditEkle);
            this.tCrazyCredits.Controls.Add(this.llkGaripGercek);
            this.tCrazyCredits.Location = new System.Drawing.Point(4, 4);
            this.tCrazyCredits.Name = "tCrazyCredits";
            this.tCrazyCredits.Padding = new System.Windows.Forms.Padding(3);
            this.tCrazyCredits.Size = new System.Drawing.Size(703, 271);
            this.tCrazyCredits.TabIndex = 2;
            this.tCrazyCredits.Text = "Garip Gerçekleri";
            // 
            // btnGaripGercekSil
            // 
            this.btnGaripGercekSil.FlatAppearance.BorderSize = 0;
            this.btnGaripGercekSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGaripGercekSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnGaripGercekSil.Location = new System.Drawing.Point(484, 9);
            this.btnGaripGercekSil.Name = "btnGaripGercekSil";
            this.btnGaripGercekSil.Size = new System.Drawing.Size(15, 14);
            this.btnGaripGercekSil.TabIndex = 42;
            this.btnGaripGercekSil.UseVisualStyleBackColor = true;
            this.btnGaripGercekSil.Click += new System.EventHandler(this.btnGaripGercekSil_Click);
            // 
            // btnCrazyCreditEkle
            // 
            this.btnCrazyCreditEkle.FlatAppearance.BorderSize = 0;
            this.btnCrazyCreditEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrazyCreditEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnCrazyCreditEkle.Image")));
            this.btnCrazyCreditEkle.Location = new System.Drawing.Point(505, 7);
            this.btnCrazyCreditEkle.Name = "btnCrazyCreditEkle";
            this.btnCrazyCreditEkle.Size = new System.Drawing.Size(19, 19);
            this.btnCrazyCreditEkle.TabIndex = 41;
            this.btnCrazyCreditEkle.UseVisualStyleBackColor = true;
            this.btnCrazyCreditEkle.Click += new System.EventHandler(this.btnCrazyCreditEkle_Click);
            // 
            // tCekimGercegi
            // 
            this.tCekimGercegi.BackColor = System.Drawing.Color.Gainsboro;
            this.tCekimGercegi.Controls.Add(this.btnCekimGercegiSil);
            this.tCekimGercegi.Controls.Add(this.btnCekimGercegiEkle);
            this.tCekimGercegi.Controls.Add(this.llkCekimGercegiGezinti);
            this.tCekimGercegi.Location = new System.Drawing.Point(4, 4);
            this.tCekimGercegi.Name = "tCekimGercegi";
            this.tCekimGercegi.Padding = new System.Windows.Forms.Padding(3);
            this.tCekimGercegi.Size = new System.Drawing.Size(703, 271);
            this.tCekimGercegi.TabIndex = 3;
            this.tCekimGercegi.Text = "Çekim Gerçekleri";
            // 
            // btnCekimGercegiSil
            // 
            this.btnCekimGercegiSil.FlatAppearance.BorderSize = 0;
            this.btnCekimGercegiSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCekimGercegiSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnCekimGercegiSil.Location = new System.Drawing.Point(484, 9);
            this.btnCekimGercegiSil.Name = "btnCekimGercegiSil";
            this.btnCekimGercegiSil.Size = new System.Drawing.Size(15, 14);
            this.btnCekimGercegiSil.TabIndex = 45;
            this.btnCekimGercegiSil.UseVisualStyleBackColor = true;
            this.btnCekimGercegiSil.Click += new System.EventHandler(this.btnCekimGercegiSil_Click);
            // 
            // btnCekimGercegiEkle
            // 
            this.btnCekimGercegiEkle.FlatAppearance.BorderSize = 0;
            this.btnCekimGercegiEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCekimGercegiEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnCekimGercegiEkle.Image")));
            this.btnCekimGercegiEkle.Location = new System.Drawing.Point(505, 7);
            this.btnCekimGercegiEkle.Name = "btnCekimGercegiEkle";
            this.btnCekimGercegiEkle.Size = new System.Drawing.Size(19, 19);
            this.btnCekimGercegiEkle.TabIndex = 44;
            this.btnCekimGercegiEkle.UseVisualStyleBackColor = true;
            this.btnCekimGercegiEkle.Click += new System.EventHandler(this.btnCekimGercegiEkle_Click);
            // 
            // tHatalar
            // 
            this.tHatalar.BackColor = System.Drawing.Color.Gainsboro;
            this.tHatalar.Controls.Add(this.btnHataSil);
            this.tHatalar.Controls.Add(this.btnHataEkle);
            this.tHatalar.Controls.Add(this.llkHatalarGezgini);
            this.tHatalar.Location = new System.Drawing.Point(4, 4);
            this.tHatalar.Name = "tHatalar";
            this.tHatalar.Size = new System.Drawing.Size(703, 271);
            this.tHatalar.TabIndex = 4;
            this.tHatalar.Text = "Hatalar";
            // 
            // btnHataSil
            // 
            this.btnHataSil.FlatAppearance.BorderSize = 0;
            this.btnHataSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHataSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnHataSil.Location = new System.Drawing.Point(484, 9);
            this.btnHataSil.Name = "btnHataSil";
            this.btnHataSil.Size = new System.Drawing.Size(15, 14);
            this.btnHataSil.TabIndex = 42;
            this.btnHataSil.UseVisualStyleBackColor = true;
            this.btnHataSil.Click += new System.EventHandler(this.btnHataSil_Click);
            // 
            // btnHataEkle
            // 
            this.btnHataEkle.FlatAppearance.BorderSize = 0;
            this.btnHataEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHataEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnHataEkle.Image")));
            this.btnHataEkle.Location = new System.Drawing.Point(505, 7);
            this.btnHataEkle.Name = "btnHataEkle";
            this.btnHataEkle.Size = new System.Drawing.Size(19, 19);
            this.btnHataEkle.TabIndex = 41;
            this.btnHataEkle.UseVisualStyleBackColor = true;
            this.btnHataEkle.Click += new System.EventHandler(this.btnHataEkle_Click);
            // 
            // tReplikler
            // 
            this.tReplikler.BackColor = System.Drawing.Color.Gainsboro;
            this.tReplikler.Controls.Add(this.btnReplikSil);
            this.tReplikler.Controls.Add(this.btnReplikEkle);
            this.tReplikler.Controls.Add(this.llkRepliklerGezgini);
            this.tReplikler.Location = new System.Drawing.Point(4, 4);
            this.tReplikler.Name = "tReplikler";
            this.tReplikler.Size = new System.Drawing.Size(703, 271);
            this.tReplikler.TabIndex = 5;
            this.tReplikler.Text = "Replikler";
            // 
            // btnReplikSil
            // 
            this.btnReplikSil.FlatAppearance.BorderSize = 0;
            this.btnReplikSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplikSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnReplikSil.Location = new System.Drawing.Point(484, 9);
            this.btnReplikSil.Name = "btnReplikSil";
            this.btnReplikSil.Size = new System.Drawing.Size(15, 14);
            this.btnReplikSil.TabIndex = 42;
            this.btnReplikSil.UseVisualStyleBackColor = true;
            this.btnReplikSil.Click += new System.EventHandler(this.btnReplikSil_Click);
            // 
            // btnReplikEkle
            // 
            this.btnReplikEkle.FlatAppearance.BorderSize = 0;
            this.btnReplikEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplikEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnReplikEkle.Image")));
            this.btnReplikEkle.Location = new System.Drawing.Point(505, 7);
            this.btnReplikEkle.Name = "btnReplikEkle";
            this.btnReplikEkle.Size = new System.Drawing.Size(19, 19);
            this.btnReplikEkle.TabIndex = 41;
            this.btnReplikEkle.UseVisualStyleBackColor = true;
            this.btnReplikEkle.Click += new System.EventHandler(this.btnReplikEkle_Click);
            // 
            // tReferanslar
            // 
            this.tReferanslar.BackColor = System.Drawing.Color.Gainsboro;
            this.tReferanslar.Controls.Add(this.btnReferansSil);
            this.tReferanslar.Controls.Add(this.btnReferansEkle);
            this.tReferanslar.Controls.Add(this.llkReferansGezici);
            this.tReferanslar.Location = new System.Drawing.Point(4, 4);
            this.tReferanslar.Name = "tReferanslar";
            this.tReferanslar.Padding = new System.Windows.Forms.Padding(3);
            this.tReferanslar.Size = new System.Drawing.Size(703, 271);
            this.tReferanslar.TabIndex = 6;
            this.tReferanslar.Text = "Referanslar";
            // 
            // btnReferansSil
            // 
            this.btnReferansSil.FlatAppearance.BorderSize = 0;
            this.btnReferansSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReferansSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnReferansSil.Location = new System.Drawing.Point(484, 9);
            this.btnReferansSil.Name = "btnReferansSil";
            this.btnReferansSil.Size = new System.Drawing.Size(15, 14);
            this.btnReferansSil.TabIndex = 42;
            this.btnReferansSil.UseVisualStyleBackColor = true;
            this.btnReferansSil.Click += new System.EventHandler(this.btnReferansSil_Click);
            // 
            // btnReferansEkle
            // 
            this.btnReferansEkle.FlatAppearance.BorderSize = 0;
            this.btnReferansEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReferansEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnReferansEkle.Image")));
            this.btnReferansEkle.Location = new System.Drawing.Point(505, 7);
            this.btnReferansEkle.Name = "btnReferansEkle";
            this.btnReferansEkle.Size = new System.Drawing.Size(19, 19);
            this.btnReferansEkle.TabIndex = 41;
            this.btnReferansEkle.UseVisualStyleBackColor = true;
            this.btnReferansEkle.Click += new System.EventHandler(this.btnReferansEkle_Click);
            // 
            // tMuzikler
            // 
            this.tMuzikler.BackColor = System.Drawing.Color.Gainsboro;
            this.tMuzikler.Controls.Add(this.btnMuzikSil);
            this.tMuzikler.Controls.Add(this.btnMuzikEkle);
            this.tMuzikler.Controls.Add(this.llkMuzikGezici);
            this.tMuzikler.Location = new System.Drawing.Point(4, 4);
            this.tMuzikler.Name = "tMuzikler";
            this.tMuzikler.Padding = new System.Windows.Forms.Padding(3);
            this.tMuzikler.Size = new System.Drawing.Size(703, 271);
            this.tMuzikler.TabIndex = 7;
            this.tMuzikler.Text = "Müzikler";
            // 
            // btnMuzikSil
            // 
            this.btnMuzikSil.FlatAppearance.BorderSize = 0;
            this.btnMuzikSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuzikSil.Image = global::Filmograf.Properties.Resources.sil1;
            this.btnMuzikSil.Location = new System.Drawing.Point(484, 9);
            this.btnMuzikSil.Name = "btnMuzikSil";
            this.btnMuzikSil.Size = new System.Drawing.Size(15, 14);
            this.btnMuzikSil.TabIndex = 42;
            this.btnMuzikSil.UseVisualStyleBackColor = true;
            this.btnMuzikSil.Click += new System.EventHandler(this.btnMuzikSil_Click);
            // 
            // btnMuzikEkle
            // 
            this.btnMuzikEkle.FlatAppearance.BorderSize = 0;
            this.btnMuzikEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuzikEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnMuzikEkle.Image")));
            this.btnMuzikEkle.Location = new System.Drawing.Point(505, 7);
            this.btnMuzikEkle.Name = "btnMuzikEkle";
            this.btnMuzikEkle.Size = new System.Drawing.Size(19, 19);
            this.btnMuzikEkle.TabIndex = 41;
            this.btnMuzikEkle.UseVisualStyleBackColor = true;
            this.btnMuzikEkle.Click += new System.EventHandler(this.btnMuzikEkle_Click);
            // 
            // tBolumler
            // 
            this.tBolumler.BackColor = System.Drawing.Color.Gainsboro;
            this.tBolumler.Controls.Add(this.label6);
            this.tBolumler.Controls.Add(this.label5);
            this.tBolumler.Controls.Add(this.gBolumBilgileri);
            this.tBolumler.Controls.Add(this.lvBolumler);
            this.tBolumler.Controls.Add(this.lvSezonlar);
            this.tBolumler.Controls.Add(this.btnKaydet);
            this.tBolumler.Location = new System.Drawing.Point(4, 22);
            this.tBolumler.Name = "tBolumler";
            this.tBolumler.Padding = new System.Windows.Forms.Padding(3);
            this.tBolumler.Size = new System.Drawing.Size(746, 332);
            this.tBolumler.TabIndex = 7;
            this.tBolumler.Text = "Bölümler";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Bölümler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sezonlar";
            // 
            // gBolumBilgileri
            // 
            this.gBolumBilgileri.Controls.Add(this.rchtxtBolumOzeti);
            this.gBolumBilgileri.Controls.Add(this.label4);
            this.gBolumBilgileri.Controls.Add(this.txtBolumID);
            this.gBolumBilgileri.Controls.Add(this.label3);
            this.gBolumBilgileri.Controls.Add(this.txtBolumCikisTarihi);
            this.gBolumBilgileri.Controls.Add(this.label2);
            this.gBolumBilgileri.Controls.Add(this.txtBolumAdi);
            this.gBolumBilgileri.Controls.Add(this.label1);
            this.gBolumBilgileri.Location = new System.Drawing.Point(342, 18);
            this.gBolumBilgileri.Name = "gBolumBilgileri";
            this.gBolumBilgileri.Size = new System.Drawing.Size(398, 272);
            this.gBolumBilgileri.TabIndex = 2;
            this.gBolumBilgileri.TabStop = false;
            this.gBolumBilgileri.Text = "Bölüm Bilgileri";
            // 
            // rchtxtBolumOzeti
            // 
            this.rchtxtBolumOzeti.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchtxtBolumOzeti.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rchtxtBolumOzeti.Location = new System.Drawing.Point(17, 113);
            this.rchtxtBolumOzeti.Name = "rchtxtBolumOzeti";
            this.rchtxtBolumOzeti.Size = new System.Drawing.Size(368, 143);
            this.rchtxtBolumOzeti.TabIndex = 8;
            this.rchtxtBolumOzeti.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bölüm Özeti";
            // 
            // txtBolumID
            // 
            this.txtBolumID.Location = new System.Drawing.Point(71, 27);
            this.txtBolumID.Name = "txtBolumID";
            this.txtBolumID.Size = new System.Drawing.Size(100, 20);
            this.txtBolumID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bölüm ID";
            // 
            // txtBolumCikisTarihi
            // 
            this.txtBolumCikisTarihi.Location = new System.Drawing.Point(273, 26);
            this.txtBolumCikisTarihi.Name = "txtBolumCikisTarihi";
            this.txtBolumCikisTarihi.Size = new System.Drawing.Size(100, 20);
            this.txtBolumCikisTarihi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yayınlanma Tarihi";
            // 
            // txtBolumAdi
            // 
            this.txtBolumAdi.Location = new System.Drawing.Point(72, 55);
            this.txtBolumAdi.Name = "txtBolumAdi";
            this.txtBolumAdi.Size = new System.Drawing.Size(168, 20);
            this.txtBolumAdi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bölüm Adı";
            // 
            // lvBolumler
            // 
            this.lvBolumler.Location = new System.Drawing.Point(181, 49);
            this.lvBolumler.Name = "lvBolumler";
            this.lvBolumler.Size = new System.Drawing.Size(154, 241);
            this.lvBolumler.TabIndex = 1;
            this.lvBolumler.UseCompatibleStateImageBehavior = false;
            this.lvBolumler.View = System.Windows.Forms.View.SmallIcon;
            this.lvBolumler.SelectedIndexChanged += new System.EventHandler(this.lvBolumler_SelectedIndexChanged);
            // 
            // lvSezonlar
            // 
            this.lvSezonlar.Location = new System.Drawing.Point(17, 49);
            this.lvSezonlar.Name = "lvSezonlar";
            this.lvSezonlar.Size = new System.Drawing.Size(158, 241);
            this.lvSezonlar.TabIndex = 0;
            this.lvSezonlar.UseCompatibleStateImageBehavior = false;
            this.lvSezonlar.View = System.Windows.Forms.View.SmallIcon;
            this.lvSezonlar.SelectedIndexChanged += new System.EventHandler(this.lvSezonlar_SelectedIndexChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(665, 296);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            // 
            // kisiEklemeMenusu
            // 
            this.kisiEklemeMenusu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kütüphanedenEkleToolStripMenuItem});
            this.kisiEklemeMenusu.Name = "kisiEklemeMenusu";
            this.kisiEklemeMenusu.Size = new System.Drawing.Size(177, 26);
            // 
            // kütüphanedenEkleToolStripMenuItem
            // 
            this.kütüphanedenEkleToolStripMenuItem.Name = "kütüphanedenEkleToolStripMenuItem";
            this.kütüphanedenEkleToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.kütüphanedenEkleToolStripMenuItem.Text = "Kütüphaneden Ekle";
            this.kütüphanedenEkleToolStripMenuItem.Click += new System.EventHandler(this.kütüphanedenEkleToolStripMenuItem_Click);
            // 
            // llkOlayOrgusu
            // 
            this.llkOlayOrgusu.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkOlayOrgusu.GosterilecekListe")));
            this.llkOlayOrgusu.Location = new System.Drawing.Point(6, 6);
            this.llkOlayOrgusu.Name = "llkOlayOrgusu";
            this.llkOlayOrgusu.Size = new System.Drawing.Size(691, 256);
            this.llkOlayOrgusu.TabIndex = 37;
            // 
            // llkReklamsalSoz
            // 
            this.llkReklamsalSoz.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkReklamsalSoz.GosterilecekListe")));
            this.llkReklamsalSoz.Location = new System.Drawing.Point(6, 6);
            this.llkReklamsalSoz.Name = "llkReklamsalSoz";
            this.llkReklamsalSoz.Size = new System.Drawing.Size(691, 256);
            this.llkReklamsalSoz.TabIndex = 36;
            // 
            // llkGaripGercek
            // 
            this.llkGaripGercek.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkGaripGercek.GosterilecekListe")));
            this.llkGaripGercek.Location = new System.Drawing.Point(6, 6);
            this.llkGaripGercek.Name = "llkGaripGercek";
            this.llkGaripGercek.Size = new System.Drawing.Size(691, 256);
            this.llkGaripGercek.TabIndex = 40;
            // 
            // llkCekimGercegiGezinti
            // 
            this.llkCekimGercegiGezinti.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkCekimGercegiGezinti.GosterilecekListe")));
            this.llkCekimGercegiGezinti.Location = new System.Drawing.Point(6, 6);
            this.llkCekimGercegiGezinti.Name = "llkCekimGercegiGezinti";
            this.llkCekimGercegiGezinti.Size = new System.Drawing.Size(691, 256);
            this.llkCekimGercegiGezinti.TabIndex = 43;
            // 
            // llkHatalarGezgini
            // 
            this.llkHatalarGezgini.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkHatalarGezgini.GosterilecekListe")));
            this.llkHatalarGezgini.Location = new System.Drawing.Point(6, 6);
            this.llkHatalarGezgini.Name = "llkHatalarGezgini";
            this.llkHatalarGezgini.Size = new System.Drawing.Size(691, 256);
            this.llkHatalarGezgini.TabIndex = 40;
            // 
            // llkRepliklerGezgini
            // 
            this.llkRepliklerGezgini.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkRepliklerGezgini.GosterilecekListe")));
            this.llkRepliklerGezgini.Location = new System.Drawing.Point(6, 6);
            this.llkRepliklerGezgini.Name = "llkRepliklerGezgini";
            this.llkRepliklerGezgini.Size = new System.Drawing.Size(691, 256);
            this.llkRepliklerGezgini.TabIndex = 40;
            // 
            // llkReferansGezici
            // 
            this.llkReferansGezici.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkReferansGezici.GosterilecekListe")));
            this.llkReferansGezici.Location = new System.Drawing.Point(6, 6);
            this.llkReferansGezici.Name = "llkReferansGezici";
            this.llkReferansGezici.Size = new System.Drawing.Size(691, 256);
            this.llkReferansGezici.TabIndex = 40;
            // 
            // llkMuzikGezici
            // 
            this.llkMuzikGezici.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkMuzikGezici.GosterilecekListe")));
            this.llkMuzikGezici.Location = new System.Drawing.Point(6, 6);
            this.llkMuzikGezici.Name = "llkMuzikGezici";
            this.llkMuzikGezici.Size = new System.Drawing.Size(691, 259);
            this.llkMuzikGezici.TabIndex = 40;
            // 
            // f_ManuelFilmEkle
            // 
            this.AcceptButton = this.btnEkle;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(769, 402);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.filmAyarlari);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnEkle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(775, 430);
            this.Name = "f_ManuelFilmEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Film Ekle";
            this.Load += new System.EventHandler(this.f_ManuelFilmEkle_Load);
            this.tDetaylar.ResumeLayout(false);
            this.gDil.ResumeLayout(false);
            this.cmsLinkSaklayici.ResumeLayout(false);
            this.gUlke.ResumeLayout(false);
            this.gBaskaIsimler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIsimUlke)).EndInit();
            this.gResmiWebSayfalari.ResumeLayout(false);
            this.gResmiWebSayfalari.PerformLayout();
            this.tDigerBilgiler.ResumeLayout(false);
            this.gSirketler.ResumeLayout(false);
            this.gAnahtarKelimeler.ResumeLayout(false);
            this.gFilmCekimYerleri.ResumeLayout(false);
            this.gFilmCekimYerleri.PerformLayout();
            this.tKadro.ResumeLayout(false);
            this.gOyuncuKadrosu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oyuncuKadrosu)).EndInit();
            this.gYazarlar.ResumeLayout(false);
            this.gYonetmenler.ResumeLayout(false);
            this.tGenelBilgiler.ResumeLayout(false);
            this.gGenelBilgiler.ResumeLayout(false);
            this.gGenelBilgiler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pFilmAfisi)).EndInit();
            this.filmAyarlari.ResumeLayout(false);
            this.tDigerKisiler.ResumeLayout(false);
            this.gBilgiler.ResumeLayout(false);
            this.gBilgiler.PerformLayout();
            this.tOduller.ResumeLayout(false);
            this.gDurum.ResumeLayout(false);
            this.gDurum.PerformLayout();
            this.tEglencelik.ResumeLayout(false);
            this.tabEglencelik.ResumeLayout(false);
            this.tOlayOrgusu.ResumeLayout(false);
            this.tReklamsalSozler.ResumeLayout(false);
            this.tCrazyCredits.ResumeLayout(false);
            this.tCekimGercegi.ResumeLayout(false);
            this.tHatalar.ResumeLayout(false);
            this.tReplikler.ResumeLayout(false);
            this.tReferanslar.ResumeLayout(false);
            this.tMuzikler.ResumeLayout(false);
            this.tBolumler.ResumeLayout(false);
            this.tBolumler.PerformLayout();
            this.gBolumBilgileri.ResumeLayout(false);
            this.gBolumBilgileri.PerformLayout();
            this.kisiEklemeMenusu.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        



        
        



        #endregion

        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabPage tDetaylar;
        private System.Windows.Forms.GroupBox gBaskaIsimler;
        private System.Windows.Forms.GroupBox gResmiWebSayfalari;
        private System.Windows.Forms.Button btnWebSayfasiEkle;
        private System.Windows.Forms.TextBox txtWebSayfasi;
        private System.Windows.Forms.TabPage tDigerBilgiler;
        private System.Windows.Forms.Button btnTumAnahtarKelimeleriSil;
        private System.Windows.Forms.Button btnDosyadanAnahtarKelimelerAl;
        private System.Windows.Forms.Button btnAnahtarKelimeEkle;
        private System.Windows.Forms.Button btnAnahtarKelimeSil;
        private System.Windows.Forms.TabPage tKadro;
        private System.Windows.Forms.GroupBox gOyuncuKadrosu;
        private System.Windows.Forms.Button btnYeniOyuncu;
        private System.Windows.Forms.Button btnSeceneklerOyunK;
        private System.Windows.Forms.GroupBox gYazarlar;
        private System.Windows.Forms.Button btnSeceneklerYazK;
        private System.Windows.Forms.Button btnYeniYazar;
        private System.Windows.Forms.GroupBox gYonetmenler;
        private System.Windows.Forms.Button btnSeceneklerYonK;
        private System.Windows.Forms.Button btnYeniYonetmen;
        private System.Windows.Forms.TabPage tGenelBilgiler;
        private System.Windows.Forms.GroupBox gGenelBilgiler;
        private System.Windows.Forms.CheckedListBox chlTurListesi;
        private System.Windows.Forms.Label lFilmTuru;
        private System.Windows.Forms.Label lDakika;
        private System.Windows.Forms.Label lFilmTarihi;
        private System.Windows.Forms.Label lCikisTarihi;
        private System.Windows.Forms.Label lFilmAdi;
        private System.Windows.Forms.TextBox txtFilmAdi;
        private System.Windows.Forms.PictureBox pFilmAfisi;
        private System.Windows.Forms.TabControl filmAyarlari;
        private System.Windows.Forms.ContextMenuStrip kisiEklemeMenusu;
        private System.Windows.Forms.ToolStripMenuItem kütüphanedenEkleToolStripMenuItem;
        private System.Windows.Forms.Label lOrnekImdbID;
        private System.Windows.Forms.Label lIMDBPuani;
        private System.Windows.Forms.Label lIMDBId;
        private System.Windows.Forms.Button btnYonetmenSil;
        private System.Windows.Forms.Button btnOyuncuSil;
        private System.Windows.Forms.Button btnYazarSil;
        private System.Windows.Forms.ListView lvYonetmenler;
        private System.Windows.Forms.ImageList kisiResimleri;
        private System.Windows.Forms.ListView lvYazarlar;
        private System.Windows.Forms.DataGridView oyuncuKadrosu;
        private System.Windows.Forms.GroupBox gAnahtarKelimeler;
        private System.Windows.Forms.GroupBox gFilmCekimYerleri;
        private System.Windows.Forms.ListBox lbFilmCekimYerleri;
        private System.Windows.Forms.TextBox txtFilmCekimYeri;
        private System.Windows.Forms.Button btnFilmCekimYeriEkle;
        private System.Windows.Forms.TextBox txtImdbID;
        private System.Windows.Forms.TabPage tEglencelik;
        private System.Windows.Forms.TabControl tabEglencelik;
        private System.Windows.Forms.TabPage tReklamsalSozler;
        private System.Windows.Forms.TabPage tOlayOrgusu;
        private listeLabelKontrolu llkReklamsalSoz;
        private System.Windows.Forms.Button btnReklamSozuEkle;
        private System.Windows.Forms.Button btnOlayOrgusuEkle;
        private System.Windows.Forms.TabPage tCrazyCredits;
        private System.Windows.Forms.Button btnCrazyCreditEkle;
        private listeLabelKontrolu llkGaripGercek;
        private System.Windows.Forms.TabPage tCekimGercegi;
        private System.Windows.Forms.Button btnCekimGercegiEkle;
        private listeLabelKontrolu llkCekimGercegiGezinti;
        private System.Windows.Forms.TextBox txtImdbPuani;
        private System.Windows.Forms.TextBox txtFilmSuresi;
        private System.Windows.Forms.TabPage tDigerKisiler;
        private System.Windows.Forms.TreeView tvOyuncuKadrosu;
        private System.Windows.Forms.GroupBox gDüzenle;
        private System.Windows.Forms.GroupBox gBilgiler;
        private System.Windows.Forms.Label lGorevDurumu;
        private System.Windows.Forms.Label lGorevAciklama;
        private System.Windows.Forms.Label lID;
        private System.Windows.Forms.Label lIsim;
        private System.Windows.Forms.Label lGosterKutuphaneDurumu;
        private System.Windows.Forms.Label lGosterGorevAciklama;
        private System.Windows.Forms.Label lGosterID;
        private System.Windows.Forms.Label lGosterIsim;
        private System.Windows.Forms.Label lGosterDepartmanGorev;
        private System.Windows.Forms.Label lDepartmanGorev;
        private System.Windows.Forms.DataGridView dgvIsimUlke;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ulke;
        private System.Windows.Forms.FlowLayoutPanel flpLinkTutucu;
        private System.Windows.Forms.ContextMenuStrip cmsLinkSaklayici;
        private System.Windows.Forms.ToolStripTextBox tstxtLinkDuzenle;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ListBox lbAnahtarKelimeler;
        private System.Windows.Forms.TabPage tOduller;
        private System.Windows.Forms.GroupBox gDuzenle;
        private System.Windows.Forms.GroupBox gDurum;
        private System.Windows.Forms.Label lAlanKisi;
        private System.Windows.Forms.Label lKategori;
        private System.Windows.Forms.Label lSonuc;
        private System.Windows.Forms.Label lYil;
        private System.Windows.Forms.Label lGosterAlanKisi;
        private System.Windows.Forms.Label lGosterKategori;
        private System.Windows.Forms.Label lGosterSonuc;
        private System.Windows.Forms.Label lGosterYil;
        private System.Windows.Forms.Label lGosterOdulVerenKurum;
        private System.Windows.Forms.Label lOdulVerenKurum;
        private System.Windows.Forms.TreeView tvOduller;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCikisTarihi;
        private System.Windows.Forms.DataGridViewImageColumn Vesikalik;
        private System.Windows.Forms.DataGridViewLinkColumn OyuncuAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn KarakterAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn imdbIDSutunu;
        private System.Windows.Forms.TextBox txtOynadigiTarihler;
        private System.Windows.Forms.Label lOynadigiTarihler;
        private System.Windows.Forms.GroupBox gSirketler;
        private System.Windows.Forms.TreeView tvSirketler;
        private System.Windows.Forms.TabPage tHatalar;
        private System.Windows.Forms.Button btnHataEkle;
        private listeLabelKontrolu llkHatalarGezgini;
        private System.Windows.Forms.TabPage tReplikler;
        private System.Windows.Forms.Button btnReplikEkle;
        private listeLabelKontrolu llkRepliklerGezgini;
        private System.Windows.Forms.TabPage tReferanslar;
        private System.Windows.Forms.TabPage tMuzikler;
        private System.Windows.Forms.Button btnReferansEkle;
        private listeLabelKontrolu llkReferansGezici;
        private System.Windows.Forms.Button btnMuzikEkle;
        private listeLabelKontrolu llkMuzikGezici;
        private System.Windows.Forms.TabPage tBolumler;
        private System.Windows.Forms.GroupBox gBolumBilgileri;
        private System.Windows.Forms.ListView lvBolumler;
        private System.Windows.Forms.ListView lvSezonlar;
        private System.Windows.Forms.RichTextBox rchtxtBolumOzeti;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBolumID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBolumCikisTarihi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBolumAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private listeLabelKontrolu llkOlayOrgusu;
        private System.Windows.Forms.Button btnOlayOrgusuSil;
        private System.Windows.Forms.Button btnSloganSil;
        private System.Windows.Forms.Button btnGaripGercekSil;
        private System.Windows.Forms.Button btnCekimGercegiSil;
        private System.Windows.Forms.Button btnHataSil;
        private System.Windows.Forms.Button btnReplikSil;
        private System.Windows.Forms.Button btnReferansSil;
        private System.Windows.Forms.Button btnMuzikSil;
        private System.Windows.Forms.Label lButce;
        private System.Windows.Forms.TextBox txtButce;
        private System.Windows.Forms.GroupBox gDil;
        private System.Windows.Forms.Button btnDilEkle;
        private System.Windows.Forms.ComboBox cmbDil;
        private System.Windows.Forms.Button btnDilSil;
        private System.Windows.Forms.GroupBox gUlke;
        private System.Windows.Forms.ComboBox cmbUlke;
        private System.Windows.Forms.Button btnUlkeEkle;
        private System.Windows.Forms.Button btnUlkeSil;
        private System.Windows.Forms.FlowLayoutPanel fwpDiller;
        private System.Windows.Forms.FlowLayoutPanel fwpUlkeler;
    }
}