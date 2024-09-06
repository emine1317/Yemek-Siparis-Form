using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MutfakPerisi
{
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataReader dr2;

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
         
            con = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT KategoriAd FROM Kategoriler";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["KategoriAd"]);

            }

            con.Close();

            Random r = new Random();
            int number = r.Next(20, 24);
            SqlCommand  s= new SqlCommand("select YemekAdı from Yemekler where YemekId="+number+"",connection );
            connection.Open();

            dr2= s.ExecuteReader();
            while (dr2.Read())
            {
               label3.Text= dr2["YemekAdı"].ToString();

            }
          
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGiriş frm = new FormGiriş();
            frm.ShowDialog();
            //Form2 form = new Form2();
            //form.ShowDialog();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0 :
                    Form4 f = new Form4();
                    f.ShowDialog();
                    
                    break;
                case 1:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;




            }

            //comboBox1.Text = "ÇORBALAR";
            //Form4 f = new Form4();
           // f.ShowDialog();
          
            //this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=905535679922");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com/umurkanirem?igshid=YmMyMTA2M2Y=");
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://yandex.com.tr/harita/-/CCUnnSw-tA");
        }
    }
}
