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
    
    public partial class Form14 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Form14()
        {
            InitializeComponent();
            BindGridView();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "Update  Donation_Event  set status=@status,Volunteer_name=@Volunteer_name,delivered_at=@delivered_at where @donor_name=donor_name and @Quantity = quantity ";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@donor_name", bunifuTextBox3.Text);
            cmd.Parameters.AddWithValue("@Quantity", bunifuTextBox1.Text);
            cmd.Parameters.AddWithValue("@status", comboBox3.SelectedItem);
            cmd.Parameters.AddWithValue("@Volunteer_name", bunifuTextBox2.Text);
            cmd.Parameters.AddWithValue("@delivered_at", comboBox1.SelectedItem);
           

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
            }
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
        void ResetControl()
        {
            bunifuTextBox2.Clear();
           

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bunifuTextBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            bunifuTextBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox3.SelectedItem = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            bunifuTextBox2.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
