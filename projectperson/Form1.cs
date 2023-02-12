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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadperson()
        {
            using (var db = new DBEntities())
            {
                dataGridView1.DataSource = db.selectperson(null);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {


            loadperson();

          
        }
        bool isnew = true;
        private void btninsert_Click(object sender, EventArgs e)
        {
            using (var db = new DBEntities())
            {
                if (txtage.Text == "" || txtcode.Text == "" || txtfirstname.Text == "" || txtlastname.Text == "")
                {
                    MessageBox.Show("فیلد های مورد نظر را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if(isnew)
                    {
                        db.addperosn(txtcode.Text, txtfirstname.Text, txtlastname.Text, int.Parse(txtage.Text));
                        loadperson();
                        txtage.Text = "";
                        txtfirstname.Text = "";
                        txtlastname.Text = "";
                        txtcode.Text = "";
                    }
                   else
                    {
                        db.updateperosn(txtcode.Text, txtfirstname.Text, txtlastname.Text, int.Parse(txtage.Text));
                        loadperson();

                        txtcode.Enabled = true;
                        txtage.Text = "";
                        txtfirstname.Text = "";
                        txtlastname.Text = "";
                        txtcode.Text = "";
                    }
                }
            }
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            using (var db = new DBEntities())
            {
              if(dataGridView1.SelectedRows.Count>0)
                {
                    DialogResult result = MessageBox.Show("کارمند حذف شود ؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        db.deleteperson(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        loadperson();
                    }
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) { 
            
                txtcode.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtfirstname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtlastname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtage.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                isnew = false;
                txtcode.Enabled = false;
            }
            else
            {
                MessageBox.Show("فیلد های مورد نظر را پر کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            using (var db = new DBEntities())
            {
                dataGridView1.DataSource = db.selectperson(txtsearch.Text);
            }
            if(txtsearch.Text=="")
            {
                loadperson();
            }
        }

        private void btnhazf_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }
    }
}

