namespace PMSv3._0
{
    partial class frmAdminMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminMain));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.iconclose = new System.Windows.Forms.PictureBox();
            this.iconminimize = new System.Windows.Forms.PictureBox();
            this.LogoSmall = new System.Windows.Forms.PictureBox();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelCenterMain = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.frmUsers = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.tblReports = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.moveright = new System.Windows.Forms.Timer(this.components);
            this.moveleft = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoSmall)).BeginInit();
            this.panelCenterMain.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
            this.panelHeader.Controls.Add(this.iconclose);
            this.panelHeader.Controls.Add(this.iconminimize);
            this.panelHeader.Controls.Add(this.LogoSmall);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1100, 43);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // iconclose
            // 
            this.iconclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconclose.Image = ((System.Drawing.Image)(resources.GetObject("iconclose.Image")));
            this.iconclose.Location = new System.Drawing.Point(1058, 9);
            this.iconclose.Name = "iconclose";
            this.iconclose.Size = new System.Drawing.Size(32, 25);
            this.iconclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconclose.TabIndex = 14;
            this.iconclose.TabStop = false;
            this.iconclose.Click += new System.EventHandler(this.iconclose_Click);
            // 
            // iconminimize
            // 
            this.iconminimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconminimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconminimize.Image = ((System.Drawing.Image)(resources.GetObject("iconminimize.Image")));
            this.iconminimize.Location = new System.Drawing.Point(1028, 9);
            this.iconminimize.Name = "iconminimize";
            this.iconminimize.Size = new System.Drawing.Size(24, 25);
            this.iconminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconminimize.TabIndex = 13;
            this.iconminimize.TabStop = false;
            this.iconminimize.Click += new System.EventHandler(this.iconminimize_Click);
            // 
            // LogoSmall
            // 
            this.LogoSmall.Image = global::PMSv3._0.Properties.Resources._21751396_764875777053037_4421086110887965149_n;
            this.LogoSmall.Location = new System.Drawing.Point(9, 9);
            this.LogoSmall.Name = "LogoSmall";
            this.LogoSmall.Size = new System.Drawing.Size(28, 28);
            this.LogoSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoSmall.TabIndex = 5;
            this.LogoSmall.TabStop = false;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(250, 43);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(850, 457);
            this.panelCenter.TabIndex = 6;
            // 
            // panelCenterMain
            // 
            this.panelCenterMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(76)))));
            this.panelCenterMain.Controls.Add(this.panelCenter);
            this.panelCenterMain.Controls.Add(this.panelBottom);
            this.panelCenterMain.Controls.Add(this.panelMenu);
            this.panelCenterMain.Controls.Add(this.panelHeader);
            this.panelCenterMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterMain.Location = new System.Drawing.Point(0, 0);
            this.panelCenterMain.Name = "panelCenterMain";
            this.panelCenterMain.Size = new System.Drawing.Size(1100, 600);
            this.panelCenterMain.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.panelBottom.Controls.Add(this.lblPass);
            this.panelBottom.Controls.Add(this.lblUser);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.lblTime);
            this.panelBottom.Controls.Add(this.lblDate);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(250, 500);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(850, 100);
            this.panelBottom.TabIndex = 5;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.White;
            this.lblPass.Location = new System.Drawing.Point(3, 3);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(80, 20);
            this.lblPass.TabIndex = 11;
            this.lblPass.Text = "Admin to";
            this.lblPass.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(101, 71);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(80, 20);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "Admin to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Welcome :";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.LightGray;
            this.lblTime.Location = new System.Drawing.Point(583, 17);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(205, 54);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "12:49:45";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(575, 71);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(237, 20);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Wednesday, December 26 2018";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.panelMenu.Controls.Add(this.frmUsers);
            this.panelMenu.Controls.Add(this.btnTables);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.tblReports);
            this.panelMenu.Controls.Add(this.btnTransaction);
            this.panelMenu.Controls.Add(this.btnMaintenance);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 43);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 557);
            this.panelMenu.TabIndex = 2;
            // 
            // frmUsers
            // 
            this.frmUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frmUsers.FlatAppearance.BorderSize = 0;
            this.frmUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.frmUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frmUsers.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmUsers.ForeColor = System.Drawing.Color.White;
            this.frmUsers.Image = ((System.Drawing.Image)(resources.GetObject("frmUsers.Image")));
            this.frmUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmUsers.Location = new System.Drawing.Point(0, 190);
            this.frmUsers.Name = "frmUsers";
            this.frmUsers.Size = new System.Drawing.Size(250, 40);
            this.frmUsers.TabIndex = 32;
            this.frmUsers.Text = "Users";
            this.frmUsers.UseVisualStyleBackColor = true;
            this.frmUsers.Click += new System.EventHandler(this.frmUsers_Click);
            // 
            // btnTables
            // 
            this.btnTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTables.FlatAppearance.BorderSize = 0;
            this.btnTables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTables.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTables.ForeColor = System.Drawing.Color.White;
            this.btnTables.Image = ((System.Drawing.Image)(resources.GetObject("btnTables.Image")));
            this.btnTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTables.Location = new System.Drawing.Point(0, 144);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(250, 40);
            this.btnTables.TabIndex = 31;
            this.btnTables.Text = "Employee";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(0, 518);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(250, 39);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 30;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 98);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(250, 40);
            this.btnHome.TabIndex = 20;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tblReports
            // 
            this.tblReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tblReports.FlatAppearance.BorderSize = 0;
            this.tblReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tblReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tblReports.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblReports.ForeColor = System.Drawing.Color.White;
            this.tblReports.Image = ((System.Drawing.Image)(resources.GetObject("tblReports.Image")));
            this.tblReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tblReports.Location = new System.Drawing.Point(0, 282);
            this.tblReports.Name = "tblReports";
            this.tblReports.Size = new System.Drawing.Size(250, 40);
            this.tblReports.TabIndex = 23;
            this.tblReports.Text = "Reports";
            this.tblReports.UseVisualStyleBackColor = true;
            this.tblReports.Click += new System.EventHandler(this.frmReports_Click);
            // 
            // btnTransaction
            // 
            this.btnTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransaction.FlatAppearance.BorderSize = 0;
            this.btnTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransaction.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransaction.ForeColor = System.Drawing.Color.White;
            this.btnTransaction.Image = ((System.Drawing.Image)(resources.GetObject("btnTransaction.Image")));
            this.btnTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransaction.Location = new System.Drawing.Point(-3, 236);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(250, 40);
            this.btnTransaction.TabIndex = 21;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = true;
            this.btnTransaction.Click += new System.EventHandler(this.btnTransaction_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenance.FlatAppearance.BorderSize = 0;
            this.btnMaintenance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenance.ForeColor = System.Drawing.Color.White;
            this.btnMaintenance.Image = ((System.Drawing.Image)(resources.GetObject("btnMaintenance.Image")));
            this.btnMaintenance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaintenance.Location = new System.Drawing.Point(0, 328);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(250, 40);
            this.btnMaintenance.TabIndex = 22;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.UseVisualStyleBackColor = true;
            this.btnMaintenance.Visible = false;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Image = global::PMSv3._0.Properties.Resources.menu2;
            this.btnMenu.Location = new System.Drawing.Point(202, 2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(43, 37);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMenu.TabIndex = 12;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmAdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panelCenterMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminMain_FormClosed);
            this.Load += new System.EventHandler(this.frmAdminMain_Load);
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoSmall)).EndInit();
            this.panelCenterMain.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoSmall;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelCenterMain;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.PictureBox iconclose;
        private System.Windows.Forms.PictureBox iconminimize;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer moveright;
        private System.Windows.Forms.Timer moveleft;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnLogout;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblPass;
        public System.Windows.Forms.Button tblReports;
        public System.Windows.Forms.Button btnTransaction;
        public System.Windows.Forms.Button btnTables;
        public System.Windows.Forms.Button frmUsers;
        public System.Windows.Forms.Button btnMaintenance;
    }
}

