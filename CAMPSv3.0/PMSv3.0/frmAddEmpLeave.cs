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
    public partial class frmAddEmpLeave : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter dr;
        SqlDataReader read;
        frmLogin login = new frmLogin();

        public string sql = "";

        public frmAddEmpLeave()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        private void frmAddEmpLeave_Load(object sender, EventArgs e)
        {
            try
            {    
                sql = "SELECT leaveID AS [LEAVE ID], employeeID AS [EMPLOYEE ID], leaveRemaining AS [LEAVE REMAINING] FROM tb_RemainingLeaves";
                cmd = new SqlCommand(sql, cnn);
                dr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dgLeave.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT leaveID AS [LEAVE ID], employeeID AS [EMPLOYEE ID], leaveRemaining AS [LEAVE REMAINING] FROM tb_RemainingLeaves WHERE employeeID like'" + txtSearch.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                dr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                dgLeave.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtID.Text==null||txtID.Text=="")
            {
                MessageBox.Show("Please double click on the employee first!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    sql = "UPDATE tb_RemainingLeaves SET leaveRemaining ='" + txtLeave.Text+ "' WHERE employeeID like '"+txtID.Text+"'";
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee leave has been updated!", "Successful");
                    cmd.Dispose();
                    txtLeave.ReadOnly = true;
                    frmAddEmpLeave_Load(sender,e);
                    txtID.Clear();
                    txtLeave.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!  " + ex);
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtLeave.Clear();
            txtLeave.ReadOnly = true;
            
        }

        private void dgLeave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = dgLeave.Rows[e.RowIndex];
                txtID.Text = Row.Cells[1].Value.ToString();
                txtLeave.Text = Row.Cells[2].Value.ToString();
                txtLeave.ReadOnly = false;
            }
        }
    }
}
