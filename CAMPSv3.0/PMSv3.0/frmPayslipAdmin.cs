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
    public partial class frmPaySlip : Form
    {
        SqlConnection cnn;
        public SqlCommand cmd;
        frmLogin login = new frmLogin();
        public DataSet1 ds;
        public SqlDataAdapter da;
        public SqlDataReader dr;

        public frmPaySlip()
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
            rpPayslip.LocalReport.ReportPath = @"Reports\PaySlip.rdlc";
            rpPayslip.LocalReport.DataSources.Clear();
            da = new SqlDataAdapter();
            ds = new DataSet1();

            string sql = ("Select * from VtblPayslip");
            da.SelectCommand = new SqlCommand(sql, cnn);
            da.Fill(ds.Tables["VtblPayslip"]);
            rptDataSource = new ReportDataSource("Payslip", ds.Tables["VtblPayslip"]);
            rpPayslip.LocalReport.DataSources.Add(rptDataSource);

            rpPayslip.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            this.rpPayslip.RefreshReport();
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
        private void frmCalculate_Load(object sender, EventArgs e)
        {
            loadbatch();

            this.rpPayslip.RefreshReport();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void rPaySlip_Load(object sender, EventArgs e)
        {

        }
    }
}
