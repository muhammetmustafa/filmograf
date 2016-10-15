using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MMC_Filmograf.Library;

namespace MMC_Filmograf
{
    public partial class f_BaslikArayicisi : Form
    {
        Kutuphane kutuphane;
        string secilenID;

        public f_BaslikArayicisi(Kutuphane kutuphane)
        {
            InitializeComponent();
            this.kutuphane = kutuphane;
            this.secilenID = "";

            AutoCompleteStringCollection yeni = new AutoCompleteStringCollection();
            foreach (string s in this.kutuphane.IDVeritabani.Keys)
            {
                if (s.StartsWith("tt"))
                    yeni.Add(this.kutuphane.IDVeritabani[s]);
            }
            this.cmbAranan.AutoCompleteCustomSource = yeni;
            this.cmbAranan.KeyUp += new KeyEventHandler(cmbAranan_KeyUp);
        }

        void cmbAranan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAra_Click(sender, e);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            lvAramaSonuclari.Items.Clear();

            foreach (string s in this.kutuphane.IDVeritabani.Keys)
            {
                string deger = this.kutuphane.IDVeritabani[s];
                if (deger.ToLower().Contains(this.cmbAranan.Text.ToLower()))
                    lvAramaSonuclari.Items.Add(s, s, s).SubItems.Add(deger);
            }

            lvAramaSonuclari.Sort();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (lvAramaSonuclari.SelectedItems.Count == 1)
            {
                this.secilenID = lvAramaSonuclari.SelectedItems[0].ImageKey;
            }
        }

        public string SecilenID
        {
            get { return this.secilenID; }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
