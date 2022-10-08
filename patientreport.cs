using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    public partial class patientreport : Form
    {
        public patientreport()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void patientreport_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from Query1 ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "pid";
                comboBox1.Refresh();

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "name";
                comboBox2.Refresh();

                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "contect";
                comboBox3.Refresh();

                cmd.CommandText = "select * from Query1 ";
                OleDbDataReader drr;
                drr = cmd.ExecuteReader();
                DataTable dtt = new DataTable();
                dtt.Load(drr);

                comboBox4.DataSource = dtt;
                comboBox4.DisplayMember = "doctor";
                comboBox4.Refresh();
            }
            catch(Exception tt)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from Query1 where visitdate between #" + dateTimePicker1.Value.ToShortDateString() + "# and #" + dateTimePicker2.Value.ToShortDateString() + "# ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch (Exception tt)
            { }
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
                if (comboBox1.Text == "")
                    comboBox1.Text = "0";
                cmd.CommandText = "select * from Query1 where pid=" + comboBox1.Text + " or name='" + comboBox2.Text + "'";
                //cmd.CommandText = "select * from Query1 where name='" + comboBox2.Text + "'";
                //cmd.CommandText = "select * from Query1 where contect=" + comboBox3.Text + "";

                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch(Exception tt)
            { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = comboBox2.Text = comboBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppointmentDetails ad = new AppointmentDetails(dataGridView1[0, e.RowIndex].Value.ToString(), dataGridView1[1, e.RowIndex].Value.ToString(), dataGridView1[4, e.RowIndex].Value.ToString(), dataGridView1[5, e.RowIndex].Value.ToString(), dataGridView1[6, e.RowIndex].Value.ToString());
            ad.Show();
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
                //cmd.CommandText = "select * from patientdetails where visitdate = #" + DateTime.Now.ToShortDateString() + "#";
                if (checkBox1.Checked)
                {
                    cmd.CommandText = "select * from Query1 where doctor='" + comboBox4.Text + "' and visitdate= #" + DateTime.Now.ToShortDateString() + "# ";
                    //str = str + " visitdate = #" + DateTime.Now.ToShortDateString() + "# ";

                }
               
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch(Exception tt)
            {

            }
        }
        
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();

                cmd.CommandText = "select * from Query1 where doctor='" + comboBox4.Text + "' and visitdate= #" + DateTime.Now.ToShortDateString() + "# ";
                    

               
                cmd.Connection = con;
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
            }
            catch(Exception tt)
            { }
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reportprint rp = new reportprint();
            rp.Show();
        }
    }
}
