namespace MMC_Filmograf
{
    partial class listeLabelKontrolu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSonraki = new System.Windows.Forms.Button();
            this.btnOnceki = new System.Windows.Forms.Button();
            this.lMetinKonumu = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSonraki
            // 
            this.btnSonraki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSonraki.BackColor = System.Drawing.Color.Transparent;
            this.btnSonraki.FlatAppearance.BorderSize = 0;
            this.btnSonraki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSonraki.Image = global::MMC_Filmograf.Properties.Resources.sag;
            this.btnSonraki.Location = new System.Drawing.Point(498, 1);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(16, 19);
            this.btnSonraki.TabIndex = 33;
            this.btnSonraki.UseVisualStyleBackColor = false;
            this.btnSonraki.Click += new System.EventHandler(this.sonrakiReklamSozu_Click);
            // 
            // btnOnceki
            // 
            this.btnOnceki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnceki.BackColor = System.Drawing.Color.Transparent;
            this.btnOnceki.FlatAppearance.BorderSize = 0;
            this.btnOnceki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnceki.Image = global::MMC_Filmograf.Properties.Resources.sol;
            this.btnOnceki.Location = new System.Drawing.Point(347, 1);
            this.btnOnceki.Name = "btnOnceki";
            this.btnOnceki.Size = new System.Drawing.Size(16, 19);
            this.btnOnceki.TabIndex = 32;
            this.btnOnceki.UseVisualStyleBackColor = false;
            this.btnOnceki.Click += new System.EventHandler(this.oncekiReklamSozu_Click);
            // 
            // lMetinKonumu
            // 
            this.lMetinKonumu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lMetinKonumu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lMetinKonumu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMetinKonumu.Location = new System.Drawing.Point(365, 1);
            this.lMetinKonumu.Name = "lMetinKonumu";
            this.lMetinKonumu.Size = new System.Drawing.Size(131, 19);
            this.lMetinKonumu.TabIndex = 31;
            this.lMetinKonumu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.Location = new System.Drawing.Point(5, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(509, 211);
            this.richTextBox1.TabIndex = 34;
            this.richTextBox1.Text = "";
            // 
            // listeLabelKontrolu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSonraki);
            this.Controls.Add(this.btnOnceki);
            this.Controls.Add(this.lMetinKonumu);
            this.Name = "listeLabelKontrolu";
            this.Size = new System.Drawing.Size(515, 238);
            this.Load += new System.EventHandler(this.listeLabelKontrolu_Load);
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button btnSonraki;
        private System.Windows.Forms.Button btnOnceki;
        private System.Windows.Forms.Label lMetinKonumu;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
