using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Canteen_Management_System
{
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            string use = txtUser.Text;
            string pas = txtPass.Text;
            if (use == "Diganto" && pas == "123")
            {
                Form2 f = new Form2();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Check your User Name and password again!!!");
                txtUser.Text = "";
                txtPass.Text = "";
            }
         
            //SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\digan\Documents\Canteen Management System.mdf;Integrated Security=True;Connect Timeout=30");
            //string query = "Select * from user where name = '" + txtUser.Text.Trim() + "' and password='" + txtPass.Text.Trim() + "' ";
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //if (dt.Rows.Count == 1)
            //{
            //    Form2 f = new Form2();
            //    f.Show();
            //    this.Hide();
            //    MessageBox.Show("Success.");
            //}
            //else
            //{
            //    MessageBox.Show("Check your username and password");
            //}

             
        }
    }
}
