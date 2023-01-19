using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbEntityUrunler
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        #region Nesneler
        DbEntityUrunEntities DbModel = new DbEntityUrunEntities();
        TBLURUN TblUrun = new TBLURUN();
        #endregion


        #region Listele Metodu
        void listele()
        {
            dataGridView1.DataSource  = (from x in DbModel.TBLURUN
                               select new
                               {
                                   x.URUNID,
                                   x.URUNAD,
                                   x.MARKA,
                                   x.STOK,
                                   x.FIYAT,
                                   x.TBLKATEGORI.AD,
                                   x.DURUM
                               }).ToList();
        }
        #endregion


        #region Listele Butonu
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }
        #endregion

        #region Ekle Butonu

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblUrun.URUNAD = TxtUrunAd.Text;
            TblUrun.MARKA = TxtMarka.Text;
            TblUrun.STOK = short.Parse(TxtStok.Text);
            TblUrun.KATEGORI = int.Parse(CmbKategori.SelectedValue.ToString());
            TblUrun.FIYAT = decimal.Parse(TxtFiyat.Text);
            TblUrun.DURUM = true;
            DbModel.TBLURUN.Add(TblUrun);
            DbModel.SaveChanges();
            MessageBox.Show("Ürün sisteme eklendi");
            listele();
        }



        #endregion


        #region Sil Butonu
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtUrunID.Text);
            var SilinecekSatir= DbModel.TBLURUN.Find(id);
            DbModel.TBLURUN.Remove(SilinecekSatir);
            DbModel.SaveChanges();
            MessageBox.Show("Ürün silindi");
            listele();
        }

        #endregion
        

        #region Güncelle Butonu
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtUrunID.Text);
            var SilinecekSatir = DbModel.TBLURUN.Find(id);
            SilinecekSatir.URUNAD = TxtUrunAd.Text;
            SilinecekSatir.STOK = short.Parse(TxtStok.Text);
            SilinecekSatir.MARKA = TxtMarka.Text;
            DbModel.SaveChanges();
            MessageBox.Show("Ürün güncellendi");
            listele();

        }

        #endregion

        #region Load Metodu

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in DbModel.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }).ToList();
            CmbKategori.ValueMember = "ID";
            CmbKategori.DisplayMember = "AD";
            CmbKategori.DataSource = kategoriler;

            
        
        }
        #endregion
    }
}
