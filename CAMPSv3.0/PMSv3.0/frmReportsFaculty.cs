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
using Microsoft.Reporting.WinForms;

namespace PMSv3._0
{ 
    public partial class frmReportsFaculty : Form
    {
        SqlConnection cnn;
        public SqlCommand cmd;
        frmLogin login = new frmLogin();
        public DataSet1 ds;
        public SqlDataAdapter da;
        public SqlDataReader dr;

        public frmReportsFaculty()
        {
            InitializeComponent();
            cnn = new SqlConnection(login.connection);
            cnn.Open();
        }

        public void loadbatch()
        {
            Cursor.Current = Cursors.WaitCursor;
            cnn = new SqlConnection(login.connection);
            cnn.Open();
            ReportDataSource rptDataSource;
            rPayroll_Report.LocalReport.ReportPath = @"Reports\PayrollReport.rdlc";
            rPayroll_Report.LocalReport.DataSources.Clear();
            da = new SqlDataAdapter();
            ds = new DataSet1();
            if (DateTime.Now.Day >= 01 && DateTime.Now.Day <= 15)
            {
                string sql = ("Select * from tb_BatchProcess ");
                da.SelectCommand = new SqlCommand(sql, cnn);
                da.Fill(ds.Tables["tb_BatchProcess"]);
                rptDataSource = new ReportDataSource("Payroll_Report", ds.Tables["tb_BatchProcess"]);
                rPayroll_Report.LocalReport.DataSources.Add(rptDataSource);

                rPayroll_Report.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
                this.rPayroll_Report.RefreshReport();
           
            }
            else if (DateTime.Now.Day >= 16 && DateTime.Now.Day <= 31)
            {
                string sql = ("Select * from tb_BatchProcess");
                da.SelectCommand = new SqlCommand(sql, cnn);
                da.Fill(ds.Tables["tb_BatchProcess"]);
                rptDataSource = new ReportDataSource("Payroll_Report", ds.Tables["tb_BatchProcess"]);
                rPayroll_Report.LocalReport.DataSources.Add(rptDataSource);

                rPayroll_Report.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
                this.rPayroll_Report.RefreshReport();
           
            }
        }
        private void frmCalculate_Load(object sender, EventArgs e)
        {
            loadbatch();

        }

    

        private void rPaySlip_Load(object sender, EventArgs e)
        {

        }
    }
}
