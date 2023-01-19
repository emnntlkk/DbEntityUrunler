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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities DBModel = new DbEntityUrunEntities();


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = DBModel.TBLKATEGORI.Count().ToString();
            label3.Text = DBModel.TBLURUN.Count().ToString();
            label5.Text = DBModel.TBLMUSTERI.Count(x => x.DURUM == true).ToString();
            label7.Text = DBModel.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            label13.Text = DBModel.TBLURUN.Sum(x => x.STOK).ToString();
            label21.Text = DBModel.TBLURUN.Sum(x => x.FIYAT).ToString() + "TL";
            label11.Text = (from x in DBModel.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label9.Text = (from x in DBModel.TBLURUN orderby x.FIYAT select x.URUNAD).FirstOrDefault();
            label15.Text = DBModel.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            label23.Text = (from x in DBModel.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            label19.Text = DBModel.MARKAGETIR().FirstOrDefault();



        }
    }
}
