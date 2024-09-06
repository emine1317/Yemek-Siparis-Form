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
using System.IO;

namespace MutfakPerisi
{
    public partial class sil : Form
    {
        public sil()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-VSF9G7I;Initial Catalog=Deneme2;Integrated Security=True");
        void temizle()
        {
            txtAd.Text = "";
            txtFiyat.Text = "";
            txtPors.Text = "";
            txtId.Text = "";
            txtİçerik.Text = "";
            ktgId.Text = "";
        }
            
          
        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'deneme2DataSet2.Yemekler' table. You can move, or remove it, as needed.
            this.yemeklerTableAdapter.Fill(this.deneme2DataSet2.Yemekler);

        }

   

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            FileStream fileStream = new FileStream(imagepath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            byte[] resim = binaryReader.ReadBytes((int)fileStream.Length);
            binaryReader.Close();
            fileStream.Close();

            this.yemeklerTableAdapter.Fill(this.deneme2DataSet2.Yemekler);
            connection.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Yemekler(YemekAdı,KategoriId,Yemekİçerik,YemekFiyat,YemekPorsiyon,YemekResim) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
          
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", ktgId.Text);
            komut.Parameters.AddWithValue("@p3", txtİçerik.Text);
            komut.Parameters.AddWithValue("@p4", txtFiyat.Text);
            komut.Parameters.AddWithValue("@p5", txtPors.Text);
            komut.Parameters.Add("@p6", SqlDbType.Image, resim.Length).Value = resim;
            // komut.Parameters.AddWithValue("@p6",txtRes.Text);


            komut.ExecuteNonQuery();
            connection.Close();
          
            //komut.Parameters.Clear();
           
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.yemeklerTableAdapter.Fill(this.deneme2DataSet2.Yemekler);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçim = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[seçim].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[seçim].Cells[1].Value.ToString();
            ktgId.Text = dataGridView1.Rows[seçim].Cells[2].Value.ToString();
            txtİçerik.Text = dataGridView1.Rows[seçim].Cells[3].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[seçim].Cells[4].Value.ToString();
            txtPors.Text = dataGridView1.Rows[seçim].Cells[5].Value.ToString();
         



        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sil = new SqlCommand("DELETE FROM Yemekler WHERE YemekId=@p1", connection);
            sil.Parameters.AddWithValue("@p1", txtId.Text);
            sil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt başarıyla silindi.");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand güncelle = new SqlCommand("UPDATE Yemekler SET YemekAdı=@p1, KategoriId=@p2, Yemekİçerik=@p3, YemekFiyat=@p4, YemekPorsiyon=@p5 WHERE YemekId=@p6",connection);
            güncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            güncelle.Parameters.AddWithValue("@p2", ktgId.Text);
            güncelle.Parameters.AddWithValue("@p3", txtİçerik.Text);
            güncelle.Parameters.AddWithValue("@p4", txtFiyat.Text);
            güncelle.Parameters.AddWithValue("@p5", txtPors.Text);
            // güncelle.Parameters.Add("@p6", SqlDbType.Image).Value = FileUpload1.FileBytes;
            //güncelle.Parameters.AddWithValue("@p6", txtRes.Text);

            güncelle.ExecuteNonQuery();

            MessageBox.Show("yemek güncellenmesi tamamlandı.");

            connection.Close();

          

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        string imagepath;
        private void button1_Click(object sender, EventArgs e)
        {
         //   openFileDialog1.ShowDialog();
          //  pictureBox1.ImageLocation = openFileDialog1.FileName;
         //   txtRes.Text= openFileDialog1.FileName; 

            openFileDialog1.Title = "Resim Seç";
             openFileDialog1.Filter = "Jpeg Dosyası (*.jpg)|*.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";
             if (openFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                 imagepath = openFileDialog1.FileName;
                //txtRes.Text = imagepath;
             }
             
            
        }
    

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }
    }
}
