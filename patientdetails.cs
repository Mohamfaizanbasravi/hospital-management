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
    public partial class patientdetails : Form
    {
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        int k;
        private string p5;
        private string p6;
        private string p7;
        public patientdetails()
        {
            InitializeComponent();
            k = 0;
        }

       
 
        public patientdetails(string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        {
            try
            {
                InitializeComponent();
                // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.p5 = p5;
            this.p6 = p6;
            this.p7 = p7;

            comboBox2.Text = Convert.ToString(p1);
            textBox2.Text = p2;
            textBox3.Text = p3;
            textBox4.Text = p4;
            textBox5.Text = p5;
            comboBox3.Text = p6;
            dateTimePicker1.Value = Convert.ToDateTime(p7);
            k = 1;
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
                cmd.CommandText = "insert into patientdetails (name,contect,address,problem,doctor,visitdate)values('" + textBox2.Text + "'," + textBox3.Text + ",'" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox3.Text + "',#" + dateTimePicker1.Value.ToShortDateString() + "#)";
                if(cmd.ExecuteNonQuery()>0)
                {
                    MessageBox.Show("RECORD ADDED");
                    patientdetails_Load(sender, e);
                    comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox3.Text = "";

                }
                else
                {
                    MessageBox.Show("ENTER PROPER VALUES");
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
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\supremhospital.accdb"; con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update patientdetails contect =" + textBox3.Text + ",address='" + textBox4.Text + "',problem='" + textBox5.Text + "',doctor='" + comboBox3.Text + "',visitdate=#" + dateTimePicker1.Value.ToShortDateString() + "# where set name='" + textBox2.Text + "'";

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD UPDATED");
                    comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox3.Text = "";
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

                cmd.CommandText = "select * from Query1 where name='" + comboBox1.Text + "'";
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
                cmd.CommandText = "delete from patientdetails where set name='" + textBox2.Text + "'";
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("RECORD DELETED");
                    comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("NO RECORD DELETED");
                }
            }
            catch(Exception tt)
            {

            }
        }

        private void patientdetails_Load(object sender, EventArgs e)
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
                    cmd.CommandText = "select * from Query1 ";
                    OleDbDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "name";
                    comboBox1.Refresh();

                    cmd.Connection = con;
                    cmd.CommandText = "select * from doctors ";
                    OleDbDataReader drr;
                    drr = cmd.ExecuteReader();
                    DataTable dtt = new DataTable();
                    dtt.Load(drr);

                    comboBox3.DataSource = dtt;
                    comboBox3.DisplayMember = "dname";
                    comboBox3.Refresh();

                    comboBox2.Text = textBox2.Text = "";


                }
            }
            catch(Exception tt)
            { }
           
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text=comboBox2.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = comboBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            patientreport pr = new patientreport();
            pr.Show();
        }

        private void paicentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
        }

        private void appointmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppointmentDetails ad = new AppointmentDetails();
            ad.Show();
        }

        private void doctoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doctor dr = new doctor();
            dr.Show();
        }

        private void patientDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientupdats pd = new  patientupdats();
            pd.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*try{
            OleDbConnection con = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\faizan\\Documents\\supremhospital.accdb";

            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "select * from patientdetails where pid=" + comboBox2.Text + " ";
           
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


            }
            else
            {
                MessageBox.Show("NO DATA FOUND ....");
            }
 
            }
            catch(Exception tt)
            { 
                 
            }
              */  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                    OleDbConnection con = new OleDbConnection();
                    OleDbCommand cmd = new OleDbCommand();
                    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\faizan\\Documents\\supremhospital.accdb";

                    con.Open();

                    cmd.Connection = con;
                    cmd.CommandText = "select * from Query1 where name='" + comboBox1.Text + "' ";
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

                    //    dateTimePicker1.Value = Convert.ToDateTime(dr[6].ToString());
                    }


                
                }
                
            catch (Exception tt)
            { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\faizan\\Documents\\supremhospital.accdb";

                con.Open();

                cmd.Connection = con;
                cmd.CommandText = "select * from Query1 where doctor=" + comboBox3.Text + " ";
                cmd.ExecuteNonQuery();

                

            }
            catch (Exception tt)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
