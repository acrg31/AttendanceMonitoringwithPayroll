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
    public partial class frmLogin : Form
    {
        //public string connection = @"Data Source=192.168.0.211,1433; Network Library = DBMSSOCN; Initial Catalog=Payroll2.0 ; User ID=alecpogi; Password=alecpogi ";
        //  public string connection = @"Data Source=USER\DEYBSQL;Initial Catalog=Payroll2.0 ;Integrated Security=True";
        public string connection = @"Data Source=localhost;Initial Catalog=payroll2.0;Integrated Security=True";
        String sql;
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader read;
        int attempt = 0;

        public frmLogin()
        {
            try
            {
                InitializeComponent();
                con = new SqlConnection(connection);
                con.Open();
                lblConnect.Text = "Connected";
                lblConnect.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                lblConnect.Text = "Not Connected";
                lblConnect.ForeColor = Color.Red;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblConnect.Text == "Connected")
                {
                    sql = "SELECT * FROM tb_EmployeeUSER WHERE EmployeeID COLLATE Latin1_General_CS_AS like '" + txtID.Text + "' AND employeePassword COLLATE Latin1_General_CS_AS like '" + txtPassword.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        if (Convert.ToInt32(read.GetValue(3).ToString()) == 3 && read.GetValue(2).ToString() == "INACTIVE")
                        {
                            read.Close();
                            MessageBox.Show("Your account is locked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtID.Clear();
                            txtPassword.Clear();
                            txtID.Focus();
                        }
                        else if (read.GetValue(2).ToString() == "ACTIVE" && (read.GetValue(3).ToString() == "0" || read.GetValue(3).ToString() == "1" || read.GetValue(3).ToString() == "2"))
                        {
                            read.Close();
                            sql = "SELECT Fname,Mname,Lname FROM tb_Employee WHERE EmployeeID like '" + txtID.Text + "'";
                            cmd = new SqlCommand(sql, con);
                            MessageBox.Show("Welcome " + cmd.ExecuteScalar().ToString(), "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            sql = "Update tb_EmployeeUSER SET Attmps ='0' where employeeID like '" + txtID.Text + "' ";
                            cmd = new SqlCommand(sql, con);
                            cmd.ExecuteNonQuery();

                            this.Hide();

                            frmMenu fMenu = new frmMenu();
                            string ID = Convert.ToString(txtID.Text);
                            fMenu.lUsername.Text = ID.ToString();
                            fMenu.ShowDialog();
                        }
                        else
                        {
                            read.Close();
                            MessageBox.Show("Employee is not active anymore.\nKindly proceed to Administrator to unlock your account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Focus();
                            txtPassword.Clear();
                        }
                    }
                    else if (txtID.Text == "" && txtPassword.Text == "")
                    {
                        read.Close();
                        MessageBox.Show("Please enter your ID Number and Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Focus();
                    }
                    else if (txtID.Text == "")
                    {
                        read.Close();
                        MessageBox.Show("Please enter your ID Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Focus();
                    }
                    else if (txtPassword.Text == "")
                    {
                        read.Close();
                        MessageBox.Show("Please enter your password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                    }
                    else
                    {
                        read.Close();
                        sql = "SELECT * FROM tb_EmployeeUSER WHERE EmployeeID COLLATE Latin1_General_CS_AS like '" + txtID.Text + "' AND employeePassword COLLATE Latin1_General_CS_AS Not like'" + txtPassword.Text + "'";
                        cmd = new SqlCommand(sql, con);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            int z = Convert.ToInt32(read.GetValue(3).ToString());
                            if (z == 2)
                            {
                                read.Close();
                                sql = "Update tb_EmployeeUSER SET Status = 'INACTIVE', Attmps ='3' where EmployeeID like '" + txtID.Text + "' ";
                                cmd = new SqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Your account has been blocked! \nKindly proceed to administrator now to unlock your account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPassword.Clear();
                                txtPassword.Focus();
                                attempt = 0;
                            }
                            else
                            {
                                read.Close();
                                sql = "SELECT * FROM tb_EmployeeUSER WHERE EmployeeID like'" + txtID.Text + "'";
                                cmd = new SqlCommand(sql, con);
                                read = cmd.ExecuteReader();
                                read.Read();

                                if (read.GetValue(2).ToString() == "ACTIVE" && Convert.ToInt32(read.GetValue(3).ToString()) <= 3 && attempt <= 3)
                                {
                                    read.Close();
                                    attempt++;
                                    sql = "Update tb_EmployeeUSER SET Attmps = " + attempt + " where employeeID like '" + txtID.Text + "' ";
                                    cmd = new SqlCommand(sql, con);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show((3 - attempt) + " more attemps will lock your account! \nInvalid Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtPassword.Clear();
                                    txtPassword.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Your account has been blocked! \nKindly proceed to administrator now to unlock your account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    attempt = 0;
                                    txtPassword.Clear();
                                    txtPassword.Focus();
                                    read.Close();
                                }
                            }
                            read.Close();
                        }
                        else
                        {
                            MessageBox.Show("No EmployeeID Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            read.Close();
                            txtID.Clear();
                            txtPassword.Clear();
                            txtID.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("NO DATABASE FOUND!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Clear();
                    txtPassword.Clear();
                    txtID.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnLogin.PerformClick();
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != 8 ? true : false;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }
    }
}
