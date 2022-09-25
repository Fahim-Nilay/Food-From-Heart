using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
namespace FoodFromHeart
{
    public partial class Form10 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form10()
        {
            
            InitializeComponent();
            BindGridView();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
           
            ofd.Filter = "Image File (All files) *.* | *.*";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bunifuPictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
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
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully ! ");
                BindGridView();
                ResetControl();
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
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Donor_Table";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            ///Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
        void ResetControl()
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear(); 
            bunifuTextBox3.Clear();
            bunifuTextBox4.Clear();
            bunifuTextBox5.Clear();
            bunifuTextBox6.Clear();
            bunifuPictureBox1.Image = Properties.Resources.icons8_user_80px_21;

        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bunifuTextBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            bunifuTextBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuTextBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuTextBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuTextBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuTextBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuPictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
        }
      
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "update Donor_Table  set name=@name,email=@email,contact_number=@contact_number,password=@password,address=@address,picture=@picture where nid=@nid";

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
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from Donor_Table where nid=@nid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nid", bunifuTextBox4.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a >= 0)
            {
                MessageBox.Show("Data Deleted Successfully ! ");
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Data not Deleted ! ");
            }
        }

      
    }
}
