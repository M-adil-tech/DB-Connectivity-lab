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
 
namespace DB_Connectivity_lab
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int id;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            id = 0;
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox5.Clear();
            textBox10.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //getstudentdata();
        }

        private void getstudentdata()
        {
            //throw new NotImplementedException();
            SqlConnection cn;
            cn = new SqlConnection(@"Data Source=DESKTOP-7RAJJIU\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True");
            SqlCommand cmd =new SqlCommand("select * from dbo.student",cn);
            DataTable dt = new DataTable();
            cn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            cn.Close();
            dataGridView1.DataSource = dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            cn = new SqlConnection(@"Data Source=DESKTOP-7RAJJIU\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True");
cn.Open();
            if (cn.State == ConnectionState.Open)
            { MessageBox.Show("Connected to the SQl Server Database"); }
            else
                MessageBox.Show("Failed");
        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            getstudentdata();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection cn;
            cn = new SqlConnection(@"Data Source=DESKTOP-7RAJJIU\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT VALUES(@id2,@name1,@fname,@semester,@age)", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id2",textBox7.Text);
            cmd.Parameters.AddWithValue("@name1", textBox8.Text);
            cmd.Parameters.AddWithValue("@fname", textBox9.Text);
            cmd.Parameters.AddWithValue("@semester", textBox5.Text);
            cmd.Parameters.AddWithValue("@age", textBox10.Text);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Added sucessfully");

        }

        

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlConnection cn;
                cn = new SqlConnection(@"Data Source=DESKTOP-7RAJJIU\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE  STUDENT SET S_id=@id2, S_name=@name1, S_fathername=@fname, S_semster=@semester, S_age=@age WHERE S_id=@id1", cn);
                cmd.CommandType = CommandType.Text; 
                cmd.Parameters.AddWithValue("@id2", textBox7.Text);
                cmd.Parameters.AddWithValue("@name1", textBox8.Text);
                cmd.Parameters.AddWithValue("@fname", textBox9.Text);
                cmd.Parameters.AddWithValue("@semester", textBox5.Text);
                cmd.Parameters.AddWithValue("@age", textBox10.Text);
                cmd.Parameters.AddWithValue("@id1", this.id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Updated Sucessfuly");
            }
            else
                MessageBox.Show("Please select a valid Record");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlConnection cn;
                cn = new SqlConnection(@"Data Source=DESKTOP-7RAJJIU\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DELETE  FROM student  WHERE S_id=@id1", cn);
                cmd.CommandType = CommandType.Text;
             
                cmd.Parameters.AddWithValue("@id1", this.id);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Deleted Sucessfuly");
            }
            else
                MessageBox.Show("Please select a valid Record");
        }
    }
}
 