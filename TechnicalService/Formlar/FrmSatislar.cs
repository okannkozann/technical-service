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
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmSatislar_Load(object sender, EventArgs e)
        {

            SaleByList();
        }
        private void SaleByList()
        {
            var degerler = from x in entities.ProductMovements
                           select new
                           {
                               x.Id,
                               x.Products.Name,
                               Currents = x.Currents.FirstName + " " + x.Currents.LastName,
                               Employee = x.Employees.FirstName + " " + x.Employees.LastName,
                               x.Date,
                               x.Amount,
                               x.Price,
                               x.ProductSerialNumber

                           };
            gridControl1.DataSource = degerler.ToList();
        }
    }
}
