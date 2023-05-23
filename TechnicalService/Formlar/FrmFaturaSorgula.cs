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
    public partial class FrmFaturaSorgula : Form
    {
        public FrmFaturaSorgula()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();

        private void btnAra_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFaturaId.Text);
            var degerler = (from x in entities.InvoiceDetails
                            select new
                            {
                                x.Id,
                                x.ProductName,
                                x.ProductAmount,
                                x.UnitsInPrice,
                                x.TotalPrice,
                                x.InvoiceId
                            }).Where(x => x.InvoiceId == id);
            gridControl1.DataSource = degerler.ToList();

        }
    }
}
