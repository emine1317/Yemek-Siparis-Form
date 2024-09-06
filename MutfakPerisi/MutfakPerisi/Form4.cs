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
using System.IO;

namespace MutfakPerisi
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataReader ds;
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");



        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Form4_Load(object sender, EventArgs e)
        {

            con = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT KategoriAd FROM Kategoriler";
            ds = cmd.ExecuteReader();
            while (ds.Read())
            {
                comboBox1.Items.Add(ds["KategoriAd"]);

            }

            con.Close();

            cmd2 = new SqlCommand();
            con.Open();
            cmd2.Connection = con;
            cmd2.CommandText = "SELECT PorsiyonSayısı FROM Porsiyon";
            ds = cmd2.ExecuteReader();
            while (ds.Read())
            {
                comboBox2.Items.Add((ds["PorsiyonSayısı"]).ToString());
                comboBox3.Items.Add((ds["PorsiyonSayısı"]).ToString());
                comboBox4.Items.Add((ds["PorsiyonSayısı"]).ToString());
                comboBox5.Items.Add((ds["PorsiyonSayısı"]).ToString());


            }

            con.Close();

            Label[] labels = new Label[]{
                  label1, label2, label3, label4};
            Label[] labelss = new Label[]{
                  l1, l2, l3, l4};
            Label[] labell = new Label[]{
                  la1, la2, la3, la4};
            for (int i = 0; i < labels.Length+1; i++)
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM Yemekler WHERE YemekID=" + i + "", connection);
                SqlDataReader dr;
                connection.Open();
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    labels[i-1].Text = dr["YemekAdı"].ToString();
                    labelss[i - 1].Text = dr["Yemekİçerik"].ToString();
                    // labels[i].Text = dr["Tür"].ToString();
                    labell[i - 1].Text = dr["YemekFiyat"].ToString();

                }
                connection.Close();
            }
            /*connection.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Yemekler WHERE YemekId=123 ", connection);
            // SqlCommand komut2 = new SqlCommand("SELECT * FROM Yemekler WHERE YemekFiyat ", connection);

            komut.Parameters.AddWithValue("@123", label1.Text);
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@123", label7.Text);
            komut.Parameters.Clear();

            //komut.Parameters.AddWithValue("@10", pictureBox1.Image);

            komut.Connection = connection;
            SqlDataReader dr = komut.ExecuteReader();


            while (dr.Read())
            {
                label1.Text = dr["YemekAdı"].ToString();
                label7.Text = dr["Yemekİçerik"].ToString();
                // pictureBox1.Image =Image.FromFile( dr["YemekResim"].ToString());

            }*/

            connection.Close();
            {

                
            //    try
            //    {
            //        connection.Open();
            //        SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT YemekResim FROM Yemekler WHERE YemekId=11" +
            //            "" + " ", connection));

            //        DataSet dataSet = new DataSet();
            //        dataAdapter.Fill(dataSet);
            //        if (dataSet.Tables[0].Rows.Count == 1)
            //        {
            //            Byte[] data = new Byte[0];
            //            data = (Byte[])(dataSet.Tables["Yemekler"].Rows[0]["YemekResim"]);        // tablodaki coloum ismi
            //            MemoryStream mem = new MemoryStream(data);
            //            pictureBox1.Image = Image.FromStream(mem);

            //            MessageBox.Show("Okuma Başarılı");

            //        }
            //        else
            //        {
            //            pictureBox1.Image = null;
            //            MessageBox.Show("Resim Yok!");
            //        }
            //    }
            //    catch (SqlException se)
            //    {
            //        MessageBox.Show(se.ToString());
            //    }
            //    finally
            //    {
            //        connection.Close();
            //        connection.Dispose();
            //    }
               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT PorsiyonSayısı FROM Porsiyon";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["PorsiyonSayısı"]);
            }
            baglanti.Close();

            
        }

        public void button12_Click(object sender, EventArgs e)
        {
            sepet frm = new sepet();
            frm.id = 1;

            frm.por = (comboBox2.SelectedItem).ToString();
            frm.ShowDialog();

           //int fiyat = Convert.ToInt32(la1.Text);
           // int por = Convert.ToInt32(comboBox1.SelectedItem);
           // int ToplamFiyat = fiyat * por;
           // //MessageBox.Show("sepete yönlendiriliyorsunuz");
           // sepet s = new sepet();
           // s.ShowDialog();
           //// s.Form2ye_Gidecek_Veri =ToplamFiyat.ToString();
           // this.Hide();
             }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            sepet frm = new sepet();
            frm.id = 2;
            frm.por = (comboBox3.SelectedItem).ToString();
            frm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sepet frm = new sepet();
            frm.id = 3;
            frm.por = (comboBox4.SelectedItem).ToString();
            frm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sepet frm = new sepet();
            frm.id = 4;
            frm.por = (comboBox5.SelectedItem).ToString();
            frm.ShowDialog();
        }
    }
}


        

    

