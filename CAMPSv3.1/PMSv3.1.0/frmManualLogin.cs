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
    public partial class frmManualLogin : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader reader;
        string sql = "";
        frmLogin login = new frmLogin();
        string yes = "Not";
        string no = "Done";
        string timein="", timeout="", total = "";
        double deduction = 0;
        public frmManualLogin()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();      
        }

        private void frmManualLogin_Load(object sender, EventArgs e)
        {
            View1();
            View();
            timer1.Enabled = true;
        }

        private void btnTimeIn_Click(object sender, EventArgs e)
        {
            try
            {
                sql = " SELECT * FROM tb_Attendance WHERE EmployeeID like '" + lEmployeeID.Text + "' AND Date like'" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                 MessageBox.Show("You have time in already.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lEmployeeID.Text + "'";
                    cmd = new SqlCommand(sql, cnn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime end = DateTime.Now;
                        string date = end.ToString("hh:mm tt");
                        string rd = reader.GetValue(4).ToString();
                        string day = DateTime.Now.DayOfWeek.ToString();

                        if (rd == day)
                        {
                            DialogResult yesss = MessageBox.Show("It's your restday, are you sure you want to time in?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (yesss == DialogResult.Yes)
                            {
                                reader.Close();
                                sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,status,InTime,Adjustment) VALUES('" + DateTime.Now.Date.ToString("MM/dd/yy") + "','" + day + "','" + lEmployeeID.Text + "','" + lLastname.Text + "','" + yes + "','" + DateTime.Now.ToString("hh:mm tt") + "','None')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Please submit adjusment letter to admin. Thankyou", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("TIme In successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                View();
                            }
                        }
                        else
                        {
                            if (day == "Monday")
                            {
                                timein = reader.GetValue(5).ToString();
                                timeout = reader.GetValue(6).ToString();
                                total = reader.GetValue(7).ToString();
                                day = "Monday";

                            }
                            else if (day == "Tuesday")
                            {
                                timein = reader.GetValue(8).ToString();
                                timeout = reader.GetValue(9).ToString();
                                total = reader.GetValue(10).ToString();
                                day = "Tuesday";

                            }
                            else if (day == "Wednesday")
                            {
                                timein = reader.GetValue(11).ToString();
                                timeout = reader.GetValue(12).ToString();
                                total = reader.GetValue(13).ToString();
                                day = "Wednesday";

                            }
                            else if (day == "Thursday")
                            {
                                timein = reader.GetValue(14).ToString();
                                timeout = reader.GetValue(15).ToString();
                                total = reader.GetValue(16).ToString();
                                day = "Thursday";

                            }
                            else if (day == "Friday")
                            {
                                timein = reader.GetValue(17).ToString();
                                timeout = reader.GetValue(18).ToString();
                                total = reader.GetValue(19).ToString();
                                day = "Friday";

                            }
                            else if (day == "Saturday")
                            {
                                timein = reader.GetValue(20).ToString();
                                timeout = reader.GetValue(21).ToString();
                                total = reader.GetValue(22).ToString();
                                day = "Saturday";
                            }
                            else if (day == "Sunday")
                            {
                                timein = reader.GetValue(23).ToString();
                                timeout = reader.GetValue(24).ToString();
                                total = reader.GetValue(25).ToString();
                                day = "Sunday";

                            }
                            TimeSpan span = Convert.ToDateTime(date.ToString()) - Convert.ToDateTime(timein.ToString());
                            DateTime ddd = Convert.ToDateTime(timein);

                            double z = span.TotalMinutes / 60;


                            if (Convert.ToDateTime(date) <= ddd)
                            {
                                reader.Close();
                                sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,status,InTime,late,Undertime,totalDeduction,Adjustment) VALUES('" + DateTime.Now.Date.ToString("MM/dd/yy") + "','" + day + "','" + lEmployeeID.Text + "','" + lLastname.Text + "','" + yes + "','" + DateTime.Now.ToString("hh:mm tt") + "','0','0','0','None')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("TIme In successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                View();
                            }
                            else if (Convert.ToDateTime(date) > Convert.ToDateTime(timein.ToString()))
                            {
                                reader.Close();
                                if (span.TotalMinutes <= 15)
                                {
                                    {//
                                        reader.Close();
                                        sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,status,InTime,late,Undertime,totalDeduction,Adjustment) VALUES('" + DateTime.Now.Date.ToString("MM/dd/yy") + "','" + day + "','" + lEmployeeID.Text + "','" + lLastname.Text + "','" + yes + "','" + DateTime.Now.ToString("hh:mm tt") + "','0','0','0','None')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("TIme  successfully Saved!", "PMS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    if (Convert.ToDateTime(date) > Convert.ToDateTime(timeout.ToString()))
                                    {
                                        string absent = "Absent";
                                        MessageBox.Show("This emplpoyee missed its schedule. ");
                                        reader.Close();
                                        sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,status,totalDeduction,WorkingTime,late,Undertime,Adjustment,InTime,OutTime) VALUES('" + DateTime.Now.Date.ToString("MM/dd/yy") +"','"+day+ "','" + lEmployeeID.Text + "','" + lLastname.Text + "','" + absent + "','" + total + "','0','0','0','None','00:00','00:00')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (span.TotalMinutes > 15)
                                    {
                                        MessageBox.Show("This employee is late to its schedule. Deductions will be impose!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        {
                                            reader.Close();
                                            sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,status,InTime,late,totalDeduction,Adjustment) VALUES('" + DateTime.Now.Date.ToString("MM/dd/yy") + "','" + day + "','" + lEmployeeID.Text + "','" + lLastname.Text + "','" + yes + "','" + DateTime.Now.ToString("hh:mm tt") + "','" + z.ToString("##.##") + "','" + deduction.ToString("##.##") + "','None')";
                                            cmd = new SqlCommand(sql, cnn);
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                                View();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You do not have summary of loads! Please submit your summary of loads first to the admin. Thank you!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex);
            }
        }

        private void btnTimeOut_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_Attendance WHERE EmployeeID like'" + lEmployeeID.Text + "' AND Status like'"+yes+"'";
                cmd = new SqlCommand(sql, cnn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    TimeSpan sx =  Convert.ToDateTime(DateTime.Now.ToString("hh:mm tt")) - Convert.ToDateTime(reader.GetValue(7).ToString());
                    double z = sx.TotalMinutes / 60;
                    lbsubID.Text = reader.GetValue(0).ToString();
                    reader.Close();
                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lEmployeeID.Text + "'";
                    cmd = new SqlCommand(sql, cnn);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        DateTime end = DateTime.Now;
                        string date = end.ToString("hh:mm tt");
                        string rd = reader.GetValue(4).ToString();
                        string day = DateTime.Now.DayOfWeek.ToString();
                        if (rd == day)
                        {
                            
                                double totalTime = Convert.ToDouble(total);
                                reader.Close();
                                sql = "UPDATE tb_Attendance SET OutTime='" + DateTime.Now.ToString("hh:mm tt") + "', Status ='" + no + "', WorkingTime='" + z.ToString("##.##") + "',totalDeduction='0',late='0',Undertime='0' WHERE attID like'" + lbsubID.Text + "' AND Status='Not'";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("TIme out successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                View();
                            
                        }
                        else
                        {
                            if (day == "Monday")
                            {
                                timein = reader.GetValue(5).ToString();
                                timeout = reader.GetValue(6).ToString();
                                total = reader.GetValue(7).ToString();
                            }
                            else if (day == "Tuesday")
                            {
                                timein = reader.GetValue(8).ToString();
                                timeout = reader.GetValue(9).ToString();
                                total = reader.GetValue(10).ToString();
                            }
                            else if (day == "Wednesday")
                            {
                                timein = reader.GetValue(11).ToString();
                                timeout = reader.GetValue(12).ToString();
                                total = reader.GetValue(13).ToString();
                            }
                            else if (day == "Thursday")
                            {
                                timein = reader.GetValue(14).ToString();
                                timeout = reader.GetValue(15).ToString();
                                total = reader.GetValue(16).ToString();
                            }
                            else if (day == "Friday")
                            {
                                timein = reader.GetValue(17).ToString();
                                timeout = reader.GetValue(18).ToString();
                                total = reader.GetValue(19).ToString();
                            }
                            else if (day == "Saturday")
                            {
                                timein = reader.GetValue(20).ToString();
                                timeout = reader.GetValue(21).ToString();
                                total = reader.GetValue(22).ToString();
                            }
                            else if (day == "Sunday")
                            {
                                timein = reader.GetValue(23).ToString();
                                timeout = reader.GetValue(24).ToString();
                                total = reader.GetValue(25).ToString();
                            }
                            reader.Close();
                            sql = "SELECT * FROM tb_Attendance Where EmployeeID like '" + lEmployeeID.Text + "' AND Status='Not' ";
                            cmd = new SqlCommand(sql, cnn);
                            reader = cmd.ExecuteReader();
                            reader.Read();
                             sx = Convert.ToDateTime(reader.GetValue(7).ToString())-Convert.ToDateTime(DateTime.Now.ToString("hh:mm tt"));
                           
                             z = sx.TotalMinutes / 60;
                            

                            if (Convert.ToDateTime(date) < Convert.ToDateTime(timeout))
                            {
                                DialogResult wew = MessageBox.Show("Are you sure you want to time out early from your schedule?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (wew == DialogResult.Yes)
                                {
                                    TimeSpan undertime = Convert.ToDateTime(timeout)-Convert.ToDateTime(DateTime.Now.ToString("hh:mm tt"));
                                    double late = Convert.ToDouble(reader.GetValue(9).ToString());
                                    double undertimee = undertime.TotalHours;
                                    deduction = undertimee+late;
                                    double totalTime = Convert.ToDouble(total) - deduction;
                                    reader.Close();
                                    sql = "UPDATE tb_Attendance SET OutTime='" + DateTime.Now.ToString("hh:mm tt") + "', status ='" + no + "', WorkingTime='" + totalTime.ToString("##.##") + "', Undertime='" + undertimee.ToString("##.##") + "',totalDeduction='"+deduction.ToString("##.##")+"' WHERE attID like'" + lbsubID.Text + "'";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("TIme out successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    View();
                                }
                                else
                                {
                                    MessageBox.Show("Please wait until your time out. Thank you!", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    reader.Close();
                                }
                            }
                            else if (sx.TotalMinutes > 1)
                            {
                                reader.Close();
                                {
                                    double late = Convert.ToDouble(reader.GetValue(9).ToString());
                                    deduction = deduction + late;
                                    double totalTime = Convert.ToDouble(total) - deduction;
                                    reader.Close();
                                    sql = "UPDATE tb_Attendance SET OutTime='" + DateTime.Now.ToString("hh:mm tt") + "', status ='" + no + "', WorkingTime='" + totalTime.ToString("##.##") + "',totalDeduction='"+deduction+"',Undertime='0' WHERE attID like'" + lbsubID.Text + "'";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("TIme out successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    View();
                                    deduction = 0;
                                    totalTime = 0;
                                    late = 0;
                                }
                            }
                            else
                            {
                                double late = Convert.ToDouble(reader.GetValue(9).ToString());
                                deduction = deduction + late;
                                double totalTime = Convert.ToDouble(total) - deduction;
                                reader.Close();
                                sql = "UPDATE tb_Attendance SET OutTime='" + DateTime.Now.ToString("hh:mm tt") + "', status ='" + no + "', WorkingTime='" + totalTime.ToString("##.##") + "',totalDeduction='" + deduction + "',Undertime='0' WHERE attID like'" + lbsubID.Text + "'";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("TIme out successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                View();
                                deduction = 0;
                                totalTime = 0;
                                late = 0;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You do not have summary of loads! Please submit your loads first. Thank you", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please time in first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void View()
        {
            dgvManual.Columns.Clear();
            string sql = "Select attID as [No.], EmployeeID as [EMPLOYEE ID], InTime as [TIME IN], OutTime as [TIME OUT], Date as [DATE], Status as [STATUS] from tb_Attendance where EmployeeID like '" + lEmployeeID.Text + "' ";
            cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            try
            {
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgvManual.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void View1()
        {
            sql = "select * from tb_Employee where EmployeeID like '" + lEmployeeID.Text + "'";
            cmd = new SqlCommand(sql, cnn);
            reader = cmd.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
            {
                lLastname.Text = reader.GetValue(1).ToString();
              
                reader.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Date.Text = DateTime.Now.ToString("MM/dd/yyyy");
            Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
