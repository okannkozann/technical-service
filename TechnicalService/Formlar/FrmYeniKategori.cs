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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            CategoryByAdd();
        }
        
        private void CategoryByAdd()
        {
            if (txtYeniKategoriAd.Text != "" && txtYeniKategoriAd.Text.Length <= 30)
            {
                Categories categories = new Categories();
                categories.CategoryName = txtYeniKategoriAd.Text;
                entities.Categories.Add(categories);
                entities.SaveChanges();
                MessageBox.Show("Kategori Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Kategori Adı boş geçilemez ve 30 karakterden uzun olamaz !");
            }
        }

        private void txtYeniKategoriAd_Click(object sender, EventArgs e)
        {
            txtYeniKategoriAd.Text = "";
            txtYeniKategoriAd.Focus();
        }
    }
}
