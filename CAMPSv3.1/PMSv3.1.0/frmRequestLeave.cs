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
    public partial class frmRequestLeave : Form
    {
        string connection = @"Data Source=localhosts;Initial Catalog=Payroll2.0 ;Integrated Security=True";
        string sql;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmRequestLeave()
        {
            InitializeComponent();
            con = new SqlConnection(connection);
            con.Open();
        }

        private void frmRequestLeave_Load(object sender, EventArgs e)
        {
            View();
            View1();
            View2();
            //dtFrom.MinDate = DateTime.Now;
            //dtTo.MinDate = DateTime.Now;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(lDays.Text);
            int b = Convert.ToInt32(lRemaining1.Text);

            try
            {
                if (dtFrom.Value > dtTo.Value)
                {
                    MessageBox.Show("Invalid Date");
                }
                else if (cbType.Text == "")
                {
                    MessageBox.Show("Input Type");
                }
                else if (txtReason.Text == "")
                {
                    MessageBox.Show("Input Reason");
                }
                else if (cbType.Text == "Paternal Leave" && lDays.Text != "7")
                {
                    MessageBox.Show("Must be 7 Day's");
                }
                else if (cbType.Text == "Maternal Leave" && lDays.Text != "65")
                {
                    MessageBox.Show("Must be 65 Day's");
                }
                else if (cbType.Text == "V/S Leave" && a >= b)
                {
                    DialogResult result = MessageBox.Show("Insufficient Leave. You want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        View1();
                        cbType.Items.Clear();
                        txtReason.Clear();
                    }
                }
                else
                {
                    sql = "INSERT INTO tb_FileLeave (employeeID, empName, empPosition, leaveStart, leaveEnd, leaveDays, leaveReason, leaveType, leaveStatus) values ('" + lID.Text + "','" + lName.Text + "','" + lPosition.Text + "','" + dtFrom.Value + "','" + dtTo.Value + "','" + lDays.Text + "','" + txtReason.Text + "','" + cbType.Text + "','Pending')";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successful Send");
                    View1();
                    txtReason.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void View()
        {
            sql = "Select * from tb_RegisterEmployee where EmployeeID like '" + lID.Text + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();

            dr.Read();
            if (dr.HasRows)
            {
                lName.Text = dr["Fname"].ToString() + " " + dr["MName"].ToString() + " " + dr["LName"].ToString();
                lPosition.Text = dr["Position"].ToString();

                dr.Close();
            }
        }

        private void View1()
        {
            cbType.Items.Clear();
            sql = "Select * from tb_RegisterEmployee where employeeID like '" + lID.Text + "'";
            cmd = new SqlCommand(sql, con);
            try
            {
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    if (dr.GetValue(5).ToString() == "Male")
                    {
                        cbType.Items.Add("V/S Leave");
                        cbType.Items.Add("Paternal Leave");
                        dr.Close();
                    }
                    else if (dr.GetValue(5).ToString() == "Female")
                    {
                        cbType.Items.Add("V/S Leave");
                        cbType.Items.Add("Maternal Leave");
                        dr.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void View2()
        {
            sql = "Select * from tb_RemainingLeave where employeeID like '" + lID.Text + "'";
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();

            try
            {
                dr.Read();
                if (dr.HasRows)
                {
                    lRemaining1.Text = dr["leaveRemaining"].ToString();
                    lRemaining1.Visible = true;
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void View3()
        {

        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            DateTime d1 = dtFrom.Value;
            DateTime d2 = dtTo.Value;
            TimeSpan t = d2 - d1;

            double dDays = t.TotalDays + 1;
            int days = Convert.ToInt32(dDays);

            lDays.Text = days.ToString();
        }
    }
}
