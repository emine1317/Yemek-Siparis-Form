using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace MutfakPerisi
{
    public partial class YöneticiGiriş : Form
    {
        public YöneticiGiriş()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Kullanıcı Adı")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Kullanıcı Adı";
                textBox3.ForeColor = Color.Black;
            }
        }
        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Şifre";
                textBox4.ForeColor = Color.Black;
                textBox4.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Şifre")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                textBox4.PasswordChar = '*';
            }

        }
        bool isThere;
        private void button1_Click(object sender, EventArgs e)
        {
            string Kullanıcı = textBox3.Text;
            string şifre = textBox4.Text;

            connection.Open();

            SqlCommand command = new SqlCommand("select YöneticiKullanıcıAdı , YöneticiŞifre from Yönetici", connection);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                if (Kullanıcı == reader["YöneticiKullanıcıAdı"].ToString() && şifre == reader["YöneticiŞifre"].ToString())
                {
                    isThere = true;
                    break;
                }

                else if (Kullanıcı != reader["YöneticiKullanıcıAdı"].ToString() || şifre != reader["YöneticiŞifre"].ToString())
                {
                    isThere = false;



                }

                //connection.Close();
            }

            connection.Close();

            if (isThere)
            {
                MessageBox.Show("Başarılı giriş yaptınız");
              sil g = new sil();
                g.ShowDialog();
                this.Hide();

            }

            else
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void YöneticiGiriş_Load(object sender, EventArgs e)
        {

        }
    }
}
