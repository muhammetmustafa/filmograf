using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMC_Filmograf
{
    public partial class f_ResimGosterici : Form
    {
        Image resim;

        Point tasimaNoktasi;

        public f_ResimGosterici()
        {
            InitializeComponent();
            this.DoubleClick += new EventHandler(f_ResimGosterici_DoubleClick);
            this.MouseDown += new MouseEventHandler(f_ResimGosterici_MouseDown);
            this.MouseMove += new MouseEventHandler(f_ResimGosterici_MouseMove);
        }


        void f_ResimGosterici_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Point koordinat;
                koordinat = Control.MousePosition;
                koordinat.Offset(-tasimaNoktasi.X, -tasimaNoktasi.Y);
                Location = koordinat;
            }
        }

        void f_ResimGosterici_MouseDown(object sender, MouseEventArgs e)
        {
            tasimaNoktasi = new Point();
            tasimaNoktasi = e.Location;
        }

        void f_ResimGosterici_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_ResimGosterici_Load(object sender, EventArgs e)
        {
            if (this.resim != null)
            {
                this.BackgroundImage = resim;
                this.Width = resim.Width;
                this.Height = resim.Height;
            }
            else
                this.BackgroundImage = global::MMC_Filmograf.Properties.Resources.kirmizicarpi;
        }

        public Image Resim
        {
            set
            {
                this.resim = value;
            }
        }
    }
}
