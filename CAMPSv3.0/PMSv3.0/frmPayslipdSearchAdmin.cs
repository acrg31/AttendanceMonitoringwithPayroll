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
    public partial class frmPayslipdSearchAdmin : Form
    {
        SqlConnection cnn;
        public SqlCommand cmd;
        frmLogin login = new frmLogin();
        public DataSet1 ds;
        public SqlDataAdapter da;
        public SqlDataReader dr;
        public frmPayslipdSearchAdmin()
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

            string sql = ("Select * from VtblPayslip WHERE EmployeeID like'" + txtSearch.Text + "'");
            da.SelectCommand = new SqlCommand(sql, cnn);
            da.Fill(ds.Tables["VtblPayslip"]);
            rptDataSource = new ReportDataSource("PaySlip", ds.Tables["VtblPayslip"]);
            rpPayslip.LocalReport.DataSources.Add(rptDataSource);

            rpPayslip.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            this.rpPayslip.RefreshReport();

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadbatch();
        }
    }
}
