using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSv3._0
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void iconclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEmployeeRegistration register = new frmEmployeeRegistration();
            register.ShowDialog();
        }

        private void btnGiveSched_Click(object sender, EventArgs e)
        {
            frmSummaryOfLoads loads = new frmSummaryOfLoads();
            loads.ShowDialog();
        }
        
      

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmAttendanceData Attendance = new frmAttendanceData();
            Attendance.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmAttendanceData data = new frmAttendanceData();
            data.ShowDialog();
        }
    }
}
