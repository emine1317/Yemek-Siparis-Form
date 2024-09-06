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
    public partial class sepet : Form
    {
        public sepet()
        {
            InitializeComponent();
        }
        // public string Form2ye_Gidecek_Veri = "";
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
        public int id;
        public string por;
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ödemeniz Başarıyla alınmıştır");
        }

       public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sepet_Load(object sender, EventArgs e)
        {
            // textBox2.Text= Form2ye_Gidecek_Veri;
           // Form4 f = new Form4();
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT*FROM Yemekler WHERE YemekId="+ id +"";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label3.Text = (dr["YemekAdı"]).ToString();
                int birim = Convert.ToInt32(dr["YemekFiyat"]);
                //label5.Text= (dr["YemekFiyat"]).ToString();
             
                label4.Text = (Convert.ToInt32(por) *birim).ToString();
              
            }
            baglanti.Close();


        }
    }
}
