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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Nesneler
        DbEntityUrunEntities DbModel = new DbEntityUrunEntities();
        TBLKATEGORI TblKategori = new TBLKATEGORI();
        #endregion



        #region Listeleme metodu
        void listele() {
            var kategoriler = DbModel.TBLKATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;

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
            
            TblKategori.AD = TxtKategoriAdi.Text;
            DbModel.TBLKATEGORI.Add(TblKategori);
            DbModel.SaveChanges();
            MessageBox.Show("Kategori eklendi");
            listele();
        }
        #endregion

        #region Sil Butonu
        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtKategoriID.Text);
            var SilinecekSatir = DbModel.TBLKATEGORI.Find(id);
            DbModel.TBLKATEGORI.Remove(SilinecekSatir);
            DbModel.SaveChanges();
            MessageBox.Show("Kategori silindi");
            listele();

        }


        #endregion


        #region Güncelle Butonu
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtKategoriID.Text);
            var ktgr = DbModel.TBLKATEGORI.Find(id);
            ktgr.AD = TxtKategoriAdi.Text;
            DbModel.SaveChanges();
            MessageBox.Show("Kategori Güncellendi");
            listele();
        }
        #endregion





    }
}
