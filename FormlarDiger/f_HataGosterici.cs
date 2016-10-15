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
    public partial class f_HataGosterici : Form
    {
        List<Exception> hatalar;

        public f_HataGosterici()
        {
            InitializeComponent();
            hatalar = new List<Exception>();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<Exception> Hatalar
        {
            get
            {
                return this.hatalar;
            }
            set
            {
                this.hatalar = value;
            }
        }

        private void f_HataGosterici_Load(object sender, EventArgs e)
        {
            if (this.hatalar.Count > 0)
            {
                ListViewItem liste = new ListViewItem();
                foreach (Exception hata in hatalar)
                {
                 lvHatalar.Items.Add(hata.Message).SubItems.Add(hata.StackTrace);
                    
                }
            }
        }
    }
}
