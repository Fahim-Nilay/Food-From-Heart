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
    public partial class Form12 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string getName;

        public Form12()
        {
            InitializeComponent();

            this.getName = Form1.Name;

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Volunteer_Table where Name='" + getName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            sda.Fill(table);

            label7.Text = table.Rows[0][0].ToString(); 
            label8.Text = table.Rows[0][1].ToString();
            label9.Text = table.Rows[0][2].ToString();
            label10.Text = table.Rows[0][3].ToString();
            label11.Text = table.Rows[0][4].ToString();
            label12.Text = table.Rows[0][5].ToString();
            bunifuPictureBox1.Image = GetPhoto((byte[])table.Rows[0][6]);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
         
            this.Hide();
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Volunteer_Table where Name='" + getName + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a >= 0)
            {
                MessageBox.Show("Profile Deleted Successfully ! ");
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();

            }
            else
            {
                MessageBox.Show("Profile cannot be not Deleted ! ");
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }
    }
}
