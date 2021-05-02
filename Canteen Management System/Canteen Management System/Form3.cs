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
using System.Data;

namespace Canteen_Management_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public void display()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\digan\Documents\Canteen Management System.mdf;Integrated Security=True;Connect Timeout=30");            
            SqlCommand cmd = new SqlCommand("select year(Dater), month(Dater),day(Dater), sum(Total_Price) from mehe group by year(Dater), month(Dater), day(Dater); ", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            
            sqlConnection.Close();
            dataGridView1.DataSource = dt;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
