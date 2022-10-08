using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    public partial class doctor : Form
    {
        public doctor()
        {
            InitializeComponent();
        }

        private void paicentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void appointmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientupdats p = new patientupdats();
            p.Show();

        }

        private void doctoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentDetails a = new AppointmentDetails();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "select * from doctors where dname='" + comboBox1.Text + "' ";
            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                byte[] photo_array = (byte[])dr[5];
                MemoryStream ma = new MemoryStream(photo_array);
                pictureBox1.Image = Image.FromStream(ma);


            }
                }
            catch(Exception kk)
            { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();
                cmd.Connection = con;

                byte[] imageData;

                imageData = System.IO.File.ReadAllBytes(@openFileDialog1.FileName);
                cmd.Parameters.AddWithValue("@IM", imageData);

                cmd.CommandText = "insert into doctors (dname,degree,specification,ablarea,abltime,photo)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "',@IM)";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("DETAILS ADDED");
                }

                else
                {
                    MessageBox.Show("NO DETAILS ADD PLEAS TRY AGAIN");
                }

                cmd.CommandText = "select * from doctors ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "dname";
                comboBox1.Refresh();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                pictureBox1.ImageLocation = null;
            }
            catch(Exception tt)
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb"; 
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update doctors set drgree ='" + textBox2.Text + "',specification='" + textBox3.Text + "',ablarea='" + textBox4.Text + "',abltime='" + textBox5.Text + "'  where dname='" + textBox1.Text + "' ";

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("DETAILS UPDATED");
                }

                else
                {
                    MessageBox.Show("NO DETAILS UPDATE PLEAS TRY AGAIN WITH PROPER VALUES");
                }
            }
            catch(Exception tt)
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "delete from doctors where dname='" + textBox1.Text + "' ";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("DETAILS DELETED");
                }
                else
                {
                    MessageBox.Show("NO DETAILS DELETED");
                }
            }
            catch(Exception tt)
            {

            }
        }

        private void doctor_Load(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select distinct dname from doctors ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "dname";
                comboBox1.Refresh();

            }
            catch(Exception tt)
            {
                MessageBox.Show(tt.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
            catch(Exception tt)
            { }
        }

        private void patientUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientupdats pu = new patientupdats();
            pu.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = "";
            pictureBox1.Image = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "select * from doctors where dname='" + comboBox1.Text + "' ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                    byte[] photo_array = (byte[])dr[5];
                    MemoryStream ma = new MemoryStream(photo_array);
                    pictureBox1.Image = Image.FromStream(ma);
                }
            }
            catch(Exception tt)
            { }

        }
    }
}