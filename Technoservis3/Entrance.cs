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

namespace Technoservis3
{
    public partial class Entrance : Form
    {
        public Entrance()
        {
            InitializeComponent();
        }

        public string path = "Host=localhost; Username=postgres; Password=cxNTVJas; Database=Technoservis3";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string post = "";
                int id_staff = 0;
                NpgsqlConnection con = new NpgsqlConnection(path);
                string sql = $"select id_staff, post from staff where login={textBox1.Text} and password={textBox2.Text}";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                con.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        post = reader.GetValue(1).ToString();
                        id_staff = Convert.ToInt32(reader.GetValue(0));

                    }
                }
                if (post == "Менеджер")
                {
                    QueryManager form = new QueryManager(id_staff);
                    this.Close();
                    form.Show();
                }
                if (post == "Исполнитель")
                {
                    QueryMaster form = new QueryMaster(id_staff);
                    this.Close();
                    form.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
