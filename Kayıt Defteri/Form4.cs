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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kayıt_Defteri
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\IO.accdb");

        private void Form4_Load(object sender, EventArgs e)
        {
            Kayit();
        }

        private void Kayit()
        {
            try
            {
                fiydan.Open();
                OleDbDataAdapter liste = new OleDbDataAdapter("select * from gelen", fiydan);
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

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Henüz Kullanım Dışı");
        }

    }
}
