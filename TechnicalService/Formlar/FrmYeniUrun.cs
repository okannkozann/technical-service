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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
            Products products = new Products();
            products.Name = txtUrunAd.Text;
            products.Brand = txtMarka.Text;
            products.PurchasePrice = decimal.Parse(txtAlisFiyat.Text);
            products.SalePrice=decimal.Parse(txtSatisFiyat.Text);
            products.CategoryId = byte.Parse(lookUpEdit1.EditValue.ToString());
            products.UnitsInStock = short.Parse(txtStokAdet.Text);
            entities.Products.Add(products);
            entities.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void txtUrunAd_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = "";
            txtUrunAd.Focus();
        }

        private void txtMarka_Click(object sender, EventArgs e)
        {
            txtMarka.Text = "";
            txtMarka.Focus();
        }

        private void txtAlisFiyat_Click(object sender, EventArgs e)
        {
            txtAlisFiyat.Text = "";
            txtAlisFiyat.Focus();
        }
        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();

        

        private void txtSatisFiyat_Click(object sender, EventArgs e)
        {
            txtSatisFiyat.Text = "";
            txtSatisFiyat.Focus();
        }

        private void txtStokAdet_Click(object sender, EventArgs e)
        {
            txtStokAdet.Text = "";
            txtStokAdet.Focus();
        }
        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in entities.Categories
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.CategoryName,
                                                 }).ToList();
        }
    }
}
