using DevExpress.Data.Linq.Helpers;
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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            lblToplamUrunSayisi.Text = entities.Products.Count().ToString();
            lblToplamKategoriSayisi.Text = entities.Categories.Count().ToString();
            lblToplamStokSayisi.Text = entities.Products.Sum(x => x.UnitsInStock).ToString();
            lblEnFazlaStokluUrün.Text=(from x in entities.Products
                                        orderby x.UnitsInStock descending 
                                        select x.Name).FirstOrDefault();
            lblEnAzStokluUrün.Text = (from x in entities.Products
                                        orderby x.UnitsInStock ascending
                                        select x.Name).FirstOrDefault();
            lblEnYuksekFiyatliUrun.Text = (from x in entities.Products
                                        orderby x.SalePrice descending
                                        select x.Name).FirstOrDefault();
            lblEnDusukFiyatliUrun.Text = (from x in entities.Products
                                        orderby x.SalePrice ascending
                                        select x.Name).FirstOrDefault();
            lblBilgisayarStokSayisi.Text = entities.Products.Count(x => x.CategoryId==1).ToString();
            lblKucukEvAletiStokSayisi.Text = entities.Products.Count(x => x.CategoryId==3).ToString();
            lblBeyazEsyaStokSayisi.Text = entities.Products.Count(x => x.CategoryId==4).ToString();
            lblToplamMarkaSayisi.Text= (from x in entities.Products
                                        select x.Brand).Distinct().Count().ToString();
            lblArizaliUrunSayisi.Text = entities.ProductAcceptances.Count().ToString();
            lblEnFazlaUrünKategorisi.Text = entities.maxkategoriurun().FirstOrDefault();

        }
    }
}
