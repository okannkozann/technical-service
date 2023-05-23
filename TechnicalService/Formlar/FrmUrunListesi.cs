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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        
        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            ProductByList();
            TransferByLookUp();
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ProductByAdd();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ProductByList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
                txtUrunAd.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
                txtMarka.Text = gridView1.GetFocusedRowCellValue("Brand").ToString();
                txtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("PurchasePrice").ToString();
                txtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SalePrice").ToString();
                txtStokAdet.Text = gridView1.GetFocusedRowCellValue("UnitsInStock").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Categories").ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata");
            }
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ProductByDelete();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            ProductByUpdate();
            
        }
        private void ProductByDelete()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Products.Find(id);
            entities.Products.Remove(deger);
            entities.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ProductByList();
        }
        private void ProductByUpdate()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Products.Find(id);
            deger.Name = txtUrunAd.Text;
            deger.UnitsInStock = short.Parse(txtStokAdet.Text);
            deger.Brand = txtMarka.Text;
            deger.PurchasePrice = decimal.Parse(txtAlisFiyat.Text);
            deger.SalePrice = decimal.Parse(txtSatisFiyat.Text);
            deger.CategoryId = byte.Parse(lookUpEdit1.EditValue.ToString());
            entities.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ProductByList();
        }
        private void ProductByAdd()
        {
            Products products = new Products();
            products.Name = txtUrunAd.Text;
            products.Brand = txtMarka.Text;
            products.PurchasePrice = decimal.Parse(txtAlisFiyat.Text);
            products.SalePrice = decimal.Parse(txtSatisFiyat.Text);
            products.UnitsInStock = short.Parse(txtStokAdet.Text);
            products.State = false;
            products.CategoryId = byte.Parse(lookUpEdit1.EditValue.ToString());
            entities.Products.Add(products);
            entities.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProductByList();
        }
        private void ProductByList()
        {
            //var degerler = db.Products.ToList();
            var degerler = from p in entities.Products
                           select new
                           {
                               p.Id,
                               p.Name,
                               p.Brand,
                               Categories = p.Categories.CategoryName,
                               p.UnitsInStock,
                               p.PurchasePrice,
                               p.SalePrice
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void TransferByLookUp()
        {
            lookUpEdit1.Properties.DataSource = (from x in entities.Categories
                                                 select new
                                                 {
                                                     x.Id,
                                                     x.CategoryName,
                                                 }).ToList();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAlisFiyat.Text = "";
            txtSatisFiyat.Text = "";
            txtId.Text = "";
            txtMarka.Text = "";
            txtStokAdet.Text = "";
            txtUrunAd.Text = "";

        }
    }
}
