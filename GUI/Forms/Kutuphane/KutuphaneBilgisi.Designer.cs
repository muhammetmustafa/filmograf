namespace Filmograf
{
    partial class f_KutuphaneBilgisi
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
            this.btnCikis = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslVeritabaniMiktari = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.scTumKontroller = new System.Windows.Forms.SplitContainer();
            this.lIDIsimVeritabani = new System.Windows.Forms.Label();
            this.dgvIsimIdler = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.lAciklamaKisiSayisi = new System.Windows.Forms.Label();
            this.lKutuphaneAdi = new System.Windows.Forms.Label();
            this.lAciklamaFilmSayisi = new System.Windows.Forms.Label();
            this.txtKutuphaneAdiDuzenle = new System.Windows.Forms.TextBox();
            this.lKisiSayisi = new System.Windows.Forms.Label();
            this.ldosyaYolu = new System.Windows.Forms.Label();
            this.lFilmSayisi = new System.Windows.Forms.Label();
            this.lAciklamaKutuphaneAdi = new System.Windows.Forms.Label();
            this.lAciklamaDosyaYolu = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTumKontroller)).BeginInit();
            this.scTumKontroller.Panel1.SuspendLayout();
            this.scTumKontroller.Panel2.SuspendLayout();
            this.scTumKontroller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIsimIdler)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCikis
            // 
            this.btnCikis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCikis.Location = new System.Drawing.Point(657, 298);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 2;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslVeritabaniMiktari});
            this.statusStrip1.Location = new System.Drawing.Point(0, 324);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(732, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslVeritabaniMiktari
            // 
            this.tsslVeritabaniMiktari.Name = "tsslVeritabaniMiktari";
            this.tsslVeritabaniMiktari.Size = new System.Drawing.Size(0, 17);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKaydet.Location = new System.Drawing.Point(576, 298);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // scTumKontroller
            // 
            this.scTumKontroller.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scTumKontroller.Location = new System.Drawing.Point(0, 0);
            this.scTumKontroller.Name = "scTumKontroller";
            // 
            // scTumKontroller.Panel1
            // 
            this.scTumKontroller.Panel1.Controls.Add(this.lIDIsimVeritabani);
            this.scTumKontroller.Panel1.Controls.Add(this.dgvIsimIdler);
            // 
            // scTumKontroller.Panel2
            // 
            this.scTumKontroller.Panel2.Controls.Add(this.btnDuzenle);
            this.scTumKontroller.Panel2.Controls.Add(this.lAciklamaKisiSayisi);
            this.scTumKontroller.Panel2.Controls.Add(this.lKutuphaneAdi);
            this.scTumKontroller.Panel2.Controls.Add(this.lAciklamaFilmSayisi);
            this.scTumKontroller.Panel2.Controls.Add(this.txtKutuphaneAdiDuzenle);
            this.scTumKontroller.Panel2.Controls.Add(this.lKisiSayisi);
            this.scTumKontroller.Panel2.Controls.Add(this.ldosyaYolu);
            this.scTumKontroller.Panel2.Controls.Add(this.lFilmSayisi);
            this.scTumKontroller.Panel2.Controls.Add(this.lAciklamaKutuphaneAdi);
            this.scTumKontroller.Panel2.Controls.Add(this.lAciklamaDosyaYolu);
            this.scTumKontroller.Size = new System.Drawing.Size(732, 292);
            this.scTumKontroller.SplitterDistance = 408;
            this.scTumKontroller.TabIndex = 11;
            // 
            // lIDIsimVeritabani
            // 
            this.lIDIsimVeritabani.AutoSize = true;
            this.lIDIsimVeritabani.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lIDIsimVeritabani.Location = new System.Drawing.Point(5, 6);
            this.lIDIsimVeritabani.Name = "lIDIsimVeritabani";
            this.lIDIsimVeritabani.Size = new System.Drawing.Size(213, 17);
            this.lIDIsimVeritabani.TabIndex = 11;
            this.lIDIsimVeritabani.Text = "Kütüphanenin ID/Isim Veritabanı";
            // 
            // dgvIsimIdler
            // 
            this.dgvIsimIdler.AllowUserToResizeRows = false;
            this.dgvIsimIdler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIsimIdler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvIsimIdler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIsimIdler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Isim});
            this.dgvIsimIdler.Location = new System.Drawing.Point(6, 23);
            this.dgvIsimIdler.Name = "dgvIsimIdler";
            this.dgvIsimIdler.RowHeadersVisible = false;
            this.dgvIsimIdler.Size = new System.Drawing.Size(396, 264);
            this.dgvIsimIdler.TabIndex = 9;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 43;
            // 
            // Isim
            // 
            this.Isim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Isim.HeaderText = "İsim";
            this.Isim.Name = "Isim";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuzenle.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.btnDuzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenle.Location = new System.Drawing.Point(285, 26);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(19, 19);
            this.btnDuzenle.TabIndex = 11;
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // lAciklamaKisiSayisi
            // 
            this.lAciklamaKisiSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lAciklamaKisiSayisi.AutoSize = true;
            this.lAciklamaKisiSayisi.Location = new System.Drawing.Point(101, 97);
            this.lAciklamaKisiSayisi.Name = "lAciklamaKisiSayisi";
            this.lAciklamaKisiSayisi.Size = new System.Drawing.Size(0, 13);
            this.lAciklamaKisiSayisi.TabIndex = 7;
            // 
            // lKutuphaneAdi
            // 
            this.lKutuphaneAdi.AutoSize = true;
            this.lKutuphaneAdi.Location = new System.Drawing.Point(3, 29);
            this.lKutuphaneAdi.Name = "lKutuphaneAdi";
            this.lKutuphaneAdi.Size = new System.Drawing.Size(80, 13);
            this.lKutuphaneAdi.TabIndex = 0;
            this.lKutuphaneAdi.Text = "Kütüphane Adı:";
            // 
            // lAciklamaFilmSayisi
            // 
            this.lAciklamaFilmSayisi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lAciklamaFilmSayisi.AutoSize = true;
            this.lAciklamaFilmSayisi.Location = new System.Drawing.Point(101, 72);
            this.lAciklamaFilmSayisi.Name = "lAciklamaFilmSayisi";
            this.lAciklamaFilmSayisi.Size = new System.Drawing.Size(0, 13);
            this.lAciklamaFilmSayisi.TabIndex = 6;
            // 
            // txtKutuphaneAdiDuzenle
            // 
            this.txtKutuphaneAdiDuzenle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKutuphaneAdiDuzenle.Location = new System.Drawing.Point(89, 26);
            this.txtKutuphaneAdiDuzenle.Name = "txtKutuphaneAdiDuzenle";
            this.txtKutuphaneAdiDuzenle.Size = new System.Drawing.Size(216, 20);
            this.txtKutuphaneAdiDuzenle.TabIndex = 11;
            this.txtKutuphaneAdiDuzenle.Visible = false;
            // 
            // lKisiSayisi
            // 
            this.lKisiSayisi.AutoSize = true;
            this.lKisiSayisi.Location = new System.Drawing.Point(3, 104);
            this.lKisiSayisi.Name = "lKisiSayisi";
            this.lKisiSayisi.Size = new System.Drawing.Size(56, 13);
            this.lKisiSayisi.TabIndex = 5;
            this.lKisiSayisi.Text = "Kişi Sayısı:";
            // 
            // ldosyaYolu
            // 
            this.ldosyaYolu.AutoSize = true;
            this.ldosyaYolu.Location = new System.Drawing.Point(3, 55);
            this.ldosyaYolu.Name = "ldosyaYolu";
            this.ldosyaYolu.Size = new System.Drawing.Size(64, 13);
            this.ldosyaYolu.TabIndex = 1;
            this.ldosyaYolu.Text = "Dosya Yolu:";
            // 
            // lFilmSayisi
            // 
            this.lFilmSayisi.AutoSize = true;
            this.lFilmSayisi.Location = new System.Drawing.Point(3, 79);
            this.lFilmSayisi.Name = "lFilmSayisi";
            this.lFilmSayisi.Size = new System.Drawing.Size(58, 13);
            this.lFilmSayisi.TabIndex = 4;
            this.lFilmSayisi.Text = "Film Sayısı:";
            // 
            // lAciklamaKutuphaneAdi
            // 
            this.lAciklamaKutuphaneAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lAciklamaKutuphaneAdi.AutoSize = true;
            this.lAciklamaKutuphaneAdi.Location = new System.Drawing.Point(101, 29);
            this.lAciklamaKutuphaneAdi.Name = "lAciklamaKutuphaneAdi";
            this.lAciklamaKutuphaneAdi.Size = new System.Drawing.Size(0, 13);
            this.lAciklamaKutuphaneAdi.TabIndex = 2;
            // 
            // lAciklamaDosyaYolu
            // 
            this.lAciklamaDosyaYolu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lAciklamaDosyaYolu.AutoSize = true;
            this.lAciklamaDosyaYolu.Location = new System.Drawing.Point(101, 48);
            this.lAciklamaDosyaYolu.Name = "lAciklamaDosyaYolu";
            this.lAciklamaDosyaYolu.Size = new System.Drawing.Size(0, 13);
            this.lAciklamaDosyaYolu.TabIndex = 3;
            // 
            // f_KutuphaneBilgisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 346);
            this.Controls.Add(this.scTumKontroller);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCikis);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(748, 384);
            this.Name = "f_KutuphaneBilgisi";
            this.Text = "Kütüphane Bilgisi";
            this.Load += new System.EventHandler(this.f_KutuphaneBilgisi_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.scTumKontroller.Panel1.ResumeLayout(false);
            this.scTumKontroller.Panel1.PerformLayout();
            this.scTumKontroller.Panel2.ResumeLayout(false);
            this.scTumKontroller.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTumKontroller)).EndInit();
            this.scTumKontroller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIsimIdler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslVeritabaniMiktari;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.SplitContainer scTumKontroller;
        private System.Windows.Forms.Label lIDIsimVeritabani;
        private System.Windows.Forms.DataGridView dgvIsimIdler;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isim;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.Label lAciklamaKisiSayisi;
        private System.Windows.Forms.Label lKutuphaneAdi;
        private System.Windows.Forms.Label lAciklamaFilmSayisi;
        private System.Windows.Forms.TextBox txtKutuphaneAdiDuzenle;
        private System.Windows.Forms.Label lKisiSayisi;
        private System.Windows.Forms.Label ldosyaYolu;
        private System.Windows.Forms.Label lFilmSayisi;
        private System.Windows.Forms.Label lAciklamaKutuphaneAdi;
        private System.Windows.Forms.Label lAciklamaDosyaYolu;
    }
}