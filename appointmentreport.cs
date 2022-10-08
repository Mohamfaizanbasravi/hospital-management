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
    public partial class appointmentreport : Form
    {
        public appointmentreport()
        {
            InitializeComponent();
        }

        private void appointmentreport_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from appointmentdetails ";
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
                cmd.CommandText = "select * from appointmentdetails where visitdate between #" + dateTimePicker1.Value.ToShortDateString() + "# and #" + dateTimePicker2.Value.ToShortDateString() + "# ";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";

                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from appointmentdetails where pid=" + comboBox1.Text + " or name='" + comboBox2.Text + "' ";



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
            comboBox1.Text = comboBox2.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reportprint1 rp = new reportprint1();
            rp.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            patientdetails pd = new patientdetails(dataGridView1[0, e.RowIndex].Value.ToString(), dataGridView1[1, e.RowIndex].Value.ToString(), dataGridView1[2, e.RowIndex].Value.ToString(), dataGridView1[3, e.RowIndex].Value.ToString(), dataGridView1[4, e.RowIndex].Value.ToString(), dataGridView1[5, e.RowIndex].Value.ToString(), dataGridView1[6, e.RowIndex].Value.ToString());
            pd.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
