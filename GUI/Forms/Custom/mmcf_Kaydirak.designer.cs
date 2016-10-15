namespace MMC_Filmograf
{
    partial class mmcf_Kaydirak
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
            this.kaydirOrta = new System.Windows.Forms.Button();
            this.kaydirAlt = new System.Windows.Forms.Button();
            this.kaydirUst = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kaydirOrta
            // 
            this.kaydirOrta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kaydirOrta.Location = new System.Drawing.Point(0, 166);
            this.kaydirOrta.Name = "kaydirOrta";
            this.kaydirOrta.Size = new System.Drawing.Size(20, 58);
            this.kaydirOrta.TabIndex = 7;
            this.kaydirOrta.UseVisualStyleBackColor = true;
            // 
            // kaydirAlt
            // 
            this.kaydirAlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kaydirAlt.Location = new System.Drawing.Point(-1, 405);
            this.kaydirAlt.Name = "kaydirAlt";
            this.kaydirAlt.Size = new System.Drawing.Size(22, 25);
            this.kaydirAlt.TabIndex = 6;
            this.kaydirAlt.UseVisualStyleBackColor = true;
            // 
            // kaydirUst
            // 
            this.kaydirUst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kaydirUst.Location = new System.Drawing.Point(-1, -1);
            this.kaydirUst.Name = "kaydirUst";
            this.kaydirUst.Size = new System.Drawing.Size(22, 25);
            this.kaydirUst.TabIndex = 5;
            this.kaydirUst.UseVisualStyleBackColor = true;
            // 
            // mmcf_Kaydirak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MMC_Filmograf.Properties.Resources.cizgi;
            this.Controls.Add(this.kaydirOrta);
            this.Controls.Add(this.kaydirAlt);
            this.Controls.Add(this.kaydirUst);
            this.MinimumSize = new System.Drawing.Size(20, 429);
            this.Name = "mmcf_Kaydirak";
            this.Size = new System.Drawing.Size(20, 429);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kaydirOrta;
        private System.Windows.Forms.Button kaydirAlt;
        private System.Windows.Forms.Button kaydirUst;
    }
}
