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
    public partial class frmForgotPassword : Form
    {
        string sql;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        frmLogin login = new frmLogin();
        public frmForgotPassword()
        {
            InitializeComponent();
            con = new SqlConnection(login.connection);
            con.Open();
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            txtPassword.Enabled = false;
            txtRPassword.Enabled = false;
            btnSubmit.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sql = "Select * from tb_Users where UserName like '" + txtUsername.Text + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();

            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please username first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (dr.Read())
            {
                dr.Close();
                txtUsername.Enabled = false;
                txtPassword.Enabled = true;
                txtRPassword.Enabled = true;
                btnSubmit.Enabled = true;
                btnSearch.Enabled = false;
                txtPassword.Focus();
            }
            else;
            {
                MessageBox.Show("Invalid Username","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            sql = "Update tb_User pass = '" + txtPassword.Text + "' where UserName like '" + txtUsername.Text + "'";
            cmd = new SqlCommand(sql, con);

            if (txtPassword.Text != txtRPassword.Text)
            {
                MessageBox.Show("Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtRPassword.Clear();
                txtPassword.Focus();
            }
            else;
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password CHange","Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtRPassword.Clear();
                txtUsername.Enabled = true;
                txtPassword.Enabled = false;
                txtRPassword.Enabled = false;
                btnSearch.Enabled = true;
                btnSubmit.Enabled = false;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSearch.PerformClick();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
      //      e.Handled = char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false; true;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  e.Handled = char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false; true;
        }
    }
}
