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
    public partial class frmLoan : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader read;
        string sql = "";
        SqlDataAdapter dr;
        string regular = "";
        frmLogin login = new frmLogin();
        double amntLoan = 0, DOT = 0, SOP = 0, mospay = 0, total = 0;
        
            
        public frmLoan()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
            
        }
        public void SSSenable()
        {
            txtSSSamount.Enabled = true;
            txtSSSMosPayment.Enabled = true;
            txtSSSStartofPayment.Enabled = true;
            txtSSSTotalPayment.Enabled = true;
            dtSSSRelease.Enabled = true;
            btnSubmitSSS.Enabled = true;
            txtName.Enabled = true;
        }
        public void SSSdisable()
        {
            txtSSSamount.Enabled = false;
            txtSSSMosPayment.Enabled = false;
            txtSSSStartofPayment.Enabled = false;
            dtSSSRelease.Enabled = false;
            txtSSSTotalPayment.Enabled = false;
            btnSubmitSSS.Enabled = false;
            txtName.Enabled = false;
        }
        public void PGenable()
        {
            txtPGAmount.Enabled = true;
            dtPGDOR.Enabled = true;
            txtPGMosPay.Enabled = true;
            txtPGStartOfPayment.Enabled = true;
            txtPGTotalPay.Enabled = true;
            btnSubmitPG.Enabled = true;
        }public void PGdisable()
        {
            txtPGAmount.Enabled = false;
            dtPGDOR.Enabled = false;
            txtPGMosPay.Enabled = false;
            txtPGStartOfPayment.Enabled = false;
            txtPGTotalPay.Enabled = false;
            btnSubmitPG.Enabled = false;
        }
        public void clear()
        {
            txtEmployeeID.Clear();
            txtName.Clear();
            txtPGAmount.Clear();
            txtPGTotalPay.Clear();
            txtPGStartOfPayment.Clear();
            txtPGMosPay.Clear();
            txtPGAmount.Clear();
            txtSSSamount.Clear();
            txtSSSMosPayment.Clear();
            txtSSSStartofPayment.Clear();
            txtSSSTotalPayment.Clear();
            lvPG.Items.Clear();
            lvSSS.Items.Clear();
            
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string go = "SSS";
                string gos = "PG";
                sql = "SELECT * FROM tb_LoanSSS WHERE employeeID='"+txtEmployeeID.Text+"'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if (!read.Read())
                {

                    read.Close();
                    cmd.Dispose();
                    if (txtSSSamount.Text != ""||txtSSSMosPayment.Text!=""||txtSSSTotalPayment.Text!="")
                    {
                        foreach (ListViewItem l in lvSSS.Items)
                        {
                            sql = "INSERT INTO tb_LoanSSS(loanType,employeeID,amnt,dor,mosPay,totalpay,sop,id,periodpay,currentBal,totalPPP) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", "SSS");
                            cmd.Parameters.AddWithValue("d2", txtEmployeeID.Text);
                            cmd.Parameters.AddWithValue("d3", txtSSSamount.Text);
                            cmd.Parameters.AddWithValue("d4", dtSSSRelease.Value.ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("d5", txtSSSMosPayment.Text);
                            cmd.Parameters.AddWithValue("d6", txtSSSTotalPayment.Text);
                            cmd.Parameters.AddWithValue("d7", txtSSSStartofPayment.Text);
                            cmd.Parameters.AddWithValue("d8", l.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d9", l.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d10", l.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d11", l.SubItems[5].Text);
                            cmd.ExecuteNonQuery();
                        }



                        read.Close();
                    }
                }
                else
                {
                    go = "Balance";
                }

                sql = "SELECT * FROM tb_LoanPG WHERE employeeID='" + txtEmployeeID.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if (!read.Read())
                {

                    read.Close();
                    cmd.Dispose();
                    if (txtPGAmount.Text!= ""||txtPGMosPay.Text!=""||txtPGTotalPay.Text!="")
                    {
                        foreach (ListViewItem l in lvPG.Items)
                        {
                            sql = "INSERT INTO tb_LoanPG(loanType,employeeID,amnt,dor,mosPay,totalpay,sop,id,periodpay,currentBal,totalPPP) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", "SSS");
                            cmd.Parameters.AddWithValue("d2", txtEmployeeID.Text);
                            cmd.Parameters.AddWithValue("d3", txtPGAmount.Text);
                            cmd.Parameters.AddWithValue("d4", dtPGDOR.Value.ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("d5", txtPGMosPay.Text);
                            cmd.Parameters.AddWithValue("d6", txtPGTotalPay.Text);
                            cmd.Parameters.AddWithValue("d7", txtPGStartOfPayment.Text);
                            cmd.Parameters.AddWithValue("d8", l.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d9", l.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d10", l.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d11", l.SubItems[5].Text);
                            cmd.ExecuteNonQuery();
                        }

                    }
                }
                else
                {
                    gos = "Balance";
                }
                read.Close();
                if (go!="Balance"&&gos!="Balance")
                {
                    MessageBox.Show("SSS/Pagibig Loan submitted!","Success",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                if (go != "Balance" && gos == "Balance")
                {
                    MessageBox.Show("Pagibig submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if(go == "Balance" && gos != "Balance")
                {
                    MessageBox.Show("Pagibig Loan submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                 if (go == "Balance" && gos == "Balance")
                {
                    MessageBox.Show("Employee currently had a balance!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSSSamount.Text != "" || txtSSSTotalPayment.Text != "" || txtSSSStartofPayment.Text != "")
                {
                    {//
                        for (int i = 0; i < lvSSS.Items.Count; i++)
                        {
                            string del = "delete from tb_LoanSSS where employeeID='" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(del, cnn);
                            cmd.ExecuteNonQuery();

                        }


                    }

                    {

                        mospay = Convert.ToDouble(txtSSSMosPayment.Text);
                        total = mospay * 24;
                        DateTime sop = Convert.ToDateTime(dtSSSRelease.Value.ToString("MM/dd/yyyy"));
                        DateTime sops = sop.AddMonths(2);
                        DateTime www = sop.AddMonths(1);
                        txtSSSTotalPayment.Text = total.ToString();
                        txtSSSStartofPayment.Text = sops.ToString("MM/dd/yyyy");
                        mospay = mospay / 2;
                        if ((sops.Day >= 20 && sops.Day <= 31) || (sops.Day >= 1 && sops.Day <= 5))
                        {
                            DateTime yearr = new DateTime(www.Year, www.Month, 05);
                            int okay = 0;
                            for (int z = 0; z < 48; z++)
                            {

                                ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                                lvi.SubItems.Add((z + 1).ToString());
                                if (okay == 0)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                    okay = 1;
                                }
                                else if (okay == 1)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                    okay = 0;
                                }

                                lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                                if (okay == 1)
                                {
                                    yearr = yearr.AddMonths(1);
                                }
                                lvi.SubItems.Add(mospay.ToString());
                                lvi.SubItems.Add(total.ToString());
                                total = total - mospay;
                                lvi.SubItems.Add(total.ToString());
                                lvSSS.Items.Add(lvi);
                            }
                        }
                        else if (sops.Day >= 6 && sops.Day <= 19)
                        {
                            DateTime yearr = new DateTime(www.Year, www.Month, 05);
                            int okay = 1;
                            for (int z = 0; z < 48; z++)
                            {


                                ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                                lvi.SubItems.Add((z + 1).ToString());
                                if (okay == 0)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                    okay = 1;
                                }
                                else if (okay == 1)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                    okay = 0;
                                }

                                lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                                if (okay == 1)
                                {
                                    yearr = yearr.AddMonths(1);
                                }


                                lvi.SubItems.Add(mospay.ToString());

                                lvi.SubItems.Add(total.ToString());
                                total = total - mospay;
                                lvi.SubItems.Add(total.ToString());
                                lvSSS.Items.Add(lvi);
                            }

                        }

                    }
                    {//
                        foreach (ListViewItem l in lvSSS.Items)
                        {
                            sql = "INSERT INTO tb_LoanSSS(loanType,employeeID,amnt,dor,mosPay,totalpay,sop,id,periodpay,currentBal,totalPPP) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.AddWithValue("d1", "SSS");
                            cmd.Parameters.AddWithValue("d2", txtEmployeeID.Text);
                            cmd.Parameters.AddWithValue("d3", txtSSSamount.Text);
                            cmd.Parameters.AddWithValue("d4", dtSSSRelease.Value.ToString("MM/dd/yyyy"));
                            cmd.Parameters.AddWithValue("d5", txtSSSMosPayment.Text);
                            cmd.Parameters.AddWithValue("d6", txtSSSTotalPayment.Text);
                            cmd.Parameters.AddWithValue("d7", txtSSSStartofPayment.Text);
                            cmd.Parameters.AddWithValue("d8", l.SubItems[1].Text);
                            cmd.Parameters.AddWithValue("d9", l.SubItems[2].Text);
                            cmd.Parameters.AddWithValue("d10", l.SubItems[4].Text);
                            cmd.Parameters.AddWithValue("d11", l.SubItems[5].Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                if (txtPGAmount.Text != "" || txtPGMosPay.Text != "" || txtPGStartOfPayment.Text != "")
                {
                    {//
                        for (int i = 0; i < lvPG.Items.Count; i++)
                        {
                            string del = "delete from tb_LoanPG where employeeID='" + txtEmployeeID.Text + "'";
                            cmd = new SqlCommand(del, cnn);
                            cmd.ExecuteNonQuery();
                        }
                        lvPG.Items.Clear();
                    }
                    {

                        mospay = Convert.ToDouble(txtPGMosPay.Text);
                        total = mospay * 24;
                        DateTime sop = Convert.ToDateTime(dtPGDOR.Value.ToString("MM/dd/yyyy"));
                        DateTime sops = sop.AddMonths(2);
                        DateTime www = sop.AddMonths(1);
                        txtPGTotalPay.Text = total.ToString();
                        txtPGStartOfPayment.Text = sops.ToString("MM/dd/yyyy");
                        mospay = mospay / 2;
                        if ((sops.Day >= 20 && sops.Day <= 31) || (sops.Day >= 1 && sops.Day <= 5))
                        {
                            DateTime yearr = new DateTime(www.Year, www.Month, 05);
                            int okay = 0;
                            for (int z = 0; z < 48; z++)
                            {

                                ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                                lvi.SubItems.Add((z + 1).ToString());
                                if (okay == 0)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                    okay = 1;
                                }
                                else if (okay == 1)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                    okay = 0;
                                }

                                lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                                if (okay == 1)
                                {
                                    yearr = yearr.AddMonths(1);
                                }
                                lvi.SubItems.Add(mospay.ToString());
                                lvi.SubItems.Add(total.ToString());
                                total = total - mospay;
                                lvi.SubItems.Add(total.ToString());
                                lvPG.Items.Add(lvi);
                            }
                        }
                        else if (sops.Day >= 6 && sops.Day <= 19)
                        {
                            DateTime yearr = new DateTime(www.Year, www.Month, 05);
                            int okay = 1;
                            for (int z = 0; z < 48; z++)
                            {


                                ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                                lvi.SubItems.Add((z + 1).ToString());
                                if (okay == 0)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                    okay = 1;
                                }
                                else if (okay == 1)
                                {
                                    yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                    okay = 0;
                                }

                                lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                                if (okay == 1)
                                {
                                    yearr = yearr.AddMonths(1);
                                }


                                lvi.SubItems.Add(mospay.ToString());

                                lvi.SubItems.Add(total.ToString());
                                total = total - mospay;
                                lvi.SubItems.Add(total.ToString());
                                lvSSS.Items.Add(lvi);
                            }
                        }
                        {//
                            foreach (ListViewItem l in lvPG.Items)
                            {
                                sql = "INSERT INTO tb_LoanSSS(loanType,employeeID,amnt,dor,mosPay,totalpay,sop,id,periodpay,currentBal,totalPPP) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.Parameters.AddWithValue("d1", "SSS");
                                cmd.Parameters.AddWithValue("d2", txtEmployeeID.Text);
                                cmd.Parameters.AddWithValue("d3", txtPGAmount.Text);
                                cmd.Parameters.AddWithValue("d4", dtPGDOR.Value.ToString("MM/dd/yyyy"));
                                cmd.Parameters.AddWithValue("d5", txtPGMosPay.Text);
                                cmd.Parameters.AddWithValue("d6", txtPGTotalPay.Text);
                                cmd.Parameters.AddWithValue("d7", txtPGStartOfPayment.Text);
                                cmd.Parameters.AddWithValue("d8", l.SubItems[1].Text);
                                cmd.Parameters.AddWithValue("d9", l.SubItems[2].Text);
                                cmd.Parameters.AddWithValue("d10", l.SubItems[4].Text);
                                cmd.Parameters.AddWithValue("d11", l.SubItems[5].Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }
        }

        private void frmLoan_Load(object sender, EventArgs e)
        {
            
            try
            {   SSSdisable();
                PGdisable();
                btnSubmit.Enabled = false;
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtEmployeeID.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                read.Read();
                if (read.HasRows)
                {
                    regular = read.GetValue(20).ToString();
                    
                    if(regular== "Regular")
                    {
                        txtName.Text = read.GetValue(3).ToString();
                        txtName.Text += "," + read.GetValue(1).ToString();
                        txtName.Text += " " + read.GetValue(2).ToString();
                        SSSenable();
                        PGenable();
                        read.Close();
                        sql = "SELECT * FROM tb_LoanSSS WHERE employeeID like'"+txtEmployeeID.Text+"'";
                        cmd = new SqlCommand(sql,cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            btnUpdate.Enabled = true;
                            btnSubmit.Enabled = true ;
                            read.Close();
                            lvSSS.View = View.Details;
                            SqlDataAdapter dap = new SqlDataAdapter(sql,cnn);
                            DataTable dt = new DataTable();
                            dap.Fill(dt);
                            for (int z=0;z<dt.Rows.Count;z++)
                            {

                                DataRow drr = dt.Rows[z];
                                ListViewItem lvv = new ListViewItem(drr[2].ToString());
                                lvv.SubItems.Add(drr[8].ToString());
                                lvv.SubItems.Add(drr[9].ToString());
                                lvv.SubItems.Add(drr[5].ToString());
                                lvv.SubItems.Add(drr[10].ToString());
                                lvv.SubItems.Add(drr[11].ToString());
                                
                                lvSSS.Items.Add(lvv);
                                txtSSSamount.Text = drr[3].ToString();
                                txtSSSMosPayment.Text = drr[5].ToString();
                                txtSSSStartofPayment.Text = drr[7].ToString();
                                txtSSSTotalPayment.Text = drr[6].ToString();
                                ListViewItem ID = new ListViewItem(drr[0].ToString());
                                lvSSSID.Items.Add(ID);
                            }
                        }
                        read.Close();
                        sql = "SELECT * FROM tb_LoanPG WHERE employeeID like'" + txtEmployeeID.Text + "'";
                        cmd = new SqlCommand(sql, cnn);
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            read.Close();
                            lvPG.View = View.Details;
                            SqlDataAdapter dap = new SqlDataAdapter(sql, cnn);
                            DataTable dt = new DataTable();
                            dap.Fill(dt);
                            for (int z = 0; z < dt.Rows.Count; z++)
                            {

                                DataRow drr = dt.Rows[z];
                                ListViewItem lvv = new ListViewItem(drr[2].ToString());
                                lvv.SubItems.Add(drr[8].ToString());
                                lvv.SubItems.Add(drr[9].ToString());
                                lvv.SubItems.Add(drr[5].ToString());
                                lvv.SubItems.Add(drr[10].ToString());
                                lvv.SubItems.Add(drr[11].ToString());
                                lvPG.Items.Add(lvv);

                                txtPGAmount.Text = drr[3].ToString();
                                txtPGMosPay.Text = drr[5].ToString();
                                txtPGStartOfPayment.Text = drr[7].ToString();
                                txtPGTotalPay.Text = drr[6].ToString();
                                ListViewItem ID = new ListViewItem(drr[0].ToString());
                                lvPGID.Items.Add(ID);

                            }

                        }


                    }
                    else
                    {
                        MessageBox.Show("Employee must be regular to have loans!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Please make sure you input the right employee id.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            PGdisable();
            SSSdisable();
            btnUpdate.Enabled = false;
            

        }

        private void txtSSSReleaseDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '/';
        }

        private void lvPG_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGeneratePG_Click(object sender, EventArgs e)
        {
            try
            {
                lvSSS.Items.Clear();
                if ((txtPGAmount.Text != "" && txtPGMosPay.Text != "" ))//
                {
                    mospay = Convert.ToDouble(txtPGMosPay.Text);//
                    total = mospay * 24;
                    DateTime sop = Convert.ToDateTime(dtPGDOR.Value.ToString("MM/dd/yyyy"));//
                    DateTime sops = sop.AddMonths(2);
                    DateTime www = sop.AddMonths(1);
                    txtPGTotalPay.Text = total.ToString();//
                    txtPGStartOfPayment.Text = sops.ToString("MM/dd/yyyy");//
                    mospay = mospay / 2;
                    if ((sops.Day >= 20 && sops.Day <= 31))
                    {
                        DateTime yearr = new DateTime(www.Year, sops.Month, 20);
                        int okay = 0;
                        for (int z = 0; z < 48; z++)
                        {

                            ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                            lvi.SubItems.Add((z + 1).ToString());
                            if (okay == 0)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                okay = 1;
                            }
                            else if (okay == 1)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                okay = 0;
                            }

                            lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                            if (okay == 1)
                            {
                                yearr = yearr.AddMonths(1);
                            }
                            lvi.SubItems.Add(mospay.ToString());
                            lvi.SubItems.Add(total.ToString());
                            total = total - mospay;
                            lvi.SubItems.Add(total.ToString());
                            lvPG.Items.Add(lvi);//
                        }
                    }
                    else if (sops.Day <= 20 && sops.Day >= 5)
                    {
                        DateTime yearr = new DateTime(www.Year, sops.Month, 05);
                        int okay = 1;
                        for (int z = 0; z < 48; z++)
                        {


                            ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                            lvi.SubItems.Add((z + 1).ToString());
                            if (okay == 0)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                okay = 1;
                            }
                            else if (okay == 1)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                okay = 0;
                            }

                            lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                            if (okay == 1)
                            {
                                yearr = yearr.AddMonths(1);
                            }


                            lvi.SubItems.Add(mospay.ToString());

                            lvi.SubItems.Add(total.ToString());
                            total = total - mospay;
                            lvi.SubItems.Add(total.ToString());
                            lvPG.Items.Add(lvi);//
                        }
                    }
                    else if (sops.Day >= 1 && sops.Day <= 4)
                    {
                        DateTime yearr = new DateTime(www.Year, www.Month, 20);
                        int okay = 1;
                        for (int z = 0; z < 48; z++)
                        {


                            ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                            lvi.SubItems.Add((z + 1).ToString());
                            if (okay == 0)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                okay = 1;
                            }
                            else if (okay == 1)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                okay = 0;
                            }
                            lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                            if (okay == 1)
                            {
                                yearr = yearr.AddMonths(1);
                            }
                            lvi.SubItems.Add(mospay.ToString());
                            lvi.SubItems.Add(total.ToString());
                            total = total - mospay;
                            lvi.SubItems.Add(total.ToString());
                            lvPG.Items.Add(lvi);//
                        }
                    }
                    btnSubmit.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnFind.PerformClick();
            }
        }

        private void btnGenerateSSS_Click(object sender, EventArgs e)
        {
            try
            {
                lvSSS.Items.Clear();
                if (txtSSSamount.Text != "" && txtSSSMosPayment.Text != "" )//
                {
                    mospay = Convert.ToDouble(txtSSSMosPayment.Text);//
                    total = mospay * 24;
                    DateTime sop = Convert.ToDateTime(dtSSSRelease.Value.ToString("MM/dd/yyyy"));//
                    DateTime sops = sop.AddMonths(2);
                    DateTime www = sop.AddMonths(1);
                    txtSSSTotalPayment.Text = total.ToString();//
                    txtSSSStartofPayment.Text = sops.ToString("MM/dd/yyyy");//
                    mospay = mospay / 2;
                    if ((sops.Day >= 20 && sops.Day <= 31))
                    {
                        DateTime yearr = new DateTime(www.Year, sops.Month, 20);
                        int okay = 0;
                        for (int z = 0; z < 48; z++)
                        {

                            ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                            lvi.SubItems.Add((z + 1).ToString());
                            if (okay == 0)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                okay = 1;
                            }
                            else if (okay == 1)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                okay = 0;
                            }

                            lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                            if (okay == 1)
                            {
                                yearr = yearr.AddMonths(1);
                            }
                            lvi.SubItems.Add(mospay.ToString());
                            lvi.SubItems.Add(total.ToString());
                            total = total - mospay;
                            lvi.SubItems.Add(total.ToString());
                            lvSSS.Items.Add(lvi);//
                        }
                    }
                    else if (sops.Day <= 20 && sops.Day >= 5)
                    {
                        DateTime yearr = new DateTime(www.Year, sops.Month, 05);
                        int okay = 1;
                        for (int z = 0; z < 48; z++)
                        {


                            ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                            lvi.SubItems.Add((z + 1).ToString());
                            if (okay == 0)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                okay = 1;
                            }
                            else if (okay == 1)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                okay = 0;
                            }

                            lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                            if (okay == 1)
                            {
                                yearr = yearr.AddMonths(1);
                            }


                            lvi.SubItems.Add(mospay.ToString());

                            lvi.SubItems.Add(total.ToString());
                            total = total - mospay;
                            lvi.SubItems.Add(total.ToString());
                            lvSSS.Items.Add(lvi);//
                        }
                    }
                    else if (sops.Day >= 1 && sops.Day <= 4)
                    {
                        DateTime yearr = new DateTime(www.Year, www.Month, 20);
                        int okay = 1;
                        for (int z = 0; z < 48; z++)
                        {


                            ListViewItem lvi = new ListViewItem(txtEmployeeID.Text);
                            lvi.SubItems.Add((z + 1).ToString());
                            if (okay == 0)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 20);
                                okay = 1;
                            }
                            else if (okay == 1)
                            {
                                yearr = new DateTime(yearr.Year, yearr.Month, 05);
                                okay = 0;
                            }

                            lvi.SubItems.Add(yearr.ToString("MM/dd/yyyy"));
                            if (okay == 1)
                            {
                                yearr = yearr.AddMonths(1);
                            }


                            lvi.SubItems.Add(mospay.ToString());

                            lvi.SubItems.Add(total.ToString());
                            total = total - mospay;
                            lvi.SubItems.Add(total.ToString());
                            lvSSS.Items.Add(lvi);//
                        }
                    }
                    btnSubmit.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Please fill up all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void txtSSSamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = sender as TextBox;
            char ch = e.KeyChar;
            decimal x;
            if (ch == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (!char.IsDigit(ch) && ch != '.' || !Decimal.TryParse(box.Text + ch, out x))
            {
                e.Handled = true;
            }
        }
    }
}
