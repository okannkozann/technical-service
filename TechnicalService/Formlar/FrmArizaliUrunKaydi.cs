using DevExpress.XtraEditors;
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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ProductAcceptancesAdd();
        }
        private void ProductAcceptancesAdd()
        {
            ProductAcceptances productAcceptances = new ProductAcceptances();
            productAcceptances.CurrentId = int.Parse(lookUpEdit1.EditValue.ToString());
            productAcceptances.EmployeeId = short.Parse(lookUpEdit2.EditValue.ToString());
            productAcceptances.ArrivalDate = DateTime.Parse(txtTarih.Text);
            productAcceptances.ProductSerialNumber = txtSeriNumarasi.Text;
            productAcceptances.ProductStatus = true;
            productAcceptances.ProductStatusDetail = " Ürün Kaydoldu";
            entities.ProductAcceptances.Add(productAcceptances);
            entities.SaveChanges();
            MessageBox.Show("Ürün Kaydı Başarıyla Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {

            GetByCurrentToGrid1();
            GetByEmployeeToGrid2();

        }

        private void GetByCurrentToGrid1()
        {
            lookUpEdit1.Properties.DataSource = (from c in entities.Currents
                                                 select new
                                                 {
                                                     c.Id,
                                                     Name = c.FirstName + " " + c.LastName


                                                 }).ToList();

        }
        private void GetByEmployeeToGrid2()
        {
            lookUpEdit2.Properties.DataSource = (from c in entities.Employees
                                                 select new
                                                 {
                                                     c.Id,
                                                     Name = c.FirstName + " " + c.LastName


                                                 }).ToList();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTarih_Click(object sender, EventArgs e)
        {
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
    }
}
