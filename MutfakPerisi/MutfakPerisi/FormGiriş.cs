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
    public partial class FormGiriş : Form
    {
        public FormGiriş()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool move;
        int mouse_x;
        int mouse_y;

        private void FormGiriş_MouseDown(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void FormGiriş_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);


            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
                textBox1.ForeColor = Color.Black;
            }
        }
        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }

        }
        bool isThere;
        private void button1_Click(object sender, EventArgs e)
        {
            string Kullanıcı = textBox1.Text;
            string şifre = textBox2.Text;

            connection.Open();

            SqlCommand command = new SqlCommand("select MüşteriKullanıcıAdı , MüşteriŞifre from Müşteri", connection);
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {

                if (Kullanıcı == reader["MüşteriKullanıcıAdı"].ToString() && şifre == reader["MüşteriŞifre"].ToString())
                {
                    isThere = true;
                    break;
                }

                else if (Kullanıcı != reader["MüşteriKullanıcıAdı"].ToString() || şifre != reader["MüşteriŞifre"].ToString())
                {
                    isThere = false;



                }

                //connection.Close();
            }

            connection.Close();

            if (isThere)
            {
                MessageBox.Show("Başarılı giriş yaptınız");

            }

            else
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");


            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = Convert.ToChar(none);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 g = new Form3();
            g.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YöneticiGiriş g = new YöneticiGiriş();
            g.ShowDialog();
            this.Hide();
        }
    }
}
