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
    public partial class frmLogin : Form
    {

        public SqlConnection cnn;
        public SqlCommand cmd;
        public SqlDataReader read;
        public string connection = @"Data Source=localhost;Initial Catalog=payroll2.0;Integrated Security=True";
        public string sql = "";
        int attemps = 3;
        public frmLogin()
        {
            try
            {
                InitializeComponent();
                cnn = new SqlConnection(connection);
                cnn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show("DATABASE IS NOT CONNECTED!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                frmAdminMain main = new frmAdminMain();
                sql = "SELECT * FROM tb_Users WHERE UserName COLLATE Latin1_General_CS_AS like'" + txtUser.Text + "' AND pass COLLATE Latin1_General_CS_AS like '" + txtPassword.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    if (read[6].ToString() == "UNLOCKED")
                    {
                        if (read[3].ToString()== "Admin")
                        {
                            if (read[4].ToString() == "Human Resource")
                            {
                                main.lblUser.Text = txtUser.Text;
                                main.lblPass.Text = txtPassword.Text;
                                main.btnTransaction.Enabled = false;
                                main.tblReports.Enabled = false;
                                
                                this.Hide();
                                main.Show();
                            }
                            else if (read[4].ToString() == "Finance")
                            {

                                main.lblUser.Text = txtUser.Text;
                                main.lblPass.Text = txtPassword.Text;
                                main.btnTables.Enabled = false;
                                main.frmUsers.Enabled = false;
                                main.btnMaintenance.Enabled = false;
                                this.Hide();
                                main.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid account!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your account is currently locked. Please go to the admin to unlocked your account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    read.Close();
                }
                else
                {
                    read.Close();
                    sql = "SELECT * FROM tb_Users WHERE UserName COLLATE Latin1_General_CS_AS like'"+txtUser.Text+"'";
                    cmd = new SqlCommand(sql,cnn);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        if (attemps == 1)
                        {
                            string stats = "LOCKED";
                            read.Close();
                            sql = "UPDATE tb_Users set statusAcc='" + stats + "' WHERE UserName like'" + txtUser.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Your account has been locked! Please proceed to the admin to unlock your account.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else if (attemps != 0)
                        {
                            attemps--;
                            MessageBox.Show(attemps + " wrong attemps will locked your account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            read.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("User name and password cannot find!","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        read.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Are you sure you want to exit?", "Payroll Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (exit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                btnLogin.PerformClick();
            }
        }
    }
}
