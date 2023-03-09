using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationSignUp
{
    public partial class Form2 : Form
    {
        DataHandler handler = new DataHandler();
        BindingSource source = new BindingSource();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            source.DataSource = handler.Display();
            dataGridView1.DataSource = source;
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = handler.SearchStudent(tbsearchemail.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            source.MoveFirst();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            source.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            source.MoveLast();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(tbsearchemail.Text == null)
            {
                MessageBox.Show("Please enter an email in the text box that you wish to delete");
            }
            else
            {
                handler.DeleteStudent(tbsearchemail.Text);
            }
        }
    }
}
