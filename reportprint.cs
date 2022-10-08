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
    public partial class reportprint : Form
    {
        public reportprint()
        {
            InitializeComponent();
        }

        private void reportprint_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'supremhospitalDataSet1.patientdetails' table. You can move, or remove it, as needed.
            this.patientdetailsTableAdapter.FillBy(this.supremhospitalDataSet1.patientdetails, DateTime.Now.Date);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
