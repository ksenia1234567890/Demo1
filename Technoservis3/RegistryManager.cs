using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technoservis3
{
    public partial class RegistryManager : UserControl
    {
        public RegistryManager(int id_registry, string date_insert, string device, string type_problem, string description, int id_client, string status, int id_staff)
        {
            InitializeComponent();
            label1.Text = id_registry.ToString();
            label2.Text = date_insert;
            label3.Text = device.ToString();
            label4.Text = type_problem;
            richTextBox1.Text = description;
            label5.Text = id_client.ToString();
            label6.Text = status;
            label7.Text = id_staff.ToString();

        }

        private void RegistryManager_Load(object sender, EventArgs e)
        {

        }
    }
}
