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
    public partial class Query : UserControl
    {
        public Query(int id_client, string surname, string name, string patronymic, string phone, string email, string description)
        {
            InitializeComponent();
            label1.Text = id_client.ToString();
            label2.Text = surname+" "+name+" "+patronymic;
            label4.Text = phone;
            label5.Text = email;
            richTextBox1.Text = description;

        }
    }
}
