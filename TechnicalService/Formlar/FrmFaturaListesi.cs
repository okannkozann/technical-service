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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            InvoiceBylist();
            TransferByLookUp();

        }
        private void TransferByLookUp()
        {
            lookUpEdit1.Properties.DataSource = (from x in entities.Currents
                                                 select new
                                                 {
                                                     x.Id,
                                                     Name = x.FirstName + " " + x.LastName

                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in entities.Employees
                                                 select new
                                                 {
                                                     x.Id,
                                                     Name = x.FirstName + " " + x.LastName

                                                 }).ToList();
        }
        private void InvoiceBylist()
        {
            var degerler = from x in entities.InvoiceInformations
                           select new
                           {
                               x.Id,
                               x.SerialName,
                               x.SerialNumber,
                               x.Date,
                               x.Time,
                               x.TaxAdministration,
                               CurrentName = x.Currents.FirstName + " " + x.Currents.LastName,
                               EmployeeName = x.Employees.FirstName + " " + x.Employees.LastName
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            InvoiceBylist();
        }
        

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            InvoiceByAdd();

        }
        private void InvoiceByAdd()
        {
            InvoiceInformations invoiceInformations = new InvoiceInformations();
            invoiceInformations.SerialName = (txtSeri.Text).ToUpper();
            invoiceInformations.SerialNumber = int.Parse(txtSiraNo.Text);
            invoiceInformations.Date = Convert.ToDateTime(TxtTarih.Text);
            invoiceInformations.Time = txtSaat.Text;
            invoiceInformations.TaxAdministration = (TxtVergiDairesi.Text).ToUpper();
            invoiceInformations.CurrentId = int.Parse(lookUpEdit1.EditValue.ToString());
            invoiceInformations.EmployeeId = short.Parse(lookUpEdit2.EditValue.ToString());
            entities.InvoiceInformations.Add(invoiceInformations);
            entities.SaveChanges();
            MessageBox.Show("Fatura Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InvoiceBylist();
        }
        private void InvoiceByUpdate()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.InvoiceInformations.Find(id);
            deger.SerialName = txtSeri.Text;
            deger.SerialNumber = short.Parse(txtSiraNo.Text);
            deger.Date = Convert.ToDateTime(TxtTarih.Text);
            deger.Time = txtSaat.Text;
            deger.TaxAdministration = TxtVergiDairesi.Text;
            //deger.CurrentId = int.Parse(lookUpEdit1.EditValue.ToString());
            //deger.EmployeeId = short.Parse(lookUpEdit2.EditValue.ToString());
            entities.SaveChanges();
            MessageBox.Show("Fatura Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            InvoiceBylist();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtSeri.Text = gridView1.GetFocusedRowCellValue("SerialName").ToString();
            txtSiraNo.Text = gridView1.GetFocusedRowCellValue("SerialNumber").ToString();
            TxtTarih.Text= gridView1.GetFocusedRowCellValue("Date").ToString();
            txtSaat.Text = gridView1.GetFocusedRowCellValue("Time").ToString();
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("TaxAdministration").ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            InvoiceByUpdate();
            InvoiceBylist();
        }
    }
}
