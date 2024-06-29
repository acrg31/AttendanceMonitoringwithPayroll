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
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void iconclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmReportsFaculty lol = new frmReportsFaculty();
            lol.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReportsFaculty calculate = new frmReportsFaculty();
            calculate.ShowDialog();
        }

        private void btnPayslip_pday_Click(object sender, EventArgs e)
        {
            frmPaySlip pay = new frmPaySlip();
            pay.ShowDialog();
        }

        private void btnPayReport_pday_Click(object sender, EventArgs e)
        {
            frmReportsAdmin loll = new frmReportsAdmin();
            loll.ShowDialog();
        }

        private void btnPayslip_phour_Click(object sender, EventArgs e)
        {
            frmPayslipFaculty llll = new frmPayslipFaculty();
            llll.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
