using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace FoodFromHeart
{
    public partial class Form5 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form5()
        {
            InitializeComponent();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Volunteer_Availability";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            panel2.SendToBack();
          
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "insert into task values (@volunteer_name,@delivery_location,@pickup_timefrom,@pickup_timeto,@donor_name,null)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@volunteer_name", bunifuTextBox3.Text);
            cmd.Parameters.AddWithValue("@delivery_location", bunifuTextBox2.Text);
            cmd.Parameters.AddWithValue("@pickup_timefrom", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@pickup_timeto", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@donor_name", bunifuTextBox1.Text);
            


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Task Successfuly Submitted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Task Submission Failed ");
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
            BindGridView1();
        }
        void BindGridView1()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Task";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView3.DataSource = data;



            //AUTOSIZE
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView3.RowTemplate.Height = 50;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            panel4.SendToBack();
        }
    }
    
}
