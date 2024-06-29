namespace PMSv3._1._0
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.lTime = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lUsername = new System.Windows.Forms.Label();
            this.lFirstname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCenterMain = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.LogoCenter = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnInformation = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.iconclose = new System.Windows.Forms.PictureBox();
            this.iconminimize = new System.Windows.Forms.PictureBox();
            this.LogoSmall = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelBottom.SuspendLayout();
            this.panelCenterMain.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCenter)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // lTime
            // 
            this.lTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTime.AutoSize = true;
            this.lTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTime.ForeColor = System.Drawing.Color.LightGray;
            this.lTime.Location = new System.Drawing.Point(513, 7);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(205, 54);
            this.lTime.TabIndex = 5;
            this.lTime.Text = "12:49:45";
            // 
            // lDate
            // 
            this.lDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lDate.AutoSize = true;
            this.lDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lDate.ForeColor = System.Drawing.Color.White;
            this.lDate.Location = new System.Drawing.Point(555, 61);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(237, 20);
            this.lDate.TabIndex = 6;
            this.lDate.Text = "Wednesday, December 26 2018";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(61)))), ((int)(((byte)(69)))));
            this.panelBottom.Controls.Add(this.lUsername);
            this.panelBottom.Controls.Add(this.lFirstname);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.lTime);
            this.panelBottom.Controls.Add(this.lDate);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(250, 673);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(830, 88);
            this.panelBottom.TabIndex = 5;
            this.panelBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottom_Paint);
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsername.ForeColor = System.Drawing.Color.White;
            this.lUsername.Location = new System.Drawing.Point(357, 59);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(91, 20);
            this.lUsername.TabIndex = 9;
            this.lUsername.Text = "Username";
            this.lUsername.Visible = false;
            // 
            // lFirstname
            // 
            this.lFirstname.AutoSize = true;
            this.lFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFirstname.ForeColor = System.Drawing.Color.White;
            this.lFirstname.Location = new System.Drawing.Point(111, 61);
            this.lFirstname.Name = "lFirstname";
            this.lFirstname.Size = new System.Drawing.Size(45, 20);
            this.lFirstname.TabIndex = 8;
            this.lFirstname.Text = "------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome :";
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
            this.panelCenterMain.Size = new System.Drawing.Size(1080, 761);
            this.panelCenterMain.TabIndex = 2;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelCenter.Controls.Add(this.LogoCenter);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(250, 43);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(830, 630);
            this.panelCenter.TabIndex = 6;
            // 
            // LogoCenter
            // 
            this.LogoCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoCenter.BackColor = System.Drawing.Color.Transparent;
            this.LogoCenter.Image = ((System.Drawing.Image)(resources.GetObject("LogoCenter.Image")));
            this.LogoCenter.Location = new System.Drawing.Point(64, 98);
            this.LogoCenter.Name = "LogoCenter";
            this.LogoCenter.Size = new System.Drawing.Size(704, 347);
            this.LogoCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoCenter.TabIndex = 4;
            this.LogoCenter.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.panelMenu.Controls.Add(this.btnLogin);
            this.panelMenu.Controls.Add(this.btnInformation);
            this.panelMenu.Controls.Add(this.btnRecords);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 43);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 718);
            this.panelMenu.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(3, 144);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 40);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnInformation
            // 
            this.btnInformation.FlatAppearance.BorderSize = 0;
            this.btnInformation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformation.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformation.ForeColor = System.Drawing.Color.White;
            this.btnInformation.Image = ((System.Drawing.Image)(resources.GetObject("btnInformation.Image")));
            this.btnInformation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformation.Location = new System.Drawing.Point(0, 98);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(250, 40);
            this.btnInformation.TabIndex = 20;
            this.btnInformation.Text = "     Information";
            this.btnInformation.UseVisualStyleBackColor = true;
            this.btnInformation.Click += new System.EventHandler(this.btnInformation_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.FlatAppearance.BorderSize = 0;
            this.btnRecords.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecords.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecords.ForeColor = System.Drawing.Color.White;
            this.btnRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnRecords.Image")));
            this.btnRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.Location = new System.Drawing.Point(0, 190);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(250, 40);
            this.btnRecords.TabIndex = 22;
            this.btnRecords.Text = " Record/s";
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(3, 669);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(244, 42);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 13;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
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
            this.panelHeader.Size = new System.Drawing.Size(1080, 43);
            this.panelHeader.TabIndex = 1;
            // 
            // iconclose
            // 
            this.iconclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconclose.Image = ((System.Drawing.Image)(resources.GetObject("iconclose.Image")));
            this.iconclose.Location = new System.Drawing.Point(1038, 9);
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
            this.iconminimize.Location = new System.Drawing.Point(1010, 9);
            this.iconminimize.Name = "iconminimize";
            this.iconminimize.Size = new System.Drawing.Size(24, 25);
            this.iconminimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconminimize.TabIndex = 13;
            this.iconminimize.TabStop = false;
            this.iconminimize.Click += new System.EventHandler(this.iconminimize_Click);
            // 
            // LogoSmall
            // 
            this.LogoSmall.Image = global::PMSv3._1._0.Properties.Resources._21751396_764875777053037_4421086110887965149_n;
            this.LogoSmall.Location = new System.Drawing.Point(9, 9);
            this.LogoSmall.Name = "LogoSmall";
            this.LogoSmall.Size = new System.Drawing.Size(28, 28);
            this.LogoSmall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoSmall.TabIndex = 5;
            this.LogoSmall.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 761);
            this.Controls.Add(this.panelCenterMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeMenu_FormClosed);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelCenterMain.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoCenter)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoSmall)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInformation;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lDate;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelCenterMain;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox iconclose;
        private System.Windows.Forms.PictureBox iconminimize;
        private System.Windows.Forms.PictureBox LogoSmall;
        private System.Windows.Forms.Label lFirstname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox LogoCenter;
        public System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnLogin;
    }
}

