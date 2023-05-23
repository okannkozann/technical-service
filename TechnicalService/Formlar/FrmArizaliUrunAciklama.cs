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
    public partial class FrmArizaliUrunAciklama : Form
    {
        public FrmArizaliUrunAciklama()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DefectDetailAdd();

        }
        private void DefectDetailAdd()
        {
            ProductTransactions productTransactions = new ProductTransactions();
            productTransactions.Description = richTextBox1.Text;
            productTransactions.Date = DateTime.Parse(txtTarih.Text);
            productTransactions.SerialNumber = txtSeriNo.Text;
            entities.ProductTransactions.Add(productTransactions);
            entities.SaveChanges();
            MessageBox.Show("Arıza Açıklama Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            
        }
    }
}
