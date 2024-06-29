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
    public partial class frmRegisterEmployee : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataAdapter dr;
        SqlDataReader read;
        frmLogin login = new frmLogin();
        Random rand = new Random();

        public string imgLoc = "";
        public string sql = "";
        public string leave = "";
        int max = 0;
        public frmRegisterEmployee()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }
        private void frmRegisterEmployee_Load(object sender, EventArgs e)
        {
            Disable();
            ButtonDisable();
            dtDateOfBirth.Text = DateTime.Today.ToString("MMM/dd/yyyy") ;
            dtDateHired.Text = DateTime.Today.ToString("MMM/dd/yyyy");

            cmbDepartments();
            cmbTOC();
            Status();
            gender();
            CivilStatus();
        }
        public void ButtonDisable()
        {
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
        }
        public void cmbPositions()
        {
            cmbPosition.Items.Add("Teacher");
            cmbPosition.Items.Add("Registrar");
            cmbPosition.Items.Add("Cashier");
            cmbPosition.Items.Add("Maintenance");
            
        }
        public void cmbDepartments()
        {
            cmbDepartment.Items.Add("Faculty");
            cmbDepartment.Items.Add("Admin");
            cmbDepartment.Items.Add("Staff");

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
        public void CivilStatus()
        {
            cmbCivilStatus.Items.Add("Single");
            cmbCivilStatus.Items.Add("Married");
            cmbCivilStatus.Items.Add("Divorced");
            cmbCivilStatus.Items.Add("Widowed");
        }
        public void clear()
        {
            txtEmployeeID.Clear();
            txtFname.Clear();
            TxtMname.Clear();
            txtLname.Clear();
            cmbCivilStatus.Items.Clear();
            cmbGender.Items.Clear();
            txtMobileNo.Clear();
            txtEmail.Clear();
            txtBirthPlace.Clear();
            txtReligion.Clear();
            txtAge.Clear();
            dtDateOfBirth.Text = "";
            cmbPosition.Items.Clear();
            cmbDepartment.Items.Clear();
            cmbContract.Items.Clear();
            cmbEmpStatus.Items.Clear();
            txtContactName.Clear();
            txtNumber.Clear();
            txtAddressContact.Clear();
            txtCityAddress.Clear();
            txtTin.Clear();
            txtSSS.Clear();
            txtPagibig.Clear();
            dtDateHired.Text = "";
            txtPhilHealth.Clear();
            pbEmployeeID.Image = null;
            ckInfo.Checked = false;
            txtBasicRate.Clear();
            txtPassword.Clear();
            dtDateOfBirth.Text = DateTime.Today.ToString("MMM/dd/yyyy");
            dtDateHired.Text = DateTime.Today.ToString("MMM/dd/yyyy");
            txtCtellno.Clear();
            txtTelNo.Clear();
        }
        public void Disable()
        {
            txtEmployeeID.Enabled = false;
            txtFname.Enabled = false;
            TxtMname.Enabled = false;
            txtLname.Enabled = false;
            cmbCivilStatus.Enabled = false;
            cmbGender.Enabled = false;
            txtMobileNo.Enabled = false;
            txtEmail.Enabled = false;
            txtBirthPlace.Enabled = false;
            txtReligion.Enabled = false;
            txtAge.Enabled = false;
            dtDateOfBirth.Enabled = false;
            cmbPosition.Enabled = false;
            cmbDepartment.Enabled = false;
            cmbContract.Enabled = false;
            cmbEmpStatus.Enabled = false;
            txtContactName.Enabled = false;
            txtNumber.Enabled = false;
            txtAddressContact.Enabled = false;
            txtCityAddress.Enabled = false;
            txtTin.Enabled = false;
            txtSSS.Enabled = false;
            txtPagibig.Enabled = false;
            txtPhilHealth.Enabled = false;
            btnBrowse.Enabled = false;
            dtDateHired.Enabled = false;
            ckInfo.Enabled = false;
            txtBasicRate.Enabled = false;
            txtPassword.Enabled = false;
            txtCtellno.Enabled = false;
            txtTelNo.Enabled = false;
        }
        public void Enable()
        {
            txtEmployeeID.Enabled = true;
            txtFname.Enabled = true;
            TxtMname.Enabled = true;
            txtLname.Enabled = true;
            cmbCivilStatus.Enabled = true;
            cmbGender.Enabled = true;
            txtMobileNo.Enabled = true;
            txtEmail.Enabled = true;
            txtBirthPlace.Enabled = true;
            txtReligion.Enabled = true;
            txtAge.Enabled = true;
            dtDateOfBirth.Enabled = true;
            cmbPosition.Enabled = true;
            cmbDepartment.Enabled = true;
            cmbContract.Enabled = true;
            cmbEmpStatus.Enabled = true;
            txtContactName.Enabled = true;
            txtNumber.Enabled = true;
            txtAddressContact.Enabled = true;
            txtCityAddress.Enabled = true;
            txtTin.Enabled = true;
            txtSSS.Enabled = true;
            txtPagibig.Enabled = true;
            txtPhilHealth.Enabled = true;
            btnBrowse.Enabled = true;
            dtDateHired.Enabled = true;
            ckInfo.Enabled = true;
            txtBasicRate.Enabled = true;
            txtPassword.Enabled = true;
            txtCtellno.Enabled = true;
            txtTelNo.Enabled = true;
        }
        
        public void forecolorBlack()
        {
            lbFname.ForeColor = Color.Black;
            lbLname.ForeColor = Color.Black;
            lbDateHired.ForeColor = Color.Black;
            lbAddress.ForeColor = Color.Black;
            lbAge.ForeColor = Color.Black;
            lbCaddress.ForeColor = Color.Black;
            lbCivilStatus.ForeColor = Color.Black;
            lbCMobile.ForeColor = Color.Black;
            lbCname.ForeColor = Color.Black;
            lbDateofBirth.ForeColor = Color.Black;
            lbDepartmen.ForeColor = Color.Black;
            lbMobileNo.ForeColor = Color.Black;
            lbPagibig.ForeColor = Color.Black;
            lbpassword.ForeColor = Color.Black;
            lbPhilhealth.ForeColor = Color.Black;
            lbpicture.ForeColor = Color.Black;
            lbPosition.ForeColor = Color.Black;
            lbRate.ForeColor = Color.Black;
            lbSSS.ForeColor = Color.Black;
            lbStatus.ForeColor = Color.Black;
            lbTin.ForeColor = Color.Black;
            lbTypeOfContract.ForeColor = Color.Black;
        }
        public OpenFileDialog dlg;
        public string okay = "OKAY";
      

    
      
      
        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void TxtMname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtBirthPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtContactName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click_2(object sender, EventArgs e)
        {
            Enable();
            btnNew.Visible = false;
            btnSave.Visible = true;
            btnSave.Enabled = true;
            try
            {

                string z = DateTime.Now.ToString("yy");
                sql = "SELECT COUNT(*) FROM tb_RegisterEmployee ";
                cmd = new SqlCommand(sql, cnn);
                int counts = Convert.ToInt32(cmd.ExecuteScalar());

                int id = 10000;
                for (int i = 0; i <= counts; i++)
                {
                    id += 1;
                }
                txtEmployeeID.Text = z + id.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!!! " + ex);

            }
            string x = "";
            for (int y = 0; y <= 6; y++)
            {

                x += Convert.ToString(rand.Next(0, 9));

            }
            txtPassword.Text = x.ToString();
            

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            try
            {
                sql = "SELECT * FROM tb_RegisterEmployee WHERE EmployeeID like'" + txtFind.Text + "'";
                cmd = new SqlCommand(sql, cnn);

                read = cmd.ExecuteReader();
                read.Read();
                if (read.HasRows)
                {
                    txtEmployeeID.Text = read[0].ToString();
                    txtFname.Text = read[1].ToString();
                    TxtMname.Text = read.GetValue(2).ToString();
                    txtLname.Text = read.GetValue(3).ToString();
                    cmbCivilStatus.Text = read.GetValue(4).ToString();
                    cmbGender.Text = read.GetValue(5).ToString();
                    txtMobileNo.Text = read.GetValue(6).ToString();
                    txtTelNo.Text = read.GetValue(7).ToString();
                    txtEmail.Text = read.GetValue(8).ToString();
                    txtBirthPlace.Text = read.GetValue(9).ToString();
                    txtReligion.Text = read.GetValue(10).ToString();
                    txtAge.Text = read.GetValue(11).ToString();
                    dtDateOfBirth.Text = read.GetValue(12).ToString();
                    cmbPosition.Text = read.GetValue(13).ToString();
                    cmbDepartment.Text = read.GetValue(14).ToString();
                    cmbContract.Text = read.GetValue(15).ToString();
                    cmbEmpStatus.Text = read.GetValue(16).ToString();
                    txtContactName.Text = read.GetValue(17).ToString();
                    txtNumber.Text = read.GetValue(18).ToString();
                    txtCtellno.Text = read.GetValue(19).ToString();
                    txtAddressContact.Text = read.GetValue(20).ToString();
                    txtCityAddress.Text = read.GetValue(21).ToString();
                    txtTin.Text = read.GetValue(22).ToString();
                    txtSSS.Text = read.GetValue(23).ToString();
                    txtPagibig.Text = read.GetValue(24).ToString();
                    txtPhilHealth.Text = read.GetValue(25).ToString();
                    dtDateHired.Text = read.GetValue(26).ToString();
                    txtBasicRate.Text = read.GetValue(28).ToString();
                    txtPassword.Text = read.GetValue(29).ToString();
                    byte[] img = (byte[])(read[27]);
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        pbEmployeeID.Image = Image.FromStream(ms);


                    }

                    btnUpdate.Enabled = true;
                    btnSave.Enabled = false;
                    Enable();
                    read.Close();
                    txtPassword.ReadOnly = false;
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

        private void btnBrowse_Click_1(object sender, EventArgs e)
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            string tin = txtTin.Text, sss = txtSSS.Text, philhealth = txtPhilHealth.Text, pagibig = txtPagibig.Text;
            DialogResult save = MessageBox.Show("Are you sure you want to save?", "Payroll Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (save == DialogResult.Yes)
            {
                if (ckInfo.Checked == true)
                {
                    if (txtFname.Text == "" || txtLname.Text == "" || cmbCivilStatus.Text == "" || cmbGender.Text == "" || txtMobileNo.Text == "" || txtAge.Text == "" || dtDateOfBirth.Text == "" || cmbPosition.Text == "" || cmbDepartment.Text == "" || cmbContract.Text == "" || cmbEmpStatus.Text == "" || txtContactName.Text == "" || txtNumber.Text == "" || txtAddressContact.Text == "" || txtCityAddress.Text == "" || txtBasicRate.Text == "" || dtDateHired.Text == "")
                    {
                        MessageBox.Show("Please fill up all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //First Name
                        if (txtFname.Text == "")
                        {
                            lbFname.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbFname.ForeColor = Color.Black;
                        }
                        //Last Name
                        if (txtLname.Text == "")
                        {
                            lbLname.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbLname.ForeColor = Color.Black;
                        }
                        //Civil status
                        if (cmbCivilStatus.Text == "")
                        {
                            lbCivilStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCivilStatus.ForeColor = Color.Black;
                        }
                        //Gender
                        if (cmbGender.Text == "")
                        {
                            llbGender.ForeColor = Color.Red;
                        }
                        else
                        {
                            llbGender.ForeColor = Color.Black;
                        }
                        //empNo
                        if (txtMobileNo.Text == "")
                        {
                            lbMobileNo.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbMobileNo.ForeColor = Color.Black;
                        }
                        //Age
                        if (txtAge.Text == "")
                        {
                            lbAge.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbAge.ForeColor = Color.Black;
                        }
                        //bday
                        if (dtDateOfBirth.Text == DateTime.Today.ToString("MMM/dd/yyyy"))
                        {
                            lbDateofBirth.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbDateofBirth.ForeColor = Color.Black;
                        }
                        //position
                        if (cmbPosition.Text == "")
                        {
                            lbPosition.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbPosition.ForeColor = Color.Black;
                        }
                        //department
                        if (cmbDepartment.Text == "")
                        {
                            lbDepartmen.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbDepartmen.ForeColor = Color.Black;
                        }
                        //contract
                        if (cmbContract.Text == "")
                        {
                            lbTypeOfContract.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbTypeOfContract.ForeColor = Color.Black;
                        }
                        //status
                        if (cmbEmpStatus.Text == "")
                        {
                            lbStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbStatus.ForeColor = Color.Black;
                        }
                        //Contact name
                        if (txtContactName.Text == "")
                        {
                            lbCname.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCname.ForeColor = Color.Black;
                        }
                        //contact number
                        if (txtNumber.Text == "")
                        {
                            lbCMobile.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCMobile.ForeColor = Color.Black;
                        }
                        //
                        if (txtAddressContact.Text == "")
                        {
                            lbCaddress.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCaddress.ForeColor = Color.Black;
                        }
                        //Emp adress
                        if (txtCityAddress.Text == "")
                        {
                            lbAddress.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbAddress.ForeColor = Color.Black;
                        }
                        //basicrate
                        if (txtBasicRate.Text == "")
                        {
                            lbRate.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbRate.ForeColor = Color.Black;
                        }
                        //datehired
                        if (lbDateHired.Text == DateTime.Today.ToString("MMM/dd/yyyy"))
                        {
                            DialogResult hired = MessageBox.Show("Are you sure you hired this employee the same date?", "Wait!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            lbDateHired.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbDateHired.ForeColor = Color.Black;
                        }
                        if(pbEmployeeID.Image==null)
                        {
                            lbpicture.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbpicture.ForeColor = Color.Black;
                        }
                        return;

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
                            try
                            {
                                lbpicture.ForeColor = Color.Black;
                                byte[] img = null;
                                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                                BinaryReader br = new BinaryReader(fs);
                                img = br.ReadBytes((int)fs.Length);
                                sql = "INSERT INTO tb_RegisterEmployee(EmployeeID,Fname,Mname,Lname,CivilStatus,Gender,MobileNo,Telno,Email,BirthPlace,Religion,Age,Bday,Position,Department,TypeOfContract,EmployeeStatus,ContactName,MobileContact,ContactTelno,AddressContact,CityAddressEmp,TinNO,SSSNO,Pagibig,PhilHealth,DateHired,empPicture,basicRate,empPassword) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + TxtMname.Text + "','" + txtLname.Text + "','" + cmbCivilStatus.Text + "','" + cmbGender.Text + "','" + txtMobileNo.Text + "','"+txtTelNo.Text+"','" + txtEmail.Text + "','" + txtBirthPlace.Text + "','" + txtReligion.Text + "','" + txtAge.Text + "','" + dtDateOfBirth.Text + "','" + cmbPosition.Text + "','" + cmbDepartment.Text + "','" + cmbContract.Text + "','" + cmbEmpStatus.Text + "','" + txtContactName.Text + "','" + txtNumber.Text + "','"+txtCtellno.Text+"','" + txtAddressContact.Text + "','" + txtCityAddress.Text + "','" + tin + "','" + sss + "','" + pagibig + "','" + philhealth + "','" + dtDateHired.Text + "', @img, '" + txtBasicRate.Text + "','" + txtPassword.Text + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.Parameters.Add(new SqlParameter("@img", img));
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Employee Record Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmd.Dispose();
                                {

                                    sql = "INSERT INTO tb_employeeUSER(employeeID,employeePassword,Types) VALUES('"+txtEmployeeID.Text+"','"+txtPassword.Text+"','"+cmbEmpStatus.Text+"')";
                                    cmd = new SqlCommand(sql, cnn);
                                    cmd.ExecuteNonQuery();

                                }
                                clear();
                                Disable();
                                ButtonDisable();
                                cmbPositions();
                                cmbDepartments();
                                cmbTOC();
                                Status();
                                CivilStatus();
                                gender();
                                btnNew.Visible = true;
                                btnSave.Visible = false;
                                forecolorBlack();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR!" + ex);
                            }
                        }
                    }
                }
                else if (ckInfo.Checked == false)
                {
                    if (txtFname.Text == "" || txtLname.Text == "" || cmbCivilStatus.Text == "" || cmbGender.Text == "" || txtMobileNo.Text == "" || txtAge.Text == "" || dtDateOfBirth.Text == "" || cmbPosition.Text == "" || cmbDepartment.Text == "" || cmbContract.Text == "" || cmbEmpStatus.Text == "" || txtContactName.Text == "" || txtNumber.Text == "" || txtAddressContact.Text == "" || txtCityAddress.Text == "" || txtBasicRate.Text == "" || dtDateHired.Text == "")
                    {
                        MessageBox.Show("Please fill up all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //First Name
                        if (txtFname.Text == "")
                        {
                            lbFname.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbFname.ForeColor = Color.Black;
                        }
                        //Last Name
                        if (txtLname.Text == "")
                        {
                            lbLname.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbLname.ForeColor = Color.Black;
                        }
                        //Civil status
                        if (cmbCivilStatus.Text == "")
                        {
                            lbCivilStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCivilStatus.ForeColor = Color.Black;
                        }
                        //Gender
                        if (cmbGender.Text == "")
                        {
                            llbGender.ForeColor = Color.Red;
                        }
                        else
                        {
                            llbGender.ForeColor = Color.Black;
                        }
                        //empNo
                        if (txtMobileNo.Text == "")
                        {
                            lbMobileNo.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbMobileNo.ForeColor = Color.Black;
                        }
                        //Age
                        if (txtAge.Text == "")
                        {
                            lbAge.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbAge.ForeColor = Color.Black;
                        }
                        //bday
                        if (dtDateOfBirth.Text == DateTime.Today.ToString("MMM/dd/yyyy"))
                        {
                            lbDateofBirth.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbDateofBirth.ForeColor = Color.Black;
                        }
                        //position
                        if (cmbPosition.Text == "")
                        {
                            lbPosition.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbPosition.ForeColor = Color.Black;
                        }
                        //department
                        if (cmbDepartment.Text == "")
                        {
                            lbDepartmen.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbDepartmen.ForeColor = Color.Black;
                        }
                        //contract
                        if (cmbContract.Text == "")
                        {
                            lbTypeOfContract.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbTypeOfContract.ForeColor = Color.Black;
                        }
                        //status
                        if (cmbEmpStatus.Text == "")
                        {
                            lbStatus.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbStatus.ForeColor = Color.Black;
                        }
                        //Contact name
                        if (txtContactName.Text == "")
                        {
                            lbCname.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCname.ForeColor = Color.Black;
                        }
                        //contact number
                        if (txtNumber.Text == "")
                        {
                            lbCMobile.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCMobile.ForeColor = Color.Black;
                        }
                        //
                        if (txtAddressContact.Text == "")
                        {
                            lbCaddress.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbCaddress.ForeColor = Color.Black;
                        }
                        //Emp adress
                        if (txtCityAddress.Text == "")
                        {
                            lbAddress.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbAddress.ForeColor = Color.Black;
                        }
                        //basicrate
                        if (txtBasicRate.Text == "")
                        {
                            lbRate.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbRate.ForeColor = Color.Black;
                        }
                        //datehired
                        if (lbDateHired.Text == DateTime.Today.ToString("MMM/dd/yyyy"))
                        {
                            DialogResult hired = MessageBox.Show("Are you sure you hired this employee the same date?", "Wait!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            lbDateHired.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbDateHired.ForeColor = Color.Black;
                        }
                        if (pbEmployeeID.Image == null)
                        {
                            lbpicture.ForeColor = Color.Red;
                        }
                        else
                        {
                            lbpicture.ForeColor = Color.Black;
                        }
                        return;

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
                        try
                        {
                            byte[] img = null;
                            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            img = br.ReadBytes((int)fs.Length);
                            sql = "INSERT INTO tb_RegisterEmployee(EmployeeID,Fname,Mname,Lname,CivilStatus,Gender,MobileNo,Telno,Email,BirthPlace,Religion,Age,Bday,Position,Department,TypeOfContract,EmployeeStatus,ContactName,MobileContact,ContactTelno,AddressContact,CityAddressEmp,TinNO,SSSNO,Pagibig,PhilHealth,DateHired,empPicture,basicRate,empPassword) VALUES('" + txtEmployeeID.Text + "','" + txtFname.Text + "','" + TxtMname.Text + "','" + txtLname.Text + "','" + cmbCivilStatus.Text + "','" + cmbGender.Text + "','" + txtMobileNo.Text + "','" + txtTelNo.Text + "','" + txtEmail.Text + "','" + txtBirthPlace.Text + "','" + txtReligion.Text + "','" + txtAge.Text + "','" + dtDateOfBirth.Text + "','" + cmbPosition.Text + "','" + cmbDepartment.Text + "','" + cmbContract.Text + "','" + cmbEmpStatus.Text + "','" + txtContactName.Text + "','" + txtNumber.Text + "','" + txtCtellno.Text + "','" + txtAddressContact.Text + "','" + txtCityAddress.Text + "','" + tin + "','" + sss + "','" + pagibig + "','" + philhealth + "','" + dtDateHired.Text + "', @img, '" + txtBasicRate.Text + "','" + txtPassword.Text + "')";
                            cmd = new SqlCommand(sql, cnn);
                            cmd.Parameters.Add(new SqlParameter("@img", img));
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee Record Successfully Saved!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmd.Dispose();
                           
                            {
                                string emp = "EMPLOYEE";
                                sql = "INSERT INTO tb_employeeUSER(employeeID,employeePassword,Types) VALUES('" + txtEmployeeID.Text + "','" + txtPassword.Text + "','" + emp + "')";
                                cmd = new SqlCommand(sql, cnn);
                                cmd.ExecuteNonQuery();

                            }
                            clear();
                            Disable();
                            ButtonDisable();
                            cmbPositions();
                            cmbDepartments();
                            cmbTOC();
                            Status();
                            CivilStatus();
                            gender();
                            btnNew.Visible = true;
                            btnSave.Visible = false;
                            forecolorBlack();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR!" + ex);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error!!");
                }
                dtDateOfBirth.Text = DateTime.Now.ToString("MMM/dd/yyyy");
            }
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
                        sql = "UPDATE tb_RegisterEmployee SET Fname= '" + txtFname.Text + "', Mname= '" + TxtMname.Text + "', Lname= '" + txtLname.Text + "', CivilStatus= '" + cmbCivilStatus.Text + "', Gender= '" + cmbGender.Text + "', MobileNo= '" + txtMobileNo.Text + "', Telno= '" + txtTelNo.Text + "' , Email= '" + txtEmail.Text + "', BirthPlace= '" + txtBirthPlace.Text + "', Religion= '" + txtReligion.Text + "', Age= '" + txtAge.Text + "', Bday= '" + dtDateOfBirth.Text + "', Position= '" + cmbPosition.Text + "', Department= '" + cmbDepartment.Text + "', TypeOfContract= '" + cmbContract.Text + "', EmployeeStatus= '" + cmbEmpStatus.Text + "', ContactName= '" + txtContactName.Text + "', MobileContact= '" + txtNumber.Text + "', ContactTelno= '" + txtCtellno.Text + "',  AddressContact= '" + txtAddressContact.Text + "', CityAddressEmp= '" + txtCityAddress.Text + "', TinNO= '" + txtTin.Text + "', SSSNO= '" + txtSSS.Text + "', Pagibig= '" + txtPagibig.Text + "', PhilHealth= '" + txtPhilHealth.Text + "', DateHired= '" + dtDateHired.Text + "', empPassword = '" + txtPassword.Text + "', basicRate='" + txtBasicRate.Text + "' WHERE EmployeeID like'" + txtEmployeeID.Text + "' ";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Data has been updated!", "Successful");
                        cmd.Dispose();
                        clear();
                        Disable();
                        ButtonDisable();
                        cmbPositions();
                        cmbDepartments();
                        cmbTOC();
                        Status();
                        CivilStatus();
                        gender();
                        read.Close();
                        txtPassword.ReadOnly = true;
                    }
                    else if (okay == "NOTOKAY")
                    {
                        byte[] img = null;
                        FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);
                        sql = "UPDATE tb_RegisterEmployee SET Fname= '" + txtFname.Text + "', Mname= '" + TxtMname.Text + "', Lname= '" + txtLname.Text + "', CivilStatus= '" + cmbCivilStatus.Text + "', Gender= '" + cmbGender.Text + "', MobileNo= '" + txtMobileNo.Text + "', Telno= '"+txtTelNo.Text+"' , Email= '" + txtEmail.Text + "', BirthPlace= '" + txtBirthPlace.Text + "', Religion= '" + txtReligion.Text + "', Age= '" + txtAge.Text + "', Bday= '" + dtDateOfBirth.Text + "', Position= '" + cmbPosition.Text + "', Department= '" + cmbDepartment.Text + "', TypeOfContract= '" + cmbContract.Text + "', EmployeeStatus= '" + cmbEmpStatus.Text + "', ContactName= '" + txtContactName.Text + "', MobileContact= '" + txtNumber.Text + "', ContactTelno= '"+txtCtellno.Text+"', AddressContact= '" + txtAddressContact.Text + "', CityAddressEmp= '" + txtCityAddress.Text + "', TinNO= '" + txtTin.Text + "', SSSNO= '" + txtSSS.Text + "', Pagibig= '" + txtPagibig.Text + "', PhilHealth= '" + txtPhilHealth.Text + "', DateHired= '" + dtDateHired.Text + "', empPassword = '" + txtPassword.Text + "', empPicture=@img, basicRate=@basicRate WHERE EmployeeID like'" + txtEmployeeID.Text + "' ";
                        cmd = new SqlCommand(sql, cnn);
                        cmd.Parameters.AddWithValue("@img", img);
                        cmd.Parameters.AddWithValue("@basicRate", txtBasicRate.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee Data has been updated!", "Successful");
                        cmd.Dispose();
                        clear();
                        Disable();
                        ButtonDisable();
                        cmbPositions();
                        cmbDepartments();
                        cmbTOC();
                        Status();
                        CivilStatus();
                        gender();
                        read.Close();
                        txtPassword.ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!  " + ex);
                }
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            cmbPositions();
            cmbDepartments();
            cmbTOC();
            Status();
            CivilStatus();
            gender();
            ButtonDisable();
            Disable();
            btnSave.Visible = false;
            btnNew.Visible = true;
            txtPassword.ReadOnly = true;
        }

        private void txtMobileNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void txtTin_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtSSS_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPagibig_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPhilHealth_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtBasicRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.Text == "Faculty")
            {
                cmbPosition.Items.Clear();
                cmbPosition.Items.Add("Teacher");
                cmbPosition.Items.Add("Instructor");
            }
            else if (cmbDepartment.Text == "Staff")
            {
                cmbPosition.Items.Clear();
                cmbPosition.Items.Add("Guard");
                cmbPosition.Items.Add("Maintenance");
            }
            else if (cmbDepartment.Text == "Admin")
            {
                cmbPosition.Items.Clear();
                cmbPosition.Items.Add("Cashier");
                cmbPosition.Items.Add("Registrar");
            }
        }

        private void cmbDepartment_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
          
        }

        private void cmbPosition_DropDown_1(object sender, EventArgs e)
        {
            if (cmbPosition.Items.Count==0)
            {
                MessageBox.Show("Please choose department first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                cmbDepartment.DroppedDown = true;
            }

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

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
    }
}
