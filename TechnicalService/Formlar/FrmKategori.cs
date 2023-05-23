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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmKategori_Load(object sender, EventArgs e)
        {
            //var degerler = entities.Categories.ToList();
            CategoryByList();
        }

        private void CategoryByList()
        {
            var degerler = from c in entities.Categories
                           select new
                           {
                               c.Id,
                               c.CategoryName
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            CategoryByAdd();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            CategoryByList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtKategoriId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtKategoriAd.Text = gridView1.GetFocusedRowCellValue("CategoryName").ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            CategoryByDelete();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            CategoryByUpdate();
        }

        private void CategoryByUpdate()
        {
            int id = int.Parse(txtKategoriId.Text);
            var deger = entities.Categories.Find(id);
            deger.CategoryName = txtKategoriAd.Text;
            entities.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            CategoryByList();
        }
        private void CategoryByDelete()
        {
            int id = int.Parse(txtKategoriId.Text);
            var deger = entities.Categories.Find(id);
            entities.Categories.Remove(deger);
            entities.SaveChanges();
            MessageBox.Show("Kategori Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            CategoryByList();
        }
        private void CategoryByAdd()
        {
            if (txtKategoriAd.Text != "" && txtKategoriAd.Text.Length <=30)
            {
                Categories categories = new Categories();
                categories.CategoryName = txtKategoriAd.Text;
                entities.Categories.Add(categories);
                entities.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CategoryByList();
            }
            else
            {
                MessageBox.Show("Kategori Adı boş geçilemez ve 30 karakterden uzun olamaz !");
            }
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKategoriAd.Text = " ";
            txtKategoriId.Text = " ";
        }
    }
}
