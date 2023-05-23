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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }
        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Employees employees = new Employees();
            employees.FirstName = txtAd.Text;
            employees.LastName = txtSoyad.Text;
            employees.MailAddress = txtMail.Text;
            employees.PhoneNumber = txtTelefon.Text;
            entities.Employees.Add(employees);
            entities.SaveChanges();
            MessageBox.Show("Personel Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtUrunAd_Click(object sender, EventArgs e)
        {
            txtAd.Text = "";
            txtAd.Focus();
        }

        private void txtSoyad_Click(object sender, EventArgs e)
        {
            txtSoyad.Text = "";
            txtSoyad.Focus();
        }

        private void txtDepartman_Click(object sender, EventArgs e)
        {
            txtDepartman.Text = "";
            txtDepartman.Focus();
        }

        private void txtMail_Click(object sender, EventArgs e)
        {
            txtMail.Text = "";
            txtMail.Focus();
        }

        private void txtTelefon_Click(object sender, EventArgs e)
        {
            txtTelefon.Text = "";
            txtTelefon.Focus();
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
