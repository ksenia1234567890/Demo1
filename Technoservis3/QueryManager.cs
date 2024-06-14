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
    public partial class QueryManager : Form
    {
        int id_staff;
        string path = "Host=localhost; Username=postgres; Password = cxNTVJas; Database=Technoservis3";
        
        public QueryManager(int id_staff)
        {
            InitializeComponent();
            this.id_staff = id_staff;
        }

        private void QueryManager_Load(object sender, EventArgs e)
        {
            NpgsqlConnection con = new NpgsqlConnection(path);
            string sql = "select * from client";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    Query query = new Query(
                        Convert.ToInt32(reader.GetValue(0)),
                        reader.GetValue(1).ToString(),
                        reader.GetValue(2).ToString(),
                        reader.GetValue(3).ToString(),
                        reader.GetValue(4).ToString(),
                        reader.GetValue(5).ToString(),
                        reader.GetValue(6).ToString());
                    flowLayoutPanel1.Controls.Add(query);
                }
            }

            NpgsqlConnection con2 = new NpgsqlConnection(path);
            string sql2 = "select * from query_registry";
            NpgsqlCommand cmd2 = new NpgsqlCommand(sql2, con2);
            NpgsqlDataReader reader2 = cmd.ExecuteReader();
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    RegistryManager query = new RegistryManager(
                        Convert.ToInt32(reader2.GetValue(0)),
                        reader2.GetValue(1).ToString(),
                        reader2.GetValue(2).ToString(),
                        reader2.GetValue(3).ToString(),
                        reader2.GetValue(4).ToString(),
                         Convert.ToInt32(reader2.GetValue(5)),
                         reader2.GetValue(6).ToString(),
                         Convert.ToInt32(reader2.GetValue(7))
                        ) ;
                    flowLayoutPanel2.Controls.Add(query);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(path);
            string sql = "insert into query_registry (id_registry, date_insert, device, type_problem, description, id_client, status, id_staff)" +
                "values (@id_registry, @date_insert, @device, @type_problem, @description, @id_client, @status, @id_staff)";
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddW
        }
    }
}
