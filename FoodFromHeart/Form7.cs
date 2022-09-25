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
    public partial class Form7 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string getName;
        public Form7()
        {
            InitializeComponent();
            getName = Form1.Name;

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Donor_Table where Name='" + getName + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            sda.Fill(table);

            bunifuTextBox1.Text = table.Rows[0][0].ToString();
            bunifuTextBox2.Text = table.Rows[0][1].ToString();
            bunifuTextBox3.Text = table.Rows[0][2].ToString();
            bunifuTextBox4.Text = table.Rows[0][3].ToString();
            bunifuTextBox5.Text = table.Rows[0][4].ToString();
            bunifuTextBox6.Text = table.Rows[0][5].ToString();
            bunifuPictureBox1.Image = GetPhoto((byte[])table.Rows[0][6]);
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";

            ofd.Filter = "Image File (All files) *.* | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bunifuPictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "update Donor_Table  set name=@name,email=@email,contact_number=@contact_number,password=@password,address=@address,picture=@picture where Name='" + getName + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", bunifuTextBox1.Text);
            cmd.Parameters.AddWithValue("@email", bunifuTextBox2.Text);
            cmd.Parameters.AddWithValue("@contact_number", bunifuTextBox3.Text);
            cmd.Parameters.AddWithValue("@nid", bunifuTextBox4.Text);
            cmd.Parameters.AddWithValue("@password", bunifuTextBox5.Text);
            cmd.Parameters.AddWithValue("@address", bunifuTextBox6.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");
               
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            bunifuPictureBox1.Image.Save(ms, bunifuPictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        
    }
}
