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
    public partial class FrmYeniCari : Form
    {
        public FrmYeniCari()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Currents currents = new Currents();
            currents.FirstName = txtAd.Text;
            currents.LastName = txtSoyad.Text;
            currents.City = txtIl.Text;
            currents.District = txtIlce.Text;
            entities.Currents.Add(currents);
            entities.SaveChanges();
            MessageBox.Show("Cari Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmYeniCari_Load(object sender, EventArgs e)
        {

        }
    }
}
