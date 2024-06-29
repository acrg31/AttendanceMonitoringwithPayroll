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
    public partial class frmPaymentRecord : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader read;
        string sql = "";
        frmLogin login = new frmLogin();

        public frmPaymentRecord()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }
        public void viewReports()
        {
            sql = "SELECT batchdate as [BATCH DATE], EmployeeID as [EMPLOYEE ID], workingTImeTotal as [WORK HOURS], grosspay as [GROSS PAY], deduction as [HOURS DEDUCTED], sss as [SSS DEDUCTIONS], philhealth as [PHILHEALTH], tax AS [TAX],pagibig AS [PAGIBIG],netpay AS [NETPAY] FROM tb_BatchProcess";
            cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteNonQuery();
            da.Fill(dt);
            dgReports.DataSource = dt;

        }

        private void frmPaymentRecord_Load(object sender, EventArgs e)
        {
            viewReports();
        }

        
    }
}
