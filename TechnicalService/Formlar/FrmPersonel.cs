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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            EmployeeByList();
            EmployeeByInformation();
        }
        
        private void EmployeeByInformation()
        {
            // Personel 1 bilgileri
            string ad1, soyad1;
            ad1 = entities.Employees.First(x => x.Id == 1).FirstName;
            soyad1 = entities.Employees.First(x => x.Id == 1).LastName;
            labelControl22.Text = ad1 + " " + soyad1;
            labelControl21.Text = entities.Employees.First(x => x.Id == 1).Departments.Name;
            labelControl20.Text = entities.Employees.First(x => x.Id == 1).MailAddress;

            // Personel 2 bilgileri
            string ad2, soyad2;
            ad2 = entities.Employees.First(x => x.Id == 2).FirstName;
            soyad2 = entities.Employees.First(x => x.Id == 2).LastName;
            labelControl25.Text = ad2 + " " + soyad2;
            labelControl23.Text = entities.Employees.First(x => x.Id == 2).Departments.Name;
            labelControl24.Text = entities.Employees.First(x => x.Id == 2).MailAddress;

            // Personel 3 bilgileri
            string ad3, soyad3;
            ad3 = entities.Employees.First(x => x.Id == 3).FirstName;
            soyad3 = entities.Employees.First(x => x.Id == 3).LastName;
            labelControl28.Text = ad3 + " " + soyad3;
            labelControl26.Text = entities.Employees.First(x => x.Id == 3).Departments.Name;
            labelControl27.Text = entities.Employees.First(x => x.Id == 3).MailAddress;

            // Personel 4 bilgileri
            string ad4, soyad4;
            ad4 = entities.Employees.First(x => x.Id == 4).FirstName;
            soyad4 = entities.Employees.First(x => x.Id == 4).LastName;
            labelControl31.Text = ad4 + " " + soyad4;
            labelControl29.Text = entities.Employees.First(x => x.Id == 4).Departments.Name;
            labelControl30.Text = entities.Employees.First(x => x.Id == 4).MailAddress;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("FirstName").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("LastName").ToString();
            //lkUpDepartman.Text = gridView1.GetFocusedRowCellValue("DepartmanId").ToString();
            //txtFotograf.Text = gridView1.GetFocusedRowCellValue("Photography").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("MailAddress").ToString();
            txtTelefon.Text = gridView1.GetFocusedRowCellValue("PhoneNumber").ToString();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            EmployeeByList();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            EmployeeByAdd();
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EmployeeByUpdate();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            EmployeeByDelete();
        }
        private void EmployeeByAdd()
        {
            Employees employees = new Employees();
            employees.FirstName = txtAd.Text;
            employees.LastName = txtSoyad.Text;
            employees.MailAddress = txtMail.Text;
            employees.PhoneNumber = txtTelefon.Text;
            entities.Employees.Add(employees);
            entities.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EmployeeByList();
        }
        private void EmployeeByUpdate()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Employees.Find(id);
            deger.LastName = txtSoyad.Text;
            deger.MailAddress = txtMail.Text;
            deger.PhoneNumber = txtTelefon.Text;
            entities.SaveChanges();
            MessageBox.Show("Personel Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            EmployeeByList();
        }

        
        private void EmployeeByDelete()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Employees.Find(id);
            entities.Employees.Remove(deger);
            entities.SaveChanges();
            MessageBox.Show("Personel Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            EmployeeByList();
        }
        private void EmployeeByList()
        {
            //var degerler = db.Products.ToList();
            var degerler = from e in entities.Employees
                           select new
                           {
                               e.Id,
                               e.FirstName,
                               e.LastName,
                              DepartmentName= e.Departments.Name,
                               e.MailAddress,
                               e.PhoneNumber
       
                           };
            gridControl1.DataSource = degerler.ToList();

            lkUpDepartman.Properties.DataSource = (from x in entities.Departments
                                                   select new
                                                   {
                                                       x.Id,
                                                       x.Name
                                                   }).ToList();

        }

    }
}
