namespace MMC_Filmograf
{
    partial class f_AnaPencere
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_AnaPencere));
            this.DurumCubugu = new System.Windows.Forms.StatusStrip();
            this.kutuphaneFilmSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.kutuphaneDiziSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslKisiSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspIlerlemeCubugu = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslDurumBilgisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.filmKisiListesiMenusu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ciciGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem18 = new System.Windows.Forms.ToolStripSeparator();
            this.yenileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.bilgileriGüncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farklıKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem17 = new System.Windows.Forms.ToolStripSeparator();
            this.kesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kopyalaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.yapıştırToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem19 = new System.Windows.Forms.ToolStripSeparator();
            this.silToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fkBuyukResimler = new System.Windows.Forms.ImageList(this.components);
            this.dosyaKaydetDiyalokKutusu = new System.Windows.Forms.SaveFileDialog();
            this.dosyaAcDiyalokKutusu = new System.Windows.Forms.OpenFileDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.fkKucukResimler = new System.Windows.Forms.ImageList(this.components);
            this.arkaPlanCalistirici = new System.ComponentModel.BackgroundWorker();
            this.filmKisiListesi = new System.Windows.Forms.ListView();
            this.filmAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cikisYili = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filmSuresi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ehAnaMenu = new System.Windows.Forms.Integration.ElementHost();
            this.mmcf_AnaMenu1 = new MMC_Filmograf.mmcf_AnaMenu();
            this.AracCubugu = new System.Windows.Forms.ToolStrip();
            this.yeniKutuphane = new System.Windows.Forms.ToolStripButton();
            this.kutuphaneAc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.kutuphaneyiKaydet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.manuelFilmEkle = new System.Windows.Forms.ToolStripButton();
            this.arastirarakFilmEkle = new System.Windows.Forms.ToolStripButton();
            this.dosyadanFilmEkle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.manuelKisiEkle = new System.Windows.Forms.ToolStripButton();
            this.arastirarakKisiEkle = new System.Windows.Forms.ToolStripButton();
            this.dosyadanKisiEkle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Kess = new System.Windows.Forms.ToolStripButton();
            this.Kopyalaa = new System.Windows.Forms.ToolStripButton();
            this.Yapistirr = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.kutuphaneAramaMetni = new System.Windows.Forms.ToolStripTextBox();
            this.kutuphaneAra = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.istatistikleriGoster = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.DurumCubugu.SuspendLayout();
            this.filmKisiListesiMenusu.SuspendLayout();
            this.AracCubugu.SuspendLayout();
            this.SuspendLayout();
            // 
            // DurumCubugu
            // 
            this.DurumCubugu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kutuphaneFilmSayisi,
            this.kutuphaneDiziSayisi,
            this.tsslKisiSayisi,
            this.tspIlerlemeCubugu,
            this.tsslDurumBilgisi});
            this.DurumCubugu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.DurumCubugu.Location = new System.Drawing.Point(0, 444);
            this.DurumCubugu.Name = "DurumCubugu";
            this.DurumCubugu.Size = new System.Drawing.Size(828, 22);
            this.DurumCubugu.TabIndex = 1;
            this.DurumCubugu.Text = "Durum Çubugu";
            // 
            // kutuphaneFilmSayisi
            // 
            this.kutuphaneFilmSayisi.AutoSize = false;
            this.kutuphaneFilmSayisi.Name = "kutuphaneFilmSayisi";
            this.kutuphaneFilmSayisi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.kutuphaneFilmSayisi.Size = new System.Drawing.Size(60, 17);
            this.kutuphaneFilmSayisi.Text = "         ";
            this.kutuphaneFilmSayisi.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // kutuphaneDiziSayisi
            // 
            this.kutuphaneDiziSayisi.AutoSize = false;
            this.kutuphaneDiziSayisi.Name = "kutuphaneDiziSayisi";
            this.kutuphaneDiziSayisi.Size = new System.Drawing.Size(50, 17);
            // 
            // tsslKisiSayisi
            // 
            this.tsslKisiSayisi.AutoSize = false;
            this.tsslKisiSayisi.Name = "tsslKisiSayisi";
            this.tsslKisiSayisi.Size = new System.Drawing.Size(60, 17);
            // 
            // tspIlerlemeCubugu
            // 
            this.tspIlerlemeCubugu.Margin = new System.Windows.Forms.Padding(1, 3, 10, 3);
            this.tspIlerlemeCubugu.Name = "tspIlerlemeCubugu";
            this.tspIlerlemeCubugu.Size = new System.Drawing.Size(150, 16);
            this.tspIlerlemeCubugu.Visible = false;
            // 
            // tsslDurumBilgisi
            // 
            this.tsslDurumBilgisi.AutoSize = false;
            this.tsslDurumBilgisi.Name = "tsslDurumBilgisi";
            this.tsslDurumBilgisi.Size = new System.Drawing.Size(250, 17);
            this.tsslDurumBilgisi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslDurumBilgisi.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // filmKisiListesiMenusu
            // 
            this.filmKisiListesiMenusu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciciGösterToolStripMenuItem,
            this.toolStripMenuItem18,
            this.yenileToolStripMenuItem,
            this.düzenleToolStripMenuItem2,
            this.toolStripMenuItem8,
            this.bilgileriGüncelleToolStripMenuItem,
            this.farklıKaydetToolStripMenuItem,
            this.toolStripMenuItem17,
            this.kesToolStripMenuItem1,
            this.kopyalaToolStripMenuItem1,
            this.yapıştırToolStripMenuItem,
            this.toolStripMenuItem19,
            this.silToolStripMenuItem2});
            this.filmKisiListesiMenusu.Name = "filmKisiListesiMenusu";
            this.filmKisiListesiMenusu.Size = new System.Drawing.Size(163, 226);
            this.filmKisiListesiMenusu.Opening += new System.ComponentModel.CancelEventHandler(this.filmKisiListesiMenusu_Opening);
            // 
            // ciciGösterToolStripMenuItem
            // 
            this.ciciGösterToolStripMenuItem.Name = "ciciGösterToolStripMenuItem";
            this.ciciGösterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ciciGösterToolStripMenuItem.Text = "Cici Göster";
            this.ciciGösterToolStripMenuItem.Click += new System.EventHandler(this.ciciGösterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem18
            // 
            this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            this.toolStripMenuItem18.Size = new System.Drawing.Size(159, 6);
            // 
            // yenileToolStripMenuItem
            // 
            this.yenileToolStripMenuItem.Name = "yenileToolStripMenuItem";
            this.yenileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.yenileToolStripMenuItem.Text = "Yenile";
            this.yenileToolStripMenuItem.Click += new System.EventHandler(this.yenileToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem2
            // 
            this.düzenleToolStripMenuItem2.Name = "düzenleToolStripMenuItem2";
            this.düzenleToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.düzenleToolStripMenuItem2.Text = "Düzenle";
            this.düzenleToolStripMenuItem2.Click += new System.EventHandler(this.düzenleToolStripMenuItem2_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(159, 6);
            // 
            // bilgileriGüncelleToolStripMenuItem
            // 
            this.bilgileriGüncelleToolStripMenuItem.Name = "bilgileriGüncelleToolStripMenuItem";
            this.bilgileriGüncelleToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.bilgileriGüncelleToolStripMenuItem.Text = "Bilgileri Güncelle";
            this.bilgileriGüncelleToolStripMenuItem.Click += new System.EventHandler(this.bilgileriGuncelleToolStripMenuItem_Click);
            // 
            // farklıKaydetToolStripMenuItem
            // 
            this.farklıKaydetToolStripMenuItem.Name = "farklıKaydetToolStripMenuItem";
            this.farklıKaydetToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.farklıKaydetToolStripMenuItem.Text = "Farklı Kaydet...";
            this.farklıKaydetToolStripMenuItem.Click += new System.EventHandler(this.farklıKaydetToolStripMenuItem_Click);
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(159, 6);
            // 
            // kesToolStripMenuItem1
            // 
            this.kesToolStripMenuItem1.Name = "kesToolStripMenuItem1";
            this.kesToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.kesToolStripMenuItem1.Text = "Kes";
            this.kesToolStripMenuItem1.Click += new System.EventHandler(this.kesToolStripMenuItem1_Click);
            // 
            // kopyalaToolStripMenuItem1
            // 
            this.kopyalaToolStripMenuItem1.Name = "kopyalaToolStripMenuItem1";
            this.kopyalaToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.kopyalaToolStripMenuItem1.Text = "Kopyala";
            this.kopyalaToolStripMenuItem1.Click += new System.EventHandler(this.kopyalaToolStripMenuItem1_Click);
            // 
            // yapıştırToolStripMenuItem
            // 
            this.yapıştırToolStripMenuItem.Name = "yapıştırToolStripMenuItem";
            this.yapıştırToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.yapıştırToolStripMenuItem.Text = "Yapıştır";
            this.yapıştırToolStripMenuItem.Click += new System.EventHandler(this.yapıştırToolStripMenuItem_Click);
            // 
            // toolStripMenuItem19
            // 
            this.toolStripMenuItem19.Name = "toolStripMenuItem19";
            this.toolStripMenuItem19.Size = new System.Drawing.Size(159, 6);
            // 
            // silToolStripMenuItem2
            // 
            this.silToolStripMenuItem2.Image = global::MMC_Filmograf.Properties.Resources.kirmizicarpi;
            this.silToolStripMenuItem2.Name = "silToolStripMenuItem2";
            this.silToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.silToolStripMenuItem2.Text = "Sil";
            this.silToolStripMenuItem2.Click += new System.EventHandler(this.silToolStripMenuItem2_Click);
            // 
            // fkBuyukResimler
            // 
            this.fkBuyukResimler.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.fkBuyukResimler.ImageSize = new System.Drawing.Size(120, 165);
            this.fkBuyukResimler.TransparentColor = System.Drawing.Color.White;
            // 
            // dosyaKaydetDiyalokKutusu
            // 
            this.dosyaKaydetDiyalokKutusu.RestoreDirectory = true;
            // 
            // dosyaAcDiyalokKutusu
            // 
            this.dosyaAcDiyalokKutusu.RestoreDirectory = true;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 441);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.splitter1.Size = new System.Drawing.Size(828, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // fkKucukResimler
            // 
            this.fkKucukResimler.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.fkKucukResimler.ImageSize = new System.Drawing.Size(20, 25);
            this.fkKucukResimler.TransparentColor = System.Drawing.Color.White;
            // 
            // arkaPlanCalistirici
            // 
            this.arkaPlanCalistirici.WorkerSupportsCancellation = true;
            this.arkaPlanCalistirici.DoWork += new System.ComponentModel.DoWorkEventHandler(this.arkaPlanCalistirici_DoWork);
            this.arkaPlanCalistirici.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.arkaPlanCalistirici_RunWorkerCompleted);
            // 
            // filmKisiListesi
            // 
            this.filmKisiListesi.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.filmKisiListesi.AllowColumnReorder = true;
            this.filmKisiListesi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filmKisiListesi.BackColor = System.Drawing.SystemColors.ControlLight;
            this.filmKisiListesi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.filmAdi,
            this.cikisYili,
            this.filmSuresi});
            this.filmKisiListesi.ContextMenuStrip = this.filmKisiListesiMenusu;
            this.filmKisiListesi.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.filmKisiListesi.FullRowSelect = true;
            this.filmKisiListesi.LargeImageList = this.fkBuyukResimler;
            this.filmKisiListesi.Location = new System.Drawing.Point(5, 58);
            this.filmKisiListesi.Margin = new System.Windows.Forms.Padding(5);
            this.filmKisiListesi.Name = "filmKisiListesi";
            this.filmKisiListesi.Size = new System.Drawing.Size(809, 381);
            this.filmKisiListesi.SmallImageList = this.fkKucukResimler;
            this.filmKisiListesi.TabIndex = 9;
            this.filmKisiListesi.UseCompatibleStateImageBehavior = false;
            // 
            // filmAdi
            // 
            this.filmAdi.Text = "Ad";
            // 
            // cikisYili
            // 
            this.cikisYili.Text = "Çıkış Yılı";
            // 
            // filmSuresi
            // 
            this.filmSuresi.Text = "Süre";
            // 
            // ehAnaMenu
            // 
            this.ehAnaMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.ehAnaMenu.Location = new System.Drawing.Point(0, 0);
            this.ehAnaMenu.Name = "ehAnaMenu";
            this.ehAnaMenu.Size = new System.Drawing.Size(828, 23);
            this.ehAnaMenu.TabIndex = 8;
            this.ehAnaMenu.Text = "ehAnaMenu";
            this.ehAnaMenu.Child = this.mmcf_AnaMenu1;
            // 
            // AracCubugu
            // 
            this.AracCubugu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AracCubugu.BackColor = System.Drawing.Color.Transparent;
            this.AracCubugu.Dock = System.Windows.Forms.DockStyle.None;
            this.AracCubugu.GripMargin = new System.Windows.Forms.Padding(3);
            this.AracCubugu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AracCubugu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKutuphane,
            this.kutuphaneAc,
            this.toolStripSeparator1,
            this.kutuphaneyiKaydet,
            this.toolStripSeparator2,
            this.manuelFilmEkle,
            this.arastirarakFilmEkle,
            this.dosyadanFilmEkle,
            this.toolStripSeparator3,
            this.manuelKisiEkle,
            this.arastirarakKisiEkle,
            this.dosyadanKisiEkle,
            this.toolStripSeparator4,
            this.Kess,
            this.Kopyalaa,
            this.Yapistirr,
            this.toolStripSeparator7,
            this.kutuphaneAramaMetni,
            this.kutuphaneAra,
            this.toolStripSeparator5,
            this.istatistikleriGoster,
            this.toolStripSeparator6});
            this.AracCubugu.Location = new System.Drawing.Point(9, 26);
            this.AracCubugu.Name = "AracCubugu";
            this.AracCubugu.Padding = new System.Windows.Forms.Padding(0);
            this.AracCubugu.Size = new System.Drawing.Size(493, 27);
            this.AracCubugu.TabIndex = 11;
            this.AracCubugu.Text = "Arac Çubugu";
            // 
            // yeniKutuphane
            // 
            this.yeniKutuphane.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.yeniKutuphane.Image = global::MMC_Filmograf.Properties.Resources.filmlerklasoru;
            this.yeniKutuphane.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.yeniKutuphane.Name = "yeniKutuphane";
            this.yeniKutuphane.Size = new System.Drawing.Size(101, 24);
            this.yeniKutuphane.Text = "Yeni Kütüphane Olustur";
            // 
            // kutuphaneAc
            // 
            this.kutuphaneAc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kutuphaneAc.Image = global::MMC_Filmograf.Properties.Resources.folder_open;
            this.kutuphaneAc.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.kutuphaneAc.Name = "kutuphaneAc";
            this.kutuphaneAc.Size = new System.Drawing.Size(101, 24);
            this.kutuphaneAc.Text = "Kütüphane ac";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(101, 6);
            // 
            // kutuphaneyiKaydet
            // 
            this.kutuphaneyiKaydet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kutuphaneyiKaydet.Image = global::MMC_Filmograf.Properties.Resources.Floppy;
            this.kutuphaneyiKaydet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kutuphaneyiKaydet.Name = "kutuphaneyiKaydet";
            this.kutuphaneyiKaydet.Size = new System.Drawing.Size(101, 24);
            this.kutuphaneyiKaydet.Text = "Kütüphaneyi kaydet";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(101, 6);
            // 
            // manuelFilmEkle
            // 
            this.manuelFilmEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.manuelFilmEkle.Image = global::MMC_Filmograf.Properties.Resources.yenifilmsimgesi;
            this.manuelFilmEkle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.manuelFilmEkle.Name = "manuelFilmEkle";
            this.manuelFilmEkle.Size = new System.Drawing.Size(101, 24);
            this.manuelFilmEkle.Text = "Manüel Film Ekle";
            // 
            // arastirarakFilmEkle
            // 
            this.arastirarakFilmEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.arastirarakFilmEkle.Image = global::MMC_Filmograf.Properties.Resources.Network;
            this.arastirarakFilmEkle.ImageTransparentColor = System.Drawing.Color.White;
            this.arastirarakFilmEkle.Name = "arastirarakFilmEkle";
            this.arastirarakFilmEkle.Size = new System.Drawing.Size(101, 24);
            this.arastirarakFilmEkle.Text = "Arastirarak Film Ekle";
            // 
            // dosyadanFilmEkle
            // 
            this.dosyadanFilmEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dosyadanFilmEkle.Image = ((System.Drawing.Image)(resources.GetObject("dosyadanFilmEkle.Image")));
            this.dosyadanFilmEkle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dosyadanFilmEkle.Name = "dosyadanFilmEkle";
            this.dosyadanFilmEkle.Size = new System.Drawing.Size(24, 24);
            this.dosyadanFilmEkle.Text = "Dosyadan Film Ekle";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(101, 6);
            // 
            // manuelKisiEkle
            // 
            this.manuelKisiEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.manuelKisiEkle.Image = global::MMC_Filmograf.Properties.Resources.kisiekle;
            this.manuelKisiEkle.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.manuelKisiEkle.Name = "manuelKisiEkle";
            this.manuelKisiEkle.Size = new System.Drawing.Size(101, 24);
            this.manuelKisiEkle.Text = "Manuel kisi ekle";
            // 
            // arastirarakKisiEkle
            // 
            this.arastirarakKisiEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.arastirarakKisiEkle.Image = global::MMC_Filmograf.Properties.Resources.Network;
            this.arastirarakKisiEkle.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.arastirarakKisiEkle.Name = "arastirarakKisiEkle";
            this.arastirarakKisiEkle.Size = new System.Drawing.Size(101, 24);
            this.arastirarakKisiEkle.Text = "Arastirarak kisi ekle";
            // 
            // dosyadanKisiEkle
            // 
            this.dosyadanKisiEkle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dosyadanKisiEkle.Image = ((System.Drawing.Image)(resources.GetObject("dosyadanKisiEkle.Image")));
            this.dosyadanKisiEkle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dosyadanKisiEkle.Name = "dosyadanKisiEkle";
            this.dosyadanKisiEkle.Size = new System.Drawing.Size(101, 24);
            this.dosyadanKisiEkle.Text = "Dosyadan Kişi Ekle";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(101, 6);
            // 
            // Kess
            // 
            this.Kess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Kess.Image = global::MMC_Filmograf.Properties.Resources.cut;
            this.Kess.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.Kess.Name = "Kess";
            this.Kess.Size = new System.Drawing.Size(101, 24);
            this.Kess.Text = "Kes";
            // 
            // Kopyalaa
            // 
            this.Kopyalaa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Kopyalaa.Image = global::MMC_Filmograf.Properties.Resources.copy;
            this.Kopyalaa.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.Kopyalaa.Name = "Kopyalaa";
            this.Kopyalaa.Size = new System.Drawing.Size(101, 24);
            this.Kopyalaa.Text = "Kopyala";
            // 
            // Yapistirr
            // 
            this.Yapistirr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Yapistirr.Image = global::MMC_Filmograf.Properties.Resources.paste;
            this.Yapistirr.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.Yapistirr.Name = "Yapistirr";
            this.Yapistirr.Size = new System.Drawing.Size(101, 24);
            this.Yapistirr.Text = "Yapıştır";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(101, 6);
            // 
            // kutuphaneAramaMetni
            // 
            this.kutuphaneAramaMetni.Name = "kutuphaneAramaMetni";
            this.kutuphaneAramaMetni.Size = new System.Drawing.Size(100, 23);
            // 
            // kutuphaneAra
            // 
            this.kutuphaneAra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kutuphaneAra.Image = global::MMC_Filmograf.Properties.Resources.Find;
            this.kutuphaneAra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kutuphaneAra.Name = "kutuphaneAra";
            this.kutuphaneAra.Size = new System.Drawing.Size(24, 24);
            this.kutuphaneAra.Text = "toolStripButton9";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // istatistikleriGoster
            // 
            this.istatistikleriGoster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.istatistikleriGoster.Image = global::MMC_Filmograf.Properties.Resources.PieDiagram;
            this.istatistikleriGoster.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.istatistikleriGoster.Name = "istatistikleriGoster";
            this.istatistikleriGoster.Size = new System.Drawing.Size(24, 24);
            this.istatistikleriGoster.Text = "Istatistikleri Goster";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // f_AnaPencere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 466);
            this.Controls.Add(this.AracCubugu);
            this.Controls.Add(this.ehAnaMenu);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.filmKisiListesi);
            this.Controls.Add(this.DurumCubugu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_AnaPencere";
            this.Text = "MMC Filmograf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_AnaPencere_FormClosing);
            this.Load += new System.EventHandler(this.f_AnaPencere_Load);
            this.DurumCubugu.ResumeLayout(false);
            this.DurumCubugu.PerformLayout();
            this.filmKisiListesiMenusu.ResumeLayout(false);
            this.AracCubugu.ResumeLayout(false);
            this.AracCubugu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip DurumCubugu;
        private System.Windows.Forms.SaveFileDialog dosyaKaydetDiyalokKutusu;
        private System.Windows.Forms.OpenFileDialog dosyaAcDiyalokKutusu;
        private System.Windows.Forms.ToolStripStatusLabel kutuphaneFilmSayisi;
        private System.Windows.Forms.ContextMenuStrip filmKisiListesiMenusu;
        private System.Windows.Forms.ToolStripMenuItem yenileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem farklıKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem17;
        private System.Windows.Forms.ToolStripMenuItem kesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kopyalaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem yapıştırToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciciGösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem18;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem19;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem2;
        private System.Windows.Forms.Splitter splitter1;
        protected System.Windows.Forms.ImageList fkBuyukResimler;
        private System.Windows.Forms.ToolStripMenuItem bilgileriGüncelleToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar tspIlerlemeCubugu;
        private System.Windows.Forms.ToolStripStatusLabel tsslDurumBilgisi;
        protected System.Windows.Forms.ImageList fkKucukResimler;
        private System.Windows.Forms.ToolStripStatusLabel kutuphaneDiziSayisi;
        private System.ComponentModel.BackgroundWorker arkaPlanCalistirici;
        private System.Windows.Forms.ToolStripStatusLabel tsslKisiSayisi;
        private System.Windows.Forms.Integration.ElementHost ehAnaMenu;
        private mmcf_AnaMenu mmcf_AnaMenu1;
        private System.Windows.Forms.ListView filmKisiListesi;
        private System.Windows.Forms.ColumnHeader filmAdi;
        private System.Windows.Forms.ColumnHeader cikisYili;
        private System.Windows.Forms.ColumnHeader filmSuresi;
        private System.Windows.Forms.ToolStrip AracCubugu;
        private System.Windows.Forms.ToolStripButton yeniKutuphane;
        private System.Windows.Forms.ToolStripButton kutuphaneAc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton kutuphaneyiKaydet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton manuelFilmEkle;
        private System.Windows.Forms.ToolStripButton arastirarakFilmEkle;
        private System.Windows.Forms.ToolStripButton dosyadanFilmEkle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton manuelKisiEkle;
        private System.Windows.Forms.ToolStripButton arastirarakKisiEkle;
        private System.Windows.Forms.ToolStripButton dosyadanKisiEkle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton Kess;
        private System.Windows.Forms.ToolStripButton Kopyalaa;
        private System.Windows.Forms.ToolStripButton Yapistirr;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripTextBox kutuphaneAramaMetni;
        private System.Windows.Forms.ToolStripButton kutuphaneAra;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton istatistikleriGoster;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}

