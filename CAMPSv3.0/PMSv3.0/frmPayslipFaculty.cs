using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace PMSv3._0
{
    public partial class frmPayslipFaculty : Form
    {
        SqlConnection cnn;
        public SqlCommand cmd;
        frmLogin login = new frmLogin();
        public DataSet1 ds;
        public SqlDataAdapter da;
        public SqlDataReader dr;

        public frmPayslipFaculty()
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
            rpPayslipFaculty.LocalReport.ReportPath = @"Reports\PaySlipFaculty.rdlc";
            rpPayslipFaculty.LocalReport.DataSources.Clear();
            da = new SqlDataAdapter();
            ds = new DataSet1();

            string sql = ("Select * from VtblPayslipFaculty");
            da.SelectCommand = new SqlCommand(sql, cnn);
            da.Fill(ds.Tables["VtblPayslipFaculty"]);
            rptDataSource = new ReportDataSource("PayslipFaculty", ds.Tables["VtblPayslipFaculty"]);
            rpPayslipFaculty.LocalReport.DataSources.Add(rptDataSource);

            rpPayslipFaculty.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            this.rpPayslipFaculty.RefreshReport();
            //if (DateTime.Now.Day >= 01 && DateTime.Now.Day <= 15)
            //{
            //    string sql = ("Select * from VtblPayslip");
            //    da.SelectCommand = new SqlCommand(sql, cnn);
            //    da.Fill(ds.Tables["VtblPayslip"]);
            //    rptDataSource = new ReportDataSource("PaySlip", ds.Tables["VtblPayslip"]);
            //    rpPayslip.LocalReport.DataSources.Add(rptDataSource);

            //    rpPayslip.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            //    this.rpPayslip.RefreshReport();

            //}
            //else if (DateTime.Now.Day >= 16 && DateTime.Now.Day <= 31)
            //{
            //    string sql = ("Select * from VtblPayslip");
            //    da.SelectCommand = new SqlCommand(sql, cnn);
            //    da.Fill(ds.Tables["VtblPayslip"]);
            //    rptDataSource = new ReportDataSource("PaySlip", ds.Tables["VtblPayslip"]);
            //    rpPayslip.LocalReport.DataSources.Add(rptDataSource);

            //    rpPayslip.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            //    this.rpPayslip.RefreshReport();
            //}
        }
        private void frmPayslipFaculty_Load(object sender, EventArgs e)
        {
            loadbatch();
        }
    }
}
