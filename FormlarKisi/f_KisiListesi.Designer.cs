namespace MMC_Filmograf
{
    partial class f_KisiListesi
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
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.cmbMeslek = new System.Windows.Forms.ComboBox();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kisiListesi = new System.Windows.Forms.ListView();
            this.kisiResimListesi = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lDurum = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(44, 19);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(124, 20);
            this.txtIsim.TabIndex = 0;
            // 
            // cmbMeslek
            // 
            this.cmbMeslek.FormattingEnabled = true;
            this.cmbMeslek.Items.AddRange(new object[] {
            "Belirsiz",
            "Yönetmen",
            "Yazar",
            "Oyuncu"});
            this.cmbMeslek.Location = new System.Drawing.Point(215, 18);
            this.cmbMeslek.Name = "cmbMeslek";
            this.cmbMeslek.Size = new System.Drawing.Size(121, 21);
            this.cmbMeslek.TabIndex = 1;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(343, 17);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(64, 22);
            this.btnFiltrele.TabIndex = 2;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "İsim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Meslek";
            // 
            // kisiListesi
            // 
            this.kisiListesi.LargeImageList = this.kisiResimListesi;
            this.kisiListesi.Location = new System.Drawing.Point(12, 89);
            this.kisiListesi.Name = "kisiListesi";
            this.kisiListesi.Size = new System.Drawing.Size(424, 256);
            this.kisiListesi.TabIndex = 6;
            this.kisiListesi.UseCompatibleStateImageBehavior = false;
            this.kisiListesi.SelectedIndexChanged += new System.EventHandler(this.kisiListesi_SelectedIndexChanged);
            this.kisiListesi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.kisiListesi_MouseDoubleClick);
            // 
            // kisiResimListesi
            // 
            this.kisiResimListesi.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.kisiResimListesi.ImageSize = new System.Drawing.Size(72, 72);
            this.kisiResimListesi.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lDurum);
            this.groupBox1.Controls.Add(this.txtIsim);
            this.groupBox1.Controls.Add(this.cmbMeslek);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnFiltrele);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 80);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lDurum
            // 
            this.lDurum.AutoSize = true;
            this.lDurum.Location = new System.Drawing.Point(13, 55);
            this.lDurum.Name = "lDurum";
            this.lDurum.Size = new System.Drawing.Size(0, 13);
            this.lDurum.TabIndex = 5;
            // 
            // f_KisiListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 367);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kisiListesi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_KisiListesi";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kişi Listesi";
            this.Load += new System.EventHandler(this.f_KisiListesi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.ComboBox cmbMeslek;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView kisiListesi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList kisiResimListesi;
        private System.Windows.Forms.Label lDurum;
    }
}