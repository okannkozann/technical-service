using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechnicalService.Formlar
{
    public partial class FrmArizaliUrunler : Form
    {
        public FrmArizaliUrunler()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmArizaliUrunler_Load(object sender, EventArgs e)
        {
            List();

            lblArizaliUrunSayisi.Text = entities.ProductAcceptances.Count(x=>x.ProductStatus == true).ToString();
            lblTamamlanmisUrunSayisi.Text = entities.ProductAcceptances.Count(x=>x.ProductStatus == false).ToString();
            lblToplamUrunSayisi.Text = entities.Products.Count().ToString();
            lblParcaBekleyenUrunSayisi.Text= entities.ProductAcceptances.Count(x=>x.ProductStatusDetail == " Parça Bekliyor").ToString();
            lblCevapBeklenen.Text= entities.ProductAcceptances.Count(x=>x.ProductStatusDetail == " Mesaj Bekliyor").ToString();
            lblİptalEdilen.Text= entities.ProductAcceptances.Count(x=>x.ProductStatusDetail == " İptal Bekliyor").ToString();

            ConnectionStatistic();

        }

        private void List()
        {
            var degerler = from x in entities.ProductAcceptances
                           select new
                           {
                               x.ProcessId,

                               x.Currents.FirstName,
                               x.Currents.LastName,
                               Employee = x.Employees.FirstName,
                               x.ArrivalDate,
                               x.ReleaseDate,
                               x.ProductSerialNumber
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void ConnectionStatistic()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=OKANKOZAN;Initial Catalog=TechnicalService;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ProductStatusDetail,count(*) from ProductAcceptances group by ProductStatusDetail ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
