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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            DepartmentByList();
            lblToplamDepartmanSayisi.Text = entities.Departments.Count().ToString();
            lblToplamPersonelSayisi.Text = entities.Employees.Count().ToString();
        }
        

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DepartmentByAdd();
            DepartmentByList();
        }
        

        private void btnSil_Click(object sender, EventArgs e)
        {
            DepartmentByDelete();
        }
        

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Name").ToString();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DepartmentByUpdate();
            
        }
        private void DepartmentByList()
        {
            //var degerler = db.Products.ToList();
            var degerler = from d in entities.Departments
                           select new
                           {
                               d.Id,
                               d.Name

                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void DepartmentByAdd()
        {
            Departments departments = new Departments();
            departments.Name = txtAd.Text;
            entities.Departments.Add(departments);
            entities.SaveChanges();
            MessageBox.Show("Ürün Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DepartmentByDelete()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Departments.Find(id);
            entities.Departments.Remove(deger);
            entities.SaveChanges();
            MessageBox.Show("Departman Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            DepartmentByList();
        }
        private void DepartmentByUpdate()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Departments.Find(id);
            deger.Name = txtAd.Text;
            entities.SaveChanges();
            MessageBox.Show("Departman Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DepartmentByList();
        }
    }
}
