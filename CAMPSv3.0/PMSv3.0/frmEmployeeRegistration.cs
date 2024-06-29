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
using System.IO.MemoryMappedFiles;
using System.IO;


namespace PMSv3._0
{
    public partial class frmEmployeeRegistration : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter dr;
        SqlDataReader read;
        frmLogin login = new frmLogin();
        Random rand = new Random();
        public OpenFileDialog dlg;
        public string okay = "OKAY";
        public string imgLoc = "";
        public string sql = "";
        public string leave = "";
        int max = 0;
        string holder = "";

        public frmEmployeeRegistration()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();

        }
        public void cmbPositions()
        {
            cmbPosition.Items.Add("Instructor");
            cmbPosition.Items.Add("Registrar");
            cmbPosition.Items.Add("Cashier");
            cmbPosition.Items.Add("Human Resource");
            cmbPosition.Items.Add("Finance");
        }
        public void cmbDepartments()
        {
            cmbDepartment.Items.Add("Faculty");
            cmbDepartment.Items.Add("Admin");

        }
        public void cmbTOC()
        {
            cmbContract.Items.Add("Regular");
            cmbContract.Items.Add("Full Time");
            cmbContract.Items.Add("Part Time");
        }
        public void Status()
        {
            cmbEmpStatus.Items.Add("Active");
            cmbEmpStatus.Items.Add("Inactive");
            cmbEmpStatus.Items.Add("Terminated");
        }
        public void gender()
        {
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Others");
        }
        public void rd()
        {
            cmbRD.Items.Add("Monday");
            cmbRD.Items.Add("Tuesday");
            cmbRD.Items.Add("Wednesday");
            cmbRD.Items.Add("Thursday");
            cmbRD.Items.Add("Friday");
            cmbRD.Items.Add("Saturday");
            cmbRD.Items.Add("Sunday");
        }
        public void Maritalstatuss()
        {
            cmbMaritalStatus.Items.Add("Single");
            cmbMaritalStatus.Items.Add("Married");
            cmbMaritalStatus.Items.Add("Widowed");
            cmbMaritalStatus.Items.Add("Divorced");
        }
      
        public void clear()
        {
            txtEmployeeID.Clear();
            txtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            cmbGender.SelectedIndex = -1;
            txtAge.Clear();
            dtDateOfBirth.Text = "";
            cmbPosition.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbContract.SelectedIndex = -1;
            cmbEmpStatus.SelectedIndex = -1;
            cmbRD.SelectedIndex = -1;
            cmbMaritalStatus.SelectedIndex = -1;
            txtAddress.Clear();
            txtTin.Clear();
            txtSSS.Clear();
            txtPagibig.Clear();
            dtDateHired.Text = "";
            txtPhilHealth.Clear();
            pbEmployeeID.Image = null;
            ckInfo.Checked = false;
            txtbasicpay.Clear();
            txtpass.Clear();
            dtDateOfBirth.Text = DateTime.Today.ToString("MMM/dd/yyyy");
            dtDateHired.Text = DateTime.Today.ToString("MMM/dd/yyyy");

        }
        public void Disable()
        {
            txtEmployeeID.Enabled = false;
            txtFname.Enabled = false;
            txtLname.Enabled = false;
            txtMname.Enabled = false;
            cmbGender.Enabled = false;
            txtAge.Enabled = false;
            dtDateOfBirth.Enabled = false;
            cmbPosition.Enabled = false;
            cmbDepartment.Enabled = false;
            cmbContract.Enabled = false;
            cmbEmpStatus.Enabled = false;
            txtAddress.Enabled = false;
            txtTin.Enabled = false;
            txtSSS.Enabled = false;
            txtPagibig.Enabled = false;
            txtPhilHealth.Enabled = false;
            btnBrowse.Enabled = false;
            dtDateHired.Enabled = false;
            ckInfo.Enabled = false;
            txtpass.Enabled = false;
            cmbRD.Enabled = false;
            txtbasicpay.Enabled = false;
            cmbMaritalStatus.Enabled = false;
        }
        public void Enable()
        {
            txtEmployeeID.Enabled = true;
            txtFname.Enabled = true;
            txtLname.Enabled = true;
            txtMname.Enabled = true;
            cmbGender.Enabled = true;
            txtAge.Enabled = true;
            dtDateOfBirth.Enabled = true;
            cmbPosition.Enabled = true;
            cmbDepartment.Enabled = true;
            cmbContract.Enabled = true;
            cmbEmpStatus.Enabled = true;
            txtAddress.Enabled = true;
            txtTin.Enabled = true;
            txtSSS.Enabled = true;
            txtPagibig.Enabled = true;
            txtPhilHealth.Enabled = true;
            btnBrowse.Enabled = true;
            dtDateHired.Enabled = true;
            ckInfo.Enabled = true;
            txtbasicpay.Enabled = true;
            txtPassword.Enabled = true;
            cmbRD.Enabled = true;
            txtpass.Enabled = true;
            cmbMaritalStatus.Enabled = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_Employee WHERE EmployeeID like'" + txtFind.Text + "'";
                cmd = new SqlCommand(sql, cnn);

                read = cmd.ExecuteReader();
                read.Read();
                if (read.HasRows)
                {
                    txtEmployeeID.Text = read[0].ToString();
                    txtFname.Text = read[1].ToString();
                    txtMname.Text = read[2].ToString();
                    txtLname.Text = read[3].ToString();
                    cmbGender.Text = read.GetValue(4).ToString();
                    txtAddress.Text = read.GetValue(5).ToString();
                    dtDateOfBirth.Text = read.GetValue(6).ToString();
                    txtAge.Text = read.GetValue(7).ToString();
                    cmbMaritalStatus.Text = read.GetValue(8).ToString();
                    txtTin.Text = read.GetValue(9).ToString();
                    txtSSS.Text = read.GetValue(10).ToString();
                    txtPagibig.Text = read.GetValue(11).ToString();
                    txtPhilHealth.Text = read.GetValue(12).ToString();
                    dtDateHired.Text = read.GetValue(13).ToString();
                    txtbasicpay.Text = read.GetValue(14).ToString();
                    txtpass.Text = read.GetValue(15).ToString();
                    cmbRD.Text = read.GetValue(16).ToString();
                        byte[] img = (byte[])(read[17]);
                        if (img != null)
                        {
                            MemoryStream ms = new MemoryStream(img);
                            pbEmployeeID.Image = Image.FromStream(ms);
                        }
                    cmbDepartment.Text = read.GetValue(18).ToString();
                    cmbPosition.Text = read.GetValue(19).ToString();
                    cmbContract.Text = read.GetValue(20).ToString();
                    cmbEmpStatus.Text = read.GetValue(21).ToString();
                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                    btnNew.Enabled = false;
                    Enable();
                    read.Close();
                    txtPassword.ReadOnly = false;
                    okay = "OKAY";
                }
                else
                {
                    MessageBox.Show("Please make sure you input the correct employee ID!");

                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR!" + ex);
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar);
            }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Enable();
            btnNew.Visible = false;
            btnSave.Visible = true;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            try
            {

                string z = DateTime.Now.ToString("yy");
                sql = "SELECT COUNT(*) FROM tb_Employee ";
                cmd = new SqlCommand(sql, cnn);
                int counts = Convert.ToInt32(cmd.ExecuteScalar());

                int id = 10000;
                for (int i = 0; i <= counts; i++)
                {
                    id += 1;
                }
                txtEmployeeID.Text = z + id.ToString();
                //password
                string x = "";
                for (int y = 0; y <= 6; y++)
                {

                    x += Convert.ToString(rand.Next(0, 9));

                }
                txtpass.Text = x.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!!! " + ex);

            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Select Employee Picture";
                    dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        imgLoc = dlg.FileName.ToString();
                        pbEmployeeID.Image = Image.FromFile(dlg.FileName);
                        okay = "NOTOKAY";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant open file sorry!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            Disable();
            btnSave.Visible = false;
            btnNew.Visible = true;
            btnNew.Enabled = true;
            txtPassword.ReadOnly = true;
        }

        private void txtTin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSSS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPagibig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPhilHealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtbasicpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string tin = txtTin.Text, sss = txtSSS.Text, philhealth = txtPhilHealth.Text, pagibig = txtPagibig.Text;
                DialogResult save = MessageBox.Show("Are you sure you want to save?", "Payroll Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (save == DialogResult.Yes)
                {

                    if (ckInfo.Checked == true)
                    {
                        if (txtFname.Text == "" || txtLname.Text == "" || txtAddress.Text == "" || txtAge.Text == "" || cmbMaritalStatus.Text == "" || txtbasicpay.Text == "" || txtbasicpay.Text == "" || txtpass.Text == "" || dtDateOfBirth.Text == "" || cmbPosition.Text == "" || cmbDepartment.Text == "" || cmbContract.Text == "" || cmbEmpStatus.Text == "" || dtDateHired.Text == ""||cmbRD.Text=="")
                        {
                            MessageBox.Show("Please fill up all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtTin.Text == "" || txtSSS.Text == "" || txtPagibig.Text == "" || txtPhilHealth.Text == "")
                        {
                            if (txtTin.Text == "" || txtTin.Text == null)
                            {
                                tin = "N/A";
                            }
                            if (txtSSS.Text == "" || txtSSS.Text == null)
                            {
                                sss = "N/A";
                            }
                            if (txtPhilHealth.Text == "" || txtPhilHealth.Text == null)
                            {
                                philhealth = "N/A";
                            }
                            if (txtPagibig.Text == "" || txtPagibig.Text == null)
                            {
                                pagibig = "N/A";
                            }
                            if (pbEmployeeID.Image == null)
                            {
                                lbpicture.ForeColor = Color.Red;
                                MessageBox.Show("Please select Employee image first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                byte[] img = null;
                                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                img = br.ReadBytes((int)fs.Length);
                                sql = "INSERT INTO tb_Employee(EmployeeID,Fname,Mname,Lname,gender,address,bday,age,maritalStatus,TIN,sss,pagibig,philhealth,dtHired,basicpay,password,rd,empPic,dpartment,position,contract,status) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + txtMname.Text + "','" + txtLname.Text + "','" + cmbGender.Text + "','" + txtAddress.Text + "','" + dtDateOfBirth.Text + "','" + txtAge.Text + "','" + cmbMaritalStatus.Text + "','" + tin + "','" + sss + "','" + pagibig + "','" + philhealth + "','" + dtDateHired.Text + "','" + txtbasicpay.Text + "','" + txtpass.Text + "','" + cmbRD.Text + "',@img, '" + cmbDepartment.Text + "','" + cmbPosition.Text + "','" + cmbContract.Text + "','" + cmbEmpStatus.Text + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.Parameters.Add(new SqlParameter("@img", img));
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Employee Record Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Dispose();
                                string status = "ACTIVE", attmps = "0";
                                sql = "INSERT INTO tb_EmployeeUSER(EmployeeID,employeePassword,Status,Attmps) VALUES('" + txtEmployeeID.Text + "','" + txtpass.Text + "','" + status + "','" + attmps + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();

                                if (cmbDepartment.Text == "Admin")
                                {
                                    //'07:00 AM','04:00 PM','8'
                                    if (cmbRD.Text == "Monday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','" + cmbRD.Text + "','" + holder + "','" + holder + "','" + holder + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Tuesday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Wednesday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Thursday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Friday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Saturday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Sunday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    {
                                        
                                        sql = "INSERT INTO tb_RemainingLeaves(employeeID,leaveRemaining) VALUES('" + txtEmployeeID.Text + "','15')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();

                                    }

                                }
                                clear();
                                Disable();
                                btnUpdate.Enabled = true;
                                btnNew.Visible = true;

                            }
                        }
                        else
                        {
                            if (txtTin.Text == "" || txtTin.Text == null)
                            {
                                tin = "N/A";
                            }
                            if (txtSSS.Text == "" || txtSSS.Text == null)
                            {
                                sss = "N/A";
                            }
                            if (txtPhilHealth.Text == "" || txtPhilHealth.Text == null)
                            {
                                philhealth = "N/A";
                            }
                            if (txtPagibig.Text == "" || txtPagibig.Text == null)
                            {
                                pagibig = "N/A";
                            }
                            if (pbEmployeeID.Image == null)
                            {
                                lbpicture.ForeColor = Color.Red;
                                MessageBox.Show("Please select Employee image first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {

                                byte[] img = null;
                                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                img = br.ReadBytes((int)fs.Length);
                                sql = "INSERT INTO tb_Employee(EmployeeID,Fname,Mname,Lname,gender,address,bday,age,maritalStatus,TIN,sss,pagibig,philhealth,dtHired,basicpay,password,rd,empPic,dpartment,position,contract,status) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + txtMname.Text + "','" + txtLname.Text + "','" + cmbGender.Text + "','" + txtAddress.Text + "','" + dtDateOfBirth.Text + "','" + txtAge.Text + "','" + cmbMaritalStatus.Text + "','" + tin + "','" + sss + "','" + pagibig + "','" + philhealth + "','" + dtDateHired.Text + "','" + txtbasicpay.Text + "','" + txtpass.Text + "','" + cmbRD.Text + "',@img, '" + cmbDepartment.Text + "','" + cmbPosition.Text + "','" + cmbContract.Text + "','" + cmbEmpStatus.Text + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.Parameters.Add(new SqlParameter("@img", img));
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Employee Record Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Dispose();
                                string status = "ACTIVE", attmps = "0";
                                sql = "INSERT INTO tb_EmployeeUSER(EmployeeID,employeePassword,Status,Attmps) VALUES('" + txtEmployeeID.Text + "','" + txtpass.Text + "','" + status + "','" + attmps + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();
                                if (cmbDepartment.Text == "Admin")
                                {
                                    //'07:00 AM','04:00 PM','8'
                                   
                                    if (cmbRD.Text == "Monday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','" + cmbRD.Text + "','" + holder + "','" + holder + "','" + holder + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Tuesday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Wednesday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Thursday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Friday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Saturday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else if (cmbRD.Text == "Sunday")
                                    {
                                        holder = "RESTDAY";
                                        sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();
                                    }

                                    {

                                        sql = "INSERT INTO tb_RemainingLeaves(employeeID,leaveRemaining) VALUES('" + txtEmployeeID.Text+"','15')";
                                        cmd = new SqlCommand(sql, cnn);
                                        cmd.ExecuteNonQuery();

                                    }

                                }
                                clear();
                                Disable();
                                btnUpdate.Enabled = true;
                                btnNew.Visible = true;

                            }
                        }


                    }
                    else if (ckInfo.Checked == false)
                    {

                        if (txtFname.Text == "" || txtLname.Text == "" || txtAddress.Text == "" || txtAge.Text == "" || cmbMaritalStatus.Text == "" || txtbasicpay.Text == "" || txtbasicpay.Text == "" || txtpass.Text == "" || dtDateOfBirth.Text == "" || cmbPosition.Text == "" || cmbDepartment.Text == "" || cmbContract.Text == "" || cmbEmpStatus.Text == "" || dtDateHired.Text == "")
                        {
                            MessageBox.Show("Please fill up all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (txtTin.Text == "" || txtSSS.Text == "" || txtPagibig.Text == "" || txtPhilHealth.Text == "")
                        {
                            MessageBox.Show("Please check the box if the employee does not have complete requirements. Thank you!", "Error");
                        }
                        else if (pbEmployeeID.Image == null)
                        {
                            MessageBox.Show("Please select Employee image first!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {

                            byte[] img = null;
                            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            img = br.ReadBytes((int)fs.Length);
                            sql = "INSERT INTO tb_Employee(EmployeeID,Fname,Mname,Lname,gender,address,bday,age,maritalStatus,TIN,sss,pagibig,philhealth,dtHired,basicpay,password,rd,empPic,dpartment,position,contract,status) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + txtMname.Text + "','" + txtLname.Text + "','" + cmbGender.Text + "','" + txtAddress.Text + "','" + dtDateOfBirth.Text + "','" + txtAge.Text + "','" + cmbMaritalStatus.Text + "','" + tin + "','" + sss + "','" + pagibig + "','" + philhealth + "','" + dtDateHired.Text + "','" + txtbasicpay.Text + "','" + txtpass.Text + "','" + cmbRD.Text + "',@img, '" + cmbDepartment.Text + "','" + cmbPosition.Text + "','" + cmbContract.Text + "','" + cmbEmpStatus.Text + "')";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.Add(new SqlParameter("@img", img));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Record Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmd.Dispose();
                            string status = "ACTIVE", attmps = "0";
                            sql = "INSERT INTO tb_EmployeeUSER(EmployeeID,employeePassword,Status,Attmps) VALUES('" + txtEmployeeID.Text + "','" + txtpass.Text + "','" + status + "','" + attmps + "')";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.ExecuteNonQuery();
                            if (cmbDepartment.Text == "Admin")
                            {
                                //'07:00 AM','04:00 PM','8'
                                if (cmbRD.Text == "Monday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','" + cmbRD.Text + "','" + holder + "','" + holder + "','" + holder + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (cmbRD.Text == "Tuesday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (cmbRD.Text == "Wednesday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (cmbRD.Text == "Thursday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (cmbRD.Text == "Friday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (cmbRD.Text == "Saturday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY','07:00 AM','04:00 PM','8')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (cmbRD.Text == "Sunday")
                                {
                                    holder = "RESTDAY";
                                    sql = "INSERT INTO tb_SummaryOfLoads(empID,empName,Rd,MonIN,MonOut,MonHour,TuesIn,TuesOut,TuesHour,WedIn,WedOut,WedHour,ThurIn,ThurOut,ThurHour,FriIn,FriOut,FriHour,SatIn,SatOut,SatHour,SunIn,SunOut,SunHour) VALUES('" + txtEmployeeID.Text + "','" + txtLname.Text + " " + txtFname.Text + " " + txtMname.Text + "','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','07:00 AM','04:00 PM','8','RESTDAY','RESTDAY','RESTDAY')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();
                                }
                                {


                                    sql = "INSERT INTO tb_RemainingLeaves(employeeID,leaveRemaining) VALUES('" + txtEmployeeID.Text + "','15')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();

                                }
                            }
                            clear();
                            Disable();
                            btnUpdate.Enabled = true;
                            btnNew.Visible = true;
                            btnSave.Visible = false;

                        }
                    }
                }
                else
                {
                    clear();

                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("ERROR!" + ex);
            }
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.Text == "Faculty")
            {
                cmbPosition.Items.Clear();
                cmbPosition.Items.Add("Instructor");
                cmbContract.Items.Clear();
                cmbContract.Items.Add("Full time");
                cmbContract.Items.Add("Part time");
            }
            else if (cmbDepartment.Text == "Admin")
            {
                cmbPosition.Items.Clear();
                cmbPosition.Items.Add("Cashier");
                cmbPosition.Items.Add("Registrar");
                cmbPosition.Items.Add("Human Resource");
                cmbPosition.Items.Add("Finance");
                cmbContract.Items.Clear();
                cmbContract.Items.Add("Regular");

            }
        }

        private void cmbPosition_DropDown(object sender, EventArgs e)
        {
            if (cmbPosition.Items.Count == 0)
            {
                MessageBox.Show("Please choose department first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                cmbDepartment.DroppedDown = true;
            }
        }

        private void dtDateOfBirth_Leave(object sender, EventArgs e)
        {
            max = DateTime.Now.Year - dtDateOfBirth.Value.Year;
            if (max >= 19)
            {
                TimeSpan age = DateTime.Now - dtDateOfBirth.Value;
                int years = DateTime.Now.Year - dtDateOfBirth.Value.Year;
                if (dtDateOfBirth.Value.AddYears(years) >= DateTime.Now) years--;
                {
                    if (years <= 18)
                    {
                        MessageBox.Show("The employee is under age!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAge.Clear();

                        lbDateofBirth.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtAge.Text = years.ToString();
                        lbDateofBirth.ForeColor = Color.Black;
                    }
                }
            }
            else
            {
                MessageBox.Show("The employee is under age!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmEmployeeRegistration_Load(object sender, EventArgs e)
        {
            Disable();
            dtDateOfBirth.Text = DateTime.Today.ToString("MMM/dd/yyyy");
            dtDateHired.Text = DateTime.Today.ToString("MMM/dd/yyyy");
            btnSave.Visible = false;
            btnSave.Enabled = true;
            cmbDepartments();
            cmbTOC();
            Status();
            gender();
            rd();
            Maritalstatuss();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult save = MessageBox.Show("Are you sure you want to save?", "Payroll Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (save == DialogResult.Yes)
            {
                try
                {

                    if (okay == "OKAY")
                    {
                        sql = "UPDATE tb_Employee SET Fname= '" + txtFname.Text + "',Mname='"+txtMname.Text+ "',Lname='"+txtLname.Text+"', gender= '" + cmbGender.Text + "', address= '" + txtAddress.Text + "', bday= '" + dtDateOfBirth.Text + "', age= '" + txtAge.Text + "',maritalStatus='"+cmbMaritalStatus.Text+"', TIN= '" + txtTin.Text + "', sss= '" + txtSSS.Text + "' , pagibig= '" + txtPagibig.Text + "', philhealth= '" + txtPhilHealth.Text + "', dtHired= '" + dtDateHired.Text + "', basicpay= '" + txtbasicpay.Text + "', password= '" + txtpass.Text + "', rd= '" + cmbRD.Text + "', dpartment= '" + cmbDepartment.Text + "', position= '" +cmbPosition.Text + "', contract= '" + cmbContract.Text + "', status= '" + cmbEmpStatus.Text + "' WHERE EmployeeID like'" + txtEmployeeID.Text + "' ";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Data has been updated!", "Successful");
                        cmd.Dispose();
                        clear();
                        Disable();
                        read.Close();
                        txtPassword.ReadOnly = true;
                        btnUpdate.Enabled = false;
                        btnSave.Enabled = true;
                        btnNew.Enabled = true;
                    }
                    else if (okay == "NOTOKAY")
                    {
                        byte[] img = null;
                        FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);
                        sql = "UPDATE tb_Employee SET Fname= '" + txtFname.Text + "',Mname='" + txtMname.Text + "',Lname='" + txtLname.Text + "', gender= '" + cmbGender.Text + "', address= '" + txtAddress.Text + "', bday= '" + dtDateOfBirth.Text + "', age= '" + txtAge.Text + "',maritalStatus='" + cmbMaritalStatus.Text + "', TIN= '" + txtTin.Text + "', sss= '" + txtSSS.Text + "' , pagibig= '" + txtPagibig.Text + "', philhealth= '" + txtPhilHealth.Text + "', dtHired= '" + dtDateHired.Text + "', basicpay= '" + txtbasicpay.Text + "', password= '" + txtpass.Text + "', rd= '" + cmbRD.Text + "', dpartment= '" + cmbDepartment.Text + "', position= '" + cmbPosition.Text + "', contract= '" + cmbContract.Text + "', status= '" + cmbEmpStatus.Text + "',empPic=@img WHERE EmployeeID like'" + txtEmployeeID.Text + "' ";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.AddWithValue("@img", img);
                        cmd.Parameters.AddWithValue("@basicRate", txtBasicRate.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Data has been updated!", "Successful");
                        cmd.Dispose();
                        clear();
                        Disable();
                        read.Close();
                        txtPassword.ReadOnly = true;
                        btnUpdate.Enabled = false;
                        btnSave.Enabled = true;
                        btnNew.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!  " + ex);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbContract_DropDown(object sender, EventArgs e)
        {
            if (cmbContract.Items.Count == 0)
            {
                MessageBox.Show("Please choose department first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                cmbDepartment.DroppedDown = true;
            }
        }

        private void cmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnFind.PerformClick();
            }
        }
    }
}
