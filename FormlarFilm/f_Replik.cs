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
    public partial class f_Replik : Form
    {
        Kutuphane kutuphane;
        Replik yeni = null;

        public f_Replik(Kutuphane kutuphane)
        {
            InitializeComponent();
            this.kutuphane = kutuphane;
            this.dgvReplikler.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvReplikler_RowsAdded);
        }

        void dgvReplikler_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewLinkCell yeni = new DataGridViewLinkCell();
            yeni.Value = "Kişi Ekle";
            this.dgvReplikler.Rows[e.RowIndex].Cells[0] = yeni;
        }

        private void dgvReplikler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                f_KisiArayici yeni = new f_KisiArayici(this.kutuphane);
                DialogResult d = yeni.ShowDialog();

                if (d == System.Windows.Forms.DialogResult.OK)
                {
                    if (yeni.SecilenID == "") return;

                    DataGridViewLinkCell link = new DataGridViewLinkCell();
                    isimID isimid = new isimID();
                    isimid.id = yeni.SecilenID;
                    isimid.isim = this.kutuphane.IDVeritabani[isimid.id];
                    link.Value = isimid;
                    this.dgvReplikler.Rows[e.RowIndex].Cells[0] = link;
                }
            }
        }

        private void f_Replik_Load(object sender, EventArgs e)
        {
            DataGridViewLinkCell link = new DataGridViewLinkCell();
            isimID isimid = new isimID();
            isimid.id = "";
            isimid.isim = "Kişi Ekle";
            link.Value = isimid;
            this.dgvReplikler.Rows[0].Cells[0] = link;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            yeni = new Replik();
            yeni.alintilar = new List<Replik.KisiSoz>();

            foreach (DataGridViewRow item in this.dgvReplikler.Rows)
            {
                DataGridViewLinkCell sel0 = (DataGridViewLinkCell)item.Cells[0];
                DataGridViewTextBoxCell sel1 = (DataGridViewTextBoxCell)item.Cells[1];

                if (sel0.Value is isimID)
                {
                    string id = ""; id = ((isimID)sel0.Value).id;
                    string isim = ""; isim = ((isimID)sel0.Value).isim;
                    string replik = ""; replik = sel1.Value.ToString();

                    if ((id != "") && (isim != "Başlık Ekle") && (replik != ""))
                    {
                        Replik.KisiSoz yenikisisoz = new Replik.KisiSoz();
                        yenikisisoz.kisiID = id;
                        yenikisisoz.soz = replik;
                        yeni.alintilar.Add(yenikisisoz);
                    }
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Replik Replik
        {
            get
            {
                return this.yeni;
            }
            set
            {
                this.yeni = value;
            }
        }
    }
}
