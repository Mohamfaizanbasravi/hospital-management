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
    public partial class AppointmentDetails : Form
    {
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;
        int k;

        public AppointmentDetails()
        {
            InitializeComponent();
            k = 0;
        }

        public AppointmentDetails(string p1, string p2, string p3, string p4,string p5)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            textBox1.Text = p1;
            textBox2.Text = p2;
            textBox3.Text = p3;
            textBox4.Text = p4;
            dateTimePicker1.Value=Convert.ToDateTime( p5);
            k = 1;

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
                cmd.CommandText = "insert into appointmentdetails (pid,name,problem,doctor,visitdate,prevappdate,nextappdate)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "',#" + dateTimePicker1.Value.ToShortDateString() + "#,#" + dateTimePicker2.Value.ToShortDateString() + "#,#" + dateTimePicker3.Value.ToShortDateString() + "#)";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD ADDED");
                }

                else
                {
                    MessageBox.Show("NO RECORD ADD PLEAS TRY AGAIN");
                }
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
                cmd.CommandText = "update appointmentdetails set name='" + textBox2.Text + "',problem ='" + textBox3.Text + "',doctor='" + textBox4.Text + "',visitdate=#" + dateTimePicker1.Value.ToShortDateString() + "#,prevappdate=#" + dateTimePicker2.Value.ToShortDateString() + "#,nextappdate=#" + dateTimePicker3.Value.ToShortDateString() + "# where pid=" + textBox1.Text + "";

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD UPDATED");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }

                else
                {
                    cmd.CommandText = "insert into  appointmentdetails (pid,name,problem,doctor,visitdate,prevappdate,nextappdate)values(" + textBox1.Text + ",'" + textBox2.Text + "', '" + textBox3.Text + "','" + textBox4.Text + "',#" + dateTimePicker1.Value.ToShortDateString() + "#,#" + dateTimePicker2.Value.ToShortDateString() + "#,#" + dateTimePicker3.Value.ToShortDateString() + "#) ";
                    cmd.ExecuteNonQuery();
                }
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
                cmd.CommandText = "select * from view1 where name='" + comboBox1.Text + "' ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();

                    dateTimePicker1.Value = Convert.ToDateTime(dr[4].ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(dr[5].ToString());
                    dateTimePicker3.Value = Convert.ToDateTime(dr[6].ToString());
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
                cmd.CommandText = "delete from appointmentdetails where pid=" + textBox1.Text + "";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD DELETED");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("NO RECORD DELETED");
                }
            }
            catch(Exception tt)
            { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void appointmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientdetails pd = new patientdetails();
            pd.Show();

        }

        private void paicentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void doctoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doctor dr = new doctor();
            dr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            appointmentreport ar = new appointmentreport();
            ar.Show();
        }

        private void AppointmentDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (k == 0)
                {
                    OleDbConnection con = new OleDbConnection();
                    OleDbCommand cmd = new OleDbCommand();
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";

                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from view1";
                    OleDbDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "name";
                    comboBox1.Refresh();
                }
            }
            catch(Exception tt)
            { }
        }

        private void patientUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientupdats pu = new patientupdats();
            pu.Show();
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
                cmd.CommandText = "select * from view1 where name='" + comboBox1.Text + "' ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();

                    dateTimePicker1.Value = Convert.ToDateTime(dr[4].ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(dr[5].ToString());
                    dateTimePicker3.Value = Convert.ToDateTime(dr[6].ToString());
                }
            }
            catch(Exception tt)
            { }
        }
    }
}
