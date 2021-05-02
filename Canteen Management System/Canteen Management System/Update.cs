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
    public partial class Update : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\digan\Documents\Canteen Management System.mdf;Integrated Security=True;Connect Timeout=30");
        public Update()
        {
            InitializeComponent();
        }

        public void display()
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvInfo.DataSource = dt;

            
            sqlConnection.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Product values('" + txtName.Text + "','" + txtPrice.Text + "','" + txtQuantity.Text + "')";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            display();

            MessageBox.Show("Inserted successfully.");

            txtName.Text = txtPrice.Text = txtQuantity.Text = "";
        }

        private void Update_Load(object sender, EventArgs e)
        {
            display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Product where Name= '" + txtName.Text + "'";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            display();

            MessageBox.Show("Deleted successfully.");
            txtName.Text = txtPrice.Text = txtQuantity.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Product set  Price='" + txtPrice.Text + "',Quantity='" + txtQuantity.Text + "'  where Name= '" + txtName.Text + "'";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            display();

            MessageBox.Show("Updated successfully.");
            txtName.Text = txtPrice.Text = txtQuantity.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
