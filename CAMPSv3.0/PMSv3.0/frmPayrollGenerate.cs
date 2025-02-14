﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PMSv3._0
{
    public partial class frmPayrollGenerate : Form
    {
        SqlCommand cmd;
        SqlDataReader read;
        frmLogin login = new frmLogin();
        SqlConnection cnn;
        SqlDataAdapter dap;
        ListViewItem lv;
        string sql = "";
        double rate = 0;
        double dailyrate = 0;
        double hourlyrate = 0;
        double grosspay = 0;
        double deduct = 0;
        double pagibig = 100;
        double netpay = 0;
        double ss = 0;
        double philhealth = 0;
        double taxes = 0;
        public frmPayrollGenerate()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();

        }
        public void admin()
        {
            sql = "SELECT * FROM tb_AdminFinance";
            dap = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            for (int z = 0; z < dt.Rows.Count; z++)
            {
                    DataRow drr = dt.Rows[z];
                    lv = new ListViewItem(drr[0].ToString());
                    lv.SubItems.Add(drr[1].ToString());
                    lv.SubItems.Add(drr[5].ToString());
                    lv.SubItems.Add(drr[2].ToString());
                    lvAdminInfo.Items.Add(lv);
            }
        }
        public void deleteAdmin()
        {
            sql = "Delete from tb_AdminFinance";
            cmd = new SqlCommand(sql,cnn);
            cmd.ExecuteNonQuery();
        }
        public void Faculty()
        {
            sql = "SELECT * FROM tb_FacultyFinance";
            dap = new SqlDataAdapter(sql, cnn);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            for (int z = 0; z < dt.Rows.Count; z++)
            {
                    DataRow drr = dt.Rows[z];
                    lv = new ListViewItem(drr[0].ToString());
                    lv.SubItems.Add(drr[1].ToString());
                    lv.SubItems.Add(drr[5].ToString());
                    lv.SubItems.Add(drr[6].ToString());
                    lvFacultyInfo.Items.Add(lv);
            }
        }
        public void deleteFaculty()
        {
            sql = "Delete from tb_FacultyFinance";
            cmd = new SqlCommand(sql,cnn);
            cmd.ExecuteNonQuery();
        }
        private void frmPayrollGenerate_Load(object sender, EventArgs e)
        {
            admin();
            Faculty();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                lvadmin.Items.Clear();
                lvFaculty.Items.Clear();

                sql = "DELETE FROM tb_BatchProcess";
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                sql = "DELETE FROM tb_BatchProcess_pday";
                cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                {//Admin
                    for (int a = 0; a < lvAdminInfo.Items.Count; a++)
                    {
                        sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + lvAdminInfo.Items[a].SubItems[0].Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            double rateee = Convert.ToDouble(read.GetValue(14).ToString());
                            double semi = rateee / 2;
                            dailyrate = (rateee * 12) / 313;
                            dailyrate = (rateee * 12) / 313;
                            hourlyrate = dailyrate / 8;
                            double tardiness = hourlyrate / 60;
                            double deductiontotallate = tardiness * (Convert.ToDouble(lvAdminInfo.Items[a].SubItems[2].Text)*60);
                            grosspay = dailyrate * Convert.ToDouble(lvAdminInfo.Items[a].SubItems[3].Text);
                            deduct = Convert.ToDouble(lvAdminInfo.Items[a].SubItems[2].Text);
                            read.Close();
                            sql = "SELECT * FROM tb_SSS ";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) >= rateee)
                                {
                                    ss = Convert.ToDouble(read.GetValue(4).ToString());
                                }
                                else if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) <= rateee)
                                {
                                    ss = Convert.ToDouble(read.GetValue(4).ToString());
                                }
                            }
                            //
                            read.Close();//philhealth
                            sql = "SELECT * FROM tb_PhilHealth";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) >= rateee)
                                {
                                    philhealth = Convert.ToDouble(read.GetValue(6).ToString());
                                }
                                else if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) <= rateee)
                                {
                                    philhealth = Convert.ToDouble(read.GetValue(6).ToString());
                                }
                            }
                            if (semi <= 10416)
                            {
                                taxes = 0;
                            }
                            else if (semi >= 10417 && semi <= 16666)
                            {
                                taxes = (semi-10417) * .20;
                            }
                            else if (semi >= 16667 && semi <= 33332)
                            {
                                taxes = (((semi - 16667) + 1250) * .25);
                            }
                            else if (semi >= 33333 && semi <= 83331)
                            {
                                taxes = (((semi - 33333) + 5416.67) * .30);

                            }
                            else if (semi >= 83332 && semi <= 333332)
                            {
                                taxes = (((semi - 83332) + 20416.67) * .32);

                            }
                            else if (semi >= 333333)
                            {
                                taxes = (((semi - 333333) + 100416.67) * .32);

                            }
                            double deductionsTotal = (ss + philhealth + taxes + pagibig + deductiontotallate);
                            deductionsTotal = Math.Round((double)deductionsTotal, 2);
                            grosspay = Math.Round((double)grosspay, 2);
                            netpay = grosspay - deductionsTotal;
                            netpay = Math.Round((double)netpay, 2);
                            lv = new ListViewItem(lvAdminInfo.Items[a].SubItems[0].Text);
                            lv.SubItems.Add(lvAdminInfo.Items[a].SubItems[1].Text);
                            lv.SubItems.Add(lvAdminInfo.Items[a].SubItems[3].Text);
                            lv.SubItems.Add(grosspay.ToString());
                            lv.SubItems.Add(deductionsTotal.ToString());
                            lv.SubItems.Add(ss.ToString());
                            lv.SubItems.Add(philhealth.ToString());
                            lv.SubItems.Add(taxes.ToString());
                            lv.SubItems.Add(pagibig.ToString());
                            lv.SubItems.Add(netpay.ToString());
                            lv.SubItems.Add(deductiontotallate.ToString("##.##"));
                            lvadmin.Items.Add(lv);
                        }
                        read.Close();
                    }
                    DateTime dt = DateTime.Now;
                    string ssss = "";

                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 15)
                    {
                        ssss = dt.Month + "/20/" + dt.Year;
                    }
                    else
                    {
                        ssss = dt.Month + "/05/" + dt.Year;
                    }


                    foreach (ListViewItem j in lvadmin.Items)
                    {
                        sql = "SELECT * FROM tb_BatchProcess_pday WHERE EmployeeID like'" + j.SubItems[0].Text + "' AND batchdate like'" + ssss + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            read.Close();
                            //sql = "UPDATE tb_BatchProcess_pday SET workingdaysTotal=" + j.SubItems[1].Text + ", grosspay=" + j.SubItems[2].Text + ", deduction=" + j.SubItems[3].Text + ",sss=" + j.SubItems[4].Text + ", philhealth=" + j.SubItems[5].Text + ", tax=" + j.SubItems[6].Text + ", netpay=" + j.SubItems[8].Text + " WHERE  batchdate like'" + ssss + "' AND EmployeeID like '" + Convert.ToString(j.SubItems[0].Text) + "'";
                            //cmd = new SqlCommand(sql, cnn);
                            //cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            read.Close();
                            sql = "INSERT INTO tb_BatchProcess_pday(batchdate,EmployeeID,EmployeeName,workingdaysTotal,grosspay,deduction,sss,philhealth,tax,pagibig,netpay,deductionTotalMoney) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", ssss);
                            cmd.Parameters.AddWithValue("d2", j.SubItems[0].Text);
                            cmd.Parameters.AddWithValue("d3", j.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d4", j.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d5", j.SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d6", j.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d7", j.SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d8", j.SubItems[6].Text);
                            cmd.Parameters.AddWithValue("d9", j.SubItems[7].Text);
                            cmd.Parameters.AddWithValue("d10", j.SubItems[8].Text);
                            cmd.Parameters.AddWithValue("d11", j.SubItems[9].Text);
                            cmd.Parameters.AddWithValue("d12", j.SubItems[10].Text);
                            cmd.ExecuteNonQuery();
                            read.Close();
                        }
                    }
                    MessageBox.Show("Admin attendance has been computed!", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                {//Faculty
                    for (int a = 0; a < lvFacultyInfo.Items.Count; a++)
                    {
                        sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + lvFacultyInfo.Items[a].SubItems[0].Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            double rateee = Convert.ToDouble(read.GetValue(14).ToString());
                            double semi = rateee / 2;
                            dailyrate = (rateee * 12) / 313;
                            hourlyrate = dailyrate / 8;
                            grosspay = hourlyrate * Convert.ToDouble(lvFacultyInfo.Items[a].SubItems[3].Text);
                            deduct = Convert.ToDouble(lvFacultyInfo.Items[a].SubItems[2].Text);
                            read.Close();
                            sql = "SELECT * FROM tb_SSS ";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) >= rateee)
                                {
                                    ss = Convert.ToDouble(read.GetValue(4).ToString());
                                }
                                else if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) <= rateee)
                                {
                                    ss = Convert.ToDouble(read.GetValue(4).ToString());
                                }
                            }
                            //
                            read.Close();//philhealth
                            sql = "SELECT * FROM tb_PhilHealth";
                            cmd = new SqlCommand(sql, cnn);
                            read = cmd.ExecuteReader();
                            while (read.Read())
                            {
                                if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) >= rateee)
                                {
                                    philhealth = Convert.ToDouble(read.GetValue(6).ToString());
                                }
                                else if (Convert.ToDouble(read.GetValue(1)) <= rateee && Convert.ToDouble(read.GetValue(2)) <= rateee)
                                {
                                    philhealth = Convert.ToDouble(read.GetValue(6).ToString());
                                }
                            }
                            if (semi <= 10416)
                            {
                                taxes = 0;
                            }
                            else if (semi >= 10417 && semi <= 16666)
                            {
                                taxes = (semi-10417) * .20;
                            }
                            else if (semi >= 16667 && semi <= 33332)
                            {
                                taxes = (((semi - 16667) + 1250) * .25);
                            }
                            else if (semi >= 33333 && semi <= 83331)
                            {
                                taxes = (((semi - 33333) + 5416.67) * .30);

                            }
                            else if (semi >= 83332 && semi <= 333332)
                            {
                                taxes = (((semi - 83332) + 20416.67) * .32);

                            }
                            else if (semi >= 333333)
                            {
                                taxes = (((semi - 333333) + 100416.67) * .32);
                            }
                            double deductionsTotal = (ss + philhealth + taxes + pagibig);
                            deductionsTotal = Math.Round((double)deductionsTotal, 2);
                            grosspay = Math.Round((double)grosspay, 2);
                            netpay = grosspay - deductionsTotal;
                            netpay = Math.Round((double)netpay, 2); lv = new ListViewItem(lvFacultyInfo.Items[a].SubItems[0].Text);
                            lv.SubItems.Add(lvFacultyInfo.Items[a].SubItems[1].Text);
                            lv.SubItems.Add(lvFacultyInfo.Items[a].SubItems[3].Text);
                            lv.SubItems.Add(grosspay.ToString("F"));
                            lv.SubItems.Add(deductionsTotal.ToString("F"));
                            lv.SubItems.Add(ss.ToString("F"));
                            lv.SubItems.Add(philhealth.ToString("F"));
                            lv.SubItems.Add(taxes.ToString("F"));
                            lv.SubItems.Add(pagibig.ToString("F"));
                            lv.SubItems.Add(netpay.ToString("F"));
                            lvFaculty.Items.Add(lv);
                        }
                        read.Close();
                    }

                    DateTime dt = DateTime.Now;
                    string ssss = "";

                    if (DateTime.Now.Day >= 1 && DateTime.Now.Day <= 15)
                    {
                        ssss = dt.Month + "/20/" + dt.Year;
                    }
                    else
                    {
                        ssss = dt.Month + "/05/" + dt.Year;
                    }
                    foreach (ListViewItem j in lvFaculty.Items)
                    {
                        sql = "SELECT * FROM tb_BatchProcess WHERE EmployeeID like'" + j.SubItems[0].Text + "' AND batchdate like'" + ssss + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            read.Close();
                            //sql = "UPDATE tb_BatchProcess SET workingTimeTotal='" + j.SubItems[1].Text + "', grosspay='" + j.SubItems[2].Text + "', deduction='" + j.SubItems[3].Text + "',sss='" + j.SubItems[4].Text + "', philhealth='" + j.SubItems[5].Text + "', tax='" + j.SubItems[6].Text + "', netpay='" + j.SubItems[8].Text + "' WHERE  batchdate='" + ssss + "' AND EmployeeID like'" + j.SubItems[0].Text + "'";
                            //cmd = new SqlCommand(sql, cnn);
                            //cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            read.Close();
                            sql = "INSERT INTO tb_BatchProcess(batchdate,EmployeeID,EmployeeName,workingTImeTotal,grosspay,deduction,sss,philhealth,tax,pagibig,netpay) VALUES(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", ssss);
                            cmd.Parameters.AddWithValue("d2", j.SubItems[0].Text);
                            cmd.Parameters.AddWithValue("d3", j.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d4", j.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d5", j.SubItems[3].Text);
                            cmd.Parameters.AddWithValue("d6", j.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d7", j.SubItems[5].Text);
                            cmd.Parameters.AddWithValue("d8", j.SubItems[6].Text);
                            cmd.Parameters.AddWithValue("d9", j.SubItems[7].Text);
                            cmd.Parameters.AddWithValue("d10", j.SubItems[8].Text);
                            cmd.Parameters.AddWithValue("d11", j.SubItems[9].Text);
                            cmd.ExecuteNonQuery();
                            read.Close();
                        }
                    }
                    MessageBox.Show("Faculty Attedance has been Calculated!", "Thank you!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }
    }
}