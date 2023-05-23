using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TechnicalService.Formlar
{
    public partial class FrmMarka : Form
    {
        public FrmMarka()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmMarka_Load(object sender, EventArgs e)
        {
            var degerler = entities.Products.OrderBy(x => x.Brand).GroupBy(y => y.Brand).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();

            lblToplamUrunSayisi.Text = entities.Products.Count().ToString();
            lblToplamMarkaSayisi.Text = (from x in entities.Products
                                         select x.Brand).Distinct().Count().ToString();
            lblEnYuksekFiyatliMarka.Text = (from x in entities.Products
                                           orderby x.SalePrice descending
                                           select x.Brand).FirstOrDefault();
            lblEnDusukFiyatliMarka.Text = (from x in entities.Products
                                            orderby x.SalePrice ascending
                                            select x.Brand).FirstOrDefault();
            lblEnFazlaUrunOlanMarka.Text = entities.maxurunmarka().FirstOrDefault();

       

            ConnectionBrand();
            ConnectionCategory();
        }

        private void ConnectionBrand()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=OKANKOZAN;Initial Catalog=TechnicalService;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select brand, COUNT(*) from Products group by brand ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        private void ConnectionCategory()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=OKANKOZAN;Initial Catalog=TechnicalService;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select CategoryName,count(*) from Products join Categories c on c.Id = Products.CategoryId group by CategoryName ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {

        }

       
    }
}
