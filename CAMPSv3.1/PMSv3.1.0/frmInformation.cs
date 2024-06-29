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

namespace PMSv3._1._0
{
    public partial class frmInformation : Form
    {
        string sql;
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader read;
        frmLogin login = new frmLogin();

        public frmInformation()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }
        private void frmInformation_Load(object sender, EventArgs e)
        {
            View();
        }

        private void View()
        {
            sql = "Select * from tb_Employee where EmployeeID like '" + lEmployeeID.Text + "'";
            cmd = new SqlCommand(sql, cnn);
            read = cmd.ExecuteReader();

            read.Read();
            if (read.HasRows)
            {
                lname.Text = read.GetValue(3).ToString();
                lname.Text +=", "+ read.GetValue(1).ToString();
                lname.Text +=" "+ read.GetValue(2).ToString();
                lposition.Text = read.GetValue(19).ToString();
                byte[] img = (byte[])(read[17]);
                if (img != null)
                {
                    MemoryStream ms = new MemoryStream(img);
                    pbEmployee.Image = Image.FromStream(ms);
                }
                read.Close();
            }
        }
    }
}
