using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication23
{
    public partial class patientupdats : Form
    {
        public patientupdats()
        {
            InitializeComponent();
        }

        private void paicentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.Text=textBox2.Text=textBox3.Text=textBox4.Text=textBox5.Text=comboBox3.Text=textBox7.Text=textBox8.Text=textBox9.Text="";

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
                cmd.CommandText = "insert into patientdetails (pid,name,contect,address,problem,doctor,visitdate,prevappdate,nextappdate,fee,total,balance)values(" + comboBox2.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "',#" + dateTimePicker1.Value.ToShortDateString() + "#,#" + dateTimePicker2.Value.ToShortDateString() + "#,#" + dateTimePicker3.Value.ToShortDateString() + "#," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + ")";
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
            {  }
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
                cmd.CommandText = "update patientdetails set name='" + textBox2.Text + "',contect =" + textBox3.Text + ",address='" + textBox4.Text + "',problem='" + textBox5.Text + "',doctor='" + comboBox3.Text + "',visitdate=#" + dateTimePicker1.Value.ToShortDateString() + "#,prevappdate=#" + dateTimePicker2.Value.ToShortDateString() + "#,nextappdate=#" + dateTimePicker3.Value.ToShortDateString() + "#,fee=" + textBox7.Text + ",total=" + textBox8.Text + ",balance=" + textBox9.Text + " where pid=" + comboBox2.Text + "";

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD UPDATED");
                }

                else
                {
                    MessageBox.Show("NO RECORD UPDATE PLEAS TRY AGAIN WITH PROPER VALUES");
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
            
            cmd.CommandText = "select * from patientdetails where name='" + comboBox1.Text + "'";
            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               comboBox2.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                comboBox3.Text = dr[5].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dr[6].ToString());
                dateTimePicker2.Value = Convert.ToDateTime(dr[7].ToString());
                dateTimePicker3.Value = Convert.ToDateTime(dr[8].ToString());
                textBox7.Text = dr[9].ToString();
                textBox8.Text = dr[10].ToString();
                textBox9.Text = dr[11].ToString();
                
            }
            else
            {
               // MessageBox.Show("NO DATA FOUND ....");
            }
                }
            catch(Exception kk)
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
                cmd.CommandText = "delete from patientdetails where pid=" + comboBox2.Text + "";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD DELETED");
                }
                else
                {
                    MessageBox.Show("NO RECORD DELETED");
                }
            }
            catch (Exception tt)
            { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void doctoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doctor dr = new doctor();
            dr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            patientreport pr = new patientreport();
            pr.Show();
        }

        private void patientdetails_Load(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();
                cmd.Connection = con;
                
                cmd.CommandText = "select * from doctors ";
                OleDbDataReader drr;
                drr = cmd.ExecuteReader();
                DataTable dtt = new DataTable();
                dtt.Load(drr);

                comboBox3.DataSource = dtt;
                comboBox3.DisplayMember = "dname";
                comboBox3.Refresh();

                cmd.CommandText = "select * from patientdetails ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "name";
                comboBox1.Refresh();

            }
            catch (Exception tt)
            { }

        }

        private void patientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientdetails pd = new patientdetails();
            pd.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb";
                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "select * from patientdetails where name='" + comboBox1.Text + "' ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comboBox2.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                    comboBox3.Text = dr[5].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr[6].ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(dr[7].ToString());
                    dateTimePicker3.Value = Convert.ToDateTime(dr[8].ToString());
                    textBox7.Text = dr[9].ToString();
                    textBox8.Text = dr[10].ToString();
                    textBox9.Text = dr[11].ToString();

                }
                else
                {
                    //MessageBox.Show("NO DATA FOUND ....");
                }
            }
            catch(Exception kk)
            {}
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

                cmd.CommandText = "select * from patientdetails name='"+comboBox1.Text+"' ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comboBox2.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                    comboBox3.Text = dr[5].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr[6].ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(dr[7].ToString());
                    dateTimePicker3.Value = Convert.ToDateTime(dr[8].ToString());
                    textBox7.Text = dr[9].ToString();
                    textBox8.Text = dr[10].ToString();
                    textBox9.Text = dr[11].ToString();

                }
                else
                {
                    //MessageBox.Show("NO DATA FOUND ....");
                }
            }
            catch (Exception kk)
            { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:|DataDirectory|\\supremhospital.accdb";


                con.Open();

                cmd.Connection = con;

                cmd.CommandText = "select * from patientdetails where name=;" + comboBox3.Text + "' ";
                OleDbDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    comboBox2.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                    textBox5.Text = dr[4].ToString();
                    comboBox3.Text = dr[5].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr[6].ToString());
                    dateTimePicker2.Value = Convert.ToDateTime(dr[7].ToString());
                    dateTimePicker3.Value = Convert.ToDateTime(dr[8].ToString());
                    textBox7.Text = dr[9].ToString();
                    textBox8.Text = dr[10].ToString();
                    textBox9.Text = dr[11].ToString();

                }
                else
                {
                    //MessageBox.Show("NO DATA FOUND ....");
                }
            }
            catch (Exception kk)
            { }
        }

        private void appointmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentDetails ap = new AppointmentDetails();
            ap.Show();
        }

       
    }
}
