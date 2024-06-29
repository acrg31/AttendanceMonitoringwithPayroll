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

namespace PMSv3._1._0
{
    public partial class frmRecord : Form
    {
        SqlConnection cnn;
        frmLogin login = new frmLogin();
        public frmRecord()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        private void frmRecord_Load(object sender, EventArgs e)
        {
            View();
            dtTo.MaxDate = DateTime.Today;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            if (dtTo.Value.Date < dtFrom.Value.Date)
            {
                MessageBox.Show("Invalid Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string sql = "SELECT Date as [DATE], EmployeeID AS [ID], EmployeeName AS [NAME], InTime AS [IN], OutTime AS [OUT], WorkingTime AS [WORKING HOURS],late as [LATE], Undertime as [UNDERTIME], Adjustment as [ADJUSTMENT],totalDeduction as [DEDUCTION]  FROM tb_Attendance WHERE EmployeeID like'" + lEmployeeID.Text + "' AND Date between'" + dtFrom.Value.ToString("MM/dd/yyyy") + "' and '" + dtTo.Value.ToString("MM/dd/yyyy") + "'";

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    cmd.ExecuteNonQuery();
                    da.Fill(dt);
                    dgvRecord.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }           
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtFrom.Value==DateTime.Now)
            {
                dtTo.Value = dtFrom.Value;
            }
            else if (dtFrom.Value.AddDays(15)>=dtTo.MaxDate)
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
