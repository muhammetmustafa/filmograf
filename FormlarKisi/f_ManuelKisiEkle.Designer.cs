namespace MMC_Filmograf
{
    partial class f_ManuelKisiEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ManuelKisiEkle));
            this.tGenelBilgiler = new System.Windows.Forms.TabPage();
            this.gGenelBilgiler = new System.Windows.Forms.GroupBox();
            this.txtImdbID = new System.Windows.Forms.TextBox();
            this.txtDogumTarihi = new System.Windows.Forms.TextBox();
            this.lKarakterAdi = new System.Windows.Forms.Label();
            this.txtKarakterAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCinsiyet = new System.Windows.Forms.ComboBox();
            this.lCinsiyet = new System.Windows.Forms.Label();
            this.lDogumYeri = new System.Windows.Forms.Label();
            this.txtDogumYeri = new System.Windows.Forms.TextBox();
            this.cUnvan = new System.Windows.Forms.ComboBox();
            this.lKisiUnvani = new System.Windows.Forms.Label();
            this.lIMDBId = new System.Windows.Forms.Label();
            this.lCikisTarihi = new System.Windows.Forms.Label();
            this.lKisiAdi = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.lResim = new System.Windows.Forms.Label();
            this.pResim = new System.Windows.Forms.PictureBox();
            this.filmAyarlari = new System.Windows.Forms.TabControl();
            this.tbAyrintilar = new System.Windows.Forms.TabPage();
            this.btnOzgecmisEkle = new System.Windows.Forms.Button();
            this.txtOzGecmis = new System.Windows.Forms.RichTextBox();
            this.lOzGecmis = new System.Windows.Forms.Label();
            this.gOduller = new System.Windows.Forms.GroupBox();
            this.btnKazandigiParaEkle = new System.Windows.Forms.Button();
            this.dgvKazandigiParalar = new System.Windows.Forms.DataGridView();
            this.film = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gResmiWebSayfalari = new System.Windows.Forms.GroupBox();
            this.yeniResmiWebSayfasiEkle = new System.Windows.Forms.Button();
            this.flpLinkTutucu = new System.Windows.Forms.FlowLayoutPanel();
            this.txtResmiWebSayfasi = new System.Windows.Forms.TextBox();
            this.tGercekler = new System.Windows.Forms.TabPage();
            this.btnKisiselSozuSil = new System.Windows.Forms.Button();
            this.btnHakkindakiGercegiSil = new System.Windows.Forms.Button();
            this.btnKisiselSozEkle = new System.Windows.Forms.Button();
            this.btnGercekEkle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.llkKisiselSozler = new MMC_Filmograf.listeLabelKontrolu();
            this.llkGercekler = new MMC_Filmograf.listeLabelKontrolu();
            this.tDigerAyrintilar = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTakmaAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDogumAdi = new System.Windows.Forms.TextBox();
            this.gBurclar = new System.Windows.Forms.GroupBox();
            this.rbBurc11 = new System.Windows.Forms.RadioButton();
            this.burcResimleri = new System.Windows.Forms.ImageList(this.components);
            this.rbBurc10 = new System.Windows.Forms.RadioButton();
            this.rbBurc9 = new System.Windows.Forms.RadioButton();
            this.rbBurc8 = new System.Windows.Forms.RadioButton();
            this.rbBurc7 = new System.Windows.Forms.RadioButton();
            this.rbBurc6 = new System.Windows.Forms.RadioButton();
            this.rbBurc5 = new System.Windows.Forms.RadioButton();
            this.rbBurc4 = new System.Windows.Forms.RadioButton();
            this.rbBurc3 = new System.Windows.Forms.RadioButton();
            this.rbBurc2 = new System.Windows.Forms.RadioButton();
            this.rbBurc1 = new System.Windows.Forms.RadioButton();
            this.rbBurc0 = new System.Windows.Forms.RadioButton();
            this.gBoyUzunlugu = new System.Windows.Forms.GroupBox();
            this.lBoyUzunlugu = new System.Windows.Forms.Label();
            this.tbBoyBelirtici = new System.Windows.Forms.TrackBar();
            this.iptal = new System.Windows.Forms.Button();
            this.Tamam = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmsLinkSaklayici = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tstxtLinkDuzenle = new System.Windows.Forms.ToolStripTextBox();
            this.kaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tGenelBilgiler.SuspendLayout();
            this.gGenelBilgiler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pResim)).BeginInit();
            this.filmAyarlari.SuspendLayout();
            this.tbAyrintilar.SuspendLayout();
            this.gOduller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKazandigiParalar)).BeginInit();
            this.gResmiWebSayfalari.SuspendLayout();
            this.tGercekler.SuspendLayout();
            this.tDigerAyrintilar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gBurclar.SuspendLayout();
            this.gBoyUzunlugu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBoyBelirtici)).BeginInit();
            this.cmsLinkSaklayici.SuspendLayout();
            this.SuspendLayout();
            // 
            // tGenelBilgiler
            // 
            this.tGenelBilgiler.BackColor = System.Drawing.Color.Gainsboro;
            this.tGenelBilgiler.Controls.Add(this.gGenelBilgiler);
            this.tGenelBilgiler.Controls.Add(this.lResim);
            this.tGenelBilgiler.Controls.Add(this.pResim);
            this.tGenelBilgiler.Location = new System.Drawing.Point(4, 22);
            this.tGenelBilgiler.Name = "tGenelBilgiler";
            this.tGenelBilgiler.Padding = new System.Windows.Forms.Padding(3);
            this.tGenelBilgiler.Size = new System.Drawing.Size(670, 332);
            this.tGenelBilgiler.TabIndex = 0;
            this.tGenelBilgiler.Text = "Genel Bilgiler";
            // 
            // gGenelBilgiler
            // 
            this.gGenelBilgiler.Controls.Add(this.txtImdbID);
            this.gGenelBilgiler.Controls.Add(this.txtDogumTarihi);
            this.gGenelBilgiler.Controls.Add(this.lKarakterAdi);
            this.gGenelBilgiler.Controls.Add(this.txtKarakterAdi);
            this.gGenelBilgiler.Controls.Add(this.label1);
            this.gGenelBilgiler.Controls.Add(this.cmbCinsiyet);
            this.gGenelBilgiler.Controls.Add(this.lCinsiyet);
            this.gGenelBilgiler.Controls.Add(this.lDogumYeri);
            this.gGenelBilgiler.Controls.Add(this.txtDogumYeri);
            this.gGenelBilgiler.Controls.Add(this.cUnvan);
            this.gGenelBilgiler.Controls.Add(this.lKisiUnvani);
            this.gGenelBilgiler.Controls.Add(this.lIMDBId);
            this.gGenelBilgiler.Controls.Add(this.lCikisTarihi);
            this.gGenelBilgiler.Controls.Add(this.lKisiAdi);
            this.gGenelBilgiler.Controls.Add(this.txtAd);
            this.gGenelBilgiler.Location = new System.Drawing.Point(231, 22);
            this.gGenelBilgiler.Name = "gGenelBilgiler";
            this.gGenelBilgiler.Size = new System.Drawing.Size(428, 292);
            this.gGenelBilgiler.TabIndex = 1;
            this.gGenelBilgiler.TabStop = false;
            this.gGenelBilgiler.Text = "Genel Bilgiler";
            // 
            // txtImdbID
            // 
            this.txtImdbID.Location = new System.Drawing.Point(107, 58);
            this.txtImdbID.MaxLength = 9;
            this.txtImdbID.Name = "txtImdbID";
            this.txtImdbID.Size = new System.Drawing.Size(100, 20);
            this.txtImdbID.TabIndex = 20;
            // 
            // txtDogumTarihi
            // 
            this.txtDogumTarihi.Location = new System.Drawing.Point(107, 117);
            this.txtDogumTarihi.Name = "txtDogumTarihi";
            this.txtDogumTarihi.Size = new System.Drawing.Size(153, 20);
            this.txtDogumTarihi.TabIndex = 19;
            // 
            // lKarakterAdi
            // 
            this.lKarakterAdi.AutoSize = true;
            this.lKarakterAdi.Location = new System.Drawing.Point(17, 248);
            this.lKarakterAdi.Name = "lKarakterAdi";
            this.lKarakterAdi.Size = new System.Drawing.Size(65, 13);
            this.lKarakterAdi.TabIndex = 18;
            this.lKarakterAdi.Text = "Karakter Adı";
            // 
            // txtKarakterAdi
            // 
            this.txtKarakterAdi.Location = new System.Drawing.Point(107, 245);
            this.txtKarakterAdi.Name = "txtKarakterAdi";
            this.txtKarakterAdi.Size = new System.Drawing.Size(153, 20);
            this.txtKarakterAdi.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(213, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "Örnek: (nm)0980970";
            // 
            // cmbCinsiyet
            // 
            this.cmbCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCinsiyet.FormattingEnabled = true;
            this.cmbCinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Kadin"});
            this.cmbCinsiyet.Location = new System.Drawing.Point(107, 177);
            this.cmbCinsiyet.Name = "cmbCinsiyet";
            this.cmbCinsiyet.Size = new System.Drawing.Size(100, 21);
            this.cmbCinsiyet.TabIndex = 7;
            // 
            // lCinsiyet
            // 
            this.lCinsiyet.AutoSize = true;
            this.lCinsiyet.Location = new System.Drawing.Point(17, 182);
            this.lCinsiyet.Name = "lCinsiyet";
            this.lCinsiyet.Size = new System.Drawing.Size(43, 13);
            this.lCinsiyet.TabIndex = 14;
            this.lCinsiyet.Text = "Cinsiyet";
            // 
            // lDogumYeri
            // 
            this.lDogumYeri.AutoSize = true;
            this.lDogumYeri.Location = new System.Drawing.Point(17, 151);
            this.lDogumYeri.Name = "lDogumYeri";
            this.lDogumYeri.Size = new System.Drawing.Size(62, 13);
            this.lDogumYeri.TabIndex = 12;
            this.lDogumYeri.Text = "Doğum Yeri";
            // 
            // txtDogumYeri
            // 
            this.txtDogumYeri.Location = new System.Drawing.Point(107, 147);
            this.txtDogumYeri.Name = "txtDogumYeri";
            this.txtDogumYeri.Size = new System.Drawing.Size(153, 20);
            this.txtDogumYeri.TabIndex = 6;
            // 
            // cUnvan
            // 
            this.cUnvan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cUnvan.FormattingEnabled = true;
            this.cUnvan.Items.AddRange(new object[] {
            "Belirsiz",
            "Yönetmen",
            "Yazar",
            "Oyuncu"});
            this.cUnvan.Location = new System.Drawing.Point(107, 28);
            this.cUnvan.Name = "cUnvan";
            this.cUnvan.Size = new System.Drawing.Size(130, 21);
            this.cUnvan.TabIndex = 2;
            // 
            // lKisiUnvani
            // 
            this.lKisiUnvani.AutoSize = true;
            this.lKisiUnvani.Location = new System.Drawing.Point(17, 32);
            this.lKisiUnvani.Name = "lKisiUnvani";
            this.lKisiUnvani.Size = new System.Drawing.Size(60, 13);
            this.lKisiUnvani.TabIndex = 2;
            this.lKisiUnvani.Text = "Kişi Ünvanı";
            // 
            // lIMDBId
            // 
            this.lIMDBId.AutoSize = true;
            this.lIMDBId.Location = new System.Drawing.Point(17, 61);
            this.lIMDBId.Name = "lIMDBId";
            this.lIMDBId.Size = new System.Drawing.Size(46, 13);
            this.lIMDBId.TabIndex = 8;
            this.lIMDBId.Text = "IMBD Id";
            // 
            // lCikisTarihi
            // 
            this.lCikisTarihi.AutoSize = true;
            this.lCikisTarihi.Location = new System.Drawing.Point(17, 121);
            this.lCikisTarihi.Name = "lCikisTarihi";
            this.lCikisTarihi.Size = new System.Drawing.Size(70, 13);
            this.lCikisTarihi.TabIndex = 10;
            this.lCikisTarihi.Text = "Doğum Tarihi";
            // 
            // lKisiAdi
            // 
            this.lKisiAdi.AutoSize = true;
            this.lKisiAdi.Location = new System.Drawing.Point(17, 92);
            this.lKisiAdi.Name = "lKisiAdi";
            this.lKisiAdi.Size = new System.Drawing.Size(20, 13);
            this.lKisiAdi.TabIndex = 4;
            this.lKisiAdi.Text = "Ad";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(107, 88);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(153, 20);
            this.txtAd.TabIndex = 3;
            // 
            // lResim
            // 
            this.lResim.AutoSize = true;
            this.lResim.Location = new System.Drawing.Point(13, 13);
            this.lResim.Name = "lResim";
            this.lResim.Size = new System.Drawing.Size(36, 13);
            this.lResim.TabIndex = 0;
            this.lResim.Text = "Resim";
            // 
            // pResim
            // 
            this.pResim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pResim.Image = global::MMC_Filmograf.Properties.Resources.Kisi;
            this.pResim.Location = new System.Drawing.Point(16, 29);
            this.pResim.Name = "pResim";
            this.pResim.Size = new System.Drawing.Size(209, 285);
            this.pResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pResim.TabIndex = 3;
            this.pResim.TabStop = false;
            this.pResim.DoubleClick += new System.EventHandler(this.pResim_DoubleClick);
            // 
            // filmAyarlari
            // 
            this.filmAyarlari.Controls.Add(this.tGenelBilgiler);
            this.filmAyarlari.Controls.Add(this.tbAyrintilar);
            this.filmAyarlari.Controls.Add(this.tGercekler);
            this.filmAyarlari.Controls.Add(this.tDigerAyrintilar);
            this.filmAyarlari.Location = new System.Drawing.Point(7, 7);
            this.filmAyarlari.Name = "filmAyarlari";
            this.filmAyarlari.SelectedIndex = 0;
            this.filmAyarlari.Size = new System.Drawing.Size(678, 358);
            this.filmAyarlari.TabIndex = 1;
            // 
            // tbAyrintilar
            // 
            this.tbAyrintilar.BackColor = System.Drawing.Color.Gainsboro;
            this.tbAyrintilar.Controls.Add(this.btnOzgecmisEkle);
            this.tbAyrintilar.Controls.Add(this.txtOzGecmis);
            this.tbAyrintilar.Controls.Add(this.lOzGecmis);
            this.tbAyrintilar.Controls.Add(this.gOduller);
            this.tbAyrintilar.Controls.Add(this.gResmiWebSayfalari);
            this.tbAyrintilar.Location = new System.Drawing.Point(4, 22);
            this.tbAyrintilar.Name = "tbAyrintilar";
            this.tbAyrintilar.Size = new System.Drawing.Size(670, 332);
            this.tbAyrintilar.TabIndex = 1;
            this.tbAyrintilar.Text = "Ayrıntılar";
            // 
            // btnOzgecmisEkle
            // 
            this.btnOzgecmisEkle.FlatAppearance.BorderSize = 0;
            this.btnOzgecmisEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOzgecmisEkle.Image = global::MMC_Filmograf.Properties.Resources.yesilarti;
            this.btnOzgecmisEkle.Location = new System.Drawing.Point(648, 6);
            this.btnOzgecmisEkle.Name = "btnOzgecmisEkle";
            this.btnOzgecmisEkle.Size = new System.Drawing.Size(15, 14);
            this.btnOzgecmisEkle.TabIndex = 12;
            this.btnOzgecmisEkle.UseVisualStyleBackColor = true;
            this.btnOzgecmisEkle.Click += new System.EventHandler(this.btnOzgecmisEkle_Click);
            // 
            // txtOzGecmis
            // 
            this.txtOzGecmis.BackColor = System.Drawing.Color.Silver;
            this.txtOzGecmis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOzGecmis.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOzGecmis.Location = new System.Drawing.Point(7, 24);
            this.txtOzGecmis.Name = "txtOzGecmis";
            this.txtOzGecmis.Size = new System.Drawing.Size(656, 178);
            this.txtOzGecmis.TabIndex = 22;
            this.txtOzGecmis.Text = "";
            // 
            // lOzGecmis
            // 
            this.lOzGecmis.AutoSize = true;
            this.lOzGecmis.Location = new System.Drawing.Point(7, 6);
            this.lOzGecmis.Name = "lOzGecmis";
            this.lOzGecmis.Size = new System.Drawing.Size(58, 13);
            this.lOzGecmis.TabIndex = 21;
            this.lOzGecmis.Text = "Öz Geçmiş";
            // 
            // gOduller
            // 
            this.gOduller.Controls.Add(this.btnKazandigiParaEkle);
            this.gOduller.Controls.Add(this.dgvKazandigiParalar);
            this.gOduller.Location = new System.Drawing.Point(305, 208);
            this.gOduller.Name = "gOduller";
            this.gOduller.Size = new System.Drawing.Size(358, 116);
            this.gOduller.TabIndex = 11;
            this.gOduller.TabStop = false;
            this.gOduller.Text = "Kazandığı Paralar";
            // 
            // btnKazandigiParaEkle
            // 
            this.btnKazandigiParaEkle.FlatAppearance.BorderSize = 0;
            this.btnKazandigiParaEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKazandigiParaEkle.Image = global::MMC_Filmograf.Properties.Resources.yesilarti;
            this.btnKazandigiParaEkle.Location = new System.Drawing.Point(340, 1);
            this.btnKazandigiParaEkle.Name = "btnKazandigiParaEkle";
            this.btnKazandigiParaEkle.Size = new System.Drawing.Size(15, 14);
            this.btnKazandigiParaEkle.TabIndex = 11;
            this.btnKazandigiParaEkle.UseVisualStyleBackColor = true;
            this.btnKazandigiParaEkle.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvKazandigiParalar
            // 
            this.dgvKazandigiParalar.AllowUserToAddRows = false;
            this.dgvKazandigiParalar.AllowUserToDeleteRows = false;
            this.dgvKazandigiParalar.AllowUserToResizeRows = false;
            this.dgvKazandigiParalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKazandigiParalar.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvKazandigiParalar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKazandigiParalar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvKazandigiParalar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKazandigiParalar.ColumnHeadersHeight = 24;
            this.dgvKazandigiParalar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.film,
            this.miktar});
            this.dgvKazandigiParalar.Location = new System.Drawing.Point(6, 19);
            this.dgvKazandigiParalar.Name = "dgvKazandigiParalar";
            this.dgvKazandigiParalar.RowHeadersVisible = false;
            this.dgvKazandigiParalar.Size = new System.Drawing.Size(346, 91);
            this.dgvKazandigiParalar.TabIndex = 0;
            // 
            // film
            // 
            this.film.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.film.HeaderText = "Film";
            this.film.Name = "film";
            // 
            // miktar
            // 
            this.miktar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.miktar.HeaderText = "Aldığı Para";
            this.miktar.Name = "miktar";
            // 
            // gResmiWebSayfalari
            // 
            this.gResmiWebSayfalari.Controls.Add(this.yeniResmiWebSayfasiEkle);
            this.gResmiWebSayfalari.Controls.Add(this.flpLinkTutucu);
            this.gResmiWebSayfalari.Controls.Add(this.txtResmiWebSayfasi);
            this.gResmiWebSayfalari.Location = new System.Drawing.Point(7, 208);
            this.gResmiWebSayfalari.Name = "gResmiWebSayfalari";
            this.gResmiWebSayfalari.Size = new System.Drawing.Size(290, 116);
            this.gResmiWebSayfalari.TabIndex = 10;
            this.gResmiWebSayfalari.TabStop = false;
            this.gResmiWebSayfalari.Text = "Resmi Web Sayfalari";
            // 
            // yeniResmiWebSayfasiEkle
            // 
            this.yeniResmiWebSayfasiEkle.FlatAppearance.BorderSize = 0;
            this.yeniResmiWebSayfasiEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yeniResmiWebSayfasiEkle.Image = global::MMC_Filmograf.Properties.Resources.yesilarti;
            this.yeniResmiWebSayfasiEkle.Location = new System.Drawing.Point(259, 21);
            this.yeniResmiWebSayfasiEkle.Name = "yeniResmiWebSayfasiEkle";
            this.yeniResmiWebSayfasiEkle.Size = new System.Drawing.Size(15, 14);
            this.yeniResmiWebSayfasiEkle.TabIndex = 23;
            this.yeniResmiWebSayfasiEkle.UseVisualStyleBackColor = true;
            // 
            // flpLinkTutucu
            // 
            this.flpLinkTutucu.AutoScroll = true;
            this.flpLinkTutucu.Location = new System.Drawing.Point(6, 45);
            this.flpLinkTutucu.Name = "flpLinkTutucu";
            this.flpLinkTutucu.Size = new System.Drawing.Size(272, 65);
            this.flpLinkTutucu.TabIndex = 28;
            // 
            // txtResmiWebSayfasi
            // 
            this.txtResmiWebSayfasi.Location = new System.Drawing.Point(6, 19);
            this.txtResmiWebSayfasi.Name = "txtResmiWebSayfasi";
            this.txtResmiWebSayfasi.Size = new System.Drawing.Size(247, 20);
            this.txtResmiWebSayfasi.TabIndex = 25;
            // 
            // tGercekler
            // 
            this.tGercekler.BackColor = System.Drawing.Color.Gainsboro;
            this.tGercekler.Controls.Add(this.btnKisiselSozuSil);
            this.tGercekler.Controls.Add(this.btnHakkindakiGercegiSil);
            this.tGercekler.Controls.Add(this.btnKisiselSozEkle);
            this.tGercekler.Controls.Add(this.btnGercekEkle);
            this.tGercekler.Controls.Add(this.label5);
            this.tGercekler.Controls.Add(this.label4);
            this.tGercekler.Controls.Add(this.llkKisiselSozler);
            this.tGercekler.Controls.Add(this.llkGercekler);
            this.tGercekler.Location = new System.Drawing.Point(4, 22);
            this.tGercekler.Name = "tGercekler";
            this.tGercekler.Padding = new System.Windows.Forms.Padding(3);
            this.tGercekler.Size = new System.Drawing.Size(670, 332);
            this.tGercekler.TabIndex = 2;
            this.tGercekler.Text = "Gerçekler ve Kişisel Sözleri";
            // 
            // btnKisiselSozuSil
            // 
            this.btnKisiselSozuSil.FlatAppearance.BorderSize = 0;
            this.btnKisiselSozuSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKisiselSozuSil.Image = global::MMC_Filmograf.Properties.Resources.sil1;
            this.btnKisiselSozuSil.Location = new System.Drawing.Point(440, 167);
            this.btnKisiselSozuSil.Name = "btnKisiselSozuSil";
            this.btnKisiselSozuSil.Size = new System.Drawing.Size(15, 14);
            this.btnKisiselSozuSil.TabIndex = 27;
            this.btnKisiselSozuSil.UseVisualStyleBackColor = true;
            this.btnKisiselSozuSil.Click += new System.EventHandler(this.btnKisiselSozuSil_Click);
            // 
            // btnHakkindakiGercegiSil
            // 
            this.btnHakkindakiGercegiSil.FlatAppearance.BorderSize = 0;
            this.btnHakkindakiGercegiSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHakkindakiGercegiSil.Image = global::MMC_Filmograf.Properties.Resources.sil1;
            this.btnHakkindakiGercegiSil.Location = new System.Drawing.Point(440, 9);
            this.btnHakkindakiGercegiSil.Name = "btnHakkindakiGercegiSil";
            this.btnHakkindakiGercegiSil.Size = new System.Drawing.Size(15, 14);
            this.btnHakkindakiGercegiSil.TabIndex = 26;
            this.btnHakkindakiGercegiSil.UseVisualStyleBackColor = true;
            this.btnHakkindakiGercegiSil.Click += new System.EventHandler(this.btnHakkindakiGercegiSil_Click);
            // 
            // btnKisiselSozEkle
            // 
            this.btnKisiselSozEkle.FlatAppearance.BorderSize = 0;
            this.btnKisiselSozEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKisiselSozEkle.Image = global::MMC_Filmograf.Properties.Resources.yesilarti;
            this.btnKisiselSozEkle.Location = new System.Drawing.Point(461, 167);
            this.btnKisiselSozEkle.Name = "btnKisiselSozEkle";
            this.btnKisiselSozEkle.Size = new System.Drawing.Size(15, 14);
            this.btnKisiselSozEkle.TabIndex = 25;
            this.btnKisiselSozEkle.UseVisualStyleBackColor = true;
            this.btnKisiselSozEkle.Click += new System.EventHandler(this.btnKisiselSozEkle_Click);
            // 
            // btnGercekEkle
            // 
            this.btnGercekEkle.FlatAppearance.BorderSize = 0;
            this.btnGercekEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGercekEkle.Image = global::MMC_Filmograf.Properties.Resources.yesilarti;
            this.btnGercekEkle.Location = new System.Drawing.Point(461, 9);
            this.btnGercekEkle.Name = "btnGercekEkle";
            this.btnGercekEkle.Size = new System.Drawing.Size(15, 14);
            this.btnGercekEkle.TabIndex = 24;
            this.btnGercekEkle.UseVisualStyleBackColor = true;
            this.btnGercekEkle.Click += new System.EventHandler(this.btnGercekEkle_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kişisel Sözleri";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hakkındaki Gerçekler";
            // 
            // llkKisiselSozler
            // 
            this.llkKisiselSozler.BackColor = System.Drawing.Color.Gainsboro;
            this.llkKisiselSozler.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkKisiselSozler.GosterilecekListe")));
            this.llkKisiselSozler.Location = new System.Drawing.Point(6, 163);
            this.llkKisiselSozler.Name = "llkKisiselSozler";
            this.llkKisiselSozler.Size = new System.Drawing.Size(658, 157);
            this.llkKisiselSozler.TabIndex = 2;
            // 
            // llkGercekler
            // 
            this.llkGercekler.BackColor = System.Drawing.Color.Gainsboro;
            this.llkGercekler.GosterilecekListe = ((System.Collections.Generic.List<string>)(resources.GetObject("llkGercekler.GosterilecekListe")));
            this.llkGercekler.Location = new System.Drawing.Point(6, 6);
            this.llkGercekler.Name = "llkGercekler";
            this.llkGercekler.Size = new System.Drawing.Size(658, 157);
            this.llkGercekler.TabIndex = 0;
            // 
            // tDigerAyrintilar
            // 
            this.tDigerAyrintilar.BackColor = System.Drawing.Color.Gainsboro;
            this.tDigerAyrintilar.Controls.Add(this.groupBox2);
            this.tDigerAyrintilar.Controls.Add(this.gBurclar);
            this.tDigerAyrintilar.Controls.Add(this.gBoyUzunlugu);
            this.tDigerAyrintilar.Location = new System.Drawing.Point(4, 22);
            this.tDigerAyrintilar.Name = "tDigerAyrintilar";
            this.tDigerAyrintilar.Padding = new System.Windows.Forms.Padding(3);
            this.tDigerAyrintilar.Size = new System.Drawing.Size(670, 332);
            this.tDigerAyrintilar.TabIndex = 4;
            this.tDigerAyrintilar.Text = "Diğer Ayrıntılar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTakmaAdi);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDogumAdi);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 86);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Diğer Adları";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Takma Adı";
            // 
            // txtTakmaAdi
            // 
            this.txtTakmaAdi.Location = new System.Drawing.Point(96, 51);
            this.txtTakmaAdi.Name = "txtTakmaAdi";
            this.txtTakmaAdi.Size = new System.Drawing.Size(153, 20);
            this.txtTakmaAdi.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Doğum Adı";
            // 
            // txtDogumAdi
            // 
            this.txtDogumAdi.Location = new System.Drawing.Point(96, 25);
            this.txtDogumAdi.Name = "txtDogumAdi";
            this.txtDogumAdi.Size = new System.Drawing.Size(153, 20);
            this.txtDogumAdi.TabIndex = 28;
            // 
            // gBurclar
            // 
            this.gBurclar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gBurclar.Controls.Add(this.rbBurc11);
            this.gBurclar.Controls.Add(this.rbBurc10);
            this.gBurclar.Controls.Add(this.rbBurc9);
            this.gBurclar.Controls.Add(this.rbBurc8);
            this.gBurclar.Controls.Add(this.rbBurc7);
            this.gBurclar.Controls.Add(this.rbBurc6);
            this.gBurclar.Controls.Add(this.rbBurc5);
            this.gBurclar.Controls.Add(this.rbBurc4);
            this.gBurclar.Controls.Add(this.rbBurc3);
            this.gBurclar.Controls.Add(this.rbBurc2);
            this.gBurclar.Controls.Add(this.rbBurc1);
            this.gBurclar.Controls.Add(this.rbBurc0);
            this.gBurclar.Location = new System.Drawing.Point(6, 152);
            this.gBurclar.Name = "gBurclar";
            this.gBurclar.Size = new System.Drawing.Size(564, 173);
            this.gBurclar.TabIndex = 29;
            this.gBurclar.TabStop = false;
            this.gBurclar.Text = "Burcu";
            // 
            // rbBurc11
            // 
            this.rbBurc11.ImageIndex = 11;
            this.rbBurc11.ImageList = this.burcResimleri;
            this.rbBurc11.Location = new System.Drawing.Point(461, 92);
            this.rbBurc11.Name = "rbBurc11";
            this.rbBurc11.Size = new System.Drawing.Size(84, 67);
            this.rbBurc11.TabIndex = 11;
            this.rbBurc11.TabStop = true;
            this.rbBurc11.UseVisualStyleBackColor = true;
            // 
            // burcResimleri
            // 
            this.burcResimleri.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("burcResimleri.ImageStream")));
            this.burcResimleri.TransparentColor = System.Drawing.Color.Transparent;
            this.burcResimleri.Images.SetKeyName(0, "01Koc.png");
            this.burcResimleri.Images.SetKeyName(1, "02Boga.png");
            this.burcResimleri.Images.SetKeyName(2, "03Ikizler.png");
            this.burcResimleri.Images.SetKeyName(3, "04Yengec.png");
            this.burcResimleri.Images.SetKeyName(4, "05Aslan.png");
            this.burcResimleri.Images.SetKeyName(5, "06Basak.png");
            this.burcResimleri.Images.SetKeyName(6, "07Terazi.png");
            this.burcResimleri.Images.SetKeyName(7, "08Akrep.png");
            this.burcResimleri.Images.SetKeyName(8, "09Yay.png");
            this.burcResimleri.Images.SetKeyName(9, "10Oglak.png");
            this.burcResimleri.Images.SetKeyName(10, "11Kova.png");
            this.burcResimleri.Images.SetKeyName(11, "12Balik.png");
            // 
            // rbBurc10
            // 
            this.rbBurc10.ImageIndex = 10;
            this.rbBurc10.ImageList = this.burcResimleri;
            this.rbBurc10.Location = new System.Drawing.Point(371, 91);
            this.rbBurc10.Name = "rbBurc10";
            this.rbBurc10.Size = new System.Drawing.Size(84, 67);
            this.rbBurc10.TabIndex = 10;
            this.rbBurc10.TabStop = true;
            this.rbBurc10.UseVisualStyleBackColor = true;
            // 
            // rbBurc9
            // 
            this.rbBurc9.ImageIndex = 9;
            this.rbBurc9.ImageList = this.burcResimleri;
            this.rbBurc9.Location = new System.Drawing.Point(281, 91);
            this.rbBurc9.Name = "rbBurc9";
            this.rbBurc9.Size = new System.Drawing.Size(84, 67);
            this.rbBurc9.TabIndex = 9;
            this.rbBurc9.TabStop = true;
            this.rbBurc9.UseVisualStyleBackColor = true;
            // 
            // rbBurc8
            // 
            this.rbBurc8.ImageIndex = 8;
            this.rbBurc8.ImageList = this.burcResimleri;
            this.rbBurc8.Location = new System.Drawing.Point(191, 92);
            this.rbBurc8.Name = "rbBurc8";
            this.rbBurc8.Size = new System.Drawing.Size(84, 67);
            this.rbBurc8.TabIndex = 8;
            this.rbBurc8.TabStop = true;
            this.rbBurc8.UseVisualStyleBackColor = true;
            // 
            // rbBurc7
            // 
            this.rbBurc7.ImageIndex = 7;
            this.rbBurc7.ImageList = this.burcResimleri;
            this.rbBurc7.Location = new System.Drawing.Point(101, 91);
            this.rbBurc7.Name = "rbBurc7";
            this.rbBurc7.Size = new System.Drawing.Size(84, 67);
            this.rbBurc7.TabIndex = 7;
            this.rbBurc7.TabStop = true;
            this.rbBurc7.UseVisualStyleBackColor = true;
            // 
            // rbBurc6
            // 
            this.rbBurc6.ImageIndex = 6;
            this.rbBurc6.ImageList = this.burcResimleri;
            this.rbBurc6.Location = new System.Drawing.Point(11, 92);
            this.rbBurc6.Name = "rbBurc6";
            this.rbBurc6.Size = new System.Drawing.Size(84, 67);
            this.rbBurc6.TabIndex = 6;
            this.rbBurc6.TabStop = true;
            this.rbBurc6.UseVisualStyleBackColor = true;
            // 
            // rbBurc5
            // 
            this.rbBurc5.ImageIndex = 5;
            this.rbBurc5.ImageList = this.burcResimleri;
            this.rbBurc5.Location = new System.Drawing.Point(461, 19);
            this.rbBurc5.Name = "rbBurc5";
            this.rbBurc5.Size = new System.Drawing.Size(84, 67);
            this.rbBurc5.TabIndex = 5;
            this.rbBurc5.TabStop = true;
            this.rbBurc5.UseVisualStyleBackColor = true;
            // 
            // rbBurc4
            // 
            this.rbBurc4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rbBurc4.ImageIndex = 4;
            this.rbBurc4.ImageList = this.burcResimleri;
            this.rbBurc4.Location = new System.Drawing.Point(371, 19);
            this.rbBurc4.Name = "rbBurc4";
            this.rbBurc4.Size = new System.Drawing.Size(84, 67);
            this.rbBurc4.TabIndex = 4;
            this.rbBurc4.TabStop = true;
            this.rbBurc4.UseVisualStyleBackColor = false;
            // 
            // rbBurc3
            // 
            this.rbBurc3.ImageIndex = 3;
            this.rbBurc3.ImageList = this.burcResimleri;
            this.rbBurc3.Location = new System.Drawing.Point(281, 19);
            this.rbBurc3.Name = "rbBurc3";
            this.rbBurc3.Size = new System.Drawing.Size(84, 67);
            this.rbBurc3.TabIndex = 3;
            this.rbBurc3.TabStop = true;
            this.rbBurc3.UseVisualStyleBackColor = true;
            // 
            // rbBurc2
            // 
            this.rbBurc2.ImageIndex = 2;
            this.rbBurc2.ImageList = this.burcResimleri;
            this.rbBurc2.Location = new System.Drawing.Point(191, 19);
            this.rbBurc2.Name = "rbBurc2";
            this.rbBurc2.Size = new System.Drawing.Size(84, 67);
            this.rbBurc2.TabIndex = 2;
            this.rbBurc2.TabStop = true;
            this.rbBurc2.UseVisualStyleBackColor = true;
            // 
            // rbBurc1
            // 
            this.rbBurc1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rbBurc1.ImageIndex = 1;
            this.rbBurc1.ImageList = this.burcResimleri;
            this.rbBurc1.Location = new System.Drawing.Point(101, 19);
            this.rbBurc1.Name = "rbBurc1";
            this.rbBurc1.Size = new System.Drawing.Size(84, 67);
            this.rbBurc1.TabIndex = 1;
            this.rbBurc1.TabStop = true;
            this.rbBurc1.UseVisualStyleBackColor = false;
            // 
            // rbBurc0
            // 
            this.rbBurc0.ImageIndex = 0;
            this.rbBurc0.ImageList = this.burcResimleri;
            this.rbBurc0.Location = new System.Drawing.Point(10, 19);
            this.rbBurc0.Name = "rbBurc0";
            this.rbBurc0.Size = new System.Drawing.Size(85, 67);
            this.rbBurc0.TabIndex = 0;
            this.rbBurc0.TabStop = true;
            this.rbBurc0.UseVisualStyleBackColor = true;
            // 
            // gBoyUzunlugu
            // 
            this.gBoyUzunlugu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gBoyUzunlugu.Controls.Add(this.lBoyUzunlugu);
            this.gBoyUzunlugu.Controls.Add(this.tbBoyBelirtici);
            this.gBoyUzunlugu.Location = new System.Drawing.Point(569, 5);
            this.gBoyUzunlugu.Name = "gBoyUzunlugu";
            this.gBoyUzunlugu.Size = new System.Drawing.Size(94, 320);
            this.gBoyUzunlugu.TabIndex = 28;
            this.gBoyUzunlugu.TabStop = false;
            this.gBoyUzunlugu.Text = "Boy Uzunluğu";
            // 
            // lBoyUzunlugu
            // 
            this.lBoyUzunlugu.Font = new System.Drawing.Font("Verdana", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lBoyUzunlugu.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lBoyUzunlugu.Location = new System.Drawing.Point(8, 27);
            this.lBoyUzunlugu.Name = "lBoyUzunlugu";
            this.lBoyUzunlugu.Size = new System.Drawing.Size(68, 22);
            this.lBoyUzunlugu.TabIndex = 23;
            this.lBoyUzunlugu.Text = "0,0 m";
            // 
            // tbBoyBelirtici
            // 
            this.tbBoyBelirtici.Location = new System.Drawing.Point(23, 64);
            this.tbBoyBelirtici.Maximum = 30;
            this.tbBoyBelirtici.Name = "tbBoyBelirtici";
            this.tbBoyBelirtici.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbBoyBelirtici.Size = new System.Drawing.Size(45, 249);
            this.tbBoyBelirtici.TabIndex = 22;
            this.tbBoyBelirtici.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbBoyBelirtici.Scroll += new System.EventHandler(this.tbBoyBelirtici_Scroll);
            // 
            // iptal
            // 
            this.iptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.iptal.Location = new System.Drawing.Point(612, 371);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(75, 23);
            this.iptal.TabIndex = 4;
            this.iptal.Text = "İptal";
            this.iptal.UseVisualStyleBackColor = true;
            this.iptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // Tamam
            // 
            this.Tamam.Location = new System.Drawing.Point(531, 371);
            this.Tamam.Name = "Tamam";
            this.Tamam.Size = new System.Drawing.Size(75, 23);
            this.Tamam.TabIndex = 3;
            this.Tamam.Text = "Tamam";
            this.Tamam.UseVisualStyleBackColor = true;
            this.Tamam.Click += new System.EventHandler(this.Tamam_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // f_ManuelKisiEkle
            // 
            this.AcceptButton = this.Tamam;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.iptal;
            this.ClientSize = new System.Drawing.Size(697, 406);
            this.Controls.Add(this.iptal);
            this.Controls.Add(this.Tamam);
            this.Controls.Add(this.filmAyarlari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_ManuelKisiEkle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Manuel Kisi Ekle";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f_ManuelKisiEkle_FormClosed);
            this.Load += new System.EventHandler(this.f_ManuelKisiEkle_Load);
            this.tGenelBilgiler.ResumeLayout(false);
            this.tGenelBilgiler.PerformLayout();
            this.gGenelBilgiler.ResumeLayout(false);
            this.gGenelBilgiler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pResim)).EndInit();
            this.filmAyarlari.ResumeLayout(false);
            this.tbAyrintilar.ResumeLayout(false);
            this.tbAyrintilar.PerformLayout();
            this.gOduller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKazandigiParalar)).EndInit();
            this.gResmiWebSayfalari.ResumeLayout(false);
            this.gResmiWebSayfalari.PerformLayout();
            this.tGercekler.ResumeLayout(false);
            this.tDigerAyrintilar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gBurclar.ResumeLayout(false);
            this.gBoyUzunlugu.ResumeLayout(false);
            this.gBoyUzunlugu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbBoyBelirtici)).EndInit();
            this.cmsLinkSaklayici.ResumeLayout(false);
            this.cmsLinkSaklayici.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tGenelBilgiler;
        private System.Windows.Forms.GroupBox gGenelBilgiler;
        private System.Windows.Forms.Label lIMDBId;
        private System.Windows.Forms.Label lCikisTarihi;
        private System.Windows.Forms.Label lKisiAdi;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lResim;
        private System.Windows.Forms.PictureBox pResim;
        private System.Windows.Forms.TabControl filmAyarlari;
        private System.Windows.Forms.ComboBox cUnvan;
        private System.Windows.Forms.Label lKisiUnvani;
        private System.Windows.Forms.Label lDogumYeri;
        private System.Windows.Forms.TextBox txtDogumYeri;
        private System.Windows.Forms.Button iptal;
        private System.Windows.Forms.Button Tamam;
        private System.Windows.Forms.Label lCinsiyet;
        private System.Windows.Forms.ComboBox cmbCinsiyet;
        private System.Windows.Forms.TabPage tbAyrintilar;
        private System.Windows.Forms.GroupBox gOduller;
        private System.Windows.Forms.GroupBox gResmiWebSayfalari;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lKarakterAdi;
        private System.Windows.Forms.TextBox txtKarakterAdi;
        private System.Windows.Forms.TextBox txtDogumTarihi;
        private System.Windows.Forms.TabPage tGercekler;
        private listeLabelKontrolu llkGercekler;
        private System.Windows.Forms.DataGridView dgvKazandigiParalar;
        private System.Windows.Forms.DataGridViewTextBoxColumn film;
        private System.Windows.Forms.DataGridViewTextBoxColumn miktar;
        private System.Windows.Forms.Button btnKazandigiParaEkle;
        private System.Windows.Forms.TabPage tDigerAyrintilar;
        private System.Windows.Forms.GroupBox gBoyUzunlugu;
        private System.Windows.Forms.TrackBar tbBoyBelirtici;
        private System.Windows.Forms.Label lBoyUzunlugu;
        private System.Windows.Forms.GroupBox gBurclar;
        private System.Windows.Forms.RadioButton rbBurc0;
        private System.Windows.Forms.RadioButton rbBurc11;
        private System.Windows.Forms.ImageList burcResimleri;
        private System.Windows.Forms.RadioButton rbBurc10;
        private System.Windows.Forms.RadioButton rbBurc9;
        private System.Windows.Forms.RadioButton rbBurc8;
        private System.Windows.Forms.RadioButton rbBurc7;
        private System.Windows.Forms.RadioButton rbBurc6;
        private System.Windows.Forms.RadioButton rbBurc5;
        private System.Windows.Forms.RadioButton rbBurc4;
        private System.Windows.Forms.RadioButton rbBurc3;
        private System.Windows.Forms.RadioButton rbBurc2;
        private System.Windows.Forms.RadioButton rbBurc1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTakmaAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDogumAdi;
        private System.Windows.Forms.TextBox txtImdbID;
        private System.Windows.Forms.RichTextBox txtOzGecmis;
        private System.Windows.Forms.Label lOzGecmis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private listeLabelKontrolu llkKisiselSozler;
        private System.Windows.Forms.FlowLayoutPanel flpLinkTutucu;
        private System.Windows.Forms.TextBox txtResmiWebSayfasi;
        private System.Windows.Forms.ContextMenuStrip cmsLinkSaklayici;
        private System.Windows.Forms.ToolStripTextBox tstxtLinkDuzenle;
        private System.Windows.Forms.ToolStripMenuItem kaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.Button btnOzgecmisEkle;
        private System.Windows.Forms.Button yeniResmiWebSayfasiEkle;
        private System.Windows.Forms.Button btnKisiselSozEkle;
        private System.Windows.Forms.Button btnGercekEkle;
        private System.Windows.Forms.Button btnKisiselSozuSil;
        private System.Windows.Forms.Button btnHakkindakiGercegiSil;
    }
}