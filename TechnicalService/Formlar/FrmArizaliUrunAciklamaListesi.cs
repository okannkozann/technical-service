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
    public partial class FrmArizaliUrunAciklamaListesi : Form
    {
        public FrmArizaliUrunAciklamaListesi()
        {
            InitializeComponent();
        }
        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmArizaliUrunAciklamaListesi_Load(object sender, EventArgs e)
        {
            
            gridControl1.DataSource = entities.ProductTransactions.ToList();
        }
    }
}
