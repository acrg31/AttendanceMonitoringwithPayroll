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
    public partial class frmEmployeeRecords : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter adp;
        SqlDataReader read;
        frmLogin login = new frmLogin();
        public string sql = "";
        public frmEmployeeRecords()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
        }
        private void frmEmployeeRecords_Load_1(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT EmployeeID as[EMPLOYEE ID],Fname as [FIRSTNAME],Mname as [MIDDLENAME],Lname as [LASTNAME],gender as [GENDER],address as [ADDRESS],bday as [BIRTHDAY],age as [AGE],maritalStatus as [MARITAL STATUS], dtHired as [HIRED], basicpay as [RATE], rd as [RESTDAY],dpartment as [DEPARTMENT], position as [POSITION],contract as [CONTRACT],status as [STATUS]  FROM tb_Employee";
                cmd = new SqlCommand(sql, cnn);
                adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgEmpName.DataSource = dt;
                dgEmpName.DataSource = dt;
                dgEmpName.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error! // // //" + ex);
            }
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
          
        }

        private void txtEMployeeName_TextChanged_1(object sender, EventArgs e)
        {
            if (txtEMployeeName.Text != "")
            {
                sql = "SELECT EmployeeID as[EMPLOYEE ID],Fname as [FIRSTNAME],Mname as [MIDDLENAME],Lname as [LASTNAME],gender as [GENDER],address as [ADDRESS],bday as [BIRTHDAY],age as [AGE],maritalStatus as [MARITAL STATUS], dtHired as [HIRED], basicpay as [RATE], rd as [RESTDAY],dpartment as [DEPARTMENT], position as [POSITION],contract as [CONTRACT],status as [STATUS]  FROM tb_Employee WHERE EmployeeID like'%" + txtEMployeeName.Text+"%'";
                cmd = new SqlCommand(sql, cnn);
                adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgEmpName.DataSource = dt;
            }
            else
            {
                frmEmployeeRecords_Load_1(sender, e);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
