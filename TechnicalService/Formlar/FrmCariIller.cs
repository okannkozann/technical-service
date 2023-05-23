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
    public partial class FrmCariIller : Form
    {
        public FrmCariIller()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();

        SqlConnection connection = new SqlConnection(@"Data Source=OKANKOZAN;Initial Catalog=TechnicalService;Integrated Security=True");
        private void FrmCariIller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 92);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 25);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 42);
            //chartControl1.Series["Series 1"].Points.AddPoint("Antalya", 32);
            //chartControl1.Series["Series 1"].Points.AddPoint("Niğde", 12);

            gridControl1.DataSource = entities.Currents.OrderBy(x => x.City).GroupBy(y => y.City).Select(z => new
            {
                z.Key,
                Toplam = z.Count()
            }).ToList();

            connection.Open();
            SqlCommand command = new SqlCommand("select City,Count(*) from Currents group by City",connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            connection.Close();
        }
    }
}
