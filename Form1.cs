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
    public partial class Form1 : Form
    {
        DataHandler handler = new DataHandler();
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            handler.AddStudent(tbname.Text, tbsurname.Text, tbemail.Text, tbpassword.Text, tbgender.Text, DateTime.Parse(tbDOB.Text));
        }

        private void btnDisplayRegUsers_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
