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
    public partial class reportprint1 : Form
    {
        public reportprint1()
        {
            InitializeComponent();
        }

        private void reportprint1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'supremhospitalDataSet2.appointmentdetails' table. You can move, or remove it, as needed.
            this.appointmentdetailsTableAdapter.Fill(this.supremhospitalDataSet2.appointmentdetails);
            DateTime kk = DateTime.Now.AddDays(1);


            this.reportViewer1.RefreshReport();
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
