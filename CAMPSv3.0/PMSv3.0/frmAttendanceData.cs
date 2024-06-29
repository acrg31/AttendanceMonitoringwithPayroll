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
using System.Linq;

namespace PMSv3._0
{
    public partial class frmAttendanceData : Form
    {

        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader read;
        SqlDataAdapter dr;
        string sql = "";
        frmLogin login = new frmLogin();
        string bbbb = "OKAY";
        string month = "";
        string year = "";
        double late = 0;
        double undertime = 0;
        double workingtime = 0;
        double totaldeduction = 0;
        double dailyRate = 0;
        double hourlyRate = 0;
        double tardiness = 0;
        double latededuction = 0;

        ListViewItem lv;
        public frmAttendanceData()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        public void clear()
        {
            txtEmpId.Clear();
            txtDays.Clear();
            txtName.Clear();
            txtIn.Clear();
            txtOut.Clear();
            cmbAdjustment.SelectedIndex = -1;
        }
        public void enable()
        {
            txtName.Enabled = true;
            txtIn.Enabled = true;
            txtOut.Enabled = true;
            txtDays.Enabled = true;
            dtDatee.Enabled = true;
        }

        public void disable()
        {
            txtName.Enabled = false;
            txtDays.Enabled = false;
            txtIn.Enabled = false;
            txtOut.Enabled = false;
            dtDatee.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                disable();
                lvlolo.Items.Clear();
                lvlola.Items.Clear();
                lvData.Items.Clear();
                if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 15)
                {
                    sql = "SELECT * FROM tb_Attendance WHERE DAY(Date) between '16' AND '31'";
                    cmd = new SqlCommand(sql, cnn);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        month = (Convert.ToDateTime(read.GetValue(1).ToString()).Month).ToString();
                        year = (Convert.ToDateTime(read.GetValue(1).ToString()).Year).ToString();
                        bbbb = "OKAY";
                        lvData.View = View.Details;
                        SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
                        DataTable dt = new DataTable();
                        read.Close();
                        dap.Fill(dt);
                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                            
                                DataRow drr = dt.Rows[z];
                                lv = new ListViewItem(drr[3].ToString());
                                lv.SubItems.Add(drr[4].ToString());
                                lv.SubItems.Add(drr[1].ToString());
                                lv.SubItems.Add(drr[2].ToString());
                                lv.SubItems.Add(drr[7].ToString());
                                lv.SubItems.Add(drr[8].ToString());
                                lv.SubItems.Add(drr[5].ToString());
                                lv.SubItems.Add(drr[9].ToString());
                                lv.SubItems.Add(drr[10].ToString());
                                lv.SubItems.Add(drr[11].ToString());
                                lv.SubItems.Add(drr[12].ToString());
                                lvData.Items.Add(lv);

                            
                        }
                    }
                }
                else if (DateTime.Now.Day >= 16 && DateTime.Now.Day <= 31)
                {
                    bbbb = "NOTOKAY";
                    sql = "SELECT * FROM tb_Attendance WHERE DAY(Date) between '1' AND '15'";
                    cmd = new SqlCommand(sql, cnn);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        month = (Convert.ToDateTime(read.GetValue(1).ToString()).Month).ToString();
                        year = (Convert.ToDateTime(read.GetValue(1).ToString()).Year).ToString();
                        lvData.View = View.Details;
                        SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
                        DataTable dt = new DataTable();
                        read.Close();
                        dap.Fill(dt);
                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                           
                                DataRow drr = dt.Rows[z];
                                lv = new ListViewItem(drr[3].ToString());
                                lv.SubItems.Add(drr[4].ToString());
                                lv.SubItems.Add(drr[1].ToString());
                                lv.SubItems.Add(drr[2].ToString());
                                lv.SubItems.Add(drr[7].ToString());
                                lv.SubItems.Add(drr[8].ToString());
                                lv.SubItems.Add(drr[5].ToString());
                                lv.SubItems.Add(drr[9].ToString());
                                lv.SubItems.Add(drr[10].ToString());
                                lv.SubItems.Add(drr[11].ToString());
                                lv.SubItems.Add(drr[12].ToString());
                                lvData.Items.Add(lv);
                            
                        }
                    }

                }
                read.Close();
                timer1.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string z = (Convert.ToDateTime(dtDatee.Value).DayOfWeek).ToString();
            DateTime qqq = Convert.ToDateTime(dtDatee.Value.ToString("MM/dd/yyyy"));

            if (cmbAdjustment.Text == "Leave")
            {
                if (txtEmpId.Text != "" && cmbAdjustment.Text != "" && dtDatee.Text != "" && txtDays.Text != "" && txtName.Text != "" && txtIn.Text != "" && txtOut.Text != "")
                {
                    read.Close();
                    for (int a = 0; a < Convert.ToInt32(txtDays.Text); a++)
                    {
                        read.Close();
                        sql = "SELECT * FROM tb_RemainingLeaves WHERE employeeID like'"+txtEmpId.Text+"'";
                        cmd = new SqlCommand(sql,cnn);
                        read = cmd.ExecuteReader();
                        read.Read();
                        int leaveremaining = Convert.ToInt32(read.GetValue(2).ToString());
                        string id = read.GetValue(1).ToString();
                        if (leaveremaining !=0)
                        {
                            read.Close();
                            sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,WorkingTime,InTime,OutTime,Adjustment,late,Undertime,totalDeduction) VALUES('" + qqq + "','" + qqq.DayOfWeek.ToString() + "','" + txtEmpId.Text + "','" + txtName.Text + "','8','" + txtIn.Text + "','" + txtOut.Text + "','" + cmbAdjustment.Text + "',' 0 ',' 0 ',' 0')";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            qqq = qqq.AddDays(1);
                            read.Close();
                            leaveremaining = leaveremaining - 1;
                            sql = "UPDATE tb_RemainingLeaves SET leaveRemaining='"+leaveremaining+"' WHERE employeeID like'"+id+"'";
                            cmd = new SqlCommand(sql,cnn);
                            cmd.ExecuteNonQuery();
                            
                        }
                        read.Close();
                    }

                    MessageBox.Show("Attendance employee has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1_Load(sender, e);
                    disable();
                    clear();
                }
                else
                {
                    MessageBox.Show("Please fill all fields first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cmbAdjustment.Text == "Official Business")
            {
                if (txtEmpId.Text != "" && cmbAdjustment.Text != "" && dtDatee.Text != "" && txtName.Text != "" && txtIn.Text != "" && txtOut.Text != "")
                {
                    TimeSpan time = Convert.ToDateTime(txtOut.Text) - Convert.ToDateTime(txtIn.Text);
                    read.Close();
                    sql = "INSERT INTO tb_Attendance(Date,day,EmployeeID,EmployeeName,WorkingTime,InTime,OutTime,Adjustment,late,Undertime,totalDeduction) VALUES('" + qqq + "','" + qqq.DayOfWeek.ToString() + "','" + txtEmpId.Text + "','" + txtName.Text + "','" + time.TotalHours.ToString("##.##") + "','" + txtIn.Text + "','" + txtOut.Text + "','" + cmbAdjustment.Text + "',' 0 ',' 0 ',' 0')";
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance employee has been updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1_Load(sender, e);
                    disable();
                    clear();
                }
                else
                {
                    MessageBox.Show("Please fill all fields first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void txtEmpId_Leave(object sender, EventArgs e)
        {


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lvData.Items.Clear();
                if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 15)
                {
                    sql = "SELECT * FROM tb_Attendance WHERE DAY(Date) between '16' AND '31' AND EmployeeID like'%" + txtSearch.Text + "%'";
                    cmd = new SqlCommand(sql, cnn);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        month = (Convert.ToDateTime(read.GetValue(1).ToString()).Month).ToString();
                        year = (Convert.ToDateTime(read.GetValue(1).ToString()).Year).ToString();
                        bbbb = "OKAY";
                        lvData.View = View.Details;
                        SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
                        DataTable dt = new DataTable();
                        read.Close();
                        dap.Fill(dt);
                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                           
                                DataRow drr = dt.Rows[z];
                                lv = new ListViewItem(drr[3].ToString());
                                lv.SubItems.Add(drr[4].ToString());
                                lv.SubItems.Add(drr[1].ToString());
                                lv.SubItems.Add(drr[2].ToString());
                                lv.SubItems.Add(drr[7].ToString());
                                lv.SubItems.Add(drr[8].ToString());
                                lv.SubItems.Add(drr[5].ToString());
                                lv.SubItems.Add(drr[9].ToString());
                                lv.SubItems.Add(drr[10].ToString());
                                lv.SubItems.Add(drr[11].ToString());
                                lv.SubItems.Add(drr[12].ToString());
                                lvData.Items.Add(lv);

                            
                        }
                    }
                }
                else if (DateTime.Now.Day >= 16 && DateTime.Now.Day <= 31)
                {
                    bbbb = "NOTOKAY";
                    sql = "SELECT * FROM tb_Attendance WHERE DAY(Date) between '1' AND '15' AND EmployeeID like'%" + txtSearch.Text + "%'";
                    cmd = new SqlCommand(sql, cnn);
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        month = (Convert.ToDateTime(read.GetValue(1).ToString()).Month).ToString();
                        year = (Convert.ToDateTime(read.GetValue(1).ToString()).Year).ToString();
                        lvData.View = View.Details;
                        SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
                        DataTable dt = new DataTable();
                        read.Close();
                        dap.Fill(dt);
                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                            
                                DataRow drr = dt.Rows[z];
                                lv = new ListViewItem(drr[3].ToString());
                                lv.SubItems.Add(drr[4].ToString());
                                lv.SubItems.Add(drr[1].ToString());
                                lv.SubItems.Add(drr[2].ToString());
                                lv.SubItems.Add(drr[7].ToString());
                                lv.SubItems.Add(drr[8].ToString());
                                lv.SubItems.Add(drr[5].ToString());
                                lv.SubItems.Add(drr[9].ToString());
                                lv.SubItems.Add(drr[10].ToString());
                                lv.SubItems.Add(drr[11].ToString());
                                lv.SubItems.Add(drr[12].ToString());
                                lvData.Items.Add(lv);
                            
                        }
                    }

                }
                read.Close();
                timer1.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void txtEmpId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            disable();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAdjustment.Text != "")
                {
                    if (cmbAdjustment.Text == "Leave")
                    {
                        sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtEmpId.Text + "' AND dpartment like 'Admin'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            if (txtEmpId.Text != "")
                            {
                                read.Close();
                                cmd = new SqlCommand(sql, cnn);
                                read = cmd.ExecuteReader();
                                if (read.Read())
                                {
                                    enable();
                                    txtName.Text = read.GetValue(3).ToString();
                                    txtName.Text += ", " + read.GetValue(1).ToString();
                                    txtName.Text += " " + read.GetValue(2).ToString();
                                    enable();
                                    txtIn.Text = "07:00 AM";
                                    txtOut.Text = "04:00 PM";
                                    txtIn.Enabled = false;
                                    txtOut.Enabled = false;
                                    txtDays.Enabled = true;
                                }
                                else
                                {
                                    MessageBox.Show("Employee cannot be found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee must be regular to file leave!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (cmbAdjustment.Text == "Official Business")
                    {
                        if (txtEmpId.Text != "")
                        {
                            read.Close();
                            sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtEmpId.Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            if (read.Read())
                            {
                                enable();
                                txtName.Text = read.GetValue(3).ToString();
                                txtName.Text += ", " + read.GetValue(1).ToString();
                                txtName.Text += " " + read.GetValue(2).ToString();
                                enable();
                                txtDays.Enabled = false;
                                txtIn.Enabled = true;
                                txtOut.Enabled = true;

                            }
                            else
                            {
                                MessageBox.Show("Employee cannot be found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    read.Close();
                }
                else
                {
                    MessageBox.Show("Please choose adjustment type first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbAdjustment.DroppedDown = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Stop();
        }

     

        private void panel2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Stop();
        }

     
        private void panel2_MouseHover(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            lvlola.Items.Clear();
            lvlolo.Items.Clear();
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void cmbAdjustment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult yiz = MessageBox.Show("Are you sure you want to submit data to finance?", "Wait!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yiz == DialogResult.Yes)
                {

                    sql = "DELETE FROM tb_FacultyFinance";
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    
                    sql = "DELETE FROM tb_AdminFinance";
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    read.Close();
                    for (int a = 0; a < lvData.Items.Count; a++)
                    {
                        int z = lvlola.Items.Count;
                        int x = lvlolo.Items.Count;
                        sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + lvData.Items[a].SubItems[0].Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        read.Read();
                        double rate = Convert.ToDouble(read.GetValue(14).ToString());
                        if (read.GetValue(18).ToString() == "Admin")
                        {
                            lv = new ListViewItem();
                            if (lvlola.Items.Count == 0)
                            {
                                lv = new ListViewItem(lvData.Items[a].SubItems[0].Text);
                                lv.SubItems.Add(lvData.Items[a].SubItems[1].Text);
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lvlola.Items.Add(lv);

                            }
                            else if (lvlola.Items[z - 1].SubItems[0].Text != lvData.Items[a].Text)
                            {
                                lv = new ListViewItem(lvData.Items[a].SubItems[0].Text);
                                lv.SubItems.Add(lvData.Items[a].SubItems[1].Text);
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lvlola.Items.Add(lv);

                            }
                        }
                        else if (read.GetValue(18).ToString() == "Faculty")
                        {
                            lv = new ListViewItem();
                            if (lvlolo.Items.Count == 0)
                            {
                                lv = new ListViewItem(lvData.Items[a].SubItems[0].Text);
                                lv.SubItems.Add(lvData.Items[a].SubItems[1].Text);
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lvlolo.Items.Add(lv);

                            }
                            else if (lvlolo.Items[x - 1].SubItems[0].Text != lvData.Items[a].SubItems[0].Text)
                            {
                                lv = new ListViewItem(lvData.Items[a].SubItems[0].Text);
                                lv.SubItems.Add(lvData.Items[a].SubItems[1].Text);
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lv.SubItems.Add("0");
                                lvlolo.Items.Add(lv);

                            }
                        }
                        read.Close();

                    }
                    for (int zz = 0; zz < lvlola.Items.Count; zz++)
                    {
                        for (int a = 0; a < lvData.Items.Count; a++)
                        {
                            sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + lvData.Items[a].SubItems[0].Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            read.Read();
                            double rate = Convert.ToDouble(read.GetValue(14).ToString());
                            if (lvlola.Items[zz].SubItems[0].Text == lvData.Items[a].SubItems[0].Text)
                            {
                                if (lvData.Items[a].SubItems[9].Text == "Leave")
                                {
                                    lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                    lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                    lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                    lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();

                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Monday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(5).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(5).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(6).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(5).ToString()) && Convert.ToDateTime(read.GetValue(6).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(5).ToString()))
                                            {//late 
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(6).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }

                                            read.Close();
                                        }
                                        else
                                        {
                                            read.Close();
                                        }
                                    }


                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Tuesday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(8).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(8).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(9).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay 
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(8).ToString()) && Convert.ToDateTime(read.GetValue(9).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(8).ToString()))
                                            {//late 
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(9).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                        }

                                        else
                                        {

                                            read.Close();
                                        }
                                    }

                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Wednesday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(11).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(11).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(12).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay 
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(11).ToString()) && Convert.ToDateTime(read.GetValue(12).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(11).ToString()))
                                            {//late 
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(12).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                        }
                                        else
                                        {

                                            read.Close();

                                        }
                                    }
                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Thursday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(14).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(14).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(15).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(14).ToString()) && Convert.ToDateTime(read.GetValue(15).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(14).ToString()))
                                            {//late
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(15).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                        }

                                        else
                                        {

                                            read.Close();
                                        }
                                    }

                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Friday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(17).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(17).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(18).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(17).ToString()) && Convert.ToDateTime(read.GetValue(18).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(17).ToString()))
                                            {//late
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(18).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime

                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                        }

                                        else
                                        {
                                            read.Close();
                                        }
                                    }
                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Saturday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(20).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(20).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(21).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(20).ToString()) && Convert.ToDateTime(read.GetValue(21).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();

                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(20).ToString()))
                                            {//late
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(21).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                        }

                                        else
                                        {
                                            read.Close();
                                        }
                                    }
                                }

                                else if (lvData.Items[a].SubItems[3].Text == "Sunday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(23).ToString() != "RESTDAY")
                                        {
                                            if (Convert.ToDateTime(read.GetValue(23).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) && Convert.ToDateTime(read.GetValue(24).ToString()) <= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//okay
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(23).ToString()) && Convert.ToDateTime(read.GetValue(24).ToString()) > Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//lat&undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(lvData.Items[a].SubItems[4].Text) > Convert.ToDateTime(read.GetValue(23).ToString()))
                                            {//late
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                            else if (Convert.ToDateTime(read.GetValue(24).ToString()) >= Convert.ToDateTime(lvData.Items[a].SubItems[5].Text))
                                            {//undertime
                                                dailyRate = (rate * 12) / 313;
                                                hourlyRate = dailyRate / 8;
                                                latededuction = (hourlyRate / 45) * 60;
                                                lvlola.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[2].Text) + 1).ToString();
                                                lvlola.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[3].Text) + 0).ToString();
                                                lvlola.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[4].Text) + latededuction).ToString();
                                                lvlola.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlola.Items[zz].SubItems[5].Text) + Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();
                                            }
                                        }

                                        else
                                        {
                                            read.Close();
                                        }
                                    }
                                }
                            }
                            read.Close();
                        }
                    }
                    for (int a = 0; a < lvData.Items.Count; a++)
                    {
                        for (int zz = 0; zz < lvlolo.Items.Count; zz++)
                        {
                            sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + lvData.Items[a].SubItems[0].Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            read.Read();
                            double rate = Convert.ToDouble(read.GetValue(14).ToString());
                            if (lvlolo.Items[zz].SubItems[0].Text == lvData.Items[a].SubItems[0].Text)
                            {

                                if (lvData.Items[a].SubItems[3].Text == "Monday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(7).ToString() != "RESTDAY")
                                        {


                                            double hours = Convert.ToDouble(read.GetValue(7).ToString());
                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text) - Convert.ToDouble(lvData.Items[a].SubItems[10].Text)).ToString();

                                            }
                                            else if (read.GetValue(5).ToString() != "RESTDAY")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();


                                                read.Close();
                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();


                                                read.Close();
                                            }
                                            else
                                            {
                                                read.Close();
                                            }
                                        }
                                    }


                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Tuesday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(10).ToString() != "RESTDAY")
                                        {
                                            double hours = Convert.ToDouble(read.GetValue(10).ToString());

                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (read.GetValue(8).ToString() != "RESTDAY")
                                            {

                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();

                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                                read.Close();
                                            }
                                            else
                                            {

                                                read.Close();
                                            }
                                        }
                                    }
                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Wednesday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {

                                        if (read.GetValue(13).ToString() != "RESTDAY")
                                        {
                                            double hours = Convert.ToDouble(read.GetValue(13).ToString());
                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (read.GetValue(11).ToString() != "RESTDAY")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                                read.Close();
                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {

                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                                read.Close();
                                            }
                                            else
                                            {

                                                read.Close();

                                            }
                                        }
                                    }
                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Thursday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {

                                        if (read.GetValue(16).ToString() != "RESTDAY")
                                        {

                                            double hours = Convert.ToDouble(read.GetValue(16).ToString());
                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (read.GetValue(14).ToString() != "RESTDAY")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();

                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {

                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();
                                            }
                                            else
                                            {

                                                read.Close();
                                            }
                                        }
                                    }
                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Friday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(19).ToString() != "RESTDAY")
                                        {

                                            double hours = Convert.ToDouble(read.GetValue(19).ToString());
                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (read.GetValue(17).ToString() != "RESTDAY")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();
                                            }
                                            else
                                            {
                                                read.Close();
                                            }
                                        }
                                    }
                                }
                                else if (lvData.Items[a].SubItems[3].Text == "Saturday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(22).ToString() != "RESTDAY")
                                        {

                                            double hours = Convert.ToDouble(read.GetValue(22).ToString());
                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (read.GetValue(20).ToString() != "RESTDAY")
                                            {

                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {


                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();
                                            }
                                            else
                                            {
                                                read.Close();
                                            }
                                        }
                                    }
                                }

                                else if (lvData.Items[a].SubItems[3].Text == "Sunday")
                                {
                                    read.Close();
                                    sql = "SELECT * FROM tb_SummaryOfLoads WHERE empID like'" + lvData.Items[a].SubItems[0].Text + "' ";
                                    cmd = new SqlCommand(sql, cnn);
                                    read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        if (read.GetValue(25).ToString() != "RESTDAY")
                                        {

                                            double hours = Convert.ToDouble(read.GetValue(25).ToString());
                                            if (lvData.Items[a].SubItems[9].Text == "Official Business")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(lvData.Items[a].SubItems[6].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();

                                            }
                                            else if (read.GetValue(23).ToString() != "RESTDAY")
                                            {

                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();
                                            }
                                            else if (lvData.Items[a].SubItems[9].Text != "None")
                                            {
                                                lvlolo.Items[zz].SubItems[2].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) + Convert.ToDouble(hours)).ToString();
                                                lvlolo.Items[zz].SubItems[3].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvData.Items[a].SubItems[7].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[4].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text) + Convert.ToDouble(lvData.Items[a].SubItems[8].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[5].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[3].Text) + Convert.ToDouble(lvlolo.Items[zz].SubItems[4].Text)).ToString();
                                                lvlolo.Items[zz].SubItems[6].Text = (Convert.ToDouble(lvlolo.Items[zz].SubItems[2].Text) - Convert.ToDouble(lvlolo.Items[zz].SubItems[5].Text)).ToString();
                                                read.Close();
                                            }
                                            else
                                            {
                                                read.Close();
                                            }
                                        }
                                    }
                                }
                            }
                            read.Close();

                        }
                        read.Close();
                    }

                    foreach (ListViewItem j in lvlola.Items)
                    {
                        sql = "SELECT * FROM tb_AdminFinance WHERE EmployeeID like'" + j.SubItems[0].Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {

                            read.Close();
                            sql = "UPDATE tb_AdminFinance SET totaldays='" + j.SubItems[2].Text + "', totalLate='" + j.SubItems[3].Text + "', totalUndertime='" + j.SubItems[4].Text + "',totalDeduction='" + j.SubItems[5].Text + "'WHERE EmployeeID like'" + j.SubItems[0].Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            read.Close();
                        }
                        else
                        {
                            read.Close();
                            sql = "INSERT INTO tb_AdminFinance(EmployeeID,EmployeeName,totaldays,totalLate,totalUndertime,totalDeduction) VALUES(@d1,@d2,@d3,@d4,@d5,@d6)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", j.SubItems[0].Text);
                            cmd.Parameters.AddWithValue("d2", j.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d3", j.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d4", j.SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d5", j.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d6", j.SubItems[5].Text);
                            cmd.ExecuteNonQuery();
                            read.Close();
                        }
                    }
                    foreach (ListViewItem j in lvlolo.Items)
                    {
                        sql = "SELECT * FROM tb_FacultyFinance WHERE EmployeeID like'" + j.SubItems[0].Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {

                            read.Close();
                            sql = "UPDATE tb_FacultyFinance SET totalHours='" + j.SubItems[2].Text + "', totalLate='" + j.SubItems[3].Text + "', totalUndertime='" + j.SubItems[4].Text + "',totalDeduction='" + j.SubItems[5].Text + "',totalHour='" + j.SubItems[6].Text + "' WHERE EmployeeID like'" + j.SubItems[0].Text + "'";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            read.Close();
                        }
                        else
                        {
                            read.Close();
                            sql = "INSERT INTO tb_FacultyFinance(EmployeeID,EmployeeName,totalHours,totalLate,totalUndertime,totalDeduction,totalHour) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", j.SubItems[0].Text);
                            cmd.Parameters.AddWithValue("d2", j.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d3", j.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d4", j.SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d5", j.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d6", j.SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d7", j.SubItems[6].Text);
                            cmd.ExecuteNonQuery();
                            read.Close();
                        }
                    }

                    MessageBox.Show("Employee records has been submitted to finance!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error "+ex);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}


    

