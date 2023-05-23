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
    public partial class FrmAjanda : Form
    {
        public FrmAjanda()
        {
            InitializeComponent();
        }

        TechnicalServiceEntities1 entities = new TechnicalServiceEntities1();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            NoteByList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            NoteByAdd();
            NoteByList();

        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            NoteByList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            NoteByUpdate();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            NoteByDelete();
        }

        private void NoteByAdd()
        {
            Notes notes = new Notes();
            notes.Title = txtBaslik.Text;
            notes.Contents = txtIcerik.Text;
            notes.Status = false;
            entities.Notes.Add(notes);
            entities.SaveChanges();
            MessageBox.Show("Not Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void NoteByUpdate()
        {

            if (checkDurum .Checked == true)
            {
                int id = int.Parse(txtId.Text);
                var deger = entities.Notes.Find(id);
                deger.Status = true;
                entities.SaveChanges();
                MessageBox.Show("Not okundu bilgisi değiştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NoteByList();
            }
            
        }
        private void NoteByList()
        {
            gridControl1.DataSource = entities.Notes.Where(x => x.Status == false).ToList();
            gridControl2.DataSource = entities.Notes.Where(y => y.Status == true).ToList();

        }

       

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtBaslik.Text = gridView1.GetFocusedRowCellValue("Title").ToString();
            txtIcerik.Text = gridView1.GetFocusedRowCellValue("Contents").ToString();
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView2.GetFocusedRowCellValue("Id").ToString();
            txtBaslik.Text = gridView2.GetFocusedRowCellValue("Title").ToString();
            txtIcerik.Text = gridView2.GetFocusedRowCellValue("Contents").ToString();
        }
        private void NoteByDelete()
        {
            int id = int.Parse(txtId.Text);
            var deger = entities.Notes.Find(id);
            entities.Notes.Remove(deger);
            entities.SaveChanges();
            MessageBox.Show("Not Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            NoteByList();
        }

        
    }
}
