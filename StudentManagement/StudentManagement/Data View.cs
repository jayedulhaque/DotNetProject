using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class Data_View : Form
    {
        public void showtab(object data)
        {
            dgv1.DataSource = data;
        }
        public Data_View()
        {
            InitializeComponent();
        }

        private void Data_View_Load(object sender, EventArgs e)
        {

        }
    }
}
