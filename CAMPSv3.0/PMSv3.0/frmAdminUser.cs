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
    public partial class frmAdminUser : Form
    {
        string type = "";
        string sql;
        SqlConnection con;
        SqlCommand cmd;
        string connection = @"Data Source=DESKTOP-VM6B8T2;Initial Catalog=asaka ;Integrated Security=True";
        public frmAdminUser()
        {
            InitializeComponent();
            con = new SqlConnection(connection);
            con.Open();
        }

        private void frmAdminUser_Load(object sender, EventArgs e)
        {
            View();
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtRPassword.Enabled = false;
            cbSQuestion.Enabled = false;
            txtAnswer.Enabled = false;
            cbStatus.Enabled = false;
            rbAdmin.Checked = false;
            rbUser.Checked = false;
            rbAdmin.Enabled = false;
            rbUser.Enabled = false;
            btnAdd.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtRPassword.Enabled = true;
            cbSQuestion.Enabled = true;
            txtAnswer.Enabled = true;
            rbAdmin.Enabled = true;
            rbUser.Enabled = true;
            btnAdd.Enabled = true;
            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbAdmin.Checked == true)
            {
                type = "Administrator";
            }
            else if (rbUser.Checked == true)
            {
                type = "User";
            }

            if (txtUsername.Text == "" || txtPassword.Text == "" || txtRPassword.Text == "" || cbSQuestion.Text == "" || txtAnswer.Text == "" || (rbAdmin.Checked == false && rbUser.Checked == false))
            {
                MessageBox.Show("Please fill up the all blanks!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtRPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Password Doesn't Match","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtUsername.Text.Count() < 5)
            {
                MessageBox.Show("Username Contains Atleast 5 Characters","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtPassword.Text.Count() < 5)
            {
                MessageBox.Show("Password Contains Atleast 5 Characters","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtAnswer.Text.Count() < 5)
            {
                MessageBox.Show("Answer Contains Atleast 5 Characters","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                sql = "INSERT INTO tb_User (username, password, squestion, answer, status, type) values ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + cbSQuestion.Text + "','" + txtAnswer.Text + "','Active','" + type + "')";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Account Added!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                View();
                Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Select username","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rbAdmin.Checked == true)
                {
                    type = "Administrator";
                }
                else if (rbUser.Checked == true)
                {
                    type = "User";
                }
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Complete The Blank","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtRPassword.Text != txtPassword.Text)
                {
                    MessageBox.Show("Password Doesn't Match","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassword.Text.Count() < 5 && txtAnswer.Text.Count() < 5)
                {
                    MessageBox.Show("Password/Answer Contains Atleast 5 Characters","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassword.Text.Count() < 5)
                {
                    MessageBox.Show("Password Contains Atleast 5 Characters","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtAnswer.Text.Count() < 5)
                {
                    MessageBox.Show("Answer Contains Atleast 5 Characters","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sql = "UPDATE tb_User SET password='" + txtPassword.Text + "',squestion='" + cbSQuestion.Text + "',answer='" + txtAnswer.Text + "',status='" + cbStatus.Text + "',type='" + type + "' WHERE username like '" + txtUsername.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Updated!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    View();
                    Clear();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void View()
        {
            dgvAccount.Columns.Clear();
            string sql = "Select * from tb_User";
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgvAccount.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtRPassword.Clear();
            cbSQuestion.Items.Clear();
            cbSQuestion.Items.Add("What is your mother middle name?");
            cbSQuestion.Items.Add("What is your first pet name?");
            cbSQuestion.Items.Add("Where is your province?");
            cbSQuestion.Items.Add("Who is your favorite uncle?");
            cbSQuestion.Items.Add("Who is your first math teacher?");
            txtAnswer.Clear();
            cbStatus.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");

            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            txtRPassword.Enabled = false;
            cbSQuestion.Enabled = false;
            txtAnswer.Enabled = false;
            cbStatus.Enabled = false;
            rbAdmin.Checked = false;
            rbUser.Checked = false;
            rbAdmin.Enabled = false;
            rbUser.Enabled = false;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnNew.Enabled = true;
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnAdd.PerformClick();
            }
        }

        private void dgvAccount_Click(object sender, EventArgs e)
        {
            txtUsername.Enabled = false;
            txtPassword.Enabled = true;
            txtRPassword.Enabled = true;
            cbSQuestion.Enabled = true;
            txtAnswer.Enabled = true;
            cbStatus.Enabled = true;
            rbAdmin.Enabled = true;
            rbUser.Enabled = true;

            btnNew.Enabled = false;

            txtUsername.Text = dgvAccount.CurrentRow.Cells["username"].Value.ToString();
            txtPassword.Text = dgvAccount.CurrentRow.Cells["password"].Value.ToString();
            txtRPassword.Text = dgvAccount.CurrentRow.Cells["password"].Value.ToString();
            cbSQuestion.Text = dgvAccount.CurrentRow.Cells["squestion"].Value.ToString();
            txtAnswer.Text = dgvAccount.CurrentRow.Cells["answer"].Value.ToString();
            cbStatus.Text = dgvAccount.CurrentRow.Cells["status"].Value.ToString();

            if (dgvAccount.CurrentRow.Cells["type"].Value.ToString() == "Administrator")
            {
                rbAdmin.Checked = true;
            }
            else if (dgvAccount.CurrentRow.Cells["type"].Value.ToString() == "User")
            {
                rbUser.Checked = true;
            }
        }
    }
}
