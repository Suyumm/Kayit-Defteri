using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FLOKSER_TEKSTİL_İNSAN_KAYNAKLARI_KAYIT_DEFTERİ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\IO.accdb");

        private void kayit()
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from gelen", fiydan);
                DataSet ds = new DataSet();
                liste.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                fiydan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void kayitg()
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from giden", fiydan);
                DataSet ds = new DataSet();
                liste.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                fiydan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayit();
            kayitg();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                fiydan.Open();


                OleDbCommand ekle = new OleDbCommand("insert into gelen values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox8.Text + "')", fiydan);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Başarıyla kaydedildi", "KAYDET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fiydan.Close();
                kayit();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox8.Clear();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter sil = new OleDbDataAdapter("delete from gelen where sira_no='" + textBox1.Text + "'", fiydan);
                DataSet ds = new DataSet();
                sil.Fill(ds);
                fiydan.Close();

                textBox1.Clear();
                MessageBox.Show("Başarıyla Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kayit();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                fiydan.Open();


                OleDbCommand ekle = new OleDbCommand("insert into giden values('" + textBox5.Text + "','" + dateTimePicker3.Text + "','" + textBox7.Text + "','" + textBox6.Text + "')", fiydan);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Başarıyla kaydedildi", "KAYDET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                fiydan.Close();
                kayitg();

                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter sil = new OleDbDataAdapter("delete from giden where sira_no='" + textBox5.Text + "'", fiydan);
                DataSet ds = new DataSet();
                sil.Fill(ds);
                fiydan.Close();

                textBox5.Clear();
                MessageBox.Show("Başarıyla Silindi", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                kayitg();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                fiydan.Close();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
