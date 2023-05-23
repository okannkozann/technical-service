using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechnicalService.Formlar;

namespace TechnicalService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.FrmUrunListesi fr3;
        private void btnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmUrunListesi();
                fr3.MdiParent = this;
                fr3.Show();
            }

        }
        Formlar.FrmYeniUrun fr4;
        private void btnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.FrmYeniUrun();
                //fr.MdiParent = this;
                fr4.Show();
            }

        }

        Formlar.FrmKategori fr2;
        private void btnKategoriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmKategori();
                fr2.MdiParent = this;
                fr2.Show();
            }


        }

        private void btnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniKategori fr = new Formlar.FrmYeniKategori();
            fr.Show();

        }
        Formlar.FrmIstatistik fr5;
        private void btnUrunIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmIstatistik();
                fr5.MdiParent = this;
                fr5.Show();
            }

        }
        Formlar.FrmMarka fr6;
        private void btnMarkaIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmMarka();
                fr6.MdiParent = this;
                fr6.Show();
            }

        }

        private void btnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCariListesi fr = new FrmCariListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnCariIstatistigi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCariIller fr = new FrmCariIller();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniCariOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYeniCari fr = new FrmYeniCari();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartman fr = new Formlar.FrmDepartman();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniDepartman fr = new Formlar.FrmYeniDepartman();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonel fr = new Formlar.FrmPersonel();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnYeniPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniPersonel fr = new Formlar.FrmYeniPersonel();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void btnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");

        }

        private void btnDovizKurlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDovizKurlari fr = new Formlar.FrmDovizKurlari();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }

        private void btnyoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYoutube fr = new Formlar.FrmYoutube();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnNotListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Ajanda

            Formlar.FrmAjanda fr = new Formlar.FrmAjanda();
            fr.MdiParent = this;
            fr.Show();
        }
        Formlar.FrmArizaliUrunler fr7;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmArizaliUrunler();
                fr7.MdiParent = this;
                fr7.Show();
            }

        }

        private void btnUrunSatis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatis fr = new Formlar.FrmUrunSatis();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void btnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmSatislar fr = new Formlar.FrmSatislar();
            fr.MdiParent = this;
            fr.Show();
        }
        Formlar.FrmArizaliUrunKaydi fr8;
        private void btnYeniArizaliUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmArizaliUrunKaydi();
                // fr.MdiParent = this;
                fr.Show();
            }
               
        }

        private void btnArizaliUrunAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunAciklama fr = new Formlar.FrmArizaliUrunAciklama();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmArizaliUrunAciklamaListesi fr = new Formlar.FrmArizaliUrunAciklamaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnQrKodOlusur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmQrKod fr = new Formlar.FrmQrKod();
            //fr.MdiParent = this;
            fr.Show();
        }

        private void btnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaListesi fr = new Formlar.FrmFaturaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnFaturaKalemGiris_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaDetay fr = new Formlar.FrmFaturaDetay();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnFaturaSorgula_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmFaturaSorgula fr = new Formlar.FrmFaturaSorgula();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGauge fr = new Formlar.FrmGauge();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnHarita_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmHarita fr = new Formlar.FrmHarita();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmRapor fr = new Formlar.FrmRapor();
            // fr.MdiParent = this;
            fr.Show();
        }

        Formlar.FrmAnasayfa fr;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();
                fr.MdiParent = this;
                fr.Show();
            }

        }

        private void btnAnasayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr == null || fr.IsDisposed)
            {
                fr = new Formlar.FrmAnasayfa();
                fr.MdiParent = this;
                fr.Show();
            }
        }
    }
}
