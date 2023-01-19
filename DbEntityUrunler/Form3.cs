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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities DBModel = new DbEntityUrunEntities();
        private void button1_Click(object sender, EventArgs e)
        {

            var sorgu = from x in DBModel.TBLADMIN where x.KULLANICI == textBox1.Text && x.SIFRE == textBox2.Text select x;

            if(sorgu.Any())
            {
                Form2 fr = new Form2();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
        }
    }
}
