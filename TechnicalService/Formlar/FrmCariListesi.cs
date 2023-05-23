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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = entities.Currents.ToList();
            lblToplamCariSayisi.Text = entities.Currents.Count().ToString();
            lblToplamIlSayisi.Text = (from x in entities.Currents
                                      select x.City).Distinct().Count().ToString();
        }
    }
}
