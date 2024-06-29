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
    public partial class frmChangepass : Form
    {

        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter dr;
        SqlDataReader read;
        frmLogin login = new frmLogin();
        Random rand;

        public string sql = "";


        public frmChangepass()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to update employee password?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               
            }
        }
      

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string x = "";
            for (int y = 0; y <= 5; y++)
            {
                x += Convert.ToString(rand.Next(0, 9));
            }
            txtPassword.Text = x.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sql = "Select EmployeeID AS [Employee ID] from tb_EmployeeUSER where EmployeeID like '%" + txtSearch.Text + "%'";
            dr = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dgvAccount.DataSource = dt;
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Generate new password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sql = "UPDATE tb_EmployeeUSER SET employeePassword = '" + txtPassword.Text + "' WHERE EmployeeID = '" + txtEmployeeID.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Password Updated", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                View();
                txtSearch.Clear();
                txtEmployeeID.Clear();
                txtPassword.Clear();
                btnGenerate.Visible = false;
                btnUpdate.Visible = true;
                btnClear.Enabled = false;
                btnEdit.Visible = true;
            }
        }
        private void View()
        {
            dgvAccount.Columns.Clear();
            sql = "Select EmployeeID AS [Employee ID] from tb_EmployeeUSER";
            cmd = new SqlCommand(sql, cnn);
            dr = new SqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
               DataTable dt = new DataTable();
                dr.Fill(dt);
                dgvAccount.DataSource = dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
