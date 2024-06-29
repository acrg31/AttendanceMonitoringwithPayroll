using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSv3._0
{
    public partial class frmAdminMain : Form
    {
        public frmAdminMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        int LX, LY, SW, SH;

        private void MainForm(object FormAll)
        {
            if (this.panelCenter.Controls.Count > 0)
                this.panelCenter.Controls.RemoveAt(0);
            Form fh = FormAll as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelCenter.Controls.Add(fh);
            this.panelCenter.Tag = fh;
            fh.Show();
        }

        private void MainFormLogo()
        {
            MainForm(new frmLogo());
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //if (panelMenu.Width == 230)
            //{
            //    this.moveright.Enabled = true;
            //}
            //else if (panelMenu.Width == 55)
            //    this.moveleft.Enabled = true;

            if (panelMenu.Width == 55)
            {
                panelMenu.Width = 230;
            }
            else

                panelMenu.Width = 55;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lblTime.Text = DateTime.Now.ToString("hh:mm:ssss");
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void iconminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmAdminMain_Load(object sender, EventArgs e)
        {
            MainFormLogo();
        }

        private void frmAdminMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainFormLogo();
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmHome frmHome = new frmHome();
            frmHome.FormClosed += new FormClosedEventHandler(frmAdminMain_FormClosed);
            MainForm(frmHome);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            frmTransaction frmTransaction = new frmTransaction();
            frmTransaction.FormClosed += new FormClosedEventHandler(frmAdminMain_FormClosed);
            MainForm(frmTransaction);
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmMaintenance frmMaintenance = new frmMaintenance();
            frmMaintenance.FormClosed += new FormClosedEventHandler(frmAdminMain_FormClosed);
            MainForm(frmMaintenance);
        }

        private void frmReports_Click(object sender, EventArgs e)
        {
            frmReports frmReports = new frmReports();
            frmReports.FormClosed += new FormClosedEventHandler(frmAdminMain_FormClosed);
            MainForm(frmReports);
        }

        

        private void iconclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int tolerance = 15;

        private void frmUsers_Click(object sender, EventArgs e)
        {
            frmUser frmTables = new frmUser();
            frmTables.FormClosed += new FormClosedEventHandler(frmAdminMain_FormClosed);
            MainForm(frmTables);
        }

        private const int WM_NCHITTEST = 132;

        private void btnTables_Click(object sender, EventArgs e)
        {
            frmEmployee frmTables = new frmEmployee();
            frmTables.FormClosed += new FormClosedEventHandler(frmAdminMain_FormClosed);
            MainForm(frmTables);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult logout = MessageBox.Show("Are you sure you want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (logout == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
               
                this.Hide();
                login.Show();
            }
        }


        
    }
}
