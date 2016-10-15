namespace MMC_Filmograf
{
    partial class f_ArastirarakEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ArastirarakEkle));
            this.tArastirma = new System.Windows.Forms.TabControl();
            this.tArastir = new System.Windows.Forms.TabPage();
            this.lvsonuclar = new System.Windows.Forms.ListView();
            this.secim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sonuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmncikiyili = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAranacak = new System.Windows.Forms.ComboBox();
            this.btnIptal = new System.Windows.Forms.Button();
            this.lAciklama = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.tTopluEkleme = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVarOlanlariKaldir = new System.Windows.Forms.Button();
            this.bntBilgileriAl = new System.Windows.Forms.Button();
            this.btnIptal2 = new System.Windows.Forms.Button();
            this.btnEkle2 = new System.Windows.Forms.Button();
            this.lvBulunanBasliklar = new System.Windows.Forms.ListView();
            this.secimler = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.baslikID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filmAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cikisYili = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durumBilgisi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lDosya = new System.Windows.Forms.Label();
            this.btnGozat = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslIslemiIptalEt = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbIlerleme = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslEklenenBaslikSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslBilgi = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.arkaPlanAmelesi = new System.ComponentModel.BackgroundWorker();
            this.tArastirma.SuspendLayout();
            this.tArastir.SuspendLayout();
            this.tTopluEkleme.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tArastirma
            // 
            this.tArastirma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tArastirma.Controls.Add(this.tArastir);
            this.tArastirma.Controls.Add(this.tTopluEkleme);
            this.tArastirma.Location = new System.Drawing.Point(9, 4);
            this.tArastirma.Name = "tArastirma";
            this.tArastirma.SelectedIndex = 0;
            this.tArastirma.Size = new System.Drawing.Size(444, 380);
            this.tArastirma.TabIndex = 0;
            this.tArastirma.Selected += new System.Windows.Forms.TabControlEventHandler(this.tArastirma_Selected);
            // 
            // tArastir
            // 
            this.tArastir.BackColor = System.Drawing.Color.Gainsboro;
            this.tArastir.Controls.Add(this.lvsonuclar);
            this.tArastir.Controls.Add(this.txtAranacak);
            this.tArastir.Controls.Add(this.btnIptal);
            this.tArastir.Controls.Add(this.lAciklama);
            this.tArastir.Controls.Add(this.btnEkle);
            this.tArastir.Controls.Add(this.btnAra);
            this.tArastir.Location = new System.Drawing.Point(4, 22);
            this.tArastir.Name = "tArastir";
            this.tArastir.Padding = new System.Windows.Forms.Padding(3);
            this.tArastir.Size = new System.Drawing.Size(436, 354);
            this.tArastir.TabIndex = 0;
            this.tArastir.Text = "Araştır";
            // 
            // lvsonuclar
            // 
            this.lvsonuclar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvsonuclar.CheckBoxes = true;
            this.lvsonuclar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.secim,
            this.sonuc,
            this.clmncikiyili});
            this.lvsonuclar.FullRowSelect = true;
            this.lvsonuclar.Location = new System.Drawing.Point(7, 70);
            this.lvsonuclar.Name = "lvsonuclar";
            this.lvsonuclar.Size = new System.Drawing.Size(423, 249);
            this.lvsonuclar.TabIndex = 3;
            this.lvsonuclar.UseCompatibleStateImageBehavior = false;
            this.lvsonuclar.View = System.Windows.Forms.View.Details;
            // 
            // secim
            // 
            this.secim.Text = "";
            this.secim.Width = 25;
            // 
            // sonuc
            // 
            this.sonuc.Text = "Sonuç";
            this.sonuc.Width = 296;
            // 
            // clmncikiyili
            // 
            this.clmncikiyili.Text = "Çıkış Yılı";
            // 
            // txtAranacak
            // 
            this.txtAranacak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAranacak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAranacak.FormattingEnabled = true;
            this.txtAranacak.Location = new System.Drawing.Point(7, 42);
            this.txtAranacak.Name = "txtAranacak";
            this.txtAranacak.Size = new System.Drawing.Size(374, 21);
            this.txtAranacak.TabIndex = 1;
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.Location = new System.Drawing.Point(356, 325);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "Çıkış";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // lAciklama
            // 
            this.lAciklama.AutoSize = true;
            this.lAciklama.BackColor = System.Drawing.Color.Gainsboro;
            this.lAciklama.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lAciklama.Location = new System.Drawing.Point(6, 18);
            this.lAciklama.Name = "lAciklama";
            this.lAciklama.Size = new System.Drawing.Size(250, 19);
            this.lAciklama.TabIndex = 2;
            this.lAciklama.Text = "İsim veya IMDB ID (Örnek: tt3488298) ";
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkle.Location = new System.Drawing.Point(282, 325);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnAra
            // 
            this.btnAra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAra.Location = new System.Drawing.Point(387, 42);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(43, 22);
            this.btnAra.TabIndex = 2;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // tTopluEkleme
            // 
            this.tTopluEkleme.BackColor = System.Drawing.Color.Gainsboro;
            this.tTopluEkleme.Controls.Add(this.label1);
            this.tTopluEkleme.Controls.Add(this.btnVarOlanlariKaldir);
            this.tTopluEkleme.Controls.Add(this.bntBilgileriAl);
            this.tTopluEkleme.Controls.Add(this.btnIptal2);
            this.tTopluEkleme.Controls.Add(this.btnEkle2);
            this.tTopluEkleme.Controls.Add(this.lvBulunanBasliklar);
            this.tTopluEkleme.Controls.Add(this.lDosya);
            this.tTopluEkleme.Controls.Add(this.btnGozat);
            this.tTopluEkleme.Location = new System.Drawing.Point(4, 22);
            this.tTopluEkleme.Name = "tTopluEkleme";
            this.tTopluEkleme.Size = new System.Drawing.Size(436, 354);
            this.tTopluEkleme.TabIndex = 1;
            this.tTopluEkleme.Text = "Toplu Ekleme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Dosya:";
            // 
            // btnVarOlanlariKaldir
            // 
            this.btnVarOlanlariKaldir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVarOlanlariKaldir.Location = new System.Drawing.Point(80, 325);
            this.btnVarOlanlariKaldir.Name = "btnVarOlanlariKaldir";
            this.btnVarOlanlariKaldir.Size = new System.Drawing.Size(98, 23);
            this.btnVarOlanlariKaldir.TabIndex = 6;
            this.btnVarOlanlariKaldir.Text = "Var Olanları Kaldır";
            this.btnVarOlanlariKaldir.UseVisualStyleBackColor = true;
            this.btnVarOlanlariKaldir.Click += new System.EventHandler(this.btnVarOlanlariKaldir_Click);
            // 
            // bntBilgileriAl
            // 
            this.bntBilgileriAl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntBilgileriAl.Location = new System.Drawing.Point(5, 325);
            this.bntBilgileriAl.Name = "bntBilgileriAl";
            this.bntBilgileriAl.Size = new System.Drawing.Size(75, 23);
            this.bntBilgileriAl.TabIndex = 5;
            this.bntBilgileriAl.Text = "Bilgilerini Al";
            this.bntBilgileriAl.UseVisualStyleBackColor = true;
            this.bntBilgileriAl.Click += new System.EventHandler(this.bntBilgileriAl_Click);
            // 
            // btnIptal2
            // 
            this.btnIptal2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal2.Location = new System.Drawing.Point(379, 325);
            this.btnIptal2.Name = "btnIptal2";
            this.btnIptal2.Size = new System.Drawing.Size(53, 23);
            this.btnIptal2.TabIndex = 4;
            this.btnIptal2.Text = "Çıkış";
            this.btnIptal2.UseVisualStyleBackColor = true;
            this.btnIptal2.Click += new System.EventHandler(this.btnIptal2_Click);
            // 
            // btnEkle2
            // 
            this.btnEkle2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkle2.Location = new System.Drawing.Point(285, 325);
            this.btnEkle2.Name = "btnEkle2";
            this.btnEkle2.Size = new System.Drawing.Size(88, 23);
            this.btnEkle2.TabIndex = 3;
            this.btnEkle2.Text = "Seçilenleri Ekle";
            this.btnEkle2.UseVisualStyleBackColor = true;
            this.btnEkle2.Click += new System.EventHandler(this.btnEkle2_Click);
            // 
            // lvBulunanBasliklar
            // 
            this.lvBulunanBasliklar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBulunanBasliklar.CheckBoxes = true;
            this.lvBulunanBasliklar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.secimler,
            this.baslikID,
            this.filmAdi,
            this.cikisYili,
            this.durumBilgisi});
            this.lvBulunanBasliklar.FullRowSelect = true;
            this.lvBulunanBasliklar.GridLines = true;
            this.lvBulunanBasliklar.Location = new System.Drawing.Point(5, 38);
            this.lvBulunanBasliklar.Name = "lvBulunanBasliklar";
            this.lvBulunanBasliklar.Size = new System.Drawing.Size(428, 284);
            this.lvBulunanBasliklar.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvBulunanBasliklar.TabIndex = 2;
            this.lvBulunanBasliklar.UseCompatibleStateImageBehavior = false;
            this.lvBulunanBasliklar.View = System.Windows.Forms.View.Details;
            this.lvBulunanBasliklar.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvBulunanBasliklar_ColumnClick);
            // 
            // secimler
            // 
            this.secimler.Text = "";
            this.secimler.Width = 20;
            // 
            // baslikID
            // 
            this.baslikID.Text = "Başlık ID";
            // 
            // filmAdi
            // 
            this.filmAdi.Text = "Film Adı";
            this.filmAdi.Width = 127;
            // 
            // cikisYili
            // 
            this.cikisYili.Text = "Çıkış Yılı";
            // 
            // durumBilgisi
            // 
            this.durumBilgisi.Text = "Durum Bilgisi";
            this.durumBilgisi.Width = 89;
            // 
            // lDosya
            // 
            this.lDosya.AutoSize = true;
            this.lDosya.BackColor = System.Drawing.Color.Gainsboro;
            this.lDosya.Location = new System.Drawing.Point(51, 17);
            this.lDosya.Name = "lDosya";
            this.lDosya.Size = new System.Drawing.Size(0, 13);
            this.lDosya.TabIndex = 1;
            // 
            // btnGozat
            // 
            this.btnGozat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGozat.Location = new System.Drawing.Point(380, 10);
            this.btnGozat.Name = "btnGozat";
            this.btnGozat.Size = new System.Drawing.Size(53, 22);
            this.btnGozat.TabIndex = 0;
            this.btnGozat.Text = "Gözat";
            this.btnGozat.UseVisualStyleBackColor = true;
            this.btnGozat.Click += new System.EventHandler(this.btnGozat_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslIslemiIptalEt,
            this.pbIlerleme,
            this.tsslEklenenBaslikSayisi,
            this.tsslBilgi});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(465, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslIslemiIptalEt
            // 
            this.tsslIslemiIptalEt.Image = global::MMC_Filmograf.Properties.Resources.action_delete1;
            this.tsslIslemiIptalEt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslIslemiIptalEt.IsLink = true;
            this.tsslIslemiIptalEt.Name = "tsslIslemiIptalEt";
            this.tsslIslemiIptalEt.Size = new System.Drawing.Size(16, 17);
            this.tsslIslemiIptalEt.ToolTipText = "Devam eden işlemi iptal et";
            this.tsslIslemiIptalEt.Visible = false;
            this.tsslIslemiIptalEt.Click += new System.EventHandler(this.tsslIslemiIptalEt_Click);
            // 
            // pbIlerleme
            // 
            this.pbIlerleme.Name = "pbIlerleme";
            this.pbIlerleme.Size = new System.Drawing.Size(150, 16);
            // 
            // tsslEklenenBaslikSayisi
            // 
            this.tsslEklenenBaslikSayisi.AutoSize = false;
            this.tsslEklenenBaslikSayisi.BackColor = System.Drawing.Color.Gainsboro;
            this.tsslEklenenBaslikSayisi.Name = "tsslEklenenBaslikSayisi";
            this.tsslEklenenBaslikSayisi.Size = new System.Drawing.Size(70, 17);
            this.tsslEklenenBaslikSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsslBilgi
            // 
            this.tsslBilgi.AutoSize = false;
            this.tsslBilgi.BackColor = System.Drawing.Color.Gainsboro;
            this.tsslBilgi.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslBilgi.Name = "tsslBilgi";
            this.tsslBilgi.Size = new System.Drawing.Size(200, 17);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // arkaPlanAmelesi
            // 
            this.arkaPlanAmelesi.WorkerSupportsCancellation = true;
            this.arkaPlanAmelesi.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.arkaPlanAmelesi.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // f_ArastirarakEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 417);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tArastirma);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(481, 445);
            this.Name = "f_ArastirarakEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Araştırarak Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_ArastirarakEkle_FormClosing);
            this.Load += new System.EventHandler(this.f_ArastirarakEkle_Load);
            this.tArastirma.ResumeLayout(false);
            this.tArastir.ResumeLayout(false);
            this.tArastir.PerformLayout();
            this.tTopluEkleme.ResumeLayout(false);
            this.tTopluEkleme.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.TabControl tArastirma;
        private System.Windows.Forms.TabPage tArastir;
        private System.Windows.Forms.Label lAciklama;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pbIlerleme;
        private System.Windows.Forms.ToolStripStatusLabel tsslBilgi;
        private System.Windows.Forms.TabPage tTopluEkleme;
        private System.Windows.Forms.ListView lvBulunanBasliklar;
        private System.Windows.Forms.ColumnHeader baslikID;
        private System.Windows.Forms.ColumnHeader filmAdi;
        private System.Windows.Forms.ColumnHeader cikisYili;
        private System.Windows.Forms.ColumnHeader durumBilgisi;
        private System.Windows.Forms.Label lDosya;
        private System.Windows.Forms.Button btnGozat;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnIptal2;
        private System.Windows.Forms.Button btnEkle2;
        private System.Windows.Forms.Button bntBilgileriAl;
        private System.Windows.Forms.ColumnHeader secimler;
        private System.Windows.Forms.ToolStripStatusLabel tsslEklenenBaslikSayisi;
        private System.Windows.Forms.Button btnVarOlanlariKaldir;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker arkaPlanAmelesi;
        private System.Windows.Forms.ToolStripStatusLabel tsslIslemiIptalEt;
        private System.Windows.Forms.ComboBox txtAranacak;
        private System.Windows.Forms.ListView lvsonuclar;
        private System.Windows.Forms.ColumnHeader secim;
        private System.Windows.Forms.ColumnHeader sonuc;
        private System.Windows.Forms.ColumnHeader clmncikiyili;


    }
}