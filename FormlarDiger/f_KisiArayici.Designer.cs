namespace MMC_Filmograf
{
    public partial class f_KisiArayici
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_KisiArayici));
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.lvAramaSonuclari = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sonuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAra = new System.Windows.Forms.Button();
            this.cmbAranan = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnIptal
            // 
            this.btnIptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIptal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIptal.Location = new System.Drawing.Point(307, 317);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 9;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEkle.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEkle.Location = new System.Drawing.Point(226, 317);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 8;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // lvAramaSonuclari
            // 
            this.lvAramaSonuclari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAramaSonuclari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.Sonuc});
            this.lvAramaSonuclari.FullRowSelect = true;
            this.lvAramaSonuclari.Location = new System.Drawing.Point(9, 37);
            this.lvAramaSonuclari.Name = "lvAramaSonuclari";
            this.lvAramaSonuclari.Size = new System.Drawing.Size(373, 274);
            this.lvAramaSonuclari.TabIndex = 7;
            this.lvAramaSonuclari.UseCompatibleStateImageBehavior = false;
            this.lvAramaSonuclari.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 87;
            // 
            // Sonuc
            // 
            this.Sonuc.Text = "Sonuç";
            this.Sonuc.Width = 230;
            // 
            // btnAra
            // 
            this.btnAra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAra.Location = new System.Drawing.Point(348, 8);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(34, 23);
            this.btnAra.TabIndex = 6;
            this.btnAra.Text = "Ara";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // cmbAranan
            // 
            this.cmbAranan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAranan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbAranan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbAranan.FormattingEnabled = true;
            this.cmbAranan.Location = new System.Drawing.Point(9, 10);
            this.cmbAranan.Name = "cmbAranan";
            this.cmbAranan.Size = new System.Drawing.Size(333, 21);
            this.cmbAranan.TabIndex = 5;
            // 
            // f_KisiArayici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnIptal;
            this.ClientSize = new System.Drawing.Size(390, 348);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.lvAramaSonuclari);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.cmbAranan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_KisiArayici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kişi Arayıcı";
            this.Load += new System.EventHandler(this.f_KisiArayici_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.ListView lvAramaSonuclari;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader Sonuc;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.ComboBox cmbAranan;
    }
}