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
using System.Data;

namespace MutfakPerisi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //string eklee = "INSERT INTO Adres(Adresİlçe,AdresCadde/Sokak,AdresBinaNo,AdresDaire) values (@İLÇE,@CADDE/SOKAK,@BİNA NO,@DAİRE)";
            //string ekle = "INSERT INTO Müşteri(MüşteriAdSoyad,MüşteriKullanıcıAdı,MüşteriPosta,MüşteriTelefon,MüşterŞifre) values (@AD SOYAD, @KULLANICI ADI, @E-MAİL, @TELEFON, @ŞİFRE)" ;

            //SqlCommand komut = new SqlCommand("INSERT INTO Müşteri(MüşteriAdSoyad,MüşteriKullanıcıAdı,MüşteriPosta,MüşteriTelefon,MüşterŞifre) values (@AD SOYAD, @KULLANICI ADI, @E-MAİL, @TELEFON, @ŞİFRE)",connection);
            //komut = new SqlCommand(ekle, connection);

            //connection.Open();
            try
            {

                //SqlCommand komutt = new SqlCommand("INSERT INTO Adres(Adresİlçe,AdresCadde,AdresBinaNo,AdresDaire) VALUES (@p1,@p2,@p3,@p4) ", connection);

                //connection.Open();


                //komutt.Parameters.AddWithValue("@p1", txtilçe.Text);
                //komutt.Parameters.AddWithValue("@p2", txtsk.Text);
                //komutt.Parameters.AddWithValue("@p3", txtno.Text);
                //komutt.Parameters.AddWithValue("@p4", txtdaire.Text);

                //komutt.ExecuteNonQuery();

                //connection.Close();
                SqlCommand komut = new SqlCommand("INSERT INTO Müşteri(MüşteriAdSoyad,MüşteriKullanıcıAdı,MüşteriPosta,MüşteriTelefon,MüşteriŞifre) VALUES (@p1, @p2, @p3, @p4, @p5)", connection);
                connection.Open();

                komut.Parameters.AddWithValue("@p1", txtad.Text);

                komut.Parameters.AddWithValue("@p2", txtkll.Text);

                komut.Parameters.AddWithValue("@p3", txtmail.Text);

                komut.Parameters.AddWithValue("@p4", txtphone.Text);

                komut.Parameters.AddWithValue("@p5", txtşifre.Text);

                //  komut.Parameters.AddWithValue("@cinsiyet", cinsiyet);


                komut.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }


        }


    }
}
