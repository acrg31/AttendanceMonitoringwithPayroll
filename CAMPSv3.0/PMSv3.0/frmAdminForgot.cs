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
    public partial class frmAdminForgot : Form
    {
        string sql;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string connection = @"Data Source=DESKTOP-VM6B8T2;Initial Catalog=asaka ;Integrated Security=True";
        public frmAdminForgot()
        {
            InitializeComponent();
            con = new SqlConnection(connection);
            con.Open();
        }

        private void frmAdminForgot_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            txtSQuestion.Visible = false;
            label3.Visible = false;
            txtAnswer.Visible = false;
            label4.Visible = false;
            txtPassword.Visible = false;
            label5.Visible = false;
            txtRPassword.Visible = false;

            btnSubmit.Enabled = false;
            btnDone.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tb_User WHERE username like '" + txtUsername.Text + "'";
            con = new SqlConnection(connection);
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (txtUsername.Text == "")
            {
                MessageBox.Show("input username");
                txtUsername.Focus();
            }
            else if (dr.Read())
            {
                dr.Close();
                txtUsername.Enabled = false;
                btnSearch.Enabled = false;
                btnSubmit.Enabled = true;
                label2.Visible = true;
                txtSQuestion.Visible = true;
                label3.Visible = true;
                txtAnswer.Visible = true;
                txtAnswer.Focus();
                string sql1 = "SELECT squestion FROM tb_User WHERE username like '" + txtUsername.Text + "'";
                SqlCommand cmdd = new SqlCommand(sql1, con);
                txtSQuestion.Text = cmdd.ExecuteScalar().ToString();

            }
            else
            {
                MessageBox.Show("Invalid Username","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtUsername.Focus();
            }
            con.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tb_User WHERE username like '" + txtUsername.Text + "' AND answer like '" + txtAnswer.Text + "'";
            con = new SqlConnection(connection);
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();
                txtAnswer.Enabled = false;
                label4.Visible = true;
                label5.Visible = true;
                txtPassword.Visible = true;
                txtRPassword.Visible = true;
                btnSubmit.Enabled = false;
                btnDone.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong answer!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnswer.Clear();
                txtAnswer.Focus();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            sql = "UPDATE tb_User SET password='" + txtPassword.Text + "' WHERE username like '" + txtUsername.Text + "'";
            cmd = new SqlCommand(sql, con);

            if (txtPassword.Text != txtRPassword.Text)
            {
                MessageBox.Show("Password do not match","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtRPassword.Clear();
                txtPassword.Focus();
            }
            else
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Password Changed","Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtUsername.Clear();
                txtUsername.Enabled = true;
                txtSQuestion.Clear();
                label2.Visible = false;
                txtSQuestion.Visible = false;
                txtAnswer.Clear();
                txtAnswer.Enabled = true;
                label3.Visible = false;
                txtAnswer.Visible = false;
                txtPassword.Clear();
                label4.Visible = false;
                txtPassword.Visible = false;
                txtRPassword.Clear();
                label5.Visible = false;
                txtRPassword.Visible = false;

                btnSearch.Enabled = true;
                btnDone.Enabled = false;

                txtUsername.Focus();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSearch.PerformClick();
            }
        }

        private void txtAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSubmit.PerformClick();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnDone.PerformClick();
            }
        }
    }
}
