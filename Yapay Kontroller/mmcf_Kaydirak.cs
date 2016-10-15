using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMC_Filmograf
{
    public partial class mmcf_Kaydirak : UserControl
    {
        Point birakmaNoktasi = new Point();

        #region Kaydırak Delegeleri

        public Delegate yukariYuksekHizli;
        public Delegate yukariOrtaHizli;
        public Delegate yukariDusukHizli;
        public Delegate asagiDusukHizli;
        public Delegate asagiOrtaHizli;
        public Delegate asagiYuksekHizli;

        #endregion

        Timer zamanlayici = new Timer();

        public mmcf_Kaydirak()
        {
            InitializeComponent();
            this.kaydirOrta.MouseUp += new MouseEventHandler(button3_MouseUp);
            this.kaydirOrta.MouseMove += new MouseEventHandler(button3_MouseMove);
            this.kaydirOrta.MouseDown += new MouseEventHandler(button3_MouseDown);
            this.Resize += new EventHandler(UserControl2_Resize);
            zamanlayici.Tick += new EventHandler(zamanlayici_Tick);
        }

        void zamanlayici_Tick(object sender, EventArgs e)
        {
            int bolge = 0;
            int birimUzunluk = 1;
            int ortaninYukariyaKonumu = 0;
            ortaninYukariyaKonumu = this.kaydirOrta.Location.Y - this.kaydirUst.Height + this.kaydirOrta.Height / 2;
            birimUzunluk = (this.Height - this.kaydirAlt.Height - this.kaydirUst.Height) / 6;
            bolge = ortaninYukariyaKonumu / birimUzunluk;

            switch (bolge)
            {
                case 0: //Birinci bölgedeyse : Yukarı Yüksek Hızlı
                    if (yukariYuksekHizli != null)
                        this.yukariYuksekHizli.DynamicInvoke(new object[] { true });
                    break;
                case 1://İkinci bölgedeyse : Yukarı Orta Hızlı
                    if (yukariOrtaHizli != null)
                        this.yukariOrtaHizli.DynamicInvoke(new object[] { true });
                    break;
                case 2://Üçüncü bölgedeyse : Yukarı Düşük Hızlı
                    if (yukariDusukHizli != null)
                        this.yukariDusukHizli.DynamicInvoke(new object[] { true });
                    break;
                case 3://Dördüncü bölgedeyse : Aşağı Düşük Hızlı
                    if (asagiDusukHizli != null)
                        this.asagiDusukHizli.DynamicInvoke(new object[] { true });
                    break;
                case 4://Beşinci bölgedeyse: Aşağı Orta Hızlı
                    if (asagiOrtaHizli != null)
                        this.asagiOrtaHizli.DynamicInvoke(new object[] { true });
                    break;
                case 5://Altıncı bölgedeyse: Aşağı Yüksek Hızlı
                    if (asagiYuksekHizli != null)
                        this.asagiYuksekHizli.DynamicInvoke(new object[] { true });
                    break;
                default:
                    break;
            }
        }


        private void UserControl2_Resize(object sender, EventArgs e)
        {
            Point ortaNokta;
            ortaNokta = new Point(0, this.Height / 2 - this.kaydirOrta.Height / 2);
            this.kaydirOrta.Location = ortaNokta;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point ortaNokta;
                ortaNokta = new Point(0, this.Height / 2 - this.kaydirOrta.Height / 2);
                this.kaydirOrta.Location = ortaNokta;
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                birakmaNoktasi.X = e.X;
                birakmaNoktasi.Y = e.Y;

                if (zamanlayici != null)
                {
                    zamanlayici.Interval = 10;
                    zamanlayici.Enabled = true;
                    zamanlayici.Start();
                }
            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point koordinat;
                koordinat = this.PointToClient(Control.MousePosition);
                koordinat.Offset(-birakmaNoktasi.X, -birakmaNoktasi.Y);
                koordinat.X = 0;
                if ((koordinat.Y >= this.kaydirUst.Width) & (koordinat.Y + kaydirOrta.Height <= this.kaydirAlt.Location.Y))
                {
                    this.kaydirOrta.Location = koordinat;
                }
            }
        }
    }
}
