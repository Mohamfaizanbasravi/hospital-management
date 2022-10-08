using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication23
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void paicentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientupdats pd = new patientupdats();
            pd.Show();
        }

        private void appointmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void doctoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patientupdats pu = new patientupdats();
            pu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppointmentDetails ap = new AppointmentDetails();
            ap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doctor dr = new doctor();
            dr.Show();
        }

       
        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            patientdetails pd = new patientdetails();
            pd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            patientreport pr = new patientreport();
            pr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            appointmentreport ar = new appointmentreport();
            ar.Show();
        }
    }
}
