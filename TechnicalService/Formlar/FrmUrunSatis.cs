using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalService.Formlar
{
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            MakeSale();

        }
        private void MakeSale()
        {
            ProductMovements productMovements = new ProductMovements();
            productMovements.ProductId = byte.Parse(txtUrunId.Text);
            productMovements.CurrentId = int.Parse(txtMusteri.Text);
            productMovements.EmployeeId = short.Parse(txtPersonel.Text);
            productMovements.Date = DateTime.Parse(txtTarih.Text);
            productMovements.Amount = short.Parse(txtAdet.Text);
            productMovements.Price = decimal.Parse(txtSatisFiyati.Text);
            productMovements.ProductSerialNumber = txtSeriNumarasi.Text;
            entities.ProductMovements.Add(productMovements);
            entities.SaveChanges();
            MessageBox.Show("Ürün Satışı Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {

        }
    }
}
