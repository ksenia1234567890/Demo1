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
    public partial class QueryMaster : Form
    {
        public int id_staff;

        public QueryMaster(int id_staff)
        {
            InitializeComponent();
            this.id_staff = id_staff;
        }
    }
}
