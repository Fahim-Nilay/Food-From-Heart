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
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }

        private void bunifuTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBox1.Text) == true)
            {
                bunifuTextBox1.Focus();
                errorProvider1.SetError(this.bunifuTextBox1, "Please fill the option first!");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void bunifuTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBox2.Text) == true)
            {
                bunifuTextBox2.Focus();
                errorProvider2.SetError(this.bunifuTextBox2, "Please fill the  option first!");

            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void bunifuTextBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBox3.Text) == true)
            {
                bunifuTextBox3.Focus();
                errorProvider3.SetError(this.bunifuTextBox3, "Please fill the  option first!");

            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBox4.Text) == true)
            {
                bunifuTextBox4.Focus();
                errorProvider4.SetError(this.bunifuTextBox4, "Please fill the  option first!");

            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void bunifuTextBox5_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(bunifuTextBox5.Text) == true)
            {
                bunifuTextBox5.Focus();
                errorProvider5.SetError(this.bunifuTextBox5, "Please fill the  option first!");

            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void bunifuTextBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBox6.Text) == true)
            {
                bunifuTextBox6.Focus();
                errorProvider6.SetError(this.bunifuTextBox6, "Please fill the  option first!");

            }
            else
            {
                errorProvider6.Clear();
            }
        }

        

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image File (*.*) | *.*";
            
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                bunifuPictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            bunifuPictureBox1.Image.Save(ms, bunifuPictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                SqlConnection con = new SqlConnection(cs);

                string query = "insert into Donor_Table values (@name,@email,@contact_number,@nid,@password,@address,@picture)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", bunifuTextBox1.Text);
                cmd.Parameters.AddWithValue("@email", bunifuTextBox2.Text);
                cmd.Parameters.AddWithValue("@contact_number", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@nid", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@password", bunifuTextBox5.Text);
                cmd.Parameters.AddWithValue("@address", bunifuTextBox6.Text);
                cmd.Parameters.AddWithValue("@picture", SavePhoto());

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Account Creation Successfull ");
                }
                else
                {
                    MessageBox.Show("Account Creation Failed ");
                }
               

            }
           
            else if (radioButton2.Checked == true)
            {
                SqlConnection con = new SqlConnection(cs);

                string query = "insert into Volunteer_Table values (@name,@email,@contact_number,@nid,@password,@address,@picture)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", bunifuTextBox1.Text);
                cmd.Parameters.AddWithValue("@email", bunifuTextBox2.Text);
                cmd.Parameters.AddWithValue("@contact_number", bunifuTextBox3.Text);
                cmd.Parameters.AddWithValue("@nid", bunifuTextBox4.Text);
                cmd.Parameters.AddWithValue("@password", bunifuTextBox5.Text);
                cmd.Parameters.AddWithValue("@address", bunifuTextBox6.Text);
                cmd.Parameters.AddWithValue("@picture", SavePhoto());

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Account Creation Successfull ");
                }
                else
                {
                    MessageBox.Show("Account Creation Failed ");
                }
                
            }
            else { MessageBox.Show("Account Creation Failed"); }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
