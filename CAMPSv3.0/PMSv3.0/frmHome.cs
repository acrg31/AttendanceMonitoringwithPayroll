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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeRecords rec = new frmEmployeeRecords();
            rec.ShowDialog();
        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttendanceRecord attendance = new frmAttendanceRecord();
            attendance.ShowDialog();
        }

        private void employeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaymentRecord pay = new frmPaymentRecord();
            pay.ShowDialog();
        }

        private void deductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            frmChangepass pass = new frmChangepass();
            pass.ShowDialog();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }

        private void sAMPLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeRegistration emp = new frmEmployeeRegistration();
            emp.ShowDialog();
        }

        private void sAMPLEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSummaryOfLoads loads = new frmSummaryOfLoads();
            loads.ShowDialog();
        }

        private void sAMPLEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmLoan loan = new frmLoan();
            loan.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPayroll pay = new frmPayroll();
            pay.ShowDialog();
        }

        private void sAMPLEToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Notepad.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void sAMPLEToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void giveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
