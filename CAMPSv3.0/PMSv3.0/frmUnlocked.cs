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
    public partial class frmUnlocked : Form
    {
        string sql;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        frmLogin login = new frmLogin();
        public frmUnlocked()
        {
            InitializeComponent();
            con = new SqlConnection(login.connection);
            con.Open();
        }

        private void frmUnlocked_Load(object sender, EventArgs e)
        {
            View();
            txtEmployeeID.Enabled = false;
            cbStatus.Enabled = false;
            txtAttempt.Enabled = false;
            btnUpdate.Visible = false;
            btnClear.Enabled = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sql = "Select EmployeeID AS [Employee ID], Status, Attmps AS [Attempt] from tb_EmployeeUSER  WHERE EmployeeID like '%" + txtEmployeeID.Text + "%'";
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            dgvAccount.DataSource = dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cbStatus.Enabled = true;
            txtAttempt.Enabled = true;

            txtEmployeeID.Text = dgvAccount.CurrentRow.Cells[0].Value.ToString();
            cbStatus.Text = dgvAccount.CurrentRow.Cells[1].Value.ToString();
            txtAttempt.Text = dgvAccount.CurrentRow.Cells[2].Value.ToString();

            btnEdit.Enabled = false;
            btnUpdate.Enabled = true;
            btnUpdate.Visible = true;
            btnClear.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAttempt.Text))
            {
                txtAttempt.Text = "0";
            }
            if (Convert.ToInt32(txtAttempt.Text) >= 1)
            {
                MessageBox.Show("You can input 0 only!");
            }
            else
            {
                sql = "Update tb_EmployeeUSER SET Status = '" + cbStatus.Text + "', Attmps = '" + txtAttempt.Text + "' where EmployeeID like '" + txtEmployeeID.Text + "' ";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "Update tb_Employee SET status = '" + cbStatus.Text + "' where EmployeeID like '" + txtEmployeeID.Text + "' ";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("success");
                btnEdit.Enabled = true;
                btnUpdate.Enabled = true;
                btnUpdate.Visible = false;
                View();
                Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void View()
        {
            dgvAccount.Columns.Clear();
            sql = "Select EmployeeID AS [Employee ID], Status, Attmps AS [Attempt] from tb_EmployeeUSER";
            cmd = new SqlCommand(sql, con);
            da = new SqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                da.Fill(dt);
                dgvAccount.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void Clear()
        {
            cbStatus.Enabled = false;
            txtAttempt.Enabled = false;

            txtEmployeeID.Clear();
            cbStatus.Items.Clear();
            cbStatus.Items.Add("ACTIVE");
            cbStatus.Items.Add("INACTIVE");
            txtAttempt.Clear();

            btnEdit.Visible = true;
            btnUpdate.Enabled = false;
            btnClear.Enabled = false;
        }

        private void txtAttempt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false: true;
        }

        private void cbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnUpdate.PerformClick();
            }
        }
    }
}
