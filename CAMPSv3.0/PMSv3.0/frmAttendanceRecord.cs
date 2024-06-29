using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMSv3._0
{
    public partial class frmAttendanceRecord : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter dr;
        SqlDataReader read;
        frmLogin login = new frmLogin();
        string sql = "";
        public frmAttendanceRecord()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT Date as [DATE], EmployeeID AS [ID], Fname AS [FIRSTNAME], Mname AS [MIDDLENAME], Lname AS [LASTNAME], InTime AS [IN], OutTime AS [OUT], WorkingTime AS [WORKING HOURS],late as [LATE], Undertime as [UNDERTIME], Adjustment as [ADJUSTMENT],totalDeduction as [DEDUCTION]  FROM tb_Attendance WHERE EmployeeID like'" + txtEmployeeID.Text + "' AND Date between'" + dtFrom.Value.ToString("MM/dd/yyyy") + "' and '" + dtTo.Value.ToString("MM/dd/yyyy") + "'";
                cmd = new SqlCommand(sql, cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                dgAttendance.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtEmployeeID.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                read.Read();
                if (read.HasRows)
                {
                    dtFrom.Enabled = true;
                    dtTo.Enabled = true;
                    btnView.Enabled = true;
                   txtName.Text= read.GetValue(3).ToString();
                   txtName.Text+= ", "+read.GetValue(1).ToString();
                   txtName.Text+=" "+ read.GetValue(2).ToString();
                   txtPosition.Text= read.GetValue(19).ToString();
                    
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void frmAttendanceRecord_Load_1(object sender, EventArgs e)
        {
            try
            {
                dtFrom.Enabled = false;
                dtTo.Enabled = false;
                btnView.Enabled = false;

                dtTo.MaxDate = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {

            if (dtFrom.Value == DateTime.Now)
            {
                dtTo.Value = dtFrom.Value;
            }
            else if (dtFrom.Value.AddDays(15) >= dtTo.MaxDate)
            {
                dtTo.Value = dtTo.MaxDate;
            }
            else
            {
                dtTo.Value = dtFrom.Value.AddDays(14);
            }
        }
    }
}
