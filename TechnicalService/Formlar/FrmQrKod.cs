using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;

namespace TechnicalService.Formlar
{
    public partial class FrmQrKod : Form
    {
        public FrmQrKod()
        {
            InitializeComponent();
        }

        private void btnKodOlustur_Click(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            pictureEdit1.Image = encoder.Encode(txtSeriNo.Text);
        }
    }
}
