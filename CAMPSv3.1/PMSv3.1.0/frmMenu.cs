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
    public partial class frmMenu : Form
    {
        string sql;
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader reader;
        frmLogin login = new frmLogin();
        public frmMenu()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        private void MainForm(object FormAll)
        {
            if (this.panelCenter.Controls.Count > 0)
                this.panelCenter.Controls.RemoveAt(0);
            Form fh = FormAll as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelCenter.Controls.Add(fh);
            this.panelCenter.Tag = fh;
            fh.Show();
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            frmInformation frmInformation = new frmInformation();
            frmInformation.FormClosed += new FormClosedEventHandler(EmployeeMenu_FormClosed);
            frmInformation.lEmployeeID.Text = lUsername.Text;
            MainForm(frmInformation);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmManualLogin frmManualLogin = new frmManualLogin();
            frmManualLogin.FormClosed += new FormClosedEventHandler(EmployeeMenu_FormClosed);
            frmManualLogin.lEmployeeID.Text = lUsername.Text;
            MainForm(frmManualLogin);
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            frmRecord frmRecord = new frmRecord();
            frmRecord.FormClosed += new FormClosedEventHandler(EmployeeMenu_FormClosed);
            frmRecord.lEmployeeID.Text = lUsername.Text;
            MainForm(frmRecord);
        }

        private void EmployeeMenu_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void View()
        {
            sql = "Select * from tb_Employee where EmployeeID like '" + lUsername.Text + "'";
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
            {
                lFirstname.Text = reader.GetValue(1).ToString();
                reader.Close();
            }
        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {
            View();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lDate.Text = DateTime.Now.ToLongDateString();
            lTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("You have been logout", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Hide();
                frmLogin fLogin = new frmLogin();
                fLogin.Show();             
            }
        }

        private void iconminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconclose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
