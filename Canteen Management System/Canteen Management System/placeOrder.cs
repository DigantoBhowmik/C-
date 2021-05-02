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
    public partial class placeOrder : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\digan\Documents\Canteen Management System.mdf;Integrated Security=True;Connect Timeout=30");
       
        
        public placeOrder()
        {
            InitializeComponent();
        }

        private void placeOrder_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

        }
           

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where Name like ('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["Name"].ToString());
            }

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode==Keys.Enter)
                {
                    textBox1.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    txtPrice.Focus();
                }
            }
            catch(Exception )
            {

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

       
        private void txtPrice_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where Name = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                txtPrice.Text=dr["Price"].ToString();
            }
        }

        private void txtQantity_Leave(object sender, EventArgs e)
        {
            try
            {
                txtTprice.Text = Convert.ToString(Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQantity.Text));
            }
            catch {  }
        }

       

        private void txtTprice_TextChanged(object sender, EventArgs e)
        {
             try
            {
                txtTprice.Text = Convert.ToString(Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQantity.Text));
            }
            catch {  }
        
        }

        protected int n, total= 0;
        private void btnOrder_Click(object sender, EventArgs e)
        {


            

            int stock=0;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from Product where Name = '" + textBox1.Text + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
            da1.Fill(dt1);

            foreach (DataRow dr1 in dt1.Rows)
            {
                stock=Convert.ToInt32(dr1["Quantity"].ToString());
            }
            if(Convert.ToInt32(txtQantity.Text)>stock)
            {
                MessageBox.Show("This Much Value is not available");
            }
            else
            {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into [Order Details] values('" + textBox1.Text + "','" + txtPrice.Text + "','" + txtQantity.Text + "','" + txtTprice.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "')";
                cmd1.ExecuteNonQuery();

                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtQantity.Text;
                dataGridView1.Rows[n].Cells[3].Value = txtTprice.Text;

                total += int.Parse(txtTprice.Text);
                label7.Text = Convert.ToString(total);

                int qty = Convert.ToInt32(txtQantity.Text);
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "update Product set Quantity=Quantity-" + qty + " where Name='" + textBox1.Text + "'";
                cmd0.ExecuteNonQuery();

            }
      
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Confirmed Order");
            textBox1.Text = "";
            txtPrice.Text= "";
            txtQantity.Text = "";
            txtTprice.Text = "";
            label7.Text = "00";
            dataGridView1.Rows.Clear();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            label7.Text = Convert.ToString(total);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        

       

        
    }
}
