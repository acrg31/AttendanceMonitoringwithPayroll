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
using System.Windows;

namespace PMSv3._0
{
    public partial class frmHoliday : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter dr;
        SqlDataReader read;
        frmLogin login = new frmLogin();

        public string sql = "";


        public frmHoliday()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }
        public void Type()
        {
            cmbType.Items.Add("Special");
            cmbType.Items.Add("Legal");
        }
        public void Month()
        {
            cmbMonth.Items.Add("JANUARY");
            cmbMonth.Items.Add("FEBRUARY");
            cmbMonth.Items.Add("MARCH");
            cmbMonth.Items.Add("APRIL");
            cmbMonth.Items.Add("MAY");
            cmbMonth.Items.Add("JUNE");
            cmbMonth.Items.Add("JULY");
            cmbMonth.Items.Add("AUGUST");
            cmbMonth.Items.Add("SEPTEMBER");
            cmbMonth.Items.Add("OCTOBER");
            cmbMonth.Items.Add("NOVEMBER");
            cmbMonth.Items.Add("DECEMBER");
        }
        public void Days()
        {
            cmbDays.Items.Add("1");
            cmbDays.Items.Add("2");
            cmbDays.Items.Add("3");
            cmbDays.Items.Add("4");
            cmbDays.Items.Add("5");
            cmbDays.Items.Add("6");
            cmbDays.Items.Add("7");
            cmbDays.Items.Add("8");
            cmbDays.Items.Add("9");
            cmbDays.Items.Add("10");
            cmbDays.Items.Add("11");
            cmbDays.Items.Add("12");
            cmbDays.Items.Add("13");
            cmbDays.Items.Add("14");
            cmbDays.Items.Add("15");
            cmbDays.Items.Add("16");
            cmbDays.Items.Add("17");
            cmbDays.Items.Add("18");
            cmbDays.Items.Add("19");
            cmbDays.Items.Add("20");
            cmbDays.Items.Add("21");
            cmbDays.Items.Add("22");
            cmbDays.Items.Add("23");
            cmbDays.Items.Add("24");
            cmbDays.Items.Add("25");
            cmbDays.Items.Add("26");
            cmbDays.Items.Add("27");
            cmbDays.Items.Add("28");
            

        }
        private void FrmHoliday_Load(object sender, EventArgs e)
        {
            Type();
            Month();

            sql = "SELECT HolidayID as [ID], dtMonth as [MONTH], dtDays as [DAYS], description as [DESCRIPTION], Type as [TYPE] FROM tb_Holiday";

            cmd = new SqlCommand(sql, cnn);
            dr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            dgHoliday.DataSource = dt;
            //
            //

            cmbDays.Enabled = false;
            cmbMonth.Enabled = false;
            txtDescription.Enabled = false;
            cmbType.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Visible = false;
            cmbDays.Text = "";
            cmbMonth.Text = "";
        }
        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                int id = 0;
                sql = "SELECT * FROM tb_Holiday WHERE description like '" + txtDescription.Text + "' AND  dtMonth like '" + cmbMonth.Text + "' AND dtDays like'" + cmbDays.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("Holiday has already been added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    read.Close();
                    try
                    {
                        sql = "SELECT COUNT(*) FROM tb_Holiday";
                        cmd = new SqlCommand(sql, cnn);
                        int counts = Convert.ToInt32(cmd.ExecuteScalar());
                        for (int i = 0; i <= counts; i++)
                        {
                            id += 1;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error!!! " + ex);
                    }
                    try
                    {
                        read.Close();
                     sql = "INSERT INTO tb_Holiday(HolidayID,dt,description,Type,dtMonth,dtDays) VALUES('" + id.ToString() + "','" + Convert.ToDateTime(cmbMonth.Text + "/" + cmbDays.Text).ToString("MMMM/dd") + "','" + txtDescription.Text + "','" + cmbType.Text +"','"+cmbMonth.Text+"','"+cmbDays.Text+ "')";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Holiday Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR!" + ex);
                    }
                }
                txtDescription.Clear();
                cmbType.Items.Clear();
                cmbMonth.Items.Clear();
                cmbDays.Items.Clear();
                read.Close();
                FrmHoliday_Load(sender, e);
                btnAdd.Visible = true;
                btnSave.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }
        }
            
        
        private void BtnEdit_Click_1(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_Holiday WHERE description like '" + txtDescription.Text + "' AND  dtMonth like '" + cmbMonth.Text + "' AND dtDays like'" + cmbDays.Text + "'";
                cmd = new SqlCommand(sql, cnn);
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("Holiday has already been added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                { 
                    read.Close();
                    sql = "UPDATE tb_Holiday SET dt= '" + Convert.ToDateTime(cmbMonth.Text + "/" + cmbDays.Text).ToString("MMMM/dd") + "', description= '" + txtDescription.Text + "', Type= '" + cmbType.Text + "', dtMonth='" + cmbMonth.Text + "', dtDays='" + cmbDays.Text + "' WHERE HolidayID like '" + lvlID.Text + "'";
                    cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Holiday has been updated!", "Successful");
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!  " + ex);
            }
            txtDescription.Clear();
            cmbType.Items.Clear();
            cmbMonth.Items.Clear();
            cmbDays.Items.Clear();
            btnAdd.Enabled = true;
            read.Close();
            FrmHoliday_Load(sender, e);

        }
        private void BtnClear_Click_1(object sender, EventArgs e)
        {
            txtDescription.Clear();
            cmbType.Items.Clear();
            Type();
            cmbDays.Items.Clear();
            cmbMonth.Items.Clear();
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnAdd.Enabled = true;
            btnAdd.Visible = true;
        }

        private void DgHoliday_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow Row = dgHoliday.Rows[e.RowIndex];

                //        dtDate.Text = Row.Cells[1].Value.ToString();
                // MessageBox.Show(Convert.ToDateTime(cmbMonth.Text+"/"+cmbDays.Text).ToString());

                //(Convert.ToDateTime(Row.Cells[1].Value)).Month.ToString();
                //cmbMonth.Text = (Convert.ToDateTime(Row.Cells[1].Value)).Month.ToString();




                cmbMonth.Text = Row.Cells[1].Value.ToString();
                cmbDays.Text = Row.Cells[2].Value.ToString();
                txtDescription.Text = Row.Cells[3].Value.ToString();
                cmbType.Text = Row.Cells[4].Value.ToString();
               
                lvlID.Text = Row.Cells[0].Value.ToString();

                lvlID.Visible = false;
                txtDescription.Enabled = true;
                cmbMonth.Enabled = true;
                cmbDays.Enabled = true;
                cmbType.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnAdd.Enabled = false;
                btnAdd.Visible = true;
            }
        }

        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
           
            txtDescription.Enabled = true;
            cmbType.Enabled = true;
            cmbMonth.Enabled = true;
            cmbDays.Enabled = true;
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnSave.Enabled = true;
            

        }

        private void CmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void cmbMonth_TextChanged(object sender, EventArgs e)
        {
            if (cmbMonth.Text == "JANUARY")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            else if (cmbMonth.Text == "FEBRUARY")
            {

                cmbDays.Items.Clear();
                Days();
            }
            else if (cmbMonth.Text == "MARCH")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            else if (cmbMonth.Text == "APRIL")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");

            }
            else if (cmbMonth.Text == "MAY")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            else if (cmbMonth.Text == "JUNE")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");

            }
            else if (cmbMonth.Text == "JULY")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            else if (cmbMonth.Text == "AUGUST")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            else if (cmbMonth.Text == "SEPTEMBER")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
            }
            else if (cmbMonth.Text == "OCTOBER")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            else if (cmbMonth.Text == "NOVEMBER")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
            }
            else if (cmbMonth.Text == "DECEMBER")
            {
                cmbDays.Items.Clear();
                Days();
                cmbDays.Items.Add("29");
                cmbDays.Items.Add("30");
                cmbDays.Items.Add("31");
            }
            
        }
    }
}
