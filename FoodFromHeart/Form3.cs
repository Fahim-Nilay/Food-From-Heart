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
    public partial class Form3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string getName;
        public Form3()
        {
            InitializeComponent();
            
            getName = Form1.Name;

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Donor_Table where Name='" + getName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            sda.Fill(table);

            label6.Text = table.Rows[0][0].ToString();
            bunifuTextBox3.Text = table.Rows[0][2].ToString();
            bunifuTextBox1.Text = table.Rows[0][5].ToString();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "insert into Donation_Event values (@donor_name,@contact_number,@pickup_schedule,@to_time,@date,@quantity,@address,null,null,null)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@donor_name", label6.Text);
            cmd.Parameters.AddWithValue("@contact_number", bunifuTextBox3.Text);
            cmd.Parameters.AddWithValue("@pickup_schedule", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@to_time", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@date", dateTimePicker.Value);
            cmd.Parameters.AddWithValue("@quantity", bunifuTextBox2.Text);
            cmd.Parameters.AddWithValue("@address", bunifuTextBox1.Text);
        

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfull ");
                 ResetControl();

            }
            else
            {
                MessageBox.Show("Account Insertion Failed ");
            }
        }
        void ResetControl()
        {

            
           
            bunifuTextBox2.Clear();
        

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Donation_Event";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;



            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            panel2.SendToBack();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
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
