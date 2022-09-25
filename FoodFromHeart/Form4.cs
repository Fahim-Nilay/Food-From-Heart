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
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string getName;
        public Form4()
        {
            InitializeComponent();
            getName = Form1.Name;

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Volunteer_Table where Name='" + getName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            sda.Fill(table);

            label6.Text = table.Rows[0][0].ToString();
            bunifuTextBox2.Text = table.Rows[0][2].ToString();
            bunifuTextBox1.Text = table.Rows[0][5].ToString();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            BindGridView1();
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

            string query = "insert into Volunteer_availability values (@name,@contact_number,@free_from,@free_to,@date,@location)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", label6.Text);
            cmd.Parameters.AddWithValue("@contact_number", bunifuTextBox2.Text);
            cmd.Parameters.AddWithValue("@free_from", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@free_to", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@location", bunifuTextBox1.Text);


            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Successfuly Submitted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Account Insertion Failed ");
            }



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

        void BindGridView1()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Task";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;



            //AUTOSIZE
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView2.RowTemplate.Height = 50;
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            panel3.SendToBack();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
            BindGridView2();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "Update  Task  set Current_Status= @Current_Status where Volunteer_name=@Volunteer_name ";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Volunteer_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Current_Status", comboBox3.SelectedItem);
            
            



            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");
                BindGridView2();

            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
            }
        }

        void BindGridView2()
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

        private void dataGridView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            panel4.SendToBack();
        }
    }
}
