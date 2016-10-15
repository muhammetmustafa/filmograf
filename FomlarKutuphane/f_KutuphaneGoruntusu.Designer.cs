namespace Filmograf
{
    partial class f_KutuphaneGoruntusu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_KisilerGoruntusu));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Filmler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Diziler", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Kişiler", System.Windows.Forms.HorizontalAlignment.Left);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslFilmSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDiziSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslKisiSayisi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslVeritabaniDurumu = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabKutuphane = new System.Windows.Forms.TabControl();
            this.tKutuphaneGoruntusu = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvKutuphane = new System.Windows.Forms.ListView();
            this.ekle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.baslikAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.durumu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tSecenekler = new System.Windows.Forms.TabPage();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbEskiyiSil = new System.Windows.Forms.RadioButton();
            this.rbVeritabaniniEkleme = new System.Windows.Forms.RadioButton();
            this.rbVeritabaniBirlestir = new System.Windows.Forms.RadioButton();
            this.gEklemeSecenekleri = new System.Windows.Forms.GroupBox();
            this.cbKisileriGuncelle = new System.Windows.Forms.CheckBox();
            this.cbDizileriGuncelle = new System.Windows.Forms.CheckBox();
            this.cbFilmleriGuncelle = new System.Windows.Forms.CheckBox();
            this.cbKisileriEkle = new System.Windows.Forms.CheckBox();
            this.cbDizileriEkle = new System.Windows.Forms.CheckBox();
            this.cbFilmleriEkle = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.tabKutuphane.SuspendLayout();
            this.tKutuphaneGoruntusu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tSecenekler.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gEklemeSecenekleri.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslFilmSayisi,
            this.tsslDiziSayisi,
            this.tsslKisiSayisi,
            this.tsslVeritabaniDurumu});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(451, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslFilmSayisi
            // 
            this.tsslFilmSayisi.Name = "tsslFilmSayisi";
            this.tsslFilmSayisi.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslDiziSayisi
            // 
            this.tsslDiziSayisi.Name = "tsslDiziSayisi";
            this.tsslDiziSayisi.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslKisiSayisi
            // 
            this.tsslKisiSayisi.Name = "tsslKisiSayisi";
            this.tsslKisiSayisi.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslVeritabaniDurumu
            // 
            this.tsslVeritabaniDurumu.Name = "tsslVeritabaniDurumu";
            this.tsslVeritabaniDurumu.Size = new System.Drawing.Size(0, 17);
            // 
            // tabKutuphane
            // 
            this.tabKutuphane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKutuphane.Controls.Add(this.tKutuphaneGoruntusu);
            this.tabKutuphane.Controls.Add(this.tSecenekler);
            this.tabKutuphane.Location = new System.Drawing.Point(0, 2);
            this.tabKutuphane.Name = "tabKutuphane";
            this.tabKutuphane.SelectedIndex = 0;
            this.tabKutuphane.Size = new System.Drawing.Size(451, 422);
            this.tabKutuphane.TabIndex = 2;
            // 
            // tKutuphaneGoruntusu
            // 
            this.tKutuphaneGoruntusu.Controls.Add(this.pictureBox1);
            this.tKutuphaneGoruntusu.Controls.Add(this.label1);
            this.tKutuphaneGoruntusu.Controls.Add(this.lvKutuphane);
            this.tKutuphaneGoruntusu.Location = new System.Drawing.Point(4, 22);
            this.tKutuphaneGoruntusu.Name = "tKutuphaneGoruntusu";
            this.tKutuphaneGoruntusu.Padding = new System.Windows.Forms.Padding(3);
            this.tKutuphaneGoruntusu.Size = new System.Drawing.Size(443, 396);
            this.tKutuphaneGoruntusu.TabIndex = 0;
            this.tKutuphaneGoruntusu.Text = "Kütüphane";
            this.tKutuphaneGoruntusu.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Filmograf.Properties.Resources.info1;
            this.pictureBox1.Location = new System.Drawing.Point(9, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 49);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 69);
            this.label1.TabIndex = 2;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvKutuphane
            // 
            this.lvKutuphane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvKutuphane.CheckBoxes = true;
            this.lvKutuphane.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ekle,
            this.baslikAdi,
            this.durumu});
            listViewGroup1.Header = "Filmler";
            listViewGroup1.Name = "film";
            listViewGroup2.Header = "Diziler";
            listViewGroup2.Name = "dizi";
            listViewGroup3.Header = "Kişiler";
            listViewGroup3.Name = "kisi";
            this.lvKutuphane.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lvKutuphane.Location = new System.Drawing.Point(3, 81);
            this.lvKutuphane.Name = "lvKutuphane";
            this.lvKutuphane.Size = new System.Drawing.Size(437, 309);
            this.lvKutuphane.TabIndex = 1;
            this.lvKutuphane.UseCompatibleStateImageBehavior = false;
            this.lvKutuphane.View = System.Windows.Forms.View.Details;
            // 
            // ekle
            // 
            this.ekle.Text = "Ekle";
            this.ekle.Width = 38;
            // 
            // baslikAdi
            // 
            this.baslikAdi.Text = "Başlık Adı";
            this.baslikAdi.Width = 170;
            // 
            // durumu
            // 
            this.durumu.Text = "Durumu";
            this.durumu.Width = 161;
            // 
            // tSecenekler
            // 
            this.tSecenekler.Controls.Add(this.btnCikis);
            this.tSecenekler.Controls.Add(this.btnEkle);
            this.tSecenekler.Controls.Add(this.groupBox1);
            this.tSecenekler.Controls.Add(this.gEklemeSecenekleri);
            this.tSecenekler.Location = new System.Drawing.Point(4, 22);
            this.tSecenekler.Name = "tSecenekler";
            this.tSecenekler.Padding = new System.Windows.Forms.Padding(3);
            this.tSecenekler.Size = new System.Drawing.Size(443, 396);
            this.tSecenekler.TabIndex = 1;
            this.tSecenekler.Text = "Seçenekler ve Ekleme";
            this.tSecenekler.UseVisualStyleBackColor = true;
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCikis.Location = new System.Drawing.Point(356, 367);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkle.Location = new System.Drawing.Point(275, 367);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 7;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbEskiyiSil);
            this.groupBox1.Controls.Add(this.rbVeritabaniniEkleme);
            this.groupBox1.Controls.Add(this.rbVeritabaniBirlestir);
            this.groupBox1.Location = new System.Drawing.Point(8, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veritabanı Seçenekleri";
            // 
            // rbEskiyiSil
            // 
            this.rbEskiyiSil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbEskiyiSil.Location = new System.Drawing.Point(19, 69);
            this.rbEskiyiSil.Name = "rbEskiyiSil";
            this.rbEskiyiSil.Size = new System.Drawing.Size(323, 38);
            this.rbEskiyiSil.TabIndex = 7;
            this.rbEskiyiSil.TabStop = true;
            this.rbEskiyiSil.Text = "Eklenen kütüphanenin veritabanını güncel kütüphanemin veritabanının yerine kullan" +
                ". (UYARI: Eski veritabanı silinecek)";
            this.rbEskiyiSil.UseVisualStyleBackColor = true;
            // 
            // rbVeritabaniniEkleme
            // 
            this.rbVeritabaniniEkleme.AutoSize = true;
            this.rbVeritabaniniEkleme.Location = new System.Drawing.Point(19, 50);
            this.rbVeritabaniniEkleme.Name = "rbVeritabaniniEkleme";
            this.rbVeritabaniniEkleme.Size = new System.Drawing.Size(226, 17);
            this.rbVeritabaniniEkleme.TabIndex = 6;
            this.rbVeritabaniniEkleme.TabStop = true;
            this.rbVeritabaniniEkleme.Text = "Eklenen kütüphanenin veritabanını ekleme";
            this.rbVeritabaniniEkleme.UseVisualStyleBackColor = true;
            // 
            // rbVeritabaniBirlestir
            // 
            this.rbVeritabaniBirlestir.AutoSize = true;
            this.rbVeritabaniBirlestir.Checked = true;
            this.rbVeritabaniBirlestir.Location = new System.Drawing.Point(19, 26);
            this.rbVeritabaniBirlestir.Name = "rbVeritabaniBirlestir";
            this.rbVeritabaniBirlestir.Size = new System.Drawing.Size(351, 17);
            this.rbVeritabaniBirlestir.TabIndex = 5;
            this.rbVeritabaniBirlestir.TabStop = true;
            this.rbVeritabaniBirlestir.Text = "Eklenen kütüphanenin veritabanını güncel kütüphaneninkiyle birleştir.";
            this.rbVeritabaniBirlestir.UseVisualStyleBackColor = true;
            // 
            // gEklemeSecenekleri
            // 
            this.gEklemeSecenekleri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gEklemeSecenekleri.Controls.Add(this.cbKisileriGuncelle);
            this.gEklemeSecenekleri.Controls.Add(this.cbDizileriGuncelle);
            this.gEklemeSecenekleri.Controls.Add(this.cbFilmleriGuncelle);
            this.gEklemeSecenekleri.Controls.Add(this.cbKisileriEkle);
            this.gEklemeSecenekleri.Controls.Add(this.cbDizileriEkle);
            this.gEklemeSecenekleri.Controls.Add(this.cbFilmleriEkle);
            this.gEklemeSecenekleri.Location = new System.Drawing.Point(8, 6);
            this.gEklemeSecenekleri.Name = "gEklemeSecenekleri";
            this.gEklemeSecenekleri.Size = new System.Drawing.Size(427, 165);
            this.gEklemeSecenekleri.TabIndex = 0;
            this.gEklemeSecenekleri.TabStop = false;
            this.gEklemeSecenekleri.Text = "Ekleme Seçenekleri";
            // 
            // cbKisileriGuncelle
            // 
            this.cbKisileriGuncelle.AutoSize = true;
            this.cbKisileriGuncelle.Checked = true;
            this.cbKisileriGuncelle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKisileriGuncelle.Location = new System.Drawing.Point(34, 137);
            this.cbKisileriGuncelle.Name = "cbKisileriGuncelle";
            this.cbKisileriGuncelle.Size = new System.Drawing.Size(347, 17);
            this.cbKisileriGuncelle.TabIndex = 5;
            this.cbKisileriGuncelle.Text = "Kütüphanede aynı ID ile başka kişi varsa onu eklenen kişiyle değiştir";
            this.cbKisileriGuncelle.UseVisualStyleBackColor = true;
            // 
            // cbDizileriGuncelle
            // 
            this.cbDizileriGuncelle.AutoSize = true;
            this.cbDizileriGuncelle.Checked = true;
            this.cbDizileriGuncelle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDizileriGuncelle.Location = new System.Drawing.Point(34, 93);
            this.cbDizileriGuncelle.Name = "cbDizileriGuncelle";
            this.cbDizileriGuncelle.Size = new System.Drawing.Size(347, 17);
            this.cbDizileriGuncelle.TabIndex = 4;
            this.cbDizileriGuncelle.Text = "Kütüphanede aynı ID ile başka dizi varsa onu eklenen diziyle değiştir";
            this.cbDizileriGuncelle.UseVisualStyleBackColor = true;
            // 
            // cbFilmleriGuncelle
            // 
            this.cbFilmleriGuncelle.AutoSize = true;
            this.cbFilmleriGuncelle.Checked = true;
            this.cbFilmleriGuncelle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilmleriGuncelle.Location = new System.Drawing.Point(34, 48);
            this.cbFilmleriGuncelle.Name = "cbFilmleriGuncelle";
            this.cbFilmleriGuncelle.Size = new System.Drawing.Size(342, 17);
            this.cbFilmleriGuncelle.TabIndex = 3;
            this.cbFilmleriGuncelle.Text = "Kütüphanede aynı ID ile başka film varsa onu eklenen filmle değiştir";
            this.cbFilmleriGuncelle.UseVisualStyleBackColor = true;
            // 
            // cbKisileriEkle
            // 
            this.cbKisileriEkle.AutoSize = true;
            this.cbKisileriEkle.Checked = true;
            this.cbKisileriEkle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKisileriEkle.Location = new System.Drawing.Point(19, 117);
            this.cbKisileriEkle.Name = "cbKisileriEkle";
            this.cbKisileriEkle.Size = new System.Drawing.Size(78, 17);
            this.cbKisileriEkle.TabIndex = 2;
            this.cbKisileriEkle.Text = "Kişileri ekle";
            this.cbKisileriEkle.UseVisualStyleBackColor = true;
            this.cbKisileriEkle.CheckedChanged += new System.EventHandler(this.cbKisileriEkle_CheckedChanged);
            // 
            // cbDizileriEkle
            // 
            this.cbDizileriEkle.AutoSize = true;
            this.cbDizileriEkle.Checked = true;
            this.cbDizileriEkle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDizileriEkle.Location = new System.Drawing.Point(19, 72);
            this.cbDizileriEkle.Name = "cbDizileriEkle";
            this.cbDizileriEkle.Size = new System.Drawing.Size(79, 17);
            this.cbDizileriEkle.TabIndex = 1;
            this.cbDizileriEkle.Text = "Dizileri ekle";
            this.cbDizileriEkle.UseVisualStyleBackColor = true;
            this.cbDizileriEkle.CheckedChanged += new System.EventHandler(this.cbDizileriEkle_CheckedChanged);
            // 
            // cbFilmleriEkle
            // 
            this.cbFilmleriEkle.AutoSize = true;
            this.cbFilmleriEkle.Checked = true;
            this.cbFilmleriEkle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilmleriEkle.Location = new System.Drawing.Point(19, 26);
            this.cbFilmleriEkle.Name = "cbFilmleriEkle";
            this.cbFilmleriEkle.Size = new System.Drawing.Size(80, 17);
            this.cbFilmleriEkle.TabIndex = 0;
            this.cbFilmleriEkle.Text = "Filmleri ekle";
            this.cbFilmleriEkle.UseVisualStyleBackColor = true;
            this.cbFilmleriEkle.CheckedChanged += new System.EventHandler(this.cbFilmleriEkle_CheckedChanged);
            // 
            // f_KutuphaneGoruntusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 449);
            this.Controls.Add(this.tabKutuphane);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(467, 487);
            this.Name = "f_KutuphaneGoruntusu";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.f_KutuphaneGoruntusu_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabKutuphane.ResumeLayout(false);
            this.tKutuphaneGoruntusu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tSecenekler.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gEklemeSecenekleri.ResumeLayout(false);
            this.gEklemeSecenekleri.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslFilmSayisi;
        private System.Windows.Forms.ToolStripStatusLabel tsslDiziSayisi;
        private System.Windows.Forms.ToolStripStatusLabel tsslKisiSayisi;
        private System.Windows.Forms.ToolStripStatusLabel tsslVeritabaniDurumu;
        private System.Windows.Forms.TabControl tabKutuphane;
        private System.Windows.Forms.TabPage tKutuphaneGoruntusu;
        private System.Windows.Forms.ListView lvKutuphane;
        private System.Windows.Forms.ColumnHeader ekle;
        private System.Windows.Forms.ColumnHeader baslikAdi;
        private System.Windows.Forms.ColumnHeader durumu;
        private System.Windows.Forms.TabPage tSecenekler;
        private System.Windows.Forms.GroupBox gEklemeSecenekleri;
        private System.Windows.Forms.CheckBox cbKisileriGuncelle;
        private System.Windows.Forms.CheckBox cbDizileriGuncelle;
        private System.Windows.Forms.CheckBox cbFilmleriGuncelle;
        private System.Windows.Forms.CheckBox cbKisileriEkle;
        private System.Windows.Forms.CheckBox cbDizileriEkle;
        private System.Windows.Forms.CheckBox cbFilmleriEkle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbEskiyiSil;
        private System.Windows.Forms.RadioButton rbVeritabaniniEkleme;
        private System.Windows.Forms.RadioButton rbVeritabaniBirlestir;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}