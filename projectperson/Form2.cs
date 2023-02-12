using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectperson
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadperson1()
        {
            using (var db = new DBEntities())
            {
                dataGridView1.DataSource = db.selectdeletetb(null);
            }

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            loadperson1();
        }
    }
}
