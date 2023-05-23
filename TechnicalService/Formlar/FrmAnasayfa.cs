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
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            gridControl2.DataSource = (from x in entities.Products
                                       select new
                                       {
                                            x.Name,
                                            x.UnitsInStock
                                       }).Where(x => x.UnitsInStock < 30).ToList();

            gridControl1.DataSource = (from y in entities.Currents
                                       select new
                                       {
                                           y.FirstName,
                                           y.LastName,
                                           y.PhoneNumber,
                                           y.City
                                       }).ToList();

            gridControl4.DataSource = entities.urunkategori().ToList();

            DateTime dateTime = DateTime.Today;
            var deger = (from x in entities.Notes.OrderBy(y => y.Id)
                         where (x.Date == dateTime)
                         select new
                         {
                             
                             x.Title,
                             x.Contents
                         });
            gridControl3.DataSource = deger.ToList();

            string konu1, ad1;
            konu1 = entities.Contact.First(x => x.Id == 1).Konu;
            ad1 = entities.Contact.First(x => x.Id == 1).AdSoyad;
            labelControl1.Text = konu1 + " - " + ad1;
        }
    }
}
