using FLOKSER_TEKSTİL_İNSAN_KAYNAKLARI_KAYIT_DEFTERİ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kayıt_Defteri
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }



        OleDbConnection fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\IO.accdb");

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    fiydan.Open();
                    OleDbCommand sil = new OleDbCommand("delete from gelen where sira_no=" + Convert.ToInt32(textBox3.Text) + "", fiydan);
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

        private void Form2_Load(object sender, EventArgs e)
        {
            kayit();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void kayit()
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from gelen", fiydan);
                DataSet ds = new DataSet();
                liste.Fill(ds);
                Form1 f1 = new Form1();
                f1.dataGridView1.DataSource = ds.Tables[0];
                fiydan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }
    }
}
    

