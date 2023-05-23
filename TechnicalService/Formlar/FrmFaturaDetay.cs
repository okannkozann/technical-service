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
    public partial class FrmFaturaDetay : Form
    {
        public FrmFaturaDetay()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {
            InvoiceDetailByList();
        }
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            InvoiceDetailByAdd();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            InvoiceDetailByList();
        }

        private void InvoiceDetailByAdd()
        {
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails.ProductName = txtUrun.Text;
            invoiceDetails.ProductAmount = short.Parse(txtAdet.Text);
            invoiceDetails.UnitsInPrice = decimal.Parse(txtBirimFiyat.Text);
            invoiceDetails.TotalPrice = decimal.Parse(txtToplamTutar.Text);
            invoiceDetails.InvoiceId = int.Parse(txtFaturaId.Text);
            entities.InvoiceDetails.Add(invoiceDetails);
            entities.SaveChanges();
            MessageBox.Show("Fatura Detayı Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InvoiceDetailByList();
        }
        private void InvoiceDetailByList()
        {
            var degerler = from x in entities.InvoiceDetails
                           select new
                           {
                               x.Id,
                               x.ProductName,
                               x.ProductAmount,
                               x.UnitsInPrice,
                               x.TotalPrice,
                               x.InvoiceId
                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
