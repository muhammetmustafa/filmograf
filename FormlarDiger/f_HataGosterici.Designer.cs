namespace Filmograf
{
    partial class f_HataGosterici
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
            this.lvHatalar = new System.Windows.Forms.ListView();
            this.hataAdi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hataKaynagi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnTamam = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvHatalar
            // 
            this.lvHatalar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvHatalar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hataAdi,
            this.hataKaynagi});
            this.lvHatalar.Location = new System.Drawing.Point(0, 0);
            this.lvHatalar.Name = "lvHatalar";
            this.lvHatalar.Size = new System.Drawing.Size(423, 193);
            this.lvHatalar.TabIndex = 0;
            this.lvHatalar.UseCompatibleStateImageBehavior = false;
            this.lvHatalar.View = System.Windows.Forms.View.Details;
            // 
            // hataAdi
            // 
            this.hataAdi.Text = "Hata Bilgisi";
            this.hataAdi.Width = 102;
            // 
            // hataKaynagi
            // 
            this.hataKaynagi.Text = "Kaynak";
            // 
            // btnTamam
            // 
            this.btnTamam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTamam.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTamam.Location = new System.Drawing.Point(3, 195);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 1;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // f_HataGosterici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 220);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.lvHatalar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_HataGosterici";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hatalar";
            this.Load += new System.EventHandler(this.f_HataGosterici_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvHatalar;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.ColumnHeader hataAdi;
        private System.Windows.Forms.ColumnHeader hataKaynagi;
    }
}