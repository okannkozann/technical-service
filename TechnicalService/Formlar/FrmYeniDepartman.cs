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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DepartmentByAdd();
        }

        private void DepartmentByAdd()
        {
            Departments departments = new Departments();
            departments.Name = txtYeniKategoriAd.Text;
            entities.Departments.Add(departments);
            entities.SaveChanges();
            MessageBox.Show("Departman Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FrmDepartman frmDepartman = new FrmDepartman();
            frmDepartman.Show();
        }

        private void FrmYeniDepartman_Load(object sender, EventArgs e)
        {

        }
    }
}
