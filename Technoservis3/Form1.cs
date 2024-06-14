using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using QRCoder;

namespace Technoservis3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string path = "Host=localhost; Username=postgres; Password=cxNTVJas; Database=Technoservis3";


        public int IdClientIdentification()
        {
            NpgsqlConnection con = new NpgsqlConnection(path);
            string line = "select id_client from client order by id_client desc limit 1";
            NpgsqlCommand command = new NpgsqlCommand(line, con);
            con.Open();
            int count = Convert.ToInt32(command.ExecuteScalar());
            con.Close();
            return count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlConnection query_client = new NpgsqlConnection(path);
                string sql = "insert into client(id_client, surname, name, patronymic, phone, email, description)" +
                    "values (@id_client, @surname, @name, @patronymic, @phone, @email, @description)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, query_client);
                cmd.Parameters.AddWithValue("@id_client", IdClientIdentification() + 1);
                cmd.Parameters.AddWithValue("@surname", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@patronymic", textBox3.Text);
                cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@description", textBox6.Text);
                query_client.Open();
                cmd.ExecuteNonQuery();
                query_client.Close();

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode("текст", QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);
                ImagePictureBox.Image = new Bitmap(qrCodeImage, ImagePictureBox.Width, ImagePictureBox.Height);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Entrance entrance = new Entrance();
            this.Hide();
            entrance.Show();
        }
    }
}
