using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kayıt_Defteri
{
    public partial class Form3 : Form
    {
        OleDbConnection fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\IO.accdb");


        public Form3()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    fiydan.Open();
                    OleDbCommand sil = new OleDbCommand("delete from giden where sira_no=" + Convert.ToInt32(textBox3.Text) + "", fiydan);
                    sil.ExecuteNonQuery();
                    textBox3.Clear();
                    MessageBox.Show("Başarıyla Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fiydan.Close();
                    kayit();

                }
                else
                    MessageBox.Show("Silme İşlemi İptal Edildi", "Veri Silinmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void kayit()
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from giden", fiydan);
                DataSet ds = new DataSet();
                liste.Fill(ds);
                fiydan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            kayit();
        }
    }
}
