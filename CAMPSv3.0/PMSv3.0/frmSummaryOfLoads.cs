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
using System.Text.RegularExpressions;


namespace PMSv3._0
{
    public partial class frmSummaryOfLoads : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader read;
        SqlDataAdapter dr;
        string sql = "";
        frmLogin login = new frmLogin();

        string rd = "";
        string holder = "";
        int total = 0;
        double mnday = 0, tuesday = 0, wed = 0, thurs = 0, fri = 0, sat = 0, sun = 0;
        public frmSummaryOfLoads()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        public void disable()
        {
            txtDepartment.Enabled = false;
            txtEmployeeName.Enabled = false;
            txtPosition.Enabled = false;
            txtRestday.Enabled = false;
        }
        
        public void enable()
        {
            txtDepartment.Enabled = true;
            txtEmployeeName.Enabled = true;
            txtPosition.Enabled = true;
            txtRestday.Enabled = true;       
        }

        public void disableTxt()
        {
            //Monday
            txtMonIn.Enabled = false;
            txtMonOut.Enabled = false;
            txtMonHour.Enabled = false;
            //Tuesday
            txtTuesIn.Enabled = false;
            txtTuesOut.Enabled = false;
            txtTuesHour.Enabled = false;
            //Wednesday
            txtWedIn.Enabled = false;
            txtWedOut.Enabled = false;
            txtWedHour.Enabled = false;
            //Thursday
            txtThursIn.Enabled = false;
            txtThursOut.Enabled = false;
            txtThursHour.Enabled = false;
            //Friday
            txtFriIn.Enabled = false;
            txtFriOut.Enabled = false;
            txtFriHour.Enabled = false;
            //Saturday
            txtSatIn.Enabled = false;
            txtSatOut.Enabled = false;
            txtSatHour.Enabled = false;
            //Sunday
            txtSunIn.Enabled = false;
            txtSunOut.Enabled = false;
            txtSunHour.Enabled = false;
        }
        public void enableTxt()
        {
            //Monday
            txtMonIn.Enabled = true;
            txtMonOut.Enabled = true;
            txtMonHour.Enabled = true;
            //Tuesday
            txtTuesIn.Enabled = true;
            txtTuesOut.Enabled = true;
            txtTuesHour.Enabled = true;
            //Wednesday
            txtWedIn.Enabled = true;
            txtWedOut.Enabled = true;
            txtWedHour.Enabled = true;
            //Thursday
            txtThursIn.Enabled = true;
            txtThursOut.Enabled = true;
            txtThursHour.Enabled = true;
            //Friday
            txtFriIn.Enabled = true;
            txtFriOut.Enabled = true;
            txtFriHour.Enabled = true;
            //Saturday
            txtSatIn.Enabled = true;
            txtSatOut.Enabled = true;
            txtSatHour.Enabled = true;
            //Sunday
            txtSunIn.Enabled = true;
            txtSunOut.Enabled = true;
            txtSunHour.Enabled = true;
        }
        public void clear()
        {
            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
            txtDepartment.Clear();
            txtPosition.Clear();
            txtRestday.Clear();
            txtMonIn.Clear();
            txtMonOut.Clear();
            txtMonHour.Clear();
            txtTuesIn.Clear();
            txtTuesOut.Clear();
            txtTuesHour.Clear();
            txtWedIn.Clear();
            txtWedOut.Clear();
            txtWedHour.Clear();
            txtThursIn.Clear();
            txtThursOut.Clear();
            txtThursHour.Clear();
            txtFriIn.Clear();
            txtFriOut.Clear();
            txtFriHour.Clear();
            txtSatIn.Clear();
            txtSatOut.Clear();
            txtSatHour.Clear();
            txtSunIn.Clear();
            txtSunOut.Clear();
            txtSunHour.Clear();
            lbTotalHour.Text = "0";
        }
        public void clearTxt()
        {
            txtMonIn.Clear();
            txtMonOut.Clear();
            txtMonHour.Clear();
            txtTuesIn.Clear();
            txtTuesOut.Clear();
            txtTuesHour.Clear();
            txtWedIn.Clear();
            txtWedOut.Clear();
            txtWedHour.Clear();
            txtThursIn.Clear();
            txtThursOut.Clear();
            txtThursHour.Clear();
            txtFriIn.Clear();
            txtFriOut.Clear();
            txtFriHour.Clear();
            txtSatIn.Clear();
            txtSatOut.Clear();
            txtSatHour.Clear();
            txtSunIn.Clear();
            txtSunOut.Clear();
            txtSunHour.Clear();
            lbTotalHour.Text = "0";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
            disable();
            disableTxt();
            read.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult save = MessageBox.Show("Are you sure you want to save?", "Payroll Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (save == DialogResult.Yes)
                {
                    read.Close();
                    if (txtRestday.Text == "Monday")
                    {
                        if (txtTuesHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            sql = "UPDATE tb_SummaryOfLoads SET TuesIn='" + txtTuesIn.Text + "', TuesOut='" + txtTuesOut.Text + "', TuesHour='" + txtTuesHour.Text + "', WedIn='" + txtWedIn.Text + "', WedOut='" + txtWedOut.Text + "', WedHour='" + txtWedHour.Text + "', ThurIn='" + txtThursIn.Text + "', ThurOut='" + txtThursOut.Text + "', ThurHour='" + txtThursHour.Text + "', FriIn='" + txtFriIn.Text + "', FriOut='" + txtFriOut.Text + "', FriHour='" + txtFriHour.Text + "', SatIn='" + txtSatIn.Text + "', SatOut='" + txtSatOut.Text + "', SatHour='" + txtSatHour.Text + "', SunIn='" + txtSunIn.Text + "', SunOut='" + txtSunOut.Text + "', SunHour='" + txtSunHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");
                            clear();
                            disable();
                            disableTxt();
                        }
                    }
                    else if (txtRestday.Text == "Tuesday")
                    {
                        if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            sql = "UPDATE tb_SummaryOfLoads SET MonIN='" + txtMonIn.Text + "', MonOut='" + txtMonOut.Text + "', MonHour='" + txtMonHour.Text + "', WedIn='" + txtWedIn.Text + "', WedOut='" + txtWedOut.Text + "', WedHour='" + txtWedHour.Text + "', ThurIn='" + txtThursIn.Text + "', ThurOut='" + txtThursOut.Text + "', ThurHour='" + txtThursHour.Text + "', FriIn='" + txtFriIn.Text + "', FriOut='" + txtFriOut.Text + "', FriHour='" + txtFriHour.Text + "', SatIn='" + txtSatIn.Text + "', SatOut='" + txtSatOut.Text + "', SatHour='" + txtSatHour.Text + "', SunIn='" + txtSunIn.Text + "', SunOut='" + txtSunOut.Text + "', SunHour='" + txtSunHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");
                            clear();
                            disable();
                            disableTxt();
                        }
                    }
                    else if (txtRestday.Text == "Wednesday")
                    {
                        if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            sql = "UPDATE tb_SummaryOfLoads SET MonIN='" + txtMonIn.Text + "', MonOut='" + txtMonOut.Text + "', MonHour='" + txtMonHour.Text + "', TuesIn='" + txtTuesIn.Text + "', TuesOut='" + txtTuesOut.Text + "', TuesHour='" + txtTuesHour.Text + "', ThurIn='" + txtThursIn.Text + "', ThurOut='" + txtThursOut.Text + "', ThurHour='" + txtThursHour.Text + "', FriIn='" + txtFriIn.Text + "', FriOut='" + txtFriOut.Text + "', FriHour='" + txtFriHour.Text + "', SatIn='" + txtSatIn.Text + "', SatOut='" + txtSatOut.Text + "', SatHour='" + txtSatHour.Text + "', SunIn='" + txtSunIn.Text + "', SunOut='" + txtSunOut.Text + "', SunHour='" + txtSunHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");

                            clear();
                            disable();
                            disableTxt();
                        }
                    }
                    else if (txtRestday.Text == "Thursday")
                    {
                        if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            sql = "UPDATE tb_SummaryOfLoads SET MonIN='" + txtMonIn.Text + "', MonOut='" + txtMonOut.Text + "', MonHour='" + txtMonHour.Text + "', TuesIn='" + txtTuesIn.Text + "', TuesOut='" + txtTuesOut.Text + "', TuesHour='" + txtTuesHour.Text + "', WedIn='" + txtWedIn.Text + "', WedOut='" + txtWedOut.Text + "', WedHour='" + txtWedHour.Text + "', FriIn='" + txtFriIn.Text + "', FriOut='" + txtFriOut.Text + "', FriHour='" + txtFriHour.Text + "', SatIn='" + txtSatIn.Text + "', SatOut='" + txtSatOut.Text + "', SatHour='" + txtSatHour.Text + "', SunIn='" + txtSunIn.Text + "', SunOut='" + txtSunOut.Text + "', SunHour='" + txtSunHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");
                            clear();
                            disable();
                            disableTxt();
                        }
                    }
                    else if (txtRestday.Text == "Friday")
                    {
                        if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            sql = "UPDATE tb_SummaryOfLoads SET MonIN='" + txtMonIn.Text + "', MonOut='" + txtMonOut.Text + "', MonHour='" + txtMonHour.Text + "', TuesIn='" + txtTuesIn.Text + "', TuesOut='" + txtTuesOut.Text + "', TuesHour='" + txtTuesHour.Text + "', WedIn='" + txtWedIn.Text + "', WedOut='" + txtWedOut.Text + "', WedHour='" + txtWedHour.Text + "', ThurIn='" + txtThursIn.Text + "', ThurOut='" + txtThursOut.Text + "', ThurHour='" + txtThursHour.Text + "', SatIn='" + txtSatIn.Text + "', SatOut='" + txtSatOut.Text + "', SatHour='" + txtSatHour.Text + "', SunIn='" + txtSunIn.Text + "', SunOut='" + txtSunOut.Text + "', SunHour='" + txtSunHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");

                            clear();
                            disable();
                            disableTxt();
                        }
                    }
                    else if (txtRestday.Text == "Saturday")
                    {
                        if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtFriHour.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            sql = "UPDATE tb_SummaryOfLoads SET MonIN='" + txtMonIn.Text + "', MonOut='" + txtMonOut.Text + "', MonHour='" + txtMonHour.Text + "', TuesIn='" + txtTuesIn.Text + "', TuesOut='" + txtTuesOut.Text + "', TuesHour='" + txtTuesHour.Text + "', WedIn='" + txtWedIn.Text + "', WedOut='" + txtWedOut.Text + "', WedHour='" + txtWedHour.Text + "', ThurIn='" + txtThursIn.Text + "', ThurOut='" + txtThursOut.Text + "', ThurHour='" + txtThursHour.Text + "', FriIn='" + txtFriIn.Text + "', FriOut='" + txtFriOut.Text + "', FriHour='" + txtFriHour.Text + "', SunIn='" + txtSunIn.Text + "', SunOut='" + txtSunOut.Text + "', SunHour='" + txtSunHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");

                            clear();
                            disable();
                            disableTxt();
                        }
                    }
                    else if (txtRestday.Text == "Sunday")
                    {
                        if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtFriHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSatHour.Text == "")
                        {
                            MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            sql = "UPDATE tb_SummaryOfLoads SET MonIN='" + txtMonIn.Text + "', MonOut='" + txtMonOut.Text + "', MonHour='" + txtMonHour.Text + "', TuesIn='" + txtTuesIn.Text + "', TuesOut='" + txtTuesOut.Text + "', TuesHour='" + txtTuesHour.Text + "', WedIn='" + txtWedIn.Text + "', WedOut='" + txtWedOut.Text + "', WedHour='" + txtWedHour.Text + "', ThurIn='" + txtThursIn.Text + "', ThurOut='" + txtThursOut.Text + "', ThurHour='" + txtThursHour.Text + "', FriIn='" + txtFriIn.Text + "', FriOut='" + txtFriOut.Text + "', FriHour='" + txtFriHour.Text + "', SatIn='" + txtSatIn.Text + "', SatOut='" + txtSatOut.Text + "', SatHour='" + txtSatHour.Text + "' WHERE empID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Data has been updated!", "Successful");

                            clear();
                            disable();
                            disableTxt();
                        }
                    }

                }
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
                sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'"+txtEmployeeID.Text+"'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if(read.Read())
                {
                    enable();
                    enableTxt();
                    txtEmployeeName.Text = read.GetValue(1).ToString();
                    txtDepartment.Text = read.GetValue(2).ToString();
                    txtPosition.Text = read.GetValue(3).ToString();
                    txtRestday.Text = read.GetValue(4).ToString();
                    rd = txtRestday.Text;
                    timer1.Start();
                    timer1.Stop();
                    //
                    if(txtRestday.Text=="Monday")
                    {
                        txtMonIn.Enabled = false;
                        txtMonOut.Enabled = false;
                        txtMonHour.Enabled = false;

                        txtTuesIn.Text = read.GetValue(8).ToString();
                        txtTuesOut.Text = read.GetValue(9).ToString();
                        txtTuesHour.Text = read.GetValue(10).ToString();

                        txtWedIn.Text = read.GetValue(11).ToString();
                        txtWedOut.Text = read.GetValue(12).ToString();
                        txtWedHour.Text = read.GetValue(13).ToString();

                        txtThursIn.Text = read.GetValue(14).ToString();
                        txtThursOut.Text = read.GetValue(15).ToString();
                        txtThursHour.Text = read.GetValue(16).ToString();

                        txtFriIn.Text = read.GetValue(17).ToString();
                        txtFriOut.Text = read.GetValue(18).ToString();
                        txtFriHour.Text = read.GetValue(19).ToString();

                        txtSatIn.Text = read.GetValue(20).ToString();
                        txtSatOut.Text = read.GetValue(21).ToString();
                        txtSatHour.Text = read.GetValue(22).ToString();

                        txtSunIn.Text = read.GetValue(23).ToString();
                        txtSunOut.Text = read.GetValue(24).ToString();
                        txtSunHour.Text = read.GetValue(25).ToString();
                    }
                    else if(txtRestday.Text=="Tuesday")
                    {

                        txtMonIn.Text = read.GetValue(5).ToString();
                        txtMonOut.Text = read.GetValue(6).ToString();
                        txtMonHour.Text = read.GetValue(7).ToString();

                        txtTuesIn.Enabled = false;
                        txtTuesOut.Enabled = false;
                        txtTuesHour.Enabled = false;

                        txtWedIn.Text = read.GetValue(11).ToString();
                        txtWedOut.Text = read.GetValue(12).ToString();
                        txtWedHour.Text = read.GetValue(13).ToString();

                        txtThursIn.Text = read.GetValue(14).ToString();
                        txtThursOut.Text = read.GetValue(15).ToString();
                        txtThursHour.Text = read.GetValue(16).ToString();

                        txtFriIn.Text = read.GetValue(17).ToString();
                        txtFriOut.Text = read.GetValue(18).ToString();
                        txtFriHour.Text = read.GetValue(19).ToString();

                        txtSatIn.Text = read.GetValue(20).ToString();
                        txtSatOut.Text = read.GetValue(21).ToString();
                        txtSatHour.Text = read.GetValue(22).ToString();

                        txtSunIn.Text = read.GetValue(23).ToString();
                        txtSunOut.Text = read.GetValue(24).ToString();
                        txtSunHour.Text = read.GetValue(25).ToString();
                    }
                    else if(txtRestday.Text=="Wednesday")
                    {

                        txtMonIn.Text = read.GetValue(5).ToString();
                        txtMonOut.Text = read.GetValue(6).ToString();
                        txtMonHour.Text = read.GetValue(7).ToString();

                        txtTuesIn.Text = read.GetValue(8).ToString();
                        txtTuesOut.Text = read.GetValue(9).ToString();
                        txtTuesHour.Text = read.GetValue(10).ToString();

                        txtWedIn.Enabled = false;
                        txtWedOut.Enabled = false;
                        txtWedHour.Enabled = false;

                        txtThursIn.Text = read.GetValue(14).ToString();
                        txtThursOut.Text = read.GetValue(15).ToString();
                        txtThursHour.Text = read.GetValue(16).ToString();

                        txtFriIn.Text = read.GetValue(17).ToString();
                        txtFriOut.Text = read.GetValue(18).ToString();
                        txtFriHour.Text = read.GetValue(19).ToString();

                        txtSatIn.Text = read.GetValue(20).ToString();
                        txtSatOut.Text = read.GetValue(21).ToString();
                        txtSatHour.Text = read.GetValue(22).ToString();

                        txtSunIn.Text = read.GetValue(23).ToString();
                        txtSunOut.Text = read.GetValue(24).ToString();
                        txtSunHour.Text = read.GetValue(25).ToString();
                    }
                    else if(txtRestday.Text=="Thursday")
                    {

                        txtMonIn.Text = read.GetValue(5).ToString();
                        txtMonOut.Text = read.GetValue(6).ToString();
                        txtMonHour.Text = read.GetValue(7).ToString();

                        txtTuesIn.Text = read.GetValue(8).ToString();
                        txtTuesOut.Text = read.GetValue(9).ToString();
                        txtTuesHour.Text = read.GetValue(10).ToString();

                        txtWedIn.Text = read.GetValue(11).ToString();
                        txtWedOut.Text = read.GetValue(12).ToString();
                        txtWedHour.Text = read.GetValue(13).ToString();

                        txtThursIn.Enabled = false;
                        txtThursOut.Enabled = false;
                        txtThursHour.Enabled = false;

                        txtFriIn.Text = read.GetValue(17).ToString();
                        txtFriOut.Text = read.GetValue(18).ToString();
                        txtFriHour.Text = read.GetValue(19).ToString();

                        txtSatIn.Text = read.GetValue(20).ToString();
                        txtSatOut.Text = read.GetValue(21).ToString();
                        txtSatHour.Text = read.GetValue(22).ToString();

                        txtSunIn.Text = read.GetValue(23).ToString();
                        txtSunOut.Text = read.GetValue(24).ToString();
                        txtSunHour.Text = read.GetValue(25).ToString();
                    }
                    else if(txtRestday.Text=="Friday")
                    {

                        txtMonIn.Text = read.GetValue(5).ToString();
                        txtMonOut.Text = read.GetValue(6).ToString();
                        txtMonHour.Text = read.GetValue(7).ToString();

                        txtTuesIn.Text = read.GetValue(8).ToString();
                        txtTuesOut.Text = read.GetValue(9).ToString();
                        txtTuesHour.Text = read.GetValue(10).ToString();

                        txtWedIn.Text = read.GetValue(11).ToString();
                        txtWedOut.Text = read.GetValue(12).ToString();
                        txtWedHour.Text = read.GetValue(13).ToString();

                        txtThursIn.Text = read.GetValue(14).ToString();
                        txtThursOut.Text = read.GetValue(15).ToString();
                        txtThursHour.Text = read.GetValue(16).ToString();

                        txtFriIn.Enabled=false;
                        txtFriOut.Enabled=false;
                        txtFriHour.Enabled=false;

                        txtSatIn.Text = read.GetValue(20).ToString();
                        txtSatOut.Text = read.GetValue(21).ToString();
                        txtSatHour.Text = read.GetValue(22).ToString();

                        txtSunIn.Text = read.GetValue(23).ToString();
                        txtSunOut.Text = read.GetValue(24).ToString();
                        txtSunHour.Text = read.GetValue(25).ToString();
                    }
                    else if(txtRestday.Text=="Saturday")
                    {

                        txtMonIn.Text = read.GetValue(5).ToString();
                        txtMonOut.Text = read.GetValue(6).ToString();
                        txtMonHour.Text = read.GetValue(7).ToString();

                        txtTuesIn.Text = read.GetValue(8).ToString();
                        txtTuesOut.Text = read.GetValue(9).ToString();
                        txtTuesHour.Text = read.GetValue(10).ToString();

                        txtWedIn.Text = read.GetValue(11).ToString();
                        txtWedOut.Text = read.GetValue(12).ToString();
                        txtWedHour.Text = read.GetValue(13).ToString();

                        txtThursIn.Text = read.GetValue(14).ToString();
                        txtThursOut.Text = read.GetValue(15).ToString();
                        txtThursHour.Text = read.GetValue(16).ToString();

                        txtFriIn.Text = read.GetValue(17).ToString();
                        txtFriOut.Text = read.GetValue(18).ToString();
                        txtFriHour.Text = read.GetValue(19).ToString();

                        txtSatIn.Enabled = false;
                        txtSatOut.Enabled = false;
                        txtSatHour.Enabled = false;

                        txtSunIn.Text = read.GetValue(23).ToString();
                        txtSunOut.Text = read.GetValue(24).ToString();
                        txtSunHour.Text = read.GetValue(25).ToString();
                    }
                    else if(txtRestday.Text=="Sunday")
                    {

                        txtMonIn.Text = read.GetValue(5).ToString();
                        txtMonOut.Text = read.GetValue(6).ToString();
                        txtMonHour.Text = read.GetValue(7).ToString();

                        txtTuesIn.Text = read.GetValue(8).ToString();
                        txtTuesOut.Text = read.GetValue(9).ToString();
                        txtTuesHour.Text = read.GetValue(10).ToString();

                        txtWedIn.Text = read.GetValue(11).ToString();
                        txtWedOut.Text = read.GetValue(12).ToString();
                        txtWedHour.Text = read.GetValue(13).ToString();

                        txtThursIn.Text = read.GetValue(14).ToString();
                        txtThursOut.Text = read.GetValue(15).ToString();
                        txtThursHour.Text = read.GetValue(16).ToString();

                        txtFriIn.Text = read.GetValue(17).ToString();
                        txtFriOut.Text = read.GetValue(18).ToString();
                        txtFriHour.Text = read.GetValue(19).ToString();

                        txtSatIn.Text = read.GetValue(20).ToString();
                        txtSatOut.Text = read.GetValue(21).ToString();
                        txtSatHour.Text = read.GetValue(22).ToString();

                        txtSunIn.Enabled = false;
                        txtSunOut.Enabled = false;
                        txtSunHour.Enabled = false;
                    }
                    read.Close();
                }
                else
                {
                    read.Close();
                    sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'"+txtEmployeeID.Text+"' AND dpartment like 'Admin'";
                    cmd = new SqlCommand(sql,cnn);
                    read = cmd.ExecuteReader();
                    if(read.Read())
                    {
                        MessageBox.Show("Admins are automatically 07:00AM-04:00PM!","Error",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        read.Close();
                        sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtEmployeeID.Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            txtEmployeeName.Text = read.GetValue(3).ToString();
                            txtEmployeeName.Text += read.GetValue(1).ToString();
                            txtEmployeeName.Text += " " + read.GetValue(2).ToString();
                            txtDepartment.Text = read.GetValue(18).ToString();
                            txtPosition.Text = read.GetValue(19).ToString();
                            txtRestday.Text = read.GetValue(16).ToString();
                            enableTxt();
                            enable();
                        }
                    }


                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtRestday.Text=="Monday")
                {
                    if (txtTuesHour.Text==""&&txtTuesIn.Text == "" &&txtTuesOut.Text == "" &&txtWedHour.Text == "" &&txtWedIn.Text == "" &&txtWedOut.Text == "" &&txtThursHour.Text == "" &&txtThursIn.Text == "" &&txtThursOut.Text == "" &&txtFriHour.Text == "" &&txtFriIn.Text == "" &&txtFriOut.Text == "" &&txtSatHour.Text == "" &&txtSatIn.Text == "" &&txtSatOut.Text == "" &&txtSunHour.Text == "" &&txtSunIn.Text == "" &&txtSunOut.Text == "" )
                    {
                        MessageBox.Show("Please fill up all fields!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('"+txtEmployeeID.Text+"','"+txtEmployeeName.Text + "','" + txtRestday.Text + "','" +holder + "','" +holder + "','" +holder + "','" + txtTuesIn.Text + "','" + txtTuesOut.Text + "','" + txtTuesHour.Text + "','" + txtWedIn.Text + "','" + txtWedOut.Text + "','" + txtWedHour.Text + "','" + txtThursIn.Text + "','" + txtThursOut.Text + "','" + txtThursHour.Text + "','" + txtFriIn.Text + "','" +txtFriOut.Text + "','" +txtFriHour.Text + "','" +txtSatIn.Text + "','" +txtSatOut.Text + "','" +txtSatHour.Text + "','" +txtSunIn.Text + "','" +txtSunOut.Text + "','" +txtSunHour.Text+"','"+lbTotalHour.Text+ "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else if(txtRestday.Text == "Tuesday")
                {
                    if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                    {
                        MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtRestday.Text + "','" + txtMonIn.Text + "','" + txtMonOut.Text + "','" + txtMonHour.Text + "','" + holder + "','" + holder + "','" + holder + "','" + txtWedIn.Text + "','" + txtWedOut.Text + "','" + txtWedHour.Text + "','" + txtThursIn.Text + "','" + txtThursOut.Text + "','" + txtThursHour.Text + "','" + txtFriIn.Text + "','" + txtFriOut.Text + "','" + txtFriHour.Text + "','" + txtSatIn.Text + "','" + txtSatOut.Text + "','" + txtSatHour.Text + "','" + txtSunIn.Text + "','" + txtSunOut.Text + "','" + txtSunHour.Text +"','"+lbTotalHour.Text+ "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else if (txtRestday.Text == "Wednesday")
                {
                    if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                    {
                        MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtRestday.Text + "','" + txtMonIn.Text + "','" + txtMonOut.Text + "','" + txtMonHour.Text + "','" + txtTuesIn.Text + "','" + txtTuesOut.Text + "','" + txtTuesHour.Text + "','" + holder+ "','" + holder + "','" + holder + "','" + txtThursIn.Text + "','" + txtThursOut.Text + "','" + txtThursHour.Text + "','" + txtFriIn.Text + "','" + txtFriOut.Text + "','" + txtFriHour.Text + "','" + txtSatIn.Text + "','" + txtSatOut.Text + "','" + txtSatHour.Text + "','" + txtSunIn.Text + "','" + txtSunOut.Text + "','" + txtSunHour.Text + "','" + lbTotalHour.Text + "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else if (txtRestday.Text == "Thursday")
                {
                    if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtFriHour.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                    {
                        MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtRestday.Text + "','" + txtMonIn.Text + "','" + txtMonOut.Text + "','" + txtMonHour.Text + "','" + txtTuesIn.Text + "','" + txtTuesOut.Text + "','" + txtTuesHour.Text + "','" + txtWedIn.Text + "','" + txtWedOut.Text + "','" + txtWedHour.Text + "','" + holder + "','" + holder + "','" + holder+ "','" + txtFriIn.Text + "','" + txtFriOut.Text + "','" + txtFriHour.Text + "','" + txtSatIn.Text + "','" + txtSatOut.Text + "','" + txtSatHour.Text + "','" + txtSunIn.Text + "','" + txtSunOut.Text + "','" + txtSunHour.Text + "','" + lbTotalHour.Text + "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else if (txtRestday.Text == "Friday")
                {
                    if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtSatHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                    {
                        MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtRestday.Text + "','" + txtMonIn.Text + "','" + txtMonOut.Text + "','" + txtMonHour.Text + "','" + txtTuesIn.Text + "','" + txtTuesOut.Text + "','" + txtTuesHour.Text + "','" + txtWedIn.Text + "','" + txtWedOut.Text + "','" + txtWedHour.Text + "','" + txtThursHour.Text + "','" + txtThursOut.Text + "','" + txtThursHour.Text + "','" + holder + "','" + holder + "','" + holder + "','" + txtSatIn.Text + "','" + txtSatOut.Text + "','" + txtSatHour.Text + "','" + txtSunIn.Text + "','" + txtSunOut.Text + "','" + txtSunHour.Text + "','" + lbTotalHour.Text + "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else if (txtRestday.Text == "Saturday")
                {
                    if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtFriHour.Text == "" && txtSunHour.Text == "" && txtSunIn.Text == "" && txtSunOut.Text == "")
                    {
                        MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtRestday.Text + "','" + txtMonIn.Text + "','" + txtMonOut.Text + "','" + txtMonHour.Text + "','" + txtTuesIn.Text + "','" + txtTuesOut.Text + "','" + txtTuesHour.Text + "','" + txtWedIn.Text + "','" + txtWedOut.Text + "','" + txtWedHour.Text + "','" + txtThursHour.Text + "','" + txtThursOut.Text + "','" + txtThursHour.Text + "','" + txtFriIn.Text + "','" + txtFriOut.Text + "','" + txtFriHour.Text + "','" + holder + "','" + holder + "','" + holder + "','" + txtSunIn.Text + "','" + txtSunOut.Text + "','" + txtSunHour.Text + "','" + lbTotalHour.Text + "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else if (txtRestday.Text == "Sunday")
                {
                    if (txtMonIn.Text == "" && txtMonOut.Text == "" && txtMonHour.Text == "" && txtTuesIn.Text == "" && txtTuesOut.Text == "" && txtTuesHour.Text == "" && txtWedHour.Text == "" && txtWedIn.Text == "" && txtWedOut.Text == "" && txtThursHour.Text == "" && txtThursIn.Text == "" && txtThursOut.Text == "" && txtFriIn.Text == "" && txtFriOut.Text == "" && txtFriHour.Text == "" && txtSatIn.Text == "" && txtSatOut.Text == "" && txtSatHour.Text == "")
                    {
                        MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        holder = "RESTDAY";
                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour,total) VALUES('" + txtEmployeeID.Text + "','" + txtEmployeeName.Text + "','" + txtRestday.Text + "','" + txtMonIn.Text + "','" + txtMonOut.Text + "','" + txtMonHour.Text + "','" + txtTuesIn.Text + "','" + txtTuesOut.Text + "','" + txtTuesHour.Text + "','" + txtWedIn.Text + "','" + txtWedOut.Text + "','" + txtWedHour.Text + "','" + txtThursHour.Text + "','" + txtThursOut.Text + "','" + txtThursHour.Text + "','" + txtFriIn.Text + "','" + txtFriOut.Text + "','" + txtFriHour.Text + "','" + txtSatIn.Text + "','" + txtSatOut.Text + "','" + txtSatHour.Text + "','" + holder + "','" + holder + "','" + holder + "','" + lbTotalHour.Text + "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Summary of loads successfully save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        disable();
                        disableTxt();
                    }
                }
                else
                {
                    MessageBox.Show("s.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
        }

        private void txtMonIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMonIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private void frmSummaryOfLoads_Load(object sender, EventArgs e)
        {
            disableTxt();
            disable();
        }

        private void txtMonHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMonHour.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtTuesIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTuesIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtWedIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtWedIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtThursIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtThursIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtFriIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFriIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtSatIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSatIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtSunIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSunIn.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtMonOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMonOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtTuesOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTuesOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtWedOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtWedOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtTuesIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtTuesIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtWedIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtWedIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtThursIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtThursIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtFriIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtFriIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtSatIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtSatIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtSunIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtSunIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtMonOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtMonOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtTuesOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtTuesOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtWedOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtWedOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtThursOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtThursOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtFriOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtFriOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtSatOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtSatOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtSunOut_Validating(object sender, CancelEventArgs e)
        {
            if (txtSunOut.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }

        private void txtMonHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                mnday = Convert.ToDouble(box.Text);
            }
            else
            {
                mnday = 0;
            }
        }

        private void txtTuesHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                tuesday = Convert.ToDouble(box.Text);
            }
            else
            {
                tuesday = 0;
            }
        }

        private void txtWedHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                wed=  Convert.ToDouble(box.Text);
            }
            else
            {
                wed= 0;
            }
        }

        private void txtThursHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                thurs = Convert.ToDouble(box.Text);
            }
            else
            {
                thurs = 0;
            }
        }

        private void txtFriHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                fri = Convert.ToDouble(box.Text);
            }
            else
            {
                fri = 0;
            }
        }

        private void txtSatHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                sat = Convert.ToDouble(box.Text);
            }
            else
            {
                sat = 0;
            }
        }

        private void txtSunHour_TextChanged(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            holder = box.Text;
            if (box.Text != "")
            {
                sun = Convert.ToDouble(box.Text);
            }
            else
            {
                sun = 0;
            }
        }

        private void frmSummaryOfLoads_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMonHour_Leave(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double resultss = Convert.ToDouble(mnday) + Convert.ToDouble(tuesday) + Convert.ToDouble(wed) + Convert.ToDouble(thurs) + Convert.ToDouble(fri) + Convert.ToDouble(sat) + Convert.ToDouble(sun);
            lbTotalHour.Text = resultss.ToString();
        }

        private void txtMonHour_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Start();
        }

        private void txtMonHour_KeyUp_1(object sender, KeyEventArgs e)
        {
            timer1.Start();
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnFind.PerformClick();
            }
        }

        private void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtThursOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtThursOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtFriOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFriOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtSatOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSatOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtSunOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSunOut.Text != "")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                TextBox box = sender as TextBox;
                string holder = box.Text;

                if (box.TextLength == 2)
                {
                    if (box.TextLength == 2 && !!char.IsDigit(e.KeyChar))
                    {
                        box.Text += ":";
                        box.SelectionStart = box.Text.Length;
                        box.SelectionLength = 0;
                    }
                }
                else if (box.TextLength >= 5)
                {
                    e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        
        private void txtMonHour_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtMonIn_Validating(object sender, CancelEventArgs e)
        {
            if (txtMonIn.Text != "")
            {
                TextBox box = sender as TextBox;
                string pattern = "\\d{1,2}:\\d{2}\\s*(AM|PM|am|pm)";
                string result = box.Text.Substring(0, 2);
                string results = box.Text.Substring(3, 2);
                int a = Convert.ToInt32(result);
                int aa = Convert.ToInt32(results);
                if (box != null)
                {
                    if (a > 12)
                    {
                        MessageBox.Show("Not a valid 12 hour format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 2;
                    }
                    else if (aa > 59)
                    {
                        MessageBox.Show("Not a valid 60 minutes format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus(); box.SelectionStart = 4;
                    }
                    else if (box.TextLength <= 5)
                    {
                        MessageBox.Show("Please input time period(AM/PM).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        box.Focus();
                    }
                    else if (!Regex.IsMatch(box.Text, pattern, RegexOptions.CultureInvariant))
                    {
                        MessageBox.Show("Not a valid time format ('hh:mm AM|PM').", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        box.Select(0, box.Text.Length);
                        box.Focus();
                    }
                }
            }
        }
    }
}
