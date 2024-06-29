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
using System.IO;
using System.Globalization;
using System.Timers;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace PMSv3._0
{
    public partial class frmPayroll : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader read;
        string sql = "";
        int ew = 0;
        double x = 0;
        double z = 0;
        double y = 0;
        double c = 0;
        double a = 0;
        double b = 0;
        double w = 0;
        double d = 0;
        frmLogin login = new frmLogin();
        public frmPayroll()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }
        private void unable()
        {

            //txtCashAdvance.Enabled = false;
            txtFname.Enabled = false;
            txtGP.Enabled = false;
            txtHoursWork.Enabled = false;
            txtLeave.Enabled = false;
            txtDepartment.Enabled = false;
            txtNP.Enabled = false;
            txtPagIbig.Enabled = false;
            txtPhilHealth.Enabled = false;
            txtDailyRate.Enabled = false;
            txtRate.Enabled = false;
            txtSSS.Enabled = false;
            txtStatus.Enabled = false;
            txtTAX.Enabled = false;
            txtTotalDeduc.Enabled = false;
            txtWorkDays.Enabled = false;


        }
        private void enable()
        {

            //txtCashAdvance.Enabled = true;
            txtFname.Enabled = true;
            txtGP.Enabled = true;
            txtHoursWork.Enabled = true;
            txtLeave.Enabled = true;
            txtDepartment.Enabled = true;
            txtNP.Enabled = true;
            txtPagIbig.Enabled = true;
            txtPhilHealth.Enabled = true;
            txtDailyRate.Enabled = true;
            txtRate.Enabled = true;
            txtSSS.Enabled = true;
            txtStatus.Enabled = true;
            txtTAX.Enabled = true;
            txtTotalDeduc.Enabled = true;
            txtWorkDays.Enabled = true;
        }
        private void clear()
        {

            //txtCashAdvance.Clear();
            txtFname.Clear();
            txtGP.Clear();
            txtHoursWork.Clear();
            txtLeave.Clear();
            txtDepartment.Clear();
            txtNP.Clear();
            txtPagIbig.Clear();
            txtPhilHealth.Clear();
            txtDailyRate.Clear();
            txtRate.Clear();
            txtSSS.Clear();
            txtStatus.Clear();
            txtTAX.Clear();
            txtTotalDeduc.Clear();
            txtWorkDays.Clear();
            txtEmployeeID.Clear();
            txtSSSLoan.Clear();
            txtPagibigLoan.Clear();
            pbEmployeePic.Image = null;
        }
            private void frmPayroll_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            z = Convert.ToDouble(txtGP.Text);
            x = Convert.ToDouble(txtSSS.Text);
            y = Convert.ToDouble(txtPhilHealth.Text);
            w = Convert.ToDouble(txtPagIbig.Text);
            a = Convert.ToDouble(txtTAX.Text);

            
            if (txtSSSLoan.Text != "")
            {
                c = Convert.ToDouble(txtSSSLoan.Text);
            }
            if (txtPagibigLoan.Text != "")
            {
                d = Convert.ToDouble(txtPagibigLoan.Text);
            }

            z = z - x;
            z = z - y;
            z = z - w;
            z = z - a;
            z = z - b;
            z = z - c;
            z = z - d;
            txtNP.Text = z.ToString();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_Payroll WHERE EmployeeID like'" + txtEmployeeID.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    DateTime dt = DateTime.Parse(read.GetValue(20).ToString());
                    if (dt.Day >= 1 && dt.Day <= 15)
                    {
                        if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 15)
                        {
                            MessageBox.Show("Payroll has been already process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (txtNP.Text != "")
                            {//insert from tb payroll
                                read.Close();
                                sql = "INSERT INTO tb_Payroll(EmployeeID,Name,Department,BasicRate,Status,DaysWorked,HoursWorked,DailyRate,LeaveTotal,SSS,Pagibig,Philhealth,WithholdingTax,Total,SSSLoan,PagibigPayable,GrossPay,NetPay,Date) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + txtDepartment.Text + "','" + txtRate.Text + "','" + txtStatus.Text + "','" + txtWorkDays.Text + "','" + txtHoursWork.Text + "','" + txtDailyRate.Text + "','" + txtLeave.Text + "','" + txtSSS.Text + "','" + txtPagIbig.Text + "','" + txtPhilHealth.Text + "','" + txtTAX.Text + "','" + txtTotalDeduc.Text + "','" + txtSSSLoan.Text + "','" + txtPagibigLoan.Text + "','" + txtGP.Text + "','" + txtNP.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Payroll Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Dispose();
                                string type = "";
                                {//updating loan
                                    if (txtSSSLoan.Text != "")
                                    {
                                        type = "SSS LOAN";
                                        sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                        cmd = new SqlCommand(sql, cnn);
                                        read = cmd.ExecuteReader();
                                        if (read.Read())
                                        {
                                            x = Convert.ToDouble(read.GetValue(3));
                                            y = Convert.ToDouble(txtSSSLoan.Text);
                                            z = x - y;
                                            {// Update loans
                                                read.Close();
                                                sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                                cmd = new SqlCommand(sql, cnn);
                                                cmd.ExecuteNonQuery();
                                                cmd.Dispose();
                                            }
                                        }
                                        read.Close();
                                    }
                                    if (txtPagibigLoan.Text != "")
                                    {
                                        type = "PAGIBIG LOAN";
                                        sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                        cmd = new SqlCommand(sql, cnn);
                                        read = cmd.ExecuteReader();
                                        if (read.Read())
                                        {
                                            x = Convert.ToDouble(read.GetValue(3));
                                            y = Convert.ToDouble(txtPagibigLoan.Text);
                                            z = x - y;
                                            {// Update loans
                                                read.Close();
                                                sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                                cmd = new SqlCommand(sql, cnn);
                                                cmd.ExecuteNonQuery();
                                                cmd.Dispose();
                                            }
                                        }
                                        read.Close();
                                    }
                                    //    if (txtCashAdvance.Text != "")
                                    //    {
                                    //        type = "CASH ADVANCE";
                                    //        sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                    //        cmd = new SqlCommand(sql, cnn);
                                    //        read = cmd.ExecuteReader();
                                    //        if (read.Read())
                                    //        {
                                    //            x = Convert.ToDouble(read.GetValue(3));
                                    //            y = Convert.ToDouble(txtCashAdvance.Text);
                                    //            z = x - y;
                                    //            {// Update loans
                                    //                read.Close();
                                    //                sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                    //                cmd = new SqlCommand(sql, cnn);
                                    //                cmd.ExecuteNonQuery();
                                    //                cmd.Dispose();
                                    //            }
                                    //        }
                                    //        read.Close();
                                    //    }
                                    //    read.Close();
                                    //}
                                    {// Deleting loan
                                        int amount = 0;
                                        {
                                            sql = "DELETE FROM tb_Loan WHERE loanAmount like '" + amount + "' and employeeID like'" + txtEmployeeID.Text + "'";
                                            cmd = new SqlCommand(sql, cnn);
                                            cmd.ExecuteNonQuery();
                                            cmd.Dispose();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please compute payroll first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (dt.Day >= 16 && dt.Day <= 31)
                    {

                        if (DateTime.Now.Day >= 16 && DateTime.Now.Day <= 31)
                        {
                            MessageBox.Show("Payroll has been already process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (txtNP.Text != "")
                            {
                                read.Close();
                                sql = "INSERT INTO tb_Payroll(EmployeeID,Name,Department,BasicRate,Status,DaysWorked,HoursWorked,DailyRate,LeaveTotal,SSS,Pagibig,Philhealth,WithholdingTax,Total,SSSLoan,PagibigPayable,GrossPay,NetPay,Date) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + txtDepartment.Text + "','" + txtRate.Text + "','" + txtStatus.Text + "','" + txtWorkDays.Text + "','" + txtHoursWork.Text + "','" + txtDailyRate.Text + "','" + txtLeave.Text + "','" + txtSSS.Text + "','" + txtPagIbig.Text + "','" + txtPhilHealth.Text + "','" + txtTAX.Text + "','" + txtTotalDeduc.Text + "','" + txtSSSLoan.Text + "','" + txtPagibigLoan.Text + "','" + "','" + txtGP.Text + "','" + txtNP.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Payroll Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Dispose();
                                string type = "";
                                {//updating loan
                                    if (txtSSSLoan.Text != "")
                                    {
                                        type = "SSS LOAN";
                                        sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                        cmd = new SqlCommand(sql, cnn);
                                        read = cmd.ExecuteReader();
                                        if (read.Read())
                                        {
                                            x = Convert.ToDouble(read.GetValue(3));
                                            y = Convert.ToDouble(txtSSSLoan.Text);
                                            z = x - y;
                                            {// Update loans
                                                read.Close();
                                                sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                                cmd = new SqlCommand(sql, cnn);
                                                cmd.ExecuteNonQuery();
                                                cmd.Dispose();
                                            }
                                        }
                                        read.Close();
                                    }
                                    if (txtPagibigLoan.Text != "")
                                    {
                                        type = "PAGIBIG LOAN";
                                        sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                        cmd = new SqlCommand(sql, cnn);
                                        read = cmd.ExecuteReader();
                                        if (read.Read())
                                        {
                                            x = Convert.ToDouble(read.GetValue(3));
                                            y = Convert.ToDouble(txtPagibigLoan.Text);
                                            z = x - y;
                                            {// Update loans
                                                read.Close();
                                                sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                                cmd = new SqlCommand(sql, cnn);
                                                cmd.ExecuteNonQuery();
                                                cmd.Dispose();
                                            }
                                        }
                                        read.Close();
                                    }
                                    //    if (txtCashAdvance.Text != "")
                                    //    {
                                    //        type = "CASH ADVANCE";
                                    //        sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                    //        cmd = new SqlCommand(sql, cnn);
                                    //        read = cmd.ExecuteReader();
                                    //        if (read.Read())
                                    //        {
                                    //            x = Convert.ToDouble(read.GetValue(3));
                                    //            y = Convert.ToDouble(txtCashAdvance.Text);
                                    //            z = x - y;
                                    //            {// Update loans
                                    //                read.Close();
                                    //                sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                    //                cmd = new SqlCommand(sql, cnn);
                                    //                cmd.ExecuteNonQuery();
                                    //                cmd.Dispose();
                                    //            }
                                    //        }
                                    //        read.Close();
                                    //    }
                                    //    read.Close();
                                    //}
                                    {// Deleting loan
                                        int amount = 0;
                                        {
                                            sql = "DELETE FROM tb_Loan WHERE loanAmount like '" + amount + "' and employeeID like'" + txtEmployeeID.Text + "'";
                                            cmd = new SqlCommand(sql, cnn);
                                            cmd.ExecuteNonQuery();
                                            cmd.Dispose();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please compute payroll first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
                else
                {

                    if (txtNP.Text != "")
                    {
                        read.Close();
                        sql = "INSERT INTO tb_Payroll(EmployeeID,Name,Department,BasicRate,Status,DaysWorked,HoursWorked,DailyRate,LeaveTotal,SSS,Pagibig,Philhealth,WithholdingTax,Total,SSSLoan,PagibigPayable,GrossPay,NetPay,Date) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + txtDepartment.Text + "','" + txtRate.Text + "','" + txtStatus.Text + "','" + txtWorkDays.Text + "','" + txtHoursWork.Text + "','" + txtDailyRate.Text + "','" + txtLeave.Text + "','" + txtSSS.Text + "','" + txtPagIbig.Text + "','" + txtPhilHealth.Text + "','" + txtTAX.Text + "','" + txtTotalDeduc.Text + "','" + txtSSSLoan.Text + "','" + txtPagibigLoan.Text  + "','" + txtGP.Text + "','" + txtNP.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy") + "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Payroll Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmd.Dispose();
                        string type = "";
                        {//updating loan
                            if (txtSSSLoan.Text != "")
                            {
                                type = "SSS LOAN";
                                sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                cmd = new SqlCommand(sql, cnn);
                                read = cmd.ExecuteReader();
                                if (read.Read())
                                {
                                    x = Convert.ToDouble(read.GetValue(3));
                                    y = Convert.ToDouble(txtSSSLoan.Text);
                                    z = x - y;
                                    {// Update loans
                                        read.Close();
                                        sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();


                                    }
                                }
                                read.Close();
                            }
                            if (txtPagibigLoan.Text != "")
                            {
                                type = "PAGIBIG LOAN";
                                sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                cmd = new SqlCommand(sql, cnn);
                                read = cmd.ExecuteReader();
                                if (read.Read())
                                {
                                    x = Convert.ToDouble(read.GetValue(3));
                                    y = Convert.ToDouble(txtPagibigLoan.Text);
                                    z = x - y;
                                    {// Update loans
                                        read.Close();
                                        sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();


                                    }
                                }
                                read.Close();
                            }
                            //if (txtCashAdvance.Text != "")
                            //{
                            //    type = "CASH ADVANCE";
                            //    sql = "SELECT * FROM tb_Loan WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                            //    cmd = new SqlCommand(sql, cnn);
                            //    read = cmd.ExecuteReader();
                            //    if (read.Read())
                            //    {
                            //        x = Convert.ToDouble(read.GetValue(3));
                            //        y = Convert.ToDouble(txtCashAdvance.Text);
                            //        z = x - y;
                            //        {// Update loans
                            //            read.Close();
                            //            sql = "UPDATE tb_Loan SET loanAmount='" + z + "' WHERE employeeID like'" + txtEmployeeID.Text + "' AND loanType like'" + type + "'";
                            //            cmd = new SqlCommand(sql, cnn);
                            //            cmd.ExecuteNonQuery();
                            //            cmd.Dispose();


                            //        }
                            //    } 
                            //    read.Close();



                            //}
                            read.Close();
                        }
                        {// Deleting loan
                            int amount = 0;
                            {
                                sql = "DELETE FROM tb_Loan WHERE loanAmount like '" + amount + "' and employeeID like'" + txtEmployeeID.Text + "'";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                            }



                        }
                        read.Close();


                    }


                    else
                    {
                        MessageBox.Show("Please compute payroll first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                read.Close();
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR!" + ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            unable();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFname.Text == "")
            {
                {// Get info emp
                    try
                    {
                        sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtEmployeeID.Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        read.Read();
                        if (read.HasRows)
                        {
                            txtFname.Text = read.GetValue(1).ToString(); ;
                            txtDepartment.Text = read[15].ToString();
                            txtStatus.Text = read[18].ToString();
                            txtRate.Text = read[11].ToString();
                            byte[] photo = (byte[])(read[14]);
                            MemoryStream ms = new MemoryStream(photo);
                            Bitmap bm = new Bitmap(ms);
                            pbEmployeePic.Image = bm;

                            {// Get work Infoooo
                                read.Close();
                                { //Hours work
                                    if (DateTime.Now.Day <= 15d && DateTime.Now.Day >= 1)
                                    {
                                        try
                                        {
                                            sql = "SELECT * FROM tb_Attendance WHERE EmployeeID like'" + txtEmployeeID.Text + "' AND MONTH(Date) like '" + DateTime.Now.Month + "' AND YEAR(Date) like '" + DateTime.Now.Year + "' ";
                                            cmd = new SqlCommand(sql, cnn);
                                            read = cmd.ExecuteReader();

                                            while (read.Read())
                                            {
                                                DateTime xs = DateTime.Parse(read.GetValue(1).ToString());

                                                if (xs.Day <= 15 && xs.Day >= 1)
                                                {
                                                    ew = ew + Convert.ToInt32(read.GetValue(1).ToString());
                                                    txtHoursWork.Text = ew.ToString();

                                                }
                                            }

                                            read.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error" + ex);
                                        }
                                    }
                                    else if (DateTime.Now.Day <= 31 && DateTime.Now.Day >= 16)
                                    {
                                        try
                                        {
                                            ew = 0;
                                            sql = "SELECT * FROM tb_Attendance WHERE EmployeeID like'" + txtEmployeeID.Text + "' AND MONTH(Date) like '" + DateTime.Now.Month + "' AND YEAR(Date) like '" + DateTime.Now.Year + "' ";
                                            cmd = new SqlCommand(sql, cnn);
                                            read = cmd.ExecuteReader();

                                            while (read.Read())
                                            {
                                                DateTime xs = DateTime.Parse(read.GetValue(1).ToString());
                                                if (xs.Day >= 16 && xs.Day <= 31)
                                                {
                                                    ew = ew + Convert.ToInt32(read.GetValue(4).ToString());
                                                    txtHoursWork.Text = ew.ToString();
                                                }
                                            }
                                            if (txtWorkDays.Text == "")
                                            {
                                                txtWorkDays.Text = 0.ToString();
                                            }
                                            read.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error" + ex);
                                        }
                                    }
                                }

                                {// Days work

                                    if (DateTime.Now.Day <= 15d && DateTime.Now.Day >= 1)
                                    {
                                        try
                                        {
                                            ew = 0;
                                            sql = "SELECT * FROM tb_Attendance WHERE EmployeeID like'" + txtEmployeeID.Text + "' AND MONTH(Date) like '" + DateTime.Now.Month + "' AND YEAR(Date) like '" + DateTime.Now.Year + "' ";
                                            cmd = new SqlCommand(sql, cnn);
                                            read = cmd.ExecuteReader();

                                            while (read.Read())
                                            {
                                                DateTime xs = DateTime.Parse(read.GetValue(1).ToString());

                                                if (xs.Day <= 15 && xs.Day >= 1)
                                                {


                                                    ew++;
                                                    txtWorkDays.Text = ew.ToString();
                                                }
                                            }
                                            if (txtWorkDays.Text == "")
                                            {
                                                txtWorkDays.Text = 0.ToString();
                                            }

                                            read.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error" + ex);
                                        }
                                    }
                                    else if (DateTime.Now.Day <= 31 && DateTime.Now.Day >= 16)
                                    {
                                        try
                                        {
                                            ew = 0;
                                            sql = "SELECT * FROM tb_Attendance WHERE EmployeeID like'" + txtEmployeeID.Text + "' AND MONTH(Date) like '" + DateTime.Now.Month + "' AND YEAR(Date) like '" + DateTime.Now.Year + "' ";
                                            cmd = new SqlCommand(sql, cnn);
                                            read = cmd.ExecuteReader();

                                            while (read.Read())
                                            {
                                                DateTime xs = DateTime.Parse(read.GetValue(1).ToString());

                                                if (xs.Day >= 16 && xs.Day <= 31)
                                                {


                                                    ew++;
                                                    txtWorkDays.Text = ew.ToString();
                                                }
                                            }
                                            if (txtWorkDays.Text == "")
                                            {
                                                txtWorkDays.Text = 0.ToString();
                                            }

                                            read.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error" + ex);
                                        }

                                    }

                                }
                            }

                            //{// Get remaining leave

                            //    sql = " SELECT * FROM tb_RemainingLeaves WHERE employeeID like'" + txtEmployeeID.Text + "'";
                            //    cmd = new SqlCommand(sql, cnn);
                            //    read = cmd.ExecuteReader();
                            //    if (read.Read())
                            //    {
                            //        txtLeave.Text = read.GetValue(2).ToString();
                            //    }
                            //    read.Close();

                            //}
                            // {// Get cash advance

                            //    sql = " SELECT * FROM tb_CashAdvance WHERE employeeID like'" + txtEmployeeID.Text + "'";
                            //    cmd = new SqlCommand(sql, cnn);
                            //    read = cmd.ExecuteReader();
                            //    if (read.Read())
                            //    {
                            //        txtCashAdvance.Text = read.GetValue(2).ToString();
                            //    }
                            //    read.Close();


                            //}

                            sql = "SELECT * FROM tb_RegisterEmployee WHERE EmployeeID like'" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            if (read.Read())
                            {

                                {// Daily Rate
                                    if (txtDepartment.Text == "Teachers")
                                    {
                                        x = Convert.ToDouble(txtRate.Text);
                                        z = (x * 12) / 313;
                                        txtDailyRate.Text = z.ToString("F");
                                    }
                                    else
                                    {
                                        x = Convert.ToDouble(txtRate.Text);
                                        z = (x * 12) / 288;
                                        txtDailyRate.Text = z.ToString("F");
                                    }
                                }
                                {// Gross pay
                                    x = 0;
                                    z = 0;
                                    y = 0;

                                    x = Convert.ToDouble(txtDailyRate.Text);
                                    z = Convert.ToDouble(txtWorkDays.Text);
                                    y = x * z;
                                    txtGP.Text = y.ToString("F");
                                }
                                read.Close();
                            }

                            {// Compute total deductions


                                if (DateTime.Now.Day >= 30)
                                {     //Pagibig
                                  
                                    read.Close();
                                    //PhilHealth
                                    sql = "SELECT * FROM tb_PhilHealth";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    while (read.Read())
                                    {
                                        if (Convert.ToDouble(read.GetValue(1)) <= x && Convert.ToDouble(read.GetValue(2)) >= x)
                                        {
                                            txtPhilHealth.Text = Convert.ToDouble(read.GetValue(6)).ToString();
                                        }
                                        else if (Convert.ToDouble(read.GetValue(1)) <= x && Convert.ToDouble(read.GetValue(2)) <= x)
                                        {
                                            txtPhilHealth.Text = Convert.ToDouble(read.GetValue(6)).ToString();
                                        }

                                    }
                                }
                                else
                                {
                                    txtSSS.Text = "0";
                                    txtPhilHealth.Text = "0";
                                    txtPagIbig.Text = "0";
                                }
                                {//Compute tax

                                    x = Convert.ToDouble(txtGP.Text);
                                    if (x <= 10416)
                                    {
                                        txtTAX.Text = "0";
                                    }
                                    else if (x >= 10417 && x <= 16666)
                                    {
                                        txtTAX.Text = (x * .20).ToString();
                                    }
                                    else if (x >= 16667 && x <= 33332)
                                    {
                                        txtTAX.Text = ((x * .25) + 1250).ToString();
                                    }
                                    else if (x >= 33333 && x <= 83331)
                                    {
                                        txtTAX.Text = ((x * .30) + 5416.67).ToString();

                                    }
                                    else if (x >= 83332 && x <= 333332)
                                    {
                                        txtTAX.Text = ((x * .32) + 20416.67).ToString();
                                    }
                                    else if (x >= 333333)
                                    {
                                        txtTAX.Text = ((x * .35) + 100416.67).ToString();
                                    }

                                }
                                {
                                    //total deduction
                                    z = Convert.ToDouble(txtSSS.Text);
                                    y = Convert.ToDouble(txtPagIbig.Text);
                                    x = Convert.ToDouble(txtPhilHealth.Text);
                                    a = Convert.ToDouble(txtTAX.Text);

                                    txtTotalDeduc.Text = (z + y + x + a).ToString();

                                }

                            }

                            {// Get loans
                                read.Close();
                                string type = "";
                                {//SSS Loan
                                    type = "SSS LOAN";
                                    sql = "SELECT * FROM tb_Loan WHERE loanType like'" + type + "' AND employeeID like '" + txtEmployeeID.Text + "'";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        txtSSSLoan.Text = read.GetValue(4).ToString();
                                    }
                                    else
                                    {
                                        txtSSSLoan.Text = "0";
                                    }
                                    read.Close();
                                }
                                {//PAGIBIG loan

                                    type = "PAGIBIG LOAN";
                                    sql = "SELECT * FROM tb_Loan WHERE loanType like'" + type + "' AND employeeID like '" + txtEmployeeID.Text + "'";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        txtPagibigLoan.Text = read.GetValue(4).ToString();
                                    }
                                    else
                                    {
                                        txtPagibigLoan.Text = "0";
                                    }
                                    read.Close();
                                }
                                {// Cash Advance
                                    type = "CASH ADVANCE";
                                    sql = "SELECT * FROM tb_Loan WHERE loanType like'" + type + "' AND employeeID like '" + txtEmployeeID.Text + "'";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                          //              txtCashAdvance.Text = read.GetValue(4).ToString();
                                    }
                                    else
                                    {
                            //            txtCashAdvance.Text = "0";
                                    }
                                    read.Close();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Employee record does not exist! Please input employee ID correctly. Thank you", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex);
                    }
                }
                read.Close();
            }
            else
            {
                MessageBox.Show("Please clear employee first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtDailyRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && Regex.IsMatch(txtDailyRate.Text, @"\.\d\d") && String.IsNullOrWhiteSpace(txtDailyRate.SelectedText))
            {
                e.Handled = true;
            }

        }
        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnFind.PerformClick();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
