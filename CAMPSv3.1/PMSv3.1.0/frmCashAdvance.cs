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
    public partial class frmCashAdvance : Form
    {
        string connection = @"Data Source=DESKTOP-VM6B8T2;Initial Catalog=Payroll2.0 ;Integrated Security=True";
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader reader;
        string sql = "";
        public frmCashAdvance()
        {
            InitializeComponent();
            con = new SqlConnection(connection);
            con.Open();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvRecord.Visible == false)
            {
                dgvRecord.Visible = true;
            }
            else
            {
                dgvRecord.Visible = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            sql = "Select * from tb_CashAdvance where employeeID like '" + txtID.Text + "' and empName like '" + txtName.Text + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rd = cmd.ExecuteReader();

            rd.Read();
            if (rd.HasRows)
            {
                if (rd.GetValue(3).ToString() == "Pending")
                {
                    MessageBox.Show("You already have request","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rd.Close();
                }
                else
                {
                    if (txtAmount.Text == "")
                    {
                        MessageBox.Show("Input Cash Advance","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Focus();
                        rd.Close();
                    }
                    else if (int.Parse(txtAmount.Text) < 1000 || int.Parse(txtAmount.Text) > 5000)
                    {
                        MessageBox.Show("Minimum of 1000 and maximum of 5000!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAmount.Focus();
                        txtAmount.Clear();
                        rd.Close();
                    }
                    else
                    {
                        try
                        {
                            rd.Close();
                            SqlConnection con1 = new SqlConnection(connection);
                            string sql1 = "INSERT INTO tb_CashAdvance VALUES('" + txtID.Text + "','" + txtName.Text + "','" + txtAmount.Text + "','" + lDate.Text + "','Pending')";
                            SqlCommand cmd1 = new SqlCommand(sql1, con1);
                            con1.Open();
                            cmd1.ExecuteNonQuery();
                            MessageBox.Show("Cash Advance Send!","Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            con1.Close();
                            txtAmount.Clear();
                            txtAmount.Focus();
                            View1();
                            rd.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }

                }
            }
            else
            {
                if (txtAmount.Text == "")
                {
                    MessageBox.Show("Input Cash Advance","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    rd.Close();
                }
                else if (int.Parse(txtAmount.Text) < 1000 || int.Parse(txtAmount.Text) > 5000)
                {
                    MessageBox.Show("Minimum of 1000 and maximum of 5000!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Focus();
                    txtAmount.Clear();
                    rd.Close();
                }
                else
                {
                    try
                    {
                        rd.Close();
                        SqlConnection con1 = new SqlConnection(connection);
                        string sql1 = "INSERT INTO tb_CashAdvance VALUES('" + txtID.Text + "','" + txtName.Text + "','" + txtAmount.Text + ".00" + "','" + lDate.Text + "','Pending')";
                        SqlCommand cmd1 = new SqlCommand(sql1, con1);
                        con1.Open();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Cash Advance Send!","Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con1.Close();
                        txtAmount.Clear();
                        txtAmount.Focus();
                        View1();
                        rd.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                }
            }
           
            rd.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != 8 ? true : false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lDate.Text = DateTime.Now.ToLongDateString();
        }

        private void frmCashAdvance_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            View();
            View1();
        }

        private void View()
        {
            sql = "Select * from tb_RegisterEmployee where employeeID like '" + txtID.Text + "'";
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
            {
                txtName.Text = reader["LName"].ToString() + ", " + reader["FName"].ToString() + " " + reader["MName"].ToString();

                reader.Close();
            }
        }

        private void View1()
        {
            dgvRecord.Columns.Clear();
            string sql = "Select employeeID AS [Employee ID], dt AS [Date], status AS [Status] from tb_CashAdvance where employeeID like '" + txtID.Text + "' ";
            cmd = new SqlCommand(sql, con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            try
            {
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dgvRecord.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
