using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMSv3._0
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUnlocked unlock = new frmUnlocked();
            unlock.ShowDialog();
        }

        private void btnGiveSched_Click(object sender, EventArgs e)
        {
            new frmAdminForgot().Show();
        }

        private void btnRegisterEmployee_Click(object sender, EventArgs e)
        {
            frmRemainingLeave leave = new frmRemainingLeave();
            leave.ShowDialog();
        }
    }
}
